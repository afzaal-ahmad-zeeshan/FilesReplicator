using FilesReplicator.Data;
using FilesReplicator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FilesReplicator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Dummy data
        private List<Tree> d_tree = new List<Tree>();
        private string d_content = "";

        private void loadTree()
        {
            // prepare the tree and load it.
            d_tree.Add(new Seed().MakeTree());

            // parse the tree and write it in the textbox
            d_content = Parser.StructureParser.ToText(d_tree[0]);
            structureTextBox.Text = d_content;
        }
        #endregion

        private Tree tree;
        private string content;

        public MainWindow()
        {
            InitializeComponent();

            // Put the focus on the textbox.
            structureTextBox.Focus();

#if DEBUG
            loadTree();

            // render
            directoryTreeView.ItemsSource = d_tree;
#endif
            }

        private void structureTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void directoryTreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {

        }

        private void whatsWrongBtn_Click(object sender, RoutedEventArgs e)
        {
            // Is there something wrong with structure? Files? TreeView?
        }

        private void resetBtn_Click(object sender, RoutedEventArgs e)
        {
            // Clear everything, and restart.
        }

        private void createDirectoryBtn_Click(object sender, RoutedEventArgs e)
        {
            // Flush the content to the directory
        }

        private void selectFilesBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
