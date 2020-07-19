using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombatManager : MonoBehaviour
{
    public static CombatManager cm;

    public ABYXController abyx;

    public CameraMove camMove;
    public GameObject combatPanel;
    Text patternText;
    Text timerText;

    public bool isCombat;
    int timer;
    int timeLimit;
    bool timeOut;
    bool attackSuccess;

    private void Awake() {
        cm = this;

        combatPanel.SetActive(false);
        patternText = combatPanel.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>();
        timerText = combatPanel.transform.GetChild(1).GetComponent<Text>();

        isCombat = false;
        timer = 0;
        timeLimit = 3;
        timeOut = false;
        attackSuccess = false;
    }

    public void CombatStart(Enemy enemy) {
        isCombat = true;
        camMove.otherPos = enemy.transform.position;
        camMove.CombatStartCamMoveCor();
        combatPanel.SetActive(true);
        PlayerBehavior.pb.CombatStart();

        StartCoroutine("Combat", enemy);
    }

    IEnumerator Combat(Enemy enemy) {
        // 1 pattern
        patternText.text = "press x";
        attackSuccess = false;
        StartCoroutine("Timer");
        while (true) {
            if (abyx.X) {
                StopCoroutine("Timer");
                attackSuccess = true;
                break;
            }
            else if (abyx.A || abyx.B || abyx.Y) {
                StopCoroutine("Timer");
                attackSuccess = false;
                break;
            }
            if (timeOut) {
                attackSuccess = false;
                break;
            }
            yield return new WaitForFixedUpdate();
        }
        if (attackSuccess) {
            timerText.text = "<color=#0000ff> O </color>";
            Debug.Log("Enemy Damage");
        }
        else {
            timerText.text = "<color=#ff0000> X </color>";
            Debug.Log("Player Damage");
        }
        timer = 0;
        timeLimit = 3;
        timeOut = false;
        attackSuccess = false;
        yield return new WaitForSeconds(1f);

        // 2 pattern
        patternText.text = "press not x";
        attackSuccess = false;
        StartCoroutine("Timer");
        while (true) {
            if (abyx.A || abyx.B || abyx.Y) {
                StopCoroutine("Timer");
                attackSuccess = true;
                break;
            }
            else if (abyx.X) {
                StopCoroutine("Timer");
                attackSuccess = false;
                break;
            }
            if (timeOut) {
                attackSuccess = false;
                break;
            }
            yield return new WaitForFixedUpdate();
        }
        if (attackSuccess) {
            timerText.text = "<color=#0000ff> O </color>";
            Debug.Log("Enemy Damage");
        }
        else {
            timerText.text = "<color=#ff0000> X </color>";
            Debug.Log("Player Damage");
        }
        timer = 0;
        timeLimit = 3;
        timeOut = false;
        attackSuccess = false;
        yield return new WaitForSeconds(1f);

        // 3 pattern
        patternText.text = "press \n x or a";
        attackSuccess = false;
        StartCoroutine("Timer");
        while (true) {
            if (abyx.A || abyx.X) {
                StopCoroutine("Timer");
                attackSuccess = true;
                break;
            }
            else if (abyx.B || abyx.Y) {
                StopCoroutine("Timer");
                attackSuccess = false;
                break;
            }
            if (timeOut) {
                attackSuccess = false;
                break;
            }
            yield return new WaitForFixedUpdate();
        }
        if (attackSuccess) {
            timerText.text = "<color=#0000ff> O </color>";
            Debug.Log("Enemy Damage");
        }
        else {
            timerText.text = "<color=#ff0000> X </color>";
            Debug.Log("Player Damage");
        }
        timer = 0;
        timeLimit = 3;
        timeOut = false;
        attackSuccess = false;
        yield return new WaitForSeconds(1f);

        // 4 pattern
        patternText.text = "press \n not y and not a";
        attackSuccess = false;
        StartCoroutine("Timer");
        while (true) {
            if (abyx.X || abyx.B) {
                StopCoroutine("Timer");
                attackSuccess = true;
                break;
            }
            else if (abyx.A || abyx.Y) {
                StopCoroutine("Timer");
                attackSuccess = false;
                break;
            }
            if (timeOut) {
                attackSuccess = false;
                break;
            }
            yield return new WaitForFixedUpdate();
        }
        if (attackSuccess) {
            timerText.text = "<color=#0000ff> O </color>";
            Debug.Log("Enemy Damage");
        }
        else {
            timerText.text = "<color=#ff0000> X </color>";
            Debug.Log("Player Damage");
        }
        timer = 0;
        timeLimit = 3;
        timeOut = false;
        attackSuccess = false;
        yield return new WaitForSeconds(1f);

        // 5 pattern
        patternText.text = "press \n not not not a";
        attackSuccess = false;
        StartCoroutine("Timer");
        while (true) {
            if (abyx.X || abyx.B || abyx.Y) {
                StopCoroutine("Timer");
                attackSuccess = true;
                break;
            }
            else if (abyx.A) {
                StopCoroutine("Timer");
                attackSuccess = false;
                break;
            }
            if (timeOut) {
                attackSuccess = false;
                break;
            }
            yield return new WaitForFixedUpdate();
        }
        if (attackSuccess) {
            timerText.text = "<color=#0000ff> O </color>";
            Debug.Log("Enemy Damage");
        }
        else {
            timerText.text = "<color=#ff0000> X </color>";
            Debug.Log("Player Damage");
        }
        timer = 0;
        timeLimit = 3;
        timeOut = false;
        attackSuccess = false;
        yield return new WaitForSeconds(1f);

        yield return new WaitForSeconds(1f);
        CombatEnd();
    }

    void CombatEnd() {
        isCombat = false;
        timer = 0;
        timeLimit = 3;
        timeOut = false;
        attackSuccess = false;

        camMove.CombatEndCamMoveCor();
        combatPanel.SetActive(false);
        isCombat = false;
    }

    IEnumerator Timer() {
        timeOut = false;
        while (timer < timeLimit) {
            timerText.text = (timeLimit - timer).ToString();
            yield return new WaitForSeconds(1f);
            timer++;
        }
        timerText.text = "";
        timeOut = true;
    }
}
