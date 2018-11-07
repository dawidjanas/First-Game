
using UnityEngine;

public class ItemPick : Interakcja {

    public Item item; 

    public override void Interact()
    {
        base.Interact();

        PickUp();
    }

    void PickUp()
    {
        Debug.Log("Podniosles " + item.name);

       bool wasPickedUp = Inventory.instance.Add(item);

        if (wasPickedUp)
            Destroy(gameObject);
    }
}
