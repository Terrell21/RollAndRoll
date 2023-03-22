using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyLogic : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.W))
        //{
        //    this.transform.position += new Vector3(0,1,0);
        //}
        //if (Input.GetKeyDown(KeyCode.S))
        //{
        //    this.transform.position -= new Vector3(0, 1, 0);
        //}

        Vector3 pos = Input.mousePosition;
        Camera.main.orthographic = true;
        this.gameObject.transform.position = Camera.main.ScreenToWorldPoint(pos);
        
        this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, -5);
        //Camera.main.orthographic = false;

    }
}
