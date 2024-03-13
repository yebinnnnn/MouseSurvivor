using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance ;
    public int movelevel = 10;
    public bool turn=true;
    public bool gohome= false;

    //유지할 값들
    public Text ScoreText;
    public int score = 0;

    private void Awake()
    {
        if (instance == null) //존재하고 있지 않을때
        {
            instance = this; //다시 최신화
            DontDestroyOnLoad(gameObject); //씬변경시 파괴 x
        }
        else
        {
            if (instance != this) //중복으로 존재할시에는 파괴
                Destroy(this.gameObject);
        }
    }
    public void AddScore(int num)
    {
        score += num; //점수를 더해줍니다.
        ScoreText.text = "Score : " + score; //텍스트에 반영합니다.
    }

    public void Update()
    {
        if (turn&&score == movelevel)
        {
            turn = false;
            SceneManager.LoadScene("Main2");
        }
    }
}
