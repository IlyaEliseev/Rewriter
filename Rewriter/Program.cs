using System.Collections.Generic;
using Rewriter.ContentControllers;

namespace Rewriter
{
    class Program
    {
        static void Main(string[] args)
        {            
            var fileHandler = new FileHandler();

            List<string> TextList = new List<string> ();

            TextList = fileHandler.ReadFile(@"D:\projects\Rewriter\Content\TextFile.txt");

            var randomizeList = fileHandler.RandomizedDataList(TextList);

            fileHandler.WriteFile(@"D:\projects\Rewriter\Content\NewTextFile.txt", randomizeList);            
        }        
    }
}
