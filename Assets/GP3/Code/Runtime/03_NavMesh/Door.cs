using UnityEngine;

namespace GP3._03_NavMesh
{
	[RequireComponent(typeof(Animator))]
	public class Door : MonoBehaviour
	{
		#region Static Stuff

		private static readonly int Activate1 = Animator.StringToHash("Activate");

		#endregion

		#region Private Fields

		private Animator _animator;

		#endregion

		#region Unity methods

		private void Awake()
		{
			_animator = GetComponent<Animator>();
		}

		#endregion

		#region Public methods

		public void Activate()
		{
			// play open animation
			_animator.SetTrigger(Activate1);
		}

		#endregion
	}
}