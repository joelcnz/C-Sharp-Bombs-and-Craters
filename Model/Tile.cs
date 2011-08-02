namespace WindowsGame1.Model
{
    public class Tile
    {
        public Tile(TileType tileType)
        {
            TileType = tileType;
        }

        public TileType TileType
        {
            get;
            set;
        }
    }
}