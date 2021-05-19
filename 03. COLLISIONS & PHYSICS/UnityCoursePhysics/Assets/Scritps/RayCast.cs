using UnityEngine;

public class RayCast : MonoBehaviour 
{
	public float hitForce = 50;
	public float explosionRadius = 10;

	// Update is called once per frame
	void Update () 
	{
		if (Input.GetMouseButtonDown (0)) 
		{
			var ray = GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);

			if(Physics.Raycast(ray, out var hit, 40F))
			{
				hit.rigidbody.AddForceAtPosition(ray.direction * this.hitForce, hit.point);
				Debug.Log ("hit: " + hit.collider.name);
				Debug.Log("hit: " + hit.rigidbody.velocity);
			}
		}
        
	}
}
