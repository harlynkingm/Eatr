using UnityEngine;
using System.Collections;

public class touchMovement : MonoBehaviour {
	
	Vector2 startPos;
	float xMove;
	float yMove;
	public float touchRadius = 30f;
	public float maxSpeed = 5f;
	Vector2 speed;
	Vector2 lastLoc;


	// Update is called once per frame
	void Update () {
				if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Began) {
					startPos = Input.GetTouch (0).position;
					lastLoc = Input.GetTouch (0).position;
				} else if (Input.touchCount > 0 && Vector2.Distance (lastLoc, Input.GetTouch (0).position) > touchRadius * 5) {
					startPos = Input.GetTouch (0).position;
					lastLoc = Input.GetTouch (0).position;
				} else if (Input.touchCount > 0 && Input.GetTouch (0).phase != TouchPhase.Ended) {
					xMove = (Input.GetTouch (0).position.x - startPos.x) / touchRadius;
					if (xMove > 1f) xMove = 1f;
					yMove = (Input.GetTouch (0).position.y - startPos.y) / touchRadius;
					if (yMove > 1f) yMove = 1f;
					speed = new Vector2 (xMove * maxSpeed, yMove * maxSpeed);
					rigidbody2D.MovePosition (rigidbody2D.position + speed * Time.deltaTime);
					lastLoc = Input.GetTouch (0).position;
				} else if (Input.touchCount == 0) {
					startPos = new Vector2();
				}
		}
}
