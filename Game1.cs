using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Game1.BasicComponents;
using System;
using Game1.UI;
using System.Threading;
namespace Game1
{
    public partial class Game1 : Game
    {

        private GraphicsDeviceManager _graphics;
        public SpriteBatch _spriteBatch;
        public GameRenderer renderer;
        public Physics.PhysicEngine physicsEngine;
        public double deltaTime;
        public float physicsValue = 0.891f;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _graphics.PreferredBackBufferWidth = 1920;
            _graphics.PreferredBackBufferHeight = 1080;
            _graphics.SynchronizeWithVerticalRetrace = false;
            TargetElapsedTime = System.TimeSpan.FromMilliseconds(8);
            this.IsFixedTimeStep = false;
            _graphics.IsFullScreen = false;
            _graphics.ApplyChanges();
    
        }
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            renderer = new GameRenderer(_graphics, this.GraphicsDevice);
            base.Initialize();
        }
        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            renderer.spriteBatch = _spriteBatch;
            physicsEngine = new Physics.PhysicEngine(physicsValue,this);
            OnLoad();
            Thread thr1 = new Thread(() => physicsEngine.Update());
            thr1.Start();
        }
        protected override void Update(GameTime gameTime)
        {
            deltaTime = (double)gameTime.ElapsedGameTime.TotalMilliseconds;
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
            }
            if (Keyboard.GetState().IsKeyDown(Keys.F11))
            {
                _graphics.ToggleFullScreen();
            }

     
            UpdateLogic();
            base.Update(gameTime);
        }
        protected override void Draw(GameTime gameTime)
        {
            renderer.Draw();

            base.Draw(gameTime);
        }
}
}
