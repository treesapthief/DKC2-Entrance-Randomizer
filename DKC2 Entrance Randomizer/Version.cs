using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DKC2_Entrance_Randomizer
{
    static class Version
    {
        //private static string versionString = "Version 0.106";
        private static string versionString = "Version 1.000";
        public static string downloadLink;
        public static bool currentVersion;

        private static void IsUpdateAvailable()
        {
            try
            {
                    //throw new System.ArgumentException();

                // Get current version from my pastebin
                System.Net.WebClient wc = new System.Net.WebClient();
                byte[] raw = wc.DownloadData("https://pastebin.com/w03LrHcH");

                // Parse the string
                String webData = System.Text.Encoding.UTF8.GetString(raw);
                    // Split data at my chosen point
                var websiteArr = Regex.Split(webData, "\\>__\\.\\.//\\r\\n");
                string websiteStr = websiteArr[1];
                websiteStr = Regex.Split(websiteStr, "\\<")[0];

                    // Update log consists of version[0] and link[1]
                    string[] log = Regex.Split(websiteStr, "\\r\\n");
                    downloadLink = log[1];

                    currentVersion = !(versionString == log[0]);
            }
                
            catch (Exception ex)
            {
                    MessageBox.Show("Trouble connecting to the internet. You may be running outdated software!", "DKC2 Entrance Randomizer");
                    currentVersion = false;
            }

            
        }

        public static void ManualCheck()
        {
            IsUpdateAvailable();

            if (currentVersion)
            {
                WillUserUpdate();
            }
            else
            {
                MessageBox.Show("You are running the current version!", "DKC2 Entrance Randomizer");
            }


        }

        public static void OnLoad()
        {

            //IsUpdateAvailable();
            //if (currentVersion)
           // {
           //     WillUserUpdate();
           // }

        }

        public static void WillUserUpdate()
        {
            // Does the user want to update now?
            if (MessageBox.Show("Your version is outdated. Update now?","DKC2 Entrance Randomizer", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                //MessageBox.Show("Please contact RainbowSprinklez on discord (Rainbow #2405) for any updates");
                System.Diagnostics.Process.Start(downloadLink);
                Application.Exit();
            }
            else
            {
                MessageBox.Show("Not recommended", "DKC2 Entrance Randomizer");
            }
        }


        public static string GetVersion() => versionString;

    }
}
