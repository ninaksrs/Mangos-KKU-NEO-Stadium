using UnityEngine;

public class Shine : MonoBehaviour
{
    public GameObject ui;
    private bool isUIActive = false;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.E) && !isUIActive)
            {
                ui.SetActive(true);
            }
            else if (Input.GetKeyUp(KeyCode.E) && isUIActive)
            {
                ui.SetActive(false);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ui.SetActive(false);
        }
    }
}
