using UnityEngine;
using System.Collections;

public class Shuriken : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	void OnCollisionEnter() {
		Destroy(gameObject);
	}

	// Update is called once per frame
	void Update () {

	}
}
