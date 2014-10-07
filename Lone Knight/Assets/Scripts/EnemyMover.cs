using UnityEngine;
using System.Collections;

public class EnemyMover : MonoBehaviour
{
	private float speed = 10;
	
	void Start ()
	{
		rigidbody.velocity = transform.right * -speed;
	}
}
