using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    public GameObject PlayerSample;
    public List<Transform> SpawnPonts;

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
        int id = PhotonNetwork.LocalPlayer.ActorNumber;
        Debug.Log("Подключен игрок" + id + " - " + PhotonNetwork.CurrentRoom.PlayerCount);
        //проверим на ошибку количества
        if (id > (SpawnPonts.Count+1))
        {
            Debug.Log("Нет свободной точки");
        }
        else
        {
            //если ок, то создаем префаб в точке взятую из листа
            PhotonNetwork.Instantiate(PlayerSample.name,SpawnPonts[id-1].position,Quaternion.identity);
        }
    }

    public void SayHello()//сказать фотону отправить указаный метод
    {
        //класс photonView является генератором пакета, требуется подвесить на gameobject(нейтральный) в проекте
        //важные настройки в инспекторе:синхронизации

        //имя метода вызова,укажем клиентов,укажем отправляемые параметры(к примеру взята инфа локального клиента)
        this.photonView.RPC("Hello", RpcTarget.All, (byte)PhotonNetwork.LocalPlayer.ActorNumber);
    }

    [PunRPC]//для того чтоб фотон знал о данном методе
    public void Hello(byte playerId)
    {
        Debug.Log($"Игрок ID {playerId} передал Привет");
    }
    void Update()
    {

    }
}
