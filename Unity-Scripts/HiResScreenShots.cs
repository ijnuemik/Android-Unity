using UnityEngine;
using System.Collections;

public class HiResScreenShots : MonoBehaviour
{
    public int resWidth = 72;
    public int resHeight = 72;

    private bool takeHiResShot = false;

    public static string ScreenShotName(int width, int height)
    {
        Debug.Log("hello" + width + height);
        string title = StartScript.designname;
        return string.Format("{0}/{1}.png", Application.persistentDataPath, title);
    }

    public void TakeHiResShot()
    {
        takeHiResShot = true;
    }

    public void SaveScreenshot()
    {

            RenderTexture rt = new RenderTexture(resWidth, resHeight, 1);
            GetComponent<Camera>().targetTexture = rt;
            Texture2D screenShot = new Texture2D(resWidth, resHeight, TextureFormat.RGBA32, false);
            GetComponent<Camera>().Render();
            RenderTexture.active = rt;
            screenShot.ReadPixels(new Rect(0, 0, resWidth, resHeight), 0, 0);
            GetComponent<Camera>().targetTexture = null;
            RenderTexture.active = null; // JC: added to avoid errors
            Destroy(rt);
            byte[] bytes = screenShot.EncodeToJPG(75);
            string filename = ScreenShotName(resWidth, resHeight);
            System.IO.File.WriteAllBytes(filename, bytes);
            Debug.Log(string.Format("Took screenshot to: {0}", filename));
            takeHiResShot = false;
        
    }
}