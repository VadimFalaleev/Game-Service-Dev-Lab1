using UnityEngine;

public class PlaneScript : MonoBehaviour
{
    [SerializeField] float radius = 5.0f; // ������ ������
    [SerializeField] float force = 10f; // ���� ������

    [SerializeField] GameObject prefabPoint; // ���������� ������ Point
    [SerializeField] GameObject prefabSpawnSphere; // ���������� ������ SpawnSphere

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
            foreach (Collider � in colliders) // ����������� �� ������� �������� ������� � ���������� �� ������ � �������, �������� ����� ������(�� ������)
            {
                Rigidbody rb = GetComponent<Rigidbody>();
                if (rb != null)
                    rb.AddExplosionForce(force, boomPosition, radius, 3.0f);
            }
        }
    }
}