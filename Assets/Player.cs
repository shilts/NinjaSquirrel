using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	// Variables
	private int health = 100;
	private float jumpSpeed = 6.5f;
	private float wallJumpSpeed = 5.0f;
	private float moveSpeed = 0.5f;
	private bool isGrounded = true;
	private bool touchingWall = false;
	private int throwForce = 2000;
	private string facing = "R";

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
			touchingWall = true;
	    }
	}

	// Update is called once per frame
	void Update () {
		Vector3 newVel = rigidbody.velocity;
		Vector3 wallJumpLeft = new Vector3(wallJumpSpeed, 0, 0);
		Vector3 wallJumpRight = new Vector3(-wallJumpSpeed, 0, 0);

		//Basic controls
		if(isGrounded) {
			if(Input.GetKey(KeyCode.LeftArrow)) {
				newVel.x -= moveSpeed;
				rigidbody.velocity = newVel;
				facing = "R";
			}

			if(Input.GetKey(KeyCode.RightArrow)) {
				newVel.x += moveSpeed;
				rigidbody.velocity = newVel;
				facing = "L";
			}

			if(Input.GetKeyDown("space")) {
				newVel.y += jumpSpeed;
				rigidbody.velocity = newVel;
			}
		} else if(touchingWall) {
			if(Input.GetKey(KeyCode.LeftArrow)) {

				if(Input.GetKeyDown("space")) {
					print("Wall jump Right");
					rigidbody.AddForce(wallJumpRight);
				}
			} else if(Input.GetKey(KeyCode.RightArrow)) {

				if(Input.GetKeyDown("space")) {
					print("Wall jump Left");
					rigidbody.AddForce(wallJumpLeft);
				}
			}
		}

		if(Input.GetKey(KeyCode.LeftArrow)) {
			newVel.x -= (moveSpeed/2);
			rigidbody.velocity = newVel;
		}

		if(Input.GetKey(KeyCode.RightArrow)) {
			newVel.x += (moveSpeed/2);
			rigidbody.velocity = newVel;
		}

		if(Input.GetKeyDown("d")) {
			// Instantiate the projectile at the position and rotation of this transform
			Transform shurikenClone = Instantiate(shuriken, transform.position, transform.rotation) as Transform;
			//Ignore the thrower
			Physics.IgnoreCollision(shurikenClone.collider, collider);
			Vector3 power = -shurikenClone.transform.right * throwForce;

			if(facing == "L") {
				shurikenClone.rigidbody.AddForce(-power);
				print(power);
			} else {
				shurikenClone.rigidbody.AddForce(power);
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
