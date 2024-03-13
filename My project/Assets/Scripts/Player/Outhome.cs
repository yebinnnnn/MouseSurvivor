using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Outhome : MonoBehaviour
{

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Point") && Input.GetKey(KeyCode.Space)&& GameManager.instance.gohome&&!other.CompareTag("Home"))
        {
            Debug.Log("³ª°¡±â");
            this.transform.position = new Vector3(0, -6, 0);
            GameManager.instance.gohome = false;
        }
    }
}
