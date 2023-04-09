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

namespace IMDB_Group_PRoject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Pages.ActorsPage actorsPage { get; set; }
        public Pages.CategoriesPage categoriesPage { get; set; }
        public Pages.DirectorsPage directorsPage { get; set; }
        public Pages.MoviesPage moviesPage { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            actorsPage= new Pages.ActorsPage();
            categoriesPage= new Pages.CategoriesPage();
            directorsPage= new Pages.DirectorsPage();
            moviesPage= new Pages.MoviesPage();

            mainFrame.NavigationService.Navigate(moviesPage);
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Movies_Page_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.NavigationService.Navigate(moviesPage);
        }

        private void Categories_Page_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.NavigationService.Navigate(categoriesPage);
        }

        private void Actors_Page_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.NavigationService.Navigate(actorsPage);
        }

        private void Directors_Page_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.NavigationService.Navigate(directorsPage);
        }
    }
}
