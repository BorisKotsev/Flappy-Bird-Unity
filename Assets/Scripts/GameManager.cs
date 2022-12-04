using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text scoreText;

    public GameObject playBtn;
    public GameObject gameOver;
    public GameObject getReady;
    public Player player;

    public int score;

    private void Awake()
    {
        Application.targetFrameRate = 60;
        
        getReady.SetActive(true);
        gameOver.SetActive(false);

        Pause();
    }

    public void Play()
    {
        if(Random.Range(0, 1000) == 69)
        {
            FindObjectOfType<Player>().strength *= -1;
            FindObjectOfType<Player>().gravity *= -1;
        }

        score = 0;
        scoreText.text = score.ToString();

        playBtn.SetActive(false);   
        gameOver.SetActive(false);
        getReady.SetActive(false);

        Time.timeScale = 1f;

        player.enabled = true;

        Pipes[] pipes = FindObjectsOfType<Pipes>();

        foreach(Pipes pipe in pipes)
        {
            Destroy(pipe.gameObject);
        }
    }

    public void Pause()
    {
        Time.timeScale = 0f; 
        
        player.enabled = false;
    }

    public void IncreaseScore(int points)
    {
        score += points;
        scoreText.text = score.ToString();
    }

    public void GameOver()
    {
        gameOver.SetActive(true);
        playBtn.SetActive(true);

        Pause();
    }
}
