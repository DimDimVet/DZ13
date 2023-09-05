using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


[CanEditMultipleObjects]//������� ������ �������� ������ ����
[CustomEditor(typeof(Settings))]//������ ��������� ���������� ��� ������ ������� ��������
public class TestEditorInspector : Editor
{
    private SerializedProperty health;//������ �� ����
    private bool setHealth;

    private void OnEnable()
    {
        health = serializedObject.FindProperty("HealtPlayer");//� ��������� ��� ���� � ��������� ���� � ������� ��������
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();//��������� � �������
        //
        GUILayout.Label(health.intValue.ToString());//� ����� ��� ������� ��������(intValue)
        base.OnInspectorGUI();//��� ������� �� �������� ������ ������� ���
        GUILayout.Space(10);//������� ������ � ��������
        //
        EditorGUILayout.PropertyField(health);//������ ��� ����
        GUILayout.Label(health.intValue.ToString());//������� ������ ��������
        setHealth = GUILayout.Button("Set Health back to 100");//�������� ������ � ���������� � ����� �� ���
        if (setHealth)//������ ������ ������
        {
            health.intValue = 100;//������� �������� � ���� health
        }
        serializedObject.ApplyModifiedProperties();//�������� �� ���� �������� �����, �������� ��������
    }

    private void OnSceneGUI()//�� �� ������ � ���� �����
    {
        Vector3 newVector = new Vector3(4,5,6);//� ����� ��������� ������ �������
        Handles.Label(newVector,"��� ��");
    }
}
