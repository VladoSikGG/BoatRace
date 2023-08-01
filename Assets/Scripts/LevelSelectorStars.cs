using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectorStars : MonoBehaviour
{
    [SerializeField] private string _lvl;
    [SerializeField] private GameObject[] _objStars;

    private void Update()
    {
        for (int i = 0; i < PlayerPrefs.GetInt(_lvl); i++)
        {
            _objStars[i].SetActive(true);
        }
    }
}
