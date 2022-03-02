using Shard;
using Shard.Shard;
using System;

namespace GameTest
{
    class JumpBehaviour : IBehaviour
    {

        private double timer = 0;
        private double jumpInterval = 3;

        public IBehaviour ChangeToNextDefaultStrategy()
        {
            return new DodgeBulletBehaviour();
        }

        public void ExecuteStrategy(AIAgent agent)
        {
            Enemy e = agent as Enemy;
            timer += Bootstrap.getDeltaTime();
            if (timer >= jumpInterval)
            {
                e.Jump();
            }
        }
    }
}
