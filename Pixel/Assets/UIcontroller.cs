
using UnityEngine;

public class UIcontroller : MonoBehaviour

{
    [SerializeField] private Transform _canvasParentTransform;
    [SerializeField] private GameObject _uiPopupMenu;
    private bool _isPause;
    void Start()
    {
        GameObject popupMenu = Instantiate(_uiPopupMenu);
        popupMenu.transform.SetParent(_canvasParentTransform, false);
        RectTransform rectTransform = popupMenu.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = Vector2.zero;
        rectTransform.sizeDelta = new Vector2(500, 400);

      //  Time.timeScale = 0f;
    }
    
}
