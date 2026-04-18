using TMPro;
using UnityEngine;

public class TextSpeedStatUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI statText;
    
    public void SetText(float current)
    {
        statText.text = $"{current}";
    }
}
