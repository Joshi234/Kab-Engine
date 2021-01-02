using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Game1.BasicComponents;
using Game1.UI;
namespace Game1
{
    public partial class Game1
    {
        Texture2D xbox;
        Texture2D block;
        GameObject gameObject;
 
        private GameObject roehre1;
        private GameObject roehre2;
        private float roehrenSpeed = 0.2f;
        private readonly Random _random = new Random();
        private Text text;
        private bool isPlaying = false;
        private bool isDead = false;
        SpriteFont font;
        public void CollisionEnter()
        {
            if (isDead == false)
            {
                renderer.RegisterNewTextToRender(text);
                isPlaying = false;
                isDead = true;
            }
        }
        protected  void OnLoad()
        {
            //Gets called when the games load
   

             font = Content.Load<SpriteFont>("Text");
            //Texture2D roehreSprite = Content.Load<Texture2D>("roehre");
            //float roehreRandom = _random.Next(-75, 75);
            //roehre1 = new GameObject(new Vector2(1000f, roehreRandom + 850F), roehreSprite, new Size2D(300f, 600f));
             text = new Text(font, "0", new Vector2(0f, 0f));
            renderer.RegisterNewTextToRender(text);
            Texture2D dirt_block = Content.Load<Texture2D>("dirt_block");
            for(int y= 0; y < 1; y++) { 
            for(int i = 0; i < 100; i++)
            {
                    gameObject = new GameObject(new Vector2(32f * i, 0f + (32f * y)), dirt_block, new Size2D(32f, 32f));
                    gameObject.isStatic = false;
                    physicsEngine.AddNewPhysicsObject(gameObject);
                    renderer.RegisterNewGameObjectToRender(gameObject);
            }
            }
        }

        protected void UpdateLogic()
        {
            renderer.RemoveText(text);
            text = new Text(font, gameObject.Position.Y.ToString(), new Vector2(0f, 0f));
            renderer.RegisterNewTextToRender(text);


        }
    }
}
