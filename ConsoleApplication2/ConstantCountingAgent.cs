using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class ConstantCountingAgent : Agent
    {
        private int ID;
        private int count = 0;

        public ConstantCountingAgent()
        {
            id++;
            ID = id;
            HasFinished = false;
        }
        public override void Update()
        {
            if (count == 10)
            {
                Console.WriteLine("ConstantCountingAgent ID: {0}", ID);
                HasFinished = true;
            }
            else count++;
        }
    }
}

