using UnityEngine;

public class Teleporter : MonoBehaviour
{
    [SerializeField]
    Transform nextTeleport;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        if(nextTeleport == null)
        {
            GameEnding.GameOver("Win");
            return;
        }

        if (other.TryGetComponent<CharacterController>(out var cc))
        {
            AudioClip clip = Resources.Load<AudioClip>("teleport");
            AudioSource.PlayClipAtPoint(clip, transform.position);

            cc.enabled = false;
            other.transform.position = nextTeleport.position;
            cc.enabled = true;
        }
    }
}
