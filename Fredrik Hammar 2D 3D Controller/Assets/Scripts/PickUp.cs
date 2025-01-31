﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    // Start is called before the first frame update
   
    public GameObject Player;
    public GameObject Item;
    private SpelarentreD TreD;
    private bool thisobjectisheld = false;
    private Rigidbody rigid;
    private float turnSpeed = 5000f;
    private Transform ItemPlacer;
    private GameObject ItemPlacerGameObject;
    private float timer = 0;
    void Awake()
    {
        TreD = Player.GetComponent<SpelarentreD>();
        rigid = Item.GetComponent<Rigidbody>();
        ItemPlacer = Player.gameObject.transform.Find("LayDownItem");
        ItemPlacerGameObject = ItemPlacer.gameObject;

    }

    // Update is called once per frame
    void Update()
    {
        if (thisobjectisheld && timer < 1)
        {
            timer += 1 * Time.deltaTime;
            Debug.Log(timer);

        }
        if (Input.GetKey(KeyCode.E) && TreD.objectHeld == true && timer >= 1)
        {
            ItemPlacerGameObject.SetActive(true);
            ItemPlacer.transform.Rotate(0, turnSpeed * Time.deltaTime, 0);
            //   turnSpeed += turnSpeed * Time.deltaTime;
           
        }
        if (TreD != null)
        {
            if (Input.GetKeyUp(KeyCode.E) && TreD.objectHeld == true && thisobjectisheld == true && timer >= 1 || TreD.playerStateHandler.current.GetType().Equals(TreD.nonCorporeal.GetType()) && thisobjectisheld == true)
            {

                //ItemPlacer.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                rigid.constraints = RigidbodyConstraints.None;
                rigid.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezePositionX;
                Item.transform.position = ItemPlacer.transform.position;// Player.transform.position - new Vector3(1, -1, 0);
                Item.transform.parent = null;
                TreD.objectHeld = false;
                thisobjectisheld = false;
                ItemPlacerGameObject.SetActive(false);
                timer = 0;
            }
        }

    }
    private void OnTriggerStay(Collider other)
    {

        if(other.tag == "Player")
        {
            if (!TreD.NonCorporeal())
            {
                if (Input.GetKeyDown(KeyCode.E) && TreD.objectHeld == false && thisobjectisheld == false)
                {
                    rigid.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezePositionX;

                    // Debug.Log("E");
                    Item.transform.position = Player.transform.position + new Vector3(0, 1, 0);
                    // Item.rigidbody.
                    Item.transform.parent = Player.transform;
                    thisobjectisheld = true;
                    TreD.objectHeld = true;

                    // Item.transform.SetParent(Player.transform.parent);
                } 
            }
            
                
            

        }
    }
}
