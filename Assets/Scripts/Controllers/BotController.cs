using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotController : MonoBehaviour
{
    [SerializeField] PlayerShipController player;
    [SerializeField] float speed=1;
    [SerializeField] float rotationSpeed = 3;
    [SerializeField] ShipBullet bullet;

    void Start()
    {
        InvokeRepeating("Shoot", 4f, 5f);
    }

    

    private void FixedUpdate()
    {
        if (player != null)
        {

            if (Vector2.Distance(transform.position, player.transform.position) > 6)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.transform.position, Time.deltaTime * speed);
               
            }
            Quaternion rotate = Quaternion.Euler(0f, 0f, player.transform.eulerAngles.z);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotate, Time.deltaTime * rotationSpeed);

        }
    }

    private void Shoot()
    {
        ShipBullet currentBullet = Instantiate(bullet, transform.position, Quaternion.identity);
        Vector3 shotTo = player.transform.position;
        currentBullet.SetPosition((shotTo - transform.position).normalized);
    }
    public void SetPlayer(PlayerShipController _player)
    {
        player = _player;
    }
}
