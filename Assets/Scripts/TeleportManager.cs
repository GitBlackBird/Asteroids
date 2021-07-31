using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Bourders {
    public float topBourder, bottomBourder, leftBourder, rightBourder;
}
public class TeleportManager : MonoBehaviour
{
    public Bourders bourders;

    // Update is called once per frame
    void Update()
    {
        var pos = this.transform.position;
        var x = this.transform.position.x;
        var y = this.transform.position.y;

        if (x > bourders.rightBourder) {
            pos.x = bourders.leftBourder;
            transform.position = pos;
        }
        if (x < bourders.leftBourder) {
            pos.x = bourders.rightBourder;
            transform.position = pos;
        }
        if (y > bourders.topBourder) {
            pos.y = bourders.bottomBourder;
            transform.position = pos;
        }
        if (y < bourders.bottomBourder) {
            pos.y = bourders.topBourder;
            transform.position = pos;
        }
    }
}
