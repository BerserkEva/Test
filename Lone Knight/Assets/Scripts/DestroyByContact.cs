using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour {

	public GameObject explosion;
	public GameObject playerExplosion;
	public int scoreValue;
	private int currentLives = 3;

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

		Instantiate (explosion, transform.position, transform.rotation);

		if (other.tag == "Player") 
		{
			if (currentLives == 0);
			{
				Instantiate (playerExplosion, other.transform.position, other.transform.rotation);
				GameController.GameOver();
			}
			GameController.RemoveLife();
			currentLives -= 1;
			/*if( currentLives == 0 )
			{
				//Destroy (other.gameObject);
				GameController.GameOver();
			}*/
		}

		GameController.AddScore (scoreValue);
		Destroy (other.gameObject);
		Destroy (gameObject);
	}
}
