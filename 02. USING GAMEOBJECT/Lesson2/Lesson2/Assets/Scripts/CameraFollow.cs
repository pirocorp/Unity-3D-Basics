using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] 
    private Transform target;

    [SerializeField]
    private Vector3 offset;

    public void Update()
    {
        this.transform.position = this.target.position + this.offset;
    }
}
