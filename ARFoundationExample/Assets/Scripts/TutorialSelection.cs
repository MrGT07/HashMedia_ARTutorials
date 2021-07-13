using UnityEngine.Video;
using UnityEngine;

public class TutorialSelection : MonoBehaviour
{
    private int _screenID;
    private string _screenCategory;
    [SerializeField]
    private VideoPlayer _videoPlayer;
    [SerializeField]
    private GameObject _screens;
    [SerializeField]
    private GameObject _btnManager;
    private void Start()
    {
       Invoke("_startTutorial", 1f);
    }

    private void _startTutorial()
    {
        if (!_videoPlayer.isPlaying)
        {
            _screenID = TutIDHolder.id;
            _screenCategory = TutIDHolder.category;
            Debug.Log("Starting Screen: " + _screenID);
            switch (_screenCategory)
            {
                case "Sensors":
                    if (_screens.transform.GetChild(0).gameObject.transform.GetChild(0).childCount > 0)
                    {
                        _screens.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.transform.GetChild(_screenID).gameObject.SetActive(true);
                    }
                    break;
                case "Boards":
                    if (_screens.transform.GetChild(0).gameObject.transform.GetChild(1).childCount > 0)
                    {
                        _screens.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject.transform.GetChild(_screenID).gameObject.SetActive(true);
                    }
                    break;
                case "Wires":
                    if (_screens.transform.GetChild(0).gameObject.transform.GetChild(2).childCount > 0)
                    {
                        _screens.transform.GetChild(0).gameObject.transform.GetChild(2).gameObject.transform.GetChild(_screenID).gameObject.SetActive(true);
                    }
                    break;
                case "Miscellaneous":
                    if (_screens.transform.GetChild(0).gameObject.transform.GetChild(3).childCount > 0)
                    {
                        _screens.transform.GetChild(0).gameObject.transform.GetChild(3).gameObject.transform.GetChild(_screenID).gameObject.SetActive(true);
                    }
                    break;
                case "Projects":
                    if (_screens.transform.GetChild(0).gameObject.transform.GetChild(4).childCount > 0)
                    {
                        _screens.transform.GetChild(0).gameObject.transform.GetChild(4).gameObject.transform.GetChild(_screenID).gameObject.SetActive(true);
                    }
                    break;
                default:
                    Debug.Log("Invalid ID!");
                    break;
            }
            _btnManager.SetActive(true);
        }
    }
}
