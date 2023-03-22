using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollAndRoll : MonoBehaviour
{
    public PlayerController player;
    public LevelPathCreator creator;

    // Start is called before the first frame update
    void Start()
    {
        creator= GetComponent<LevelPathCreator>(creator);
        player= GetComponent<PlayerController>(player);

        CreateNextLevel();//创建第一关


    }

    [Range(0,1)]
    public float keep = 0;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            keep += Time.deltaTime;
            if (keep >= 1)
                keep = 1;

        }
        if (Input.GetMouseButtonUp(0))
        {
            player.AddForceToRun(keep);
            //player.AddSpeed();
            keep = 0;

        }

        if (Input.GetKeyDown(KeyCode.Space))
        {

        int count = Random.Range(3, 5);
            GameStatus.level++;
            creator.NextLevel(count, GameStatus.level);

        }      
    }


    public T GetComponent<T>(Component c) where T : Component
    {
        if (c == null)
        {
           c = gameObject.GetComponent<T>();

            if (c == null)
                c = GameObject.FindObjectOfType<T>();

            if (c == null)
                c = gameObject.AddComponent<T>();

        }

        return (T)c;
    }


    public void CreateNextLevel()
    {
        //生成移动路径
        int count = Random.Range(3, 5);
        creator.AddPath(count, GameStatus.level);

        //移动路径以及目标位置生成后，分配给玩家
        player.target = creator.target;
    }


    public void CompletedLevel()
    {
        creator.DeletePath();
        GameStatus.level++;
        CreateNextLevel();

    }

}
