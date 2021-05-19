using UnityEngine;

public class PlayerShootScript : MonoBehaviour
{

    //Допълнете скрипта, по следния начин:
    //С левия бутон на мишката трябва да стреля
    //Трябва да има два режима на стрелба, които се сменят с клавиши 1 и 2 Keycode.Alpha1/Keycode.Alpha2
    //Режим 1 прави "дупка в стената" като просто инстанцира bulletholepfb и го слага в точката на удара (raycast) и му прави ротацията като на уцеления обект
    //Режим 2 инстанцира bulletPfb и го изтрелва от позиция/ротация newBulletPosition чрез rigibody.AddRelativeForce

    [SerializeField]
    private GameObject bulletHolePfb;

    [SerializeField]
    private GameObject bulletPfb;

    [SerializeField]
    private GameObject newBulletPosition;

    bool isInBulletHoleMode;

    public void Start()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            this.isInBulletHoleMode = false;
        }
        else if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            this.isInBulletHoleMode = true;
        }

        if (Input.GetMouseButton(0))
        {
            if (this.isInBulletHoleMode)
            {
                // hit.point
                // rotation = hit.transform.rotation
            }
            else
            {
                
            }
        }
    }

    // Update is called once per frame
    public void Update ()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Time.timeScale = 0.2F;
            Time.fixedDeltaTime = 0.004F;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            Time.timeScale = 1F;
            Time.fixedDeltaTime = 0.02F;
        }
    }
}
