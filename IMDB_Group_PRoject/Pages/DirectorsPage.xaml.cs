using IMDB.Data;
using IMDB.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace IMDB_Group_PRoject.Pages
{
    /// <summary>
    /// Interaction logic for DirectorsPage.xaml
    /// </summary>
    public partial class DirectorsPage : Page
    {
        private readonly ImdbProjectContext _context = new ImdbProjectContext();

        public DirectorsPage()
        {
            InitializeComponent();

            RunQuery("");
        }

        public void RunQuery(string text)
        {
            string searchTerm = text;

            var query =
                from Name in _context.Names
                where Name.PrimaryName.Contains(searchTerm) && Name.PrimaryProfession.Contains("director")
                select Name;

            var directorViewSource = (CollectionViewSource)FindResource("directorViewSource");
            directorsListView.ItemsSource = new ObservableCollection<Name>(query.ToList());
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            RunQuery(txtSearch.Text);
        }

  

    }
}
