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
    /// Interaction logic for CategoriesPage.xaml
    /// </summary>
    public partial class CategoriesPage : Page
    {
        private readonly ImdbProjectContext _context = new ImdbProjectContext();

        public CategoriesPage()
        {
            InitializeComponent();

            _context.Titles.Load();


        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            var query =
                from title in _context.Titles
                where title.PrimaryTitle.Contains(txtSearch.Text)
                group title by title.Genres into newGroup
                select new
                {
                    Index = newGroup.Key
                    
                };

            categoriesListView.ItemsSource = query.ToList();
        }
    }
}
