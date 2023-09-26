using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject[] Levels;
    public GameObject ResetScreen, End;

    int currentLevel;

    //Timer
    public Text TextTimer;
    public float Waktu = 100;

    public bool GameAktif = true;
    public GameObject TimesUp;

    //Attack

    //public GameObject Player;
    //public GameObject Enemy;

    [SerializeField] private AudioSource wrongAnsSound;
    [SerializeField] private AudioSource winSound;

    public void wrongAnswer()
    {
        ResetScreen.SetActive(true);
        Levels[currentLevel].SetActive(false);
        wrongAnsSound.Play();
        GameAktif = false;
    }

    public void ResetGame()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void correctAnswer()
    {
        if(currentLevel + 1 != Levels.Length)
        {
            Levels[currentLevel].SetActive(false);

            currentLevel++;
            Levels[currentLevel].SetActive(true);
        }
        else
        {
            End.SetActive(true);
            Levels[currentLevel].SetActive(false);
            GameAktif = false;
            winSound.Play();
        }
    }

    void SetText()
    {
        int Menit = Mathf.FloorToInt(Waktu / 60);//01
        int Detik = Mathf.FloorToInt(Waktu % 60);//30
        TextTimer.text = Menit.ToString("00") + ":" + Detik.ToString("00");
    }

    float s;

    private void Update()
    {
        if (GameAktif)
        {
            s += Time.deltaTime;
            if (s >= 1)
            {
                Waktu--;
                s = 0;
            }
        }

        if (GameAktif && Waktu <= 0)
        {
            Debug.Log("Game Over");
            TimesUp.SetActive(true);
            Levels[currentLevel].SetActive(false);
            ResetScreen.SetActive(false);
            GameAktif = false; 
            wrongAnsSound.Play();
        }


        SetText();

    }
}
