using UnityEngine;
using System.Collections;

public class gameController : MonoBehaviour 
{
	public GameObject Hazard;
	public Vector3 SpawnValues;
	public int hazardCount;

	public GameObject player1;

	private Boundary boundary;
	//private Vector3 pos = new Vector3(150.0f, 0.0f, 0.0f); 

	public float spawnWait;
	public float startWait;
	public float waveWait;

	public GUIText scoreText;
	public GUIText restartText;
	public GUIText gameOverText;
	public GUIText lifeText;

	private bool gameOver;
	private bool stopped;
	private bool restart;

	private int score;
	private int lives;

	public Camera camera;

	void UpdateScore()
	{
		scoreText.text = "Score: " + score;
	}

	void UpdateLife()
	{
		lifeText.text = "Life : " + lives;
	}

	void Start()
	{
		score = 0;
		gameOver = false;
		restart = false;
		stopped = false;
		gameOverText.text = "";
		restartText.text = "";
		lives = 3;

		//boundary.transform.position = camera.transform.position;

		UpdateScore ();
		UpdateLife ();
		StartCoroutine ("SpawnWaves");
		//StartCoroutine ("SpawnPlayer");

		Instantiate (player1, player1.transform.position, player1.transform.rotation);
	}

	/*public IEnumerator SpawnPlayer()
	{
		Debug.Log (lives);
		float spawnW = 3.0f;

		while (lives > 0) 
		{
			if (lives >= 1)
			{
				Instantiate (player1, player1.transform.position, player1.transform.rotation);
			}
			
			if (lives < 1) 
			{
				GameOver();
				yield break;
			}

			yield return new WaitForSeconds (spawnW);
		}

		if (gameOver) 
		{
			Restart();
			yield break;
		}
	}*/

	
	IEnumerator SpawnWaves()
	{
		if(camera.transform.position.x >= 140)
		{
			stopped = true;
		}

		yield return new WaitForSeconds(startWait);
		while (!gameOver) 
		{

			for (int i = 0; i < hazardCount; i++) 
			{

				Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);
				viewPos.x = Mathf.Clamp01(viewPos.x);
				viewPos.y = Mathf.Clamp01(viewPos.y);
				transform.position = Camera.main.ViewportToWorldPoint(viewPos);

				Vector3 SpawnPosition = new Vector3 ((SpawnValues.x + camera.transform.position.x), Random.Range(-SpawnValues.y , SpawnValues.y), SpawnValues.z);
				Quaternion SpawnRotation = Quaternion.identity;
				Instantiate (Hazard, SpawnPosition, SpawnRotation);

				yield return new WaitForSeconds (spawnWait);
			}

			yield return new WaitForSeconds(waveWait);


			if (gameOver)
			{
				Restart();
				break;

			}
		}
	}

	public void AddScore(int newScoreValue)
	{
		score += newScoreValue;
		UpdateScore ();
	}

	public void RemoveLife()
	{
		lives -= 1;
		UpdateLife ();
	}

	public void Restart()
	{
		restartText.text = "Press R to restart.";
		restart = true;
	}

	public void GameOver()
	{
		gameOverText.text = "Game Over";
		gameOver = true;
	}

	void Update()
	{
		if (restart)
		{
			if(Input.GetKeyDown(KeyCode.R))
			{
				Application.LoadLevel(Application.loadedLevel);
			}
		}

		if (camera.transform.position.x >= 140)
		{
			StopCoroutine ("SpawnWaves");
		}

		if (lives < 1) 
		{
			StopCoroutine("SpawnPlayer");
		}

	}
}
