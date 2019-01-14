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
        public List<double> vBookmarkTimes = new List<double>();
        public bool bUseTimeModify;
        public bool bUseModifyHead = false;
        public bool bUseModifyTail = false;
        public int nModifySec;
        public string sFileName;

        public FormParseDialog()
        {
            InitializeComponent();
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

            // 각 라인별 루프
            foreach( string sTempTime in textBoxInputBookmark.Text.Split('\n') )
            {
                int nHour, nMin, nSec;
                nHour = nMin = nSec = 0;

                // 공백으로 쪼갠 뒤 루프
                foreach( string sRawTime in sTempTime.Split(' '))
                {
                    if( sRawTime.IndexOf(':') > 1 )
                    {
                        // 시간 정보가 있는 것으로 추측
                        int nCnt = 1;
                        bool bValid = true;

                        // ':'값으로 파싱한 시/분/초별 루프
                        foreach( string sTimeSplit in sRawTime.Split(':'))
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
                        if( bValid )
                        {
                            int nTimeBookmark = Convert.ToInt32(nHour * 3600 + nMin * 60 + nSec);

                            if (nTimeOrg < nTimeBookmark)
                            {
                                vBookmarkTimes.Add(Convert.ToDouble(nTimeBookmark - nTimeOrg));
                            }
                        }
                    }
                }
            }

            bUseTimeModify = checkModifyTime.Checked;
            bUseModifyHead = checkBoxModifyHead.Checked;
            bUseModifyTail = checkBoxModifyTail.Checked;
            nModifySec = Convert.ToInt32(numericModifySec.Value);

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
    }
}
