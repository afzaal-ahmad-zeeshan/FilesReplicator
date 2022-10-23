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
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            // Read the arguments from "e.Args".
            var arguments = e.Args;

            File.WriteAllText("output.txt", "Hello");

            // Run the MainWindow
            //App.Current.Dispatcher.Invoke(
            //    new Action(() =>
            //    {
            //        new MainWindow().Show();
            //    })
            //);
        }
    }
}
