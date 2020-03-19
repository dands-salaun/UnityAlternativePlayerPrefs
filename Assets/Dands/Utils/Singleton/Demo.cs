using UnityEngine;
using Dands.Utils.Singleton;
public class Demo : Singleton<Demo>
{
    // (Optional) Prevent non-singleton constructor use.
    protected Demo() { }
 
    // Then add whatever code to the class you need as you normally would.
    public string MyTestString = "Hello world!";

    private void OnEnable() {
        Debug.Log(Demo.I.MyTestString);
    }
}
