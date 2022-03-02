using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shard.Shard
{
    public interface IBehaviour
    {
        public void ExecuteStrategy(AIAgent agent);

        public IBehaviour ChangeToNextDefaultStrategy();
    }
}
