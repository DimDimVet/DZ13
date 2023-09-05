using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TestEditorWin : EditorWindow
{
    private string[] settingsList;

    private bool buttonPress;

    [MenuItem("Window/Game Setting Window")]//��������� � ���� Window ������ Game Setting Window
    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(TestEditorWin));//GetWindow ��������� ���� 
    }

    void OnGUI()
    {
        GUILayout.Label("Game Setting", EditorStyles.boldLabel);//��� ���������� � ����

        settingsList = AssetDatabase.FindAssets("t:settings");//������ ������� � ������� settings
        GUILayout.Label("Game Settings",EditorStyles.boldLabel);//��� ���������� � ����
        GUILayout.Space(10);//������� ������ � ��������
        foreach (var item in settingsList)//������� ��������� ������ � ����� � �������
        {
            GUILayout.Label(AssetDatabase.GUIDToAssetPath(item), EditorStyles.label);//������� ��� ���������
        }

        buttonPress = GUILayout.Button("AAAAA");
        if (buttonPress)
        {
            foreach (var item in settingsList)//������� ��������� ������ � ����� � �������
            {
                var settingsFile = AssetDatabase.LoadAssetAtPath<Settings>(AssetDatabase.GUIDToAssetPath(item));//�� �������� ��������, ������� ������ � ���������� ��������
                settingsFile.HealtPlayer += 100;//� ��������� �������� ������ ��������
            }
            AssetDatabase.SaveAssets();//��������� ���������
        }

    }
}
