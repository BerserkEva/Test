using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary
{
	public float xmin, xmax, ymin,ymax;
}

public class PlayerController : MonoBehaviour {
	
	public float speed;
	public float acceleration;
	public float tilt;
	public Boundary boundary;
	
	//private Vector3 currentSpeed;
	//private float maxSpeed = 12;
	
	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;
	
	private float nextFire;

	void Update()
	{
		Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);
		viewPos.x = Mathf.Clamp01(viewPos.x);
		viewPos.y = Mathf.Clamp01(viewPos.y);
		transform.position = Camera.main.ViewportToWorldPoint(viewPos);

		if (Input.GetButton ("Fire1") && Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
		} 
		
		if (shot.rigidbody.position.x > boundary.xmax) {
			Destroy (shot);
		}
	}
	//input
	void FixedUpdate ()
	{
		float moveHoriztontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");
		
		Vector3 movement = new Vector3(moveHoriztontal, moveVertical, 0.0f);
		rigidbody.velocity = movement * speed;
	}
	
}
