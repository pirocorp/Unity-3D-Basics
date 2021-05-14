using UnityEngine;
using System.Collections;

public class ShooterScript : MonoBehaviour
{
    //1. Използвайте аксисите "Horizontal", "Vertical" и "Mouse X" за да напраите контролер за движение. Hint - Transform.Translate, Transform.Rotate
    //2. Добавете код, с който при натикане на левия бутон на мишката да се инстанцира и изтрелва  куршум, който представлява елементарен куб или сфера.
    //3. Куршумът трябва да се изтрелва от позицията на оръжието, което е дете на този обект и да лети в права посока и да се самоунищожи след 2 секунди съществуване.

    public GameObject bulletPosition;
    public GameObject Rocket;
    public GameObject gun;
    float moveSpeed = 10f;
    float rotationSpeed = 80f;
	
    void Start()
    {
		
    }
	
	// Update is called once per frame
	void Update ()
	{
		
	}
}
