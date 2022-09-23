using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnCubesScript : MonoBehaviour
{
    [SerializeField] GameObject panel; // ���������� ������ Panel �� �����.
    [SerializeField] InputField Field; // ���������� ������ ����� �� �����.
    [SerializeField] GameObject cube; // ���������� ������, ������� ����� ������������.
    [SerializeField] GameObject cubePointMin; 
    [SerializeField] GameObject cubePointMax; // ���������� �������, �������� �������� ��� ��������� ��������.
    [SerializeField] List<Vector3> spawnPoints = new(); // ���������� ������, ��� ����� �������� ����������, ���� ����� �������������� �������.

    public void Awake()
    {
        Time.timeScale = 0; // ��� ������� ������ ����� �� �����.
    }

    public void GenerateButton() // ���� ����� ����� �������� ����� ������� ������.
    {
        GetPosition();

        panel.SetActive(false); // ��������� ������.
        Time.timeScale = 1; // ������� ������ � �����.

        for (int i = 0; i < int.Parse(Field.text); i++)
            Instantiate(cube, spawnPoints[i], cube.transform.rotation); // ���������� ����� ���������� ��������.
    }

    private void GetPosition()
    {
        float cubePointMinX = cubePointMin.transform.position.x;
        float cubePointMinZ = cubePointMin.transform.position.z;
        float cubePointMaxX = cubePointMax.transform.position.x;
        float cubePointMaxZ = cubePointMax.transform.position.z; // ���������� ���������� � � Z ������ ��� ��������.

        for (int i = 0; i < int.Parse(Field.text); i++)
        {
            Vector3 newPoint = new(
                Random.Range(cubePointMinX, cubePointMaxX),
                cubePointMax.transform.position.y,
                Random.Range(cubePointMinZ, cubePointMaxZ)); // ���������� �����, ���� ����� ������������ ������.

            if (!spawnPoints.Contains(newPoint))
                spawnPoints.Add(newPoint);  // ��������� ����� � ������, ���� ����� ��� ���.
        }
    }
}