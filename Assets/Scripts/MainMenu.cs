using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private AudioSource clickSound;
    public void PlayButton()
    {
        clickSound.Play();
        SceneManager.LoadScene("Difficulty");
    }

    public void CreditsButton()
    {
        SceneManager.LoadScene("Credits");
        clickSound.Play();
    }

    public void QuitButton()
    {
        Application.Quit();
        Debug.Log("quitted");
        clickSound.Play();
    }

    public void BackButton()
    {
        SceneManager.LoadScene("Menu");
        clickSound.Play();
    }

    public void EasyButton()
    {
        SceneManager.LoadScene("Scene1");
        clickSound.Play();
    }

    public void NormalButton()
    {
        SceneManager.LoadScene("Scene2");
        clickSound.Play();
    }

    public void HardButton()
    {
        SceneManager.LoadScene("Scene3");
        clickSound.Play();
    }
}
