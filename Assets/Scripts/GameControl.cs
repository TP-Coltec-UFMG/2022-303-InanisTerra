using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameControl : MonoBehaviour
{

	//[SerializeField] int lives = 3;
	[SerializeField] TMP_Text highScoreText;
	[SerializeField] TMP_Text yourScoreText;
	[SerializeField] GameObject[] obstacles;
	[SerializeField] float spawnRate = 2f;
	[SerializeField] Transform spawnPoint;

	float nextSpawn;
	int highScore = 0, yourScore = 0;
	float nextScoreIncrease = 0f;

	private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Obstaculo")
        {
            restartGame();
            //lives--;
        }
    }
    void restartGame()
    {
        //gameObject.transform.position = new Vector3(-8f, -4f);
        SceneManager.LoadScene(0);
    }

    // Start is called before the first frame update
    void Start()
    {
		yourScore = 0;
		Time.timeScale = 1f;
		nextSpawn = Time.time + spawnRate;
		highScore = PlayerPrefs.GetInt("highScore");
	}

    // Update is called once per frame
    void Update()
    {
		IncreaseYourScore();

		highScoreText.text = "High Score: " + highScore;
		yourScoreText.text = "Your Score: " + yourScore;

		//if (lives < 1) restartGame();
		if (Time.time > nextSpawn) SpawnObstacle();
	}
	void SpawnObstacle()
	{
		nextSpawn = Time.time + spawnRate;
		int randomObstacle = Random.Range(0, obstacles.Length);
		Instantiate(obstacles[randomObstacle], spawnPoint.position, Quaternion.identity);
	}
	void IncreaseYourScore()
	{
		if (Time.unscaledTime > nextScoreIncrease)
		{
			yourScore += 1;
			nextScoreIncrease = Time.unscaledTime + 1;
		}
	}
}
