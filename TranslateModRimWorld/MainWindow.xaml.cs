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
using Microsoft.Win32;
using System.IO;
using TranslateMod;

namespace TranslateModRimWorld
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Translate translate = new Translate();
        public MainWindow()
        {
            InitializeComponent();
            MessageBox.Show("Данная программа использует обычный переводчик, возможен кривой перевод");
        }

        private void bStartTranslate_Click(object sender, RoutedEventArgs e)
        {
            foreach (object item in lbFiles.Items)
            {
                translate.StartTranslateXML(Convert.ToString(item));
            }
            MessageBox.Show("Перевод выполнен, удачной игры");
        }

        private void addFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true;
            openFileDialog.Filter = "Xml files (*.xml)|*.xml|All files (*.*)|*.*";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (openFileDialog.ShowDialog() == true)
            {
                foreach (string filename in openFileDialog.FileNames)
                    lbFiles.Items.Add(filename);
            }
        }
    }
}
