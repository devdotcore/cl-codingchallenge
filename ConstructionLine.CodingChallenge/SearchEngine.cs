using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace ConstructionLine.CodingChallenge
{
    public class SearchEngine
    {
        private readonly IEnumerable<Shirt> _shirts;

        private List<ColorCount> _colorCounts;

        private List<SizeCount> _sizeCounts;

        public SearchEngine(IEnumerable<Shirt> shirts)
        {
            _shirts = shirts;

            // initialise color count list with all colors
            _colorCounts = (from color in Color.All
                            select new ColorCount { Color = color, Count = 0 }).ToList();

            // initialise size count list with all sizes
            _sizeCounts = (from size in Size.All
                           select new SizeCount { Size = size, Count = 0 }).ToList();

        }

        public SearchResults Search(SearchOptions options)
        {
            // find matching shirts from the provided combination of size and color
            var shirts = (from shirt in _shirts
                          where (!options.Colors.Any() || options.Colors.Select(c => c.Id).Contains(shirt.Color.Id)) &&
                          (!options.Sizes.Any() || options.Sizes.Select(c => c.Id).Contains(shirt.Size.Id))
                          select shirt);

            foreach (var shirt in shirts)
            {
                // get SizeCount matching shirt size & increment
                var size = _sizeCounts.SingleOrDefault(x => x.Size.Id == shirt.Size.Id);
                size.Count++;

                // get ColourCount matching shirt color & increment
                var color = _colorCounts.SingleOrDefault(x => x.Color.Id == shirt.Color.Id);
                color.Count++;
            }

            return new SearchResults
            {
                Shirts = shirts.ToList(),
                ColorCounts = _colorCounts,
                SizeCounts = _sizeCounts
            };
        }
    }
}
