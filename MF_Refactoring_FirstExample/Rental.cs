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
            double result = 0;

            switch (Movie.PriceCode)
            {
                case Movie.Regular:
                    result += 2;
                    if (DaysRented > 2)
                    {
                        result += (DaysRented - 2) * 1.5;
                    }
                    break;
                case Movie.NewRelease:
                    result += DaysRented * 3;
                    break;
                case Movie.Childrens:
                    result += 1.5;
                    if (DaysRented > 3)
                    {
                        result += (DaysRented - 3) * 1.5;
                    }
                    break;
            }

            return result;
        }

        public int GetFrequentRenterPoints()
        {
            // Give bonus points if rented "new release" over two days
            if (Movie.PriceCode == Movie.NewRelease && 
                DaysRented > 1)
            {
                return 2;
            }
            else
            {
                return 1;
            }
        }
    }
}
