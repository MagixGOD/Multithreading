using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApplication2
{
    class CountingAgent : Agent
    {
        private int ID;
        private int count = 0;
        public CountingAgent()
        {
            id++;
            ID = id;
            HasFinished = false;
        }
        public override void Update()
        {
            if (count == ID)
            {
                Console.WriteLine("CountingAgent ID: " + ID);
                HasFinished = true;
            }
            else count++;
        }

    }
}
