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
using Microsoft.Win32;
using ToysRoom.Toys;

namespace ToysRoom
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ToyRoom toyRoom;
        public MainWindow()
        {
            InitializeComponent();
            toyRoom = new ToyRoom();
        }

        private void OpenButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.DefaultExt = ".dat";
            ofd.AddExtension = true;
            ofd.Filter = "Dat files (*.dat)|*.dat";
            ofd.Title = "Open file";
            ofd.InitialDirectory = "C:\\Users\\ilona\\source\\repos\\semestr 5\\OOP\\Lab1\\ToyRoom\\ToyRoom\\bin\\Debug";
            if (ofd.ShowDialog() == true)
            {
                this.toyRoom.Input(ofd.FileName);
            }
            UpdateToys();
        }
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.DefaultExt = ".dat";
            sfd.AddExtension = true;
            sfd.Filter = "Dat files (*.dat)|*.dat";
            sfd.Title = "Choose a directory";
            sfd.InitialDirectory = "C:\\Users\\ilona\\source\\repos\\semestr 5\\OOP\\Lab1\\ToyRoom\\ToyRoom\\bin\\Debug";
            if (sfd.ShowDialog() == true)
            {
                this.toyRoom.Output(sfd.FileName);
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            AddToy addToy = new AddToy();
            addToy.Owner = this;
            addToy.ShowDialog();
            UpdateToys();
        }
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            Object treeViewItem = this.treeToys.SelectedItem;
            int index=0;
            for(int i=0;i<treeToys.Items.Count;i++)
            {
                if (treeToys.Items[i]==treeViewItem)
                {
                    index = i;
                    break;
                }
            }
            Toy toy = toyRoom.ListToys[index];
            toyRoom.ListToys.Remove(toy);
            UpdateToys();
        }
        private void SortByPriceButton_Click(object sender, RoutedEventArgs e)
        {
            toyRoom.SortByPrice();
            UpdateToys();
        }
        private void SortByTypeButton_Click(object sender, RoutedEventArgs e)
        {
            Dictionary<string, List<Toy>> dictionary = toyRoom.SortByType();
            SortedToys(dictionary);
        }
        private void SortByAgeButton_Click(object sender, RoutedEventArgs e)
        {
            Dictionary<string, List<Toy>> dictionary = toyRoom.SortByAge();
            SortedToys(dictionary);
        }
        private void SortBySizeButton_Click(object sender, RoutedEventArgs e)
        {
            Dictionary<string, List<Toy>> dictionary = toyRoom.SortBySize();
            SortedToys(dictionary);
        }
        private void SortByMaterialButton_Click(object sender, RoutedEventArgs e)
        {
            Dictionary<string, List<Toy>> dictionary = toyRoom.SortByMaterial();
            SortedToys(dictionary);
        }
        
        private void UpdateToys()
        {
            this.treeToys.Items.Clear();
            TreeViewItem treeViewItem;
            string descriprion;
            foreach (Toy toy in toyRoom.ListToys)
            {
                treeViewItem = new TreeViewItem();
                if (toy is Ball)
                    descriprion = (toy as Ball).GetDescription();
                else if (toy is Car)
                    descriprion = (toy as Car).GetDescription();
                else descriprion = (toy as Doll).GetDescription();
                treeViewItem.Header = descriprion;
                this.treeToys.Items.Add(treeViewItem);
            }
            this.price.Content = this.toyRoom.price;
        }

        private void SortedToys(Dictionary<string,List<Toy>> dictionary)
        {
            this.treeToys.Items.Clear();
            TreeViewItem parent;
            TreeViewItem child;
            string descriprion;
            foreach (string key in dictionary.Keys)
            {
                parent = new TreeViewItem();
                parent.Header = key;
                foreach (Toy toy in dictionary[key])
                {
                    child = new TreeViewItem();
                    if (toy is Ball)
                        descriprion = (toy as Ball).GetDescription();
                    else if (toy is Car)
                        descriprion = (toy as Car).GetDescription();
                    else descriprion = (toy as Doll).GetDescription();
                    child.Header = descriprion;
                    parent.Items.Add(child);
                }
                this.treeToys.Items.Add(parent);
            }
        }

        private void maxPriceButton_Click(object sender, RoutedEventArgs e)
        {
            int max;
            if (int.TryParse(maxPrice.Text, out max) && max > 0)
                this.toyRoom.maxPrice = max;
            else
            {
                MessageBox.Show(
                "Please input another value.",
                "Wrong input",
                MessageBoxButton.OK,
                MessageBoxImage.Error,
                MessageBoxResult.OK,
                MessageBoxOptions.DefaultDesktopOnly);
                maxPrice.Text = this.toyRoom.maxPrice.ToString();
            }
        }
    }
}
