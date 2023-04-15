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
    /// Interaction logic for MoviesPage.xaml
    /// </summary>
    /// 
    public partial class MoviesPage : Page
    {
        private ImdbProjectContext _context = new ImdbProjectContext();
        private CollectionViewSource moviesViewSource;

        public MoviesPage()
        {
            InitializeComponent();
            moviesViewSource = (CollectionViewSource)FindResource(nameof(moviesViewSource));

            RunQuery("");
        }

        private void RunQuery(string text)
        {
            var query = (
                from movie in _context.Titles
                join rating in _context.Ratings on movie.TitleId equals rating.TitleId
                where movie.TitleType.Equals("movie")
                where movie.PrimaryTitle.Contains(text)
                orderby movie.StartYear ascending
                select new
                {
                    Title = movie.PrimaryTitle,
                    Year = movie.Fmt_Year,
                    RunTime = movie.Fmt_RunTime,
                    AvgRating = rating.Fmt_Rating,
                }).ToList();

            moviesListView.ItemsSource = query;
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            RunQuery(txtSearch.Text);
        }
    }
}
