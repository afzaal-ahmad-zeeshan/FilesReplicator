using FilesReplicator.Parser;
using FilesReplicator.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;

namespace FilesReplicator
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        // Some variables
        private bool onlyCli = false;
        private string structureFile = "";

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            // Read the arguments from "e.Args".
            var arguments = e.Args;
            bool allGood = true;

            // Process
            for (var i = 0; i < arguments.Length; i++)
            {
                var arg = arguments[i];
                if (arg == "--onlycli")
                {
                    Console.WriteLine("Running only in the CLI...");
                    onlyCli = true;
                } else if (arg == "--file")
                {
                    // the structure file
                    Console.WriteLine("Reading the structure file path...");
                    if (i < arguments.Length - 1)
                    {
                        structureFile = arguments[i + 1];
                        Console.WriteLine("The parameter value is: " + structureFile);
                    } else
                    {
                        // print that the --file argument does not have a follow-up value
                        allGood = false;
                    }
                }
            }
            
            // Is the CLI well used?
            if (!allGood)
            {
                Console.WriteLine("Something went wrong, check the flags and put them in correct order.");
                Environment.Exit(1);
            }

            if (onlyCli)
            {
                // Process the structure file
                try
                {
                    Console.WriteLine("Reading the structure file...");
                    if (File.Exists(structureFile))
                    {
                        var tree = StructureParser.ParseStructure(File.ReadAllText(structureFile));

                        Console.WriteLine("Read the structure, creating resources in root directory: " + tree.ParentDirectory);
                        Replicator.CreateDirectories(tree);

                        // Close the process.
                        Console.WriteLine("Done, terminating the process...");
                        Environment.Exit(0);
                    } else
                    {
                        Console.WriteLine("The structure file not found: " + structureFile);
                    }
                } catch (Exception ex) 
                {
                    Console.WriteLine("Something went wrong, " + ex.Message);
                }
            } else
            {
                // Run the MainWindow
                Console.WriteLine("Launching the UI...");
                App.Current.Dispatcher.Invoke(
                    new Action(() =>
                    {
                        new MainWindow().Show();
                    })
                );
            }
        }
    }
}
