using UnityEngine;
using TMPro;
public class DiamanteHudController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI diamanteText;

    public void TextUpdate(int value)
    {
        diamanteText.text = value.ToString();
        
    }

}
