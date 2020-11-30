using UnityEngine;

namespace UEGP3.FSM.AI
{
	public abstract class CombatState : IEnemyState
	{
		public virtual IEnemyState Execute(Enemy enemy)
		{
			if (Vector3.Distance(enemy.transform.position, enemy.Player.transform.position) >= enemy.AggroRange)
			{
				return Enemy.PatrolState;
			}
			
			return this;
		}

		public abstract void Enter(Enemy enemy);
		public abstract void Exit(Enemy enemy);
	}
}