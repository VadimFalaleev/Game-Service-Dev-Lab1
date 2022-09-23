using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnCubesScript : MonoBehaviour
{
    [SerializeField] GameObject panel; // Определяем объект Panel на сцене.
    [SerializeField] InputField Field; // Определяем строку ввода на сцене.
    [SerializeField] GameObject cube; // Определяем объект, который будем генерировать.
    [SerializeField] GameObject cubePointMin; 
    [SerializeField] GameObject cubePointMax; // Определяем объекты, служащие границей для генерации объектов.
    [SerializeField] List<Vector3> spawnPoints = new(); // Определяем список, где будут хранится координаты, куда могут генерироваться объекты.

    public void Awake()
    {
        Time.timeScale = 0; // При запуске проект будет на паузе.
    }

    public void GenerateButton() // Этот метод бдует работать после нажатия кнопки.
    {
        GetPosition();

        panel.SetActive(false); // Закрываем панель.
        Time.timeScale = 1; // Убираем проект с паузы.

        for (int i = 0; i < int.Parse(Field.text); i++)
            Instantiate(cube, spawnPoints[i], cube.transform.rotation); // Генерируем нужно количество объектов.
    }

    private void GetPosition()
    {
        float cubePointMinX = cubePointMin.transform.position.x;
        float cubePointMinZ = cubePointMin.transform.position.z;
        float cubePointMaxX = cubePointMax.transform.position.x;
        float cubePointMaxZ = cubePointMax.transform.position.z; // Записываем координаты Х и Z границ для удобства.

        for (int i = 0; i < int.Parse(Field.text); i++)
        {
            Vector3 newPoint = new(
                Random.Range(cubePointMinX, cubePointMaxX),
                cubePointMax.transform.position.y,
                Random.Range(cubePointMinZ, cubePointMaxZ)); // Определяем точку, куда будем генерировать объект.

            if (!spawnPoints.Contains(newPoint))
                spawnPoints.Add(newPoint);  // Добавляем точку в список, если такой еще нет.
        }
    }
}