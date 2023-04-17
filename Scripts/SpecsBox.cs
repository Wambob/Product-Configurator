using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpecsBox : MonoBehaviour
{
    [SerializeField] private Image speedBar, accelerationBar, handlingBar;
    [SerializeField] private float blendSpeed;

    private float speed, acceleration, handling, blend;

    private void Update()
    {
        blend = blendSpeed * Time.deltaTime;

        speedBar.fillAmount = Mathf.Lerp(speedBar.fillAmount, speed, blend);
        accelerationBar.fillAmount = Mathf.Lerp(accelerationBar.fillAmount, acceleration, blend);
        handlingBar.fillAmount = Mathf.Lerp(handlingBar.fillAmount, handling, blend);
    }

    public void ConfigureValues(float newSpeed, float newAcceleration, float newHandling)
    {
        speed = newSpeed;
        acceleration = newAcceleration;
        handling = newHandling;
    }
}
