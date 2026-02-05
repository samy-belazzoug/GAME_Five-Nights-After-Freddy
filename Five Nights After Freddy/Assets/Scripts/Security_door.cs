using GLTFast.Schema;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Security_door : MonoBehaviour, IInteractable
{   
    public UnityEngine.Material material;
    public GameObject door;
    public GameObject button;
    
    public float speed = 2f;
    private bool isOpen = false;

    public void Interact()
    {
        if (!isOpen)
        {
            StartCoroutine(OpenDoor());
        }
    }

    IEnumerator OpenDoor()
    {
        button.GetComponent<MeshRenderer>().material = material;
        isOpen = true;
        Vector3 startPos = door.transform.position;
        Vector3 targetPos = startPos + new Vector3(0, 2, 0);

        float elapsed = 0f;
        while (elapsed < 1f)
        {
            elapsed += Time.deltaTime * speed;
            door.transform.position = Vector3.Lerp(startPos, targetPos, elapsed);
            yield return null; // Attend la prochaine frame
        }

        door.transform.position = targetPos;
    }
}