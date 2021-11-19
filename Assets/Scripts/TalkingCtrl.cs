using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TalkingCtrl : MonoBehaviour
{
    public AudioClip[] talk;
    public bool isTalking;
    GameObject player;

    Animator anim;
    private void Start()
    {
        player = PlayerCtrl._Instance.transform.gameObject;
    }
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.T)) //Talking
        {
            if (SongPanelCtrl._Instance.isListening)
            {
                UICtrl._Instance.CreateNotice("���� ���� �߿��� �ֹΰ� ��ȭ�� �� �����ϴ�.");
                return;
            }
            if (PlayerCtrl._Instance.isFishing)
            {
                UICtrl._Instance.CreateNotice("���� �߿��� �ֹΰ� ��ȭ�� �� �����ϴ�.");
                return;
            }
            if (Vector3.Distance(transform.position, player.transform.position) < 6.0f)
            {
                Debug.Log("��ȭ����");
                isTalking = true;
                anim = this.transform.GetComponent<Animator>();
                anim.SetBool("Talk", true);
                int numTalk = Random.Range(0, talk.Length);
                TalkStart(numTalk);
                Vector3 targetPosition = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
                transform.LookAt(targetPosition);
                Invoke("TalkEnd", talk[numTalk].length);
                if (numTalk == 1 && transform.gameObject.name == "Nabi")
                {
                    SongPanelCtrl._Instance.nabiSongPanel.SetActive(true);
                }
            }
          /*  else if (Vector3.Distance(transform.position, player.transform.position) >= 6.0f && !PlayerCtrl._Instance.isTalking)
            {
                UICtrl._Instance.CreateNotice("�ֹΰ� �̾߱��Ϸ���\n�� ������ �ٰ�������.");
                Debug.Log("�̾߱����ΰ�: " + PlayerCtrl._Instance.isTalking);
            }
          */
        }
 

    }
    void TalkStart(int idx)
    {
        PlayerCtrl._Instance.audioSrc.clip = talk[idx];
        PlayerCtrl._Instance.audioSrc.Play();
    }
    void TalkEnd()
    {
        if (anim != null)
            anim.SetBool("Talk", false);
        else
            Debug.Log("Animator �������� ����");
       
        PlayerCtrl._Instance.audioSrc.clip = PlayerCtrl._Instance.BGM;
        PlayerCtrl._Instance.audioSrc.Play();
        isTalking = false;
    }
}
    

