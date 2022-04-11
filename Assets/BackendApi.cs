using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using System;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

public class BackendApi
{
    public static string apiUrl = "https://mrd4l9nsqc.execute-api.ap-northeast-1.amazonaws.com/GameCollectorServ";

    public static Task<string> getCallApi(string url)
    {
        string obj = "[]";
        var req = UnityWebRequest.Get(url);
        var op = req.SendWebRequest();
        var promise = new TaskCompletionSource<string>();
        op.completed += (e) =>
        {
            if (req.result != UnityWebRequest.Result.ConnectionError && req.result != UnityWebRequest.Result.ProtocolError)
            {
                obj = req.downloadHandler.text;
            }
            req.Dispose();
            promise.TrySetResult(obj);
        };

        return promise.Task;
    }
    public static Task<string> putCallApi(string url, object obj)
    {
        string objOut = null;
        var content = JsonUtility.ToJson(obj);
        var req = UnityWebRequest.Put(url, content);
        req.SetRequestHeader("Content-Type", "application/json");

        var op = req.SendWebRequest();
        var promise = new TaskCompletionSource<string>();
        op.completed += (e) =>
        {
            if (req.result != UnityWebRequest.Result.ConnectionError && req.result != UnityWebRequest.Result.ProtocolError)
            {
                objOut = req.downloadHandler.text;
            }
            req.Dispose();
            promise.TrySetResult(objOut);
        };

        return promise.Task;

    }
}
