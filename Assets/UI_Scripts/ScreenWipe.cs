using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenWipe : MonoBehaviour
{
    [SerializeField]
    [Range(0.1f,3f)]
    private float wipeSpeed = 1f;

    public float progress = 0f;
    public Image image;
    public int nextScene;

    public delegate void Handler(int nextScene);
    public event Handler OnFinishScreenWipe;
    // Start is called before the first frame update
    void Start()
    {
        
        image = GetComponentInChildren<Image>();
        image.fillAmount = 0f;

    }

    public void NextScene(int nextScene){
        if (progress > 0f) return;
        this.nextScene = nextScene;
        StartCoroutine("StartWipe");
    }

    IEnumerator StartWipe()
    {
        progress = 0f;
        while(progress < 1f){
            progress += wipeSpeed * Time.deltaTime;
            image.fillAmount = progress;
            

            yield return new WaitForEndOfFrame();
        }

        OnFinishScreenWipe?.Invoke(nextScene);

        progress = 0f;
        image.fillAmount = progress;
    }
}
