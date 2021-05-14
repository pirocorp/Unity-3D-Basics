using UnityEngine;
using System.Collections;

public class Inspector : MonoBehaviour
{
    GameObject[] player;
    GameObject[] enemy;
	

	// Use this for initialization
	void Start ()
    {
    	GameObject sph = GameObject.Find("Sphere");
    	sph.transform.Translate(0f, 10f, 0f);
        this.player = GameObject.FindGameObjectsWithTag("Player");
        this.enemy = GameObject.FindGameObjectsWithTag("Enemy");

        //Debug.Log("Player.Length: " + Player.Length.ToString());
        //Debug.Log("Enemy.Length: " + Enemy.Length.ToString());
        
        GameObject go = Resources.Load ("Sphere") as GameObject;

		Instantiate (go);
		go.transform.position = Vector3.zero;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (this.enemy != null)
        {
            foreach (GameObject go in this.enemy)
            {
                go.transform.Translate(Vector3.forward * Time.deltaTime);
            }
        }
	}
}
