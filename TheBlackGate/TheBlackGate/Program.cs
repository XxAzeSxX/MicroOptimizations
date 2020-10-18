using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBlackGate
{
    class Program
    {
        static bool m_Active = true;

        private static Test m_Test = new Test();

        private static InputHandler m_InputHandler = new InputHandler();

        static System.Diagnostics.Stopwatch m_Stopwatch = new System.Diagnostics.Stopwatch();

        static void Main(string[] args)
        {
            Initialize();

            while (m_Active)
            {
                Console.WriteLine("//:");
                m_InputHandler.HandleInput(Console.ReadLine());
            }
        }

        private static void Initialize()
        {
            InputHandler.OnExit += InputHandler_OnExit;
            InputHandler.OnTestStart += InputHandler_OnTestStart;
            InputHandler.OnSetIteration += InputHandler_OnSetIteration;
        }

        private static void InputHandler_OnSetIteration(int i)
        {
            m_Iterations = i;
        }

        private static void InputHandler_OnTestStart()
        {
            StartTest();
        }

        private static void StartTest()
        {
            Console.WriteLine("Starting (A/B) Test, Please Wait...");
            Console.WriteLine("/*****************/");
            Console.WriteLine();

            Console.WriteLine("Starting Test (A)");

            m_Stopwatch.Reset(); m_Stopwatch.Start();
            Console.WriteLine("/*****************/");

            RunTest_A();
            m_Stopwatch.Stop();

            Console.WriteLine("Test (A) Total Time: {0}ms", m_Stopwatch.ElapsedMilliseconds);

            Console.WriteLine("/*****************/");
            Console.WriteLine("/*****************/");

            Console.WriteLine("Starting Test (B)");
            m_Stopwatch.Reset(); m_Stopwatch.Start();
            Console.WriteLine("/*****************/");

            RunTest_A();
            m_Stopwatch.Stop();

            Console.WriteLine("Test (B) Total Time: {0}ms", m_Stopwatch.ElapsedMilliseconds);
        }

        private static void InputHandler_OnExit()
        {
            Deactivate();
        }

        private static void Deactivate()
        {
            m_Active = false;
        }

        static int m_Iterations = 1000000000;
        private static void RunTest_A()
        {
            Console.WriteLine("Iterations (A): {0}", m_Iterations);
            for (int i = m_Iterations - 1; i >= 0; i--)
            {
                if(Test.TestMode_A)
                {
                    int x = 0;
                }
            }
        }

        private static void RunTest_B()
        {
            Console.WriteLine("Iterations (B): {0}", m_Iterations);
            for (int i = m_Iterations - 1; i >= 0; i--)
            {
                if (Test.TestMode_B)
                {
                    int x = 0;
                }
            }
        }
    }
}
