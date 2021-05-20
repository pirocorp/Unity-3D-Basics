// ReSharper disable CheckNamespace
using UnityEngine;

using static Assets.Scripts.GlobalConstants;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 movingVectorHorizontal;
    private Vector3 movingVectorVertical;
    private Vector3 jumpVector;
    private bool isInAir = false;

    private float inAir = 0;
    
    [SerializeField] 
    private float speed = 10;

    [SerializeField] 
    private float rotationSpeed = 3;

    [SerializeField]
    private Camera cameraObject;

    public void Start()
    {
        this.rb = this.GetComponent<Rigidbody>();
    }

    public void FixedUpdate()
    {
        this.ProcessKeyboardMovement();

        // var movement = new Vector3(- Input.GetAxis(Axis.Horizontal), 0F, - Input.GetAxis(Axis.Vertical));
        // this.transform.Translate(movement * Time.deltaTime * this.speed);
        // this.rigidbody.AddForce(movement * this.speed);

        // Moving velocity per keyboard input
        var newVector = this.movingVectorVertical + this.movingVectorHorizontal + this.jumpVector;
        this.rb.velocity = newVector;

        // Player per mouse input
        this.rb.rotation = Quaternion.Euler(this.rb.rotation.eulerAngles + new Vector3(0F, Input.GetAxis(Axis.MouseX), 0F) * this.rotationSpeed);

        // Camera orientation on Y axis
        this.cameraObject.transform.Rotate(new Vector3(- Input.GetAxis(Axis.MouseY), 0F, 0F) * this.rotationSpeed);
    }

    public void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == Tags.Floor)
        {
            this.isInAir = false;

            this.inAir = 0F;
        }
    }

    private void ProcessKeyboardMovement()
    {
        // Vertical movement
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            this.movingVectorVertical = -this.transform.forward * this.speed;
        }
        else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            this.movingVectorVertical = this.transform.forward * this.speed;
        }
        else
        {
            this.movingVectorVertical = Vector3.zero;
        }

        // Horizontal movement
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            this.movingVectorHorizontal = this.transform.right * this.speed;
        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            this.movingVectorHorizontal = -this.transform.right * this.speed;
        }
        else
        {
            this.movingVectorHorizontal = Vector3.zero;
        }

        // Jump movement
        if (Input.GetAxis(Axis.Jump) > 0 && !this.isInAir)
        {
            this.jumpVector = new Vector3(0, 10, 0);
            this.isInAir = true;
            this.inAir += Time.deltaTime;
        }
        else
        {
            this.inAir += Time.deltaTime;

            if (this.inAir >= 0.5F)
            {
                this.jumpVector = Physics.gravity;
                this.inAir = 0F;
            }
        }
    }
}
