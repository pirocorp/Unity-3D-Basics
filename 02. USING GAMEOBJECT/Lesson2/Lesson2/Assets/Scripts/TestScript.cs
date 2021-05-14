using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
		Debug.Log(this.transform.gameObject.tag);
		Debug.Log(this.transform.gameObject.layer);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Spawn()
	{
		Debug.Log("Spawn");
	}
}
