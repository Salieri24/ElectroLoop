using UnityEngine;
using Live2D.Cubism.Core;
public class Movement : MonoBehaviour
{
    private CubismModel model;
    private Rigidbody2D rigid;
    public float thrust = 1;
    // Start is called before the first frame update
    public void Start()
    {
        model = GetComponent<CubismModel>();
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    public void Update()
    {

        float f = Input.GetAxis("Horizontal");
        Vector2 v = new Vector2(f*thrust ,0);
        rigid.AddForce(v);

        model.Parameters[3].Value = Mathf.Abs(rigid.velocity.x)*2.5f;
        model.Parameters[0].Value = rigid.velocity.x * -1;
        model.Parameters[1].Value = rigid.velocity.y * -1;
    }
}
