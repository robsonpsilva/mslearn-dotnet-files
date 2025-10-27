// See https://aka.ms/new-console-template for more information
using System.IO;
using System.Collections.Generic;

IEnumerable<string> listOfDirectories = Directory.EnumerateDirectories("stores");

foreach (var dir in listOfDirectories) {
    Console.WriteLine(dir);
}

// Outputs:
// stores/201
// stores/202
Console.WriteLine("Hello, World!");
