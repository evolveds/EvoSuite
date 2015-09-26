using EvoEngine.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvoEngine.Screen
{
    public class FrameFactory
    {

        public FrameFactory() { }

        public FrameFactory(Type c_FrameType)
        {
            m_FrameType = c_FrameType;
        }

        Type m_FrameType;
        Frame<IEngineFrameContainer> m_EngineFrame;

        public IFrame HelloFrame()
        {
            //if (m_frame == null)
            //{
                Frame<string> frame = new Frame<string>();
                frame.SetFrame("Hello");
                //m_frame = frame;
            //}
            return frame;
        }

        public IFrame NextEngineFrame()
        {
            var hasEngineFrame = m_FrameType.GetInterfaces().Contains(typeof(IEngineFrameContainer));
            if (m_EngineFrame == null && hasEngineFrame )
            {
                IEngineFrameContainer frame_container = (IEngineFrameContainer)Activator.CreateInstance(m_FrameType);
                m_EngineFrame = new Frame<IEngineFrameContainer>() { CurrentFrame = frame_container };
            }
            if (m_EngineFrame != null)
                m_EngineFrame.CurrentFrame.UpdateFrame();
            return m_EngineFrame;
        }
    }
}
