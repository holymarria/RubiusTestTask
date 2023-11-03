using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class ButtonFor3 : MonoBehaviour
{
    public List<GameObject> objectsToExecuteCode = new List<GameObject>(); // Список объектов для выполнения кода
    public Button button;
    public TMP_Dropdown dropdown;

    public void ExecuteCodeOnObjects()
    {
        StartCoroutine(ExecuteOnObjects());
    }
    public void EnableButton()
    {
        StartCoroutine(ButtonDelay(8.5f));
    }
    public void EnableDropDown()
    {
        StartCoroutine(DropDownDelay(8.5f));
    }
    private IEnumerator ExecuteOnObjects()
    {
        foreach (GameObject obj in objectsToExecuteCode)
        {
            if (obj != null)
            {
                Pics script = obj.GetComponent<Pics>();
                if (script != null)
                {
                    script.Load();
                }
            }
            yield return null;
        }
    }
    IEnumerator ButtonDelay(float delay)
    {
        
        Button btn = button.GetComponent<Button>();
        btn.interactable = false;
        yield return new WaitForSeconds(delay);
        btn.interactable = true;
    }
    IEnumerator DropDownDelay(float delay)
    {
        dropdown.interactable = false;
        yield return new WaitForSeconds(delay);
        dropdown.interactable = true;
    }
}
