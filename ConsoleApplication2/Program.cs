using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApplication2
{
    class Program
    {
        public static int AgentCount = 4;
        private static Random random = new Random();
        private static List<IEnumerator<float>> Lista = new List<IEnumerator<float>>();
        private static List<IRunnable> Agents = new List<IRunnable>();
        private static List<IRunnable> SumSupervizors = new List<IRunnable>();
        private static List<int> RandomList = new List<int>();

        public List<int> GetList()
        {
            return RandomList;
        }
        public List<IRunnable> GetAgentList()
        {
            return Agents;
        }
        static void GenerateRunnables()
        {
            for (int a = 0; a < 1000; a++)
            {
                RandomList.Add(random.Next(0, 1000));
            }

            for (int a = 1; a <= AgentCount; a++)
            {
                Agents.Add(new SumAgent(((1000 / AgentCount) * a) - 1));
            }
            SumSupervizors.Add(new SumSupervizor());

            /*   for (int a = 0; a < AgentCount/3; a++)
                          {
                              Agents.Add(new ConstantCountingAgent());
                              Agents.Add(new CountingAgent());
                              Agents.Add(new SineGeneratingAgent());
                          } */
        }

        static void RunThreads()
        {
            List<Thread> Threads = new List<Thread>();

            foreach (Agent Agent in Agents)
            {
                Threads.Add(new Thread(Agent.Run));
                Console.WriteLine("SumAgent added.");
            }
            foreach (SumSupervizor Sumsupervizor in SumSupervizors)
            {
                Threads.Add(new Thread(Sumsupervizor.Run));
                Console.WriteLine("SumSupervizor added.");
            }
            foreach (Thread Thread in Threads)
            {
                Thread.Start();
            }
        }
        static void RunFibers()
        {
            foreach (Agent Agent in Agents)
            {
                Lista.Add(Agent.CoroutineUpdate());
            }
            while (!Agents.All(a => a.HasFinished))
            {
                foreach (IEnumerator<float> Enumerator in Lista)
                {
                    Enumerator.MoveNext();
                }
                Thread.Sleep(100);
            }
        }
        static void Main(string[] args)
        {
            Program.GenerateRunnables();
            Program.RunThreads();
            // Program.RunFibers();

            Console.ReadKey();
        }
    }
}
