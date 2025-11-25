using UnityEngine;
using UnityEngine.SceneManagement;

public class SpikeDamage : MonoBehaviour
{
    public int dano = 1; // Quantidade de vidas que o espinho tira

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("player"))
        {
            // Pega o script Hearts do player
            Hearts hearts = collision.GetComponent<Hearts>();
            if (hearts != null)
            {
                // Subtrai vida, sem mexer em sprites ou lógica de corações
                hearts.vida -= dano;

                // Garante que a vida não fique negativa
                if (hearts.vida < 0)
                    hearts.vida = 0;

                // Debug opcional
                //Debug.Log("Player levou dano! Vidas restantes: " + hearts.vida);

                // Se vida chegou a zero, vai para GameOver
                if (hearts.vida == 0)
                {
                    SceneManager.LoadScene("GameOver");
                }
            }
        }
    }
}
