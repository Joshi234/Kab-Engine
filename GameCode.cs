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
   

            SpriteFont font = Content.Load<SpriteFont>("Text");
            Texture2D roehreSprite = Content.Load<Texture2D>("roehre");
            float roehreRandom = _random.Next(-75, 75);
            roehre1 = new GameObject(new Vector2(1000f, roehreRandom + 850F), roehreSprite, new Size2D(300f, 600f));
            renderer.RegisterNewGameObjectToRender(roehre1);
            roehre2 = new GameObject(new Vector2(1000f, roehreRandom), roehreSprite, new Size2D(300f, 600f), Effect: SpriteEffects.FlipVertically);
            renderer.RegisterNewGameObjectToRender(roehre2);
            text = new Text(font, "GameOver, press enter to restart!", new Vector2(800F, 500F));
            xbox = Content.Load<Texture2D>("ase32");
            for (int i = 0; i < 300; i++)
            {
                gameObject = new GameObject(new Vector2((float)(_random.NextDouble()*1920f), (float)(_random.NextDouble() * 900f)), xbox, new Size2D(64, 64), true);
                gameObject.isStatic = false;
                //-gameObject.isCollider = true;
                gameObject.bounciness = 1f;
                renderer.RegisterNewGameObjectToRender(gameObject);
                physicsEngine.AddNewPhysicsObject(gameObject);
            }

            gameObject = new GameObject(new Vector2(400f, 500f), xbox, new Size2D(64, 64), true);


            physicsEngine.AddNewPhysicsObject(gameObject);
 
            renderer.RegisterNewGameObjectToRender(gameObject);
            gameObject.onCollision += new GameObject.OnCollisionEventHandler(CollisionEnter);
            gameObject = new GameObject(new Vector2(0f, 1000f), xbox, new Size2D(1920, 64), true);
            gameObject.bounciness = 1f;
            renderer.RegisterNewGameObjectToRender(gameObject);

            physicsEngine.AddNewPhysicsObject(gameObject);
            //physicsEngine.AddNewPhysicsObject(roehre1);
            //physicsEngine.AddNewPhysicsObject(roehre2);
        }

        protected void UpdateLogic()
        {
            //Gets called once a frame
            var gamePad = GamePad.GetState(PlayerIndex.One);
            var keyBoard = Keyboard.GetState();
 
            //GamePad.SetVibration(PlayerIndex.One, 1f, 1f);
            if (keyBoard.IsKeyDown(Keys.Enter))
            {
                if (isDead)
                {
                    isDead = false;
                    isPlaying = true;
                    renderer.RemoveText(text);
                    gameObject.Position = new Vector2(400f, 500f);
                    float roehreRandom = _random.Next(-75, 75);
                    roehre1.Position = new Vector2(1000f, roehreRandom + 850F);
                    roehre2.Position = new Vector2(1000f, roehreRandom);
                    gameObject.isStatic = true;
                    gameObject.Velocity = new Vector2(0f, 0f);
                }
            }


            if (isPlaying)
            {
                roehre1.Position = new Vector2(roehre1.Position.X - (roehrenSpeed * (float)deltaTime), roehre1.Position.Y);
                roehre2.Position = new Vector2(roehre2.Position.X - (roehrenSpeed * (float)deltaTime), roehre2.Position.Y);
            }
            if (isDead == false)
            {
                if (gameObject.Position.Y > 1800 || gameObject.Position.Y < 10f)
                {
                    isDead = true;
                    isPlaying = false;
                    renderer.RegisterNewTextToRender(text);
                
                }
                if (gamePad.IsButtonDown(Buttons.A) || Keyboard.GetState().IsKeyDown(Keys.Space))
                {

                    if (isPlaying == false)
                    {
                        isPlaying = true;
                    }
                    gameObject.isStatic = false;

                    gameObject.AddVelocity(new Vector2(0f, -0.004f*(float)deltaTime));
                    if (roehre1.Position.X < -330f)
                    {
                        float roehreRandom = _random.Next(-75, 75);

                        roehre1.Position = new Vector2(1920f, roehreRandom + 850F);
                        roehre2.Position = new Vector2(1920f, roehreRandom);
                    }
                }
      
            }
        }
    }
}
