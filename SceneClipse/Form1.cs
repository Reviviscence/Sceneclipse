using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.IO;
using System.Xml;

namespace SceneClipse
{
    public partial class Form1 : Form
    {
        // 책갈피 목록<인덱스, 책갈피>
        private SortedList<int, BookmarkItem> _listBookmarks;
        // 책갈피 개수(책갈피를 추가시킬때 이 값을 인덱스로 이용)
        private int _nBookmarkCount = 0;
        // 현재 선택된 책갈피 인덱스
        private int _nCurrentBookmarkIdx = 0;
        // 현재 열려있는 파일 이름(혹은 해시값?)
        private string _sFilenamePlaying = "";        
        private string _sFilehashPlaying = "";           // 현재 미사용
        private bool _isUpdatingBookmarkInfo = false;

        public Form1()
        {
            InitializeComponent();
            InitializeBookmarkList();

            _listBookmarks = new SortedList<int, BookmarkItem>();
        }

        private void buttonPlay_Click(object sender, EventArgs e)
        {
            // 디버그용 임시 파일 설정(TODO : 이후에 제거)
            if (_sFilenamePlaying == "")
            {
                InitializeBookmarkdata();
                _sFilenamePlaying = @"c:\Wildlife.wmv";
                // _sFilehashPlaying = GetMD5HashFromFile(_sFilenamePlaying);

                axMediaPlayer1.URL = _sFilenamePlaying;
            }

            axMediaPlayer1.Ctlcontrols.play();
            
            timerPlayTime.Start();
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            axMediaPlayer1.Ctlcontrols.stop();
        }
                
        private void timerCurrentTime_Tick(object sender, EventArgs e)
        {
            string sCurrentTime = DateTime.Now.ToString("tt HH:mm:ss");
            labelTimeDisplay.Text = sCurrentTime;
        }

        // pause 버튼 클릭시 - 재생중이면 정지, 정지상태면 다시 재생
        private void buttonPause_Click(object sender, EventArgs e)
        {
            if( axMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsPaused )
               axMediaPlayer1.Ctlcontrols.play();
            else if( axMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsPlaying )
               axMediaPlayer1.Ctlcontrols.pause();
        }

        // 파일 열기. 다이얼로그 표시 후 파일 선택하여 재생
        private void buttonOpenFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFiledialog1 = new OpenFileDialog();
            // openFiledialog1.Filter = "Movie files|*.wmv";

            if( openFiledialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK )
            {
                InitializeBookmarkdata();

                _sFilenamePlaying = openFiledialog1.FileName;
                // _sFilehashPlaying = GetMD5HashFromFile(_sFilenamePlaying);

                axMediaPlayer1.URL = openFiledialog1.FileName;
                textBoxOpenFileName.Text = openFiledialog1.FileName;
                timerPlayTime.Start();

                // labelOpenFileName.Text = "재생중인 파일 : " + openFiledialog1.FileName;
            }            
        }

        private void timerPlayTime_Tick(object sender, EventArgs e)
        {
            if (axMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsPlaying ||
                axMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsPaused)
            {
                string sVideoTime = axMediaPlayer1.Ctlcontrols.currentPositionString;
                labelPlayTime.Text = "재생 중 : \n" + sVideoTime;
            }
            else
            {
                labelPlayTime.Text = "";
                timerPlayTime.Stop();
            }
        }

        private void buttonBookmark_Click(object sender, EventArgs e)
        {

            if (_sFilenamePlaying != "")
            {
                // 책갈피 리스트에서 현재 추가할 정보의 인덱스
                int nCurrentBookmarkIndex = ++_nBookmarkCount;

                string sVideoTime = axMediaPlayer1.Ctlcontrols.currentPositionString;
                double dVideoTime = axMediaPlayer1.Ctlcontrols.currentPosition;

                // 시간이 0시간일 경우 문구 앞에 00을 추가함
                if (sVideoTime.Split(':').Length < 3) sVideoTime = "00:" + sVideoTime;

                BookmarkItem itemNewBookmark = new BookmarkItem("책갈피 " + sVideoTime, dVideoTime);

                // mediaplayer에서 이미지 가져오기
                Bitmap bitmap = new Bitmap(axMediaPlayer1.Width, axMediaPlayer1.Height - 76);
                {
                    using (Graphics g = Graphics.FromImage(bitmap))
                    {
                        g.CopyFromScreen(axMediaPlayer1.PointToScreen(new System.Drawing.Point()).X,
                            axMediaPlayer1.PointToScreen(new System.Drawing.Point()).Y,
                            0, 0,
                            new System.Drawing.Size(
                                axMediaPlayer1.Width, axMediaPlayer1.Height - 76));

                    }
                    // 이미지 표시(디버그용)                
                    // bitmap.Save("e:\\test.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);

                    // if (pictureBox1.Image != null) pictureBox1.Image.Dispose();
                    // pictureBox1.Image = bitmap.Clone(new Rectangle(0, 0, bitmap.Width, bitmap.Height), System.Drawing.Imaging.PixelFormat.DontCare);

                    imageList1.Images.Add(bitmap);
                }
                itemNewBookmark.imageThumbnail = bitmap;

                // 책갈피 목록에 추가            
                _listBookmarks.Add(nCurrentBookmarkIndex, itemNewBookmark);


                // 리스트에 등록
                ListViewItem item = new ListViewItem(sVideoTime);
                item.SubItems.Add(dVideoTime.ToString());
                item.SubItems.Add(itemNewBookmark.sBookmarkName);
                item.SubItems.Add(nCurrentBookmarkIndex.ToString());

                item.ImageIndex = imageList1.Images.Count;

                listViewBookmark.Items.Add(item);

                // 책갈피 편집부분에도 표시
                UpdateBookmarkInputData(nCurrentBookmarkIndex);

                //listBookmark.DisplayMember = "sVideoTime";
                //listBookmark.Items.Add(item);          
            }
        }

        private void listViewBookmark_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        // 책갈피 목록에서 항목 선택시
        // 해당 항목 위치로 점프하고, 상세설명에 내용 입력
        private void listViewBookmark_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if ((sender as ListView).SelectedItems.Count > 0)
            {
                UpdateBookmarkInputData(Convert.ToInt32((sender as ListView).SelectedItems[0].SubItems[3].Text));
                
            }
        }

        // private void UpdateBookmarkInputData(int nIdx)
        // 책갈피 정보를 입력칸에 갱신함
        // nIdx = 해당 책갈피의 인덱스 값
        private void UpdateBookmarkInputData(int nIdx)
        {
            _isUpdatingBookmarkInfo = true;

            _nCurrentBookmarkIdx = nIdx;

            BookmarkItem bookmarkSelected = _listBookmarks[_nCurrentBookmarkIdx];

            axMediaPlayer1.Ctlcontrols.currentPosition = bookmarkSelected.BookmarkStart.dTimeBookmark;

            //pictureBox1.Image = imageList1.Images[(sender as ListView).SelectedItems[0].Index];
            // 이미지를 썸네일 크기로 변환해서 표시(TODO : 썸네일 크기 상수화)
            if (bookmarkSelected.imageThumbnail != null)
                pictureBox1.Image = bookmarkSelected.imageThumbnail.GetThumbnailImage(64, 64, null, new IntPtr());

            textBoxBookmarkName.Text = bookmarkSelected.sBookmarkName;

            numericBookmarkStartHour.Value = bookmarkSelected.BookmarkStart.Hour;
            numericBookmarkStartMin.Value = bookmarkSelected.BookmarkStart.Min;
            numericBookmarkStartSec.Value = bookmarkSelected.BookmarkStart.Sec;

            numericBookmarkEndHour.Value = bookmarkSelected.BookmarkEnd.Hour;
            numericBookmarkEndMin.Value = bookmarkSelected.BookmarkEnd.Min;
            numericBookmarkEndSec.Value = bookmarkSelected.BookmarkEnd.Sec;

            // 태그 추가
            ClearTagList();
            foreach (string sTagInList in bookmarkSelected.vTags)
            {
                AddIntoTagList(sTagInList);
            }

            textBoxTagInput.Text = ""; // 텍스트 입력칸에 내용이 있으면 제거

            _isUpdatingBookmarkInfo = false;
        }

        // 태그 입력칸에 쉼표(,) 를 입력하면 태그 입력을 종료하고, 그 태그를 왼쪽에 등록
        private void textBoxTagInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (_nCurrentBookmarkIdx > 0)
            {
                // 쉼표 혹은 엔터일 경우
                if (e.KeyChar.Equals(',') || e.KeyChar.Equals(Keys.Enter))
                {
                    // 태그 목록에 추가
                    _listBookmarks[_nCurrentBookmarkIdx].vTags.Add(textBoxTagInput.Text);

                    // 태그 표시항목에 추가
                    AddIntoTagList(textBoxTagInput.Text);

                    // 입력이 끝나면 텍스트박스 내용 초기화
                    textBoxTagInput.Text = "";

                    // 쉼표 입력 처리하지 않게 리턴처리
                    e.KeyChar = '\n';
                    return;
                }
            }
        }

        // private void AddIntoTagList(string sTag)
        // 태그목록에 태그 추가
        // string sTag : 추가할 태그명
        // 라벨을 생성해 태그리스트 끝에 붙이고, 입력칸을 오른쪽으로 한칸 밀어냄
        private void AddIntoTagList(string sTag)
        {
            // 입력 칸이 들어있는 컨트롤 가져오기
            Control cellInput = panelTagList.GetControlFromPosition(panelTagList.ColumnCount - 1, 0);

            // 컬럼정보 입력용 임시 스타일 획득
            ColumnStyle columnTemp = panelTagList.ColumnStyles[panelTagList.ColumnCount - 1];

            // 컬럼 수 추가
            panelTagList.ColumnCount++;
            panelTagList.ColumnStyles.Add(new ColumnStyle(columnTemp.SizeType, columnTemp.Width));

            // 입력 텍스트박스를 마지막 컬럼으로 이동
            Control cellNewInput = panelTagList.GetControlFromPosition(panelTagList.ColumnCount - 1, 0);
            panelTagList.SetColumn(cellInput, panelTagList.ColumnCount - 1);

            // 컬럼에 입력한 값 집어넣기
            Label labelNewTag = new Label() { Text = sTag };

            // 라벨 클릭이벤트 추가
            // 우클릭시 : 해당 태그 삭제
            // 더블클릭시 : 태그 수정
            labelNewTag.MouseClick += (s, e) =>
            {
                if (e.Button == MouseButtons.Right)
                    RemoveFromTagList((s as Label).Text);
            };
            labelNewTag.MouseDoubleClick += (s, e) =>
            {
                if (e.Button == MouseButtons.Left)
                {
                    // 태그 수정 : 기존 태그 입력값을 입력칸에 넣어준 뒤, 기존 태그를 삭제해버림
                    textBoxTagInput.Text = (s as Label).Text;
                    RemoveFromTagList((s as Label).Text);
                }
            };

            // 여백 설정
            labelNewTag.Margin = new Padding(3, 7, 3, 0);

            panelTagList.Controls.Add(labelNewTag, panelTagList.ColumnCount - 2, 0);
            
            // 컬럼 크기를 태그 내용 크기에 맞게 조절
            ColumnStyle columnTemp2 = panelTagList.ColumnStyles[panelTagList.ColumnCount - 2];
            columnTemp2.Width = TextRenderer.MeasureText(labelNewTag.Text, labelNewTag.Font).Width + 15;

            ColumnStyle columnTemp3 = panelTagList.ColumnStyles[panelTagList.ColumnCount - 2];

        }


        // private void RemoveFromTagList(string sTag)
        // 태그목록에서 태그 삭제
        // string sTag : 삭제할 태그명. 없으면 삭제하지 않음
        // 특정 라벨과 그 칸을 삭제
        private void RemoveFromTagList(string sTag)
        {
            // 컨트롤을 순회하면서 해당 태그를 검색
            bool bTagDeleted = false;
            for( int i = 2; i < panelTagList.Controls.Count; i++)
            {
                if (panelTagList.Controls[i].Text == sTag)
                {
                    panelTagList.Controls.RemoveAt(i);                     
                    _listBookmarks[_nCurrentBookmarkIdx].vTags.Remove(sTag);
                    bTagDeleted = true;
                }
            }
            if( bTagDeleted )
            {
                ClearTagList();

                foreach (string sTagFromList in _listBookmarks[_nCurrentBookmarkIdx].vTags)
                {
                    AddIntoTagList(sTagFromList);
                }
            }
        }

        private void ClearTagList()
        {
            // 입력 칸이 들어있는 컨트롤 가져오기
            Control cellInput = panelTagList.GetControlFromPosition(panelTagList.ColumnCount - 1, 0);
            ColumnStyle columnInput = panelTagList.ColumnStyles[panelTagList.ColumnCount - 1];

            panelTagList.Controls.Clear();
            panelTagList.ColumnStyles.Clear();
            panelTagList.ColumnCount = 0;

            // 컬럼 수 추가
            panelTagList.ColumnCount++;

            // 컬럼에 입력한 값 집어넣기
            Label labelNewTag = new Label() { Text = "태그 :" };

            // 여백 설정
            labelNewTag.Margin = new Padding(3, 7, 3, 0);

            panelTagList.Controls.Add(labelNewTag, panelTagList.ColumnCount - 2, 0);

            ColumnStyle styleNew = new ColumnStyle(columnInput.SizeType, columnInput.Width);
            // 컬럼 크기를 태그 내용 크기에 맞게 조절
            styleNew.Width = TextRenderer.MeasureText(labelNewTag.Text, labelNewTag.Font).Width + 15;
            panelTagList.ColumnStyles.Add(styleNew);

            // 입력칸 컬럼 추가
            panelTagList.ColumnCount++;
            // 입력 텍스트박스를 마지막 컬럼으로 이동
            panelTagList.Controls.Add(textBoxTagInput, panelTagList.ColumnCount - 1, 0);
            panelTagList.ColumnStyles.Add(columnInput);

        }

        private string GetMD5HashFromFile(string sFilePath)
        {
            // TODO : ReadAllBytes 가 2GB 이상을 가져오지 못해서 큰 파일에서 에러가 남.
            // 해시 획득시 모든 파일데이터를 긁어올 필요는 없으므로 파일의 일정 부분만 잘라서 가져오면 좋을 듯.
            // 참조 : TransformBlock, TransformFinalBlock 이용
            byte[] hash = MD5.Create().ComputeHash(File.ReadAllBytes(sFilePath));
            return BitConverter.ToString(hash).Replace("-", "");
        }

        // InitializeBookmarkList()
        // 책갈피 목록 리스트뷰 초기화
        private void InitializeBookmarkList()
        {
            listViewBookmark.Columns.Add("시간", 70);
            listViewBookmark.Columns.Add("dblTime", 0);
            listViewBookmark.Columns.Add("이름", 190);
            listViewBookmark.Columns.Add("Index", 0);
            listViewBookmark.LargeImageList = imageList1;
        }

        // InitializeBookmarkData() 
        // 영상을 열었을 때 현재 등록된 책갈피 정보를 초기화
        // 저장된 책갈피 정보가 있다면 불러와서 자동 등록 <- TODO
        private void InitializeBookmarkdata()
        {
            _isUpdatingBookmarkInfo = true;
            listViewBookmark.Clear();
            InitializeBookmarkList();
            _listBookmarks.Clear();
            _nBookmarkCount = 0;
            _nCurrentBookmarkIdx = 0;
            _isUpdatingBookmarkInfo = false;
        }

        // UpdateBookmarkDataFromInput()
        // 책갈피 정보가 수정되었을 때 호출됨
        // 입력된 값을 참고해서 책갈피 정보를 갱신
        private void UpdateBookmarkDataFromInput()
        {
            if (_sFilenamePlaying != "" && _nCurrentBookmarkIdx != 0 && _isUpdatingBookmarkInfo == false)
            {
                BookmarkItem itemCurrent = _listBookmarks[_nCurrentBookmarkIdx];

                itemCurrent.sBookmarkName = textBoxBookmarkName.Text;

                // 시작시간 업데이트
                DateTime timeBookmarkBegin = new DateTime(0);
                timeBookmarkBegin = timeBookmarkBegin.AddHours(Convert.ToDouble(numericBookmarkStartHour.Value));
                timeBookmarkBegin = timeBookmarkBegin.AddMinutes(Convert.ToDouble(numericBookmarkStartMin.Value));
                timeBookmarkBegin = timeBookmarkBegin.AddSeconds(Convert.ToDouble(numericBookmarkStartSec.Value));
                // timeBookmarkBegin = timeBookmarkBegin.AddMilliseconds(Convert.ToDouble(numericBookmarkStartHour));
                itemCurrent.BookmarkStart.UpdateTime(timeBookmarkBegin);

                // 끝나는 시간 업데이트
                DateTime timeBookmarkEnd = new DateTime(0);
                timeBookmarkEnd = timeBookmarkEnd.AddHours(Convert.ToDouble(numericBookmarkEndHour.Value));
                timeBookmarkEnd = timeBookmarkEnd.AddMinutes(Convert.ToDouble(numericBookmarkEndMin.Value));
                timeBookmarkEnd = timeBookmarkEnd.AddSeconds(Convert.ToDouble(numericBookmarkEndSec.Value));
                // timeBookmarkEnd = timeBookmarkEnd.AddMilliseconds(Convert.ToDouble(numericBookmarkEndHour));
                itemCurrent.BookmarkEnd.UpdateTime(timeBookmarkEnd);

                // 항목 목록에서도 내용 수정
                foreach (ListViewItem item in listViewBookmark.Items)
                {
                    if (item.SubItems[3].Text == _nCurrentBookmarkIdx.ToString())
                    {
                        item.SubItems[0].Text = itemCurrent.BookmarkStart.sTimeBookmark;
                        item.SubItems[2].Text = itemCurrent.sBookmarkName;
                    }
                }

                // TODO : 태그 정보도 업데이트
            }
        }
        
        private void numericBookmarkStartHour_MouseClick(object sender, MouseEventArgs e)
        {
            UpdateBookmarkDataFromInput();
        }

        private void numericBookmarkStartMin_MouseClick(object sender, MouseEventArgs e)
        {
            UpdateBookmarkDataFromInput();
        }

        private void numericBookmarkStartSec_MouseClick(object sender, MouseEventArgs e)
        {
            UpdateBookmarkDataFromInput();
        }

        private void numericBookmarkEndHour_MouseClick(object sender, MouseEventArgs e)
        {
            UpdateBookmarkDataFromInput();
        }

        private void numericBookmarkEndMin_MouseClick(object sender, MouseEventArgs e)
        {
            UpdateBookmarkDataFromInput();
        }

        private void numericBookmarkEndSec_MouseClick(object sender, MouseEventArgs e)
        {
            UpdateBookmarkDataFromInput();
        }

        private void textBoxBookmarkName_TextChanged(object sender, EventArgs e)
        {
            UpdateBookmarkDataFromInput();
        }

        private void numericBookmarkStartHour_ValueChanged(object sender, EventArgs e)
        {
            UpdateBookmarkDataFromInput();
        }

        private void numericBookmarkStartMin_ValueChanged(object sender, EventArgs e)
        {
            // 60을 넘겼을 경우 시간에 +1 후 초기화
            if((sender as NumericUpDown).Value == 60)
            {
                _isUpdatingBookmarkInfo = true;
                numericBookmarkStartMin.Value = 0;
                numericBookmarkStartHour.Value++;
                _isUpdatingBookmarkInfo = false;
            }
            if ((sender as NumericUpDown).Value < 0)
            {
                _isUpdatingBookmarkInfo = true;
                numericBookmarkStartMin.Value = 59;
                numericBookmarkStartHour.Value--;
                _isUpdatingBookmarkInfo = false;
            }

            UpdateBookmarkDataFromInput();
        }

        private void numericBookmarkStartSec_ValueChanged(object sender, EventArgs e)
        {
            // 60을 넘겼을 경우 시간에 +1 후 초기화
            if ((sender as NumericUpDown).Value == 60)
            {
                _isUpdatingBookmarkInfo = true;
                numericBookmarkStartSec.Value = 0;
                numericBookmarkStartMin.Value++;
                _isUpdatingBookmarkInfo = false;
            }
            if ((sender as NumericUpDown).Value < 0)
            {
                _isUpdatingBookmarkInfo = true;
                numericBookmarkStartSec.Value = 59;
                numericBookmarkStartMin.Value--;
                _isUpdatingBookmarkInfo = false;
            }
            UpdateBookmarkDataFromInput();
        }

        private void numericBookmarkEndHour_ValueChanged(object sender, EventArgs e)
        {
            UpdateBookmarkDataFromInput();
        }

        private void numericBookmarkEndMin_ValueChanged(object sender, EventArgs e)
        {
            // 60을 넘겼을 경우 시간에 +1 후 초기화
            if ((sender as NumericUpDown).Value == 60)
            {
                _isUpdatingBookmarkInfo = true;
                numericBookmarkEndMin.Value = 0;
                numericBookmarkEndHour.Value++;
                _isUpdatingBookmarkInfo = false;
            }
            if ((sender as NumericUpDown).Value < 0)
            {
                _isUpdatingBookmarkInfo = true;
                numericBookmarkEndMin.Value = 59;
                numericBookmarkEndHour.Value--;
                _isUpdatingBookmarkInfo = false;
            }
            UpdateBookmarkDataFromInput();
        }

        private void numericBookmarkEndSec_ValueChanged(object sender, EventArgs e)
        {
            // 60을 넘겼을 경우 시간에 +1 후 초기화
            if ((sender as NumericUpDown).Value == 60)
            {
                _isUpdatingBookmarkInfo = true;
                numericBookmarkEndSec.Value = 0;
                numericBookmarkEndMin.Value++;
                _isUpdatingBookmarkInfo = false;
            }
            if ((sender as NumericUpDown).Value < 0)
            {
                _isUpdatingBookmarkInfo = true;
                numericBookmarkEndSec.Value = 59;
                numericBookmarkEndMin.Value--;
                _isUpdatingBookmarkInfo = false;
            }

            UpdateBookmarkDataFromInput();
        }

        // 책갈피 정보를 XML화해서 파일로 저장
        private void buttonSaveBookmark_Click(object sender, EventArgs e)
        {
            XmlDocument xml = new XmlDocument();
            XmlNode nodeRoot = xml.CreateElement("bookmarks");
            xml.AppendChild(nodeRoot);

            // 각 책갈피 리스트를 반복해 입력
            // 책갈피 예제
            /*
             * <xml>
             *      <project>
             *          <bookmarks filename="">
             *               <bookmarkdata bookmarkname="책갈피 1" bookmarkstart="" bookmarkend="" ...>
             *                  
             *                      <tag name="태그 1"/>
             *                      <tag name="태그 12"/>
             *                      ...
             *                      <tag name="태그 10"/>
             *                  
             *               </bookmarkdata>
             *               <bookmarkdata bookmarkname="책갈피 2" bookmarkstart="" bookmarkend="" ... />
             *               <bookmarkdata bookmarkname="책갈피 3" bookmarkstart="" bookmarkend="" ... />
             *               ...
             *               <bookmarkdata bookmarkname="책갈피 10" bookmarkstart="" bookmarkend="" ... />
             *          </bookmarks>
             *      </project>
             * </xml>
             * */
            foreach ( KeyValuePair<int, BookmarkItem> kvItem in _listBookmarks )
            {
                // kvItem.Value.
                XmlElement nodeBookmark = xml.CreateElement("bookmarkdata");

                nodeBookmark.SetAttribute("bookmarkStart", kvItem.Value.BookmarkStart.dTimeBookmark.ToString());
                nodeBookmark.SetAttribute("bookmarkEnd", kvItem.Value.BookmarkEnd.dTimeBookmark.ToString());
                nodeBookmark.SetAttribute("bookmarkName", kvItem.Value.sBookmarkName);

                XmlNode nodeTags = xml.CreateElement("tags");
                nodeBookmark.AppendChild(nodeTags);

                // 태그 저장(TODO : 태그 작성 기능 완료되면 디버그 필요
                if (kvItem.Value.vTags.Count > 0)
                {
                    foreach (string sTag in kvItem.Value.vTags)
                    {
                        XmlElement nodeTag = xml.CreateElement("tag");
                        nodeTag.SetAttribute("name", sTag);
                        nodeTags.AppendChild(nodeTag);
                    }
                }

                nodeRoot.AppendChild(nodeBookmark);

            }

            SaveFileDialog dialogSave = new SaveFileDialog();
            dialogSave.Filter = "XML File | *.xml";

            if (dialogSave.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    xml.Save(dialogSave.FileName);

                    MessageBox.Show("저장 : " + dialogSave.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("저장 실패 : " + ex.Message);
                }
            }
        }
        // 책갈피 예제
        /*

         *          <bookmarks filename="">
         *               <bookmarkdata bookmarkname="책갈피 1" bookmarkstart="" bookmarkend="" ...>
         *                  
         *                      <tag name="태그 1"/>
         *                      <tag name="태그 12"/>
         *                      ...
         *                      <tag name="태그 10"/>
         *                  
         *               </bookmarkdata>
         *               <bookmarkdata bookmarkname="책갈피 2" bookmarkstart="" bookmarkend="" ... />
         *               <bookmarkdata bookmarkname="책갈피 3" bookmarkstart="" bookmarkend="" ... />
         *               ...
         *               <bookmarkdata bookmarkname="책갈피 10" bookmarkstart="" bookmarkend="" ... />
         *          </bookmarks>
         * */
        private void buttonLoadBookmark_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialogOpen = new OpenFileDialog();
            dialogOpen.Filter = "XML File | *.xml";

            if(dialogOpen.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                XmlDocument xmlOpen = new XmlDocument();
                try
                {
                    xmlOpen.Load(dialogOpen.FileName);

                    // 기존 책갈피 내용 초기화
                    _nBookmarkCount = 0;
                    _listBookmarks.Clear();

                    // 리스트 초기화
                    listViewBookmark.Clear();
                    InitializeBookmarkList();

                    XmlNodeList nodeBookmarks = xmlOpen.SelectNodes("/bookmarks/bookmarkdata");

                    // 책갈피 내용별 루프
                    foreach (XmlNode nodeData in nodeBookmarks)
                    {
                        // 이름, 시작시간, 끝시간 읽어오기
                        string sBookmarkName = nodeData.Attributes["bookmarkName"].Value;
                        double dBookmarkStart = Convert.ToDouble(nodeData.Attributes["bookmarkStart"].Value);
                        double dBookmarkEnd = Convert.ToDouble(nodeData.Attributes["bookmarkEnd"].Value);
                        
                        BookmarkItem itemBookmark = new BookmarkItem(sBookmarkName, dBookmarkStart);
                        itemBookmark.BookmarkEnd = new BookmarkTimeData(dBookmarkEnd);

                        // 태그 읽어오기
                        foreach (XmlNode nodeTags in nodeData.ChildNodes)
                        {
                            if (nodeTags.Name == "tags")
                            {
                                foreach (XmlNode nodeTag in nodeTags.ChildNodes)
                                    itemBookmark.vTags.Add(nodeTag.Attributes["name"].Value);
                            }
                        }

                        _nBookmarkCount++;
                        _listBookmarks.Add(_nBookmarkCount, itemBookmark);

                        // 리스트에 등록
                        ListViewItem item = new ListViewItem(itemBookmark.BookmarkStart.sTimeBookmark);
                        item.SubItems.Add(dBookmarkStart.ToString());
                        item.SubItems.Add(sBookmarkName);
                        item.SubItems.Add(_nBookmarkCount.ToString());

                        // TODO : 썸네일 저장하게 되면 이미지 인덱스도 입력해야 함
                        // item.ImageIndex = imageList1.Images.Count;

                        listViewBookmark.Items.Add(item);
                    }                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("파일 열기 실패 : " + ex.Message);
                }
            }
        }

        private void buttonQuit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
