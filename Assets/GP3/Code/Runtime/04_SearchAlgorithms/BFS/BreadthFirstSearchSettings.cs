using GP3.Core;
using UnityEngine;
using UnityEngine.Serialization;

namespace GP3._04_SearchAlgorithms.BFS
{
	[CreateAssetMenu(fileName = "BreadthFirstSearchSettings", menuName = "SearchAlgorithms/New BreadthFirstSearchSettings", order = 200)]
	public class BreadthFirstSearchSettings : ScriptableSingleton<BreadthFirstSearchSettings>
	{
		[FormerlySerializedAs("_normalNodeColor")]
		[Header("Colors for Search States")]
		[SerializeField] private Color _noneNodeColor;
		[FormerlySerializedAs("_QueueNodeColor")] [SerializeField] private Color _queueNodeColor;
		[SerializeField] private Color _processedNodeColor;
		[SerializeField] private Color _pathNodeColor;
		[Header("Colors for Node Types")]
		[SerializeField] private Color _groundNodeColor;
		[SerializeField] private Color _wallNodeColor;
		[SerializeField] private Color _waterNodeColor;

		public Color NoneNodeColor => _noneNodeColor;
		public Color WallNodeColor => _wallNodeColor;
		public Color WaterNodeColor => _waterNodeColor;
		public Color GroundNodeColor => _groundNodeColor;
		public Color QueueNodeColor => _queueNodeColor;
		public Color ProcessedNodeColor => _processedNodeColor;
		public Color PathNodeColor => _pathNodeColor;
	}
}