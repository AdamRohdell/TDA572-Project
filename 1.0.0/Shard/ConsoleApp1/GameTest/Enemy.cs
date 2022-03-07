using Shard;
using Shard.Shard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTest
{
    class Enemy : GameObject, AIAgent, CollisionHandler
    {

      /*  public override void CheckIfBehaviourShouldChange()
        {
            if (true)
            {
                currentBehaviour = currentBehaviour.ChangeToNextDefaultStrategy();
            }
        }
      */
        public Enemy()
        {
            this.Transform.X = Bootstrap.getDisplay().getWidth() - 150;
            this.Transform.Y = Bootstrap.getDisplay().getHeight() - 150;
            this.Transform.SpritePath = "ryu2.png";
            this.Transform.SpriteFrames = 9;
            this.Transform.SpriteFrameDelay = 100;
            this.Transform.Scalex = 0.2f;
            this.Transform.Scaley = 0.8f;
            this.Transform.SpriteFlip = true;

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

            addTag("Enemy");
        }

        public override void update()
        {
            Bootstrap.getDisplay().addToDraw(this);
        }


        public void Jump()
        {

        }

        public void Move()
        {

        }

        public void CheckIfBehaviourShouldChange()
        {
            throw new NotImplementedException();
        }

        public void onCollisionEnter(PhysicsBody x)
        {
            throw new NotImplementedException();
        }

        public void onCollisionExit(PhysicsBody x)
        {
            throw new NotImplementedException();
        }

        public void onCollisionStay(PhysicsBody x)
        {
            throw new NotImplementedException();
        }
    }
}
