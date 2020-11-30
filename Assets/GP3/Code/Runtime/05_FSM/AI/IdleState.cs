namespace UEGP3.FSM.AI
{
	public abstract class IdleState : IEnemyState
	{
		public virtual IEnemyState Execute(Enemy enemy)
		{
			if (enemy.IsPlayerInSight)
			{
				return Enemy.RepositionState;
			}
			
			return this;
		}
		
		public abstract void Enter(Enemy enemy);
		public abstract void Exit(Enemy enemy);
	}
}