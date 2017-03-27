using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class SineGeneratingAgent : Agent
    {
        private int ID;
        private int count = 0;
        private double SinValue;

        public SineGeneratingAgent()
        {
            id++;
            ID = id;
            HasFinished = false;
        }
        public override void Update()
        {
            SinValue = Math.Sin(count);
            if (count == ID % 10)
            {
                Console.WriteLine("Sin ID = {1} Out: {0}", SinValue, ID);
                HasFinished = true;
            }
            else
                count++;
        }
    }
}
