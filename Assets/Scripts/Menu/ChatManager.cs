using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChatManager : MonoBehaviour
{
    [SerializeField] public Text _chatRealtimeText;
    [SerializeField] private Text _whoIsOnlineText;

    public void WeGotNewMesage(string Message, string Nick, int MessageColor)
    {

    }

    public void realtimeChatText(string liveChatHistoryText)
    {
        _chatRealtimeText.text = liveChatHistoryText;

    }

    public void realtimeOnlineStatus(string OnlineStatus)
    {
        _whoIsOnlineText.text = OnlineStatus;
    }
}
