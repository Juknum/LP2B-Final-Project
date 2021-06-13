using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class brickBreakerMenu : MonoBehaviour
{
    public Button btn;

    // Start is called before the first frame update
    void Start()
    {
        Button btn2 = btn.GetComponent<Button>();
        btn.onClick.AddListener(PlayGame);
    }

    void PlayGame(){
        SceneManager.LoadScene("BrickBreaker");
    }
}
