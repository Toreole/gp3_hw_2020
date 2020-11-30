using System;
using UnityEngine;

namespace UEGP3.FSM.Quests
{
	public class QuestItem : MonoBehaviour
	{
		public bool IsCollected => _isCollected;
		private bool _isCollected;

		private void Awake()
		{
			gameObject.SetActive(false);
		}

		private void Update()
		{
			transform.position = new Vector3(transform.position.x, transform.position.y * Mathf.Sin(Time.time), transform.position.z);
			transform.rotation = Quaternion.Euler(new Vector3(0, 90 * Time.deltaTime, 0));
		}

		private void OnTriggerEnter(Collider other)
		{
			if (other.CompareTag("Player"))
			{
				Collect();
			}
		}
		
		private void Collect()
		{
			_isCollected = true;
			gameObject.SetActive(false);
		}

		public void Activate()
		{
			gameObject.SetActive(true);
		}
	}
}