using System;
using System.IO;


namespace ESLibrary
{
        public class GenerateList
    {//start of generate list
        public static string ChooseFormat()
        {
            string emailformat;
            Console.WriteLine("1.) jappleseed@apple.com ");
            Console.WriteLine("2.) johnny.appleseed@apple.com ");
            Console.WriteLine("3.) johnny_appleseed@apple.com ");
            Console.WriteLine("4.) Don't know the format");
            Console.Write("Please choose an email format:  ");
            emailformat = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            return(emailformat);
        }

        public static string EmailList(string firstname, string lastname, string domain, string emailformat = "4")
        {
            string filename = firstname + lastname + ".txt";
            

            


            StreamWriter fn = new StreamWriter(filename);


            switch(emailformat)
            {
                case "1":
                    fn.WriteLine(firstname[0]+lastname+domain);
                    for(char c = 'a'; c <= 'z'; c++)
                    {
                      fn.WriteLine(firstname[0] + char.ToString(c) + lastname+ domain);
                    }
                    break;

                case "2":
                    fn.WriteLine(firstname+ "." +lastname+domain);
                    for(char c = 'a'; c <= 'z'; c++)
                    {
                     fn.WriteLine(firstname + "." + c + "." + lastname+ domain);
                    }
                    break;


                case "3":
                    fn.WriteLine(firstname+ "_"+lastname+domain);
                    for(char c = 'a'; c <= 'z'; c++)
                    {
                     fn.WriteLine(firstname + "_" + c + "_" + lastname+ domain);
                    }
                    break;


                default:
                    fn.WriteLine(firstname+domain);
                    fn.WriteLine(lastname+domain);
                    fn.WriteLine(firstname[0]+lastname+domain);
                    fn.WriteLine(firstname+ "." +lastname+domain);
                    fn.WriteLine(firstname+ "_"+lastname+domain);
                    fn.WriteLine(firstname+lastname+domain);
                    fn.WriteLine(lastname+firstname[0]+domain);
                    fn.WriteLine(firstname+lastname[0]+domain);


                    
                    for(char c = 'a'; c <= 'z'; c++)
                    {
                        fn.WriteLine(firstname + "." + c + "." + lastname+ domain);
                    }

                    for(char c = 'a'; c <= 'z'; c++)
                    {
                        fn.WriteLine(firstname + "_" + c + "_" + lastname+ domain);
                    }

                    for(char c = 'a'; c <= 'z'; c++)
                    {
                        fn.WriteLine(firstname + c + lastname+ domain);
                    }

                    for(char c = 'a'; c <= 'z'; c++)
                    {
                        fn.WriteLine(firstname[0] + char.ToString(c) + lastname+ domain);
                    }
                    break;

            }

            fn.Close();
            return filename;
            
        }
    }//end of generate list
}