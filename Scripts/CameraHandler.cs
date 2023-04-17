using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CameraHandler : MonoBehaviour
{
    [SerializeField] private RenderTexture texture;
    [SerializeField] private RawImage transitionImage;
    [SerializeField] private GameObject[] dynamicAnchors;
    [SerializeField] private GameObject[] staticAnchors;
    [SerializeField] private Camera main, transition;
    [SerializeField] private TMP_Dropdown cameraDropdown;
    [SerializeField] private float transitionAlpha, fadeSpeed;
    [SerializeField] private bool anchorBool;

    private GameObject mainAnchor, transitionAnchor;
    private int currentAnchor, nextAnchor;
    private float fadeProgress;
    private bool tourMode = true;

    private void Start()
    {
        texture.width = Screen.width;
        texture.height = Screen.height;
    }

    private void Update()
    {
        if (tourMode)
        {
            transitionImage.color = new Color(1, 1, 1, transitionAlpha);
            main.transform.position = mainAnchor.transform.position;
            main.transform.rotation = mainAnchor.transform.rotation;
            transition.transform.position = transitionAnchor.transform.position;
            transition.transform.rotation = transitionAnchor.transform.rotation;
        }
        else if (fadeProgress <= 1)
        {
            fadeProgress += fadeSpeed * Time.deltaTime;
            transitionImage.color = new Color(1, 1, 1, fadeProgress);
        }
    }

    public void CameraChange()
    {
        if (fadeProgress >= 1)
        {
            fadeProgress = 0;
        }

        if (cameraDropdown.value == 0)
        {
            tourMode = true;
        }
        else
        {
            tourMode = false;

            currentAnchor = nextAnchor;
            nextAnchor = cameraDropdown.value - 1;

            main.gameObject.transform.position = staticAnchors[currentAnchor].transform.position;
            main.gameObject.transform.rotation = staticAnchors[currentAnchor].transform.rotation;
            transition.gameObject.transform.position = staticAnchors[nextAnchor].transform.position;
            transition.gameObject.transform.rotation = staticAnchors[nextAnchor].transform.rotation;
        }
    }

    public void SetMain()
    {
        if (anchorBool)
        {
            mainAnchor = dynamicAnchors[1];
        }
        else
        {
            mainAnchor = dynamicAnchors[0];
        }
    }

    public void SetTransition()
    {
        if (anchorBool)
        {
            transitionAnchor = dynamicAnchors[0];
        }
        else
        {
            transitionAnchor = dynamicAnchors[1];
        }
    }
}