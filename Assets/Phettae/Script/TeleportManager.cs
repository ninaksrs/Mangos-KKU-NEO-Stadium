using UnityEngine;

public class TeleportManager : MonoBehaviour
{
    public GameObject[] teleposPos;

    public void Teleport(int index)
    {
        if (index >= 0 && index < teleposPos.Length)
        {
            transform.position = teleposPos[index].transform.position;
        }
        else
        {
            Debug.LogWarning("Invalid teleport index: " + index);
        }
    }
}
