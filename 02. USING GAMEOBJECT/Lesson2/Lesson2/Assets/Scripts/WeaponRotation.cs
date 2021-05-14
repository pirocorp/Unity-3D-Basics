using UnityEngine;
using System.Collections;

public class WeaponRotation : MonoBehaviour
{
    Camera mainCamera;
    public GameObject Rocket;
    public GameObject leftPostion;
    public GameObject rightPosition;

    Vector3 posToFace = new Vector3(0.28f, 1.89f, 10.72f);

    void Start()
    {
        this.mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
    }


    // Update is called once per frame
    void Update()
    {

#if UNITY_EDITOR || UNITY_STANDALONE
        this.posToFace = this.mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 40f));

#elif UNITY_IPHONE || UNITY_ANDROID
        if (Input.touchCount > 0)
        {
            posToFace = mainCamera.ScreenToWorldPoint(new Vector3(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y, 40f));
        }
#endif

        this.transform.LookAt(this.posToFace);

        this.transform.localRotation = Quaternion.Euler(this.transform.eulerAngles.x, 0f, 0f);


        if (Input.GetMouseButtonDown(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
        {
            GameObject go = Instantiate(this.Rocket);
            go.transform.position = this.leftPostion.transform.position;
            go.transform.LookAt(this.posToFace);
            go.AddComponent<RocketEngine>();

            go = Instantiate(this.Rocket);
            go.transform.position = this.rightPosition.transform.position;
            go.transform.LookAt(this.posToFace);
            go.AddComponent<RocketEngine>();
        }
    }
}
