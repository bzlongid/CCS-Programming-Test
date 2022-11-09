using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEditorManager : MonoBehaviour
{
    public ButtonController[] ItemButtons;
    public GameObject[] ItemPrefabs;
    public int ButtonPressed; //the id of the button that was pressed

    GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        //want to instantiate an object in front of the player
        Vector3 PlayerPstn = player.transform.position;

        //check if button was pressed
        var leftHandDevices = new List<UnityEngine.XR.InputDevice>();
        UnityEngine.XR.InputDevice device = leftHandDevices[0];
        bool trigVal;
        if (device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.triggerButton, out trigVal) && trigVal && ItemButtons[ButtonPressed].Clicked)
        {
            ItemButtons[ButtonPressed].Clicked = false;
            Instantiate(ItemPrefabs[ButtonPressed], PlayerPstn + (transform.forward * 2), Quaternion.identity);
        }
    }
}
