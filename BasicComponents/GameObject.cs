
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Game1.BasicComponents
{
    public class GameObject
    {
        public Vector2 Position { get;set; }
        public Texture2D Texture { get; set; }
        public Size2D Size { get; set; }
        public Vector2 Velocity { get; set; }
        public bool isCollider { get; set; }
        public bool isStatic { get; set; }
        public float bounciness = 0f;
        public float rotation;
        public SpriteEffects effect;
        public event OnCollisionEventHandler onCollision;
        public GameObject(Vector2 position, Texture2D texture, Size2D size = null, bool Static=true, SpriteEffects Effect = SpriteEffects.None)
        {
            Position = position;
            Texture = texture;
            Size = size;
            isStatic = Static;
            effect = Effect;
        }
        public void AddVelocity(Vector2 velocity)
        {
            Velocity += velocity;
        }
        public delegate void OnCollisionEventHandler();
        public virtual void OnCollision()
        {
            onCollision?.Invoke();
        }
        }
}
