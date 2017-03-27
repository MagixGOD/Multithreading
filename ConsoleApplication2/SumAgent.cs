using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class SumAgent : Agent
    {
        protected int Sum;
        private int zakres;
        private static int ID;
        public SumAgent(int range)
        {
            id++;
            ID = id;
            zakres = range;
        }
        public override void Update()
        {
            while (!HasFinished)
            {

            }
        }
    }
}
