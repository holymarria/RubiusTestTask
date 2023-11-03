using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DropDown : MonoBehaviour
{
    public TMP_Dropdown dropdown; 
    private void Start()
    {

        dropdown.interactable = false;
        StartCoroutine(DropDownDelay(2f));
    }
    IEnumerator DropDownDelay(float delay)
    {
        dropdown.interactable = false;
        yield return new WaitForSeconds(delay);
        dropdown.interactable = true;
    }
}
