using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKC2_Entrance_Randomizer
{
    public class Save
    {
        public int seed;
        public List<string> spoilerLog;
        public List<string> logic;
        public string fileAddition;

        public Save (int seed, List<string> spoilerLog, List<string> logic, string fileAddition)
        {
            this.seed = seed;
            this.spoilerLog = spoilerLog;
            this.logic = logic;
            this.fileAddition = fileAddition;
        }

    }
}
