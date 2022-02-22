using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Text.Json;
using System.IO;
using System.Web;

namespace ESLibrary
{
    public class Validate
    {
       private class ZBResponse
        {//start of ZBresponse
            public string address { get; set; }
            public string status { get; set; }
            public bool free_email { get; set; }
            public string didyoumean { get; set; }
            public string account { get; set; }
            public string domain { get; set; }
            public string domainagedays { get; set; }
            public string provider { get; set; }
            public string mxrecord { get; set; }
            public bool mxfound { get; set; }
            public string firstname { get; set; }
            public string lastname { get; set; }
            public string gender { get; set; }
            public string country { get; set; }
            public string region { get; set; }
            public string city { get; set; }
            public string zipcode { get; set; }
            public string processedat { get; set; }
        }// ned of ZBResponse


        public static string validate(string emailToValidate)
        {//start of validate

            string status;


            try
            {//start of try


                string api_key = File.ReadAllText("info.config");
                string ip_address = ""; //Can be blank, but parameter required on the API Call

                string responseString = "";

                string apiURL = "https://api.zerobounce.net/v2/validate?api_key=" + api_key + "&email=" + HttpUtility.UrlEncode(emailToValidate) + "&ip_address=" + HttpUtility.UrlEncode(ip_address);


                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(apiURL);
                request.Timeout = 150000;
                request.Method = "GET";

                using (WebResponse response = request.GetResponse())
                {//start of outer using
                    //response.GetResponseStream().ReadTimeout = 20000;
                    using (StreamReader ostream = new StreamReader(response.GetResponseStream()))
                    {//start of inner using
                        responseString = ostream.ReadToEnd();
                    }//end of outer using
                }//end of outer using

                ZBResponse zbresponse = JsonSerializer.Deserialize<ZBResponse>(responseString);
                status = zbresponse.status;
                return status;


            }//end of try 

            catch (Exception ex)
            {//start of catch
                status = "not found";
                Console.WriteLine(ex);

                return status;
                //Catch Exception - All errors will be shown here - if there are issues with the API
            }//end of catch
        }


        public static void single()
        {
            bool exit_case = true;
            string email, status, check;

            //stay in while under done entering emails
            while (exit_case == true)
            {
                Console.Write("Enter the e-mail you wish to validate:  ");
                email = Console.ReadLine();
                status = Validate.validate(email);
                Console.WriteLine("Status:   " + status);
                Console.WriteLine();


                Console.Write("Do you have another e-mail? (Y/N):   ");
                check = Console.ReadLine();
             



                if (check[0] != 'Y' && check[0] != 'y')
                {
                    exit_case = false;
                }
                

            }

        }
        public static string list(string emailToValidate)
        {

            return ("Under Construction");


        }
    }




}
