using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongPanelCtrl : MonoBehaviour
{
    public static SongPanelCtrl _Instance;
    public GameObject nabiSongPanel;
    public GameObject StopBtn;
    public AudioClip[] Songs;
    public bool isListening;
    private void Awake()
    {
        _Instance = this;
    }

    public void ClosePanel()
    {
        nabiSongPanel.SetActive(false);
        StopBtn.SetActive(true);
        isListening = false;
    }
    public void DontListen()
    {
        nabiSongPanel.SetActive(false);
        isListening = false;
    }
    public void ClickStopBtn()
    {
        StopBtn.SetActive(false);
        PlayerCtrl._Instance.audioSrc.clip = PlayerCtrl._Instance.BGM;
        PlayerCtrl._Instance.audioSrc.Play();
        isListening = false;
    }
    public void StartSong1()
    {
        PlayerCtrl._Instance.audioSrc.clip = Songs[0];
        PlayerCtrl._Instance.audioSrc.Play();
        isListening = true;
    }
    public void StartSong2()
    {
        PlayerCtrl._Instance.audioSrc.clip = Songs[1];
        PlayerCtrl._Instance.audioSrc.Play();
        isListening = true;
    }
    public void StartSong3()
    {
        PlayerCtrl._Instance.audioSrc.clip = Songs[2];
        PlayerCtrl._Instance.audioSrc.Play();
        isListening = true;
    }

}
