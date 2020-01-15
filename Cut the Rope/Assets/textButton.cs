using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textButton : MonoBehaviour
{


    public Text outputText;

   
  public void OnClick()
    {
        outputText.text = " This code is working";

    }
}
