using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MF_Refactoring_FirstExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // declare movies
            var hoge    = new Movie("Hoge",     Movie.Regular);
            var piyo    = new Movie("Piyo",     Movie.Regular);
            var fuga    = new Movie("Fuga",     Movie.NewRelease);
            var hogera  = new Movie("Hogera",   Movie.Childrens);

            // declare customer
            var equo = new Customer("Equo");
            
            // rent movies
            equo.AddRental(new Rental(hoge,     1));
            equo.AddRental(new Rental(piyo,     3));
            equo.AddRental(new Rental(fuga,     2));
            equo.AddRental(new Rental(hogera,   4));

            // output statement
            Console.WriteLine(equo.Statement());
        }
    }
}
