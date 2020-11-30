using System;
using UnityEngine;

namespace UEGP3.FSM.AI
{
	public class LookAroundState : IdleState
	{
		private float _currentTime;
		private static readonly int LookAround = Animator.StringToHash("LookAround");
		private const float LookAroundTime = 1.75f;
		
		public override IEnemyState Execute(Enemy enemy)
		{
			_currentTime += Time.deltaTime;
			if (_currentTime >= LookAroundTime)
			{
				return Enemy.PatrolState;
			}

			return base.Execute(enemy);
		}

		public override void Enter(Enemy enemy)
		{
			_currentTime = 0;
			enemy.Animator.SetTrigger(LookAround);
		}

		public override void Exit(Enemy enemy)
		{
		}
	}
}