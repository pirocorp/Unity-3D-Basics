using UnityEngine;

public class MoveScript : MonoBehaviour
{
    private Rigidbody rb;

    [SerializeField]
    private float speed = 17;

    private Vector3 rotationRight = new Vector3(0, 30, 0);
    private Vector3 rotationLeft = new Vector3(0, -30, 0);

    private Vector3 forward = new Vector3(0, 0, 1);
    private Vector3 backward = new Vector3(0, 0, -1);

    public void Start()
    {
        this.rb = this.GetComponent<Rigidbody>();
    }

    public void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            this.transform.Translate(this.forward * this.speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            this.transform.Translate(this.backward * this.speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            var deltaRotationRight = Quaternion.Euler(this.rotationRight * Time.deltaTime);
            this.rb.MoveRotation(this.rb.rotation * deltaRotationRight);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            var deltaRotationLeft = Quaternion.Euler(this.rotationLeft * Time.deltaTime);
            this.rb.MoveRotation(this.rb.rotation * deltaRotationLeft);
        }
    }
}
