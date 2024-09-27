using Microsoft.EntityFrameworkCore;
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

namespace WebProgrammingBD
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private AssignmentDbContext _context = new AssignmentDbContext();

        public MainWindow()
        {
            InitializeComponent();
            LoadSections();
        }

        private void LoadSections()
        {
            SectionList.ItemsSource = _context.Sections.Include(s => s.Assignments).ToList();
        }

        private void SectionList_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (SectionList.SelectedItem is Section selectedSection)
            {
                AssignmentList.ItemsSource = selectedSection.Assignments;
            }
        }

        private void AddSection_Click(object sender, RoutedEventArgs e)
        {
            AddSectionWindow addSectionWindow = new AddSectionWindow();
            addSectionWindow.ShowDialog();
        }

        private void AddAssignment_Click(object sender, RoutedEventArgs e)
        {
            AddAssignmentWindow addAssignmentWindow = new AddAssignmentWindow();
            addAssignmentWindow.ShowDialog();
        }

        private void AddStudent_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}