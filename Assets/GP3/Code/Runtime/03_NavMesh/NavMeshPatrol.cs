using UnityEngine;
using UnityEngine.AI;

namespace GP3._03_NavMesh
{
	public class NavMeshPatrol : MonoBehaviour
	{
		[SerializeField] private Transform[] _patrolPoints;

		private NavMeshAgent _agent;
		// shows us which patrol point we are currently going to
		private int _currentPatrolPointIndex;
		
		private void Awake()
		{
			_currentPatrolPointIndex = 0;
			_agent = GetComponent<NavMeshAgent>();
			SampleNavMeshPosition();
		}

		private void Update()
		{
			if (_agent.stoppingDistance >= _agent.remainingDistance)
			{
				// we arrived at the current patrol point, so we have to check for the next one
				_currentPatrolPointIndex++;
				// modulo length will result in "resetting" the _currentPatrolPointIndex once we are >= _patrolPoint.Length
				// issue:
				// lets say we have 3 patrol points:
				// 0, 1, 2
				// another ++ = 3. 3 is out of bounds...
				// so lets calc with modulo!
				// 0 % 3 = 0
				// 1 % 3 = 1
				// 2 % 3 = 2
				// 3 % 3 = 0
				// 4 % 3 = 1
				// 5 % 3 = 2
				// 6 % 3 = 0
				// 18 % 3 = 0
				// mathematically spoken this also works with negative numbers:
				// -1 % 3 = 2
				// -2 % 3 = 1
				// -3 % 3 = 0
				// but this doesnt work in c# because the % operator doesnt implement "true" modulo
				_currentPatrolPointIndex %= _patrolPoints.Length;
				SampleNavMeshPosition();
			}
		}

		private void SampleNavMeshPosition()
		{
			bool didFindPosition = NavMesh.SamplePosition(_patrolPoints[_currentPatrolPointIndex].position, out NavMeshHit hit, 2f, NavMesh.AllAreas);
			if (didFindPosition)
			{
				_agent.SetDestination(hit.position);
			}
		}
	}
}