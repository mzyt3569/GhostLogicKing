using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;

    private void Awake() {
        gm = this;
    }

    private void FixedUpdate() {
        //PlayerBehavior.pb.Move(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }
}
