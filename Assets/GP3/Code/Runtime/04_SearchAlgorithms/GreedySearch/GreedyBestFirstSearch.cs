using System.Collections.Generic;
using System.Linq;

namespace GP3._04_SearchAlgorithms.GreedySearch
{
	public class GreedyBestFirstSearch : SearchBase
	{
		protected override void InitializeSearch()
		{
			_startNode = _startMarker.ClosestGridNode;
			_goalNode = _endMarker.ClosestGridNode;

			foreach (GridNode gridNode in _visited.Keys)
			{
				gridNode.Reset();
			}
			
			_openList = new List<GridNode>();
			_visited = new Dictionary<GridNode, GridNode>();

			_openList.Add(_startNode);
		}

		protected override bool StepToGoal()
		{
			_openList = _openList.OrderBy(n => n.Heuristic).ToList();
			GridNode current = _openList[0];
			
			// goal found
			if (current == _goalNode)
			{
				return true;
			}

			foreach (GridNode next in current.Neighbours)
			{
				if (next.IsWall)
				{
					continue;
				}

				if (!_visited.ContainsKey(next))
				{
					next.Heuristic = GetHeuristic(_goalNode, next);
					
					_openList.Add(next);
					_visited.Add(next, current);
					next.SetGridNodeSearchState(GridNodeSearchState.Queue);
				}
			}

			_openList.Remove(current);
			current.SetGridNodeSearchState(GridNodeSearchState.Processed);
			// not yet finished
			return false;
		}

		private float GetHeuristic(GridNode goal, GridNode next)
		{
			return (goal.transform.position - next.transform.position).magnitude;
		}
	}
}