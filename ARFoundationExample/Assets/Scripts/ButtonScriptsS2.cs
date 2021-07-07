using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScriptsS2 : MonoBehaviour
{
    private bool _isPaused = false;
    [SerializeField]
    private GameObject _playBtn;
    [SerializeField]
    private GameObject _pauseBtn;
    [SerializeField]
    private GameObject _codeBtn;

    private void Start()
    {
        _playBtn.SetActive(false);
    }
    public void goPlay()
    {
        if (_isPaused)
        {
            Time.timeScale = 1f;
            _playBtn.SetActive(false);
            _pauseBtn.SetActive(true);
            _isPaused = false;
        }
        else
        {
            _playBtn.SetActive(false);
        }
    }

    public void goPause()
    {
        if (!_isPaused)
        {
            Time.timeScale = 0f;
            _pauseBtn.SetActive(false);
            _playBtn.SetActive(true);
            _isPaused = true;
        }
        else
        {
            _pauseBtn.SetActive(false);
        }
    }

    public void goCode()
    {

    }
}
