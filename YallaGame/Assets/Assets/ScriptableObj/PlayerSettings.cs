using UnityEngine;

[CreateAssetMenu(fileName = "PlayerSettings", menuName = "Scriptable Objects/PlayerSettings")]
public class PlayerSettings : ScriptableObject
{
    public int playerMaxHealth = 3;
    public float playerMoveSpeed = 5f;           // Текущая скорость вперёд
    public float playerSideSpeed = 7f;   
}
