using UnityEngine;
using TMPro;
public class MoedaHudController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI moedaText;

    public void TextUpdate(int value)
    {
        moedaText.text = value.ToString();
        
    }

}
