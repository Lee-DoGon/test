#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace PM_Extension
{
    public static class PolygonalMind_Overlay
    {
        // Menu paths
        private const string RootMenuPath = "Tools/";
        private const string PolygonalMenuPath = RootMenuPath + "Polygonal Mind/";
        private const string PublisherPath = PolygonalMenuPath + "Publisher Page";
        private const string GithubPath = PolygonalMenuPath + "GitHub";
        private const string WebPath = PolygonalMenuPath + "About Polygonal Mind";

        /*
         MenuItem(path, priority)
         - 낮을수록 위에 표시됨
         - priority 차이가 10 이상이면 구분선 생성
        */

        [MenuItem(PublisherPath, priority = 1)]
        private static void OpenPublisherPage()
        {
            Application.OpenURL("https://assetstore.unity.com/publishers/36722");
        }

        [MenuItem(GithubPath, priority = 2)]
        private static void OpenGithub()
        {
            Application.OpenURL("https://github.com/PolygonalMind");
        }

        [MenuItem(WebPath, priority = 13)]
        private static void OpenWebsite()
        {
            Application.OpenURL("https://www.polygonalmind.com/");
        }
    }
}
#endif