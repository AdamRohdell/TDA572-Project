using SDL2;
using Shard;
using System.Drawing;

namespace GameTest
{
    class Dinosaur : GameObject, InputListener, CollisionHandler
    {
        bool up, down, turnLeft, turnRight;


        public override void initialize()
        {

            this.Transform.X = 0.0f;
            this.Transform.Y = 600.0f;
            this.Transform.SpritePath = "ryu2.png";
            this.Transform.SpriteFrames = 9;
            this.Transform.SpriteFrameDelay = 100;
            this.Transform.Scalex = 0.25;

            Bootstrap.getInput().addListener(this);
            up = false;
            down = false;

            setPhysicsEnabled();

            MyBody.Mass = 4;
            MyBody.MaxForce = 10;
            MyBody.AngularDrag = 0.01f;
            MyBody.Drag = 0f;
            MyBody.UsesGravity = false;
            MyBody.StopOnCollision = false;
            MyBody.ReflectOnCollision = false;
            MyBody.ImpartForce = true;


            MyBody.PassThrough = false;

            addTag("Dinosaur");


        }

        public void handleInput(InputEvent inp, string eventType)
        {
            if (eventType == "KeyDown")
            {
                if (inp.Key == (int)SDL.SDL_Scancode.SDL_SCANCODE_D)
                {
                    up = true;
                }

                if (inp.Key == (int)SDL.SDL_Scancode.SDL_SCANCODE_A)
                {
                    down = true;
                }


            }
            else if (eventType == "KeyUp")
            {
                if (inp.Key == (int)SDL.SDL_Scancode.SDL_SCANCODE_D)
                {
                    up = false;
                }

                if (inp.Key == (int)SDL.SDL_Scancode.SDL_SCANCODE_A)
                {
                    down = false;
                }




            }




        }

        public override void physicsUpdate()
        {

            if (turnLeft)
            {
                MyBody.addTorque(-0.3f);
            }

            if (turnRight)
            {
                MyBody.addTorque(0.3f);
            }

            if (up)
            {

                MyBody.addForce(this.Transform.Forward, 0.5f);

            }

            if (down)
            {
                MyBody.addForce(this.Transform.Forward, -0.2f);
            }


        }

        public override void update()
        {
            Bootstrap.getDisplay().addToDraw(this);
        }

        public void onCollisionEnter(PhysicsBody x)
        {
            if (x.Parent.checkTag("Bullet") == false)
            {
                MyBody.DebugColor = Color.Red;
            }
        }

        public void onCollisionExit(PhysicsBody x)
        {

            MyBody.DebugColor = Color.Green;
        }

        public void onCollisionStay(PhysicsBody x)
        {
            MyBody.DebugColor = Color.Blue;
        }

        public override string ToString()
        {
            return "Spaceship: [" + Transform.X + ", " + Transform.Y + ", " + Transform.Wid + ", " + Transform.Ht + "]";
        }

    }
}
