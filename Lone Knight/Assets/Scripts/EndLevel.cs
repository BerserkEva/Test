using UnityEngine;
using System.Collections;

public class EndLevel : MonoBehaviour {

	private gameController GameController;

	void Start()
	{
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null)
		{
			GameController = gameControllerObject.GetComponent<gameController>();
		}
		
		if (gameControllerObject == null)
		{
			Debug.Log("Can't find game controller Script.");
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Boundary") 
		{
			return;
		}

		if(other.tag == "Player")
	    {
			GameController.GameOver();
		}
	}
}
