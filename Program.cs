using System.IO;
using System.Text;
using System.Text.Json;
using System.Globalization;
using System.Collections.Generic;

public class SalesSummaryReport
{
    private class SalesTotalData
    {
        public decimal OverallTotal { get; set; }
    }

    public static void ProcessSales(string storePath, string outputPath)
    {
        
        decimal grandTotal = 0m;
        
        var salesDetails = new List<(string FileName, decimal Total)>();

        // Fetch all "salestotals.json" files
        IEnumerable<string> salesFiles = Directory.EnumerateFiles(
            storePath, 
            "salestotals.json", 
            SearchOption.AllDirectories
        );

        foreach (var file in salesFiles)
        {
            try
            {
                string jsonContent = File.ReadAllText(file);
                var salesData = JsonSerializer.Deserialize<SalesTotalData>(jsonContent);

                if (salesData != null)
                {
                    decimal total = salesData.OverallTotal;
                    
                    // Accumulates the total
                    grandTotal += total;
                    
                    salesDetails.Add((Path.GetFileName(file), total));
                }
            }
            catch (Exception ex)
            {
                
                Console.WriteLine($"Erro ao processar o arquivo {file}: {ex.Message}");
            }
        }

        // Build the final report using StringBuilder
        var report = new StringBuilder();
        var culture = new CultureInfo("en-US");

        report.AppendLine("Sales Summary Report");
        report.AppendLine("--------------------------------------------------");
        
        
        report.AppendLine($"Total Sales: {grandTotal.ToString("C2", culture)}"); 
        report.AppendLine();
        report.AppendLine("Details:");

        foreach (var detail in salesDetails)
        {
            string totalStr = detail.Total.ToString("C2", culture);
            
            report.AppendLine($"  {detail.FileName.PadRight(30)}: {totalStr.PadLeft(15)}");
        }
        report.AppendLine("--------------------------------------------------");

        File.WriteAllText(outputPath, report.ToString());
    }
}

class Program
{
    static void Main(string[] args)
    {
        string baseDirectory = AppContext.BaseDirectory;
        string projectRoot = Path.GetFullPath(Path.Combine(baseDirectory, @"..\..\..\"));
        Directory.SetCurrentDirectory(projectRoot);
        string baseDir = Directory.GetCurrentDirectory();
        string storePath = Path.Combine(baseDir, "stores");
        string outputPath = Path.Combine(baseDir, "sales_summary.txt");

        SalesSummaryReport.ProcessSales(storePath, outputPath);
    }
}

// string baseDirectory = AppContext.BaseDirectory;
// string projectRoot = Path.GetFullPath(Path.Combine(baseDirectory, @"..\..\..\"));
// Directory.SetCurrentDirectory(projectRoot);
// IEnumerable<string> listOfDirectories = Directory.EnumerateDirectories("stores");
// Console.WriteLine("Directories:");
// foreach (var dir in listOfDirectories) {
//     Console.WriteLine(dir);
// }

// IEnumerable<string> files = Directory.EnumerateFiles("stores");
// Console.WriteLine("Files:");
// foreach (var file in files)
// {
//     Console.WriteLine(file);
// }

// // Outputs:
// // stores/totals.txt
// // stores/sales.json


// Console.WriteLine("Sales files:");
// var salesFiles = FindFiles("stores");

// foreach (var file in salesFiles)
// {
//     Console.WriteLine(file);
// }

// IEnumerable<string> FindFiles(string folderName)
// {
//     List<string> salesFiles = new List<string>();

//     var foundFiles = Directory.EnumerateFiles(folderName, "*", SearchOption.AllDirectories);

//     foreach (var file in foundFiles)
//     {
//         // The file name will contain the full path, so only check the end of it
//         if (file.EndsWith("sales.json"))
//         {
//             salesFiles.Add(file);
//         }
//     }

//     return salesFiles;
// }

// Console.WriteLine("Current Find json files:");



// var jsonFiles = FindAllFiles(".json");

// foreach (var file in jsonFiles)
// {
//     Console.WriteLine(file);
// }

// IEnumerable<string> FindAllFiles(string extensionType)
// {
//     IEnumerable<string> foundFiles = Directory.EnumerateFiles("stores", "*", SearchOption.AllDirectories);
//     List<string> salesFiles = new List<string>();
//     foreach (var file in foundFiles)
//     {
//         var extension = Path.GetExtension(file);
//         if (extension == ".json")
//         {
//             salesFiles.Add(file);
//         }
//     }
//     return salesFiles;
// }
// // /home/username/dotnet-files/stores/sales.json  
// // /home/username/dotnet-files/stores/201/sales.json
// // /home/username/dotnet-files/stores/201/salestotals.json  
// // /home/username/dotnet-files/stores/202/sales.json
// // /home/username/dotnet-files/stores/202/salestotals.json    
// // /home/username/dotnet-files/stores/203/sales.json  
// // /home/username/dotnet-files/stores/203/salestotals.json  
// // /home/username/dotnet-files/stores/204/sales.json  
// // /home/username/dotnet-files/stores/204/salestotals.json  

// if (!Directory.Exists(Path.Combine(Directory.GetCurrentDirectory(), "stores", "201", "newDir")))
// {
//     Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), "stores", "201", "newDir"));
// }

// File.WriteAllText(Path.Combine(Directory.GetCurrentDirectory(), "greeting.txt"), "Hello World!");
//----------------------------Create files and directories--------------------