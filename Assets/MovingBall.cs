using UnityEngine;

public class MovingBall : MonoBehaviour
{
    [SerializeField]
    float speed = 5f;
    private Vector3 ww = new Vector3(0, 0, 1);
    private float[] katy = {45f, 0f, -45f };

    void Update()
    {
        transform.position += ww * speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            float kat = katy[Random.Range(0, 3)];

            ww = Quaternion.Euler(0, kat, 0) * -ww;
        }
    }
}
