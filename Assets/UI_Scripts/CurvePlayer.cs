using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurvePlayer : MonoBehaviour
{
    public static CurvePlayer instance;

    private List<Curve> activeCurves = new List<Curve>();


    private void Awake(){
        if (instance) Destroy(this);
        else instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        int i = 0;

        while(i < activeCurves.Count)
        {
            if (activeCurves[i].UpdateCurve(Time.deltaTime)){
                i++;
            }
            else{
                activeCurves.RemoveAt(i);
            }
        }
    }

    public static void PlayCurve(Curve curve){
        MakeInstance();

        if (!instance.activeCurves.Contains(curve)){
            instance.activeCurves.Add(curve);
        }
    }

    public static void MakeInstance(){
        if (!instance){
            GameObject CurvePlayer = new GameObject("Curve Player");
            CurvePlayer.AddComponent<CurvePlayer>();
        }
    }
}
