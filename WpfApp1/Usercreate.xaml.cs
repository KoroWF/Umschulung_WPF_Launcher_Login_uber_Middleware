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
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaktionslogik für Usercreate.xaml
    /// </summary>
    /// 

    public partial class Usercreate : Window
    {
        public Usercreate()
        {
            InitializeComponent();
        }

        private void Erstellen_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Abbrechen_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
