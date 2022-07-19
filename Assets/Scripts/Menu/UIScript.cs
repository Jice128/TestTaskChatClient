using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
      public static UIScript Instance { set; get; }

    [SerializeField] private Animator _menuAnimator;
    [SerializeField] private InputField _nickName;
    [SerializeField] private ChatConnection _connection;
    [SerializeField] private Button _sendMsgBtn;
    [SerializeField] private InputField _inputMessage;
    



    public int  _chatMemberColorNumber;
    public string _chatMemberNickName = "Без имени";
    public bool _weMayConnect = false;


    private enum _chatMemberColor
    {
        red,
        blue,
        green,
        black
    }

    private void Awake()
    {
        Instance = this;
        _chatMemberColorNumber = 3;
    }


    public void OnStartChatButton()
    {
        _chatMemberNickName = _nickName.text;
        if (string.IsNullOrWhiteSpace(_chatMemberNickName)) { return; } //проверяем что бы мы не подключились с пустым ником

         else
         {
            _weMayConnect = true;
            _menuAnimator.SetTrigger("ChatMenu");
         }
    }

    public void OnExitChatButton()
    {
        _connection.CloseCOnnection();
        _menuAnimator.SetTrigger("MainMenu");
    }


   
    public void _redToglleChanged(bool newValue)
    {
        if (newValue)
            _chatMemberColorNumber = (int)_chatMemberColor.red;
    }
    public void _blueToglleChanged(bool newValue)
    {
        if (newValue)
            _chatMemberColorNumber = (int)_chatMemberColor.blue;
    }
    public void _greenToglleChanged(bool newValue)
    {
        if (newValue)
            _chatMemberColorNumber = (int)_chatMemberColor.green;
    }
    public void _blackToglleChanged(bool newValue)
    {
        if (newValue)
            _chatMemberColorNumber = (int)_chatMemberColor.black;
    }

    public void SendMessageBtn()
    {
        if (string.IsNullOrWhiteSpace(_inputMessage.text.Trim())) { return; }
        else
        {
            _connection.SendChatMessage(_inputMessage.text.Trim(), _chatMemberNickName, _chatMemberColorNumber);
           _inputMessage.text = "";
        }

    }

    public void ExitBtn()
    {
        Application.Quit();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter)) SendMessageBtn();
           
    }

}
