using System;

namespace UEGP3.FSM.AI
{
	public class PatrolState : IdleState
	{
		public override IEnemyState Execute(Enemy enemy)
		{
			if (enemy.NavMeshAgent.remainingDistance <= enemy.NavMeshAgent.stoppingDistance)
			{
				enemy.UpdateNextPatrolPoint();
				
				// watch out! we CAN return a static state here, but as our LookAroundState has some runtime/isntance data, we will run into troubles
				// once we manage multiple enemies, as the instance and hence the instance data would be shared. Instead we should return a new LookAroundState
				// every time here. I will leave this in as-is for you to play around with and see the difference.
				// return new LookAroundState();
				return Enemy.LookAroundState;
			}

			return base.Execute(enemy);
		}

		public override void Enter(Enemy enemy)
		{
			enemy.NavMeshAgent.SetDestination(enemy.PatrolPoints[enemy.CurrentPatrolPointIndex].position);
			enemy.Animator.SetTrigger("Patrol");
		}

		public override void Exit(Enemy enemy)
		{
		}
	}
}