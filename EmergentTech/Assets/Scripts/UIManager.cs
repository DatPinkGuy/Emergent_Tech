using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private int m_startingUILevel;
    private UIElement[] m_uiElement;

    private void Awake()
    {
        m_uiElement = FindObjectsOfType<UIElement>();
    }
    
    void Start()
    {
        ChangeElements(m_startingUILevel);
    }

    public void ChangeElements(int _level)
    {
        foreach (var element in m_uiElement)
        {
            if (_level != 0)
            {
                if (element.ElementLevel == -1)
                {
                    element.gameObject.SetActive(true);
                    continue;
                }
                element.gameObject.SetActive(element.ElementLevel == _level);
            }
            else element.gameObject.SetActive(element.ElementLevel == _level);
        }
    }
}
