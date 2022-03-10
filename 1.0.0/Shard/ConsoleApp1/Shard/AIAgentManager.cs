/*
*
*   This manager class makes sure update gets called when it should on all the game objects, 
*       and also handles the pre-physics and post-physics ticks.  It also deals with 
*       transient objects (like bullets) and removing destroyed game objects from the system.
*   @author Michael Heron
*   @version 1.0
*   
*/

using Shard.Shard;
using System.Collections.Generic;

namespace Shard
{
    class AIAgentManager
    {
        private static AIAgentManager me;
        List<AIAgent> myAgents;

        private AIAgentManager()
        {
            myAgents = new List<AIAgent>();
        }

        public static AIAgentManager getInstance()
        {
            if (me == null)
            {
                me = new AIAgentManager();
            }

            return me;
        }

        public void addAIAgent(AIAgent gob)
        {
            myAgents.Add(gob);

        }

        public void removeAIAgent(AIAgent gob)
        {
            myAgents.Remove(gob);
        }




        public void update()
        {
            AIAgent agent;

            for(int i = 0; i < myAgents.Count; i++)
            {
                agent = myAgents[i];

                if (agent.CheckIfBehaviourShouldChange())
                {
                    agent.ChangeBehaviour(agent.currentBehaviour);
                }

                agent.currentBehaviour.ExecuteStrategy();
                // myAgents[i].CheckIfBehaviourShouldChange();
            }
        }

    }
}
