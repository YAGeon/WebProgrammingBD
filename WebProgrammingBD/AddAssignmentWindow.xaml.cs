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
    /// Логика взаимодействия для AddAssignmentWindow.xaml
    /// </summary>
    public partial class AddAssignmentWindow : Window
    {
        private AssignmentDbContext _context = new AssignmentDbContext();

        public AddAssignmentWindow()
        {
            InitializeComponent();
        }

        private void AddAssigment_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(JobName.Text) && string.IsNullOrWhiteSpace(JobDescription.Text) && SectionBox.SelectedItem != null)
            {
                Assignment assignment = new Assignment();
                assignment.Title = JobName.Text;
                assignment.Description = JobDescription.Text;
                assignment.SectionId = SectionBox.SelectedIndex;
                _context.Assignments.Add(assignment);
                _context.SaveChanges();
                Close();
            }
            else
                MessageBox.Show("Not all data has been entered!");
        }
    }
}
