using UnityEngine;
using System.Collections;

public class DartsMover : MonoBehaviour {


    int score = 0;

    Vector3 newPos;
    Vector3 startPos;
    float progress = 0f;

	// Use this for initialization
	void Start ()
    {
        this.NewCoords();
	}
	
	// Update is called once per frame
	void Update ()
    {
        this.transform.position = Vector3.Lerp(this.startPos, this.newPos, this.progress);

        this.progress += Time.deltaTime * (0.5f + (this.score / 10));

        if (this.progress >= 1f)
        {
            this.NewCoords();
        }
	}


    void NewCoords()
    {
        this.startPos = this.transform.position;
        this.newPos = new Vector3(Random.Range(-6.5f, 6f), Random.Range(4f, 16f), 11f);
        this.progress = 0f;
    }


    void OnTriggerEnter(Collider other)
    {
        this.NewCoords();
        this.score++;
        Debug.Log("Score: " + this.score.ToString());
    }


}
