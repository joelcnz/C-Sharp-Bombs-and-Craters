using System.Collections.Generic;
using System.Linq;

namespace WindowsGame1.Model
{
    public class TileLayout
    {
        private readonly IList<RowOfTiles> rows;

        public IEnumerable<IEnumerable<Tile>> GetTileMatrix()
        {
            return rows.Select(row => row.Tiles);
        }

        public TileLayout()
        {
            rows = new List<RowOfTiles>();
        }

        public void AddRepeatedRow(Tile tile, int count)
        {
            var row = new RowOfTiles();

            for (var i = 0; i < count; i++)
            {
               row.AddTile(tile); 
            }

            rows.Add(row);
        }

        public void AddRow(IEnumerable<Tile> tiles)
        {
            var row = new RowOfTiles();

            foreach (var tile in tiles)
            {
                row.AddTile(tile);
            }

            rows.Add(row);
        }
    }
}