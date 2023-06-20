using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public enum CamMode
{
    Tour, FreeView, Static
}

public class CameraHandler : MonoBehaviour
{
    [SerializeField] private RenderTexture texture;
    [SerializeField] private RawImage transitionImage;
    [SerializeField] private GameObject[] dynamicAnchors;
    [SerializeField] private GameObject[] staticAnchors;
    [SerializeField] private GameObject freeCamAnchor;
    [SerializeField] private Camera main, transition;
    [SerializeField] private TMP_Dropdown cameraDropdown;
    [SerializeField] private float transitionAlpha, fadeSpeed, lerpSpeed;
    [SerializeField] private bool anchorBool;

    private GameObject mainAnchor, transitionAnchor;
    private CamMode camMode = CamMode.Tour;
    private int currentAnchor, nextAnchor;
    private float fadeProgress;

    private void Start()
    {
        texture.width = Screen.width;
        texture.height = Screen.height;
    }

    private void Update()
    {
        if (camMode == CamMode.Tour)
        {
            transitionImage.color = new Color(1, 1, 1, transitionAlpha);
            main.transform.position = mainAnchor.transform.position;
            main.transform.rotation = mainAnchor.transform.rotation;
            transition.transform.position = transitionAnchor.transform.position;
            transition.transform.rotation = transitionAnchor.transform.rotation;
        }
        else if (camMode == CamMode.FreeView)
        {
            main.transform.position = Vector3.Lerp(main.transform.position, freeCamAnchor.transform.position, lerpSpeed * Time.deltaTime);
            main.transform.rotation = Quaternion.Lerp(main.transform.rotation, freeCamAnchor.transform.rotation, lerpSpeed * Time.deltaTime);
        }
        else if (camMode == CamMode.Static && fadeProgress <= 1)
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

        if (cameraDropdown.value != 1)
        {
            freeCamAnchor.SetActive(false);
        }

        if (cameraDropdown.value == 0)
        {
            camMode = CamMode.Tour;
        }
        else if (cameraDropdown.value == 1)
        {
            camMode = CamMode.FreeView;
            transitionImage.color = new Color(1, 1, 1, 0);
            freeCamAnchor.SetActive(true);
        }
        else
        {
            camMode = CamMode.Static;

            currentAnchor = nextAnchor;
            nextAnchor = cameraDropdown.value - 2;

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