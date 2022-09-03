using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemControl : MonoBehaviour
{

	public float moveSpeed = -8f;

	// Update is called once per frame
	void Update()
	{
		transform.position = new Vector2(transform.position.x + moveSpeed * Time.deltaTime, 0);

		if (transform.position.x < -15f) Destroy(gameObject);
	}
}
