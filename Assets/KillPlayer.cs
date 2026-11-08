using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Kill(other.gameObject);
    }
    private void OnCollisionEnter(Collision collision)
    {
        Kill(collision.gameObject);
    }
    private void Kill(GameObject target)
    {
        if (target.CompareTag("Player"))
        {
            target.SetActive(false);
            GameEnding.GameOver("Lose");
        }
    }
}
