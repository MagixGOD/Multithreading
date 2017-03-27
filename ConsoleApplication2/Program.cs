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
        private static int AgentCount = 30;
        private static Random random = new Random();

        private static List<IRunnable> Agents = new List<IRunnable>();
        private static List<int> RandomList = new List<int>();
        static void GenerateRunnables()
        {
            for (int a = 0; a < 4; a++)
            {
                Agents.Add(new SumAgent(a));
            }

            for (int a = 0; a < 1000; a++)
            {
                RandomList.Add(random.Next(0, 1000));
            }

            /*  for (int a = 0; a < AgentCount; a += 3)
                        {
                            Agents.Add(new ConstantCountingAgent(a));
                            Agents.Add(new CountingAgent(a + 1));
                            Agents.Add(new SineGeneratingAgent(a + 2));
                        } */
        }

        static void RunThreads()
        {
            List<Thread> Threads = new List<Thread>();

            foreach (Agent Agent in Agents)
            {
                Threads.Add(new Thread(Agent.Run));
                Console.WriteLine();
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
