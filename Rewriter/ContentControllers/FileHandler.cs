using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Rewriter.ContentControllers
{
    public class FileHandler
    {       
        public List<string> ReadFile(string readPath)
        {
            List<string> dataList = new List<string>();

            using (StreamReader sr = new StreamReader(readPath, System.Text.Encoding.Default))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    dataList.Add(line);
                }
            }

            return dataList;
        }

        public void WriteFile(string writePath, IOrderedEnumerable<string> randomizedDataList)
        {
            using (StreamWriter sr = new StreamWriter(writePath, true, System.Text.Encoding.Default))
            {
                foreach (var str in randomizedDataList)
                {
                    sr.WriteLine(str);
                }
            }
        }

        public IOrderedEnumerable<string> RandomizedDataList(List<string> originalList)
        {
            var rnd = new Random();

            var randomizedDataList = originalList.OrderBy(i => rnd.Next());

            return randomizedDataList;
        }
    }
}
