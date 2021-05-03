// ReSharper disable ArrangeTypeMemberModifiers
// ReSharper disable CheckNamespace
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnassignedField.Global

using UnityEngine;

public class FollowScript : MonoBehaviour
{
    public Transform sphere;
    public float followSpeed;
    public float minDistance;

    // Update is called once per frame
	void LateUpdate ()
    {
        if (this.sphere != null)
        {
            this.transform.LookAt(this.sphere);

            if (Vector3.Distance(this.transform.position, this.sphere.position) > this.minDistance)
            {
                this.transform.Translate(0F, 0F, this.followSpeed * Time.deltaTime);
            }
        }
    }
}
