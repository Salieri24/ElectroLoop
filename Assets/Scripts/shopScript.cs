using Assets.Scripts.PlayerScripts;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shopScript : MonoBehaviour
{
    PlayerParts p = new PlayerParts();

    private List<Battery> batteries = new List<Battery>();
    private List<Engine> engines = new List<Engine>();
    private List<Dynamo> dynamos = new List<Dynamo>();

    public GameObject Player;

    public GameObject shopUI;

    private bool isInShop = false;
    private bool openUI = false;

    // Start is called before the first frame update
    void Start()
    {
        batteries.AddRange (new List<Battery> { new Battery(), new Battery() });
        engines.AddRange(new List<Engine> { new Engine(), new Engine() });
        dynamos.AddRange(new List<Dynamo> { new Dynamo(), new Dynamo()});
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isInShop)
        {
            openUI = !openUI;
            shopUI.SetActive(openUI);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            isInShop = true;
            Debug.Log("Is in Shop!");
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            isInShop = false;
            Debug.Log("Exited the Shop!");
        }
    }
}
