using UnityEngine;

public class PointScript : MonoBehaviour
{
    public float radius = 5.0f;
    public float force = 10f;

    void Start()
    {
        Vector3 boomPosition = transform.position;
        Collider[] colliders = Physics.OverlapSphere(boomPosition, radius);
        foreach (Collider c in colliders)
        {
            Rigidbody rb = GetComponent<Rigidbody>();
            if (rb != null)
                rb.AddExplosionForce(force, boomPosition, radius, 3.0f);
        }
    }
}
