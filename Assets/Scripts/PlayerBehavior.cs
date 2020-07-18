using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    public static PlayerBehavior pb;

    Animator anim;

    public float moveSpeed = 1f;

    private void Awake() {
        pb = this;

        anim = transform.GetChild(0).GetComponent<Animator>();
    }

    public void Move(float horizontal, float vertical) {
        Vector3 moveVector = new Vector3(horizontal, vertical, 0);
        if (horizontal + vertical >= 1f) {
            moveVector = moveVector.normalized;
        }

        // 방향에 따른 회전
        if (horizontal > 0f)
            transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 0f));
        else if (horizontal < 0f)
            transform.rotation = Quaternion.Euler(new Vector3(0f, 180f, 0f));

        // 이동
        transform.position += moveVector * moveSpeed * Time.deltaTime;

        // Animation
        anim.SetFloat("Speed", moveVector.magnitude);
        if (moveVector.magnitude > 0f) {
            if (vertical > 0) {
                anim.SetInteger("Direction", 2);
            }
            else if (vertical < 0) {
                anim.SetInteger("Direction", 0);
            }
            if (Mathf.Abs(horizontal) >= 0.5f) {
                anim.SetInteger("Direction", 1);
            }
        }
    }

    public void CombatStart() {
        anim.SetFloat("Speed", 0);
    }
}
