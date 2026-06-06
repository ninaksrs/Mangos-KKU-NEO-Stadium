using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PinControl : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject textTitle;

    private void Start()
    {
        textTitle.SetActive(false);    
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        textTitle.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        textTitle.SetActive(false);
    }
}
