using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LocationPanel : MonoBehaviour
{
    [SerializeField] private RawImage _map;
    [SerializeField] private InputField _mapNotes;
    [SerializeField] private Text _caseNumberTitle;

    public void OnEnable()
    {
        _caseNumberTitle.text = "CASE NUMBER" + UIManager.Instance.activeCase.caseID;
    }


    public void ProcessInfo()
    {
        if (string.IsNullOrEmpty(_mapNotes.text) == false)
        {
            UIManager.Instance.activeCase.locationNotes = _mapNotes.text;
        }
    }

}
