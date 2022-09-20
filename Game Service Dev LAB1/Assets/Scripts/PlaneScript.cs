using UnityEngine;

public class PlaneScript : MonoBehaviour
{
    [SerializeField] public float radius = 5.0f; // ������ ������
    [SerializeField] public float force = 10f; // ���� ������

    [SerializeField] public GameObject prefabPoint; // ���������� ������ Point
    [SerializeField] public GameObject prefabSpawnSphere; // ���������� ������ SpawnSphere

    private void OnCollisionEnter(Collision collision) // ������������, ���� ���� ��������� �������� �������
    {
        if (collision.gameObject.name == "Sphere") // ���� ������ � ������ Sphere...
        {
            Destroy(collision.gameObject); // ... �� �� ������������
            Vector3 boomPosition = collision.gameObject.transform.position; // ���������� ������ �������
            Quaternion boomRotation = collision.gameObject.transform.rotation; // ���� �������� �������
            Instantiate(prefabPoint, boomPosition, boomRotation);
            Instantiate(prefabSpawnSphere, boomPosition, boomRotation); // ��������� ������� �� ����� � ��� ��� �����, ��� ����������� ������ Sphere

            Collider[] colliders = Physics.OverlapSphere(boomPosition, radius); // ������� ������ ����������� � ���������� � ���� ��, ������� ���������
                                                                                // � ������� �����, ��� ����������� ������ Sphere
            foreach (Collider c in colliders) // ����������� �� ������� �������� ������� � ���������� �� ������ � �������, �������� ����� ������(�� ������)
            {
                Rigidbody rb = GetComponent<Rigidbody>();
                if (rb != null)
                    rb.AddExplosionForce(force, boomPosition, radius, 3.0f);
            }
        }
    }
}