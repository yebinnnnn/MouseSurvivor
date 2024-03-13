using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dontdes : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
