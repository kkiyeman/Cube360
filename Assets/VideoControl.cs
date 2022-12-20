using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Video;
using System;

public class VideoControl : MonoBehaviour
{

    public Image bg;
    public Image filler;
    public VideoPlayer videplayer;
    public Slider slider;
    public Button btnPlay;
    public Button btnRW;
    public Button btnFF;
    public Button btnStop;
    public TMP_Text curTime;
    public TMP_Text Length;
    public CanvasGroup canvasgroup;
    private bool isRewind = false;
    private bool isFastForwrd = false;
    private int isFading;




    public float speed = 0.2f;
    // Start is called before the first frame update
    void Start()
    {
        videplayer.Stop();
        btnPlay.onClick.AddListener(videoPlay);
        btnFF.onClick.AddListener(IsFastForward);
        btnRW.onClick.AddListener(IsRewind);
        btnStop.onClick.AddListener(IsStop);
    }

    // Update is called once per frame
    void Update()
    {
        
        videoReWind();
        videoFastForward();
        SetCurTime();
    }


    private void videoPlay()
    {
        if (!videplayer.isPlaying)
        {
            isRewind = false;
            isFastForwrd = false;
            
            videplayer.Play();
        }
        else
        {
            isRewind = false;
            isFastForwrd = false;
            
            videplayer.Pause();
        }
    }
    private void IsStop()
    {
        isRewind = false;
        isFastForwrd = false;
        
        videplayer.Stop();
    }

    private void videoFastForward()
    {
        if (isFastForwrd)
            videplayer.time = videplayer.time + speed;
    }

    private void IsFastForward()
    {

        if (isFastForwrd)
        {
            isFastForwrd = false;
            videplayer.Play();
        }
        else if (!isFastForwrd)
        {
            videplayer.Pause();
            isFastForwrd = true;
        }
    }

    private void videoReWind()
    {
        if (isRewind)
        {
            videplayer.time -= speed;
        }
    }

    private void IsRewind()
    {
        if (isRewind)
        {
            isRewind = false;
            videplayer.Play();
        }
        else if (!isRewind)
        {
            videplayer.Pause();
            isRewind = true;
        }
    }
    private void SetCurTime()
    {
        double v = videplayer.length;
        double c = videplayer.time;
        float vf = (float)v;
        float cf = (float)c;

        double vt = Math.Truncate(v);
        double ct = Math.Truncate(c);

        if (vt < 10d)
        {
            Length.text = $"00 : 0{vt}";
        }
        else
            Length.text = $"00 : {vt}";


        if (ct < 10d)
        {
            curTime.text = $"00 : 0{ct}";
        }
        else
            curTime.text = $"00 : {ct}";

        slider.maxValue = vf;
        slider.value = cf;
    }

    public void FadeOut()
    {
        isFading = 0;
        StartCoroutine(FadeOutt());
    }

    public void FadeIn()
    {
        isFading = 0;
        StartCoroutine(FadeInn());
    }
    public IEnumerator FadeOutt()
    {
        if(isFading==0)
        {
            bg.gameObject.SetActive(true);
            yield return new WaitForSeconds(1f);
            for (float i = 1.0f; i >= -0.2f; i -= 0.1f)
            {
                canvasgroup.alpha = i;
                isFading++;
                yield return new WaitForSeconds(0.02f);
            }

        }

        bg.gameObject.SetActive(false);
        filler.gameObject.SetActive(true);

    }
    public IEnumerator FadeInn()
    {
        if(isFading==0)
        {      
            bg.gameObject.SetActive(true);

            for (float i = 0.0f; i <= 1.2f; i += 0.1f)
            {
                canvasgroup.alpha = i;
                isFading++;
                yield return new WaitForSeconds(0.02f);
            }
            filler.gameObject.SetActive(false);
        }
     

    }

    public void OnStay()
    {
        bg.gameObject.SetActive(true);
    }
}
