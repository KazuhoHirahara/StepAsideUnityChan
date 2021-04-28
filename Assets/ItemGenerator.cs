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


    //Unityちゃんのオブジェクト   (課題追加)
    private GameObject unitychan;
    //アイテムを生成する更新位置 (課題追加)
    private int generate=0;


    // Use this for initialization
    void Start()
    {
        //Unityちゃんのオブジェクトを取得   (課題追加)
        this.unitychan = GameObject.Find("unitychan");
        //生成位置の初期化(課題追加)
        generate = startPos;
    }

    // Update is called once per frame
    void Update()
    {
            //ユニティちゃんの位置が更新位置の40m先になったらアイテム生成(課題追加)
            if (generate<unitychan.transform.position.z+40 &&generate<goalPos) {
            //アイテム生成位置を15m先に更新(課題追加)
            generate += 15;


            //どのアイテムを出すのかをランダムに設定
            int num = Random.Range(1, 11);
            if (num <= 2)
            {
                //コーンをx軸方向に一直線に生成
                for (float j = -1; j <= 1; j += 0.4f)
                {
                    GameObject cone = Instantiate(conePrefab);
                    cone.transform.position = new Vector3(4 * j, cone.transform.position.y, generate);
                }
            }
            else
            {

                //レーンごとにアイテムを生成
                for (int j = -1; j <= 1; j++)
                {
                    //アイテムの種類を決める
                    int item = Random.Range(1, 11);
                    //アイテムを置くZ座標のオフセットをランダムに設定
                    int offsetZ = Random.Range(-5, 6);
                    //60%コイン配置:30%車配置:10%何もなし
                    if (1 <= item && item <= 6)
                    {
                        //コインを生成
                        GameObject coin = Instantiate(coinPrefab);
                        coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, generate + offsetZ);
                    }
                    else if (7 <= item && item <= 9)
                    {
                        //車を生成
                        GameObject car = Instantiate(carPrefab);
                        car.transform.position = new Vector3(posRange * j, car.transform.position.y, generate + offsetZ);
                    }
                }
            }
        }
    }
}