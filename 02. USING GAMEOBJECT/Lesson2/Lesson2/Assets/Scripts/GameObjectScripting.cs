using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameObjectScripting : MonoBehaviour
{
#if DEMO
	// Update is called once per frame
	void Update () 
	{
		//transform.Translate(Input.GetAxis("Horizontal") * Time.deltaTime, 0f, Input.GetAxis("Vertical") * Time.deltaTime);
		Debug.Log("Demo");
	}
#endif
}
