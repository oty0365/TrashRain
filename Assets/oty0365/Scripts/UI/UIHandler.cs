using UnityEngine;

public class PlayerHUDHandler : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private TextHPStatUI hpStatUI;
    [SerializeField] private TextSpeedStatUI speedStatUI;

    private void Start()
    {
        if (player == null)
        {
            Debug.LogError("Player reference is not set in PlayerHUDHandler.");
        }
        else
        {
            var playerStats = player.GetComponent<PlayerStatController>();
            playerStats.HP.OnValueChangedWithMax += hpStatUI.SetText;
            playerStats.MoveSpeed.OnValueChanged += speedStatUI.SetText;
            playerStats.HP.ForceNotify();
            playerStats.MoveSpeed.ForceNotify();
        }
    }

}

