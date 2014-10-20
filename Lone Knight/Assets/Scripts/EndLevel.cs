using UnityEngine;
using System.Collections;

public class EndLevel : MonoBehaviour {

	private gameController GameController;
	public GameObject test;

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
			GameController.Restart();
			GameController.GameOver();
			return;
		}

		/*if (other.tag == "Finish") 
		{
			int counter;
			while(counter < 10)
			{
				counter++;
			}
		}*/
		Destroy (other.gameObject);
		Destroy (gameObject);
	}
}
