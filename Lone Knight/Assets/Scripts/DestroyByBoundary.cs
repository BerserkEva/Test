using UnityEngine;
using System.Collections;

public class DestroyByBoundary : MonoBehaviour {

	void OnTriggerExit (Collider other)
	{
		Destroy (other.gameObject);

		if (other.tag == "player") 
		{
			Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);
			viewPos.x = Mathf.Clamp01(viewPos.x);
			viewPos.y = Mathf.Clamp01(viewPos.y);
			transform.position = Camera.main.ViewportToWorldPoint(viewPos);
		}
	
	}
}
