using System;
using System.IO;
using ESLibrary;

namespace EmailSearchUI
{//start of namespace
    class Program
    {//start of class
        static void Main(string[] args)
        { //start of main
            string email_case = "0";
            bool exit_loop = true;
            

            
            GenerateList list = new GenerateList();


                Console.WriteLine("*********************************************************************");
                Console.WriteLine("             Welcome to the Email Validation Tool");
                Console.WriteLine("                Written by Mike Tencza");
                Console.WriteLine("         Please submit any feedback to mtencza@ueidaq.com");
                Console.WriteLine("**********************************************************************");
               
                Console.WriteLine();
              
            

            while (exit_loop)
            {//start of while
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("1.) Validate Single E-Mail");
                Console.WriteLine("2.) Validate List of E-Mails");
                Console.WriteLine("3.) Find Single E-Mail");
                Console.WriteLine("4.) Find E-Mails from file");
                Console.Write("Enter option:  ");

                email_case = Console.ReadLine();
                Console.WriteLine();
            
                



                switch (email_case)
                {//start of switch
                    case "1":

                        Validate.single();
                        break;


                    case "2":
                        FindEmail.list();

                       break;

                    case "3":

                        FindEmail.single();                        
                        break;

                    case "4":
                        Console.WriteLine("You chose option 4");
                        Console.WriteLine("Its still under construction, check back later");
                        break;

                    default:
                        Console.WriteLine("Invalid Option");    
                        break;

                    
                }//end of switch

                

            }//end of while

        }//end of main

        
    }//end of class
}// start of namespace
