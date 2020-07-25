using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace ConstructionLine.CodingChallenge.Tests
{
    [TestFixture]
    public class SearchEngineTests : SearchEngineTestsBase
    {
        [Test]
        public void Test()
        {
            var shirts = new List<Shirt> {
                new Shirt (Guid.NewGuid (), "Red - Small", Size.Small, Color.Red),
                new Shirt (Guid.NewGuid (), "Black - Medium", Size.Medium, Color.Black),
                new Shirt (Guid.NewGuid (), "Blue - Large", Size.Large, Color.Blue),
                new Shirt (Guid.NewGuid (), "Red - Medium", Size.Medium, Color.Red),
            };

            var searchEngine = new SearchEngine(shirts);

            var searchOptions = new SearchOptions
            {
                Colors = new List<Color> { Color.Red },
                Sizes = new List<Size> { Size.Small }
            };

            var results = searchEngine.Search(searchOptions);

            AssertResults(results.Shirts, searchOptions);
            AssertSizeCounts(shirts, searchOptions, results.SizeCounts);
            AssertColorCounts(shirts, searchOptions, results.ColorCounts);
        }

        [Test]
        public void Test_Shirt_Option_All_Color()
        {
            var shirts = new List<Shirt> {
                new Shirt (Guid.NewGuid (), "Red - Small", Size.Small, Color.Red),
                new Shirt (Guid.NewGuid (), "Red - Large", Size.Large, Color.Red),
                new Shirt (Guid.NewGuid (), "Black - Medium", Size.Medium, Color.Black),
                new Shirt (Guid.NewGuid (), "Black - Medium", Size.Medium, Color.Black)
            };

            var searchEngine = new SearchEngine(shirts);

            var searchOptions = new SearchOptions
            {
                Colors = Color.All
            };

            var results = searchEngine.Search(searchOptions);

            AssertResults(results.Shirts, searchOptions);
            AssertSizeCounts(shirts, searchOptions, results.SizeCounts);
            AssertColorCounts(shirts, searchOptions, results.ColorCounts);
        }

        [Test]
        public void Test_Shirt_Option_All_Size()
        {
            var shirts = new List<Shirt> {
                new Shirt (Guid.NewGuid (), "Red - Small", Size.Small, Color.Red),
                new Shirt (Guid.NewGuid (), "Red - Large", Size.Large, Color.Red),
                new Shirt (Guid.NewGuid (), "Black - Medium", Size.Medium, Color.Black),
                new Shirt (Guid.NewGuid (), "Black - Medium", Size.Medium, Color.Black)
            };

            var searchEngine = new SearchEngine(shirts);

            var searchOptions = new SearchOptions
            {
                Sizes = Size.All
            };

            var results = searchEngine.Search(searchOptions);

            AssertResults(results.Shirts, searchOptions);
            AssertSizeCounts(shirts, searchOptions, results.SizeCounts);
            AssertColorCounts(shirts, searchOptions, results.ColorCounts);
        }

        [Test]
        public void Test_Shirt_Option_None()
        {
            var shirts = new List<Shirt> {
                new Shirt (Guid.NewGuid (), "Red - Small", Size.Small, Color.Red),
                new Shirt (Guid.NewGuid (), "Red - Large", Size.Large, Color.Red),
                new Shirt (Guid.NewGuid (), "Black - Medium", Size.Medium, Color.Black),
                new Shirt (Guid.NewGuid (), "Black - Medium", Size.Medium, Color.Black)
            };

            var searchEngine = new SearchEngine(shirts);

            var searchOptions = new SearchOptions {};

            var results = searchEngine.Search(searchOptions);

            AssertResults(results.Shirts, searchOptions);
            AssertSizeCounts(shirts, searchOptions, results.SizeCounts);
            AssertColorCounts(shirts, searchOptions, results.ColorCounts);
        }

        [Test]
        public void Test_Shirt_Option_Missing_Size()
        {
            var shirts = new List<Shirt> {
                new Shirt (Guid.NewGuid (), "Black - Small", Size.Small, Color.Black),
                new Shirt (Guid.NewGuid (), "Red - Small", Size.Small, Color.Red),
                new Shirt (Guid.NewGuid (), "Yellow - Small", Size.Small, Color.Yellow),
                new Shirt (Guid.NewGuid (), "While - Small", Size.Small, Color.White),
                new Shirt (Guid.NewGuid (), "Blue - Small", Size.Small, Color.Blue)
            };

            var searchEngine = new SearchEngine(shirts);

            var searchOptions = new SearchOptions
            {
                Colors = new List<Color> { Color.Red }
            };

            var results = searchEngine.Search(searchOptions);

            AssertResults(results.Shirts, searchOptions);
            AssertSizeCounts(shirts, searchOptions, results.SizeCounts);
            AssertColorCounts(shirts, searchOptions, results.ColorCounts);
        }

       [Test]
        public void Test_Shirt_Option_Missing_Color()
        {
            var shirts = new List<Shirt> {
                new Shirt (Guid.NewGuid (), "Black - Small", Size.Small, Color.Black),
                new Shirt (Guid.NewGuid (), "Red - Small", Size.Small, Color.Red),
                new Shirt (Guid.NewGuid (), "Yellow - Small", Size.Small, Color.Yellow),
                new Shirt (Guid.NewGuid (), "While - Small", Size.Small, Color.White),
                new Shirt (Guid.NewGuid (), "Blue - Small", Size.Small, Color.Blue)
            };

            var searchEngine = new SearchEngine(shirts);

            var searchOptions = new SearchOptions
            {
                Sizes = new List<Size> { Size.Small }
            };

            var results = searchEngine.Search(searchOptions);

            AssertResults(results.Shirts, searchOptions);
            AssertSizeCounts(shirts, searchOptions, results.SizeCounts);
            AssertColorCounts(shirts, searchOptions, results.ColorCounts);
        }

        [Test]
        public void Test_No_Shirts_Option_Size_Color()
        {
            var shirts = new List<Shirt> {};

            var searchEngine = new SearchEngine(shirts);

            var searchOptions = new SearchOptions
            {
                Sizes = new List<Size> { Size.Small },
                Colors = new List<Color> {Color.Black}
            };

            var results = searchEngine.Search(searchOptions);

            AssertResults(results.Shirts, searchOptions);
            AssertSizeCounts(shirts, searchOptions, results.SizeCounts);
            AssertColorCounts(shirts, searchOptions, results.ColorCounts);
        }
    }
}