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
        GameObject player;

        private Text text;
        private bool isDead = false;
        SpriteFont font;
        public GameObject[] terrain;
        public void CollisionEnter()
        {

        }
        protected  void OnLoad()
        {
            //Gets called when the games load
   

            font = Content.Load<SpriteFont>("Text");
            Texture2D dirtSprite = Content.Load<Texture2D>("dirt_block");
            Texture2D playerSprite = Content.Load<Texture2D>("xbox");
            //float roehreRandom = _random.Next(-75, 75);
            //roehre1 = new GameObject(new Vector2(1000f, roehreRandom + 850F), roehreSprite, new Size2D(300f, 600f));
            text = new Text(font, "Hello World", new Vector2(0f, 0f));
            renderer.RegisterNewTextToRender(text);
            terrain = new GameObject[30];
            for(int i = 0; i < 30; i++)
            {
                terrain[i] = new GameObject(new Vector2((i * 20)+40, 300), dirtSprite, new Size2D(20, 20));
                terrain[i].isCollider = true;
                terrain[i].bounciness = 0;
                renderer.RegisterNewGameObjectToRender(terrain[i]);
                physicsEngine.AddNewPhysicsObject(terrain[i]);
            }
            player = new GameObject(new Vector2(40, 0), playerSprite, new Size2D(40, 40),false);
            player.bounciness = 0;
            renderer.RegisterNewGameObjectToRender(player);
            physicsEngine.AddNewPhysicsObject(player);
        }

        protected void UpdateLogic()
        {
            text.text = deltaTime.ToString();
            
        }
    }
}
