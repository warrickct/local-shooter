using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

	public GameObject Ps_explosion;

	// Use this for initialization
	void Start () {
		this.GetComponent<Rigidbody>().AddForce(transform.forward * 20, ForceMode.Impulse);
		Destroy(this.gameObject, 3.0f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	/// <summary>
	/// OnCollisionEnter is called when this collider/rigidbody has begun
	/// touching another rigidbody/collider.
	/// </summary>
	/// <param name="other">The Collision data associated with this collision.</param>
	void OnCollisionEnter(Collision other)
	{
		if (other.transform.tag == "player") {
			Instantiate(Ps_explosion, this.transform.position, this.transform.rotation);
		}
	}
}
