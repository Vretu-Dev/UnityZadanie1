using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField]
    GameObject zasobnik;

    private Camera playerCamera;
    private RaycastHit hit;

    private void Start()
    {
        playerCamera = GetComponentInChildren<Camera>();
    }

    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Shot();
        }
    }

    private void Shot()
    {
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, 15f))
        {
            if (hit.collider.CompareTag("Enemy"))
            {
                Destroy(hit.collider.gameObject);

                int remainingEnemies = GameObject.FindGameObjectsWithTag("Enemy").Length;

                if (remainingEnemies <= 1 && zasobnik != null)
                {
                    zasobnik.SetActive(true);
                }
            }
        }
    }
}
