using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsScript: MonoBehaviour
{

    public GameObject[] estrelas = new GameObject[5];
    public int counter;

    void Start()
    {
        PlayerPrefs.SetInt("total_points", 0);
        PlayerPrefs.SetInt("stars", 5);
        counter = PlayerPrefs.GetInt("stars");
    }

    /*void Update()
    {
        AddEstrela();
        SubEstrela();
    }
    */


    public void AddEstrela()
    {
        if (counter < 5)
        {
            switch (counter)
            {
                case 0:
                    estrelas[0].SetActive(true);
                    break;
                case 1:
                    estrelas[1].SetActive(true);
                    break;
                case 2:
                    estrelas[2].SetActive(true);
                    break;
                case 3:
                    estrelas[3].SetActive(true);
                    break;
                case 4:
                    estrelas[4].SetActive(true);
                    break;
                default:
                    break;
            }

            counter++;
            PlayerPrefs.SetInt("stars", counter);
            int points = PlayerPrefs.GetInt("total_points");
            PlayerPrefs.SetInt("total_points", points+1);

        }
    }


    public void SubEstrela()
    {
        if (counter > 0)
        {
            switch (counter)
            {
                case 1:
                    estrelas[0].SetActive(false);
                    // GameOver
                    break;
                case 2:
                    estrelas[1].SetActive(false);
                    break;
                case 3:
                    estrelas[2].SetActive(false);
                    break;
                case 4:
                    estrelas[3].SetActive(false);
                    break;
                case 5:
                    estrelas[4].SetActive(false);
                    break;
                default:
                    break;
            }
            counter--;
            PlayerPrefs.SetInt("stars", counter);
            
        }
    }

}
