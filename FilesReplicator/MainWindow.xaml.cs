using FilesReplicator.Data;
using FilesReplicator.Exceptions;
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
        private string whatsWrong = "";

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
            var updatedStructure = (sender as TextBox).Text;
            try
            {
                var _tree = Parser.StructureParser.ParseStructure(updatedStructure);

                tree[0] = _tree;

                // Update the resources
                selectedFilesListView.ItemsSource = _tree.Resources;
                // Change visibilities
                if (tree[0].Resources.Count > 0)
                {
                    noSelectedFilesTextBlock.Visibility = Visibility.Collapsed;
                }
                else
                {
                    noSelectedFilesTextBlock.Visibility = Visibility.Visible;
                }
            }
            catch (StructureException ex)
            {
                // Provide the details for the StructureException
                whatsWrong = ex.Message;
                flushTree();
            }
            catch (Exception ex)
            {
                // Just mention something is wrong.
                flushTree();
            }
        }

        private void flushTree()
        {
            tree[0] = null;

            // Update the resources
            selectedFilesListView.ItemsSource = null;

            // Change visibilities
            noSelectedFilesTextBlock.Visibility = Visibility.Collapsed;
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
            var sapling = new Seed().GetSapling();
            structureTextBox.Text = sapling;

            tree[0] = StructureParser.ParseStructure(sapling);
            selectedFilesListView.ItemsSource = tree[0].Resources;

            // Change visibilities
            if (tree[0].Resources.Count > 0)
            {
                noSelectedFilesTextBlock.Visibility = Visibility.Collapsed;
            } else
            {
                noSelectedFilesTextBlock.Visibility = Visibility.Visible;
            }
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
            // Select the files in the UI.
        }

        private void selectedFilesRemoveBtn_Click(object sender, RoutedEventArgs e)
        {
            var filePath = ((Button)sender).Tag as string;
            MessageBox.Show(filePath);
        }

        private void replicateBtn_Click(object sender, RoutedEventArgs e)
        {
            // Create the files.
        }
    }
}
