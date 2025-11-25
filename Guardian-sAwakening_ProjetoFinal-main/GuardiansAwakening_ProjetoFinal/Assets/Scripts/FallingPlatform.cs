using UnityEngine;
using System.Collections;

public class FallingPlatform : MonoBehaviour
{
    [Header("Tempos")]
    public float tempoParaCair = 3f;
    public float tempoParaVoltar = 3f;

    private Vector3 posicaoInicial;
    private Rigidbody2D rb;
    private bool playerEncima = false;
    private bool jaCaiu = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        posicaoInicial = transform.position;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("player") && !jaCaiu)
        {
            playerEncima = true;
            StartCoroutine(FallingRoutine());
        }
    }

    IEnumerator FallingRoutine()
    {
        jaCaiu = true;

        // Espera 3 segundos ANTES de cair
        yield return new WaitForSeconds(tempoParaCair);

        // Ativa gravidade para cair
        rb.bodyType = RigidbodyType2D.Dynamic;

        // Espera 3 segundos PARA VOLTAR
        yield return new WaitForSeconds(tempoParaVoltar);

        // Reset da plataforma
        rb.linearVelocity = Vector2.zero;
        rb.angularVelocity = 0;
        rb.bodyType = RigidbodyType2D.Kinematic;
        transform.position = posicaoInicial;

        jaCaiu = false;
    }
}
