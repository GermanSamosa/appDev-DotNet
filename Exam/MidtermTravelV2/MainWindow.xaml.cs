using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace MidtermTravelV2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public VacationDbContext db = new VacationDbContext();
        List<Trip> exportTrips = new List<Trip>();

        public MainWindow()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                lvTrips.ItemsSource = db.Trips.ToList();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(this, "Unable to access the database:\n" + ex.Message, "Database error", MessageBoxButton.OK, MessageBoxImage.Error);
                Environment.Exit(1); //whats the point if db isnt working lol
            }
        }
        private void ResetFields()
        {
            TxtBxName.Text = "";
            TxtBxDest.Text = "";
            TxtBxPass.Text = "";
            LbErr.Content = "";
            DpDepart.SelectedDate = null;
            DpReturn.SelectedDate = null;
        }

        private void Btn_Export_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text file (*.txt)|*.txt|All files (*.*)|*.*";
            try
            {
                List<string> lines = new List<string>();

                if (saveFileDialog.ShowDialog() != true) return; //cancel it
                foreach(Trip t in exportTrips)
                {
                    lines.Add($"{t.Name};{t.PassportNo};{t.Destination};{t.Departure};{t.Return}");
                }
                File.WriteAllLines(saveFileDialog.FileName, lines);
                MessageBox.Show("Export Complete.");
            }
            catch (Exception ex) when (ex is IOException || ex is SystemException)
            {
                MessageBox.Show("export failed.", ex.Message);
            }
        }

        private void Btn_Add_Click(object sender, RoutedEventArgs e)
        {
            
            try
            {
                string name = TxtBxName.Text;
                string dest = TxtBxDest.Text;
                string pass = TxtBxPass.Text;
                DateTime depa = (DateTime)DpDepart.SelectedDate; //TODO error handle null dates
                DateTime retu = (DateTime)DpReturn.SelectedDate;
                if(name.Length < 2 || name.Length > 30 || dest.Length < 2 || dest.Length > 30 || pass.Length > 8)
                {
                    LbErr.Content = "Name and Destination must be at least 2 characters to a limit of 30";
                    return;
                }
                else
                {
                    db.Trips.Add(new Trip()
                    {
                        Name = name,
                        PassportNo = pass,
                        Destination = dest,
                        Departure = depa,
                        Return = retu
                    });
                }
            }
            catch (ArgumentOutOfRangeException ex) //exception handleling not going well 
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                
                db.SaveChanges();
                lvTrips.ItemsSource = db.Trips.ToList();
                ResetFields();
            }
        }

        private void Btn_Update_Click(object sender, RoutedEventArgs e)
        {
            Trip currSelTrip = lvTrips.SelectedItem as Trip;
            if (currSelTrip == null)
            {
                return;
            }
            try
            {
                currSelTrip.Name = TxtBxName.Text;
                currSelTrip.PassportNo = TxtBxPass.Text;
                currSelTrip.Destination = TxtBxDest.Text;
                currSelTrip.Departure = (DateTime)DpDepart.SelectedDate;
                currSelTrip.Return = (DateTime)DpReturn.SelectedDate;
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(this, ex.Message, "Input error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            catch (SystemException ex)
            {
                MessageBox.Show(this, "Unable to access the database:\n" + ex.Message, "Database error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                db.SaveChanges();
                lvTrips.ItemsSource = db.Trips.ToList();
                ResetFields();
            }
        }

        private void Btn_Delete_Click(object sender, RoutedEventArgs e)
        {
            Trip currSelTrip = lvTrips.SelectedItem as Trip;
            //List<Trip> multiSelectTrips = new List<Trip>(); must create way to delete multiples

            if(currSelTrip == null)
            {
                return;
            }
            var result = MessageBox.Show(this, "Are you sure you want to delete this item?", "Confirm deletion", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.No) return;
            try
            {
                foreach (Trip t in lvTrips.SelectedItems)//YESSIR DELETES ALL SELECTED!!!
                {
                    db.Trips.Remove(t);
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(this, "Unable to access the database:\n" + ex.Message, "Database error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                db.SaveChanges();
                lvTrips.ItemsSource = db.Trips.ToList();
                ResetFields();
            }
        }

        private void lvTrips_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Trip currSelTrip = lvTrips.SelectedItem as Trip;
            //List<Trip> multiSelTrip = new List<Trip>(); //this will create a list with our selected trips
            //Btn_Delete.IsEnabled = currSelTrip != null;
            //Btn_Update.IsEnabled = currSelTrip != null;
            //Btn_Export.IsEnabled = currSelTrip != null;
            if (currSelTrip == null)
            {
                ResetFields();
                exportTrips.Clear(); //clear when unselected //does not work as expect but somewhat does
            }
            else
            {
                TxtBxName.Text = currSelTrip.Name;
                TxtBxPass.Text = currSelTrip.PassportNo;
                TxtBxDest.Text = currSelTrip.Destination;
                DpDepart.SelectedDate = currSelTrip.Departure;
                DpReturn.SelectedDate = currSelTrip.Return;

                foreach(Trip t in lvTrips.SelectedItems)
                {
                    if (!t.Id.Equals(currSelTrip.Id))//will this stop duplicates?
                    {
                        exportTrips.Add(t); 
                    }
                    
                }
            }
            
        }
    }
}
