using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int sceneIndex = 0;
    public SceneTransition sceneTransition;
    public static int highScore = 0;

    // Start is called before the first frame update
    void Start()
    {
        if (!instance)
        {
            instance = this;
            DontDestroyOnLoad(this);
            
        } 
        else Destroy(this);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (sceneIndex == 0)
            {
                sceneIndex++;
                sceneTransition.StartTransition(sceneIndex);
                //SceneManager.LoadScene(sceneIndex);
            }
            
        }
    }

    public void LoadStart()
    {
        sceneIndex = 0;
        sceneTransition.StartTransition(sceneIndex);
    }
}
