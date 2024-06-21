using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;
    private int _availablePositions = 1;

    private Vector2[] MovePositions = new Vector2[40];
    private Camera MainCam;
    private Rigidbody2D RB;

    // Start is called before the first frame update
    void Start()
    {
        MainCam = Camera.main;
        RB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Fire1"))
        {
            Vector2 WorldPos = MainCam.ScreenToWorldPoint(Input.mousePosition);
            MovePositions[_availablePositions] = WorldPos;
            _availablePositions++;
            Debug.Log(WorldPos);
        }
        if (Vector2.Distance(transform.position, MovePositions[0]) >= 0.3f && MovePositions[0] != Vector2.zero)
        {
            transform.position = Vector2.MoveTowards(transform.position, MovePositions[0], _speed);
        }
        else if (Vector2.Distance(transform.position, MovePositions[0]) <= 0.3f && MovePositions[1] != Vector2.zero || MovePositions[0] == Vector2.zero && _availablePositions >= 1)
        {
            for (int i = 0; i < MovePositions.Length - 1; i++)
            {
                MovePositions[i] = MovePositions[i + 1];
            }
            _availablePositions--;
        }
    }
}
