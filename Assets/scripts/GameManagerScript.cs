using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    public PointsScript pointsScript;
    public PlayerController playerController;
    public Animator playerAnimator;
    public GameObject GameOverPanel;

    public static GameManagerScript instance;
    void Awake()
    {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        } else if (instance != this) {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetFallPlayer()
    {
        playerAnimator.SetTrigger("Fall");
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void VerifyGameOver()
    {
        int stars = PlayerPrefs.GetInt("stars");
        if (stars==0)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        GameOverPanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void Replay()
    {
        SceneManager.LoadScene(1);
    }
    public void Menu()
    {
        SceneManager.LoadScene(0);
    }
}
