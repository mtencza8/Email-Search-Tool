using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESLibrary;
using System.Threading.Tasks;
using System.IO;
using CsvHelper;

using Microsoft.VisualBasic.FileIO;

namespace ESLibrary
{
    public class FindEmail
    {
           public static void single()
        {

            string firstname, lastname, domain, filename, emailformat;
            string status;


            Console.Write("First Name:  ");
            firstname = Console.ReadLine();

            Console.Write("Last Name:  ");
            lastname = Console.ReadLine();

            Console.Write("Domain:  ");
            domain = "@" + Console.ReadLine();


            Console.WriteLine();
            Console.WriteLine();

            emailformat = GenerateList.ChooseFormat();
            filename = GenerateList.EmailList(firstname, lastname, domain, emailformat);


            try
            {
                using (StreamReader sr = new StreamReader(filename))
                {
                    string emailToValidate;

                    while ((emailToValidate = sr.ReadLine()) != null)
                    {
                        status = Validate.validate(emailToValidate);
                        Console.WriteLine(emailToValidate + "----->" + status);


                    }



                }

            }
            catch (Exception e)
            {

                Console.WriteLine("Something went wrong");
                Console.WriteLine(e.Message);
            }


        }

           public static void list()
        {

            string fileextension, filename;

            Console.WriteLine("File type must be .txt, .csv, .xls, or .xlsx");
            Console.Write(@"Enter file location (C:\\test.csv):  ");
            filename = Console.ReadLine();
            Console.WriteLine(filename);


            fileextension = ValidateFile.filetype(filename);
            filename = filename.Substring(1, filename.Length - 2);
            
            switch (fileextension)
            {
                case "csv":
                case "txt":
                    CSVtxt(filename);

                    break;



                case "xls":
                case "xlsx":
                    excel(filename);
                    break;

            }


        }


           private static void CSVtxt(string filename)
        {
            char HeaderCheck = 'O';
            bool HC_loop = false;
            int EmailCol = 0, numCol, j = 0;
            string status;

            //setting parameters for csv file
            using (TextFieldParser csvParser = new TextFieldParser(filename))
            {//start of using
                csvParser.CommentTokens = new string[] { "#" };
                csvParser.SetDelimiters(new string[] { "," });
                csvParser.HasFieldsEnclosedInQuotes = false;

                //looped to ensure correct response.  Checking for header with either y or n
                while (HC_loop == false)
                { //start of header check while loop
                    Console.Write("Is there a header column (Y/N):  ");
                    HeaderCheck = char.ToUpper(Console.ReadLine()[0]);

                    if (HeaderCheck == 'Y')
                    {
                        csvParser.ReadLine();
                        HC_loop = true;
                    }
                    else if (HeaderCheck != 'N')
                    {
                        Console.WriteLine("That is an incorrect response, please try again");
                    }
                    else
                    {
                        HC_loop = true;
                    }
                }//end of HC while loop


                //read the first line to get # of columns
                string[] fields = csvParser.ReadFields();
                numCol = Enumerable.Count(fields);

                Console.WriteLine("There are {0} columns in your file.", numCol);



                //If there is more than 1 coloumn, finding which is the email
                if (numCol > 1)
                {
                    for (int i = 0; i < Enumerable.Count(fields); i++)
                    {
                        j = i + 1;
                        Console.WriteLine("{0}: {1}", j, fields[i]);
                    }

                    Console.Write("Which one is the e-mail: ");
                    EmailCol = Convert.ToInt32(Console.ReadLine()) - 1;
                }
                else
                {
                    EmailCol = 1;
                }


                //start of validating the emails
                while (!csvParser.EndOfData)
                {//start of while Read File



                    string[] columns = csvParser.ReadFields();


                    if (columns[EmailCol].Contains("@"))
                    {
                        status = Validate.validate(columns[EmailCol]);
                        Console.WriteLine(status);

                    }

                }//end of while Read File

                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();



            }//end of using






        }


        private static void excel(string filename)
        { }

    }
}
