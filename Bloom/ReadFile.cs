using System;
using System.Collections.Generic;
using System.IO;

namespace Bloom
{
    public class ReadFile
    {
        public List<String> ReadWordsList(String path)
        {
            var list = new List<String>();

            using (StreamReader reader = new StreamReader(path))
            {
                while(reader.EndOfStream == false)
                {
                    list.Add(reader.ReadLine().Trim());
                }
            }

            return list;
        }
    }
}
