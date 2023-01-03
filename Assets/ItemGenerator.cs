using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    //carPrefabを入れる
    public GameObject carPrefab;
    //coinPrefabを入れる
    public GameObject coinPrefab;
    //cornPrefabを入れる
    public GameObject conePrefab;
    
    //スタート地点
    private float startPos = 80f;
    //ゴール地点
    private float goalPos = 360f;
    //アイテムを出すx方向の範囲
    private float posRange = 3.4f;
    
    //Unityちゃんのオブジェクト
    private GameObject unitychan;
    //Unityちゃんの見える範囲
    private float viewPos = 40f;
    //アイテムを生成する開始地点
    private float Pos = 0f;
    //前回アイテムが生成された終了地点
    private float createdPos = 0f;

    // Start is called before the first frame update
    void Start()
    {
        //Unityちゃんのオブジェクトを取得
        this.unitychan = GameObject.Find("unitychan");
    }

    // Update is called once per frame
    void Update()
    {
        //Unityちゃんの位置＋４０ｍ先をアイテム生成の終了位置に設定
        Pos = unitychan.transform.position.z + viewPos;

        //前回アイテムを生成した位置+15fを超えている場合
        if (Pos >= createdPos + 15f && Pos < goalPos)
        {
            //アイテムを生成する
            CreateItem(Pos);
            //アイテムを生成した終了位置を保持する
            createdPos = Pos;
        }

    }

    //アイテムを作成する処理
    void CreateItem(float pos)
    {
        //どのアイテムを出すのかをランダムに設定
        int num = Random.Range(1, 6);
        //どのレーンにいくつアイテムを出すのかランダムに設定
        int lane = Random.Range(-1, 1);

        //コーンを生成する
        if (num <= 1)
        {
            //コーンをx軸方向に一直線に生成
            for (float j = -1; j <= 1; j += 0.4f)
            {
                GameObject cone = Instantiate(conePrefab);
                cone.transform.position = new Vector3(4 * j, cone.transform.position.y, pos);
            }
        }
        //コインを生成する
        else if (2 <= num && num <= 4)
        {
            //レーンごとにアイテムを生成
            for (int j = lane; j <= 1; j++)
            {
                //コインを生成（Prefabからインスタンスを生成している）
                GameObject coin = Instantiate(coinPrefab); //Instantiate () は、()内に指定したPrefabのインスタンスをGameObject型として生成する
                coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, pos);
            }
        }
        //車を生成する
        else if (5 <= num) 
        {
            //レーンごとにアイテムを生成
            for (int j = lane; j <= 1; j++)
            {
                //車を生成
                GameObject car = Instantiate(carPrefab);
                car.transform.position = new Vector3(posRange * j, car.transform.position.y, pos);
            }
        }
    }
}
