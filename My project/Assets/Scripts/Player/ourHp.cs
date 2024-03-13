using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ourHp : MonoBehaviour
{
    private float curHealth; //* ���� ü��
    private float maxHealth; //* �ִ� ü��
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

    public void SetHp(float amount) //*�ʱ�Hp����
    {
        maxHealth = amount;
        curHealth = maxHealth;
        CheckHp();
    }

    public void CheckHp() //*HP ����
    {
        if (HpBarSlider != null)
            HpBarSlider.value = curHealth / maxHealth;
    }

    void OnTriggerEnter2D(Collider2D other) //�¾����� ��ó��, ���ó��, ���߿� ����� �ҷ����⵵ �߰�
    {
        if (other.CompareTag("Enemy") && other.gameObject.activeSelf)
        {
            Damage(damage);
        }
    }

    public void Damage(float damage) //* ������ �޴� �Լ�
    {
        curHealth -= damage;
        CheckHp(); //* ü�� ����

        if (curHealth <= 0)
        {
            Debug.Log("ü�¿���");
            Destroy(this.gameObject);
            SceneManager.LoadScene("DieScene");
        }

    }

    void OnTriggerStay2D(Collider2D other) //�¾����� ��ó��, ���ó��, ���߿� ����� �ҷ����⵵ �߰�
    {
        if(other.CompareTag("HealPoint")&&isHealth)
        {
            keepheal();
        }
    }

    void keepheal()
    {
            Debug.Log("ȸ�����Դϴ�");
            if (curHealth <= maxHealth)
            {
                curHealth += healscale;
                CheckHp();
                isHealth = false;
        }
    }
}
