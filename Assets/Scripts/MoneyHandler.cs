using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyHandler : MonoBehaviour
{
    [SerializeField] private TMP_Text priceList;
    private float modelPrice, extrasPrice, totalPrice;

    public void RefactorPrice (float price, bool model)
    {
        if (model)
        {
            modelPrice = price;
        }
        else
        {
            extrasPrice = price;
        }

        totalPrice = modelPrice + extrasPrice;

        priceList.text = ("Model: £" + System.Math.Round(modelPrice, 2).ToString() + "\nExtras: £" + System.Math.Round(extrasPrice, 2) + "\nTotal: £" + System.Math.Round(totalPrice, 2));
    }
}
