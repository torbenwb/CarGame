using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformScale : CurveScaler
{
    Vector3 initialScale;

    public override void OnStart()
    {
        base.OnStart();
        initialScale = transform.localScale;

    }

    public override void CurveUpdateCallback()
    {
        base.CurveUpdateCallback();
        transform.localScale = initialScale * linkedCurve.Value * curveScale;
    }
}
