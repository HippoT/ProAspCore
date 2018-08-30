using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EssentialCSharpFeatures.Models
{
    public static class MyExtensionMethods
    {
        public static decimal TotalPrice(this IEnumerable<Product> cartParam)
        {
            decimal total = 0;
            foreach (Product p in cartParam)
            {
                total += p?.Price ?? 0;
            }
            return total;
        }

        public static IEnumerable<Product> FilterPrice(this IEnumerable<Product> cartParam, decimal minPrice)
        {
            foreach(Product p in cartParam)
            {
                if((p?.Price?? 0) >= minPrice)
                {
                    yield return p;
                }
            }
        }

        public static IEnumerable<Product> FilterByName(this IEnumerable<Product> cartParam, char firstLetter)
        {
            foreach (Product p in cartParam)
            {
                if ((p?.Name?[0]) == firstLetter)
                {
                    yield return p;
                }
            }
        }

        public static IEnumerable<Product> Filter(this IEnumerable<Product> cartParam, Func<Product, bool> selector)
        {
            foreach (Product p in cartParam)
            {
                if (selector(p))
                {
                    yield return p;
                }
            }
        }
    }
}
