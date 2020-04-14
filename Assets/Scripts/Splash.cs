using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Splash : MonoBehaviour
{
    public Image Logo;
    public Image Title;
    public Action SplashDone;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PlayIntro());
    }

    IEnumerator PlayIntro()
    {
        yield return new WaitForSeconds(3);
        Logo.gameObject.SetActive(false);
        Title.gameObject.SetActive(true);
        yield return new WaitForSeconds(3);
        SplashDone.Invoke();
    }
}
