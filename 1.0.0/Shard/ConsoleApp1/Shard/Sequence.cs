﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shard.Shard
{
    public class Sequence : Node
    {
        public Sequence() : base()
        {
        
        }
        public Sequence(List<Node> children) : base(children) 
        {
        
        }

        public override NodeState Evaluate()
        {
            bool anyChildIsRunning = false;

            foreach (Node node in children)
            {
                switch (node.Evaluate())
                {
                    case NodeState.FAILURE:
                        state = NodeState.FAILURE;
                        return state;
                    case NodeState.SUCCESS:
                        continue;
                    case NodeState.RUNNING:
                        anyChildIsRunning = true;
                        continue;
                    default:
                        state = NodeState.SUCCESS;
                        return state;
                }
            }

            if (anyChildIsRunning)
            {
                state = NodeState.RUNNING;
            } else
            {
                state = NodeState.SUCCESS;
            }

            return state;
        }

    }
}
