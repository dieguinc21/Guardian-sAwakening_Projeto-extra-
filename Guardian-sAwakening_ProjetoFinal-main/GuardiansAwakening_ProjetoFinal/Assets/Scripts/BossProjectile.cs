using UnityEngine;

public class BossProjectile : MonoBehaviour
{
    public int dano = 1;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            PlayerLife pl = col.GetComponent<PlayerLife>();
            if (pl != null) pl.TakeDamage(dano);
            Destroy(gameObject);
        }
        else if (col.CompareTag("Ground") || col.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }
}
