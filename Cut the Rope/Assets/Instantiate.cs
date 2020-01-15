
using UnityEngine;
using UnityEngine.UI;

public class Instantiate : MonoBehaviour
{
    public GameObject LinkGenerator;
    
    public void OnClick()
    
    {
        Instantiate(LinkGenerator);
  
    }
}
