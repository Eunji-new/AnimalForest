using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    [HideInInspector]
    public AudioSource audioSrc;
    public AudioClip BGM;
    public GameObject fishing;
    public GameObject[] fishes;
    public static PlayerCtrl _Instance;

    public bool isFishing;
    bool isNearRiver;
    void Awake()
    {
        _Instance = this;
    }
    private void Start()
    {
        audioSrc = transform.GetComponent<AudioSource>();
        audioSrc.volume = 0.2f;
    }

    void Update() 
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (isFishing) //�̹� ���� �߿��� �߰� ���� �Ұ�
                return;

            if(!isNearRiver)
            {
                UICtrl._Instance.CreateNotice("���� �� ������ �ٰ����ּ���.");
                return;
            }

            Collider[] hitcolliders = Physics.OverlapSphere(transform.position, 5.0f);

            foreach(Collider coll in hitcolliders)
            {
                if (coll.gameObject.tag == "RIVER")
                {
                    isFishing = true;
                    isNearRiver = true;
                    fishing.SetActive(true);
                    break;
                }
                else
                {
                    isNearRiver = false;
                }
                
            }

            if (isFishing) //3�� �Ŀ� ����� ����.
                StartCoroutine(Fishing());
        }
    }

    IEnumerator Fishing()
    {
        yield return new WaitForSeconds(3.0f);
        //����� ����
        int numFish = Random.Range(0, 5);
        GameObject fish = Instantiate(fishes[numFish], transform.position + transform.forward*5, transform.rotation);
        switch (numFish)
        {
            case 0: UICtrl._Instance.CreateNotice("��, �� ��Ҵ�!\n�ȳ� ����!");  break;
            case 1: UICtrl._Instance.CreateNotice("��, ��� ��Ҵ�!\n���ް�3!!!"); break;
            case 2: UICtrl._Instance.CreateNotice("��, ��ġ�� ��Ҵ�!\n���� ģ��!!!"); break;
            case 3: UICtrl._Instance.CreateNotice("��, ������ ��Ҵ�!\n���ְڴ�!!!"); break;
            case 4: UICtrl._Instance.CreateNotice("��, �� ��Ҵ�!\n������~!!!"); break;
        }
        yield return new WaitForSeconds(3.0f);
        Destroy(fish);
        fishing.SetActive(false);
        isFishing = false;
    }


}
