using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUpHealt : MonoBehaviour, ILevelUp
{
    private HealtComponent healtData;

    public int minLvl;
    public int MinLvl => minLvl;

    private void Awake()
    {
        healtData = GetComponent<HealtComponent>();
    }
    public void LevelUp(CharacterData data, int lvl)
    {
        if (healtData == null)
        {
            return;
        }
        if (data.CurrentLvl>= MinLvl)//проверим на минимальный порог лвл
        {
            healtData.LvlUpData(500);//запишем и обновим
        }
    }
}
