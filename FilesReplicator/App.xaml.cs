using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace FilesReplicator
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        // Some checks
        private bool onlyCli = false;
        private string structureFile = "";

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            // Read the arguments from "e.Args".
            var arguments = e.Args;
            foreach (var argument in arguments)
            {
                if (argument == "--onlycli")
                {
                    // don't launch the UI.
                    onlyCli = true;
                } else if (argument == "")
                {
                    // handle
                }
            }

            if (onlyCli)
            {
                File.WriteAllText("output.txt", "Hello");

                // Close the process.
                Environment.Exit(0);
            } else
            {
                // Run the MainWindow
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
