using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Game1.Controls
{
    public class Controls
    {
        public GamePadState gamePad1;
        public GamePadState gamePad2;
        public GamePadState gamePad3;
        public GamePadState gamePad4;
        public GamePadState gamePad5;
        public KeyboardState keyboard;
        public void UpdateVars()
        {
            //Gets called once a frame
            gamePad1 = GamePad.GetState(PlayerIndex.One);
            gamePad2 = GamePad.GetState(PlayerIndex.Two);
            gamePad3 = GamePad.GetState(PlayerIndex.Three);
            gamePad4 = GamePad.GetState(PlayerIndex.Four);
            gamePad5 = GamePad.GetState(4);
            keyboard = Keyboard.GetState();
            //GamePad.SetVibration(PlayerIndex.One, 1f, 1f);
            
        }
        
        public void Vibrate(PlayerIndex index,float leftMotor,float rightMotor)
        {
            GamePad.SetVibration(index, leftMotor, rightMotor);
        }
    }
}
