using System.Collections.Generic;

namespace WindowsGame1.Model
{
    public class RowOfTiles
    {
        private readonly IList<Tile> tiles = new List<Tile>();

        public IEnumerable<Tile> Tiles
        {
            get { return tiles; }
        }

        public void AddTile(Tile tile)
        {
            tiles.Add(tile);
        }
    }
}