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
            if (isFishing) //이미 낚시 중에는 추가 낚시 불가
                return;

            if(!isNearRiver)
            {
                UICtrl._Instance.CreateNotice("강에 더 가까이 다가가주세요.");
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

            if (isFishing) //3초 후에 물고기 낚음.
                StartCoroutine(Fishing());
        }
    }

    IEnumerator Fishing()
    {
        yield return new WaitForSeconds(3.0f);
        //물고기 생성
        int numFish = Random.Range(0, 5);
        GameObject fish = Instantiate(fishes[numFish], transform.position + transform.forward*5, transform.rotation);
        switch (numFish)
        {
            case 0: UICtrl._Instance.CreateNotice("어, 농어를 잡았다!\n안농 농어야!");  break;
            case 1: UICtrl._Instance.CreateNotice("어, 고등어를 잡았다!\n오메가3!!!"); break;
            case 2: UICtrl._Instance.CreateNotice("어, 삼치를 잡았다!\n고등어 친구!!!"); break;
            case 3: UICtrl._Instance.CreateNotice("어, 참돔을 잡았다!\n맛있겠다!!!"); break;
            case 4: UICtrl._Instance.CreateNotice("어, 상어를 잡았다!\n무서워~!!!"); break;
        }
        yield return new WaitForSeconds(3.0f);
        Destroy(fish);
        fishing.SetActive(false);
        isFishing = false;
    }


}
