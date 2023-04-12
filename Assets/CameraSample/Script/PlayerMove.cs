// ---------------------------------------------------------  
// PlayerMove.cs  
//   
// 作成日:  2021/11/22
// 作成者:  MasterM
// ---------------------------------------------------------  
using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour
{

    #region 変数  
    public bool g_moveTranslate = false;
    public float g_speed = 10f;
    public float g_jumpPower = 8f;
    #endregion

    #region プロパティ  

    #endregion

    #region メソッド  
    private void Update() {
        if (g_moveTranslate) {
            transform.Translate(new Vector2(Input.GetAxis("Horizontal") * g_speed, Input.GetAxis("Vertical") * g_speed));
        } else {

            GetComponent<Rigidbody2D>().AddForce(new Vector2(Input.GetAxis("Horizontal") * g_speed, Input.GetAxis("Vertical") * g_speed));

            if (Input.GetButtonDown("Jump")) {
                GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, g_jumpPower);
            }
        }
            
    }
    private void FixedUpdate() {
        
    }
    #endregion
}