using UnityEngine;

public class FloatEffect : MonoBehaviour
{
    [Header("Configurações da flutuação")]
    public float amplitude = 0.05f;
    public float velocidade = 2f;

    [Header("Configurações do brilho")]
    public float brilhoVelocidade = 2f;  
    public float brilhoIntensidade = 0.2f; 

    private Vector3 posInicial;
    private SpriteRenderer spriteRenderer;
    private Color corOriginal;

    void Start()
    {
        posInicial = transform.position;
        spriteRenderer = GetComponent<SpriteRenderer>();
        corOriginal = spriteRenderer.color;
    }

    void Update()
    {
        // --- Flutuação suave ---
        float novaY = posInicial.y + Mathf.Sin(Time.time * velocidade) * amplitude;
        transform.position = new Vector3(transform.position.x, novaY, transform.position.z);

        // --- Brilho indo e voltando ---
        float brilho = (Mathf.Sin(Time.time * brilhoVelocidade) + 1f) / 2f;
        brilho *= brilhoIntensidade;

        spriteRenderer.color = new Color(
            corOriginal.r + brilho,
            corOriginal.g + brilho,
            corOriginal.b + brilho,
            corOriginal.a
        );
    }
}
