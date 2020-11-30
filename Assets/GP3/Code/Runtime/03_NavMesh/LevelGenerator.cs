using UnityEngine;
using UnityEngine.AI;

namespace GP3._03_NavMesh
{
	public class LevelGenerator : MonoBehaviour
	{
		#region Serialize Fields

		[SerializeField] [Tooltip("The nav mesh we want to generate.")] 
		private NavMeshSurface _surface;
		[SerializeField] [Tooltip("The width of the level.")]
		private int _width = 10;
		[SerializeField] [Tooltip("The height of the level.")]
		private int _height = 10;
		[SerializeField] [Tooltip("The prefab to use for a wall")]
		private GameObject _wall;
		[SerializeField] [Tooltip("Probability to place a wall per tile in percent (0, 1)")] [Range(0f, 1f)]
		private float _wallProbability = 0.15f;

		#endregion

		#region Unity methods

		private void Start()
		{
			GenerateLevel();
			_surface.BuildNavMesh();
		}

		#endregion

		#region Private methods

		// Create a grid based level
		private void GenerateLevel()
		{
			// Loop over the grid
			for (int x = 0; x <= _width; x += 4)
			{
				for (int y = 0; y <= _height; y += 4)
				{
					// Should we place a wall?
					if (!(Random.value < _wallProbability))
					{
						continue;
					}

					// Spawn a wall
					Vector3 pos = new Vector3(x - (_width / 2f), 0, y - (_height / 2f)) + transform.position;
					Instantiate(_wall, pos, Quaternion.identity, _surface.transform);
				}
			}
		}

		#endregion
	}
}