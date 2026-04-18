using TMPro;
using UnityEngine;

public class TextHPStatUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI statText;
    
    public void SetText(float current,float max)
    {
        statText.text = $"{current}/{max}";
    }
}
