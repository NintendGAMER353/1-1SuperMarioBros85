using UnityEngine;

public class EndingController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Exit Game");
            Application.Quit();
        }
    }
}
