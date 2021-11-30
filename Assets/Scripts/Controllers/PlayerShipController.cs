using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerShipController : MonoBehaviour
{

    [SerializeField] float speed;
    [SerializeField] float rotationSpeed;
    [SerializeField] float bulletSpawnRate;

    [SerializeField] Camera cam;
    [SerializeField] UIController UI;

    private void OnDestroy()
    {
        if(UI!=null)
        UI.SetActiveGameOver();
        Time.timeScale = 0;
       
    }

    private Vector3 _moveTo;
    private int bulletsCount=0;

    [SerializeField] ShipBullet bullet;

    enum MoveState
    {
        isMoving,
        notMoving
    }
    MoveState moveState = MoveState.notMoving;

    void Start()
    {
        InvokeRepeating("addBullet", 0.1f, bulletSpawnRate);
    }

    private void addBullet()
    {
        bulletsCount++;
    }

   
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            _moveTo = cam.ScreenToWorldPoint(Input.mousePosition);
            moveState = MoveState.isMoving;
 
        }

        if (Input.GetMouseButtonDown(1) &&  bulletsCount>0)
        {
            bulletsCount--;
            ShipBullet currentBullet= Instantiate(bullet, transform.position, Quaternion.identity);
            Vector3 shotTo = cam.ScreenToWorldPoint(Input.mousePosition);
            currentBullet.SetPosition((shotTo - transform.position).normalized);

        }

    }

    private void FixedUpdate()
    {
        if (moveState == MoveState.isMoving)
        {

            if (Vector2.Distance(transform.position, _moveTo) < 0.5)
            {
                moveState = MoveState.notMoving;
            }
            else
            {

                transform.position = Vector2.MoveTowards(transform.position, _moveTo, Time.deltaTime * speed);
                Vector3 diff = _moveTo - transform.position;
                diff.Normalize();

                float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;

                Quaternion rotate = Quaternion.Euler(0f, 0f, rot_z - 90);

                transform.rotation = Quaternion.Lerp(transform.rotation, rotate, Time.deltaTime * rotationSpeed);
            }

           

        }
    }



}
