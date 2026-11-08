using UnityEngine;

public class ApperingObject : MonoBehaviour
{
    [SerializeField]
    private GameObject obiekt;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            obiekt.SetActive(true);
        }
    }
}
