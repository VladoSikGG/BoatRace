using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AccesForLevel : MonoBehaviour
{
    [SerializeField] private GameObject _lock;
    [SerializeField] private int _lvlNum;

    
    private void Update()
    {
        if (PlayerPrefs.GetInt("openLevel") < _lvlNum)
        {
            _lock.SetActive(true);
            GetComponent<Button>().enabled = false;
        }
        else
        {
            _lock.SetActive(false);
            GetComponent<Button>().enabled = true;
        }
    }
}
