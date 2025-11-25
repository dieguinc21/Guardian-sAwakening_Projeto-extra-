using UnityEngine;
using TMPro;
public class PorcaoTerraHudController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI porçaoterraText;

    public void TextUpdate(int value)
    {
        porçaoterraText.text = value.ToString();
        
    }

}
