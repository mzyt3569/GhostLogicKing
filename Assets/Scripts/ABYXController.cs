using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class ABYXController : MonoBehaviour
{
    public bool A, B, Y, X;

    private void Awake() {
        A = B = Y = X = false;
    }

    public void DownA() {
        A = true;
    }

    public void UpA() {
        A = false;
    }

    public void DownB() {
        B = true;
    }

    public void UpB() {
        B = false;
    }

    public void DownY() {
        Y = true;
    }

    public void UpY() {
        Y = false;
    }

    public void DownX() {
        X = true;
    }

    public void UpX() {
        X = false;
    }
}
