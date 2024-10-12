using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DKC2_Entrance_Randomizer;
using System.Threading.Tasks;

namespace DKC2_Entrance_Randomizer
{
    public partial class CrankyHints
    {
        // Ok names
        public string[] names = new string[] { "Pichi", "Lumophile", "DustPan", "SnakPak", "Zera", "Tompa", "V0oid", "Fathlo", "DLB", "P4plus2", "Sch1ey", "Jermro", "Silent Wolf" };

        
        // Templates
        // 30%
        public string GetFreeHint1(string name, string stage) => $"I once heard from {name} that{stage.Split('(')[0]}was important.";
        // 30%
        public string GetFreeHint2(string stage) => $"If you see{stage.Split('(')[0]}you are in good shape.";
        // 15%
        public string GetFreeHint3() => "Having trouble finding something? Consider checking the spoiler log.";
        // 10%
        public string GetFreeHint4() => "It is dangerous to go alone. You should grab your buddy.";
        // 5%
        public string GetFreeHint5() => "Rumor is, if you re-enter Poison Pond, you will get WR.";
        // 3%
        public string GetFreeHint6() => "Master Necky Senior is after Platform Perils.";
        // 3%
        public string GetFreeHint7() => "If you see Jungle Hijinx, you are playing the wrong game.";
        // 3%
        public string GetFreeHint8() => "Never do front ropes.";
        // 1%
        public string GetFreeHint9() => "Eh? Where's Donkey? I have no hints for you. Oh? Still here? Fine. Don't die.";

        // Free hint
        public string SelectFreeHint ()
        {
            // Select random number
            var num = Defaults.rng.Next(1, 101);
            
            // Rng based
            if (num < 30)
            {
                return GetFreeHint1(names[Defaults.rng.Next(0, names.Length)], masterSpoilerLog[Defaults.rng.Next(0,masterSpoilerLog.Count)]);
            }
            else if (num < 60)
            {
                return GetFreeHint2(masterSpoilerLog[Defaults.rng.Next(0, masterSpoilerLog.Count)]);
            }
            else if (num < 75)
            {
                return GetFreeHint3();
            }
            else if (num < 85)
            {
                return GetFreeHint4();
            }
            else if (num < 90)
            {
                return GetFreeHint5();
            }
            else if (num < 93)
            {
                return GetFreeHint6();
            }
            else if (num < 96)
            {
                return GetFreeHint7();
            }
            else if (num < 99)
            {
                return GetFreeHint8();
            }
            else
            {
                return GetFreeHint9();
            }


            return "";

        }
        List<string> GetHintCost2 = new List<string>();

        private string[] string_template = new string[]
        {
                $"'I've got a lovely bunch of coconuts, deedledeedee!' OH! There's",
                $"I got some secret intel for ya. It seems there's",
                $"It seems that there's",
                $"Didja hear? It seems there's",
                $"I once heard that there's",
                $"It is said that there's",


        };

        public string DustpanHint(List<string> spoilerLog)
        {
            if (spoilerLog.Count > 3)
            {
                string hint = $"{string_template[Defaults.rng.Next(0, string_template.Length - 1)]} at least 1 boss 2 exits away from {spoilerLog[spoilerLog.Count - 3].Split('(')[0].Trim()}.";
                return hint;
            }
            return "";
        }
        //6924
        /*public void WayOfTheHero (byte stageCode)
        {
            //$" {Entrance.nameByCompleteCode[FindEntrance(0x9).currentStage].Trim()} is on the way of the hero."
            var entrance = FindEntrance(stageCode);
            var if ()
        }*/

        public void Fill2Cost()
        {
            GetHintCost2.AddRange(new string[] 
            {
                $"You think just because you paid money you deserve a clue?! Ok. There's {bossesInBonus} {(bossesInBonus == 1 ? "boss" : "bosses")} in bonuses.",
                $"Legend says that there's {bossesInWarp} {(bossesInWarp == 1 ? "boss" : "bosses")} in Warps.",
                $"Someone once said that there {(bossesInExit == 1 ? "is" : "are")} {bossesInExit} {(bossesInExit == 1 ? "boss" : "bosses")} at the end of levels.",
                $"{string_template[Defaults.rng.Next(0, string_template.Length)]} {bossesInWorld1} {(bossesInWorld1 == 1 ? "boss" : "bosses")} in World 1.",
                $"There's {bossesInWorld2} {(bossesInWorld2 == 1 ? "boss" : "bosses")} in World 2. Ok. Gotta blast!",
                $"There's {bossesInWorld3} {(bossesInWorld3 == 1 ? "boss" : "bosses")} in World 3. Ok. Gotta blast!",
                $"There's {bossesInWorld4} {(bossesInWorld4 == 1 ? "boss" : "bosses")} in World 4. Ok. Gotta blast!",
                $"{string_template[Defaults.rng.Next(0, string_template.Length)]} {bossesInWorld3} {(bossesInWorld3 == 1 ? "boss" : "bosses")} in World 3.",
                $"{string_template[Defaults.rng.Next(0, string_template.Length)]} {bossesInWorld4} {(bossesInWorld4 == 1 ? "boss" : "bosses")} in World 4.",
                $"{string_template[Defaults.rng.Next(0, string_template.Length)]} {bossesInWorld5} {(bossesInWorld5 == 1 ? "boss" : "bosses")} in World 5.",
                $"{string_template[Defaults.rng.Next(0, string_template.Length)]} {bossesInWorld6} {(bossesInWorld6 == 1 ? "boss" : "bosses")} in World 6.",
                $"{string_template[Defaults.rng.Next(0, string_template.Length)]} {bossesInWorld8} {(bossesInWorld8 == 1 ? "boss" : "bosses")} in The Lost Levels.",
                $"{string_template[Defaults.rng.Next(0, string_template.Length)]} {bossesInWorld2} {(bossesInWorld2 == 1 ? "boss" : "bosses")} in World 2.",

                // Way of the hero
                $"{FindEntrance(0x900).name.Split('(')[0].Trim()} is on the way of the hero.",
                $"{FindEntrance(0x2100).name.Split('(')[0].Trim()} is on the way of the hero.",
                $"{FindEntrance(0x6000).name.Split('(')[0].Trim()} is on the way of the hero.",
                $"{FindEntrance(0x6300).name.Split('(')[0].Trim()} is on the way of the hero.",
                $"{FindEntrance(0xd00).name.Split('(')[0].Trim()} is on the way of the hero.",

                // Length
                $"It turns out that Krow1 is {spoilerLogKrow1.Count - 2} exits away from 1-1.",
                $"It turns out that Kleever is {spoilerLogKleever.Count - 2} exits away from 1-1.",
                $"Sefuroth told me that Kudgel is {spoilerLogKudgel.Count - 2} exits away from 1-1.",
                $"I once heard that King Zing is {spoilerLogBee.Count - 2} exits away from 1-1.",
                $"I'll have you know that Krow2 is {spoilerLogKrow2.Count - 2} exits away from 1-1.",

            });
            


            //  Add 'at least' hints
            if (bossesInWorld1 >= 1)
            {
                GetHintCost2.Add($"Word around this island is there is at least 1 boss in World 1.");
            }
            if (bossesInWorld2 >= 1)
            {
                GetHintCost2.Add($"Word around this island is there is at least 1 boss in World 2.");
            }
            if (bossesInWorld3 >= 1)
            {
                GetHintCost2.Add($"Word around this island is there is at least 1 boss in World 3.");
            }
            if (bossesInWorld4 >= 1)
            {
                GetHintCost2.Add($"Word around this island is there is at least 1 boss in World 4.");
            }
            if (bossesInWorld5 >= 1)
            {
                GetHintCost2.Add($"Word around this island is there is at least 1 boss in World 5.");
            }
            if (bossesInWorld6 >= 1)
            {
                GetHintCost2.Add($"Word around this island is there is at least 1 boss in World 6.");
            }
            if (bossesInWorld7 >= 1)
            {
                GetHintCost2.Add($"Word around this island is there is at least 1 boss in World 7.");
            }
            if (bossesInWorld8 >= 1)
            {
                GetHintCost2.Add($"Word around this island is there is at least 1 boss in The Lost Levels.");
            }
            if (bossesInWorld1 >= 2)
            {
                GetHintCost2.Add($"I hear there are at least 2 bosses in World 1.");
            }
            if (bossesInWorld2 >= 2)
            {
                GetHintCost2.Add($"I hear there are at least 2 bosses in World 2.");
            }
            if (bossesInWorld3 >= 2)
            {
                GetHintCost2.Add($"I hear there are at least 2 bosses in World 3.");
            }
            if (bossesInWorld4 >= 2)
            {
                GetHintCost2.Add($"I hear there are at least 2 bosses in World 4.");
            }
            if (bossesInWorld5 >= 2)
            {
                GetHintCost2.Add($"I hear there are at least 2 bosses in World 5.");
            }
            if (bossesInWorld6 >= 2)
            {
                GetHintCost2.Add($"I hear there are at least 2 bosses in World 6.");
            }
            if (bossesInWorld8 >= 2)
            {
                GetHintCost2.Add($"I hear there are at least 2 bosses in The Lost Levels.");
            }
            if (bossesInWorld1 >= 6)
            {
                GetHintCost2.Add($"It seems every boss is in World 1.");
            }
            if (bossesInWorld2 >= 6)
            {
                GetHintCost2.Add($"It seems every boss is in World 2.");
            }
            if (bossesInWorld3 >= 6)
            {
                GetHintCost2.Add($"It seems every boss is in World 3.");
            }
            if (bossesInWorld4 >= 6)
            {
                GetHintCost2.Add($"It seems every boss is in World 4.");
            }
            if (bossesInWorld5 >= 6)
            {
                GetHintCost2.Add($"It seems every boss is in World 5.");
            }
            if (bossesInWorld6 >= 6)
            {
                GetHintCost2.Add($"It seems every boss is in World 6.");
            }
            if (bossesInWorld8 >= 6)
            {
                GetHintCost2.Add($"It seems every boss is in The Lost Levels.");
            }

        }

        public string SelectCost2Hint ()
        {
            var number = Defaults.rng.Next(0, GetHintCost2.Count);
            string @return = GetHintCost2[number];


            return @return; 

        }

        public string SelectCost30Hint()
        {
            // 1-100 for percentages
            var number = Defaults.rng.Next(1, 101);
            // Find which stage leads to kkr
            var kkrStage = FindEntrance(0x6100);
            string kkrStagee = kkrStage.name.Split('(')[0].Trim();

            if (number < 33)
            {
                return $"Did you notice? You can see K Rool's pirate ship from {kkrStagee}.";
            }
            else if (number < 66)
            {
                return $"Search in {kkrStagee} for K Rool.";
            }
            else
            {
                return $"{kkrStagee} is on the way of the hero.";
            }

            return "";
        }
        public List<string> NegativeHints = new List<string>();
        public void FillNegativeCost2()
        {
            NegativeHints = new List<string>()
            {
                $"If you see {GetUnusedAndRemove()}, you should turn back.",
                $"{GetUnusedAndRemove()} is bad new bears.",
                $"Seeing {GetUnusedAndRemove()} is a bad omen.",
                $"I don't think {GetUnusedAndRemove()} is a good idea.",
                $"If you're {GetUnusedAndRemove()}, you're dead.",
                $"Exploring {GetUnusedAndRemove()} is a poor life decision.",


            };
            
        }

        private string GetUnusedAndRemove()
        {
            int num = Defaults.rng.Next(0, unusedLevels.Count);
            string toReturn = unusedLevels[num];
            unusedLevels.RemoveAt(num);

            return toReturn;
        }



    }
}
