using EvoEngine.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using EvoEngine.Screen;
using System.Threading;

namespace EvoEngine
{
    public class Engine
    {
        public delegate void DefaultTransport<T>(T Frame, Type FrameType);
        public event DefaultTransport<object> OnNewMessage;
        public event DefaultTransport<IFrame> OnNewFrame;
        private Thread m_thread;
        private Type m_FrameType;
        private FrameFactory m_Frames;

        private void EngineRunner()
        {
            while (true)
            {
                if (m_Frames == null)
                    m_Frames = new FrameFactory(m_FrameType);

                if (OnNewMessage != null)
                {
                }
                if (OnNewFrame != null)
                {
                    OnNewFrame(m_Frames.NextEngineFrame(), m_FrameType);
                }
            }
        }

        private Engine(XmlReader c_Config, Type c_FrameType)
        {
            //Implement XML Configuration
            m_FrameType = c_FrameType;
            //if (m_timer == null)
            //m_timer = new System.Threading.Timer(x => EngineRunner(), null, 1,1);
            m_thread = new Thread(x => EngineRunner());
            m_thread.Start();
            
        }
        private Engine()
        { }
         
        private Engine(Engine c_engine)
        { }

        internal static Engine StartEngine(IEngineInit c_Init)
        {
            return new Engine(c_Init.Config, c_Init.FrameType);
        }

        public static Engine StartEngine(PublicInitializer c_Init)
        {
            return StartEngine((IEngineInit)c_Init);
        }
    }
}
