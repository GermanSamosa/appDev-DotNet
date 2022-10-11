using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Security.Policy;
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

namespace Day05TodosEF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const string filePath = @"..\..\data.txt";
        public MainWindow()
        {
            InitializeComponent();
        }
        private int EnumConv(string status)
        {
            if (status != null)
            {
                switch (status)
                {
                    case "Pending": return 0;
                    case "Done": return 1;
                    case "Delegated": return 2;
                    default:break;
                }
            }
            MessageBox.Show("error converting status");
            return 99;
           
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                TodoDbContext ctx = new TodoDbContext();
                LvTodoList.ItemsSource = ctx.TodoList.ToList();

                CbxPending.Content = Todo.StatusEnum.Pending;
                CbxDone.Content = Todo.StatusEnum.Done;
                CbxDelegated.Content = Todo.StatusEnum.Delegated;
                Todo exTask = new Todo
                {
                    Task = "Finish my homework",
                    Difficulty = 3,
                    DueDate = DateTime.Now,
                    Status = (Todo.StatusEnum)2
                };

                ctx.TodoList.Add(exTask);
                ctx.SaveChanges();
                
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(this, "Unable to access the database:\n" + ex.Message, "Database error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string task = TaskTxtBox.Text;
                int difficulty = (int)DiffSlider.Value;
                DateTime dueDate = (DateTime)DueDatePick.SelectedDate;
                string status = ComboStatus.Text;
                //int number = 2;
                string error = "";


                if (Todo.IsTaskValid(task, out error) || Todo.IsDatePickerValid(dueDate, out error))
                {
                    TodoDbContext ctx = new TodoDbContext();
                    ctx.TodoList.Add(new Todo() 
                    { 
                        Task = task,
                        Difficulty = difficulty,
                        DueDate = dueDate,
                        Status = (Todo.StatusEnum)EnumConv(status) //UNFINISHED

                    });
                    ctx.SaveChanges();
                    LvTodoList.ItemsSource = ctx.TodoList.ToList();
                }
                else
                {
                    MessageBox.Show(error);
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(this, "Unable to access the database:\n" + ex.Message, "Database error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                
                ResetFields();
                LvTodoList.SelectedItem = null;
            }
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            //fetch for the object first, than order deletion
            TodoDbContext ctx = new TodoDbContext();

            Todo currSelTodo = LvTodoList.SelectedItem as Todo;
            if(currSelTodo == null)
            {
                return;
            }
            //very nice feature down below
            var result = MessageBox.Show(this, "Are you sure you want to delete this item?", "Confirm deletion", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result != MessageBoxResult.Yes) return;
            try
            {
                ctx.TodoList.Remove(currSelTodo);
                
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(this, "Unable to access the database:\n" + ex.Message, "Database error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                ctx.SaveChanges();
                LvTodoList.ItemsSource = ctx.TodoList.ToList();
                ResetFields();
            }
        }

        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            //fetch for the object first, than order deletion, than new one? dunno
        }
        private void ResetFields()
        {
            TaskTxtBox.Text = "";
            DiffSlider.Value = 1;
            DueDatePick.SelectedDate = null;
        }

        private void TodoList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Todo currSelTodo = LvTodoList.SelectedItem as Todo;
            UpdateBtn.IsEnabled = currSelTodo != null;
            DeleteBtn.IsEnabled = currSelTodo != null;
            string status = ComboStatus.Text;
            if (currSelTodo == null)
            {
                ResetFields();
            }
            
            else
            {

                TaskTxtBox.Text = currSelTodo.Task;
                DiffSlider.Value = currSelTodo.Difficulty;
                DueDatePick.SelectedDate = currSelTodo.DueDate;
                //ComboStatus.SelectedItem = currSelTodo.Status;
            }
            

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            List<string> lines = new List<string>();
            try
            {
                if (!File.Exists(filePath)) return;
                
                foreach (Todo t in LvTodoList.ItemsSource)
                {
                    lines.Add($"{t.Task};{t.Difficulty};{t.DueDate};{t.Status}");
                }
                File.WriteAllLines(filePath, lines);
            }
            catch (Exception ex) when (ex is IOException || ex is SystemException)
            {
                MessageBox.Show(this, "Error writing to file\n" + ex.Message, "File access error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                ResetFields();
            }
        }
    }
}
