using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class GamepadConnections : UnityEvent<int, int> { }

public class Mg_GamepadInputAdapter : MonoBehaviour {

    public bool playstationController, xboxController, keyboard;
    public string[] currentControllers;
    public float controllerCheckTimer = 2;

    public int gamepad1;
    int gamepad1Last;
    public int gamepad2;
    int gamepad2Last;

    GamepadConnections gamepadConnectionsChanged;

    private void Start () {
        ControllerCheck();
    }

    public void ControllerCheck () {
        System.Array.Clear(currentControllers, 0, currentControllers.Length);
        System.Array.Resize<string>(ref currentControllers, Input.GetJoystickNames().Length);
        int numberOfControllers = 0;
        for (int i = 0; i < Input.GetJoystickNames().Length; i++) {
            currentControllers[i] = Input.GetJoystickNames()[i].ToLower();
            if ((currentControllers[i] == "controller (xbox 360 for windows)" || currentControllers[i] == "controller (xbox 360 wireless receiver for windows)" || currentControllers[i] == "controller (xbox one for windows)")) {
                xboxController = true;
                keyboard = false;
                playstationController = false;
                if (i == 0)
                    gamepad1 = 1;
                else if (i == 1)
                    gamepad2 = 1;
            }
            else if (currentControllers[i] == "wireless controller") {
                playstationController = true; //not sure if wireless controller is just super generic but that's what DS4 comes up as.
                keyboard = false;
                xboxController = false;
                if (i == 0)
                    gamepad1 = 2;
                else if (i == 1)
                    gamepad2 = 2;
            }
            else if (currentControllers[i] == "") {
                numberOfControllers++;
                if (i == 0)
                    gamepad1 = 0;
                else if (i == 1)
                    gamepad2 = 0;
            }
        }
        if (numberOfControllers == Input.GetJoystickNames().Length) {
            keyboard = true;
            xboxController = false;
            playstationController = false;
        }
        if (gamepad1 != gamepad1Last || gamepad2 != gamepad2Last)
            gamepadConnectionsChanged.Invoke(gamepad1, gamepad2);
        gamepad1Last = gamepad1;
        gamepad2Last = gamepad2;
        Invoke("ControllerCheck", controllerCheckTimer);
    }
}
