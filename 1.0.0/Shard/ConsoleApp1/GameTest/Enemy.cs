using Shard.Shard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shard.GameTest
{
    class Enemy : GameObject, AIAgent
    {
        public bool CheckIfBehaviourShouldChange()
        {
            throw new NotImplementedException();
        }

        public Enemy()
        {

        }
    }
}
