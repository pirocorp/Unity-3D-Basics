using UnityEngine;

public class DartsMover : MonoBehaviour {
    private int score = 0;

    private Vector3 newPos;
    private Vector3 startPos;
    private float progress = 0F;

	// Use this for initialization
	void Start ()
    {
        this.NewCoords();
	}
	
	// Update is called once per frame
	void Update ()
    {
        this.transform.position = Vector3.Lerp(this.startPos, this.newPos, this.progress);

        this.progress += Time.deltaTime * (0.5F + (this.score / 10));

        if (this.progress >= 1F)
        {
            this.NewCoords();
        }
	}

    void NewCoords()
    {
        this.startPos = this.transform.position;
        this.newPos = new Vector3(Random.Range(-6.5F, 6F), Random.Range(4F, 16F), 11F);
        this.progress = 0F;
    }

    void OnTriggerEnter(Collider other)
    {
        this.NewCoords();
        this.score++;
        Debug.Log("Score: " + this.score.ToString());
    }
}
