using UnityEngine;

[ExecuteAlways]
public class BackgroundAutoFollow : MonoBehaviour
{
    [SerializeField] private Camera targetCamera;    
    [SerializeField] private float zOffset = 0f;    
    [Range(0f, 1f)]
    [SerializeField] private float parallaxFactor = 1f; 

    private Vector3 initialCameraPosition;
    private Vector3 initialBackgroundPosition;

    void Start()
    {
        if (targetCamera == null)
            targetCamera = Camera.main;

        if (targetCamera != null)
        {
            initialCameraPosition = targetCamera.transform.position;
            initialBackgroundPosition = transform.position;
        }
    }

    void LateUpdate()
    {
        if (targetCamera == null)
            targetCamera = Camera.main;

        if (targetCamera == null)
            return;

        
        Vector3 cameraDelta = targetCamera.transform.position - initialCameraPosition;
        transform.position = new Vector3(
            initialBackgroundPosition.x + cameraDelta.x * parallaxFactor,
            initialBackgroundPosition.y + cameraDelta.y * parallaxFactor,
            zOffset
        );

        
        float height = 2f * targetCamera.orthographicSize;
        float width = height * targetCamera.aspect;

        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if (sr == null || sr.sprite == null)
            return;

        float spriteWidth = sr.sprite.bounds.size.x;
        float spriteHeight = sr.sprite.bounds.size.y;

        transform.localScale = new Vector3(
            width / spriteWidth,
            height / spriteHeight,
            1f
        );
    }
}