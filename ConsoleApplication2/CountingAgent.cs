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
        private int ID
        public CountingAgent()
        {
            id++; 
            ID = id;
            HasFinished = false;
        }
        public override void Update()
        {
            for (int i = 0; i < id / 3 + 1; i++)
            {
                Console.WriteLine("Wykonuje wątek " + i);
                Thread.Sleep(100);
            }
            Console.WriteLine("CountingAgent ID: " + id / 3);
        }

    }
}
