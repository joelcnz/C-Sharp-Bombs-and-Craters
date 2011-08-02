using System;
using System.Collections.Generic;

namespace WindowsGame1.Model
{
    public class TileLayoutBuilder
    {
        private readonly Random random;
        private const int Width = 30;
        private const int Height = 20;

        public TileLayoutBuilder()
        {
            random = new Random();
        }

        public TileLayout GetInitialLayout()
        {
            var tileLayout = new TileLayout();

            for (var i = 0; i < Width; i++)
            {
                var row = new List<Tile>();
                for (var c = 0; c < Height; c++)
                {
                    switch( random.Next() % 4 ) {
                        case 0:
                            row.Add(new Tile( TileType.Blank ) );
                        break;
                        case 1:
                            row.Add(new Tile( TileType.block ) );
                        break;
                        case 2:
                            row.Add(new Tile( TileType.bomb ) );
                        break;
                        case 3:
                            row.Add(new Tile( TileType.spikes ) );
                        break;
                    }
                    /*
                    if (random.Next() % 4 == 0)
                    {
                        row.Add(new Tile(TileType.Scribble));
                    }
                    else
                    {
                        row.Add(new Tile(TileType.Blank));
                    }
                     */
                }

                tileLayout.AddRow(row);
            }

            return tileLayout;
        }
    }
}