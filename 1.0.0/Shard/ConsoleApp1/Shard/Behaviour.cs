using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shard.Shard
{
    public abstract class Behaviour
    {
        protected AIAgent _agent;

        public Behaviour(AIAgent agent)
        {
            _agent = agent;
        }

        public void ExecuteStrategy()
        {

        }

        public Behaviour ChangeToNextDefaultStrategy();
    }
}
