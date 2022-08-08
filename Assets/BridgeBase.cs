using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeBase : MonoBehaviour
{
    // Variables used to determine whether the bridge needs to be retracted or not.
    private int buttonDown = 0;
    private bool expanded = false;
    private bool retracted = false;

    // Variables used to determine where the bridge needs to expand to. 
    [SerializeField] private float maxX;
    [SerializeField] private float maxZ;
    [SerializeField] private float minX;
    [SerializeField] private float minZ;

    [SerializeField] private bool left;
    [SerializeField] private bool down;

    [SerializeField] private float growthRate;

    private Vector3 locScale;
    private Vector3 location;


    private void Start()
    {
        locScale = transform.localScale;
        location = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(buttonDown == 0 && !retracted)
        {
            Retract();
        }
        else if(buttonDown > 0 && !expanded)
        {
            Expand();
        }
    }
    void Expand()
    {
        retracted = false;

        // Scale the bridge.
        locScale.x = locScale.x + (maxX - minX) * growthRate / 100f * Time.deltaTime;
        locScale.z = locScale.z + (maxZ - minZ) * growthRate / 100f * Time.deltaTime;

        if (locScale.x > maxX)
        {
            locScale.x = maxX;
            expanded = true;
        }
        if (locScale.z > maxZ)
        {
            locScale.z = maxZ;
            expanded = true;
        }
        transform.localScale = locScale;

        // Move the bridge
        if (left)
        {
            location.x = location.x + (maxX - minX) * growthRate / 200f * Time.deltaTime;
        }
        else
        {
            location.x = location.x - (maxX - minX) * growthRate / 200f * Time.deltaTime;
        }
        if (down)
        {
            location.z = location.z + (maxZ - minZ) * growthRate / 200f * Time.deltaTime;
        }
        else
        {
            location.z = location.z - (maxZ - minZ) * growthRate / 200f * Time.deltaTime;
        }
        transform.position = location;
    }
    void Retract()
    {
        expanded = false;
        locScale.x = locScale.x - (maxX - minX) * growthRate / 100f * Time.deltaTime;
        locScale.z = locScale.z - (maxZ - minZ) * growthRate / 100f * Time.deltaTime;

        if (locScale.x < minX)
        {
            locScale.x = minX;
            retracted = true;
        }
        if (locScale.z < minZ)
        {
            locScale.z = minZ;
            retracted = true;
        }
        transform.localScale = locScale;

        // Move the bridge
        if (left)
        {
            location.x = location.x - (maxX - minX) * growthRate / 200f * Time.deltaTime;
        }
        else
        {
            location.x = location.x + (maxX - minX) * growthRate / 200f * Time.deltaTime;
        }
        if (down)
        {
            location.z = location.z - (maxZ - minZ) * growthRate / 200f * Time.deltaTime;
        }
        else
        {
            location.z = location.z + (maxZ - minZ) * growthRate / 200f * Time.deltaTime;
        }
        transform.position = location;
    }

    public void addButtonDown()
    {
        buttonDown = buttonDown + 1;
    }

    public void removeButtonDown()
    {
        buttonDown = buttonDown - 1;
    }
}
