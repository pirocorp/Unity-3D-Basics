using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float bulletSpeed = 10F;

    public void Start()
    {
        
    }

    public void Update()
    {
        this.transform.position += this.transform.forward * this.bulletSpeed * Time.deltaTime;
        //this.transform.Translate(this.transform.forward * this.bulletSpeed * Time.deltaTime);
    }
}
