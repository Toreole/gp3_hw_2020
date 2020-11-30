namespace UEGP3.FSM.AI
{
	public interface IEnemyState
	{
		IEnemyState Execute(Enemy enemy);
		void Enter(Enemy enemy);
		void Exit(Enemy enemy);
	}
}