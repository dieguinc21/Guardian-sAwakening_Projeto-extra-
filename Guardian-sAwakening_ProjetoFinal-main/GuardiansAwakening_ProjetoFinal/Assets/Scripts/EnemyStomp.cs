using UnityEngine;

public class EnemyStomp : MonoBehaviour
{
    public EnemyRespawn enemyRespawn; // referência ao script no inimigo

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("player"))
        {
            enemyRespawn.KillEnemy(other);
        }
    }
}
