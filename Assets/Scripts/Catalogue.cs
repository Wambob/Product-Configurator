using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Catalogue : MonoBehaviour
{
    [SerializeField] private CatalogueItems[] items;
    [SerializeField] private TMP_Dropdown modelDropdown;
    [SerializeField] private MoneyHandler moneyHandler;
    [SerializeField] private SpecsBox specsBox;

    private int currentID;

    private void Start()
    {
        ChangeModel();
    }

    public void ChangeModel()
    {
        print("Changed");

        items[currentID].car.SetActive(false);
        items[modelDropdown.value].car.SetActive(true);

        currentID = modelDropdown.value;
        moneyHandler.RefactorPrice(items[modelDropdown.value].cost, true);
        specsBox.ConfigureValues(items[modelDropdown.value].speed, items[modelDropdown.value].acceleration, items[modelDropdown.value].handling);
    }

    public void ActivateDoors()
    {
        items[currentID].anim.SetTrigger("Doors");
    }
}

[System.Serializable]
public struct CatalogueItems
{
    public GameObject car;
    public Animator anim;
    public float cost, speed, acceleration, handling;
}