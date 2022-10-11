using System.Collections.Generic;
using System.Windows;
using System.Windows.Documents;


namespace Day04ListGridViewPeople
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Person> peopleList = new List<Person>();

        public MainWindow()
        {
            InitializeComponent();
            LvPeople.ItemsSource = peopleList;
        }

        private void BtnAddPerson_Click(object sender, RoutedEventArgs e)
        {
            if (!ArePersonInputsValid()) return;
            string name = TbxName.Text;
            int.TryParse(TbxAge.Text, out int age);
            peopleList.Add(new Person(name, age));  
            LvPeople.Items.Refresh();
            ResetFields();
        }

        private void BtnDeletePersone_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnUpdatePerson_Click(object sender, RoutedEventArgs e)
        {
            Person currSelPer = LvPeople.SelectedItem as Person;
        }
       private bool ArePersonInputsValid()
        {
            string name = TbxName.Text;
            if(!Person.IsNameValid(name, out string errorName))
            {
                MessageBox.Show(this, errorName, "Input error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            string strAge = TbxAge.Text;
            if (!Person.IsAgeValid(strAge, out string errorAge))
            {
                MessageBox.Show(this, errorAge, "Input error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }
        private void ResetFields()
        {
            TbxName.Text = "";
            TbxAge.Text = "";
        }
        
    }
}
