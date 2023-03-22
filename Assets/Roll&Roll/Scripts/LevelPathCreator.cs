using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelPathCreator : MonoBehaviour
{
    /// <summary>
    /// 大地图地板
    /// </summary>
    public GameObject floorPlane;

    public GameObject camera;

    /// <summary>
    /// 需要记录上一关的最终位置作为下一关的初始位置
    /// </summary>
    private Vector3 lastPos;


    [ContextMenuItem("生成路径", "AddPath1")]
    public GameObject pathBase;

    /// <summary>
    /// 关卡判断位置预制体
    /// </summary>
    public GameObject targetBase;

    public GameObject target;

    [Range(1,10)]
    public int count = 1;
    public float width = 1;

    public Vector3 levelFirstPos;

    List<GameObject> temp = new List<GameObject>();

    public Vector3 relationPos;

    private void Awake()
    {
        levelFirstPos = new Vector3(-2, 0, -10);
        relationPos = Camera.main.transform.position - floorPlane.transform.position;
    }

    private void Start()
    {
       
    }

    public void AddPath(int count,int level)
    {
        bool single = level % 2 == 1 ? true : false;


        for(int i = 0; i < count; i++)
        {
            GameObject g = GameObject.Instantiate(pathBase);
            float addPos = (i) * width;
            Vector3 addPosv3 = new Vector3(single ? addPos : 0, 0, single ? 0 : addPos); 
            g.transform.position = levelFirstPos + addPosv3;
            temp.Add(g);

            //if(level!=1)
            //    camera.transform.position += addPosv3;
        }

        //路径生成完毕后，还需要在最后一个点的位置，创建一个成功到达的判断
        GameObject final = temp[temp.Count-1];
        target = GameObject.Instantiate(targetBase);
        target.transform.position = final.transform.position + new Vector3(0, 1, 0);
        levelFirstPos = final.transform.position;

        floorPlane.transform.position = new Vector3(temp[0].transform.position.x, -0.5f, temp[0].transform.position.z);
        
        camera.transform.position = floorPlane.transform.position + relationPos;

    }

    public void AddPath1()
    {
        AddPath(count,1);
    }

    public void DeletePath()
    {
        Destroy(target);
        for(int i=0;i< temp.Count;i++)
        {
            Destroy(temp[i]);
        }
        temp.Clear();
    }


    public void NextLevel(int count,int level)
    {
        DeletePath();
        AddPath(count, level);

    }

}
