using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApplication2
{
    abstract class Agent : IRunnable
    {
        public IEnumerator<float> a;
        public static int id;
        public abstract void Update();

        public bool HasFinished { get; protected set; }

        public IEnumerator<float> CoroutineUpdate()
        {
            Update();
            if (!HasFinished) yield return 0;
            else yield break;
        }

        public void Run()
        {
            while (!HasFinished)
            {
                Update();
                Thread.Sleep(100);
            }
        }
    }
}
