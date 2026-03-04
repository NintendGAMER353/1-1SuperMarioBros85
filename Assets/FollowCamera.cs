using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform camara; // Arrastra la Main Camera aquí en el Inspector
    public float efectoParallax = 0.9f; // 1.0 se mueve igual que la cámara, 0.9 un poco más lento

    void LateUpdate()
    {
        // Esto hace que el fondo siga la posición X e Y de la cámara
        transform.position = new Vector3(camara.position.x * efectoParallax, camara.position.y * efectoParallax, transform.position.z);
    }
}
