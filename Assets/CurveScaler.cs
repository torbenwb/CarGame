using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurveScaler : MonoBehaviour
{
    [SerializeField] private Curve linkedCurve;

    private Vector3 initialScale;

    private void Start(){
        initialScale = transform.localScale;

        if (linkedCurve){
            linkedCurve.OnCurveUpdate += CurveUpdateCallback;
        }
    }

    private void OnDisable(){
        if (linkedCurve){
            linkedCurve.OnCurveUpdate -= CurveUpdateCallback;
        }
    }

    public void CurveUpdateCallback(){
        transform.localScale = initialScale * linkedCurve.Value;
    }
}
