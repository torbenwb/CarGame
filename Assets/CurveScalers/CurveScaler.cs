using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurveScaler : MonoBehaviour
{
    [SerializeField] protected Curve linkedCurve;
    [SerializeField] protected float curveScale = 1.0f;

    private void Start(){
        OnStart();
        
        if (linkedCurve){
            linkedCurve.OnCurveUpdate += CurveUpdateCallback;
        }
    }

    private void OnDisable(){
        if (linkedCurve){
            linkedCurve.OnCurveUpdate -= CurveUpdateCallback;
        }
    }

    public virtual void OnStart(){

    }

    public virtual void CurveUpdateCallback(){
        //transform.localScale = initialScale * linkedCurve.Value;
        //print("Curve update callback");
    }
}
