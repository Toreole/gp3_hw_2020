using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace GP3._04_SearchAlgorithms
{
    public class AStarSearch : SearchBase
    {
        private List<GridNode> _closedList = new List<GridNode>();

        protected override void InitializeSearch()
        {
            //_startNode.Neighbours
            _startNode = _startMarker.ClosestGridNode;
            _goalNode = _endMarker.ClosestGridNode;

            _startNode.CostSoFar = 0;
            _startNode.Heuristic = HeuristicForNode(_startNode);

            _openList = new List<GridNode>();
            _openList.Add(_startNode);
        }

        //One step in the operation.
        protected override bool StepToGoal()
        {
            //ew linq
            _openList = _openList.OrderBy(x => x.Heuristic + x.CostSoFar).ToList();
            
            //grab the current node. not from a queue, but it still pops
            GridNode current = _openList[0];
            //check for goal.
            if(current == _goalNode)
            {
                return true;
            }
            _openList.Remove(current);
            //now go through the neighbours.
            foreach(GridNode nextNode in current.Neighbours)
            {
                //disregard walls
                if(nextNode.IsWall)
                    continue;
                //the pathcost to the next node from the current one.
                float nextPathCost = current.CostSoFar + nextNode.Cost;
                //if its shorter /faster than the previous path, override it.
                if(nextPathCost < nextNode.CostSoFar)
                {
                    _visited[nextNode] = current;
                    nextNode.CostSoFar = nextPathCost;
                    nextNode.Heuristic = HeuristicForNode(nextNode);
                    //if not added already, add it to the open list.
                    if(!_openList.Contains(nextNode))
                    {
                        nextNode.SetGridNodeSearchState(GridNodeSearchState.Queue);
                        _openList.Add(nextNode);
                    }
                }
            }
            current.SetGridNodeSearchState(GridNodeSearchState.Processed);
            //this node is not the goal.
            return false;
        }

        //Manhattan distance LOL!
        private float HeuristicForNode(GridNode node)
        {
            Vector2 pos = node.transform.position;
            Vector2 goalPos = _goalNode.transform.position;
            return Mathf.Abs(pos.x - goalPos.x) + Mathf.Abs(pos.y - goalPos.y);
        }
    }
}
