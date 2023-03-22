using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetTrigger : MonoBehaviour
{

    public void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            PlayerController player = other.gameObject.GetComponent<PlayerController>();
            if (player.isStop)
            {
                //通知其他模块，通关成功
                Debug.Log("isCompleted!");
                GameObject.FindObjectOfType<RollAndRoll>().CompletedLevel();
            }
        }
    }

}
