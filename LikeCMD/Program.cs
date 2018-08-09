using System;
 
namespace LikeCMD
{
    class Program
    {

        static void _Create(string WorkName) {
            try {
                if (System.IO.File.Exists(WorkName + ".txt"))
                {
                    Console.WriteLine("Файл существует, переписать? yes = y; no = all other char ");
                    string ANS;
                    ANS = Console.ReadLine();
                    if (ANS.ToLower() == "y")
                    {
                        System.IO.File.WriteAllText(WorkName + ".txt", "");
                        Console.WriteLine("Create successful");
                    }


                }
                else
                {
                    System.IO.File.WriteAllText(WorkName + ".txt", "");
                    Console.WriteLine("Create successful");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
            }
        }

        static string _Entering()
        {
           return (System.Text.RegularExpressions.Regex.Replace(Console.ReadLine(), @"\s+", " ").Trim());
        }

        static string _Entering(string Way)
        {
            try
            {
                string BufWay;
                BufWay = System.Text.RegularExpressions.Regex.Replace(Way, @"\s+", " ").Trim() + "/";
                if (System.IO.Directory.Exists(BufWay))
                    return (BufWay);
                else
                {
                    Console.WriteLine("Каталога не существует, создать? yes = y; no = all other char ");
                    string ANS;
                    ANS = Console.ReadLine();
                    if (ANS.ToLower() == "y")
                    {
                        System.IO.Directory.CreateDirectory(BufWay);
                        return (BufWay);
                    }
                    else return ("xer");
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
                return ("xer");
            }
            
        }
        
                
            
        static void Main(string[] args)
        {
            string NameComand, WayFile;
            WayFile = "C:/";
            do
            {
                Console.Write(WayFile + " ");
                NameComand = _Entering();
                switch ((NameComand.IndexOf(" ") == -1) ? NameComand.ToLower() : (NameComand.Substring(0,NameComand.IndexOf(" ")).ToLower()))
                {
                    case "create":
                        {
                            _Create(WayFile.Trim() + NameComand.Substring("create".Length + 1,NameComand.Length - "create".Length - 1));
                            break;
                        }
                    case "goover":
                        {
                            string BufWay = WayFile;
                            WayFile = _Entering(NameComand.Substring("goover".Length + 1, NameComand.Length - "goover".Length - 1)).ToLower();
                            if (WayFile == "xer") 
                                {
                                WayFile = BufWay; 
                                }
                           break;
                        }
                    case "help":
                        {
                            break;
                        }
                    case "exit":
                        {
                            break;
                        }

                    default:
                        {
                            Console.WriteLine("eror");
                            break;
                        }
                }

                
            } while (NameComand.ToLower() != "exit");
        }

    }
}
