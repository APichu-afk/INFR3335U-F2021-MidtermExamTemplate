using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController character;
    private float speed = 2.0f;
    private Vector3 direction = Vector3.zero;
    private int coincounter = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (coincounter == 10)
        {
            SceneManager.LoadScene("End");
        }
        direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        direction = transform.TransformDirection(direction);

        direction *= speed;

        character.Move(direction * Time.fixedDeltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "coin")
        {
            Destroy(collision.gameObject);
            coincounter += 1;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        
    }
}
