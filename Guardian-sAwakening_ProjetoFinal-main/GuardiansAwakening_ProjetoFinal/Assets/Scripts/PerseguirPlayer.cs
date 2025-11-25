using UnityEngine;

public class PerseguirPlayer : MonoBehaviour
{
    public float velocidade = 2f;
    private Transform player;

    public float raioDeVisao = 3;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (player != null)
        {
            if (Vector3.Distance(transform.position, player.position) < raioDeVisao)
            {
                Vector2 direcao = player.position - transform.position;
                transform.position += new Vector3(direcao.normalized.x,0) * velocidade * Time.deltaTime;
            }
        }
    }
}