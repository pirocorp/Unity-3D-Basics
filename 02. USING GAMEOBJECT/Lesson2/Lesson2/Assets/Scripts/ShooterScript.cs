using UnityEngine;

public class ShooterScript : MonoBehaviour
{
    //1. Използвайте аксисите "Horizontal", "Vertical" и "Mouse X" за да напраите контролер за движение. Hint - Transform.Translate, Transform.Rotate
    //2. Добавете код, с който при натикане на левия бутон на мишката да се инстанцира и изтрелва  куршум, който представлява елементарен куб или сфера.
    //3. Куршумът трябва да се изтрелва от позицията на оръжието, което е дете на този обект и да лети в права посока и да се самоунищожи след 2 секунди съществуване.

    private const float moveSpeed = 10F;

    private const float rotationSpeed = 80F;

    private Vector3 positionToLookAt = new Vector3(0.28F, 1.89F, 10.72F);

    private Camera mainCamera;

    [SerializeField]
    private GameObject bulletPosition;

    [SerializeField]
    private GameObject Rocket;

    [SerializeField]
    private GameObject gun;

    // Use this for initialization
    internal void Start()
    {
        this.mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
    }

    // Update is called once per frame
    internal void Update ()
	{
        this.transform.position = new Vector3(
            this.transform.position.x + GetHorizontalAxisOffset, 
            this.transform.position.y,
            this.transform.position.z + GetVerticalAxisOffset);

        this.transform.Rotate(0F, GetRotationMouseXOffset, 0F); 
    }

    private static float GetMoveOffset => moveSpeed * Time.deltaTime;

    private static float GetRotationOffset => rotationSpeed * Time.deltaTime;

    private static float GetHorizontalAxisOffset => Input.GetAxis("Horizontal") * GetMoveOffset;

    private static float GetVerticalAxisOffset => Input.GetAxis("Vertical") * GetMoveOffset;

    private static float GetRotationMouseXOffset => Input.GetAxis("Mouse X") * GetRotationOffset;
}
