using UnityEngine;

public class GunController : MonoBehaviour
{
    [SerializeField]
    private float fireRate = 2F;

    [SerializeField] 
    private GameObject bullet;

    [SerializeField] 
    private GameObject spawnPoint;

    private float elapsedTime = 0F;

    public void Start()
    {
        
    }

    public void Update()
    {
        this.elapsedTime += Time.deltaTime;

        if (this.elapsedTime >= this.fireRate)
        {
            var currentBullet = Instantiate(this.bullet, this.spawnPoint.transform.position, this.spawnPoint.transform.rotation);
            Destroy(currentBullet, 5);
            this.elapsedTime = 0F;
        }
    }
}
