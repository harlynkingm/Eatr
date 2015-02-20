using UnityEngine;
using System.Collections;

public class camMovement : MonoBehaviour {

	public Transform player;
	Vector3 newPos;
	public float speed = 40.0f;

	void Start () {
		player = GameObject.Find ("Player").transform;
		}

	void Update () {
		newPos = new Vector3 (player.position.x, player.position.y, transform.position.z);
		transform.position = Vector3.MoveTowards (transform.position, newPos, speed * Time.deltaTime);
	}
}
