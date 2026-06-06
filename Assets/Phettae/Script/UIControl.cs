using UnityEngine;

public class UIControl : MonoBehaviour
{
    public GameObject uiPanel;
    public bool _isPanelActive;

    private void Start()
    {
        uiPanel.SetActive(false);
        _isPanelActive = false;
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.E) && !_isPanelActive)
        {
            uiPanel.SetActive(true);
            _isPanelActive = true;
        }
        else if (Input.GetKeyUp(KeyCode.E) && _isPanelActive)
        {
            uiPanel.SetActive(false);
            _isPanelActive = false;
        }
    }
}
