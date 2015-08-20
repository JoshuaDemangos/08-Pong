using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
	public float speed = 30;

	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody2D> ().velocity = Vector2.right / 2* speed;
	}

	float hitFactor(Vector2 ballPosition, Vector2 racketPosition, float racketHeight)
	{
		return (ballPosition.y - racketPosition.y) / racketHeight;
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.name == "RacketLeft" || collision.gameObject.name == "RacketRight") {
			// calculate the hit factor
			float y = hitFactor (transform.position,
			                     collision.transform.position,
			                     collision.collider.bounds.size.y);
			
			Vector2 direction = new Vector2(1, y).normalized;

			if(collision.gameObject.name == "RacketRight") {
				direction = new Vector2(-1, y).normalized;
			}
			
			GetComponent<Rigidbody2D> ().velocity = direction * speed;
		}
	}
}
