using IMDB.Data;
using Microsoft.EntityFrameworkCore;
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

namespace IMDB_Group_PRoject.Pages
{
    /// <summary>
    /// Interaction logic for DirectorsPage.xaml
    /// </summary>
    public partial class DirectorsPage : Page
    {
        private ImdbProjectContext _context = new ImdbProjectContext();
        private CollectionViewSource directorsViewSource;

        public DirectorsPage()
        {
            InitializeComponent();
            directorsViewSource = (CollectionViewSource)FindResource(nameof(directorsViewSource));

        }

        private async void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new ImdbProjectContext())
            {
                var searchTerm = txtSearch.Text.Trim();
                var directors = await context.Names
                    .Where(name => name.PrimaryProfession.Contains("director"))
                    .Where(name => string.IsNullOrEmpty(searchTerm) || name.PrimaryName.Contains(searchTerm))
                    .ToListAsync();
                directorsListView.ItemsSource = directors;
            }
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            using (var context = new ImdbProjectContext())
            {
                await context.Names.LoadAsync();
                var directors = context.Names.Local
                    .Where(name => name.PrimaryProfession.Contains("director"))
                    .ToList();
                directorsListView.ItemsSource = directors;
            }
        }

    }
}
