using UnityEngine;

public class PlaneScript : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Sphere")
            Destroy(collision.gameObject);
    }
}
