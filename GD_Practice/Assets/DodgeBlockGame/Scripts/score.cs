using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class score : MonoBehaviour {
	private float gravityScaler = 30f;
	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody2D> ().gravityScale += Time.timeSinceLevelLoad/2 / gravityScaler;
	}
	void Update () {
		if (transform.position.y <= -2f) {
			Destroy (gameObject);
		}
	}
}
