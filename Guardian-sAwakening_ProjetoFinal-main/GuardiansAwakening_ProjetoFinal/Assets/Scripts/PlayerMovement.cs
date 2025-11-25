using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movimento")]
    public float speed = 5f;
    public float jumpForce = 7f;

    [Header("Pulo Duplo")]
    public int maxPulos = 2;
    private int pulosRestantes;

    [Header("Ground Check")]
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private Animator animator;

    private bool isGrounded;

    private Vector3 posInicial;
    private Vector3 checkpointPos;
    private bool checkpointAtivo = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        pulosRestantes = maxPulos;

        posInicial = transform.position;
        checkpointPos = posInicial;

        StartCoroutine(EfeitoPiscarInicio());
    }

    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        if (isGrounded)
            pulosRestantes = maxPulos;

        float move = Input.GetAxis("Horizontal");

        rb.linearVelocity = new Vector2(move * speed, rb.linearVelocity.y);

        if (Input.GetButtonDown("Jump") && pulosRestantes > 0)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0f);
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            pulosRestantes--;
        }

        animator.SetBool("movendo", move != 0);
        animator.SetBool("saltando", !isGrounded);

        if (move > 0) spriteRenderer.flipX = false;
        if (move < 0) spriteRenderer.flipX = true;
    }

    public void RespawnPlayer()
    {
        Hearts hearts = GetComponent<Hearts>();
        if (hearts != null)
        {
            hearts.vida -= 1;
            if (hearts.vida < 0) hearts.vida = 0;

            if (hearts.vida == 0)
            {
                checkpointPos = posInicial;
                checkpointAtivo = false;

                SceneManager.LoadScene("GameOver");
                return;
            }
        }

        rb.linearVelocity = Vector2.zero;

        Vector3 spawnPos = checkpointAtivo ? checkpointPos : posInicial;

        Collider2D playerCollider = GetComponent<Collider2D>();
        float alturaPlayer = playerCollider != null ? playerCollider.bounds.size.y : 1f;

        spawnPos.y += alturaPlayer / 2f + 0.1f;
        transform.position = spawnPos;

        pulosRestantes = maxPulos;

        StartCoroutine(EfeitoPiscarInicio());
    }

    private IEnumerator EfeitoPiscarInicio()
    {
        float duracao = 0.10f;
        int quantidade = 3;

        for (int i = 0; i < quantidade; i++)
        {
            spriteRenderer.color = new Color(1f, 1f, 1f, 0f);
            yield return new WaitForSeconds(duracao);
            spriteRenderer.color = new Color(1f, 1f, 1f, 1f);
            yield return new WaitForSeconds(duracao);
        }
    }

    public void SetCheckpoint(Vector3 newCheckpoint, SpriteRenderer checkpointSprite)
    {
        checkpointPos = newCheckpoint;
        checkpointAtivo = true;

        if (checkpointSprite != null)
            StartCoroutine(BlinkCheckpoint(checkpointSprite));
    }

    private IEnumerator BlinkCheckpoint(SpriteRenderer sr)
    {
        for (int i = 0; i < 6; i++)
        {
            sr.enabled = !sr.enabled;
            yield return new WaitForSeconds(0.1f);
        }
        sr.enabled = true;
    }

    private void OnDrawGizmosSelected()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        }
    }
}
