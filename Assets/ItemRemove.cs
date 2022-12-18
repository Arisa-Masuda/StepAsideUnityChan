using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRemove : MonoBehaviour
{
    //MainCameraのオブジェクト
    private GameObject maincamera;

    // Start is called before the first frame update
    void Start()
    {
        //MainCameraのオブジェクトを取得
        this.maincamera = Camera.main.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        //MainCameraがアイテム（オブジェクト）を通り過ぎたら破棄する
        if (this.transform.position.z < maincamera.transform.position.z) 
        {
            //Debug.Log("削除する");
            Destroy(this.gameObject);
        }
    }
}
