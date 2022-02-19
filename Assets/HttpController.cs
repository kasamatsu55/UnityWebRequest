using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class HttpController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(HttpConnect());
    }
    IEnumerator HttpConnect() //自分で作るメソッド
    {
        string url = "https://joytas.net/php/hello.php";
        //Unity2018～
        UnityWebRequest uwr = UnityWebRequest.Get(url); //Get通信ができるインスタンスを作成
        yield return uwr.SendWebRequest(); //実際に通信
        if(uwr.isHttpError || uwr.isNetworkError) //サーバーに繋がらない、ネットに繋がらないとか、
        {
            Debug.Log(uwr.error);
        }
        else
        {
            Debug.Log(uwr.downloadHandler.text); //本文にアクセス
        }
    }
}
