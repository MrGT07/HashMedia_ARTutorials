using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoFromURL : MonoBehaviour
{
    [SerializeField]
    private VideoPlayer _videoPlayer;
    private int _id;
    private string _category;
    [SerializeField]
    private GameObject _screenHolder;
    private Transform _parentTransform;
    [HideInInspector]
    public static GameObject temp;

    private void Start()
    {
        InvokeRepeating("_startVid", 2f, 5f);
        _parentTransform = _screenHolder.transform;
    }

    private void _startVid()
    {
        _category = TutIDHolder.category;
        _id = TutIDHolder.id;
        if (!_videoPlayer.isPlaying)
        {
            temp = _parentTransform.Find(_category).gameObject.transform.GetChild(_id).gameObject.transform.Find("ContentHolder").gameObject;
            Debug.Log("url = " + temp.GetComponent<LoadVideos>().url);
            _videoPlayer.url = temp.GetComponent<LoadVideos>().url;
            _videoPlayer.audioOutputMode = VideoAudioOutputMode.AudioSource;
            _videoPlayer.EnableAudioTrack(0, true);
            _videoPlayer.Prepare();
        }
    }
}
