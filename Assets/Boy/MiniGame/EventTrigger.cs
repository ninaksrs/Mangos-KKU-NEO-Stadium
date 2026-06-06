using StarterAssets;
using UnityEngine;

public class EventTrigger : MonoBehaviour
{
    public ThirdPersonController Player;
    public GameObject Trigger;
    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<ThirdPersonController>();
    }
    public GameObject EventOBJ;
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.GetComponent<ThirdPersonController>())
        {
            Trigger.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                //other.gameObject.SetActive(false);
                EventOBJ.SetActive(true);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<ThirdPersonController>())
        {
            Trigger.SetActive(false);
            EventOBJ.SetActive(false);

        }
    }
}
