using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FOV : CurveScaler
{
    private float initialFOV;

    public override void OnStart()
    {
        base.OnStart();
        initialFOV = Camera.main.fieldOfView;
    }

    public override void CurveUpdateCallback()
    {
        base.CurveUpdateCallback();
        Camera.main.fieldOfView = initialFOV + (linkedCurve.Value - 1.0f) * curveScale;
    }
}
