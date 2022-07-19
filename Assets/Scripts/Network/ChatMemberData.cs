using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using UnityEngine.UI;
using UnityEngine.UIElements;
using TMPro;
using Button = UnityEngine.UI.Button;

public class ChatMemberData : NetworkBehaviour
{

    [SerializeField] ChatConnection _chatConnection;

    public int _chatMemberColor;
    public string _chatMemberName;
    public int _chatMemberId;
   
   

    private void Start()
    {
        _chatConnection = FindObjectOfType<ChatConnection>();
        _chatMemberColor = UIScript.Instance._chatMemberColorNumber;    
        _chatMemberName = UIScript.Instance._chatMemberNickName;
        _chatMemberId = Random.Range(1, 100);

        NewChatMemberConnecterServerRpc( _chatMemberName, _chatMemberColor);

    }


    [ServerRpc]
    void NewChatMemberConnecterServerRpc(string NickName, int _playerColor)
    {
      
        _chatConnection.NewChatMemberConnected(NickName, _playerColor);

    }


}
