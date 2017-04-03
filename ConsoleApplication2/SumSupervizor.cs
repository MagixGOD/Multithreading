using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class SumSupervizor : Agent
    {
        private double Sum = 0;
        private static int ID;
        Program program = new Program();
        private static List<IRunnable> SumAgents = new List<IRunnable>();

        public void GetAgentList()
        {
            SumAgents = program.GetAgentList();
        }
        public SumSupervizor()
        {
            id++;
            ID = id;
            GetAgentList();
        }
        public override void Update()
        {
            while (SumAgents.All(a => a.HasFinished))
            {
                foreach (SumAgent SumAgent in SumAgents)
                {
                    Sum += SumAgent.Sum;
                }
                Console.WriteLine("Sum of all:" + Sum);
            }
        }
    }
}
