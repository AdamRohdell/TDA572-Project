using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shard.Shard
{
    interface IBehaviour
    {
        public void ExecuteStrategy();

        public void ChangeStrategy();
    }
}
