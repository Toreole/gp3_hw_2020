using System;
using System.Collections.Generic;
using GP3._04_SearchAlgorithms.BFS;
using UnityEngine;

namespace GP3._04_SearchAlgorithms
{
	public class GridNode : MonoBehaviour
	{
		[SerializeField] private SpriteRenderer _image = default;
		[SerializeField] private SpriteRenderer _searchStateImage = default;
		[SerializeField]
		private GridNodeSettings[] settings;

		private int currentSettings;

		public float Cost => settings[currentSettings].Cost;

		public float CostSoFar { get; set; }
		public IEnumerable<GridNode> Neighbours => _neighbours;
		public bool IsWall => float.IsInfinity(Cost);
		public float Heuristic { get; set; }
		private List<GridNode> _neighbours = new List<GridNode>();
		private GridNodeType _type;
		private GridNodeSearchState _searchState;

		public void Init()
		{
			Reset();
			FindNeighbours();
			SetGridNodeSearchState(GridNodeSearchState.None);

			_searchStateImage.enabled = false;
		}

		private void OnMouseDown()
		{
			currentSettings = (currentSettings+1) % settings.Length;
			_image.color = settings[currentSettings].Color;
		}

		public void Reset()
		{
			SetGridNodeSearchState(GridNodeSearchState.None);
			CostSoFar = float.PositiveInfinity; //was -1000 before, but A* requires this to be infinite
		}

		public void SetGridNodeSearchState(GridNodeSearchState state)
		{
			_searchState = state;
			_searchStateImage.enabled = true;
			switch (state)
			{
				case GridNodeSearchState.None:
					_searchStateImage.color = BreadthFirstSearchSettings.Instance.GroundNodeColor;
					break;
				case GridNodeSearchState.Queue:
					_searchStateImage.color = BreadthFirstSearchSettings.Instance.QueueNodeColor;
					break;
				case GridNodeSearchState.Processed:
					_searchStateImage.color = BreadthFirstSearchSettings.Instance.ProcessedNodeColor;
					break;
				case GridNodeSearchState.PartOfPath:
					_searchStateImage.color = BreadthFirstSearchSettings.Instance.PathNodeColor;
					break;
				default:
					throw new ArgumentOutOfRangeException(nameof(state), state, null);
			}
		}

		private void FindNeighbours()
		{
			RaycastHit2D raycastHit2D = Physics2D.Linecast(transform.position, transform.position + Vector3.up, ~LayerMask.NameToLayer("Grid"));
			if ((raycastHit2D.collider != null) && raycastHit2D.collider.TryGetComponent(out GridNode node))
			{
				_neighbours.Add(node);
			}
			raycastHit2D = Physics2D.Linecast(transform.position, transform.position + Vector3.right, ~LayerMask.NameToLayer("Grid"));
			if ((raycastHit2D.collider != null) && raycastHit2D.collider.TryGetComponent(out node))
			{
				_neighbours.Add(node);
			}
			raycastHit2D = Physics2D.Linecast(transform.position, transform.position + Vector3.down, ~LayerMask.NameToLayer("Grid"));
			if ((raycastHit2D.collider != null) && raycastHit2D.collider.TryGetComponent(out node))
			{
				_neighbours.Add(node);
			}
			raycastHit2D = Physics2D.Linecast(transform.position, transform.position + Vector3.left, ~LayerMask.NameToLayer("Grid"));
			if ((raycastHit2D.collider != null) && raycastHit2D.collider.TryGetComponent(out node))
			{
				_neighbours.Add(node);
			}
		}
	}
}