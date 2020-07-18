using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public GameObject target;
    public float offsetX;
    public float offsetY;

    Camera cam;
    public Vector3 otherPos;

    private void Awake() {
        cam = GetComponent<Camera>();
    }

    private void LateUpdate() {
        if (!CombatManager.cm.isCombat) {
            Vector3 targetPos = target.transform.position;
            transform.position = new Vector3(targetPos.x + offsetX, targetPos.y + offsetY, transform.position.z);
        }
    }

    public void CombatStartCamMoveCor() {
        StartCoroutine("CombatStartCamMove");
    }

    IEnumerator CombatStartCamMove() {
        transform.position = new Vector3(otherPos.x, otherPos.y, transform.position.z);

        for (int i = 0; i < 20; i++) {
            cam.orthographicSize -= 0.1f;
            yield return new WaitForSeconds(0.01f);
        }
    }

    public void CombatEndCamMoveCor() {
        StartCoroutine("CombatEndCamMove");
    }

    IEnumerator CombatEndCamMove() {
        otherPos = target.transform.position;

        for (int i = 0; i < 20; i++) {
            cam.orthographicSize += 0.1f;
            yield return new WaitForSeconds(0.01f);
        }
    }
}
