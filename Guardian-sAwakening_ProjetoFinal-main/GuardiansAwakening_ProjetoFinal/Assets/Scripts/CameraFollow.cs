using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("Alvo")]
    public Transform alvo; 
    public Vector3 offset; 
    public float suavizacao = 0.125f;

    [Header("Limites da Câmera")]
    public bool limitarMovimento = true;
    public Vector2 limiteMinimo; 
    public Vector2 limiteMaximo;

    private void LateUpdate()
    {
        if (alvo == null) return;

        Vector3 destinoDesejado = alvo.position + offset;
        Vector3 destinoSuavizado = Vector3.Lerp(transform.position, destinoDesejado, suavizacao);

        
        if (limitarMovimento)
        {
            float clampedX = Mathf.Clamp(destinoSuavizado.x, limiteMinimo.x, limiteMaximo.x);
            float clampedY = Mathf.Clamp(destinoSuavizado.y, limiteMinimo.y, limiteMaximo.y);
            transform.position = new Vector3(clampedX, clampedY, transform.position.z);
        }
        else
        {
            transform.position = new Vector3(destinoSuavizado.x, destinoSuavizado.y, transform.position.z);
        }
    }
}