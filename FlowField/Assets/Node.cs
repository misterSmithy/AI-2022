﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    [SerializeField]
    private Vector3 flowDirection;

    [SerializeField]
    //even index are direct, odds are diagonal, starting with x+1 and continuing clockwise
    private Node[] connections = new Node[8];
    private bool available = true;
    private float weight = 1;


    [SerializeField]
    private Material active, inactive;

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Agent")
        {
            other.GetComponent<AgentMovement>().SetDirection(flowDirection);
        }
    }


    public Vector3 GetFlow()
    {
        return flowDirection;
    }

    public Node GetConnection(int loc)
    {
        return connections[loc];
    }

    public void SetFlow(Vector3 dir)
    {
        flowDirection = dir.normalized;
        //change indicator to point correctly
        transform.GetChild(0).rotation = Quaternion.LookRotation(flowDirection);
    }

    public void SetConnection(int loc, Node toSet)
    {
        connections[loc] = toSet;
    }

    public bool GetAvailable()
    {
        return available;
    }

    public void ToggleAvailable()
    {
        available = !available;
        if(available)
        {
            transform.GetChild(1).GetChild(0).GetComponent<MeshRenderer>().material = active;
        }
        else
        {
            transform.GetChild(1).GetChild(0).GetComponent<MeshRenderer>().material = inactive;
        }
        //transform.GetChild(0).gameObject.SetActive(available);
    }

    public float GetWeight()
    {
        return weight;
    }
}