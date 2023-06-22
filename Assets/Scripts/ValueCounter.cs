using TMPro;
using UnityEngine;


public class ValueCounter : MonoBehaviour
{
    int value;
    TextMeshPro[] textMesh;
    Rigidbody cube;
    [SerializeField] ScoreCounter scoreCounter;
    public Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        cube = GetComponent<Rigidbody>();
        scoreCounter = FindAnyObjectByType<ScoreCounter>();
        textMesh = GetComponentsInChildren<TextMeshPro>();

        if (Random.Range(1, 101) <= 75)
            value = 2;
        else value = 4;

        foreach (TextMeshPro text in textMesh)
            text.text = value.ToString();

    }

    private void OnCollisionEnter(Collision collision)
    {
        AudioManager.instance.Play("BoxPunch");
    }

    void OnTriggerEnter(Collider other)
    {
        ValueCounter otherValueCounter = other.GetComponent<ValueCounter>();
        ValueCounter cubeValueCounter = cube.GetComponent<ValueCounter>();


        if (otherValueCounter != null && cubeValueCounter != null)
        {
           
            if (cubeValueCounter.value == otherValueCounter.value)
            {
                scoreCounter.ScoreValues(cubeValueCounter.value);

                cubeValueCounter.value += otherValueCounter.value;

                animator.SetBool("Punch", true);

                foreach (TextMeshPro text in textMesh)
                    text.text = cubeValueCounter.value.ToString();

                Destroy(other.gameObject);
            }
        }

    }

    public void ExitAnimation()
    {
        animator.SetBool("Punch", false);
    }

}
