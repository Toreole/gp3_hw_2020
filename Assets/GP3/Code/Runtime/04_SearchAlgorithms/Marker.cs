using System;
using System.Linq;
using GP3._04_SearchAlgorithms.BFS;
using UnityEngine;

namespace GP3._04_SearchAlgorithms
{
	public class Marker : MonoBehaviour
	{
		public static event Action MarkerMoved;
		
		private GridNode _closestGridNode;
		private Vector3 _screenPoint;
		private Vector3 _offset;
		public GridNode ClosestGridNode => _closestGridNode;

		private void OnMouseDown()
		{ 
			_screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
			_offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, _screenPoint.z));
		}

		private void OnMouseDrag()
		{     
			Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, _screenPoint.z);
 
			Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + _offset;
			transform.position = curPosition;
			SetToClosestGridNode();
			MarkerMoved?.Invoke();
		}

		public void SetToClosestGridNode()
		{
			Collider2D overlapCircle = Physics2D.OverlapCircleAll(transform.position, transform.localScale.x, ~LayerMask.NameToLayer("Grid")).OrderBy(c => (transform.position - c.transform.position).sqrMagnitude).FirstOrDefault();
			transform.position = overlapCircle.transform.position;
			_closestGridNode = overlapCircle.transform.GetComponent<GridNode>();
		}

		private void OnMouseUp()
		{
			SetToClosestGridNode();
		}
	}
}