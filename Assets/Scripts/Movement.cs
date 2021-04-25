using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    [SerializeField] private LayerMask platformLayerMask;
    [SerializeField] private LayerMask deathLayerMask;
    private Animator animator;

    private Rigidbody2D rigid;
    private CircleCollider2D circleColl;

    public Text targetText;

    public float thrust = 3;
    public float maxSpeed;

    public float energy=0;
    public float energyCost=1f;
    public float energyGeneration = 0.05f;
    public float maxEnergy;

    public Slider energySlider;

    // Start is called before the first frame update
    public void Start()
    {
        Debug.developerConsoleVisible = true;

        energySlider.maxValue = maxEnergy;
        energySlider.minValue = 0f;

        energyCost *= 10;  //amplify the energy cost

        animator = this.GetComponentInChildren<Animator>();

        rigid = GetComponent<Rigidbody2D>();
        circleColl = GetComponent<CircleCollider2D>();

    }
    public void Update()
    {
        if (energy <= 0)
        {
            energy = 0;
        }
    }
    // Update is called once per frame
    public void FixedUpdate()
    {
        if (isInDeathZone()) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name,LoadSceneMode.Single);
        }

        Vector2 v = new Vector2(0, 0);
        bool grounded = isGrounded();

        float generatedEnergy = energyGeneration * Mathf.Abs(rigid.angularVelocity) / 100;

        movement(v, grounded);

        if (energy < maxEnergy)
        {
            energy +=generatedEnergy;
        }
        else
        {
            energy = maxEnergy;
        }

        energySlider.value = energy;
        animator.SetFloat("Energy", energy);

        targetText.text = "Thrust = " + thrust + "\nmaxSpeed = " + maxSpeed + "\nVelocity = " + rigid.velocity + "\n";
        targetText.text += "Applied force:" + v + "\nGrounded: " + grounded + "\nGeneratedEnergy: "+ generatedEnergy;
    }

    private void movement( Vector2 v, bool grounded)
    {
        float f = Input.GetAxis("Horizontal");

        if (grounded && Input.GetKey(KeyCode.Space)) //jump
        {
            rigid.AddForce(new Vector2(0, 5f), ForceMode2D.Impulse);
            energy -= energyCost * 10;
        }
        if (!grounded)  //move in air
        {
            v.x = (f * thrust) * 0.25f;
        }
        else
        {               //move on ground
            v.x = f * thrust;
        }
        var tempEnergy = energy - (energyCost) * Mathf.Abs(f);
        if (tempEnergy < 0) {
            //signal: no energy!
            energy = 0;
        }
        else { 
        rigid.AddForce(v);
            energy = tempEnergy;
        }
        if (Mathf.Abs(rigid.velocity.x) >= maxSpeed && rigid.velocity.x * f > 0)   //max speed
            rigid.AddForce(new Vector2(-v.x, 0));
    }

    private bool isGrounded()
    {
        var grounded = Physics2D.OverlapCircle(circleColl.bounds.center,circleColl.bounds.size.x/2+0.01f,platformLayerMask);
        return grounded != null;
    }

    private bool isInDeathZone()
    {
        var danger = Physics2D.OverlapCircle(circleColl.bounds.center, circleColl.bounds.size.x / 4, deathLayerMask);
        return danger != null;
    }

    public float getEnergy()
    {
        return this.energy;
    }

}
