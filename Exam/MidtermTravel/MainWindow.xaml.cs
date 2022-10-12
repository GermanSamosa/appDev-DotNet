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

namespace MidtermTravel
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            VacationDbContext db = new VacationDbContext();
            lvTrips.ItemsSource = db.Trips.ToList();
            try
            {
                Trip testTrip = new Trip { Name="Matthew", PassportNo = "OK356898", Destination="Barbados", Return = DateTime.Now, Departure = DateTime.Now };
                db.Trips.Add(testTrip);
                db.SaveChanges();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(this, "Unable to access the database:\n" + ex.Message, "Database error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                
            }
        }

        private void Btn_Export_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_Add_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_Update_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_Delete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void lvTrips_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
