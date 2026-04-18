using UnityEngine;

public class PlayerStatController : MonoBehaviour
{
    [SerializeField] private PlayerStatDataSO statData;

    public Stat HP { get; private set; }
    public Stat MoveSpeed { get; private set; }

    private void Awake()
    {
        HP = new Stat(statData.initialHP, statData.maxHP);
        MoveSpeed = new Stat(statData.moveSpeed);
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            HP.Value -= 10;
        }
    }
}
