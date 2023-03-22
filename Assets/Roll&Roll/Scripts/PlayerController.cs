using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool isStop;


    /// <summary>
    /// 目标位置
    /// </summary>
    public GameObject target;

    public Vector3 targetPos;

    public AnimationCurve speedCurve = new AnimationCurve(new Keyframe(0, 1));


    /// <summary>
    /// 滚动强度系数
    /// </summary>
    public float rollPower = 80;


    /// <summary>
    /// 滚动用刚体组件
    /// </summary>
    public Rigidbody moveRigidBody;


    // Start is called before the first frame update
    void Start()
    {
        this.tag = "Player";
        StartCoroutine(CheckStop());
        moveRigidBody = GetComponent<Rigidbody>();
    }

    public float currentTime = 0;

    public Vector3 dir;

    // Update is called once per frame
    void Update()
    {
        if (isRun)
        {
            currentTime += Time.deltaTime;
            //Vector3 forceDir = Vector3.Normalize(targetPos - transform.position);

            transform.position += (/*forceDir*/ dir * speedCurve.Evaluate(currentTime));

        }
    }

    private Vector3 lastPos;


    IEnumerator CheckStop()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            Vector3 currenPos = transform.position;
            float distance = Mathf.Abs(Vector3.Distance(currenPos, lastPos));
            if (distance <= 0.001f)
            {
                isStop = true;
                isRun = false;
                currentTime = 0;
            }
            else
            {
                isStop = false;
                dir = Vector3.Normalize(targetPos - transform.position);

            }
            lastPos = currenPos;
        }

    }



    public void AddForceToRun(float keep)
    {
        if (target != null)
            targetPos = target.transform.position;
        Vector3 forceDir = Vector3.Normalize(targetPos - transform.position);
        moveRigidBody.AddForce(forceDir * rollPower * keep, ForceMode.Acceleration);

    }

    public bool isRun = false;


    public void AddSpeed()
    {
        if (target != null)
            targetPos = target.transform.position;
        Vector3 forceDir = Vector3.Normalize(targetPos - transform.position);

        isRun = true;

        //moveRigidBody.AddForce(forceDir * rollPower * keep, ForceMode.Acceleration);
        //transform.position.
    }

}
