using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonChangeScreen : MonoBehaviour
{
    [SerializeField] private GameObject _currentScreen, _nextScreen;
    [SerializeField] private AudioSource _sndButton;

    public void OnClick()
    {
        _sndButton.Play();
        _nextScreen.SetActive(true);
        _currentScreen.SetActive(false);
    }
}
