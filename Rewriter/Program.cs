using System.Collections.Generic;
using Rewriter.ContentControllers;
using HtmlAgilityPack;
using System.Text;
using System.Collections;
using System;
using System.Threading;

namespace Rewriter
{
    class Program
    {
        static void Main(string[] args)
        {
            var fileHandler = new FileHandler();

            //List<string> TextList = new List<string>();

            //TextList = fileHandler.ReadFile(@"D:\projects\Rewriter\Content\TextFile.txt");

            //var randomizeList = fileHandler.RandomizedDataList(TextList);

            //fileHandler.WriteFile(@"D:\projects\Rewriter\Content\NewTextFile.txt", randomizeList);

            HtmlWeb web = new HtmlWeb();
            web.OverrideEncoding = Encoding.UTF8;
            HtmlDocument doc = web.Load("https://puzzle-english.com/directory/1000-popular-words/");

            ArrayList list = new ArrayList();
            //HtmlNode nodes = doc.DocumentNode.SelectNodes("//div[contains(@class, 'FR')]//a[@href]");
            int count = 0;
            
            
                foreach (HtmlNode nodes in doc.DocumentNode.SelectNodes("//div[contains(@class, 'container-fluid')]//a[@href]"))
                {
                    count++;
                    //Console.WriteLine(nodes.GetAttributeValue("href", null));
                    list.Add("https://puzzle-english.com/directory/1000-popular-words/" + nodes.GetAttributeValue("href", null));

                    if (count == 3)
                    {
                        break;
                    }
                }

                foreach (string element in list)
                {
                    Thread.Sleep(500);

                    //Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(element);

                    doc = web.Load(element);

                    foreach (HtmlNode link in doc.DocumentNode.SelectNodes("//div[contains(@ol, '')]"))
                    {
                        fileHandler.WriteFile(@"D:\projects\Rewriter\Rewriter\Content\NewTextFile2.txt", link);
                        Console.WriteLine(link.InnerText);
                    }


                    //foreach (HtmlNode link in doc.DocumentNode.SelectNodes("//div[@class = 'MRazp']//span"))
                    //{
                    //    fileHandler.WriteFile(@"D:\projects\Rewriter\Rewriter\Content\NewTextFile2.txt", link);

                    //    Console.WriteLine(link.InnerText);
                    //}

                    //foreach (HtmlNode link in doc.DocumentNode.SelectNodes("//div[@class = 'G9aj5']//p"))
                    //{
                    //    fileHandler.WriteFile(@"D:\projects\Rewriter\Rewriter\Content\NewTextFile2.txt", link);

                    //    Console.WriteLine(link.InnerText);
                    //}

                    //for (int i = 0; i < 2; i++)
                    //{
                    //    Console.WriteLine();
                    //}

                    
                }
                
        }
    }
}
