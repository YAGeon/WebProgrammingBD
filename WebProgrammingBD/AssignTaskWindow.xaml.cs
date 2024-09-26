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

namespace WebProgrammingBD
{
    /// <summary>
    /// Логика взаимодействия для AssignTaskWindow.xaml
    /// </summary>
    public partial class AssignTaskWindow : Window
    {
        private AssignmentDbContext _context = new AssignmentDbContext();

        public AssignTaskWindow()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            StudentComboBox.ItemsSource = _context.Students.ToList();
            AssignmentComboBox.ItemsSource = _context.Assignments.ToList();
        }

        private void Assign_Click(object sender, RoutedEventArgs e)
        {
            var selectedStudent = (Student)StudentComboBox.SelectedItem;
            var selectedAssignment = (Assignment)AssignmentComboBox.SelectedItem;

            if (selectedStudent != null && selectedAssignment != null)
            {
                var record = new CompletionRecord
                {
                    StudentId = selectedStudent.Id,
                    AssignmentId = selectedAssignment.Id,
                    IsCompleted = false
                };

                _context.CompletionRecords.Add(record);
                _context.SaveChanges();

                MessageBox.Show("Задание успешно выполнено!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите студента и задание.");
            }
        }
    }
}
