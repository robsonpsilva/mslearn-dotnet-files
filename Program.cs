// See https://aka.ms/new-console-template for more information
 using System.IO;
 using System.Collections.Generic;



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