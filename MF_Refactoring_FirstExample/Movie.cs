using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MF_Refactoring_FirstExample
{
    public class Movie
    {        
        public const int Childrens = 2;
        public const int Regular = 0;
        public const int NewRelease = 1;

        private string title;
        private int priceCode;

        public Movie(string title, int priceCode)
        {
            this.title = title;
            this.priceCode = priceCode;
        }

        public int PriceCode
        {
            get { return priceCode; }
            set { priceCode = value; }
        }

        public string Title
        {
            get { return title; }
        }

        public double GetCharge(int daysRented)
        {
            double result = 0;

            switch (PriceCode)
            {
                case Movie.Regular:
                    result += 2;
                    if (daysRented > 2)
                    {
                        result += (daysRented - 2) * 1.5;
                    }
                    break;
                case Movie.NewRelease:
                    result += daysRented * 3;
                    break;
                case Movie.Childrens:
                    result += 1.5;
                    if (daysRented > 3)
                    {
                        result += (daysRented - 3) * 1.5;
                    }
                    break;
            }

            return result;
        }

        public int GetFrequentRenterPoints(int daystRented)
        {
            // Give bonus points if rented "new release" over two days
            if (PriceCode == Movie.NewRelease &&
                daystRented > 1)
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
