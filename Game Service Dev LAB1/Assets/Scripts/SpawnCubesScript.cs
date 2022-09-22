using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnCubesScript : MonoBehaviour
{
    [SerializeField] public GameObject panel;
    [SerializeField] public GameObject cube;
    [SerializeField] InputField Field;
    [SerializeField] public List<Transform> spawnPoints= new List<Transform>();

    public void Start()
    {
        Time.timeScale = 0;
    }

    private void GenerateButton()
    {
        panel.SetActive(false);
        Time.timeScale = 1;

        for(int i = 0; i < int.Parse(Field.text); i++)
        {
            
        }
    }
}
