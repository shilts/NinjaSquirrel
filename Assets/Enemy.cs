using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	void OnCollisionEnter(Collision theCollision) {
		print(theCollision.gameObject.name);
	    if(theCollision.gameObject.name == "Wall") {
	    	Destroy(gameObject);
	    }
	}

	// Update is called once per frame
	void Update () {

	}
}
