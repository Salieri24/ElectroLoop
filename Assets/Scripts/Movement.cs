using UnityEngine;
//using Live2D.Cubism.Core;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    [SerializeField] private LayerMask platformLayerMask;
    //private CubismModel model;
    private Rigidbody2D rigid;
    private CircleCollider2D circleColl;

    public Text targetText;
    public float thrust = 3;
    public float maxSpeed;

    // Start is called before the first frame update
    public void Start()
    {
        Debug.developerConsoleVisible = true;
        //model = GetComponent<CubismModel>();
        rigid = GetComponent<Rigidbody2D>();
        circleColl = GetComponent<CircleCollider2D>();

    }

    // Update is called once per frame
    public void FixedUpdate()
    {

        float f = Input.GetAxis("Horizontal");
        Vector2 v = new Vector2(0,0);

        bool grounded = isGrounded();

        if(grounded && Input.GetKey(KeyCode.Space)) //jump
        {
            rigid.AddForce(new Vector2(0, 5f), ForceMode2D.Impulse);
        }

        if (!grounded)
        {
            v.x = (f * thrust) * 0.25f;
        }
        else
        {
            v.x = f * thrust;
        }
        rigid.AddForce(v);

        if (Mathf.Abs(rigid.velocity.x) >= maxSpeed && rigid.velocity.x * f > 0)   //max speed
            rigid.AddForce(new Vector2(-v.x, 0));

        targetText.text = "Thrust = " + thrust + "\nmaxSpeed = " + maxSpeed + "\nVelocity = "+rigid.velocity+"\n";
        targetText.text += "Applied force:" + v + "\nGrounded: " + grounded;
    }
    private bool isGrounded()
    {

        var grounded = Physics2D.OverlapCircle(circleColl.bounds.center,circleColl.bounds.size.x/2+0.01f,platformLayerMask);
        return grounded != null;
    }
}
