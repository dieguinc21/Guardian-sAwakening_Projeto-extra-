using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class carregarcena : MonoBehaviour
{

    public String nomme;

    public void carregar()
    {
        SceneManager.LoadScene(nomme);

    }

}
