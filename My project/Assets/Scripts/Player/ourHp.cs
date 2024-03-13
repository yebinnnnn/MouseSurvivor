using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ourHp : MonoBehaviour
{
    private float curHealth; //* 현재 체력
    private float maxHealth; //* 최대 체력
    public float amount;
    public float damage = 10.0f;
    public Slider HpBarSlider;
    public float healscale = 10.0f;
    private float timer = 0f;
    private bool isHealth=false;

    void Start()
    {
        SetHp(amount);
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 1.0f)
        {
            isHealth = true;
            timer = 0f;
        }
    }

    public void SetHp(float amount) //*초기Hp설정
    {
        maxHealth = amount;
        curHealth = maxHealth;
        CheckHp();
    }

    public void CheckHp() //*HP 갱신
    {
        if (HpBarSlider != null)
            HpBarSlider.value = curHealth / maxHealth;
    }

    void OnTriggerEnter2D(Collider2D other) //맞았을때 피처리, 사망처리, 나중에 사망씬 불러오기도 추가
    {
        if (other.CompareTag("Enemy") && other.gameObject.activeSelf)
        {
            Damage(damage);
        }
    }

    public void Damage(float damage) //* 데미지 받는 함수
    {
        curHealth -= damage;
        CheckHp(); //* 체력 갱신

        if (curHealth <= 0)
        {
            Debug.Log("체력오버");
            Destroy(this.gameObject);
            SceneManager.LoadScene("DieScene");
        }

    }

    void OnTriggerStay2D(Collider2D other) //맞았을때 피처리, 사망처리, 나중에 사망씬 불러오기도 추가
    {
        if(other.CompareTag("HealPoint")&&isHealth)
        {
            keepheal();
        }
    }

    void keepheal()
    {
            Debug.Log("회복중입니다");
            if (curHealth <= maxHealth)
            {
                curHealth += healscale;
                CheckHp();
                isHealth = false;
        }
    }
}
