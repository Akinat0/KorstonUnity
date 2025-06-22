
using UnityEngine;

public class GameInstance : MonoBehaviour
{
    Messenger messenger;
    
    void Awake()
    {
        messenger = gameObject.AddComponent<Messenger>();
        Communication.SendMessageToFlutter("unity_started");
    }
    
    public void HandleWebMessage(string message)
    {
        Debug.Log($"Web: {message}");
    }
}
