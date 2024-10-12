using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DKC2_Entrance_Randomizer
{
    public class ROM
    {
        public List<byte> rom = new List<byte>();
        public byte[] backupRom = new byte[0x400000];
        private string fileName;
        public static bool loadROMSuccess = false;

        // 0x38dd8e - matrix start
        // 0x38df9a - array from matrix start

        public void Load () 
        {
            //0x0x163e1202
            OpenFileDialog d = new OpenFileDialog();
            d.Filter = "ROM file (*.smc;*.sfc)|*.smc;*.sfc";
            d.Title = "Select a proper DKC2 ROM";

            while (d.ShowDialog() == DialogResult.OK)
            {
                //Loading my file and displaying all my content.
                byte[] temp = File.ReadAllBytes(d.FileName);
                // Start reading after the header
                Int32 startingPoint = temp.Length == 0x400000 + 0x200 ? 0x200 : 0;
                Array.Copy(temp, startingPoint, backupRom, 0, 0x400000);

                // Verify checksum
                if (GetChecksum(backupRom) == 0x163e1202.ToString("x"))
                {
                    fileName = d.FileName;
                    // Core hack patch
                    ASM.ApplyPatch(ASM.ASMaddresses, ASM.ASMvalues, backupRom);


                    // Copy backup to main
                    RestoreFromBackup();
                    loadROMSuccess = true;
                    break;
                }
                else
                {
                    MessageBox.Show("Invalid file");
                    continue;
                }
            }
        }
        public UInt16 Read16(Int32 address)
        {
            address &= 0x3fffff;
            return (UInt16)(
                (rom[address++] << 0) |
                (rom[address++] << 8));
        }
        public void Write16(Int32 address, Int32 value)
        {
            address &= 0x3fffff;
            rom[address++] = (byte)(value >> 0);
            rom[address++] = (byte)(value >> 8);
        }
        public void WriteString(Int32 address, string str)
        {
            address &= 0x3fffff;
            foreach (var letter in str)
            {
                rom[address++] = (byte)(letter);
            }
        }
        public void RestoreFromBackup()
        {
            // Make sure rom is clear
            rom = new List<byte>();
            // Copy Over
            rom.AddRange(backupRom);
        }

        // For ROM validation
        private string GetChecksum(byte[] tempArr)
        {
            Int32 checksum = 0;
            foreach (var @byte in tempArr)
                checksum += @byte;
            return checksum.ToString("x");
        }

        // Save file
        public void SaveRandoROM (Save save, bool race)
        {
            int index = fileName.LastIndexOf("\\");

            // Create new directories here
            System.IO.Directory.CreateDirectory(fileName.Substring(0, index) + "\\ROMs");
            System.IO.Directory.CreateDirectory(fileName.Substring(0, index) + "\\Spoiler Logs");
            System.IO.Directory.CreateDirectory(fileName.Substring(0, index) + "\\Logic");


            System.IO.File.WriteAllBytes(fileName.Substring(0, index) + "\\ROMs\\DKC2 Entrance Randomizer " + Version.GetVersion() + " " + DateTime.Now.ToString("M_d_yyyy") + "_ Seed " + save.seed +".smc", rom.ToArray()); //Include date and random number
            if (!race)
                System.IO.File.WriteAllLines(fileName.Substring(0, index) + "\\Spoiler Logs\\DKC2 Spoiler log_"  + save.fileAddition + ".txt", save.spoilerLog); //Include date and random number
            System.IO.File.WriteAllLines(fileName.Substring(0, index) + "\\Logic\\DKC2 Logic_" + save.fileAddition +".txt", save.logic); //Include date and random number

        }

    }
}
