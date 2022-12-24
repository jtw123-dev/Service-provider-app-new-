using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TakePhotoPanel : MonoBehaviour
{
    [SerializeField] RawImage _photoTaken;
    [SerializeField] InputField _notesInput;
    [SerializeField] Text _caseNumberText;
    [SerializeField] GameObject _panel;

    public void TakePictureButton()
    {
        TakePicture(512);
    }

    public void ProcessInfo()
    {
        _caseNumberText.text = "CASE NUMBER" + UIManager.Instance.activeCase.caseID;
        UIManager.Instance.activeCase.photoTaken = _photoTaken.texture;
        UIManager.Instance.activeCase.photoNotes = _notesInput.text;
    }

    private void TakePicture(int maxSize)
    {
        NativeCamera.Permission permission = NativeCamera.TakePicture((path) =>
        {
            Debug.Log("Image path: " + path);
            if (path != null)
            {
                // Create a Texture2D from the captured image
                Texture2D texture = NativeCamera.LoadImageAtPath(path, maxSize);
                if (texture == null)
                {
                    Debug.Log("Couldn't load texture from " + path);
                    return;
                }
                _photoTaken.texture = texture;
                _photoTaken.gameObject.SetActive(true);

            }
        }, maxSize);

        Debug.Log("Permission result: " + permission);
    }



    public void CheckName()
    {

    }
}
