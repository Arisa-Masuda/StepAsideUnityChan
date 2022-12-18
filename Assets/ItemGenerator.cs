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
    private float startCreatePos = 0f;
    //アイテムを生成する終了地点
    private float endCreatePos = 0f;
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
        endCreatePos = unitychan.transform.position.z + viewPos;

        //アイテム生成の終了位置がスタート地点を超えている場合
        if (endCreatePos > startPos)
        {
            //アイテム生成の終了位置が前回アイテムを作成した位置を超えているかつ
            //前回アイテムを作成した位置がゴール地点を超えていない場合
            if (endCreatePos > createdPos && createdPos < goalPos)
            {
                //初回アイテム生成の場合
                if (startCreatePos == 0f)
                {
                    startCreatePos = startPos;       //スタート地点を設定
                    endCreatePos = startPos += 15f;  //スタート地点＋15m先を設定
                }
                //アイテム生成の終了位置がゴール地点を超えている場合
                else if (endCreatePos > goalPos)
                {
                    startCreatePos = createdPos;  //前回アイテムを作成した位置
                    endCreatePos = goalPos;       //ゴール地点を設定
                }
                else
                {
                    startCreatePos = createdPos;  //前回アイテムを作成した位置
                    if (endCreatePos - startCreatePos <= 10f) //前回アイテムを作成した位置と今回作成する位置の差が10f以下の場合
                    {
                        endCreatePos += 10f;     //今回作成する位置に加算する
                    }
                }

                //アイテムを生成する
                CreateItem(startCreatePos, endCreatePos);
                //アイテムを生成した終了位置を保持する
                createdPos = endCreatePos;

            }
        }
    }

    //アイテムを作成する処理
    void CreateItem(float posS, float posE)
    {
        for (float i = posS; i < posE; i += 15f)
        {
            //どのアイテムを出すのかをランダムに設定
            int num = Random.Range(1, 11);
            if (num <= 2)
            {
                //コーンをx軸方向に一直線に生成
                for (float j = -1; j <= 1; j += 0.4f)
                {
                    GameObject cone = Instantiate(conePrefab);
                    cone.transform.position = new Vector3(4 * j, cone.transform.position.y, i);
                }
            }
            else
            {
                //レーンごとにアイテムを生成
                for (int j = -1; j <= 1; j++)
                {
                    //アイテムの種類を決める
                    int item = Random.Range(1, 11);
                    //アイテムを置くℤ座標のオフセットをランダムに設定
                    int offsetZ = Random.Range(-5, 6);
                    //６０％コインを配置：３０％車を配置：１０％何もなし
                    if (1 <= item && item <= 6)
                    {
                        //コインを生成（Prefabからインスタンスを生成している）
                        GameObject coin = Instantiate(coinPrefab); //Instantiate () は、()内に指定したPrefabのインスタンスをGameObject型として生成する
                        coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, i + offsetZ);
                    }
                    else if (7 <= item && item <= 9)
                    {
                        //車を生成
                        GameObject car = Instantiate(carPrefab);
                        car.transform.position = new Vector3(posRange * j, car.transform.position.y, i + offsetZ);
                    }
                }
            }
        }
    }
}
