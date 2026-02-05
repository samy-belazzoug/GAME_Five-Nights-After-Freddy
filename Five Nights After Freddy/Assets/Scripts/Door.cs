using GLTFast.Schema;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class Doors : MonoBehaviour, IInteractable
{
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
        else
        {
            StartCoroutine(CloseDoor());
        }
    }

    IEnumerator OpenDoor()
    {
        isOpen = true;
        Quaternion startRot = door.transform.rotation;
        Quaternion targetRot = startRot * Quaternion.Euler(0, 90, 0); // Pivote de 90° sur l'axe Y
        Vector3 startPos = door.transform.position;
        Vector3 targetPos = startPos + new Vector3(-0.5f, 0, -1);

        float elapsed = 0f;
        while (elapsed < 1f)
        {
            elapsed += Time.deltaTime * speed;
            door.transform.rotation = Quaternion.Lerp(startRot, targetRot, elapsed);
            door.transform.position = Vector3.Lerp(startPos, targetPos, elapsed);
            yield return null;
        }

        door.transform.rotation = targetRot;
    }

    IEnumerator CloseDoor()
    {
        Quaternion startRot = door.transform.rotation;
        Quaternion targetRot = startRot * Quaternion.Euler(0, -90, 0); // Pivote de 90° sur l'axe Y
        Vector3 startPos = door.transform.position;
        Vector3 targetPos = startPos - new Vector3(0.5f, 0, 1);

        float elapsed = 0f;
        while (elapsed < 1f)
        {
            elapsed += Time.deltaTime * speed;
            door.transform.rotation = Quaternion.Lerp(startRot, targetRot, elapsed);
            door.transform.position = Vector3.Lerp(startPos, targetPos, elapsed);
            yield return null;
        }

        door.transform.rotation = targetRot;
        isOpen = false;
    }
}