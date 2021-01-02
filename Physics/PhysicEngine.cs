using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Game1.BasicComponents;
using System.Diagnostics;
using System.Threading;
namespace Game1.Physics
{
    public class PhysicEngine
    {
        private float Gravitation;
        private List<GameObject> objects = new List<GameObject>();
        Game1 _game;
        double delta = 1;
        public PhysicEngine(float gravitation, Game1 game)
        {
            Gravitation = gravitation;
            _game = game;
        }
        public void Update()
        {
            
            while (true)
            {
                
                Stopwatch watch = new Stopwatch();
                watch.Start();
                for (int i = 0; i < objects.Count; i++)
                {

                    GameObject gameObject = objects[i];
                    if (gameObject.isStatic == false)
                    {
                        Vector2 oldPos = gameObject.Position;

                        gameObject.AddVelocity(new Vector2(0, (float)(Gravitation * delta)));
                        gameObject.Position = new Vector2((float)(gameObject.Position.X + (gameObject.Velocity.X * delta)), (float)(gameObject.Position.Y + (gameObject.Velocity.Y * delta)));
                        Rectangle rec = new Rectangle((int)gameObject.Position.X, (int)gameObject.Position.Y, (int)gameObject.Size.Width, (int)gameObject.Size.Height);
                        for (int ie = 0; ie < objects.Count; ie++)
                        {
                            GameObject otherObj = objects[ie];
                            if (gameObject != otherObj)
                            {

                                if (rec.Intersects(new Rectangle((int)otherObj.Position.X, (int)otherObj.Position.Y, (int)otherObj.Size.Width, (int)otherObj.Size.Height)))
                                {
                                    if (gameObject.Velocity != new Vector2(0f, 0f))
                                    {
                                        gameObject.Velocity = new Vector2(-1 * (gameObject.Velocity.X * otherObj.bounciness), -1 * (gameObject.Velocity.Y * otherObj.bounciness));
                                        //gameObject.Velocity = new Vector2(0f, 0f);
                                    }
                                    else
                                    {
                                        gameObject.Velocity = new Vector2(-1, -1);
                                    }
                                    gameObject.OnCollision();
                                    otherObj.OnCollision();
                                    gameObject.Position = oldPos;

                                }
                            }

                        }
                    }
                }
                //Thread.Sleep(100);
                watch.Stop();

                if (watch.ElapsedMilliseconds < 10) { 
                  Thread.Sleep((int)(10 - watch.ElapsedMilliseconds));
                }


            }
        }
        public void AddNewPhysicsObject(GameObject gameObject)
        {
            objects.Add(gameObject);
        }
    }
}
