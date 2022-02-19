using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class PostController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(HttpConnect());
    }

    IEnumerator HttpConnect()
    {
        WWWForm form = new WWWForm(); //リクエストパラメータ(文字列になってしまう)
        form.AddField("x", 5); //ハッシュマップ的
        form.AddField("y", 8);

        string url = "https://joytas.net/php/calc.php";
        UnityWebRequest uwr = UnityWebRequest.Post(url, form); //formインスタンスも一緒に
        yield return uwr.SendWebRequest();
        if(uwr.isHttpError || uwr.isNetworkError)
        {
            Debug.Log(uwr.error);
        }
        else
        {
            Debug.Log(uwr.downloadHandler.text);
        }
    }
}
