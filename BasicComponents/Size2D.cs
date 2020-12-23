using System;
using System.Collections.Generic;
using System.Text;

namespace Game1.BasicComponents
{
    public class Size2D
    {
        public float Height { get; set; }
        public float Width { get; set; }
        public Size2D(float width, float height)
        {
            Height = height;
            Width = width;
        }
    }
}
