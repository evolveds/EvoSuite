using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace EvoEngine.Interfaces
{
    internal interface IEngineInit
    {
        XmlReader Config { get; }
        Type FrameType { get; }
    }
}
