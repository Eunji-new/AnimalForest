using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomWalk : MonoBehaviour
{
    private WalkDir walkState;
    enum WalkDir { forward, left, right, back};

    // Start is called before the first frame update
    void Start()
    {
        walkState = WalkDir.forward;
        StartCoroutine(Walking());
    }

    IEnumerator Walking()
    {
        while (true)
        {
            yield return new WaitForSeconds(3.0f);
            RandomWalkDir();
            if (walkState == WalkDir.forward)
            {
                transform.Rotate(new Vector3(0.0f, 0.0f, 0.0f));
            }
            else if (walkState == WalkDir.left)
            {
                transform.Rotate(new Vector3(0.0f, -90.0f, 0.0f));
            }
            else if (walkState == WalkDir.right)
            {
                transform.Rotate(new Vector3(0.0f, 90.0f, 0.0f));
            }
            else if (walkState == WalkDir.back)
            {
                transform.Rotate(new Vector3(0.0f, 180.0f, 0.0f));
            }
            if (transform.GetComponent<TalkingCtrl>().isTalking == true)
            {
                Vector3 targetPosition = new Vector3(PlayerCtrl._Instance.transform.position.x, transform.position.y, PlayerCtrl._Instance.transform.position.z);
                transform.LookAt(targetPosition);
            }
            //else
            //    transform.rotation = Quaternion.identity;
        }
        //yield return new WaitForSeconds(3.0f);
    }
    void RandomWalkDir()
    {
        float r = Random.Range(0.0f, 4.0f);
        if(r <= 1.0f)
        {
            walkState = WalkDir.forward;
        }
        else if (1.0f < r && r <= 2.0f)
        {
            walkState = WalkDir.left;
        }
        else if (2.0f < r && r <= 3.0f)
        {
            walkState = WalkDir.right;
        }
        else if ( r > 3.0f)
        {
            walkState = WalkDir.back;
        }
    }

}
