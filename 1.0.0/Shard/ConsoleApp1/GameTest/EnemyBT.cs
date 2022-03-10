using GameTest;
using Shard.Shard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shard.GameTest
{
    public class EnemyBT : BehaviourTree
    {

        public EnemyBT()
        {

        }

        protected override Node SetupTree()
        {
            Node root = new PatrolBehaviour(transform, waypoints);
            return root;
        }
    }
}
