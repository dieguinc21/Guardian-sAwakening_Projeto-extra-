using UnityEngine;

public class Playerco : MonoBehaviour
{
    [SerializeField] private int moedaQtd = 0;
    [SerializeField] private int porcaoTerraQtd = 0;
    [SerializeField] private int diamanteQtd = 0;

    [Header("Sons de coleta")]
    public AudioClip somMoeda;
    public AudioClip somPorcao;
    public AudioClip somDiamante;

    private AudioSource audioSource;
    private MoedaHudController moedaHud;
    private PorcaoTerraHudController porcaoHud;
    private DiamanteHudController diamanteHud;

    [System.Obsolete]
    private void Awake()
    {
        moedaHud = FindObjectOfType<MoedaHudController>();
        porcaoHud = FindObjectOfType<PorcaoTerraHudController>();
        diamanteHud = FindObjectOfType<DiamanteHudController>();

        moedaHud?.TextUpdate(moedaQtd);
        porcaoHud?.TextUpdate(porcaoTerraQtd);
        diamanteHud?.TextUpdate(diamanteQtd);

        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // --- Coleta de moeda ---
        if (collision.CompareTag("Collectable"))
        {
            moedaQtd++;
            moedaHud?.TextUpdate(moedaQtd);

            if (somMoeda != null)
                audioSource?.PlayOneShot(somMoeda);

            Destroy(collision.gameObject);
        }

        // --- Coleta de porção terra ---
        else if (collision.CompareTag("Collect"))
        {
            porcaoTerraQtd++;
            porcaoHud?.TextUpdate(porcaoTerraQtd);

            if (somPorcao != null)
                audioSource?.PlayOneShot(somPorcao);

            Destroy(collision.gameObject);
        }

        // --- Coleta de Diamante ---
        else if (collision.CompareTag("Diamante"))
        {
            diamanteQtd++;
            diamanteHud?.TextUpdate(diamanteQtd);

            if (somDiamante != null)
                audioSource?.PlayOneShot(somDiamante);

            Destroy(collision.gameObject);
        }
    }
}
