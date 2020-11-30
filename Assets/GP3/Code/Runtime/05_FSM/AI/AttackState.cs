using UnityEngine;

namespace UEGP3.FSM.AI
{
	public class AttackState : CombatState
	{
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