using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public int playerId;
	public float speedMultiplier;
	public float turnMultiplier;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (playerId == 1) {
			if (Input.GetKey(KeyCode.W)) {
				MoveForward();
			}
			if (Input.GetKey(KeyCode.A)) {
				RotateLeft();
			}
			if (Input.GetKey(KeyCode.S)) {
				MoveBack();
			}
			if (Input.GetKey(KeyCode.D)) {
				RotateRight();
			}
			if (Input.GetKeyDown(KeyCode.Space)) {
				Shoot();					
			}
		}
		
		if (playerId == 2) {
			if (Input.GetKey(KeyCode.UpArrow)) {
				MoveForward();
			}
			if (Input.GetKey(KeyCode.DownArrow)) {
				RotateLeft();
			}
			if (Input.GetKey(KeyCode.LeftArrow)) {
				RotateLeft();
			}
			if (Input.GetKey(KeyCode.RightArrow)) {
				RotateRight();
			}
			if (Input.GetKeyDown(KeyCode.Return)) {
				Shoot();
			}
		}
	}


	public GameObject projectile;
	public Transform shootPoint;
	private void Shoot() {
		Instantiate(projectile, shootPoint.position, shootPoint.rotation);
	}

	private void RotateLeft() {
		this.transform.Rotate(Vector3.up * Time.deltaTime * turnMultiplier);
	}

	private void MoveForward() {
		this.transform.position += this.transform.forward * Time.deltaTime * speedMultiplier;
	}

	private void RotateRight() {
		this.transform.Rotate(Vector3.up * Time.deltaTime * -turnMultiplier);
	}

	private void MoveBack() {
		this.transform.position -= this.transform.forward * Time.deltaTime  * speedMultiplier;
	}

	/// <summary>
	/// OnCollisionEnter is called when this collider/rigidbody has begun
	/// touching another rigidbody/collider.
	/// </summary>
	/// <param name="other">The Collision data associated with this collision.</param>
	void OnCollisionEnter(Collision other)
	{
		if (other.transform.tag == "projectile") {
			Destroy(this.gameObject);
		}
	}
}
