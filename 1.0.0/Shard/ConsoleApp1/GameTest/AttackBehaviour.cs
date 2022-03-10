using Shard.Shard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shard.GameTest
{
    public class AttackBehaviour : Node
    {

        public AttackBehaviour()
        {

        }

        public override NodeState Evaluate()
        {
            state = NodeState.RUNNING;
            return state;
        }
    }
}
