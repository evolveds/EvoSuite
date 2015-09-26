using EvoEngine;
using EvoEngine.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EvoEngine.Screen;
using EvoEngineFormsUI.Frame;

namespace EvoEngineFormsUI
{
    public partial class Form1 : Form
    {
        private Engine m_Engine;
        public Form1(Engine c_Engine)
        {
            InitializeComponent();
            m_Engine = c_Engine;
            m_Engine.OnNewFrame += OnNewFrame;
            m_Engine.OnNewMessage += OnNewMessage;
        }

        private string m_frameString = "";
        private string m_fullFrameString = "";
        private void OnNewFrame(IFrame FrameIn, Type FrameType)
        {
            if (this.InvokeRequired)
            {
                MethodInvoker del = delegate { OnNewFrame(FrameIn, FrameType); };
                this.Invoke(del);
                return;
            }
            if (FrameIn == null)
                return;
            if(FrameType == typeof(FullFrame))
            {
                Frame<IEngineFrameContainer> Frame = (Frame<IEngineFrameContainer>)FrameIn;
                FullFrame fullFrame = (FullFrame)Frame.CurrentFrame;
                using (var gfx = pnlFrame.CreateGraphics())
                {
                    gfx.Clear(Color.Black);
                    gfx.DrawPath(new Pen(new SolidBrush(Color.White)), fullFrame.Frame);
                }
            }
            //SetTitle();
        }

        private void SetTitle()
        {
            this.Text = String.Format("{0} - {1} - {2} - {3}",m_title,m_count,m_frameString, m_fullFrameString);
        }

        private int m_count = 0;
        private string m_title = "";
        private void OnNewMessage(object Frame, Type FrameType)
        {
            if (this.InvokeRequired)
            {
                MethodInvoker del = delegate { OnNewMessage(Frame, FrameType); };
                this.Invoke(del);
                return;
            }
            if(FrameType == typeof(string))
                m_title = (string)Frame;
            if (FrameType == typeof(int))
                m_count += (int)Frame;
            //SetTitle();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
