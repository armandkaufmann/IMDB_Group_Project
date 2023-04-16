using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMDB.Models
{
    public partial class Name
    {

        public string FormattedYears
        {
            get
            {
                if (BirthYear == null)
                {
                    return "Birth/Death Data unavailable";
                }
                else if(DeathYear == null)
                {
                    return $"{BirthYear} - Present";
                } 
                else
                {
                    return $"{BirthYear} - {DeathYear}";
                }
            }
        }
    }
}
