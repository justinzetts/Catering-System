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
        private const string destinationTotalSalesFile = @"C:\Catering\totalsales.txt";
        private const string SourceTotalSalesFile = @"C:\Catering\totalsalessource.txt";
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


        //public void WriteTotalSalesLog(CateringItem item)
        //{
        //    List<string> totalSalesList = new List<string>();
        //    using (StreamReader sr = new StreamReader(SourceTotalSalesFile))
        //    using (StreamWriter sw = new StreamWriter(destinationTotalSalesFile, false))
        //    {

        //    double totalSalesVariable = 0;
        //    for (int i = 0; i < 18; i++)
        //        {
        //            string line = sr.ReadLine();
        //            string[] totalSalesArray = line.Split("|");

        //            string itemName = item.Name;
        //            int numberSold = int.Parse(totalSalesArray[1]);
        //            string[] arrayIndex2WithoutDollarSign = totalSalesArray[2].Split("$");
        //            double revenueSold = double.Parse(arrayIndex2WithoutDollarSign[1]);

        //            numberSold += item.TotalAmountPurchased;
        //            revenueSold += item.TotalRevenue;
        //            totalSalesVariable += item.TotalRevenue;

        //            sw.WriteLine(@$"{item.Name}|{numberSold}|${revenueSold}");

        //            // need to copt TotalSales.txt to TotalSalesSource.txt as final step
        //        }
        //    }
        //}

        // These files should be read from / written to in the DataDirectory
        private const string CateringFileName = @"cateringsystem.csv";
        private const string SourceReportFileName = @"totalsales.txt";
    }
}
