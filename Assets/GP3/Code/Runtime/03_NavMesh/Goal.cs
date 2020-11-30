using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GP3._03_NavMesh
{
	[RequireComponent(typeof(SphereCollider))]
	public class Goal : MonoBehaviour
	{
		private SphereCollider _sphereCollider;

		private void Awake()
		{
			_sphereCollider = GetComponent<SphereCollider>();
			_sphereCollider.isTrigger = true;
		}

		private void OnTriggerEnter(Collider other)
		{
			if (!other.CompareTag("Player"))
			{
				return;
			}

			// reload current scene if player reached goal
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}
	}
}