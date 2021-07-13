using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoFromURL : MonoBehaviour
{
    [SerializeField]
    private VideoPlayer _videoPlayer;
    private int _id;

    private void Start()
    {
        InvokeRepeating("_startVid", 2f, 5f);
    }

    private void _startVid()
    {
        _id = TutIDHolder.id;
        if (!_videoPlayer.isPlaying)
        {
            switch (_id)
            {
                case 0:
                    _videoPlayer.url = "http://localhost/Video/Welcome.mp4";
                    break;
                case 1:
                    _videoPlayer.url = "http://localhost/video/20180201_144846.mp4";
                    break;
                case 2:
                    _videoPlayer.url = "http://localhost/video/20180202_220106.mp4";
                    break;
                default:
                    _videoPlayer.url = "http://localhost/video/Censor%20BEEP%20Sound%20EffectTV%20Error%20Clip.mp4";
                    break;
            }
            _videoPlayer.audioOutputMode = VideoAudioOutputMode.AudioSource;
            _videoPlayer.EnableAudioTrack(0, true);
            _videoPlayer.Prepare();
        }
    }
}
