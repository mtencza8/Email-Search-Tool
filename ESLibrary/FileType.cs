using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.FileIO;


namespace ESLibrary
{//start of namespace
    public class ValidateFile
    {//start of class FileType

        public static string filetype(string fn)
        {//beginning of filetype


            string  fe;
            string apost = "\"";

            Console.WriteLine(apost[0]);


                fe = Path.GetExtension(fn);
         
                fe = fe.Substring(fe.IndexOf(".") + 1, fe.Length - 2);
            


            if (fn[0] == apost[0])
                fn = fn.Substring(1,fn.Length-2);

           
            return (fe);

        }//end of filetype


       

    }//end of class
}//end of namespace
