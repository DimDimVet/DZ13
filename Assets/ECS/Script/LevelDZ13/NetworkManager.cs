using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class NetworkManager : MonoBehaviourPunCallbacks
{

    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();//запустим тестовый мастер-сервер
    }

    //возьмем в родителе OnConnectedToMaster() для создания тестового мастер-сервера
    public override void OnConnectedToMaster()
    {
        //создали экземпл.настроек, выбрали настройку, задали значение
        RoomOptions roomOptions = new RoomOptions
        {
            MaxPlayers = 4,
            IsVisible = false
        };
        //при старте, ищет комнату, при ее отсутсвии - создает с предуст.настройками
        PhotonNetwork.JoinOrCreateRoom("TestDZ13", roomOptions, TypedLobby.Default);
    }

    //возьмем в родителе OnJoinedRoom()
    public override void OnJoinedRoom()
    {
        Debug.Log(PhotonNetwork.CurrentRoom.PlayerCount);
    }

    void Update()
    {

    }
}
