using System.Runtime.InteropServices;
using UnityEngine;

public static class Communication 
{
    [DllImport("__Internal")]
    static extern void SendToFlutter(string message);

    public static void SendMessageToFlutter(string content) {
        Debug.Log("Send Message To Flutter: " + content);
#if UNITY_WEBGL && !UNITY_EDITOR
        SendToFlutter(content);
#endif
    }
}
