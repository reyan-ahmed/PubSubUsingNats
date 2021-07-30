using System;
using System.IO;
using System.Xml.Serialization;
using MessagingApp.Models;

namespace MessagingApp.Utilities
{
    public class ObjectConvertor : IObjectConvertor
    {
        public byte[] serializeToXML(Object obj)
        {
            MemoryStream ms = new MemoryStream();
            XmlSerializer x = new XmlSerializer(((MessageBody)obj).GetType());

            x.Serialize(ms, obj);

            byte[] content = new byte[ms.Position];
            Array.Copy(ms.GetBuffer(), content, ms.Position);

            return content;
        }

        public Object deserializeFromXML(byte[] data)
        {
            XmlSerializer x = new XmlSerializer(new MessageBody().GetType());
            MemoryStream ms = new MemoryStream(data);
            return x.Deserialize(ms);
        }
    }
}