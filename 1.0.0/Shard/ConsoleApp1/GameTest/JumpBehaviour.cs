using Shard;
using Shard.Shard;
using System;

namespace GameTest
{
    class JumpBehaviour : Node
    {

        private double timer = 0;
        private double jumpInterval = 3;

        public JumpBehaviour()
        {

        }

        public override NodeState Evaluate()
        {
            state = NodeState.RUNNING;
            return state;
        }
    }
}
