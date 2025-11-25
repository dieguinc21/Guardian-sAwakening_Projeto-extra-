using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync("Fase1");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Voltar()
    {
        SceneManager.LoadSceneAsync("MainMenu");
    }

    public void SomOn()
    {
        AudioListener.volume = 1f;
        Debug.Log("Sons ligados");
    }

    public void SomOff()
    {
        AudioListener.volume = 0f;
        Debug.Log("Sons desligados");
    }

    public class SceneLoaderManager : MonoBehaviour
    {
        // Método público para carregar uma cena por nome (string)
        public void LoadSceneByName(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
