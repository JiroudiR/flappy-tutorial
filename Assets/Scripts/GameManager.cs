using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private const string V = "Cubes: ";
    public Player player;
	public Text scoreText;
	public GameObject playButton;
	public GameObject gameOver;
	public GameObject getReady;
	private GameObject square;
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
		scoreText.text = V + score.ToString();
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

    public Text GetScoreText()
    {
        return scoreText;
    }

    public void IncreaseScore(Text scoreText)
	{
		score++;
        scoreText.text = V + score.ToString();
		square.gameObject.SetActive(false);
	}
}
