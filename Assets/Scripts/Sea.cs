using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Sea : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] PlayerShipController player;

    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public void OnPointerDown(PointerEventData pointerEventData)
    {
  /*   Vector3 moveTo=cam.ScreenToWorldPoint(pointerEventData.position);
        player.gameObject.transform.position = Vector2.Lerp(player.gameObject.transform.position, moveTo, Time.deltaTime * speed); */

    }
}
