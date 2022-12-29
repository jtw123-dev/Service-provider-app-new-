using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SearchPanel : MonoBehaviour
{
    [SerializeField] InputField _caseNumberInput;
    [SerializeField] SelectPanel _selectPanel;

    public void ProcessInfo()
    {
        AWSManager.Instance.GetList(_caseNumberInput.text, () => { _selectPanel.gameObject.SetActive(true); });     
    }
}
