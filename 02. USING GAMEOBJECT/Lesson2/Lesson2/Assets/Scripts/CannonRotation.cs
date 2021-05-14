using UnityEngine;
using System.Collections;

public class CannonRotation : MonoBehaviour
{
    Vector3 positionToLookAt = new Vector3(0.28f, 1.89f, 10.72f);
    Camera mainCamera;
	
    void Start()
    {
        this.mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
    }


	// Update is called once per frame
	void Update ()
    {

#if UNITY_EDITOR || UNITY_STANDALONE
        this.positionToLookAt = this.mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 30f));

        this.transform.position = new Vector3(this.transform.position.x + (Input.GetAxis("Horizontal") * Time.deltaTime), this.transform.position.y, this.transform.position.z);

#elif UNITY_IPHONE || UNITY_ANDROID
        if (Input.touchCount > 0)
        {
            positionToLookAt = mainCamera.ScreenToWorldPoint(new Vector3(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y, 30f));
        }
#endif

        this.transform.LookAt(this.positionToLookAt);
        this.transform.eulerAngles = new Vector3(0f, this.transform.localRotation.eulerAngles.y, 0f);
    }
}
