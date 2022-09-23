using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnCubesScript : MonoBehaviour
{
    [SerializeField] public GameObject panel;
    [SerializeField] public GameObject cube;
    [SerializeField] InputField Field;
    [SerializeField] public List<Vector3> spawnPoints = new List<Vector3>();
    [SerializeField] public GameObject cubePointMin;
    [SerializeField] public GameObject cubePointMax;

    public void Awake()
    {
        if(panel.activeSelf)
            Time.timeScale = 0;
    }

    public void GenerateButton()
    {
        GetPosition();

        panel.SetActive(false);
        Time.timeScale = 1;

        for (int i = 0; i < int.Parse(Field.text); i++)
            Instantiate(cube, spawnPoints[i], cube.transform.rotation);
    }

    private void GetPosition()
    {
        float cubePointMinX = cubePointMin.transform.position.x;
        float cubePointMinZ = cubePointMin.transform.position.z;
        float cubePointMaxX = cubePointMax.transform.position.x;
        float cubePointMaxZ = cubePointMax.transform.position.z;

        for (int i = 0; i < int.Parse(Field.text); i++)
        {
            Vector3 newPoint = new Vector3(
                Random.Range(cubePointMinX, cubePointMaxX),
                cubePointMax.transform.position.y,
                Random.Range(cubePointMinZ, cubePointMaxZ));

            if (!spawnPoints.Contains(newPoint))
                spawnPoints.Add(newPoint);
        }
    }
}
