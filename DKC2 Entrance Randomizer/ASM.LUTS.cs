using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKC2_Entrance_Randomizer
{
    static partial class ASM
    {
        public static string levelCode = "";
        private static List<string> levelCodesRaw = new List<string>
        {
            "00=Web Woods (Unused)",
            "01=Glimmer's Galleon",
            "02=Rambi Rumble",
            "03=Pirate Panic",
            "04=Gangplank Galley",
            "05=Rattle Battle",
            "06=Glimmer's Galleon - Exit Room",
            "07=Hot-Head Hop",
            "08=Red-Hot Ride",
            "09=Krow's Nest",
            "0A=Slime Climb",
            "0B=Topsail Trouble",
            "0C=Mainbrace Mayhem",
            "0D=Kreepy Krow",
            "0E=Target Terror",
            "0F=Rickety Race",
            "10=Haunted Hall",
            "11=Hornet Hole",
            "12=Rambi Rumble - Rambi Room",
            "13=Parrot Chute Panic",
            "14=Lava Lagoon",
            "15=Lockjaw's Locker",
            "16=Fiery Furnace",
            "17=Web Woods",
            "18=Gusty Glade",
            "19=Ghostly Grove",
            "1A=Topsail Trouble - Warp Room",
            "1B=Pirate Panic - K.Rool's Cabin",
            "1C=Hot-Head Hop - Bonus 2",
            "1D=Pirate Panic - Warp Room",
            "1E=Target Terror - Exit Room",
            "1F=Web Woods Room (Unused)",
            "20=Mainbrace Mayhem - Warp Room",
            "21=Kleever's Kiln",
            "22=Rattle Battle - Rattly Room",
            "23=Windy Well",
            "24=Sqwawks Shaft",
            "25=Kannon's Klaim",
            "26=Parrot Chute Panic - Warp Room",
            "27=Kannon's Klaim - Warp Room",
            "28=Barrel Bayou",
            "29=Krochead Klamber",
            "2A=Web Woods - Squitter Room",
            "2B=Barrel Bayou - Warp Room",
            "2C=Mudhole Marsh",
            "2D=Bramble Blast",
            "2E=Bramble Scramble",
            "2F=Screech's Sprint",
            "60=King Zing Sting",
            "61=K.Rool Duel",
            "62=Castle Crush",
            "63=Kudgel's Kontest",
            "68=Lockjaw's Locker - Warp Room",
            "69=Lava Lagoon - Warp Room",
            "6A=Squawk's Shaft - Warp Room",
            "6B=Krocodile Kore",
            "6C=Arctic Abyss",
            "6D=Chain Link Chamber",
            "6E=Toxic Tower",
            "6F=Pirate Panic - Bonus 1",
            "70=Pirate Panic - Bonus 2",
            "71=Gangplank Galley - Bonus 2",
            "72=Rattle Battle - Bonus 1",
            "73=Rattle Battle - Bonus 3",
            "74=Hot-Head Hop - Bonus 3",
            "75=Hot-Head Hop - Bonus 1",
            "76=Red-Hot Ride - Bonus 1",
            "77=Red-Hot Ride - Bonus 2",
            "78=Mainbrace Mayhem - Bonus 1",
            "79=Mainbrace Mayhem - Bonus 2",
            "7A=Slime Climb - Bonus 1",
            "7B=Topsail Trouble - Bonus 1",
            "7C=Topsail Trouble - Bonus 2",
            "7D=Mainbrace Mayhem - Bonus 3",
            "7E=Slime Climb - Bonus 2",
            "7F=Rattle Battle - Bonus 2",
            "80=Klobber Karnage",
            "81=Lockjaw's Locker - Bonus 1",
            "82=Glimmer's Galleon - Bonus 2",
            "83=Lava Lagoon - Bonus 1",
            "84=Glimmer Galleon - Bonus 1",
            "85=Ghostly Grove - Bonus 1",
            "86=Gusty Glade - Bonus 1",
            "87=Gusty Glade - Bonus 2",
            "88=Ghostly Grove Bonus 2",
            "89=Barrel Bayou - Bonus 1",
            "8A=Barrel Bayou - Bonus 2",
            "8B=Krochead Klamber - Bonus 1",
            "8C=Mudhole Marsh - Bonus 1",
            "8D=Mudhole Marsh - Bonus 2",
            "8E=Hot-Head Hop - Warp Room",
            "8F=Clapper's Cavern",
            "90=Animal Antics - Enguarde Section",
            "91=Clapper's Cavern - Bonus 1",
            "92=Clapper's Cavern - Bonus 2",
            "93=Arctic Abyss - Bonus 1",
            "94=Black Ice Battle - Bonus 1",
            "95=Arctic Abyss - Bonus 2",
            "96=Black Ice Battle",
            "97=Klobber Karnage - Bonus 1",
            "98=Jungle Jinx - Bonus 1",
            "99=Jungle Jinx",
            "9A=Animal Antics - Rambi Section",
            "9B=Animal Antics - Squitter Section",
            "9C=Animal Antics - Rattly Section",
            "9D=Animal Antics - Bonus 1",
            "9E=Fiery Furnace - Bonus 1",
            "9F=Animal Antics - Squawks Section",
            "A0=Bramble Blast - Bonus 2",
            "A1=Target Terror - Bonus 1",
            "A2=Bramble Scramble - Bonus 1",
            "A3=Windy Well - Bonus 2",
            "A4=Web Woods - Bonus 1",
            "A5=Toxic Tower - Bonus 1",
            "A6=Bramble Blast - Bonus 1",
            "A7=Screech's Sprint - Bonus 1",
            "A8=Gangplank Galley - Bonus 1",
            "A9=Squawk's Shaft - Bonus 3",
            "AA=Kannon's Klaim - Bonus 3",
            "AB=Kannon's Klaim - Bonus 1",
            "AC=Squawk's Shaft - Bonus 1",
            "AD=Kannon's Klaim - Bonus 2",
            "AE=Hornet Hole - Bonus 1",
            "AF=Parrot Chute Panic - Bonus 2",
            "B0=Hornet Hole - Bonus 3",
            "B1=Parrot Chute Panic - Bonus 1",
            "B2=Rambi Rumble - Bonus 2",
            "B3=Hornet Hole - Bonus 2",
            "B4=Rambi rumble - Bonus 1",
            "B5=Chain Link Chamber - Bonus 1",
            "B6=Chain Link Chamber - Bonus 2",
            "B7=Castle Crush - Bonus 1",
            "B8=Castle Crush - Bonus 2",
            "B9=Stronghold Showdown",
            "BA=Squawk's Shaft - Bonus 2",
            "BC=Web Woods - Bonus 2",
            "BB=Windy Well - Bonus 1",
            "BD=Haunted Hall - Bonus 1",
            "BE=Rickety Race - Exit",
            "BF=Haunted Hall - Exit",
            "C0=Haunted Hall Bonus 3",
            "C1=Target Terror - Bonus 2",
            "C2=Haunted Hall - Bonus 2",
            "C3=Rickety Race - Bonus 1"
        };
        private static List<string> organized = new List<string>();
        
        private static void RawLUT ()
        {
            for (int i = 0; i < 0x100; i++)
            {

            }
        }


        public static void Init()
        {
            RawLUT();
        }


        public static void LevelCodeD3()
        {
            // Loop through 255 AND our dict
            for (int i = 0, j = 0; i < 256; i++)
            {

            }

        }
    }
}
