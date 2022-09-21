using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Transforms to act as start and end markers for the journey.
    public Transform topLeft;
    public Transform topRight;
    public Transform bottomLeft;
    public Transform bottomRight;
    public GameObject art;
    public Transform[] positions;

    float random;
    [SerializeField] int posRandom;

    private bool moving = true;
    private bool tL = false;
    // Movement speed in units per second.
    public float speed = 1.0F;

    // Time when the movement started.
    public float startTime;
    public float timer;

    // Total distance between the markers.
    private float journeyLength;

    public int counter = 1;
    public int destPoint = 0;
    public Vector3 remainingDistance;

    Rigidbody rb;

    void Start()
    {
        // Keep a note of the time the movement started.
        startTime = Time.time;
        timer = Time.deltaTime;

        rb = this.gameObject.GetComponent<Rigidbody>();

        random = Random.Range(0.0f, 20.0f);
        Debug.Log(random);
        posRandom = Random.Range(0, 4);

        MovePositions(0);
    }

    // Move to the target end position.
    private void Update()
    {
        timer += Time.deltaTime;
        remainingDistance = rb.transform.position - positions[destPoint].position;
    }
    void FixedUpdate()
    {
        MovePositions(destPoint);
    }

    public void MovePosition()
    {
        destPoint = (destPoint + 1) % positions.Length;
    }

    public void MovePositions(int count)
    {

        //rb.MovePosition(Vector3.Lerp(rb.position, positions[count].position, speed / 5000));
        Vector3 newPos = Vector3.MoveTowards(rb.position, positions[count].position, speed * 5000);
        rb.MovePosition(newPos);
        Debug.Log("Moving");
        /*if (timer >= random)
        {
            timer = 0;
            Charge();
            moving = false;
        }*/
    }

    IEnumerator Moving()
    {
        counter++;
        yield return new WaitForSeconds(3f);
        Debug.Log(counter);
    }

    public void Charge()
    {
        Debug.Log("Charge");
        StartCoroutine(Waiting());
    }


    IEnumerator Waiting()
    {
        yield return new WaitForSeconds(3f);
        Jump();
    }

    IEnumerator WaitingJump()
    {
        random = Random.Range(0.0f, 10.0f);
        yield return new WaitForSeconds(3f);
        moving = true;
        timer = 0;
    }

    public void Jump()
    {
        Debug.Log("Jump");
        StartCoroutine(WaitingJump());
        Debug.Log("Yippee Again");
    }
}
