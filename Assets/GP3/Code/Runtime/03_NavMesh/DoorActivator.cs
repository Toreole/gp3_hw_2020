using UnityEngine;

namespace GP3._03_NavMesh
{
	[RequireComponent(typeof(BoxCollider))]
	public class DoorActivator : MonoBehaviour
	{
		#region Serialize Fields

		[SerializeField] [Tooltip("Door to activate")]
		private Door _door;

		#endregion

		#region Private Fields

		private Collider _collider;

		#endregion

		#region Unity methods

		private void Awake()
		{
			_collider = GetComponent<Collider>();
			_collider.isTrigger = true;
		}

		private void OnTriggerEnter(Collider other)
		{
			if (!other.gameObject.CompareTag("Player"))
			{
				return;
			}

			_door.Activate();
		}

		#endregion
	}
}