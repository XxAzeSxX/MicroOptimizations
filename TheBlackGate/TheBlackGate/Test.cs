using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBlackGate
{
    class Test
    {
        bool m_TestMode = true;
        static Test m_Instance;

        public static bool TestMode_A
        {
            get
            {
                if (m_Instance != null)
                    return m_Instance.m_TestMode;
                else
                    return false;
            }
        }

        public static bool TestMode_B
        {
            get
            {
                return (m_Instance != null && m_Instance.m_TestMode);
            }
        }

        public Test()
        {
            if (m_Instance == null)
                m_Instance = this;
        }
    }
}
