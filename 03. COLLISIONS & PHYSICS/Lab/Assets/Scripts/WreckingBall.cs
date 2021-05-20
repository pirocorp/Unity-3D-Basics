using UnityEngine;

public class WreckingBall : MonoBehaviour
{
    private Rigidbody rb;

    public void Start()
    {
        this.rb = this.GetComponent<Rigidbody>();
    }

    public void Update()
    {
        if (Input.GetMouseButton(0))
        {
            this.rb.AddForce(this.transform.right, ForceMode.Impulse);
        }
    }
}
