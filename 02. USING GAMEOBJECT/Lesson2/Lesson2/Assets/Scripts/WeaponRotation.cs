using UnityEngine;

public class WeaponRotation : MonoBehaviour
{
    private Camera mainCamera;

    [SerializeField] 
    private GameObject rocket;

    [SerializeField] 
    private GameObject leftPosition;

    [SerializeField] 
    private GameObject rightPosition;

    Vector3 posToFace = new Vector3(0.28f, 1.89f, 10.72f);

    void Start()
    {
        this.mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
    }


    // Update is called once per frame
    void Update()
    {

#if UNITY_EDITOR || UNITY_STANDALONE
        this.posToFace = this.mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 40F));

#elif UNITY_IPHONE || UNITY_ANDROID
        if (Input.touchCount > 0)
        {
            posToFace = mainCamera.ScreenToWorldPoint(new Vector3(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y, 40f));
        }
#endif

        this.transform.LookAt(this.posToFace);

        this.transform.localRotation = Quaternion.Euler(this.transform.eulerAngles.x, 0F, 0F);


        if (Input.GetMouseButtonDown(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
        {
            var go = Instantiate(this.rocket);
            go.transform.position = this.leftPosition.transform.position;
            go.transform.LookAt(this.posToFace);
            go.AddComponent<RocketEngine>();

            go = Instantiate(this.rocket);
            go.transform.position = this.rightPosition.transform.position;
            go.transform.LookAt(this.posToFace);
            go.AddComponent<RocketEngine>();
        }
    }
}
