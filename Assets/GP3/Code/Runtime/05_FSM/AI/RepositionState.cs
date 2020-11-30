using UnityEngine;

namespace UEGP3.FSM.AI
{
	public class RepositionState : CombatState
	{
		private Vector3 _nextOffsetToPlayer;

		public override IEnemyState Execute(Enemy enemy)
		{
			return base.Execute(enemy);
		}

		public override void Enter(Enemy enemy)
		{
		}

		public override void Exit(Enemy enemy)
		{
		}
	}
}