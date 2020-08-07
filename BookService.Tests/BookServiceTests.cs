using Book.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Book.UnitTests.Services
{
    public class BookService_GetPriceShould
    {
        private readonly BookService _bookService;

        public BookService_GetPriceShould()
        {
            _bookService = new BookService();
        }

        [Fact]
        public void GetPrice_InputIsNull_ReturnArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => _bookService.GetPrice(null));
        }
  
 
        [Theory]
        [InlineData(new int[]{})]
        [InlineData(new int[]{0,1,2,3,4,5,6})]
        public void GetPrice_InputIsEmpty_ReturnArgumentOutOfRangeException(int[] value)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => _bookService.GetPrice(value));
        }
 
        [Theory]
        [InlineData(new int[]{1}, 8)]
        [InlineData(new int[]{1,2}, 15.2)]
        [InlineData(new int[]{1,2,3}, 21.6)]
        [InlineData(new int[]{1,2,3,4}, 25.6)]
        [InlineData(new int[]{1,2,3,4,5}, 30)]
        [InlineData(new int[]{1,1,1,1,1}, 40)]
        [InlineData(new int[]{  1,1,1,1,1,
                                2,2,2,2,2,
                                3,3,3,3,3,
                                4,4,4,4,
                                5,5,5,5	    }, 141.2)]
        public void GetPrice_InputIsCorrect_ReturnCorrectPrice(int[] value, double expected)
        {
            var result = _bookService.GetPrice(value);
            Assert.True(result == expected, $"GetPrice {result}");
        }   
   }
}
