using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Capstone;

namespace Capstone.Classes
{
    /// <summary>
    /// This class should contain any and all details of access to files
    /// </summary>
    public class FileAccess
    {
        // All external data files for this application should live in this directory.
        // You will likely need to create this directory and copy / paste any needed files.
        private const string sourceFile = @"C:\Catering\cateringsystem.csv";
        private const string destinationLogFile = @"C:\Catering\log.txt";
        CateringSystem auditList = new CateringSystem();
        public void ReadFiles(CateringSystem system)
        {
            

            using (StreamReader fileInput = new StreamReader(sourceFile))

            {

                while (!fileInput.EndOfStream)
                {
                    string line = fileInput.ReadLine();
                    string[] CateringItemArray = line.Split("|");
                    
                    if (CateringItemArray[0] == "B")
                    {
                        Beverages bev = new Beverages(CateringItemArray[2], double.Parse(CateringItemArray[3]), CateringItemArray[1], 10);
                        system.AddCateringItem( bev);
                    }

                    else if (CateringItemArray[0] == "A")
                    {
                        Appetizers app = new Appetizers(CateringItemArray[2], double.Parse(CateringItemArray[3]), CateringItemArray[1], 10);
                        system.AddCateringItem( app);
                    }

                    else if (CateringItemArray[0] == "E")
                    {
                        Entrees ent = new Entrees(CateringItemArray[2], double.Parse(CateringItemArray[3]), CateringItemArray[1], 10);
                        system.AddCateringItem( ent);
                    }

                    else if (CateringItemArray[0] == "D")
                    {
                        Dessert des = new Dessert(CateringItemArray[2], double.Parse(CateringItemArray[3]), CateringItemArray[1], 10);
                        system.AddCateringItem( des);
                    }
                }
            }
        }
        //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  Write File  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

        public void WriteAuditLog(CateringSystem system) //when you're declaring it you're making a new instance of it, which does not have the stored values
                                                         //the reason this works is because we're using a the same cateringSystem object we declared when the system starts
        {
            using (StreamWriter sw = new StreamWriter(destinationLogFile, true))
            {
                List<string> auditLogStrings = system.GetAuditEntries();
                foreach (string log in auditLogStrings)
                {
                    sw.WriteLine(log);
                    
                }




                

            }


        }

        // These files should be read from / written to in the DataDirectory
        private const string CateringFileName = @"cateringsystem.csv";
        private const string ReportFileName = @"totalsales.txt";
    }
}
