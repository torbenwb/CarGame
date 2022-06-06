using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu]
public class SceneTransition : ScriptableObject
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private float transitionTime = 1.0f;

    private int nextSceneIndex;

    public void StartTransition(int nextSceneIndex)
    {
        this.nextSceneIndex = nextSceneIndex;

        GameObject prefabInstance = MonoBehaviour.Instantiate(prefab);
        Timer timer = prefabInstance.AddComponent<Timer>();
        timer.OnTimerEnd += FinishTransition;
        timer.StartTimer(transitionTime);
    }

    public void FinishTransition()
    {
        SceneManager.LoadScene(nextSceneIndex);
    }
}
