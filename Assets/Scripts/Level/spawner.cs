using UnityEngine;
using System.Collections;

public class spawner : MonoBehaviour {

	public Transform spawn;
	public int maxSpawn;
	public float xDistance;
	public float yDistance;
	float lastSpawned;
	ArrayList spawned = new ArrayList();
	Vector3 randPos;
	// Use this for initialization
	void Start () {
		for (int i = 0; i < 10; i++){
			spawnRandom ();
		}
	}
	
	// Update is called once per frame
	void Update () {
		if ((Time.time - lastSpawned) > 1 && spawned.Count < maxSpawn){
			spawnRandom ();
		}
	}

	void OnDrawGizmosSelected(){
		Gizmos.color = Color.white;
		Gizmos.DrawWireCube (transform.position, new Vector3(xDistance, yDistance, .1));
	}

	void spawnRandom(){
		randPos = new Vector3(Random.Range (transform.position.x - xDistance), Random.Range (transform.position.y - yDistance), 0);
		spawned.Add (Instantiate(spawn, randPos, Quaternion.identity));
		for (int i = 0; i < spawned.Count; i++){
			GameObject currentObj = (GameObject) spawned[i];
			if (currentObj.activeSelf == false){
				spawned.RemoveAt (i);
				Destroy(currentObj);
			}
		}
	}
}
