using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStatData", menuName = "Stats/PlayerStatData")]
public class PlayerStatDataSO : ScriptableObject
{
    [Header("HP")]
    public float maxHP = 100f;
    public float initialHP = 100f;

    [Header("이동속도")]
    public float moveSpeed = 5f;
}

