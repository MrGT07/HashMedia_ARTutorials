using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class ButtonScriptsS2 : MonoBehaviour
{
    private bool _isPaused = false;
    private bool _isDisplaying = false;
    [SerializeField]
    private VideoPlayer _videoPlayer;
    [SerializeField]
    private GameObject _playBtn;
    [SerializeField]
    private GameObject _pauseBtn;
    [SerializeField]
    private GameObject _codeBtn;
    private GameObject _target;


    private void Start()
    {
        _playBtn.SetActive(false);
    }
    public void goPlay()
    {
        if (_isPaused)
        {
            _videoPlayer.Play();
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
            _videoPlayer.Pause();
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
        if (!_isDisplaying)
        {
            _target = VideoFromURL.temp;
            _target.SetActive(true);
            _isDisplaying = true;
        }
        else
        {
            _target.SetActive(false);
            _isDisplaying = false;
        }
        if (!_videoPlayer.isPlaying)
        {
            _videoPlayer.Pause();
            _pauseBtn.SetActive(false);
            _playBtn.SetActive(true);
            _isPaused = true;
        }
    }

    public void goBack()
    {
        SceneManager.LoadScene("main");
    }
}
