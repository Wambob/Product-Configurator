using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PaintApplier : MonoBehaviour
{
    [SerializeField] private Material paintJob;
    [SerializeField] private TMP_Dropdown colourDropdown;
    [SerializeField] private ColourPicker colourPicker;
    [SerializeField] private ColourEntry[] colours;
    [SerializeField] private MoneyHandler moneyHandler;

    private void Start()
    {
        ChangePaint();
    }

    public void ChangePaint()
    {
        if (colourDropdown.value == 0)
        {
            colourPicker.gameObject.SetActive(true);
        }
        else
        {
            colourPicker.gameObject.SetActive(false);

            paintJob.color = colours[colourDropdown.value].colour;
        }

        moneyHandler.RefactorPrice(colours[colourDropdown.value].cost, false);
    }
}

[System.Serializable]
public struct ColourEntry
{
    public Color colour;
    public int cost;
}
