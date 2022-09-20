using UnityEngine;

public class PlaneScript : MonoBehaviour
{
    [SerializeField] public float radius = 5.0f; // Радиус взрыва
    [SerializeField] public float force = 10f; // Сила взрыва

    [SerializeField] public GameObject prefabPoint; // Используем префаб Point
    [SerializeField] public GameObject prefabSpawnSphere; // Используем префаб SpawnSphere

    private void OnCollisionEnter(Collision collision) // Активируется, если один коллайдер касается другого
    {
        if (collision.gameObject.name == "Sphere") // Если объект с именем Sphere...
        {
            Destroy(collision.gameObject); // ... то он уничтожается
            Vector3 boomPosition = collision.gameObject.transform.position; // Координаты центра объекта
            Quaternion boomRotation = collision.gameObject.transform.rotation; // Угол поворота объекта
            Instantiate(prefabPoint, boomPosition, boomRotation);
            Instantiate(prefabSpawnSphere, boomPosition, boomRotation); // Создаются префабы на месте и под тем углом, где уничтожился объект Sphere

            Collider[] colliders = Physics.OverlapSphere(boomPosition, radius); // Создаем массив коллайдеров и записываем в него те, которые находятся
                                                                                // в радиусе места, где уничтожился объект Sphere
            foreach (Collider c in colliders) // Пробегаемся по каждому элементу массива и заставляем их лететь в сторону, обратную точки взрыва(от центра)
            {
                Rigidbody rb = GetComponent<Rigidbody>();
                if (rb != null)
                    rb.AddExplosionForce(force, boomPosition, radius, 3.0f);
            }
        }
    }
}