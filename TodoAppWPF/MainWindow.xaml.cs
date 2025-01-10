using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TodoAppWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private TodoList _todoList;
        public MainWindow()
        {
            InitializeComponent();
            _todoList = new TodoList();
        }

       /// <summary>
       /// Tar bort valt todo-item.
       /// </summary>
       /// <param name="sender"> sender från main window</param>
       /// <param name="e"></param>
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            string task = TaskTextBox.Text;
            if (!string.IsNullOrEmpty(task))
            {
                _todoList.AddTask(task);
                UpdateTaskList();
                TaskTextBox.Clear();
            }
        }
        //<summary>
        //uppdaterar listan med todo-items
        //</summary>
        private void UpdateTaskList()
        {
            TasksListBox.Items.Clear();
            foreach (var task in _todoList.GetAllTasks())
            {
                TasksListBox.Items.Add(task);
            }
        }
        /// <summary>
        /// tar bort todo items
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            if(TasksListBox.SelectedIndex >= 0)
            {
                _todoList.RemoveTask(TasksListBox.SelectedIndex);
                UpdateTaskList();
            }
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)  //min egna
        {
            if(TasksListBox.SelectedIndex >= 0)
            {
                int selectedIndex = TasksListBox.SelectedIndex;
                string newTask = TaskTextBox.Text;
          
                 _todoList.EditTask(selectedIndex, newTask);
                TasksListBox.Items[selectedIndex] = newTask;

                if (string.IsNullOrEmpty(newTask))
                {
                    TaskTextBox.Text = "Markera tasken o ändra texten här tryck sedan redigera igen.";
                }
                else
                {
                    TaskTextBox.Clear();
                }


            }
        }
    }
}