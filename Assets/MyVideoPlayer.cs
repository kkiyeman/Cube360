using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class MyVideoPlayer : MonoBehaviour
{

    VideoPlayer videoplayer;
    VideoClip videoclip;
    // Start is called before the first frame update
    void Start()
    {
        videoplayer = GetComponent<VideoPlayer>();

        //videoplayer.Play();
        //videoplayer.Stop();
        //videoplayer.Pause();

        //videoplayer.clip = videoclip;
        //videoplayer.time <- ���� ���� �ð�
        //videoplayer.Length <- ��ü ���� �ð�

    }



}
