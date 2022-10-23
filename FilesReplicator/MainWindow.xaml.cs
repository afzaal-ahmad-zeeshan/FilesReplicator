using FilesReplicator.Data;
using FilesReplicator.Models;
using FilesReplicator.Parser;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private void loadTree()
        {
            // prepare the tree and load it.
            tree.Add(new Seed().MakeTwoLevelTree());

            // parse the tree and write it in the textbox
            //d_content = Parser.StructureParser.ToText(d_tree[0]);

            content = Parser.StructureParser.ToText(tree[0]); 
            structureTextBox.Text = content;
        }
        #endregion

        private ObservableCollection<Tree> tree = new ObservableCollection<Tree>();
        private string content = "";

        public MainWindow()
        {
            InitializeComponent();

            // Put the focus on the textbox.
            structureTextBox.Focus();

#if DEBUG
            loadTree();
#endif
            // render
            renderTree();
        }

        private void renderTree()
        {
            // render
            directoryTreeView.ItemsSource = tree;

            // show the files
            if (tree[0].Resources.Count > 0)
            {
                selectedFilesListView.ItemsSource = tree[0].Resources;
                noSelectedFilesTextBlock.Visibility = Visibility.Collapsed;
            }
            else
            {
                selectedFilesListView.ItemsSource = null;
                noSelectedFilesTextBlock.Visibility = Visibility.Visible;
            }
        }

        private void structureTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            //var updatedStructure = (sender as TextBox).Text;
            //var updatedTree = StructureParser.FromYaml(updatedStructure);

            //d_tree[0] = updatedTree;
        }

        private void directoryTreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {

        }

        private void whatsWrongBtn_Click(object sender, RoutedEventArgs e)
        {
            // Is there something wrong with structure? Files? TreeView?
        }

        private void resetTree()
        {
            structureTextBox.Text = String.Empty;
            tree[0] = new Tree();
            selectedFilesListView.ItemsSource = null;
            noSelectedFilesTextBlock.Visibility = Visibility.Visible;
        }

        private void resetBtn_Click(object sender, RoutedEventArgs e)
        {
            resetTree();
        }

        private void createDirectoryBtn_Click(object sender, RoutedEventArgs e)
        {
            // Flush the content to the directory
        }

        private void selectFilesBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void selectedFilesRemoveBtn_Click(object sender, RoutedEventArgs e)
        {
            var filePath = ((Button)sender).Tag as string;
            MessageBox.Show(filePath);
        }
    }
}
