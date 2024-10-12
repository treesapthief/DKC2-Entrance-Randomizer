using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKC2_Entrance_Randomizer
{
    class ColorsHair
    {
        private ROM rom;

        public Dictionary<int, ColorChoiceHair> chooseColor;
        public ColorsHair(ROM rom, byte[] custom)
        {
            // Yellow, red, white, purple, green, random
            this.chooseColor = new Dictionary<int, ColorChoiceHair>
            {
                [0] = new ColorChoiceHair(true, rom),
                [1] = new ColorChoiceHair(redValues, rom),
                [2] = new ColorChoiceHair(whiteValues, rom),
                [3] = new ColorChoiceHair(purpleValues, rom),
                [4] = new ColorChoiceHair(greenValues, rom),
                [5] = new ColorChoiceHair(orangeValues, rom),
                [6] = new ColorChoiceHair(blackValues, rom),
                [7] = new ColorChoiceHair(custom, rom),

            };
        }

        // Normal
        public byte[] defaultDiddy = new byte[] { };
        public byte[] defaultDixie = new byte[] { };

        private byte[] redValues = new byte[] { 0x1a, 0x0, 0x09 };
        private byte[] whiteValues = new byte[] { 0x1d, 0x1d, 0x1d };
        //private byte[] tealValues = new byte[] { 0xA4, 0x5B, 0x39, 0x67, 0xBD, 0x77, 0xF7, 0x5E, 0x7B, 0x6F, 0x7B, 0x6F, 0x7F };
        private byte[] purpleValues = new byte[] { 0x18, 0x0, 0x18 };
        private byte[] greenValues = new byte[] { 0x0, 0x16, 0x0 };
        private byte[] orangeValues = new byte[] { 0x1c, 0x10, 0x0 };
        private byte[] blackValues = new byte[] { 0xa, 0xa, 0xa };

    }
}
