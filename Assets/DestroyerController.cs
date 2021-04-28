using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyerController : MonoBehaviour
{
    //Unityちゃんのオブジェクト
    private GameObject unitychan;
    //UnityちゃんとDestroyerの距離
    private float difference;
    //Destroyerをぶつけるためのコンポーネントを入れる
    private Rigidbody myRigidbody;


    // Use this for initialization
    void Start()
    {
        //Unityちゃんのオブジェクトを取得
        this.unitychan = GameObject.Find("unitychan");
        //UnityちゃんとDestroyerの位置（z座標）の差を求める
        this.difference = unitychan.transform.position.z - this.transform.position.z;
        //Rigidbodyコンポーネントを取得
        this.myRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Unityちゃんの位置に合わせてDestroyerの位置を移動
         this.transform.position = new Vector3(0, this.transform.position.y, this.unitychan.transform.position.z - difference);
    }

    //トリガーモードで他のオブジェクトと接触した場合の処理
    void OnTriggerEnter(Collider other)
    {

        //障害物に衝突した場合
        if (other.gameObject.tag == "CoinTag" || other.gameObject.tag == "CarTag" || other.gameObject.tag == "TrafficConeTag")
        {
            //接触したコインのオブジェクトを破棄
            Destroy(other.gameObject);
        }
    }
}