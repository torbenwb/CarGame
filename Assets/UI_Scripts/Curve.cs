using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Curve : ScriptableObject
{
    [SerializeField] private AnimationCurve curve;
    [SerializeField] private float updateRate = 0.02f;

    public delegate void CurveUpdateHandler();
    public event CurveUpdateHandler OnCurveUpdate;

    public float Value{
        get {
            return curve.Evaluate(curveTime);
        }
    }

    float curveTime = 0.0f;
    float curveEndTime = 0.0f;

    public void PlayCurve(){
        curveTime = 0.0f;
        curveEndTime = curve[curve.length - 1].time;
        CurvePlayer.PlayCurve(this);
    }

    public bool UpdateCurve(float update){
        MonoBehaviour.print("Update curve");
        curveTime += update;
        OnCurveUpdate?.Invoke();

        return curveTime < curveEndTime;
    }
}
