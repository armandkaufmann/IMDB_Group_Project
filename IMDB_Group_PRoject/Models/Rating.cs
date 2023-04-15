using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMDB.Models
{
    public partial class Rating
    {
        public string Fmt_Rating
        {
            get
            {
                if (AverageRating == null)
                {
                    return "No Rating";
                }
                else
                {
                    return $"Rating: {AverageRating:0.0} / 10";
                }

            }
        }
    }
}
