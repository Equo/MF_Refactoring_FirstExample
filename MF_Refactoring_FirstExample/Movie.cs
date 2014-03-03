using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MF_Refactoring_FirstExample
{
    class Movie
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
    }
}
