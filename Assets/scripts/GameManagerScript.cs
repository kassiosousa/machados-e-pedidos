using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    public PointsScript pointsScript;
    public PlayerController playerController;
    public Animator playerAnimator;
    public AudioSource playerAudioSource;
    public GameObject GameOverPanel;
    public GameObject TotalPoints;

    public static GameManagerScript instance;
    void Awake()
    {
        if (instance == null) {
            print("dontdestroy");
            instance = this;
            //DontDestroyOnLoad(this.gameObject);
        } else if (instance != this) {
            //print("destroy");
            //Destroy(gameObject);
        }
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
        TextMeshProUGUI mText = TotalPoints.GetComponent<TextMeshProUGUI>();
        mText.text = "Points :"+PlayerPrefs.GetInt("total_points").ToString();
        playerAnimator.SetBool("Death", true);
        // Desliga o som de caminhada
        playerAudioSource.Stop();
        //Trava a movimentação do personagem porque perdeu 
        playerController.IsDead = true;
        // Função para esperar a animação de morte antes de morrer de fato
        StartCoroutine(WaitToDeathCourotine());
    }
    IEnumerator WaitToDeathCourotine()
    {
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(2);
        
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

    public void CamShake()
    {
        this.GetComponent<Shake>().CamShake();
    }
}
