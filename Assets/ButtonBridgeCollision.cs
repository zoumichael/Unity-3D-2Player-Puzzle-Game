using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBridgeCollision : MonoBehaviour
{
    [SerializeField] private BridgeBase bridge;
    private int numPressed = 0;

    void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.CompareTag("Player") || c.gameObject.CompareTag("Cube"))
        {
            numPressed = numPressed + 1;
            bridge.addButtonDown();
        }
    }

    private void OnTriggerExit(Collider c)
    {
        if (c.gameObject.CompareTag("Player") || c.gameObject.CompareTag("Cube"))
        {
            numPressed = numPressed - 1;
            bridge.removeButtonDown();
        }
    }
}
