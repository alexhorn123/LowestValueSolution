using System.Collections.Generic;
using Xunit;
using LowestValueApp;   // <-- important

namespace LowestValueApp.Tests
{
    public class ValueFinderTests
    {
        private readonly ValueFinder _finder = new ValueFinder();

        [Fact]
        public void GetLowestValue_WithValidList_ReturnsLowest()
        {
            var numbers = new List<int> { 42, 7, 19, -3, 88 };
            int result = _finder.GetLowestValue(numbers);
            Assert.Equal(-3, result);
        }

        [Fact]
        public void GetLowestValue_WithSingleElement_ReturnsThatElement()
        {
            var numbers = new List<int> { 99 };
            int result = _finder.GetLowestValue(numbers);
            Assert.Equal(99, result);
        }

        [Fact]
        public void GetLowestValue_WithEmptyList_ThrowsArgumentException()
        {
            var numbers = new List<int>();
            Assert.Throws<ArgumentException>(() => _finder.GetLowestValue(numbers));
        }

        [Fact]
        public void GetLowestValue_WithNullList_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => _finder.GetLowestValue(null));
        }

        [Fact]
        public void GetLowestValue_WithLargeList_ReturnsLowest()
        {
            var numbers = new List<int>();
            for (int i = 0; i < 1000000; i++)
            {
                numbers.Add(i);
            }
            int result = _finder.GetLowestValue(numbers);
            Assert.Equal(0, result);
        }
    }
}
