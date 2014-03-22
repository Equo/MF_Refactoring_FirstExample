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
        private Price price;

        public Movie(string title, int priceCode)
        {
            this.title = title;
            PriceCode = priceCode;
        }

        public int PriceCode
        {
            get { return price.GetPriceCode(); }
            set 
            {
                switch (value)
                {
                    case Regular:
                        price = new RegularPrice();
                        break;
                    case Childrens:
                        price = new ChildrensPrice();
                        break;
                    case NewRelease:
                        price = new NewReleasePrice();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        public string Title
        {
            get { return title; }
        }

        public double GetCharge(int daysRented)
        {
            return price.GetCharge(daysRented);
        }

        public int GetFrequentRenterPoints(int daysRented)
        {
            return price.GetFrequentRenterPoints(daysRented);
        }
    }

    public abstract class Price
    {
        abstract public int GetPriceCode();

        abstract public double GetCharge(int daysRented);

        virtual public int GetFrequentRenterPoints(int daysRented)
        {
            return 1;
        }
    }

    public class ChildrensPrice : Price
    {
        override public int GetPriceCode()
        {
            return Movie.Childrens;
        }

        override public double GetCharge(int daysRented)
        {
            double result = 1.5;
            if (daysRented > 3)
            {
                result += (daysRented - 3) * 1.5;
            }
            return result;
        }
    }

    public class NewReleasePrice : Price
    {
        override public int GetPriceCode()
        {
            return Movie.NewRelease;
        }

        override public double GetCharge(int daysRented)
        {
            return daysRented * 3;
        }

        override public int GetFrequentRenterPoints(int daysRented)
        {
            // Give bonus points if rented "new release" over two days
            return daysRented > 1
                ? 2
                : 1;
        }
    }

    public class RegularPrice : Price
    {
        override public int GetPriceCode()
        {
            return Movie.Regular;
        }

        override public double GetCharge(int daysRented)
        {
            double result = 2;
            if (daysRented > 2)
            {
                result += (daysRented - 2) * 1.5;
            }

            return result;
        }
    }
}
