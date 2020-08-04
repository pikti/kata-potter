using System;
using System.Collections.Generic;
using System.Linq;

namespace Book.Services
{
    public class BookService
    {
        private const double UNIT_PRICE = 8d;
        private static readonly Dictionary<int, double> DISCOUNT = new Dictionary<int, double>
        {
            {1, 1d},
            {2, 0.95d},
            {3, 0.9d},
            {4, 0.8d},
            {5, 0.75d}
        };

        /// <summary>
        /// Get price for books
        /// </summary>
        /// <param name="books">Books are from 1 to 5</param>
        /// <returns></returns>
        public double GetPrice(int[] books)
        {
            if (books == null) 
                throw new ArgumentNullException("books should not be null.");
            
            var listBooks = books.ToList();

            if (listBooks.Count == 0 || listBooks.Any(b => b < 1 || b > 5)) 
                throw new ArgumentOutOfRangeException("books should be between 1 and 5.");
        
            var enu = books.ToList().GetEnumerator();
            var group = new List<List<int>>();
            // Group books for discount
            while (enu.MoveNext())
            {
                if (group.Count == 0 || group.All(b => b.Contains(enu.Current)))
                {
                    group.Add(new List<int>{enu.Current});
                }
                else
                {
                    group.First(b => !b.Contains(enu.Current)).Add(enu.Current);
                }
            }

            var total = 0d;
            group.ForEach(b => total += UNIT_PRICE * b.Count * DISCOUNT[b.Count]);
            return total;
        }
    }
}
