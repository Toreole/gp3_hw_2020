using System;
using UnityEngine;
using UnityEngine.AI;

namespace GP3._03_NavMesh
{
	[RequireComponent(typeof(NavMeshAgent))]
	public class SimplePointAndClickController : MonoBehaviour
	{
		private NavMeshAgent _agent;

		private void Awake()
		{
			_agent = GetComponent<NavMeshAgent>();
		}

		private void Update()
		{
			if (Input.GetMouseButtonDown(0) && Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit))
			{
				_agent.SetDestination(hit.point);
			}
		}
	}
}
