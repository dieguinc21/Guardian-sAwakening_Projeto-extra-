using UnityEngine;

public class EnemyPatrolRaycast : MonoBehaviour
{
    [Header("Configurações de Movimento")]
    public float speed = 2f; // velocidade do inimigo

    [Header("Detecção de Paredes")]
    public Transform frontCheck;     // ponto na frente do inimigo
    public float rayDistance = 0.4f; // distância do raycast
    public LayerMask wallsLayer;     // layer das paredes (coloca a layer "Paredes" aqui)

    private bool facingRight = true; // direção atual
    private float turnCooldown = 0f; // tempo de espera pra evitar virar várias vezes seguidas

    void Update()
    {
        // controla o cooldown da virada
        if (turnCooldown > 0f)
            turnCooldown -= Time.deltaTime;

        // define a direção (1 = direita, -1 = esquerda)
        float direction = facingRight ? 1f : -1f;

        // move o inimigo
        transform.Translate(Vector2.right * direction * speed * Time.deltaTime);

        // origem do raycast (usa o frontCheck se existir, senão o próprio inimigo)
        Vector2 origin = frontCheck != null ? (Vector2)frontCheck.position : (Vector2)transform.position;
        Vector2 dir = facingRight ? Vector2.right : Vector2.left;

        // dispara o raycast para detectar a parede
        RaycastHit2D hit = Physics2D.Raycast(origin, dir, rayDistance, wallsLayer);

        // linha vermelha pra debug (opcional, aparece no modo de jogo)
        Debug.DrawLine(origin, origin + dir * rayDistance, Color.red);

        // se encostar na parede e o cooldown estiver zerado → vira
        if (hit.collider != null && turnCooldown <= 0f)
        {
            Flip();
            turnCooldown = 0.3f; // tempo de espera antes de poder virar de novo
        }
    }

    void Flip()
    {
        facingRight = !facingRight;

        // espelha o sprite horizontalmente
        Vector3 scale = transform.localScale;
        scale.x = Mathf.Abs(scale.x) * (facingRight ? 1f : -1f);
        transform.localScale = scale;

        // recua um pouquinho pra não colar na parede
        Vector3 offset = facingRight ? Vector3.right : Vector3.left;
        transform.position += offset * 0.2f;
    }
}
