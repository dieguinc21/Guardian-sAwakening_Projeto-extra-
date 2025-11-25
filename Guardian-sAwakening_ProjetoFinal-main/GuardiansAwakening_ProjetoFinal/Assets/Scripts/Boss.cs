using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    [Header("Vida do Boss")]
    public int vidaMax = 100;
    private int vidaAtual;
    public Slider barraVida;

    [Header("Movimento")]
    public Transform pontoA;
    public Transform pontoB;
    public float velocidade = 3f;
    private bool indoParaA = true;

    [Header("Tiro")]
    public GameObject projetilPrefab;
    public Transform pontoDeTiro;
    public float delayTiro = 2f;
    private float timer;
    private Transform player;
    public float velocidadeProjetil = 6f;

    private void Start()
    {
        vidaAtual = vidaMax;

        if (barraVida != null)
        {
            barraVida.maxValue = vidaMax;
            barraVida.value = vidaAtual;
        }

        player = GameObject.FindGameObjectWithTag("Player")?.transform;
    }

    private void Update()
    {
        Mover();

        timer += Time.deltaTime;
        if (timer >= delayTiro)
        {
            Atirar();
            timer = 0f;
        }
    }

    void Mover()
    {
        Transform alvo = indoParaA ? pontoA : pontoB;

        transform.position = Vector2.MoveTowards(
            transform.position,
            alvo.position,
            velocidade * Time.deltaTime
        );

        if (Vector2.Distance(transform.position, alvo.position) < 0.1f)
            indoParaA = !indoParaA;
    }

    void Atirar()
    {
        if (projetilPrefab == null || pontoDeTiro == null || player == null)
            return;

        GameObject tiro = Instantiate(projetilPrefab, pontoDeTiro.position, Quaternion.identity);

        Rigidbody2D rb = tiro.GetComponent<Rigidbody2D>();
        Vector2 direcao = (player.position - pontoDeTiro.position).normalized;

        if (rb != null)
        {
            rb.linearVelocity = direcao * velocidadeProjetil;
        }
        else
        {
            Debug.LogWarning("ADICIONE Rigidbody2D ao prefab do Tiro do Boss");
        }
    }

    public void TomarDano(int dano)
    {
        vidaAtual -= dano;

        if (barraVida != null)
            barraVida.value = vidaAtual;

        if (vidaAtual <= 0)
            Morrer();
    }

    void Morrer()
    {
        Debug.Log("Boss morreu!");
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerBullet"))
        {
            TomarDano(10);
            Destroy(collision.gameObject);
        }
    }
}
