using Shard.Shard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTest
{
    class Enemy : AIAgent
    {

        public override void CheckIfBehaviourShouldChange()
        {
            if (true)
            {
                currentBehaviour = currentBehaviour.ChangeToNextDefaultStrategy();
            }
        }

        public Enemy(IBehaviour initialBehaviour) : base(initialBehaviour)
        {

        }

        public override void update()
        {
            base.update();
        }


        public void Jump()
        {

        }

        public void Move()
        {

        }
    }
}
