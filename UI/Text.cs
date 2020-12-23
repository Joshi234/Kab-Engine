
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game1.UI
{
    public class Text
    {
        public SpriteFont font;
        public string text;
        public Vector2 position;
        public Color color;
        public Text(SpriteFont _font,string _text, Vector2 _Position) {
            font = _font;
            text = _text;
            position = _Position;
        }
    }
}
