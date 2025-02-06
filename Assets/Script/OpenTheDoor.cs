using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenTheDoor : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OTD();
            Debug.Log("Openthedoor");
        }
    }

    private void OTD()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
