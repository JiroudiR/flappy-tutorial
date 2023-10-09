using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public Player player;
	public Text scoreText;
	public GameObject playButton;
	public GameObject gameOver;
	public GameObject getReady;
    private int score;

    private void Awake()
    {
		Application.targetFrameRate = 60;
		Pause();
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
		{
			Application.Quit();
		}
    }

    public void Play()
	{
		score = 0;
		scoreText.text = score.ToString();
		playButton.SetActive(false);
		gameOver.SetActive(false);
		getReady.SetActive(false);
		Time.timeScale = 1f;
		player.enabled = true;
		Pipes[] pipes = FindObjectsOfType<Pipes>();
		for (int i = 0; i < pipes.Length; i++) {
			Destroy(pipes[i].gameObject);
		}
	}

	public void Pause()
	{
		Time.timeScale = 0f;
		player.enabled = false;
	}

    public void GameOver()
	{
		gameOver.SetActive(true);
		getReady.SetActive(false);
		playButton.SetActive(true);
		Pause();
	}
	
	public void IncreaseScore()
	{
		score++;
		scoreText.text = score.ToString();
	}
}
