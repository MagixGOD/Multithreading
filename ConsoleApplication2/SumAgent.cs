using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class SumAgent : Agent
    {
        public double Sum;
        private int zakres;
        private static int ID;
        Program program = new Program();
        private static List<int> SumList = new List<int>();
        private static List<int> RandomList = new List<int>();

        public void GetList()
        {
            RandomList = program.GetList();
        }
        public SumAgent(int range)
        {
            id++;
            ID = id;
            zakres = range;
            HasFinished = false;
            GetList();
        }
        public override void Update()
        {
            SumList = RandomList.GetRange((zakres - (1000 / Program.AgentCount) + 1), 1000 / Program.AgentCount);
            Sum = SumList.Sum();
            Console.WriteLine("Sum: " + Sum);
            HasFinished = true;
        }
    }
}
