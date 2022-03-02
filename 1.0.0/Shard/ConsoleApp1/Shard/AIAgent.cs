using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shard.Shard
{

    // This class contains all of the commonly shared functionality between any AI agent. The class inherits from GameObject and
    // makes use of its update() method.
    //
    // The class that inherits from this one should contain all of the necessary functions that the different behaviours can control on the agent.
    // Examples of this would include Move() and Jump() as seen in the Enemy-class in the GameTest-project.


    public abstract class AIAgent : GameObject
    {

        protected IBehaviour currentBehaviour;

        public abstract void CheckIfBehaviourShouldChange();

        public AIAgent(IBehaviour behaviour) : base()
        {
            currentBehaviour = behaviour;
        }

        public override void update() {

            CheckIfBehaviourShouldChange();
            currentBehaviour.ExecuteStrategy(this);

        }
    }
}
