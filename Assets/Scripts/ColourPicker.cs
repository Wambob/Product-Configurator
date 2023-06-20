using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ColourPicker : MonoBehaviour
{
    [SerializeField] private SliderClass[] sliders;
    [SerializeField] private Image preview;
    [SerializeField] private Material paintJob;

    private Color previewColour;

    private void Start()
    {
        previewColour = new Color(0, 0, 0);
        preview.color = previewColour;
        paintJob.color = previewColour;
    }

    public void UpdatePreview(int sliderID)
    {
        previewColour = new Color(sliders[0].slider.value, sliders[1].slider.value, sliders[2].slider.value);

        switch (sliderID)
        {
            case (0):
                sliders[1].UpdateValues(previewColour);
                sliders[2].UpdateValues(previewColour);
                break;
            case (1):
                sliders[0].UpdateValues(previewColour);
                sliders[2].UpdateValues(previewColour);
                break;
            case (2):
                sliders[0].UpdateValues(previewColour);
                sliders[1].UpdateValues(previewColour);
                break;
        }

        preview.color = previewColour;
    }

    public void ApplyCustomPaint()
    {
        paintJob.color = previewColour;
    }
}

[System.Serializable]
public class SliderClass
{
    public string name;
    public int ID;
    public Image gradient, background;
    public Slider slider;

    public void UpdateValues(Color previewColour)
    {
        switch (ID)
        {
            case (0):
                gradient.color = new Color(0, previewColour.g, previewColour.b);
                background.color = new Color(1, previewColour.g, previewColour.b);
                break;
            case (1):
                gradient.color = new Color(previewColour.r, 0, previewColour.b);
                background.color = new Color(previewColour.r, 1, previewColour.b);
                break;
            case (2):
                gradient.color = new Color(previewColour.r, previewColour.g, 0);
                background.color = new Color(previewColour.r, previewColour.g, 1);
                break;
        }
    }
}
