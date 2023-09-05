using UnityEngine;

[CreateAssetMenu]
public class SettingsLoadData : ScriptableObject
{
    public bool isFireBase = true;
    public bool isLocalBase = false;
    public bool isDefault = false;
    //��� ��������� ������
    public bool isStartUpload = false;
    public bool isSave = true;
}
