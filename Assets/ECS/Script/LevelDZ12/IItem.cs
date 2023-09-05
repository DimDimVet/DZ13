using UnityEngine;

public interface IItem1 
{
    GameObject ItemUI { get;}
    void UseItem(CharacterData data);//реализация логики работы с инвентарем
}
