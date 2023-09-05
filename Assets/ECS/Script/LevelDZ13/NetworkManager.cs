using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class NetworkManager : MonoBehaviourPunCallbacks
{

    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();//�������� �������� ������-������
    }

    //������� � �������� OnConnectedToMaster() ��� �������� ��������� ������-�������
    public override void OnConnectedToMaster()
    {
        //������� �������.��������, ������� ���������, ������ ��������
        RoomOptions roomOptions = new RoomOptions
        {
            MaxPlayers = 4,
            IsVisible = false
        };
        //��� ������, ���� �������, ��� �� ��������� - ������� � �������.�����������
        PhotonNetwork.JoinOrCreateRoom("TestDZ13", roomOptions, TypedLobby.Default);
    }

    //������� � �������� OnJoinedRoom()
    public override void OnJoinedRoom()
    {
        Debug.Log(PhotonNetwork.CurrentRoom.PlayerCount);
    }

    void Update()
    {

    }
}
