using System.Diagnostics;

namespace OpenCores
{

    public class Program
    {

        static void Main(string[] args)
        {

            if (GArgs.Args.IsArgsOpen(args.Length))
            {

                string contents = File.ReadAllText("urls.txt");

                if (!GArgs.Args.IsEmpty(contents))
                {

                    if (contents.Contains(GetPicked(GArgs.VisitPortal.Google)))
                    {
                        Process.Start("C:\\Program Files\\Google\\Chrome\\Application\\chrome.exe", GetPicked(GArgs.VisitPortal.Google));
                    }

                    if (contents.Contains(GetPicked(GArgs.VisitPortal.YouTube)))
                    {
                        Process.Start("C:\\Program Files\\Google\\Chrome\\Application\\chrome.exe", GetPicked(GArgs.VisitPortal.YouTube));
                    }

                    else
                    {
                        Process.Start("C:\\Program Files\\Google\\Chrome\\Application\\chrome.exe", contents);

                    }
                }
            }
        }

        public static string GetPicked(GArgs.VisitPortal siteVisited)
        {
            if (siteVisited == GArgs.VisitPortal.Google)
            {
                return "https://www.google.com";
            }

            if (siteVisited == GArgs.VisitPortal.YouTube)
            {
                return "https://www.youtube.com";
            }

            return "https://www.google.com";
        }

        
    }

}


namespace GArgs
{

    public enum VisitPortal
    {
        Google,
        YouTube,

    }
    class Args
    {

        public static bool IsArgsOpen(int lengthOfArgs)
        {
            if (lengthOfArgs < 10)
            {
                return true;
            }

            return false;
        }

        public static bool IsEmpty(string initString)
        {

            if (initString == string.Empty)
            {
                Console.WriteLine("Text is Empty");
                return false;
            }

            return false;

        }
    }

}