using UnityEngine;

public class CollectingZasobnik : MonoBehaviour
{
    [SerializeField]
    GameObject teleport;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if (teleport == null)
                Destroy(this.gameObject);
            else
            {
                AudioClip clip = Resources.Load<AudioClip>("pickup");
                AudioSource.PlayClipAtPoint(clip, transform.position);

                gameObject.GetComponent<MeshRenderer>().material.color = Color.green;
                teleport.SetActive(true);
            }
        }
    }
}
