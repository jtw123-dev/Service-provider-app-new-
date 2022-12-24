using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClientInfoPanel : MonoBehaviour
{
    [SerializeField] private Text _caseNumberText;
    [SerializeField] private InputField _firstName, _lastName;
    [SerializeField] private GameObject _locationPanel;


    public void ProcessInfo()
    {
        _caseNumberText.text = UIManager.Instance.activeCase.caseID;
    }

    public void CheckName()
    {
        if (string.IsNullOrEmpty(_firstName.text) || string.IsNullOrEmpty(_lastName.text))
        {
            Debug.Log("Empty");
            _locationPanel.SetActive(false);
        }
        else
        {
            UIManager.Instance.activeCase.name = _firstName.text + " " + _lastName.text;
        }
    }
}
