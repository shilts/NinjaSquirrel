using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	// Variables
	private int health = 100;
	private float jumpForce = 6.5f;
	private float moveForce = 0.5f;
	private bool isGrounded = true;
	private bool touchingWall = false;
	private int throwForce = 2000;

	public string facing = "R";
	public bool isDead = false;

	// Spawnable objects
	public Transform shuriken;

	// Use this for initialization
	void Start () {
	}

	void OnCollisionEnter(Collision theCollision) {
	    if(theCollision.gameObject.name == "Floor") {
	        isGrounded = true;

	    } else if(theCollision.gameObject.name == "Wall") {
	    	touchingWall = true;
	    }
	}

	void OnCollisionExit(Collision theCollision) {
	    if(theCollision.gameObject.name == "Floor") {
	        isGrounded = false;

	    } else if(theCollision.gameObject.name == "Wall") {
			touchingWall = false;
	    }
	}

	// Update is called once per frame
	void Update () {
		Vector3 newVel = rigidbody.velocity;

		//Basic controls
		if(isGrounded == true) {
			if(Input.GetKey(KeyCode.LeftArrow)) {
				newVel.x -= moveForce;
				rigidbody.velocity = newVel;
				facing = "L";
			}

			if(Input.GetKey(KeyCode.RightArrow)) {
				newVel.x += moveForce;
				rigidbody.velocity = newVel;
				facing = "R";
			}

			if(Input.GetKeyDown("space")) {
				newVel.y += jumpForce;
				rigidbody.velocity = newVel;
			}

		} else if(touchingWall == true) {
			if(Input.GetKey(KeyCode.LeftArrow)) {
				newVel.y -= 0.05f;
				rigidbody.velocity = newVel;

				if(Input.GetKeyDown("space")) {
					newVel.x += jumpForce;
					newVel.y = jumpForce;
					rigidbody.velocity = newVel;
					facing = "R";
				}

			} else if(Input.GetKey(KeyCode.RightArrow)) {
				newVel.y -= 0.05f;
				rigidbody.velocity = newVel;

				if(Input.GetKeyDown("space")) {
					newVel.x -= jumpForce;
					newVel.y = jumpForce;
					rigidbody.velocity = newVel;
					facing = "L";
				}
			}
		}

		if(Input.GetKey(KeyCode.LeftArrow)) {
			newVel.x -= (moveForce/3);
			rigidbody.velocity = newVel;
			facing = "L";
		}

		if(Input.GetKey(KeyCode.RightArrow)) {
			newVel.x += (moveForce/3);
			rigidbody.velocity = newVel;
			facing = "R";
		}

		if(Input.GetKeyDown("d")) {
			// Instantiate the projectile at the position and rotation of this transform
			Transform shurikenClone = Instantiate(shuriken, transform.position, transform.rotation) as Transform;
			//Ignore the thrower
			Physics.IgnoreCollision(shurikenClone.collider, collider);
			Vector3 horizontalPower = shurikenClone.transform.right * throwForce;
			Vector3 verticalPower = shurikenClone.transform.up * throwForce;

			if(Input.GetKey(KeyCode.UpArrow)) {
				shurikenClone.rotation = new Quaternion(0,0,1f,1);
				print(shurikenClone.rotation);
				shurikenClone.rigidbody.AddForce(verticalPower);
			} else if(Input.GetKey(KeyCode.DownArrow)) {
				shurikenClone.rotation = new Quaternion(0,0,-1f,1);
				shurikenClone.rigidbody.AddForce(-verticalPower);
			} else {
				if(facing == "L") {
					shurikenClone.rigidbody.AddForce(-horizontalPower);
				} else if(facing == "R"){
					shurikenClone.rigidbody.AddForce(horizontalPower);
				}
			}
		}

		if(transform.position.y <= -50) {
			health = 0;
		}

		if(health <= 0 && isDead == false) {
			print("You died");
			isDead = true;
		}
	}
}
