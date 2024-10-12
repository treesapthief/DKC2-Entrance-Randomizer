using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKC2_Entrance_Randomizer
{
    class SpoilerLog
    {

        public List<String> pathTakenString = new List<String>();
        public Int32 current;

        public SpoilerLog(List<String> pathTakenString, Int32 current)
        {
            this.pathTakenString.AddRange(pathTakenString);
            this.current = current;
        }
    }
}
