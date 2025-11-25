using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [Header("Brilho")]
    [Tooltip("Intensidade máxima do brilho")]
    public float maxAlpha = 0.8f;
    [Tooltip("Intensidade mínima do brilho")]
    public float minAlpha = 0.4f;
    [Tooltip("Velocidade do brilho")]
    public float speed = 2f;

    private SpriteRenderer sr;
    private Color originalColor;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        if (sr == null)
        {
            //Debug.LogWarning("Precisa de um SpriteRenderer no mesmo GameObject!");
            enabled = false;
            return;
        }

        originalColor = sr.color;
    }

    void Update()
    {
        // Cria o efeito de brilho pulsante usando Seno
        float alpha = Mathf.Lerp(minAlpha, maxAlpha, (Mathf.Sin(Time.time * speed) + 1f) / 2f);

        sr.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
    }
}
