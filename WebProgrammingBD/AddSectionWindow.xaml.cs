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
    /// Логика взаимодействия для AddSectionWindow.xaml
    /// </summary>
    public partial class AddSectionWindow : Window
    {
        private AssignmentDbContext _context = new AssignmentDbContext();

        public AddSectionWindow()
        {
            InitializeComponent();
        }

        private void AddSectionInBD_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NameSection.Text))
            {
                Section section = new Section();
                section.Name = NameSection.Text;
                _context.Sections.Add(section);
                _context.SaveChanges();
                Close();
            }
            else
                MessageBox.Show("Name is null!");
        }
    }
}
