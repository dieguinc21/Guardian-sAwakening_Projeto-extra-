using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerDemage : MonoBehaviour
{
    private Hearts heart;

    [System.Obsolete]
    void Start()
    {
        heart = FindObjectOfType<Hearts>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            heart.vida--;

            if (heart.vida <= 0)
            {
                SceneManager.LoadScene("GameOver");
            }
        }
    }
}
