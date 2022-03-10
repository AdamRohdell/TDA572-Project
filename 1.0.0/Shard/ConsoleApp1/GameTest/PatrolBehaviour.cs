using Shard;
using Shard.Shard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTest
{
    class PatrolBehaviour : Node
    {

        private Transform _transform;
        private Transform[] _waypoints;
        private int _currentWaypointIndex = 0;


        public PatrolBehaviour(Transform transform, Transform[] waypoints)
        {
            _transform = transform;
            _waypoints = waypoints;
        }

        public override NodeState Evaluate()
        {

            Transform wp = _waypoints[_currentWaypointIndex];
            if (Vector3.Distance(_transform.position, wp.position) < 0.01f)
            {
                _transform.position = wp.position;


                _currentWaypointIndex = (_currentWaypointIndex + 1) % _waypoints.Length;
            }
            else
            {
                _transform.position = Transform.lerp(new Vector(_transform.X, _transform.Y), new Vector(wp.X, wp.Y))
            }


            state = NodeState.RUNNING;
            return state;
        }


    }
}
