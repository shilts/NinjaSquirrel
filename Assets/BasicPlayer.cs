using UnityEngine;
using System.Collections;

public class BasicPlayer : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

		//Basic controls
		if(Input.GetKey(KeyCode.LeftArrow)) {
			transform.Translate(new Vector3(-0.5f, 0, 0));
		} else if(Input.GetKey(KeyCode.RightArrow)) {
			transform.Translate(new Vector3(0.5f, 0, 0));
		} else if(Input.GetKey(KeyCode.Space)) {
			transform.Translate(new Vector3(0, 0.5f, 0));
		}
	}
}
