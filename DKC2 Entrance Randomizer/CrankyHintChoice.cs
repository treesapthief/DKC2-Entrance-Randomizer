using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DKC2_Entrance_Randomizer
{
    class CrankyHintChoice
    {
        ROM rom;
        string hint;
        int hintAddress;
        List<string> brokenDown = new List<string>();

        // Formatting:
        // 30 bytes each line
        // 6 lines total
        public CrankyHintChoice(ROM rom, string hint, int hintAddress)
        {
            this.rom = rom;
            this.hint = hint;
            this.hintAddress = hintAddress;

        }

        public void ApplyHint()
        {
            FormatString();
            WriteToROM();
        }
        private void FormatString()
        {
            // Split hint into a list of words for formatting
            var wordList = new List<string>(hint.Split(' '));

            // Create a var to keep track of line length
            int lineMax = 29;

            string line = "";
            // Loop through each word
            while (wordList.Count > 0) 
            {
                if (line.Length + wordList[0].Length + 1 < lineMax)
                {
                    // Add next word to line
                    line += $"{wordList[0]} ";
                    // Remove word
                    wordList.RemoveAt(0);
                }
                else
                {
                    brokenDown.Add(line.Trim());
                    line = "";
                }
            }
            brokenDown.Add(line.Trim());

            for (int i = 0; i < brokenDown.Count; i++)
            {
                var text = brokenDown[i];

                if (i == brokenDown.Count - 1 || true)
                {
                    // Get length
                    var len = text.Length;

                    // Free space
                    var freeSpace = lineMax - len;

                    // Pad our string
                    brokenDown[i] = new string(' ', (freeSpace / 2 | 0) + 1) + text;
                }
                else
                {
                    brokenDown[i] = " " + text;
                }



            }

            // How long is our list?
            // Add emptys at top or bitten to manip.
            switch (brokenDown.Count)
            {
                case 1:
                    brokenDown.Insert(0, "");
                    brokenDown.Insert(0, "");
                    brokenDown.Insert(0, "");
                    brokenDown.Insert(0, "");
                    brokenDown.Add("");
                    break;
                case 2:
                    brokenDown.Insert(0, "");
                    brokenDown.Insert(0, "");
                    brokenDown.Insert(0, "");
                    brokenDown.Add("");
                    break;
                case 3:
                    brokenDown.Insert(0, "");
                    brokenDown.Insert(0, "");
                    brokenDown.Add("");
                    break;
                case 4:
                    brokenDown.Insert(0, "");
                    brokenDown.Add("");
                    break;
                case 5:
                    brokenDown.Add("");
                    break;
                case 6:
                    break;

                default:
                    break;
            }
        }
        public void WriteToROM ()
        {
            foreach (var line in brokenDown)
            {
                foreach (var @char in line)
                {
                    rom.rom[hintAddress++] = (byte)@char;
                }
                rom.rom[hintAddress++] = 0;
            }
        }

    }
}
