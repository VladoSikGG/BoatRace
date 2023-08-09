using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class lvlStart : MonoBehaviour
{
    [SerializeField] private int _indexLvl;
    [SerializeField] private AudioSource _sndButton;

    public void OnClick()
    {
        _sndButton.Play();
        SceneManager.LoadScene($"lvl{_indexLvl}");
    }
}
