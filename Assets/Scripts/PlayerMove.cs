using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private GameController gameController;
    public float SPEED = 0.02f;
    private Direction direction = Direction.None;
    private Animator animator;
    private Vector3 move;
    public bool isRespawning;

    private void setDirection(Direction dir)
    {
        if (dir != direction)
        {
            direction = dir;
            animator.SetInteger("WalkingDirection", (int)direction);
        }

    }

    private enum Direction { None = 0, Bottom = 1, Top = 2, Left = 3, Right = 4};

    private void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        animator = transform.GetComponentInChildren<Animator>();
        move = new Vector3(0, 0, 0);
    }

    public void Die()
    {
        animator.SetBool("isDead", true);
        animator.SetInteger("WalkingDirection", -1);
        gameController.GameOver = true;
    }

    public System.Collections.IEnumerator Respawn(int secs)
    {
        isRespawning = true;
        yield return new WaitForSeconds(secs);
        animator.SetBool("isDead", false);
        animator.SetInteger("WalkingDirection", (int)Direction.None);
        transform.localPosition = new Vector2(0.13f, 0);
        isRespawning = false;
        gameController.GameOver = false;
    }

    void FixedUpdate()
    {

        if (!gameController.GameOver)
        {

            if (Input.GetKey(KeyCode.LeftArrow)) {
                // Walking left
                setDirection(Direction.Left);
                move = new Vector3(-0.5f, 0, 0);
                transform.GetComponentInChildren<SpriteRenderer>().flipX = true;
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                // Walking right
                setDirection(Direction.Right);
                move = new Vector3(0.5f, 0, 0);
                transform.GetComponentInChildren<SpriteRenderer>().flipX = false;
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                // Walking down
                setDirection(Direction.Bottom);
                move = new Vector3(0, -0.5f, 0);
            }
            else if (Input.GetKey(KeyCode.UpArrow))
            {
                // Walking down
                setDirection(Direction.Top);
                move = new Vector3(0, 0.5f, 0);
            }
            else
            {
                move = new Vector3(0, 0, 0);
                setDirection(Direction.None);   
            }


            transform.position += move * SPEED;
        } else
        {
            Die();
        }

    }
}