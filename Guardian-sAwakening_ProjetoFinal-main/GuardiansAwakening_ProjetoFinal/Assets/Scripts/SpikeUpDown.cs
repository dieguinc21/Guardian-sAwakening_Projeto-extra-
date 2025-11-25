using UnityEngine;

public class SpikeUpDown : MonoBehaviour
{
    [Header("Movimento Vertical")]
    public float altura = 1f;          // Altura que o espinho vai subir
    public float velocidade = 2f;      // Velocidade da subida/descida
    public float tempoParado = 0.5f;   // Pequena pausa no topo e embaixo

    private Vector3 posInicial;
    private Vector3 posTopo;
    private float timer;

    private enum Estado { Subindo, ParadoCima, Descendo, ParadoBaixo }
    private Estado estadoAtual;

    private void Start()
    {
        posInicial = transform.localPosition;
        posTopo = posInicial + new Vector3(0, altura, 0);
        estadoAtual = Estado.ParadoBaixo;
        timer = tempoParado;
    }

    private void Update()
    {
        switch (estadoAtual)
        {
            case Estado.ParadoBaixo:
                timer -= Time.deltaTime;
                if (timer <= 0) estadoAtual = Estado.Subindo;
                break;

            case Estado.Subindo:
                transform.localPosition = Vector3.MoveTowards(
                    transform.localPosition,
                    posTopo,
                    velocidade * Time.deltaTime
                );

                if (Vector3.Distance(transform.localPosition, posTopo) < 0.01f)
                {
                    estadoAtual = Estado.ParadoCima;
                    timer = tempoParado;
                }
                break;

            case Estado.ParadoCima:
                timer -= Time.deltaTime;
                if (timer <= 0) estadoAtual = Estado.Descendo;
                break;

            case Estado.Descendo:
                transform.localPosition = Vector3.MoveTowards(
                    transform.localPosition,
                    posInicial,
                    velocidade * Time.deltaTime
                );

                if (Vector3.Distance(transform.localPosition, posInicial) < 0.01f)
                {
                    estadoAtual = Estado.ParadoBaixo;
                    timer = tempoParado;
                }
                break;
        }
    }
}
