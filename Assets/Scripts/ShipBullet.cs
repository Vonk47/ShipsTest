using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipBullet : MonoBehaviour
{

    private Vector3  _moveDir;
    private bool isActive;
    [SerializeField] float speed;


    bool isShooting;

    private void FixedUpdate()
    {
        if (isShooting) transform.position += _moveDir * speed * Time.deltaTime; 
    }

    private void InitDamage() { isActive = true; }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8 && isActive)
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }

    public void SetPosition(Vector3 pos)
    {
        _moveDir = pos;
        _moveDir.z = 0;
        isShooting = true;
        Invoke("InitDamage", 0.2f);
    }


}
