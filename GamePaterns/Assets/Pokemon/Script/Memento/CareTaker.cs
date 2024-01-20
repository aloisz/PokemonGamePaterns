using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CareTaker : MonoBehaviour
{
    [SerializeField] private Originator originator;

    private Memento savedMemento;

    [ContextMenu("Save State")]
    public void HitSave()
    {
        this.savedMemento = originator.Save();
        Debug.Log("SAVE");
    }

    [ContextMenu("Restore State")]
    public void HitUndo()
    {
        originator.Restore(savedMemento);
        InventoryManager.instance.FightWithEntities(0, 0, String.Empty);
        Debug.Log("RESTORE");
    }
}
