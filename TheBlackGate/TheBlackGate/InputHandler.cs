using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBlackGate
{
    public class InputHandler
    {
        public delegate void ExitApplicationEvent();
        public delegate void StartTestEvent();
        public delegate void SetIterationEvent(int i);

        public static event StartTestEvent OnTestStart;
        public static event ExitApplicationEvent OnExit;
        public static event SetIterationEvent OnSetIteration;

        internal void InvokeExit()
        {
            if (OnExit != null)
            {
                OnExit.Invoke();
            }
        }

        internal void InvokeStart()
        {
            if (OnTestStart != null)
                OnTestStart.Invoke();
        }

        internal void InvokeSetIteration(int i)
        {
            if (OnSetIteration != null)
                OnSetIteration.Invoke(i);
        }

        private StringBuilder m_StringBuilder = new StringBuilder();

        public StringBuilder InputStringBuilder { get { return m_StringBuilder; } }

        public void HandleInput(string input)
        {
            HandleInputSegments(input.Split(' '));
        }

        void HandleInputSegments(string[] cmds)
        {
            if (cmds.Length > 0)
            {
                switch (cmds[0].ToLowerInvariant().Trim())
                {
                    case "exit":
                        {
                            InvokeExit();
                            break;
                        }
                    case "start":
                        {
                            HandleStartParameters(cmds);
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Unknown Command Or Command Prefix: {0}", cmds[0]);
                            break;
                        }
                }
            }
        }

        private void HandleStartParameters(string[] cmds)
        {
            if(cmds.Length > 1)
                HandleFirstStartParameter(cmds[1]);

            InvokeStart();
        }

        private void HandleFirstStartParameter(string cmd)
        {
            int iterations;
            if (Int32.TryParse(cmd, out iterations))
            {
                InvokeSetIteration(iterations);

                Console.WriteLine("Running ({0}) Iterations!", iterations);
            }

            else if(cmd == "max")
            {
                InvokeSetIteration(Int32.MaxValue -1);

                Console.WriteLine("Running ({0}) Iterations!", Int32.MaxValue - 1);
            }

            else
                Console.WriteLine("[ERROR]: Unknown Parameter Type (must be an integer) For Start Command.");
        }
    }
}
