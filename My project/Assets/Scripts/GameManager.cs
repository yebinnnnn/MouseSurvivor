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

    //������ ����
    public Text ScoreText;
    public int score = 0;

    private void Awake()
    {
        if (instance == null) //�����ϰ� ���� ������
        {
            instance = this; //�ٽ� �ֽ�ȭ
            DontDestroyOnLoad(gameObject); //������� �ı� x
        }
        else
        {
            if (instance != this) //�ߺ����� �����ҽÿ��� �ı�
                Destroy(this.gameObject);
        }
    }
    public void AddScore(int num)
    {
        score += num; //������ �����ݴϴ�.
        ScoreText.text = "Score : " + score; //�ؽ�Ʈ�� �ݿ��մϴ�.
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
