using UnityEngine;

public class MonsterController : MonoBehaviour
{
    [SerializeField] 
    private GameObject player;

    [SerializeField]
    private float aimSpeed = 1.5F;

    private Rigidbody rb;

    public void Start()
    {
        this.rb = this.GetComponent<Rigidbody>();
    }

    public void Update()
    {
        //this.transform.LookAt(this.player.transform);
        var direction = this.player.transform.position - this.transform.position;

        this.rb.rotation = Quaternion.Slerp(this.rb.rotation, Quaternion.LookRotation(direction), this.aimSpeed * Time.deltaTime);
    }
}
