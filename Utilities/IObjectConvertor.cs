using System;

namespace MessagingApp.Utilities
{
    public interface IObjectConvertor
    {
          byte[] serializeToXML(Object obj);
          Object deserializeFromXML(byte[] data);
    }
}