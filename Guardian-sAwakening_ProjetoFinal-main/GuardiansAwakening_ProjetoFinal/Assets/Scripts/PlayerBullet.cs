using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public int dano = 10;
    public float speed = 8f;

    private void Start()
    {
        if (transform.localScale.x < 0)
            speed *= -1;
    }

    private void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Boss"))
        {
            Boss boss = col.GetComponent<Boss>();
            if (boss != null)
                boss.TomarDano(dano);

            Destroy(gameObject);
        }

        if (col.CompareTag("Ground") || col.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }
}
