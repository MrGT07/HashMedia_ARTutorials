using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoFromURL : MonoBehaviour
{
    [SerializeField]
    private VideoPlayer _videoPlayer;
    [SerializeField]
    private string _videoURL;

    private void Start()
    {
        _videoPlayer.url = _videoURL;
        _videoPlayer.audioOutputMode = VideoAudioOutputMode.AudioSource;
        _videoPlayer.EnableAudioTrack(0, true);
        _videoPlayer.Prepare();
    }
}
