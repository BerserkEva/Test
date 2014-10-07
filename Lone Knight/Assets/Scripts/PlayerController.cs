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
		//currentSpeed = rigidbody.velocity;
		
		//if (currentSpeed.x < maxSpeed) 
		//{
		//	currentSpeed.x += acceleration;
		//}

		Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);
		viewPos.x = Mathf.Clamp01(viewPos.x);
		viewPos.y = Mathf.Clamp01(viewPos.y);
		rigidbody.position = new Vector3 
			(
				Mathf.Clamp(rigidbody.position.x, boundary.xmin, boundary.xmax),
				Mathf.Clamp(rigidbody.position.y, boundary.ymin, boundary.ymax),
				0.0f
				);


		transform.position = Camera.main.ViewportToWorldPoint(viewPos);
		
		//rigidbody.rotation = Quaternion.Euler(0.0f, rigidbody.velocity.y, 0.0f) - tilt;
	}
	
}
