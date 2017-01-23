using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float _speed;

    void Update()
    {
        transform.position += transform.right * _speed * Time.deltaTime;
    }

}
