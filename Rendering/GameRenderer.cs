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
    public class GameRenderer
    {
        public SpriteBatch spriteBatch;
        private GraphicsDeviceManager graphicsDeviceManager;
        private GraphicsDevice device;
        private List<GameObject> objects=new List<GameObject>();
        private List<Text> texts = new List<Text>();

        public GameRenderer( GraphicsDeviceManager manager,GraphicsDevice Grdevice)
        {
           
            graphicsDeviceManager = manager;
            device = Grdevice;
        }
       
        public void Draw()
        {
            device.Clear(Color.CornflowerBlue);
            // TODO: Add your drawing code here
            SamplerState state = new SamplerState() ;
            ClearScreen();
            spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            for (int i = 0; i < objects.Count; i++)
            {
                GameObject gameObject = objects[i];
                if (gameObject.Size != null) { 
                   spriteBatch.Draw(gameObject.Texture,
                   new Rectangle((int)gameObject.Position.X, (int)gameObject.Position.Y, (int)gameObject.Size.Width, (int)gameObject.Size.Height),
                   new Rectangle(0, 0, gameObject.Texture.Width, gameObject.Texture.Height),
                   Color.White,
                   gameObject.rotation,
                   new Vector2(0F,0F),
                   gameObject.effect,
                   1);
                }
                else
                {
                    spriteBatch.Draw(gameObject.Texture, gameObject.Position, Color.White);
                }
            }
            for(int i = 0; i< texts.Count; i++)
            {

                   Text text = texts[i];
                spriteBatch.DrawString(text.font, text.text,text.position,Color.Black);
            }
            spriteBatch.End();
        }
        public void ClearScreen()
        {
            
        }
        public void RegisterNewGameObjectToRender(GameObject gameObject)
        {
            objects.Add(gameObject);
        }
        public void RemoveGameObject(GameObject gameObject)
        {
            if (objects.Contains(gameObject))
            {
                objects.Remove(gameObject);
            }
        }
        public void RegisterNewTextToRender(Text text)
        {
            texts.Add(text);
        }
        public void RemoveText(Text text)
        {
            if (texts.Contains(text))
            {
                texts.Remove(text);
            }
        }
    }
}
