using UnityEngine;
using System.Collections;
public class Block : MonoBehaviour {
	public float gravityScaler = 30f;
	void Start(){
		GetComponent<Rigidbody2D> ().gravityScale += Time.timeSinceLevelLoad /2/ gravityScaler;
	}
	void Update () {
		if (transform.position.y <= -2f) {
			Destroy (gameObject);
		}
	}
}