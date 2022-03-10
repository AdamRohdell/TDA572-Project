using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shard.Shard
{
    public abstract class BehaviourTree : GameObject
    {

        private Node _root = null;

        protected void Start()
        {
            _root = SetupTree();
        }


        public override void update()
        {
            base.update();

            if (_root != null)
            {
                _root.Evaluate();
            }
        }

        protected abstract Node SetupTree();
    }
}
