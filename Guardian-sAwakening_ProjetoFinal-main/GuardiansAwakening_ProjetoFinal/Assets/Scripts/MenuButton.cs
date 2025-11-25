using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuClickManager : MonoBehaviour
{
    // Nomes das sprites/objetos usados como "botões"
    public string nomeJogar = "Jogar";
    public string nomeAjustes = "Ajustes";
    public string nomeCreditos = "Creditos";

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Pega posição do mouse no mundo (2D)
            Vector2 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // Procura um collider 2D na posição do mouse
            Collider2D hit = Physics2D.OverlapPoint(worldPos);
            if (hit != null)
            {
                Debug.Log("Hit: " + hit.name);
                if (hit.name == nomeJogar)
                {
                    Debug.Log("Carregando cena Fase1...");
                    SceneManager.LoadScene("Fase1"); // ou por índice
                }
                else if (hit.name == nomeAjustes)
                {
                    Debug.Log("Carregando cena Configuracoes...");
                    SceneManager.LoadScene("Configuracoes");
                }
                else if (hit.name == nomeCreditos)
                {
                    Debug.Log("Carregando cena Creditos...");
                    SceneManager.LoadScene("Creditos");
                }
                else
                {
                    Debug.Log("Objeto clicado não é botão esperado: " + hit.name);
                }
            }
            else
            {
                Debug.Log("Nenhum collider 2D na posição: " + worldPos);
            }
        }
    }
}