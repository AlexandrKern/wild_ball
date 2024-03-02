using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    [SerializeField] private GameObject _startGamePanel;

    private GameObject _currentPanel;


    void Awake()
    {
        _currentPanel = _startGamePanel;
        _currentPanel.SetActive(true);
    }
    
    public void ChangePanel(GameObject panel)
    {
        _currentPanel.SetActive(false);
        panel.SetActive(true);
        _currentPanel = panel;
    }

    public static void FinalPanel(GameObject finalPanel)
    {
        finalPanel.SetActive(true);
    }

    public static void DisableButton (Button button) 
    {
        button.gameObject.SetActive(false);
    }
}
