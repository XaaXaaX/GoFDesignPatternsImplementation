using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace GoFDesignPatternsImplementation.Domain.DomainTraversalModels
{
    [Serializable]
    public class Prototype<T>
    {
        public T Clone()
        {
            return (T)this.MemberwiseClone();
        }
        public T FullClone()
        {
            try
            {
                MemoryStream stream = new MemoryStream();
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, this);
                stream.Seek(0, SeekOrigin.Begin);
                T copy = (T)formatter.Deserialize(stream);
                stream.Close();
                return copy;
            }
            catch (Exception e)
            {

                throw;
            }
        }
    }


}
