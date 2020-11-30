using System;
using Gamekit3D;
using UnityEngine;
using UnityEngine.AI;

namespace UEGP3.FSM.AI
{
	[RequireComponent(typeof(NavMeshAgent), typeof(Animator))]
	public class Enemy : MonoBehaviour
	{
		public static PatrolState PatrolState = new PatrolState();
		public static LookAroundState LookAroundState = new LookAroundState();
		public static RepositionState RepositionState = new RepositionState();
		
		[SerializeField] [Tooltip("Enemy Sight Distance in meters")]
		private float _sightDistance = 5f;
		[SerializeField] [Tooltip("Enemy Aggro Range in meters. Outside of this range, the enemy will go back to patrolling.")]
		private float _aggroRange = 15f;
		[SerializeField] [Tooltip("Patrol pints")]
		private Transform[] _patrolPoints = default;

		// reference to the player object
		public PlayerController Player => _player;
		// returns true, if the player can be seen (First check distance of sight, then check line of sight using dot product (LoS in this case only means player is in front of enemy, doesnt check for occlusion)
		public bool IsPlayerInSight => (Vector3.Distance(transform.position, _player.transform.position) < _sightDistance) && (Vector3.Dot(transform.forward, _player.transform.position) > 0);
		// range in meters for aggro, before enemy goes back to idle again
		public float AggroRange => _aggroRange;
		// points for the enemy patrol
		public Transform[] PatrolPoints => _patrolPoints;
		// the nav mesh agent component of the enemy
		public NavMeshAgent NavMeshAgent => _navMeshAgent;
		// the animator of the enemy
		public Animator Animator => _animator;
		// the current patrol point we are walking towards
		public int CurrentPatrolPointIndex => _currentPatrolPointIndex;
		
		private PlayerController _player;
		private Animator _animator;
		private NavMeshAgent _navMeshAgent;
		private IEnemyState _currentState;
		private int _currentPatrolPointIndex;

		private void Awake()
		{
			_player = FindObjectOfType<PlayerController>();
			_animator = GetComponent<Animator>();
			_navMeshAgent = GetComponent<NavMeshAgent>();
			_currentState = PatrolState;
		}

		private void Update()
		{
			IEnemyState enemyState = _currentState.Execute(this);
			if (enemyState != _currentState)
			{
				Debug.Log($"Going from state {_currentState} to {enemyState}");
				_currentState.Exit(this);
				_currentState = enemyState;
				_currentState.Enter(this);
			}
		}
		
		public void UpdateNextPatrolPoint()
		{
			_currentPatrolPointIndex++;
			// use % operator to easily wrap around the patrol point index once we "overshoot" the index
			_currentPatrolPointIndex %= _patrolPoints.Length;
		}
	}
}