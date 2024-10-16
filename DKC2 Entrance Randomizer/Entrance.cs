using DKC2_Entrance_Randomizer.Constants;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DKC2_Entrance_Randomizer
{
    public class Entrance
    {
        public Int32 completeCode;
        public string name;
        private Int32 address;
        public Int32[] exits;
        public static Dictionary<Int32, int[]> sanity = new Dictionary<int, int[]>();
        public static Dictionary<Int32, string> nameByCompleteCode = new Dictionary<int, string>();
        public Int32 currentStage;
        public byte levelCode;
        public byte songCode;
        private byte thisEntrance;
        public static List<byte> songList = new List<byte>();
        public string LevelType;
        public static int musicLUTStart = 0x32fc29;


        // 0x38dd8e - matrix start
        // 0x38df9a - array from matrix start
        public Entrance(Int32 address, string name, byte levelCode, byte songCode, byte thisEntrance, params Int32[] exits)
        {
            this.address = address;
            this.name = name;
            this.levelCode = levelCode;
            this.songCode = songCode;
            this.thisEntrance = thisEntrance;
            // If we are not in a boss
            if (!BossLevelCodes.IsBossLevel(levelCode))
            {
                songList.Add(songCode);
                this.exits = exits;
            }
            else
            {
                this.exits = new int[] { }; 
            }
            completeCode = (levelCode << 8) | thisEntrance;

            nameByCompleteCode[completeCode] = name;
            sanity[completeCode] = exits;

            if (name.Contains("Bonus"))
            {
                LevelType = "Bonus";
            }
            else if (name.Contains("Warp"))
            {
                LevelType = "Warp";
            }
            else if (name.Contains("Room") || name.Contains("Cabin"))
            {
                LevelType = "Room";
            }
            else
            {
                LevelType = "Exit";
            }
        }

        public void RandomizeEntrance(ROM rom, List<Int32> available)
        {
            // Select index first
            int randomIndex = Defaults.rng.Next(0, available.Count);
            rom.Write16(address, available[randomIndex]);
            currentStage = available[randomIndex];
            // Remove used
            available.RemoveAt(randomIndex);
        }
        // Return a bool
        public bool[] Sanity(ROM rom)
        {
            Queue<Int32> queue = new Queue<Int32>();
            // Have we been here before?
            bool[] checklist = new bool[49920];

            queue.Enqueue(currentStage);
            // Find which ones are accessible
            while (queue.Count > 0)
            {
                // Pull (from bottom) next spoiler log into current
                var currentCode = queue.Dequeue();

                if (BossLevelCodes.IsBossLevel((byte)(currentCode >> 8)))
                {
                    // Mark stage as 'been here'
                    checklist[currentCode] = true;
                    queue.Enqueue(0x300);
                    continue;
                }

                // Have we been here?
                if (!checklist[currentCode])
                {
                    // Mark stage as 'been here'
                    checklist[currentCode] = true;

                    // Loop through available exits from this entrance
                    foreach (var exit in sanity[currentCode])
                    {
                        // 0x38dd8e - matrix start
                        // 0x38df9a - array from matrix start
                        // Load entrance at exit's index
                        // Get top 8 bits of and double them, then add to 0x38dd8e
                        var stageAddress = rom.Read16(0x38dd8e + ((exit >> 8) << 1));
                        var entrance = rom.Read16(0x380000 | stageAddress + ((byte)exit << 1));

                        queue.Enqueue(entrance);


                    }

                }
            }

            return checklist;
        }

        // Return a string of our path
        public String GenerateSpoilerString(Int32 end, ROM rom)
        {
            Queue<SpoilerLog> queue = new Queue<SpoilerLog>();
            // Have we been here before?
            bool[] checklist = new bool[49920];

            queue.Enqueue(new SpoilerLog(new List<String>() { nameByCompleteCode[0x0300] }, 0x0300));
            // Find which ones are accessible
            while (queue.Count > 0)
            {
                // Pull (from bottom) next spoiler log into current
                SpoilerLog log = queue.Dequeue();

                List<String> pathString = log.pathTakenString;
                Int32 currentStage = log.current;
                if (currentStage == end)
                {
                    pathString.Add(nameByCompleteCode[currentStage].Split('(')[0]);
                    return String.Join(", ", pathString);
                }

                if (BossLevelCodes.IsBossLevel((byte)(currentStage >> 8)))
                {
                    // Mark stage as 'been here'
                    checklist[currentStage] = true;
                    queue.Enqueue(new SpoilerLog(new List<String>() { nameByCompleteCode[0x0300] }, 0x0300));
                    continue;
                }

                // Have we been here?
                if (!checklist[currentStage])
                {
                    // Mark stage as 'been here'
                    checklist[currentStage] = true;

                    // Loop through available exits from this entrance
                    foreach (var exit in sanity[currentStage])
                    {
                        // Copy entrance from sanity
                        // 0x38dd8e - matrix start
                        // 0x38df9a - array from matrix start
                        // Load entrance at exit's index
                        // Get top 8 bits of and double them, then add to 0x38dd8e
                        var stageAddress = rom.Read16(0x38dd8e + ((exit >> 8) << 1));
                        var entrance = rom.Read16(0x380000 | stageAddress + ((byte)exit << 1));

                        string exitString = nameByCompleteCode[exit].Contains("(") ? nameByCompleteCode[exit] : nameByCompleteCode[exit] + " (Level Exit)";

                        // Add exit to path taken
                        pathString.Add(exitString);
                        // Stack on queue
                        queue.Enqueue(new SpoilerLog(pathString, entrance));
                        // Remove potential destination after we create a new SpoilerLog
                        pathString.Remove(nameByCompleteCode[exit]);

                    }

                }
            }

            return "Not found.";
        }

        public void WriteOriginalSong (ROM rom)
        {
            rom.rom[musicLUTStart + levelCode] = songCode;
        }

        public void RandomizeSong(ROM rom)
        {
            // If we are not in a boss
            if (!BossLevelCodes.IsBossLevel(levelCode))
            {
                // Select index first
                int randomIndex = Defaults.rng.Next(0, songList.Count);
                rom.rom[musicLUTStart + levelCode] = songList[randomIndex];
                // Remove used
                songList.RemoveAt(randomIndex);

            }

        }


    }
}
