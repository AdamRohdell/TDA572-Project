using GameTest;
using System;
using System.Drawing;

namespace Shard
{
    class GameTest : Game, InputListener
    {
        GameObject background;

        GameObject ship;
        GameObject asteroid;
        GameObject dinosaur;
        public override void update()
        {
            //            Bootstrap.getDisplay().addToDraw(background);

            Bootstrap.getDisplay().showText("FPS: " + Bootstrap.getFPS(), 10, 10, 12, 255, 255, 255);

        }

        public void createShip()
        {
            ship = new Spaceship();
            Random rand = new Random();
            int offsetx = 0, offsety = 0;

            


            asteroid = new Asteroid();
            asteroid.Transform.translate(500 + 100, 500);
//            asteroid.MyBody.Kinematic = true;
     


            background = new GameObject();
            background.Transform.SpritePath = "background2.jpg";
            background.Transform.X = 0;
            background.Transform.Y = 0;


        }

        public void spawnDinosaur()
        {
            dinosaur = new Dinosaur();
            dinosaur.Transform.translate(0,0);
        }

        public override void initialize()
        {
            Bootstrap.getInput().addListener(this);
            Bootstrap.getSound().LoadSound("explosion.wav", "explosion");
            Bootstrap.getSound().LoadSound("bossfight.mp3", "boss");

            createShip();
            spawnDinosaur();

            //Bootstrap.getSound().PlaySound("bossfight");

        }

        public void handleInput(InputEvent inp, string eventType)
        {


            if (eventType == "MouseDown" && inp.Button == 1)
            {
                Asteroid asteroid = new Asteroid();
                asteroid.Transform.X = inp.X;
                asteroid.Transform.Y = inp.Y;
            }

            if (eventType == "MouseDown" && inp.Button == 3)
            {
                Bootstrap.getSound().PlaySound("explosion", asteroid, ship);
            }

            if (eventType == "MouseDown" && inp.Button == 2)
            {
                Bootstrap.getSound().PlayMusic("boss", 0, ship, asteroid);
            }


        }
    }
}
