using UnityEngine;

public class PlataformaVertical : MonoBehaviour
{
    public Transform pontoCima;
    public Transform pontoBaixo;
    public float velocidade = 2f;

    private Vector3 alvo;

    void Start()
    {
        alvo = pontoBaixo.position; // começa indo para baixo
    }

    void Update()
    {
        // Move a plataforma até o alvo
        transform.position = Vector3.MoveTowards(transform.position, alvo, velocidade * Time.deltaTime);

        // Quando chega no ponto, troca o alvo
        if (Vector3.Distance(transform.position, alvo) < 0.05f)
        {
            if (alvo == pontoBaixo.position)
                alvo = pontoCima.position;
            else
                alvo = pontoBaixo.position;
        }
    }
}
