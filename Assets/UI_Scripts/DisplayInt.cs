using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayInt : MonoBehaviour
{
    public Text text;
    public string precedingString;
    public Int displayValue;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        text.text = precedingString + displayValue.RuntimeValue;
    }
}
