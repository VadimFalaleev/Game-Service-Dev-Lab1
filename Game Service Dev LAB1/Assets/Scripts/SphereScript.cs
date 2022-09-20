using UnityEngine;

public class SphereScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("������ ���������� � " + other.gameObject.name);
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("��������� ������������ � " + other.gameObject.name);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Cube")
            collision.gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "Cube")
            collision.gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
    }
}
