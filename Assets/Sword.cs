using UnityEngine;
using System.Collections;

public class Sword : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		Quaternion swordSwing = transform.rotation;

		if(Input.GetKeyDown("f")) {
			swordSwing.z -= 0.50f;
			transform.rotation = swordSwing;
		} else if (Input.GetKeyUp("f")) {
			swordSwing.z = 0;
			transform.rotation = swordSwing;
		}
	}
}
