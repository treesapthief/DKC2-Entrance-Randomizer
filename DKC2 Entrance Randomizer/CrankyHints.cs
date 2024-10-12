using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using DKC2_Entrance_Randomizer;

namespace DKC2_Entrance_Randomizer
{
    public partial class CrankyHints
    {
        public List<string> unusedLevels = new List<string>();
        public List<string> hints = new List<string>();
        // Generate spoiler logs
        public List<string> spoilerLogKrow1;
        public List<string> spoilerLogKleever;
        public List<string> spoilerLogKudgel;
        public List<string> spoilerLogBee;
        public List<string> spoilerLogKrow2;
        public List<string> spoilerLogKkr;
        public List<string> masterSpoilerLog = new List<string>();

        public int bossesInBonus = 0;
        public int bossesInWarp = 0;
        public int bossesInRoom = 0;
        public int bossesInExit = 0;

        public int bossesInWorld1 = 0;
        public int bossesInWorld2 = 0;
        public int bossesInWorld3 = 0;
        public int bossesInWorld4 = 0;
        public int bossesInWorld5 = 0;
        public int bossesInWorld6 = 0;
        public int bossesInWorld7 = 0;
        public int bossesInWorld8 = 0;


        public int[] hintSlot = new int[] { 0x372000, 0x372100, 0x372200, 0x372300, 0x372400, 0x372500 };
        public int[] hintPointers = new int[] { 0x34c769, 0x34c76b, 0x34c76d, 0x34c76f, 0x34c771, 0x34c773 };
        public List<Entrance> entrances;

        public ROM rom;

        public CrankyHints (ROM rom, List<Entrance> entrances)
        {
            this.rom = rom;
            // Format/display blank hints
            for (int i = 0; i < hintSlot.Length; i++)
            {
                FormatHintSlots(hintSlot[i], hintPointers[i], rom);
            }
            // Copy entrances here for use of spoiler log
            this.entrances = entrances;

            // Get all those logs
            GetSpoilerLog(rom, entrances[0]);

            // Count types
            FullCount();

            // Fill a master list we can use for hints
            FillMasterSpoilerLog(spoilerLogKrow1);
            FillMasterSpoilerLog(spoilerLogKleever);
            FillMasterSpoilerLog(spoilerLogKudgel);
            FillMasterSpoilerLog(spoilerLogBee);
            FillMasterSpoilerLog(spoilerLogKrow2);
            FillMasterSpoilerLog(spoilerLogKkr);

            hints.Add(SelectFreeHint());
            hints.Add(SelectFreeHint());

            // Reroll until not the same
            while (hints[0] == hints[1])
            {
                hints = new List<string>();
                hints.Add(SelectFreeHint());
                hints.Add(SelectFreeHint());
            }

            CountAllWorlds();

            // Setup the 2-cost hints
            GetUnusedLevels();
            Fill2Cost();
            FillNegativeCost2();

            while (hints.Count < 5)
            {
                // Generate random number
                int rand = Defaults.rng.Next(0, 1000);
                // String to potentially add
                String proposed = "";

                // Assigned proposed based on random number
                if (rand > 300)
                    proposed = SelectCost2Hint();
                else
                {
                    proposed = NegativeHints[Defaults.rng.Next(0, NegativeHints.Count)];
                }
                if (proposed == "")
                    continue;
                // Does our list not have proposed yet?
                if (!hints.Contains(proposed))
                    hints.Add(proposed);
            }




            // Select a 30 hint
            hints.Add(SelectCost30Hint());

            for (int i = 0; i < hints.Count; i++)
            {
                var choice = new CrankyHintChoice(rom, hints[i], hintSlot[i]);
                choice.ApplyHint();
            }

            // TEST


        }

        public void FormatHintSlots(int address, int pointer, ROM rom)
        {
            // Setup pointer
            rom.Write16(pointer, address & 0xffff);

            // Write blanks * 6. 6 lines allowed
            rom.rom[address++] = 0x00;
            rom.rom[address++] = 0x00;
            rom.rom[address++] = 0x00;
            rom.rom[address++] = 0x00;
            rom.rom[address++] = 0x00;
            rom.rom[address++] = 0x00;

        }

        public List<string> GetHints()
        {

            return new List<string>();
        }
        private void GetSpoilerLog (ROM rom, Entrance entrance)
        {
            spoilerLogKrow1 = new List<string> (entrance.GenerateSpoilerString(0x0900, rom).Split(','));
            spoilerLogKleever = new List<string>(entrance.GenerateSpoilerString(0x2100, rom).Split(','));
            spoilerLogKudgel = new List<string>(entrance.GenerateSpoilerString(0x6300, rom).Split(','));
            spoilerLogBee = new List<string>(entrance.GenerateSpoilerString(0x6000, rom).Split(','));
            spoilerLogKrow2 = new List<string>(entrance.GenerateSpoilerString(0x0d00, rom).Split(','));
            spoilerLogKkr = new List<string>(entrance.GenerateSpoilerString(0x6100, rom).Split(','));
        }

        public string DetermineType(int goal)
        {
            Entrance thisEntrance = FindEntrance(goal);

            switch (thisEntrance.LevelType)
            {
                case "Bonus":
                    return "bonus";
                case "Warp":
                    return "warp";
                case "Room":
                    return "room";
                case "Exit":
                    return "exit";

                default:
                    break;
            }


            return "";
        }
        public void CountType(int goal)
        {
            // 0x38dd8e - matrix start
            // 0x38df9a - array from matrix start

            Entrance thisEntrance = FindEntrance(goal);

            switch (thisEntrance.LevelType)
            {
                case "Bonus":
                    bossesInBonus++;
                    return;
                case "Warp":
                    bossesInWarp++;
                    return;
                case "Room":
                    bossesInRoom++;
                    return;
                case "Exit":
                    bossesInExit++;
                    return;

                default:
                    break;
            }


            return;
        }
        private void FullCount ()
        {
            CountType(0x0900);
            CountType(0x2100);
            CountType(0x6300);
            CountType(0x6000);
            CountType(0x0d00);
            CountType(0x6100);

        }

        public Entrance FindEntrance (int id)
        {
            // Loop until we find a match
            foreach (var entrance in entrances)
            {
                // Did we find?
                if (entrance.currentStage == id)
                {
                    return entrance;
                }
            }
            // We should never get here
            return entrances[0];
        }
        private void FillMasterSpoilerLog (List<string> spoilerLog)
        {
            // Copy all to new list to be safe
            var newList = new List<string>();
            if (spoilerLog.Count > 1)
            {
                newList.AddRange(spoilerLog);
                // Remove the final and first index of log, then add
                newList.RemoveAt(0);
                newList.RemoveAt(0);
                newList.RemoveAt(newList.Count - 1);

                // Add to master
                masterSpoilerLog.AddRange(newList);

            }

        }
        private void CountAllWorlds ()
        {
            bossInWorld(0x0900);
            bossInWorld(0x2100);
            bossInWorld(0x6300);
            bossInWorld(0x6000);
            bossInWorld(0x0d00);
            bossInWorld(0x6100);
        }

        private void bossInWorld (int goal)
        {
            // Which entrance do we want?
            var bossEntrance = FindEntrance(goal);

            string baseStage = Entrance.nameByCompleteCode[bossEntrance.completeCode];
            baseStage = baseStage.Split('(')[0].Trim();
            //return;

            string worldOfBoss = Defaults.entranceByWorld[baseStage];

            switch (worldOfBoss)
            {
                case "World 1":
                    bossesInWorld1++;
                    break;
                case "World 2":
                    bossesInWorld2++;
                    break;
                case "World 3":
                    bossesInWorld3++;
                    break;
                case "World 4":
                    bossesInWorld4++;
                    break;
                case "World 5":
                    bossesInWorld5++;
                    break;
                case "World 6":
                    bossesInWorld6++;
                    break;
                case "World 7":
                    bossesInWorld7++;
                    break;

                default:
                    bossesInWorld8++;
                    break;

            }
        }

        public void GetUnusedLevels ()
        {
            var tempList = new List<string>();
            // Add all first
            foreach (var entrance in entrances)
            {
                // Is this a base level?
                if (!entrance.name.Contains("("))
                {
                    tempList.Add(entrance.name.Trim());
                }
            }

            int x = 1;
            foreach (var entranceDest in tempList)
            {
                // Is stage present in master spoiler log?
                bool present = false;
                foreach (var entranceSrc in masterSpoilerLog)
                {
                    if (entranceDest == entranceSrc.Split('(')[0].Trim())
                    {
                        present = !present;
                    }
                }
                if (!present)
                {
                    unusedLevels.Add(entranceDest);
                }
            }
            unusedLevels.Remove(Entrance.nameByCompleteCode[0x0300].Trim());
            unusedLevels.Remove(Entrance.nameByCompleteCode[0x0900].Trim());
            unusedLevels.Remove(Entrance.nameByCompleteCode[0x2100].Trim());
            unusedLevels.Remove(Entrance.nameByCompleteCode[0x6300].Trim());
            unusedLevels.Remove(Entrance.nameByCompleteCode[0x6000].Trim());
            unusedLevels.Remove(Entrance.nameByCompleteCode[0x0d00].Trim());
            unusedLevels.Remove(Entrance.nameByCompleteCode[0x6100].Trim());

            x = 2;
        }
    }
}
