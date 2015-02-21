using UnityEngine;
using System.Collections;

public class sizeController : MonoBehaviour {

	float currentSize;
	public float speed = 3f;
	ArrayList edibles = new ArrayList();
	// Use this for initialization
	void Start () {
		currentSize = transform.localScale.x;
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.localScale.x != currentSize || transform.localScale.y != currentSize) {
			Vector3 newScale = new Vector3(currentSize, currentSize, 1);
			transform.localScale = Vector3.Lerp (transform.localScale, newScale, speed * Time.deltaTime);
				}
		if (edibles.Count > 0) {
						for (int i = 0; i < edibles.Count; i++) {
								GameObject currentObject = (GameObject) edibles[i];
								if (Vector3.Distance(currentObject.transform.position, transform.position) < renderer.bounds.size.x * .5){
									currentObject.SetActive (false);
									edibles.RemoveAt (i);
								}
								else currentObject.transform.position = Vector3.MoveTowards (currentObject.transform.position, transform.position, speed * Time.deltaTime);
						}
				}

	}

	void OnTriggerEnter2D (Collider2D other){
		//Debug.Log (other.name);
		if (other.name == "food" && squareBoth (renderer.bounds.size.x, renderer.bounds.size.y) >= squareBoth (other.renderer.bounds.size.x, other.renderer.bounds.size.y)) {
						edibles.Add (other.gameObject);
						currentSize += squareBoth (other.renderer.bounds.size.x, other.renderer.bounds.size.y) * .1f;
		} else if (other.name == "food" && squareBoth (renderer.bounds.size.x, renderer.bounds.size.y) < squareBoth (other.renderer.bounds.size.x, other.renderer.bounds.size.y)) {
			currentSize -= squareBoth (other.renderer.bounds.size.x, other.renderer.bounds.size.y) * .1f;
				}
		}
		 
	float squareBoth(float one, float two){
		float final = 0f;
		final += Mathf.Pow (one, 2) + Mathf.Pow (two, 2);
		return final;
		}
}
