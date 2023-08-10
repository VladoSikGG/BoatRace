using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenLevel : MonoBehaviour
{
    private void Start()
    {
        if (!PlayerPrefs.HasKey("openLevel") || PlayerPrefs.GetInt("openLevel") < 1)
            PlayerPrefs.SetInt("openLevel", 1);
    }
}
