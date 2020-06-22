using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SceneClipse
{
    public partial class FormParseDialog : Form
    {
        public List<string> _vsFixedTagList = new List<string>();
        private List<BookmarkItem> _vBookmarkGenerated = new List<BookmarkItem>();
        public bool bUseTimeModify;
        public bool bUseModifyHead = false;
        public bool bUseModifyTail = false;
        public int nModifySec;
        public string sFileName;
        const string _InitializedTextExample = "입력 형식 : \r\n시간(시:분:초)|태그(, 구분)|제목\r\n\r\n 예 :\r\n13:19:00|태그|제목1\r\n13:28:00|태그1,태그2|제목2\r\n14 Dec 2018 13:08:00||제목3";
        
        internal List<BookmarkItem> VBookmarkGenerated
        {
            get { return _vBookmarkGenerated; }
            set { _vBookmarkGenerated = value; }
        }

        public FormParseDialog()
        {
            InitializeComponent();
        }

        public FormParseDialog(string fileName)
        {
            sFileName = fileName;
            InitializeComponent();
            // 시작시에 파일정보를 통해 자동으로 영상시작시간을 갱신
            buttonGetTimeDataFromFilename_Click(null, null);
        }

        private void numericMin_ValueChanged(object sender, EventArgs e)
        {

            // 60을 넘겼을 경우 시간에 +1 후 초기화
            if ((sender as NumericUpDown).Value == 60)
            {
                numericMin.Value = 0;
                numericHour.Value++;
            }
            if ((sender as NumericUpDown).Value < 0)
            {
                numericMin.Value = 59;
                numericHour.Value--;
            }
        }

        private void numericSec_ValueChanged(object sender, EventArgs e)
        {
            // 60을 넘겼을 경우 분에 +1 후 초기화
            if ((sender as NumericUpDown).Value == 60)
            {
                numericSec.Value = 0;
                numericMin.Value++;
            }
            if ((sender as NumericUpDown).Value < 0)
            {
                numericSec.Value = 59;
                numericMin.Value--;
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            /*
             * 책갈피 시간배열을 만드는 작업
             * */

            // 입력 시각정보로 기반 시각을 작성
            int nTimeOrg = Convert.ToInt32( numericHour.Value * 3600 + numericMin.Value * 60 + numericSec.Value );
            
            bUseTimeModify = checkModifyTime.Checked;
            bUseModifyHead = checkBoxModifyHead.Checked;
            bUseModifyTail = checkBoxModifyTail.Checked;
            nModifySec = Convert.ToInt32(numericModifySec.Value);

            // 내용의 색이 ControlDark일 경우 예제만 표시되어 있는 상태 = 아무것도 입력을 하지 않음
            if (textBoxInputBookmark.ForeColor == SystemColors.ControlDark)
                textBoxInputBookmark.Text = "";

            _vBookmarkGenerated.Clear();

            // 각 라인별 루프
            foreach ( string sLineData in textBoxInputBookmark.Text.Split('\n') )
            {
                if (sLineData.Trim().Length == 0)
                    continue;

                double dTimeStart, dTimeEnd;
                dTimeStart = dTimeEnd = 0;
                int nTimeBookmark = 0;
                string sBookmarkTitle = "";
                List<string> _vsTagList= new List<string>();

                int sectionCount = 0;
                // 라인의 입력정보 : 시간정보|태그(,로 분)|제목
                foreach (string sSectionData in sLineData.Split('|'))
                {
                    sectionCount++;

                    switch(sectionCount)
                    {
                        case 1: // 시간 정보
                            int nHour, nMin, nSec;
                            nHour = nMin = nSec = 0;

                            // 공백으로 쪼갠 뒤 루프
                            foreach (string sRawTime in sSectionData.Split(' '))
                            {
                                if (sRawTime.IndexOf(':') > 1)
                                {
                                    // 시간 정보가 있는 것으로 추측
                                    int nCnt = 1;
                                    bool bValid = true;

                                    // ':'값으로 파싱한 시/분/초별 루프
                                    foreach (string sTimeSplit in sRawTime.Split(':'))
                                    {
                                        if (!bValid) break;

                                        int nTimeSplit = Convert.ToInt32(sTimeSplit);

                                        switch (nCnt)
                                        {
                                            case 1: // 시
                                                if (nTimeSplit > 24 || nTimeSplit < 0)
                                                {
                                                    bValid = false;
                                                }
                                                else
                                                {
                                                    nHour = nTimeSplit;
                                                }
                                                break;

                                            case 2: // 분
                                                if (nTimeSplit > 60 || nTimeSplit < 0)
                                                {
                                                    bValid = false;
                                                }
                                                else
                                                {
                                                    nMin = nTimeSplit;
                                                }
                                                break;

                                            case 3: // 초
                                                if (nTimeSplit > 60 || nTimeSplit < 0)
                                                {
                                                    bValid = false;
                                                }
                                                else
                                                {
                                                    nSec = nTimeSplit;
                                                }
                                                break;
                                            case 4: // 밀리초?
                                                break;
                                            default: // 잘못된 정보일 가능성이 있음
                                                bValid = false;
                                                break;
                                        }
                                        nCnt++;
                                    }

                                    // 문제없이 파싱했을 경우
                                    if (bValid)
                                    {
                                        nTimeBookmark = Convert.ToInt32(nHour * 3600 + nMin * 60 + nSec);

                                        // 영상 시작시각과 책갈피한 시각의 차이값을 저장
                                        nTimeBookmark -= nTimeOrg;

                                        // 차이값이 -일 경우 : 하루가 경과했을 경우로 판단(11:59 -> 00:00)하고, 24시간을 더함
                                        if (nTimeBookmark < 0)
                                        {
                                            nTimeBookmark += 24 * 60 * 60;
                                        }
                                    }
                                }
                            }
                            break;
                        case 2:// 태그 정보
                            foreach (string sTagData in sSectionData.Split(','))
                            {
                                _vsTagList.Add(sTagData.Trim());
                            }
                            break;
                        case 3:// 제목 정보
                            if (sSectionData.Length != 0)
                                sBookmarkTitle = sSectionData;
                            break;
                        default:
                            break;
                    }                    
                }

                // 북마크정보 생성
                dTimeStart = dTimeEnd = nTimeBookmark;

                // 시간 보정 여부 체크후 시간값 보정
                if (bUseTimeModify)
                {
                    if (bUseModifyHead)
                        dTimeStart = nTimeBookmark - nModifySec;
                    if (bUseModifyTail)
                        dTimeEnd = nTimeBookmark + nModifySec;
                }

                // 시간보정 이후 시간이 - 값이 되지 않도록 보정
                if (dTimeStart < 0) dTimeStart = 0;

                BookmarkTimeData time = new BookmarkTimeData(dTimeStart * 1000);
                string sTimeData = time.GetTime();

                // 제목이 없다면 기본값으로 생성
                if (sBookmarkTitle.Trim().Length == 0)
                    sBookmarkTitle = "책갈피 " + sTimeData;

                // 책갈피 목록에 추가     
                BookmarkItem itemNewBookmark = new BookmarkItem(sBookmarkTitle, dTimeStart * 1000);
                itemNewBookmark.BookmarkEnd = new BookmarkTimeData(dTimeEnd * 1000);
                itemNewBookmark.vTags = _vsTagList.ToList();
                itemNewBookmark.vTags.AddRange(_vsFixedTagList.ToList());

                _vBookmarkGenerated.Add(itemNewBookmark);
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void buttonGetTimeDataFromFilename_Click(object sender, EventArgs e)
        {
            /*
             * TODO : 영상의 시간정보를 전송해 줌
             * 2018-12-14 13-00-08_저지아이즈.mp4
             * */
            if (sFileName != "")
            {
                int nHour, nMin, nSec;
                nHour = nMin = nSec = 0;

                foreach (string sTempStr in sFileName.Split(' '))
                {
                    string[] vTempStr = sTempStr.Split('-');
                    if (vTempStr.Count() >= 3)
                    {
                        int nCnt = 1;
                        bool bValid = true;
                        foreach (string sTime in vTempStr)
                        {
                            switch (nCnt)
                            {
                                case 1:
                                    // 시
                                    // 숫자로만 구성되었는지 체크
                                    bValid = sTime.All(Char.IsDigit);
                                    if (bValid)
                                    {
                                        int nTemp = Convert.ToInt32(sTime);
                                        if (nTemp > 24 || nTemp < 0)
                                            bValid = false;
                                        else
                                            nHour = nTemp;
                                    }
                                    break;
                                case 2:
                                    // 분
                                    // 숫자로만 구성되었는지 체크
                                    bValid = sTime.All(Char.IsDigit);
                                    if (bValid)
                                    {
                                        int nTemp = Convert.ToInt32(sTime);
                                        if (nTemp > 60 || nTemp < 0)
                                            bValid = false;
                                        else
                                            nMin = nTemp;
                                    }
                                    break;
                                case 3:
                                    // 초
                                    // 초 형식 : **.mp4 혹은 **_영상이름.mp4 가 될 수 있으므로 뒷부분을 자름
                                    string sTimeMod = sTime.Substring(0, sTime.IndexOf('.'));
                                    if (sTimeMod.IndexOf('_') > 0)
                                        sTimeMod = sTimeMod.Substring(0, sTimeMod.IndexOf('_'));

                                    // 숫자로만 구성되었는지 체크
                                    bValid = sTimeMod.All(Char.IsDigit);
                                    if (bValid)
                                    {
                                        int nTemp = Convert.ToInt32(sTimeMod);
                                        if (nTemp > 60 || nTemp < 0)
                                            bValid = false;
                                        else
                                            nSec = nTemp;
                                    }
                                    break;
                                default:
                                    break;
                            }

                            if (!bValid)
                                break;

                            nCnt++;
                        }

                        if (bValid)
                        {
                            numericHour.Value = nHour;
                            numericMin.Value = nMin;
                            numericSec.Value = nSec;
                        }
                    }
                }
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void checkModifyTime_CheckedChanged(object sender, EventArgs e)
        {
            groupModifyTime.Enabled = checkModifyTime.Checked;
        }

        private void buttonSetFixedTag_Click(object sender, EventArgs e)
        {
            FormEditFixedTag dialog = new FormEditFixedTag();
            if (_vsFixedTagList.Count > 0)
            {
                dialog.SetFixedBookmark(_vsFixedTagList);
            }

            var result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                _vsFixedTagList = dialog._vsFixedTagList.ToList();
            }
        }

        private void textBoxInputBookmark_Enter(object sender, EventArgs e)
        {
            if (textBoxInputBookmark.ForeColor == SystemColors.ControlDark)
            {
                textBoxInputBookmark.Text = "";
                textBoxInputBookmark.ForeColor = SystemColors.WindowText;
            }
        }

        private void textBoxInputBookmark_Leave(object sender, EventArgs e)
        {
            if (textBoxInputBookmark.Text.Length == 0)
            {
                textBoxInputBookmark.Text = _InitializedTextExample;
                textBoxInputBookmark.ForeColor = SystemColors.ControlDark;
            }
        }
    }
}
