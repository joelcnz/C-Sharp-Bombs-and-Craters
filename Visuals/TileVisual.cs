using System;
using Microsoft.Xna.Framework.Graphics;

namespace WindowsGame1.Visuals
{
    public class TileVisual
    {
        private Texture2D visual;

        public TileVisual(Texture2D visual)
        {
            if (visual == null) throw new ArgumentNullException("visual");
            this.visual = visual;
        }

        public Texture2D Visual
        {
            get { return visual; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("value");
                }

                visual = value;
            }
        }

        public int Width { get { return Visual.Width; } }

        public int Height { get { return Visual.Height; } }
    }
}