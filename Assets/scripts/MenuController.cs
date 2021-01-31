using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject panelMenu;
    public GameObject panelCredits;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ActiveMenu()
    {
        panelCredits.SetActive(false);
        panelMenu.SetActive(true);
    }
    public void ActiveCredits()
    {
        panelCredits.SetActive(true);
        panelMenu.SetActive(false);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
