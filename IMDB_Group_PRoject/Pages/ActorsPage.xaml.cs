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
    /// Interaction logic for ActorsPage.xaml
    /// </summary>
    public partial class ActorsPage : Page
    {
        private readonly ImdbProjectContext _context = new ImdbProjectContext();

        public ActorsPage()
        {
            InitializeComponent();
            _context.Genres.Load();
            _context.Titles.Load();

            RunQuery("");
        }

        public void RunQuery(string text)
        {
            var query =
                from Name in _context.Names
                where Name.PrimaryName.Contains(text) && Name.PrimaryProfession.Contains("actor")

                select new
                {
                    name = Name.PrimaryName,
                    years = Name.FormattedYears,
                    
                };

            actorsListView.ItemsSource = query.ToList();
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            RunQuery(txtSearch.Text);
        }
    }
}
