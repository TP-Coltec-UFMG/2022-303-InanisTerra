using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleControl : MonoBehaviour
{

	public float moveSpeed = -8f;

	// Update is called once per frame
	void Update()
	{
		transform.position = new Vector2(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y);

		if (transform.position.x < -10f) Destroy(gameObject);
	}
}
