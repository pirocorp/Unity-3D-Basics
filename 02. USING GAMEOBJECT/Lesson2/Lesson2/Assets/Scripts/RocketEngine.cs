using UnityEngine;
using System.Collections;

public class RocketEngine : MonoBehaviour {


    float timeOut = 3;
    float speed = 10;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		// Vector3.forward global forward
		//transform.forward 
		//transform.position += this.transform.forward * (Time.deltaTime * speed);
        this.transform.Translate(0f, 0f, Time.deltaTime * this.speed);


        this.timeOut -= Time.deltaTime;	// 0.02s
        if (this.timeOut <= 0f)
        {
            Destroy(this.gameObject);
        }
	}



}
