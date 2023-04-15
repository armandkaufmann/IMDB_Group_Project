using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMDB.Models
{
    public partial class Title
    {
        public string Fmt_Title
        {
            get
            {
                if (PrimaryTitle == null)
                {
                    return "";
                }
                else
                {
                    return PrimaryTitle;
                }

            }
        }

        public string Fmt_Year
        {
            get
            {
                if (StartYear == null)
                {
                    return "Year: N\\A";
                }
                else
                {
                    return $"Year: {StartYear}";
                }
            }
        }

        public string Fmt_RunTime
        {
            get
            {
                if (RuntimeMinutes == null)
                {
                    return "N\\A minutes";
                }
                else
                {
                    return $"{RuntimeMinutes} minutes";
                }
            }
        }

        public string Fmt_Rating
        {
            get
            {
                if (Rating == null)
                {
                    return "No Rating";
                }
                else
                {
                    return $"Rating: {Rating.AverageRating:.2f}";
                }
            }
        }
    }
}
