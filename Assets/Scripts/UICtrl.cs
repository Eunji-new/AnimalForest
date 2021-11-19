using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UICtrl : MonoBehaviour
{
    public GameObject m_Panel;
    public GameObject noticePanel;
    public static UICtrl _Instance;

    private void Awake()
    {
        _Instance = this;
    }
    public void ClickMethodBtn()
    {
        m_Panel.SetActive(!m_Panel.activeSelf);
    }

    public void CreateNotice(string t)
    {
        noticePanel.SetActive(true);
        noticePanel.transform.Find("Text").GetComponent<Text>().text = t;
        StartCoroutine("RemoveNotice");
    }
    IEnumerator RemoveNotice()
    {
        yield return new WaitForSeconds(3.0f);
        noticePanel.SetActive(false);
    }
    public void ClickGameStart()
    {
        SceneManager.LoadScene("AnimalForest");
    }
    public void ClickGameEnd()
    {
        Application.Quit();
    }
}
