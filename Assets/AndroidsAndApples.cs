using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.UI;

public class AndroidsAndApples : MonoBehaviour
{
    private Camera arCamera;
    private PlaceGameBoard placeGameBoard;

    public GameObject androidPrefab;
    public GameObject applePrefab;

    public GameObject tile0;
    public GameObject tile1;
    public GameObject tile2;
    public GameObject tile3;
    public GameObject tile4;
    public GameObject tile5;
    public GameObject tile6;
    public GameObject tile7;
    public GameObject tile8;

    private bool tile0android;
    private bool tile1android;
    private bool tile2android;
    private bool tile3android;
    private bool tile4android;
    private bool tile5android;
    private bool tile6android;
    private bool tile7android;
    private bool tile8android;

    private bool tile0apple;
    private bool tile1apple;
    private bool tile2apple;
    private bool tile3apple;
    private bool tile4apple;
    private bool tile5apple;
    private bool tile6apple;
    private bool tile7apple;
    private bool tile8apple;

    private bool isAndroid;
    private bool isApple;

    private bool gameOver;

    public Text text;

    public Material androidMat;
    public Material appleMat;

    private bool once;

    private int turn;

    // Start is called before the first frame update
    void Start()
    {
        // Here we will grab the camera from the AR Session Origin.
        // This camera acts like any other camera in Unity.
        arCamera = GetComponent<ARSessionOrigin>().camera;
        // We will also need the PlaceGameBoard script to know if
        // the game board exists or not.
        placeGameBoard = GetComponent<PlaceGameBoard>();

        tile0 = GetComponent<GameObject>();
        tile1 = GetComponent<GameObject>();
        tile2 = GetComponent<GameObject>();
        tile3 = GetComponent<GameObject>();
        tile4 = GetComponent<GameObject>();
        tile5 = GetComponent<GameObject>();
        tile6 = GetComponent<GameObject>();
        tile7 = GetComponent<GameObject>();
        tile8 = GetComponent<GameObject>();

        tile0android = false;
        tile1android = false;
        tile2android = false;
        tile3android = false;
        tile4android = false;
        tile5android = false;
        tile6android = false;
        tile7android = false;
        tile8android = false;

        tile0apple = false;
        tile1apple = false;
        tile2apple = false;
        tile3apple = false;
        tile4apple = false;
        tile5apple = false;
        tile6apple = false;
        tile7apple = false;
        tile8apple = false;

        isAndroid = false;
        isApple = true;

        gameOver = false;
        once = false;
        turn = 0;
    }

    // Update is called once per frame
    void Update()
    {
        CheckWin();
        if (!once && Input.touchCount > 0)
        {
            once = true;
        }
        else { 
            if (placeGameBoard.Placed() && Input.touchCount > 0)
            {
                Vector2 touchPosition = Input.GetTouch(0).position;
                // Convert the 2d screen point into a ray.
                Ray ray = arCamera.ScreenPointToRay(touchPosition);
                // Check if this hits an object within 100m of the user.
                RaycastHit hit;
            
                if (Physics.Raycast(ray, out hit, 100))
                {
                        // Check that the object is interactable.
                        if (hit.transform.tag == "Interactable")
                    {
                        turn += 1;
                        switch (hit.transform.name)
                        {
                            case "Tile0":
                                if (turn%2 == 0)
                                {
                                    Debug.Log("tile 0 android");
                                    tile0android = true;
                                    InstantiatePrefab(androidPrefab, GameObject.Find("Tile0").transform);
                                    GameObject.Find("Tile0").GetComponent<MeshRenderer>().material = androidMat;
                                }
                                else
                                {
                                    Debug.Log("tile 0 apple");
                                    tile0apple = true;
                                    GameObject.Find("Tile0").GetComponent<MeshRenderer>().material = appleMat;
                                    InstantiatePrefab(applePrefab, GameObject.Find("Tile0").transform);
                                }
                                break;
                            case "Tile1":
                                if (turn % 2 == 0)
                                {
                                    Debug.Log("tile 1 android");
                                    tile1android = true;
                                    GameObject.Find("Tile1").GetComponent<MeshRenderer>().material = androidMat;
                                    InstantiatePrefab(androidPrefab, GameObject.Find("Tile1").transform);
                                }
                                else
                                {
                                    Debug.Log("tile 1 apple");
                                    tile1apple = true;
                                    GameObject.Find("Tile1").GetComponent<MeshRenderer>().material = appleMat;
                                    InstantiatePrefab(applePrefab, GameObject.Find("Tile1").transform);
                                }
                                break;
                            case "Tile2":
                                if (turn % 2 == 0)
                                {
                                    Debug.Log("tile 2 android");
                                    tile2android = true;
                                    GameObject.Find("Tile2").GetComponent<MeshRenderer>().material = androidMat;
                                    InstantiatePrefab(androidPrefab, GameObject.Find("Tile2").transform);
                                }
                                else
                                {
                                    Debug.Log("tile 2 apple");
                                    tile2apple = true;
                                    GameObject.Find("Tile2").GetComponent<MeshRenderer>().material = appleMat;
                                    InstantiatePrefab(applePrefab, GameObject.Find("Tile2").transform);
                                }
                                break;
                            case "Tile3":
                                if (turn % 2 == 0)
                                {
                                    tile3android = true;
                                    GameObject.Find("Tile3").GetComponent<MeshRenderer>().material = androidMat;
                                    InstantiatePrefab(androidPrefab, GameObject.Find("Tile3").transform);
                                }
                                else
                                {
                                    tile3apple = true;
                                    GameObject.Find("Tile3").GetComponent<MeshRenderer>().material = appleMat;
                                    InstantiatePrefab(applePrefab, GameObject.Find("Tile3").transform);
                                }
                                break;
                            case "Tile4":
                                if (turn == 0)
                                {
                                    break;
                                }
                                if (turn % 2 == 0)
                                {
                                    tile4android = true;
                                    GameObject.Find("Tile4").GetComponent<MeshRenderer>().material = androidMat;
                                    InstantiatePrefab(androidPrefab, GameObject.Find("Tile4").transform);
                                }
                                else
                                {
                                    tile4apple = true;
                                    GameObject.Find("Tile4").GetComponent<MeshRenderer>().material = appleMat;
                                    InstantiatePrefab(applePrefab, GameObject.Find("Tile4").transform);
                                }
                                break;
                            case "Tile5":
                                if (turn % 2 == 0)
                                {
                                    tile5android = true;
                                    GameObject.Find("Tile5").GetComponent<MeshRenderer>().material = androidMat;
                                    InstantiatePrefab(androidPrefab, GameObject.Find("Tile5").transform);
                                }
                                else
                                {
                                    tile5apple = true;
                                    GameObject.Find("Tile5").GetComponent<MeshRenderer>().material = appleMat;
                                    InstantiatePrefab(applePrefab, GameObject.Find("Tile5").transform);
                                }
                                break;
                            case "Tile6":
                                if (turn % 2 == 0)
                                {
                                    tile6android = true;
                                    GameObject.Find("Tile6").GetComponent<MeshRenderer>().material = androidMat;
                                    InstantiatePrefab(androidPrefab, GameObject.Find("Tile6").transform);
                                }
                                else
                                {
                                    tile6apple = true;
                                    GameObject.Find("Tile6").GetComponent<MeshRenderer>().material = appleMat;
                                    InstantiatePrefab(applePrefab, GameObject.Find("Tile6").transform);
                                }
                                break;
                            case "Tile7":
                                if (turn % 2 == 0)
                                {
                                    tile7android = true;
                                    GameObject.Find("Tile7").GetComponent<MeshRenderer>().material = androidMat;
                                    InstantiatePrefab(androidPrefab, GameObject.Find("Tile7").transform);
                                }
                                else
                                {
                                    tile7apple = true;
                                    GameObject.Find("Tile7").GetComponent<MeshRenderer>().material = appleMat;
                                    InstantiatePrefab(applePrefab, GameObject.Find("Tile7").transform);
                                }
                                break;
                            case "Tile8":
                                if (turn % 2 == 0)
                                {
                                    tile8android = true;
                                    GameObject.Find("Tile8").GetComponent<MeshRenderer>().material = androidMat;
                                    InstantiatePrefab(androidPrefab, GameObject.Find("Tile8").transform);
                                }
                                else
                                {
                                    tile8apple = true;
                                    GameObject.Find("Tile8").GetComponent<MeshRenderer>().material = appleMat;
                                    InstantiatePrefab(applePrefab, GameObject.Find("Tile8").transform);
                                }
                                break;
                            default:
                                break;
                        }
                    }
                }
        }
    }
    }

    void InstantiatePrefab(GameObject prefab, Transform transform)
    {
        Instantiate(prefab, transform.position, Quaternion.identity);
    }

    void CheckWin()
    {
        if ((tile0android && tile1android && tile2android) ||
            (tile0android && tile3android && tile6android) ||
            (tile6android && tile7android && tile8android) ||
            (tile1android && tile4android && tile7android) ||
            (tile2android && tile5android && tile8android) ||
            (tile3android && tile4android && tile5android) ||
            (tile0android && tile4android && tile8android) ||
            (tile6android && tile4android && tile2android))
        {
            // Android won
            gameOver = true;
            text.gameObject.SetActive(true);
            text.text = "Android Won";
        } else if ((tile0apple && tile1apple && tile2apple) ||
            (tile0apple && tile3apple && tile6apple) ||
            (tile6apple && tile7apple && tile8apple) ||
            (tile1apple && tile4apple && tile7apple) ||
            (tile2apple && tile5apple && tile8apple) ||
            (tile3apple && tile4apple && tile5apple) ||
            (tile0apple && tile4apple && tile8apple) ||
            (tile6apple && tile4apple && tile2apple))
        {
            // Apple won
            gameOver = true;
            text.gameObject.SetActive(true);
            text.text = "Apple Won";
        } 
    }
}
