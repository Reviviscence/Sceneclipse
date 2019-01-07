using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SceneClipse
{
    static class Program
    {

        /// <summary>
        /// 해당 응용 프로그램의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }

    internal class BookmarkItem
    {
        public BookmarkItem(string s, double d)
        {
            sBookmarkName = s;
            BookmarkStart = new BookmarkTimeData(d);
            BookmarkEnd = new BookmarkTimeData(0);
            vTags = new List<string>();
        }

        // 책갈피 시작 시간(책갈피 생성시 자동 입력됨)
        public BookmarkTimeData BookmarkStart { get; set; }
        // 책갈피 끝 시간
        public BookmarkTimeData BookmarkEnd { get; set; }

        // 책갈피 이름
        public string sBookmarkName;

        // 연결된 파일(파일명 or 해시?)
        public string sFileName;
        public string sFileHash;

        // 썸네일 데이터
        public Image imageThumbnail;
        public string sThumbnailPath;

        // 태그 목록
        public List<string> vTags;

    }

    internal class BookmarkTimeData
    {
        public BookmarkTimeData(double d)
        {
            dTimeBookmark = d;
            UpdateTime(d);
        }

        // double d : 책갈피 시간정보(초, 소숫점 이하 : 밀리초)
        public void UpdateTime(double d)
        {
            // 시간 정보(string 혹은 double값)를 읽어와 datetime으로 변환
            DateTime timeBookmark = new DateTime(0);
            timeBookmark = timeBookmark.AddMilliseconds(d);

            UpdateTime(timeBookmark);
        }

        public void UpdateTime(DateTime timeBookmark)
        {
            Hour = timeBookmark.Hour;
            Min = timeBookmark.Minute;
            Sec = timeBookmark.Second;
            MilliSec = timeBookmark.Millisecond;

            double dTemp = timeBookmark.ToBinary();
            dTimeBookmark = Convert.ToDouble(timeBookmark.ToBinary()) / 10000;

            sTimeBookmark = Hour.ToString("D2") + ":" + Min.ToString("D2") + ":" + Sec.ToString("D2"); 
            // + "." + (MilliSec / 10).ToString("D2");
        }

        public string GetTime() { return sTimeBookmark; }
        public double GetTimeDouble() { return dTimeBookmark; }

        private string sTimeBookmark { get; set; }
        private double dTimeBookmark { get; set; }
        public int Hour;
        public int Min;
        public int Sec;
        public int MilliSec;
    }
}
