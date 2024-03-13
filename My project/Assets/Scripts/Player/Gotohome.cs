using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gotohome : MonoBehaviour
{

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Home")&&Input.GetKey(KeyCode.Space))
        {
            Debug.Log("Áý¿À±â");
            this.transform.position = new Vector3(300, 297, 0);
            GameManager.instance.gohome = true;
        }
    }
}
