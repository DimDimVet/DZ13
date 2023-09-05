using Firebase.Database;
using System;
using System.Collections;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class UpLoadDataPlayer : MonoBehaviour
{
    //UI
    [SerializeField] private Text saveData;
    [SerializeField] private Text loadLocalData;
    [SerializeField] private Text loadFireBaseData;
    //
    [SerializeField] private HealtComponent healtComponent;
    private string hashKey = "DataPlayer";
    //
    private DataPlayer dataPlayerFireBase;
    private DataPlayer dataPlayerLocal;
    private DataPlayer dataPlayerDefault;
    //Load settings
    public SettingsLoadData SettingsLoadData;

    private bool isFireBase = false;
    private bool isLocalBase = false;
    private bool isDefault = false;
    //Zenject
    private IData dataConfig;

    [Inject]
    public void Init(IData d)
    {
        dataConfig = d;
    }

    private void Awake()
    {
        StartCoroutine(Example());
        isFireBase = SettingsLoadData.isFireBase;
        isLocalBase = SettingsLoadData.isLocalBase;
        isDefault = SettingsLoadData.isDefault;
    }

    private IEnumerator Example()
    {
        int i = 0;
        while (i < 3)
        {
            FireBaseTool.LoadData(hashKey);
            yield return new WaitForSeconds(0.2f);
            i++;
        }
        LoadData();
    }
    
    ////Async/await
    private async void LoadData()
    {

        /*bool isFireBase =*/ await Task.FromResult(dataConfig.LoadDataFireBase(FireBaseTool.Snapshot, out dataPlayerFireBase));//�������� FireBase
        loadFireBaseData.text = $"healtPlayer={dataPlayerFireBase.healtPlayer} shootCount={dataPlayerFireBase.shootCount}";

        /*bool isLocalBase =*/ await Task.FromResult(dataConfig.LoadDataLocalBase(hashKey, out dataPlayerLocal));//�������� LocalBase
        loadLocalData.text = $"healtPlayer={dataPlayerLocal.healtPlayer} shootCount={dataPlayerLocal.shootCount}";

        dataConfig.LoadDataDefault(out dataPlayerDefault);

        if (isFireBase)//������� �������� ��������
        {
            GetData(dataPlayerFireBase);
        }
        else if (isLocalBase)//������� �������� ��������
        {
            GetData(dataPlayerLocal);
        }
        else if (isDefault)//������� �������� ��������
        {
            GetData(dataPlayerDefault);
        }

    }

    private void GetData(DataPlayer dataPlayer)//��������� ������� ������������
    {
        healtComponent.Healt = dataPlayer.healtPlayer;
        Statistic.ShootCount = dataPlayer.shootCount;//���������� � ���������� ������
    }

    //��� DZ11 ����
    public void GetDataMenu()
    {
        if (SettingsLoadData.isStartUpload)
        {
            isFireBase = SettingsLoadData.isFireBase;
            isLocalBase = SettingsLoadData.isLocalBase;
            isDefault = SettingsLoadData.isDefault;
            LoadData();
            healtComponent.UpData();//��� ���������� ������ � ������ �� ���������
            Statistic.isUpData = true;
            SettingsLoadData.isStartUpload = false;
        }

    }
    private void Update()
    {
        GetDataMenu();
    }
    void OnApplicationQuit()
    {
        if (SettingsLoadData.isSave)//������� ������ ���� ����� ���������� DZ11
        {
            SaveData();
        }
    }

    private void SaveData()
    {
        DataPlayer dataPlayer = new DataPlayer
        {
            healtPlayer = healtComponent.Healt,
            shootCount = Statistic.ShootCount
        };

        string rezult = dataConfig.SaveData(dataPlayer, hashKey);
        saveData.text = rezult;
    }

}

//srukture 
public struct DataPlayer
{
    public int shootCount;
    public int healtPlayer;
}


