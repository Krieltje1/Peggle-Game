using UnityEngine;
public class ShootBall : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private float forceBuild = 20f;
    [SerializeField] private float maximumHoldTime = 5f;
    [SerializeField] private float lineSpeed = 10f;
    
    public PlayerStats playerStats;

    private LineRenderer _line;
    private bool _lineActive = false;
    private float _pressTimer = 0f;
    private float _launchForce = 0f;
    private bool canSpawnBall = true;
    private bool hasShownNoBallsMessage = false;
    void Start()
    {
        _line = GetComponent<LineRenderer>();
        _line.SetPosition(1,Vector3.zero);

        playerStats.ballsUsed = 0;
        hasShownNoBallsMessage = false;
    }
    void Update(){
        if(playerStats.ballsUsed >= playerStats.maxBalls && !hasShownNoBallsMessage)
        {
            canSpawnBall = false;
            Debug.Log("No Orbs Remaining!");
            hasShownNoBallsMessage = true;
        }
        if(canSpawnBall)
        {
            HandleShot();
        }
    }
    private void HandleShot() {
        if (Input.GetMouseButtonDown(0) && playerStats.ballsUsed < playerStats.maxBalls)
        {
            _pressTimer = 0;
            _lineActive = true;

        }
        if (Input.GetMouseButtonUp(0))
        {
            _launchForce = _pressTimer * forceBuild;

            
            GameObject ball = Instantiate(prefab, transform.parent);

            ball.transform.rotation = transform.rotation;

            ball.GetComponent<Rigidbody2D>().AddForce(ball.transform.right * _launchForce, ForceMode2D.Impulse);

            ball.transform.position = transform.position;

            _lineActive = false;
            _line.SetPosition(1, Vector3.zero);

            playerStats.ballsUsed++;
            Debug.Log("Balls Used: " + playerStats.ballsUsed);
        }
        
        if(_pressTimer < maximumHoldTime){

            _pressTimer += Time.deltaTime;
        }

         if (_lineActive) {
        _line.SetPosition(1, Vector3.right * _pressTimer * lineSpeed);
        }
    }
}