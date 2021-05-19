using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    [SerializeField]
    private float speedKoef = 0.5f;

    [SerializeField]
    private float mouseSpeedX = 1f;

    [SerializeField]
    private float mouseSpeedY = 1f;

    [SerializeField]
    private float jumpForce = 1f;

    [SerializeField]
    private float gravityInAir = 40f;

    [SerializeField]
    private float normalGravity = 9.8f;

    [SerializeField]
    private float maxMovingSpeed = 15;

    [SerializeField]
    private float dampTime = 2;

    [SerializeField]
    private bool isGrounded;

    private float mouseLookVertical;
    private float mouseLookHorizontal;
    private float dampVolumeX;
    private float dampVolumeZ;
    private Camera playerCamera;
    private Vector2 movementVector;

    Rigidbody attachedRigidbody;

    private void Start()
    {
        this.playerCamera = Camera.main;
        Physics.gravity = -Vector3.up * this.normalGravity;
        this.attachedRigidbody = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(Input.GetAxis("Horizontal") * speedKoef, 0f, Input.GetAxis("Vertical") * speedKoef);
        this.movementVector = new Vector2(this.attachedRigidbody.velocity.x, this.attachedRigidbody.velocity.z);

        if (this.movementVector.magnitude > this.maxMovingSpeed)
        {
            this.movementVector.Normalize();
            this.movementVector *= this.maxMovingSpeed;
        }

        this.attachedRigidbody.velocity = new Vector3(this.movementVector.x, this.attachedRigidbody.velocity.y, this.movementVector.y);

        this.attachedRigidbody.AddRelativeForce(Input.GetAxis("Horizontal") * this.speedKoef, 0f, Input.GetAxis("Vertical") * this.speedKoef, ForceMode.Force);

        if (Input.GetAxis("Horizontal") == 0f && this.isGrounded)
        {
            this.attachedRigidbody.velocity = new Vector3(this.attachedRigidbody.velocity.x, this.attachedRigidbody.velocity.y, Mathf.SmoothDamp(this.attachedRigidbody.velocity.z, 0f, ref this.dampVolumeZ, this.dampTime));
        }

		if (Input.GetAxis("Vertical") == 0f && this.isGrounded)
		{
            this.attachedRigidbody.velocity = new Vector3(Mathf.SmoothDamp(this.attachedRigidbody.velocity.x, 0f, ref this.dampVolumeX, this.dampTime), this.attachedRigidbody.velocity.y, this.attachedRigidbody.velocity.z);
		}

        if (Input.GetKeyDown(KeyCode.Space)) this.Jump();

        this.mouseLookVertical = this.playerCamera.transform.localRotation.eulerAngles.x - (Input.GetAxis("Mouse Y") * this.mouseSpeedX);
        this.mouseLookHorizontal = this.transform.rotation.eulerAngles.y + (Input.GetAxis("Mouse X") * this.mouseSpeedY);

        if (this.mouseLookVertical <= 300 && this.mouseLookVertical >= 40)
            return;


        this.transform.localRotation = Quaternion.Euler(0f, this.mouseLookHorizontal, 0f);
        this.playerCamera.transform.localRotation = Quaternion.Euler(this.mouseLookVertical, 0f, 0f);
    }

    private void Jump()
    {
        Debug.Log("Jump");
        if (!this.isGrounded)
            return;

        this.attachedRigidbody.AddForce(Vector3.up * this.jumpForce);
        this.isGrounded = false;
        this.SetGravity(2);
    }

    /// <summary>
    /// type = 1 means normal gravity ; type = 2 means gravity in air
    /// </summary>
    /// <param name="type"></param>
    private void SetGravity(int type)
    {
        Physics.gravity = -Vector3.up * (type == 1 ? this.normalGravity : this.gravityInAir);
    }

    private void OnTriggerStay(Collider col)
    {
        if (col.tag == "Floor" && !this.isGrounded)
        {
            this.isGrounded = true;

            if (Physics.gravity != Vector3.up * this.normalGravity)
            {
                this.SetGravity(1);
            }
        }
    }
    
    private void OnTriggerEnter(Collider col)
    {
        Debug.Log("TriggerEnter");

        if (col.tag == "Floor" && !this.isGrounded)
        {
            this.isGrounded = true;
            this.SetGravity(1);
        }
    }

    private void OnTriggerExit(Collider col)
    {
        Debug.Log("TriggerExit");

        if (col.tag == "Floor" && this.isGrounded)
        {
            this.isGrounded = false;
            this.SetGravity(2);
        }
    }
}
