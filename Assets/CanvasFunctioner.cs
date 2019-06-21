using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasFunctioner : MonoBehaviour
{
    public GameObject lightMcLightFace, mainCam, fpsCam;

    public void ContinueWithCharacter()
    {
        this.gameObject.SetActive(false);
        lightMcLightFace.SetActive(false);
        mainCam.SetActive(false);
        fpsCam.SetActive(true);
    }

    public void Update()
    {
        if (this.gameObject.activeSelf)
        {
            lightMcLightFace.SetActive(true);
        }
        else
        {
            lightMcLightFace.SetActive(false);
        }
    }
}
