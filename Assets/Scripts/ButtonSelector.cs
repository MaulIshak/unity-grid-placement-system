using UnityEngine;
using UnityEngine.UI;

public class ButtonSelector : MonoBehaviour
{
    public Color selectedColor;
    public Color normalColor;
    private static ButtonSelector currentSelected;
    private Button button;
    private Image image;

    void Awake()
    {
        button = GetComponent<Button>();
        image = GetComponent<Image>();

        button.onClick.AddListener(OnSelect);
    }

    void OnSelect()
    {
        if (currentSelected != null && currentSelected != this)
            currentSelected.Deselect();

        currentSelected = this;
        image.color = selectedColor;
    }

    void Deselect()
    {
        image.color = normalColor;
    }
}