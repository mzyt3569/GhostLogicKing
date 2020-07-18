using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    FixedJoystick joystick;

    private void Awake() {
        joystick = GetComponent<FixedJoystick>();
    }

    private void FixedUpdate() {
        if (!CombatManager.cm.isCombat) {
            PlayerBehavior.pb.Move(joystick.Horizontal, joystick.Vertical);
        }
    }
}
