using EvoEngine.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace EvoEngine
{
    public class PublicInitializer : IEngineInit
    {
        private XmlReader m_config;
        XmlReader IEngineInit.Config
        {
            get
            {
                return m_config;
            }
        }

        public Type FrameType { get; set; }

        /// <summary>
        /// Single use set m_config.
        /// 
        /// This can only set it once as if the config has already been set elsewhere this will
        /// not change it.
        /// </summary>
        /// <param name="XML">XML file for the configuration of the engine</param>
        public void setConfig(Stream XML)
        {
            if(m_config== null)
                m_config = XmlReader.Create(XML);
        }
       
        /// <summary>
        /// Reset the configuration of the engine. This will cause the engine to pause
        /// Any changes made using resetConfig will be reflected as soon as the Engine notices there is a new
        /// configuration available.
        /// 
        /// !!This could be dangerous!!
        /// </summary>
        public void resetConfig(Stream XML)
        {
            //dispose
            m_config.Dispose();
            //nullify
            m_config = null;
            //recreate
            m_config = XmlReader.Create(XML);
        }
    }
}
