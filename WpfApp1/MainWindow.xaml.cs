using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
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
using Model;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            List<Nutzer> list = BenutzerServiceClient.getAllAsync().Result;
            DatabaseConverter converter = new DatabaseConverter();
            //DataTable gridnutzer = converter.ToDataTable();
            gridNutzer.DataContext = list;
        }

        private void B_Login_Click(object sender, RoutedEventArgs e)
        {
            var token = BenutzerServiceClient.connectAsync(idbox.Text, pwbox.Password).Result;

            if (token.admin)
            {
                tab1.Visibility = Visibility.Hidden;
                tab2.Visibility = Visibility.Hidden;
                Maincontroller.SelectedIndex = 2;
                tab3.Visibility = Visibility.Visible;
                SideAdmin.Visibility = Visibility.Visible;
                Logout.Visibility = Visibility.Visible;

                pwbox.Password = "";
                idbox.Text = "";

                Aname.Text = token.userNname;
                Avorname.Text = token.userAname;
                AID.Text = token.IDname;
            }
            else if(idbox.Text == "" && pwbox.Password.Length == 0)
            {
                errortext.Visibility = Visibility.Visible;
                errortext.Content = "Bitte geben Sie Ihre ID und Ihr Password ein bevor sie auf Login klicken!";
            }
            else if (token != null)
            {

                tab1.Visibility = Visibility.Hidden;
                Maincontroller.SelectedIndex = 1;
                tab2.Visibility = Visibility.Visible;
                SideProfil.Visibility = Visibility.Visible;
                Logout.Visibility = Visibility.Visible;

                pwbox.Password = "";
                idbox.Text = "";

                Pname.Text = token.userNname;
                Pvorname.Text = token.userAname;
                PID.Text = token.IDname;
            }


        }

        private void B_Neu_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void B_Suche_Click(object sender, RoutedEventArgs e)
        {
            switch(b)
            if(SucheID = true && )
            if
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            tab3.Visibility = Visibility.Hidden;
            tab2.Visibility = Visibility.Hidden;
            Maincontroller.SelectedIndex = 0;
            tab1.Visibility = Visibility.Visible;
            Logout.Visibility = Visibility.Hidden;
            SideProfil.Visibility= Visibility.Hidden;
            SideAdmin.Visibility= Visibility.Hidden;
        }

        private void CloseProgramm_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void SideProfil_Click(object sender, RoutedEventArgs e)
        {
            Maincontroller.SelectedIndex = 1;
        }

        private void SideAdmin_Click(object sender, RoutedEventArgs e)
        {
            Maincontroller.SelectedIndex = 2;
        }
    }
}
