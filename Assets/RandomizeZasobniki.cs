using System.Collections.Generic;
using UnityEngine;

public class RandomizeZasobniki : MonoBehaviour
{
    [SerializeField]
    List<GameObject> zasobniki;

    [SerializeField]
    BoxCollider spawnArea;

    void Start()
    {
        Bounds bounds = spawnArea.bounds;

        foreach (GameObject zasobnik in zasobniki)
        {
            float randomX = Random.Range(bounds.min.x, bounds.max.x);
            float randomZ = Random.Range(bounds.min.z, bounds.max.z);
            zasobnik.transform.position = new Vector3(randomX, 1.67f, randomZ);
        }
    }
}
