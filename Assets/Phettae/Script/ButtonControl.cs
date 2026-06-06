using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonControl : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject pinPos;

    private void Start()
    {
        pinPos.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        pinPos.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        pinPos.SetActive(false);
    }
}
