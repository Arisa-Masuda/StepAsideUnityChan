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
    private int startPos = 80;
    //ゴール地点
    private int goalPos = 360;
    //アイテムを出すx方向の範囲
    private float posRange = 3.4f;

    // Start is called before the first frame update
    void Start()
    {

        for (int i = startPos; i < goalPos; i += 15) 
        {
            //どのアイテムを出すのかをランダムに設定
            int num = Random.Range(1, 11);
            if (num <= 2) 
            {
                //コーンをx軸方向に一直線に生成
                for(float j = -1; j <= 1; j += 0.4f) 
                {
                    GameObject cone = Instantiate(conePrefab);
                    cone.transform.position = new Vector3(4 * j, cone.transform.position.y, i);
                }
            }
            else 
            {
                //レーンごとにアイテムを生成
                for(int j = -1; j <=1; j++) 
                {
                    //アイテムの種類を決める
                    int item = Random.Range(1, 11);
                    //アイテムを置くℤ座標のオフセットをランダムに設定
                    int offsetZ = Random.Range(-5, 6);
                    //６０％コインを配置：３０％車を配置：１０％何もなし
                    if(1 <= item && item <= 6) 
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
