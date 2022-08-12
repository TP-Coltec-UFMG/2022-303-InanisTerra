using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Threading.Tasks;
using System.IO;

public class GameControl : MonoBehaviour
{

	[SerializeField] int lives = 3;
	[SerializeField] TMP_Text highScoreText;
	[SerializeField] TMP_Text yourScoreText;
	[SerializeField] TMP_Text lives_text;
	[SerializeField] GameObject[] obstacles;
	[SerializeField] GameObject item;
	[SerializeField] float spawnRate = 2f;
	[SerializeField] float ItemSpawnRate = 2f;
	[SerializeField] Transform spawnPoint;

	float nextSpawn;
	float nextSpawnItem;
	int highScore = 0, yourScore = 0;
	float nextScoreIncrease = 0f;

	private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Obstaculo")
        {
            lives--;
			Destroy(collision.gameObject);
			if(lives == 0) restartGame();
		}

		if(collision.gameObject.tag == "Item")
        {
			lives++;
			Destroy(collision.gameObject);
		}

	}
    void restartGame()
    {
		if (yourScore > highScore)
		{
			highScore = yourScore;
			File.WriteAllText("Highscore.txt", highScore.ToString());
		}
		SceneManager.LoadScene(0);
    }

    // Start is called before the first frame update
    void Start()
    {
		yourScore = 0;
		Time.timeScale = 1f;
		nextSpawn = Time.time + spawnRate;
		nextSpawnItem = Time.time + ItemSpawnRate;
		highScore = int.Parse(File.ReadAllText("Highscore.txt"));
	}

    // Update is called once per frame
    void Update()
    {
		IncreaseYourScore();

		highScoreText.text = "High Score: " + highScore;
		yourScoreText.text = "Your Score: " + yourScore;
		lives_text.text = "Lives: " + lives.ToString();

		if (Time.time > nextSpawn) SpawnObstacle();
		if (Time.time > nextSpawnItem) SpawnItem();
	}
	void SpawnObstacle()
	{
		float rng = Random.Range(-3f, 3f);
		nextSpawn = Time.time + spawnRate - rng;
		int randomObstacle = Random.Range(0, obstacles.Length);
		Instantiate(obstacles[randomObstacle], spawnPoint.position, Quaternion.identity);
	}
	void SpawnItem()
	{
		nextSpawnItem = Time.time + ItemSpawnRate;
		Instantiate(item, spawnPoint.position, Quaternion.identity);
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
