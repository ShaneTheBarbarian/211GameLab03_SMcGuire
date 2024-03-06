using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	[SerializeField] private Transform target;

	private Vector3 offset;

	private void Start()
	{
		offset = transform.position - target.position;
	}

	private void Update()
	{
		transform.position = Vector3.Lerp(transform.position, target.position + offset, Time.deltaTime);
	}

}
