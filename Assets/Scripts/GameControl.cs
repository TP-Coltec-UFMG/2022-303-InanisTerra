using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Threading.Tasks;
using System.IO;

public class GameControl : MonoBehaviour
{
	public AudioSource Game_over;
	public AudioSource explosion;
	[SerializeField] GameObject Menu;
	[SerializeField] int lives = 1;
	[SerializeField] TMP_Text highScoreText;
	[SerializeField] TMP_Text yourScoreText;
	[SerializeField] TMP_Text lives_text;
	[SerializeField] GameObject[] obstacles;
	[SerializeField] GameObject item;
	[SerializeField] float spawnRate = 2f;
	[SerializeField] float ItemSpawnRate = 2f;
	[SerializeField] Transform spawnPoint;
	private bool menu = false;

	float nextSpawn;
	float nextSpawnItem;
	int highScore = 0, yourScore = 0;
	float nextScoreIncrease = 0f;
	

	private void OnCollisionEnter2D(Collision2D collision)
    {
		if (collision.gameObject.tag == "Obstaculo")
        {
			explosion.Play();
            lives--;
			Destroy(collision.gameObject);
		}
		if (collision.gameObject.tag == "Obs3")
        {
			explosion.Play();
			lives--;
			Destroy(collision.gameObject);
		}
		if (collision.gameObject.tag == "Obstaculo2")
		{
			explosion.Play();
			lives--;
			Destroy(collision.gameObject);
		}
		if (collision.gameObject.tag == "Item")
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
		SceneManager.LoadScene("MainMenu");
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

    private void Update()
    {
		escMenu();
	}

	// Update is called once per frame
	void FixedUpdate()
    {
		//escMenu();
		IncreaseYourScore();

		highScoreText.text = "High Score: " + highScore;
		yourScoreText.text = "Your Score: " + yourScore;
		lives_text.text = "Lives: " + lives.ToString();

		if (Time.time > nextSpawn) SpawnObstacle();
		if (Time.time > nextSpawnItem) SpawnItem();

		if (lives == 0)
		{
			Game_over.Play();
			Time.timeScale = 0.2f;
			Invoke(nameof(restartGame), .3f);
		}
	}

	void escMenu()
    {
		if (Input.GetKeyDown("escape"))
		{
			if (!menu)
			{
				Time.timeScale = 0;
				Menu.SetActive(true);
				menu = true;
			}
			else
			{
				Menu.SetActive(false);
				Time.timeScale = 1;
				menu = false;
			}
			Debug.Log("menu");
		}
	}

	void SpawnObstacle()
	{
		nextSpawn = Time.time + spawnRate;
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
			yourScore += 10;
			nextScoreIncrease = Time.unscaledTime + 1;
		}
	}
}
