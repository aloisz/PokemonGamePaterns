using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class UndoActionScript : MonoBehaviour
{
    public InputManagerPokemon inputManager;
    public int numberOfUndoAction;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inputManager.UndoAction(numberOfUndoAction);
            UiManager.instance.ChangeTextGame();
            UiManager.instance.textGame.text = "Undo " + numberOfUndoAction + " Actions";
        }
    }


    private void OnDrawGizmos()
    {
        Handles.Label(transform.position + Vector3.up, transform.name);
        Handles.DrawWireCube(transform.position, transform.GetComponent<Collider>().bounds.size);
    }
    
}
