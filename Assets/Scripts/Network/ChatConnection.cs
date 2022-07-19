using UnityEngine;
using Unity.Netcode;
using Unity.Netcode.Transports.UNET;
using System.Collections.Generic;
using UnityEngine.UI;
using System;

public class ChatConnection : NetworkBehaviour
{
    [SerializeField] private string ipAdress;
    [SerializeField] private int port;
    [SerializeField] private UNetTransport transport;
    [SerializeField] private ChatManager _chatManager;
   
    
      public void ConneToChatButton()
      {

          if (UIScript.Instance._weMayConnect == true) //check did the nickname is not empty
          {
              transport = NetworkManager.Singleton.GetComponent<UNetTransport>();
              transport.ConnectAddress = ipAdress;
              NetworkManager.Singleton.StartClient();  // launch clien with ip/port
              Debug.Log($"Подключаемся к {ipAdress} and {transport.ConnectPort}");
          }
      }
    public void CloseCOnnection()
    {
        NetworkManager.Singleton.Shutdown();
    }
    public void NewChatMemberConnected(string playerName, int playercolor)
    {
       
    }

    public void SendChatMessage(string Message, string NickName, int Color)
    {
        NewChatMessageServerRpc(Message, NickName, Color);

    }


    [ServerRpc(RequireOwnership = false)]
    void NewChatMessageServerRpc(string Message, string NickName, int PlayerColor)
    {

        Debug.Log($"отправляем на сервер сообщение - {Message}");
        _chatManager.WeGotNewMesage(Message, NickName, PlayerColor);

    }



   

    [ClientRpc]
    public void realtimeChatToClient_ClientRpc(string _chatText)
    {

        
        _chatManager.realtimeChatText(_chatText);


    }

    [ClientRpc]
    public void realtimeOnlineState_ClientRpc(string onlineState)
    {
        Debug.Log($"Мы получили статус онлайна {onlineState} ");
        _chatManager.realtimeOnlineStatus(onlineState);
    }

}
