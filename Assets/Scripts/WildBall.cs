using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


[RequireComponent(typeof(Rigidbody))]
public class WildBall : MonoBehaviour
{
    [SerializeField] private GameObject _finalPanel;
    [SerializeField] private Button _pauseButton;
    [SerializeField] private ParticleSystem _deathEffect;

    private AnimationController _animationcontroller;
    private Rigidbody _wildBallRigitbody;

    private float _speedWall;

    private void Awake()
    {

        _speedWall = 10;
        _wildBallRigitbody = GetComponent<Rigidbody>();
        _animationcontroller = GetComponent<AnimationController>();
    }


    private void OnTriggerEnter(Collider other)
    {
        BounceBack(other, "Hit");
        Death(other, "Respawn",_animationcontroller.wildBallDeathAnimation);
        Finishit(other, "Finish");
        CollectCoin(other, "Coin");
    }

    private void OnCollisionEnter(Collision collision)
    {
        Death(collision, "Respawn", _animationcontroller.wildBallDeathAnimation);
        ButtonPressed(_animationcontroller.firstDoorAnimation,_animationcontroller.firstButtonAnimation, collision, "ButtonOpeningFirstDoor");
        ButtonPressed(_animationcontroller.secondDoorAnimation, _animationcontroller.secondButtonAnimation, collision, "ButtonOpeningSecondDoor");
        ButtonPressed(_animationcontroller.acceleratorAnimation, _animationcontroller.acceleratorButtonAnimation, collision, "ButtonOpeningAccelerator");
        Accelerate(collision, "Accelerator");
    }

    public void BallMovement(Vector3 movement)
    {
        _wildBallRigitbody.AddForce(movement * _speedWall);
    }

    private void ButtonPressed(Animation door,Animation button, Collision collision, string buttonName)
    {
        if (collision.gameObject.CompareTag(buttonName))
        {
            OpenDoor(door);
            button.Play();
            button.GetComponent<Renderer>().material.color = Color.green;
        }
    }

    private void Death(Collision collision,string objectName,Animation death)
    {
        if (collision.gameObject.CompareTag(objectName))
        {
            _deathEffect.transform.position = transform.position;
            _deathEffect.Play();
            death.Play();
            StartCoroutine(TimerLoadScene());
        }
    }

    private void Death(Collider other, string objectName, Animation death)
    {
        if (other.gameObject.CompareTag(objectName))
        {
            _deathEffect.transform.position = transform.position;
            _deathEffect.Play();
            death.Play();
            StartCoroutine(TimerLoadScene());
        }
    }

    private void Finishit(Collider other,string finishName)
    {
        if (other.CompareTag(finishName) && SceneManager.GetActiveScene().buildIndex <= 2)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        if (other.CompareTag(finishName) && SceneManager.GetActiveScene().buildIndex >= 3)
        {
            gameObject.SetActive(false);
            MenuController. FinalPanel(_finalPanel);
            MenuController.DisableButton(_pauseButton);
        }
    }

    private void BounceBack(Collider other,string objectName)
    {
        if (other.gameObject.CompareTag(objectName))
        {
            _wildBallRigitbody.AddForce((transform.position - other.transform.position).normalized * 30,ForceMode.Impulse);
        }
    }

    private void OpenDoor(Animation door)
    {
        door.Play();
    }

    private void Accelerate(Collision collision,string acceleratorName)
    {
        if (collision.gameObject.CompareTag(acceleratorName))
        {
            _wildBallRigitbody.AddForce((collision.transform.position - transform.position).normalized * 30,ForceMode.Impulse);
        }
    }

    private void CollectCoin(Collider other,string coinName)
    {
        if (other.CompareTag(coinName))
        {
            other.GetComponent<ParticleSystem>().Play();
            other.GetComponent<Animator>().SetTrigger("CoinCollect");
        }
    }

    private IEnumerator TimerLoadScene()
    {
        yield return new WaitForSeconds(1);

        LevelController.ReloadScene();
    }
}

