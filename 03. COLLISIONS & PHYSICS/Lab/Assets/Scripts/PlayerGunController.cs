using System.Security.Cryptography;
using UnityEngine;

public class PlayerGunController : MonoBehaviour
{
    [SerializeField]
    private float fireRate = 0.5F;

    [SerializeField]
    private GameObject bullet;

    [SerializeField]
    private GameObject spawnPoint;

    private float elapsedTime = 0;

    public void Start()
    {
        
    }

    public void Update()
    {
        this.elapsedTime += Time.deltaTime;

        if (this.elapsedTime >= this.fireRate && Input.GetMouseButton(0))
        {
            var currentBullet = Instantiate(this.bullet, this.spawnPoint.transform.position, this.spawnPoint.transform.rotation);
            Destroy(currentBullet, 5);
            this.elapsedTime = 0F;

            var layerMask = 1 << 8;

            if (Physics.Raycast(this.spawnPoint.transform.position, this.spawnPoint.transform.forward, out var hit, 1000, layerMask))
            {
                Destroy(hit.transform.gameObject);
            }
        }
    }
}
