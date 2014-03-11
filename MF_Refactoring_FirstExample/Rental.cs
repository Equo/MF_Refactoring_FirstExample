using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MF_Refactoring_FirstExample
{
    public class Rental
    {
        private Movie movie;
        private int daysRented;

        public Rental(Movie movie, int daysRented)
        {
            this.movie = movie;
            this.daysRented = daysRented;
        }

        public int DaysRented
        {
            get { return daysRented; }
        }

        public Movie Movie
        {
            get { return movie; }
        }

        public double GetCharge()
        {
            return Movie.GetCharge(DaysRented);
        }

        public int GetFrequentRenterPoints()
        {
            return Movie.GetFrequentRenterPoints(daysRented);
        }
    }
}
