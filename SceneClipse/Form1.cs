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
using System.Threading;
using WMPLib;

namespace SceneClipse
{
    public partial class Form1 : Form
    {
        // 트랙바(trackBarVideoProgress)와 마우스 클릭 위치를 맞추기 위한 보정값.
        private const int TRACKBAR_VIDEOPROGRESS_MODIFY_POSITION_VALUE = 13;
        private const int TRACKBAR_AUDIOVOLUME_MODIFY_POSITION_VALUE = 13;

        private const string SCENECLIP_FILE_DESC = "Sceneclips File";
        private const string SCENECLIP_FILE_EXT = ".sclip";
        private const string SCENECLIP_FILE_OPENTEXT = SCENECLIP_FILE_DESC + "|*" + SCENECLIP_FILE_EXT;

        private const string BANDICUT_FILE_DESC = "Bandicut Project File";
        private const string BANDICUT_FILE_EXT = ".bcpf";
        private const string BANDICUT_FILE_OPENTEXT = BANDICUT_FILE_DESC + "|*" + BANDICUT_FILE_EXT;
        private const int VLCPLAYER_ORG_WIDTH = 610;
        private const int VLCPLAYER_ORG_HEIGHT = 348;
        private const int FORM_ORG_WIDTH = 890;
        private const int FORM_ORG_HEIGHT = 590;
        private const int MODIFY_SEC_TO_VLCTIME = 1000;


        // 책갈피 목록<인덱스, 책갈피>
        private SortedList<int, BookmarkItem> _listBookmarks;
        // 책갈피 개수(책갈피를 추가시킬때 이 값을 인덱스로 이용)
        private int _nBookmarkCount = 0;
        // 현재 선택된 책갈피 인덱스
        private int _nCurrentBookmarkIdx = 0;
        private ListViewItem _itemCurrentBookmark;
        // 현재 열려있는 파일 이름(혹은 해시값?)
        private string _sFilenamePlaying = "";
        private string _sFilehashPlaying = "";           // 현재 미사용
        private bool _isUpdatingBookmarkInfo = false;
        private bool _isWaitingForJump = false;
        private int _nVideoProgress = 0;
        private string _sVideoPlaytime = "";
        private int _nTrackbarMaximum = 0;
        private List<string> _listFixedTags;

        public Form1()
        {
            InitializeComponent();
            InitializeBookmarkList();
            InitializeVLCPlayer();

            this.panelTagList.VerticalScroll.Enabled = false;
            _listBookmarks = new SortedList<int, BookmarkItem>();
            _listFixedTags = new List<string>();
        }

        private void InitializeVLCPlayer()
        {
            this.vlcMediaPlayer = new Vlc.DotNet.Forms.VlcControl();
            this.vlcMediaPlayer.BeginInit();
            this.vlcMediaPlayer.Size = panelMediaPlayer.Size;
            this.vlcMediaPlayer.VlcLibDirectory = new DirectoryInfo(Path.Combine(".", "libvlc", IntPtr.Size == 4 ? "win-x86" : "win-x64"));

#if _DEBUG
            this.vlcMediaPlayer.VlcMediaplayerOptions = new[] { "--file-logging", "-vvv", "--extraintf=logger", "--logfile=vlcLog.log" };
#else
            this.vlcMediaPlayer.VlcMediaplayerOptions = new[] { "--no-snapshot-preview", "--snapshot-format=jpg", "--no-video-title", "--quiet-synchro", "--file-logging", "-vv", "--extraintf=logger", "--logfile=vlcLog.log" };
#endif
            this.vlcMediaPlayer.EndInit();

            vlcMediaPlayer.PositionChanged += VlcMediaPlayer_PositionChanged;
            vlcMediaPlayer.EncounteredError += (sender, e) =>
            {
                Console.Error.Write("Error : " + e);
            };

            this.Controls.Add(this.vlcMediaPlayer);
            this.panelMediaPlayer.Controls.Add(this.vlcMediaPlayer);

            // 트랙바 관련 컨트롤 추가(마우스 드래그 이벤트)
            Panel panelVideoProgress = new Panel();
            panelVideoProgress.Dock = DockStyle.Fill;
            panelVideoProgress.BackColor = Color.Transparent;
            panelVideoProgress.MouseDown += panelVideoProgress_MouseDown;
            panelVideoProgress.MouseMove += panelVideoProgress_MouseMove;
            this.panelTrackbarBackground.Controls.Add(panelVideoProgress);
            //panelVideoProgress.BringToFront();

            Panel panelVolume = new Panel();
            panelVolume.Dock = DockStyle.Fill;
            panelVolume.BackColor = Color.Transparent;
            panelVolume.MouseDown += panelVolume_MouseDown;
            panelVolume.MouseMove += panelVolume_MouseMove;
            this.panelVolumeControl.Controls.Add(panelVolume);

            _nTrackbarMaximum = trackBarVideoProgress.Maximum;

        }

        private void panelVideoProgress_MouseMove(object sender, MouseEventArgs e)
        {
            if (vlcMediaPlayer.IsPlaying)
            {
                if (e.Button == MouseButtons.Left)
                {
                    int nPosition = e.X - TRACKBAR_VIDEOPROGRESS_MODIFY_POSITION_VALUE;
                    if (nPosition < 0) nPosition = 0;

                    int nProgressValue = Convert.ToInt32(trackBarVideoProgress.Maximum * vlcMediaPlayer.Position);

                    _nVideoProgress =
                        (nProgressValue < trackBarVideoProgress.Maximum) ?
                        nProgressValue : trackBarVideoProgress.Maximum;

                    vlcMediaPlayer.Position = ((float)nPosition / (trackBarVideoProgress.Width - TRACKBAR_VIDEOPROGRESS_MODIFY_POSITION_VALUE * 2));
                }
            }
        }

        private void panelVolume_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int nPosition = Convert.ToInt32(((float)e.X - TRACKBAR_AUDIOVOLUME_MODIFY_POSITION_VALUE)
                / (trackBarVolumeControl.Width - TRACKBAR_AUDIOVOLUME_MODIFY_POSITION_VALUE * 2) * 100);

                if (nPosition < 0) nPosition = 0;
                if (nPosition > trackBarVolumeControl.Maximum)
                    nPosition = trackBarVolumeControl.Maximum;

                trackBarVolumeControl.Value = nPosition;
                if (vlcMediaPlayer.IsPlaying)
                    vlcMediaPlayer.Audio.Volume = nPosition;
            }
        }

        private void VlcMediaPlayer_PositionChanged(object sender, Vlc.DotNet.Core.VlcMediaPlayerPositionChangedEventArgs e)
        {

            if (vlcMediaPlayer.IsPlaying)
            {
                BookmarkTimeData timeBookmark = new BookmarkTimeData(vlcMediaPlayer.Time);
                BookmarkTimeData timeMedia = new BookmarkTimeData(vlcMediaPlayer.GetCurrentMedia().Duration.TotalMilliseconds);
                _sVideoPlaytime = "재생 중 : " + timeBookmark.GetTime()
                    + " / " +  timeMedia.GetTime() + " (" + Math.Floor(vlcMediaPlayer.Position * 100) + "%)";

                int nProgressValue = Convert.ToInt32(_nTrackbarMaximum * vlcMediaPlayer.Position);
                _nVideoProgress =
                    (nProgressValue < _nTrackbarMaximum) ?
                    nProgressValue : _nTrackbarMaximum;
            }
            else
            {
                _sVideoPlaytime = "";
            }
        }

        private void buttonPlay_Click(object sender, EventArgs e)
        {
            vlcMediaPlayer.Play();
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            vlcMediaPlayer.Stop();
        }

        // pause 버튼 클릭시 - 재생중이면 정지, 정지상태면 다시 재생
        private void buttonPause_Click(object sender, EventArgs e)
        {
            // 디버그용 임시 파일 설정(TODO : 이후에 제거)
            if (_sFilenamePlaying == "")
            {
                InitializeBookmarkdata();
                _sFilenamePlaying = @"c:\Wildlife.wmv";
                // _sFilehashPlaying = GetMD5HashFromFile(_sFilenamePlaying);

                vlcMediaPlayer.SetMedia(new FileInfo(_sFilenamePlaying));
            }
            else
            {
                // 재생중이면 정지, 정지상태면 다시 재생
                if (!vlcMediaPlayer.IsPlaying)
                    vlcMediaPlayer.Play();
                else
                    vlcMediaPlayer.Pause();
            }
        }

        // 파일 열기. 다이얼로그 표시 후 파일 선택하여 재생
        private void buttonOpenFile_Click(object sender, EventArgs e)
        {            
            OpenFileDialog openFiledialog1 = new OpenFileDialog();
            // openFiledialog1.Filter = "Movie files|*.wmv";
            try
            {
                if (openFiledialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    InitializeBookmarkdata();
                    _sFilenamePlaying = openFiledialog1.FileName;
                    // _sFilehashPlaying = GetMD5HashFromFile(_sFilenamePlaying);

                    // 자동 북마크파일 불러오기(불러오는 파일의 위치와 동일한 경로에 같은 이름의 .sclip 파일이 있으면 자동으로 읽어옴)
                    if (checkAutoloadBookmark.Checked)
                    {
                        string sBookmarkFilename = _sFilenamePlaying.Substring(0, _sFilenamePlaying.LastIndexOf('.')) + SCENECLIP_FILE_EXT;
                        if (File.Exists(sBookmarkFilename))
                        {
                            LoadBookmarkFormFile(sBookmarkFilename);
                        }
                    }

                    vlcMediaPlayer.SetMedia(new FileInfo(openFiledialog1.FileName));
                    vlcMediaPlayer.Audio.Volume = trackBarVolumeControl.Value;
                    vlcMediaPlayer.Play();

                    textBoxOpenFileName.Text = openFiledialog1.FileName;

                    /*
                    axMediaPlayer1.URL = openFiledialog1.FileName;

                    timerPlayTime.Start();
                    */

                    // labelOpenFileName.Text = "재생중인 파일 : " + openFiledialog1.FileName;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("재생 실패 : " + ex.Message);
            }
        }

        // UTF-8 변환용 함수. VLC플레이어에서 스크린샷 생성시 UTF-8로 변환되어 생성되므로 파일명을 변환할 필요가 있을 듯.
        private string ToUTF8(string sSnapshotFullPath)
        {
            byte[] bytes = Encoding.Default.GetBytes(sSnapshotFullPath);
            return Encoding.UTF8.GetString(bytes);
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
                if (!_isUpdatingBookmarkInfo)
                {
                    _itemCurrentBookmark = (sender as ListView).FocusedItem;
                    UpdateBookmarkInputData(Convert.ToInt32(_itemCurrentBookmark.SubItems[3].Text));
                }
            }
        }

        // private void UpdateBookmarkInputData(int nIdx)
        // 책갈피 정보를 입력칸에 갱신함
        // nIdx = 해당 책갈피의 인덱스 값
        // bJumpToBookmark = 갱신 후 해당 시각으로 이동할지 여부(책갈피 생성시에는 이동하지 않음)
        private void UpdateBookmarkInputData(int nIdx, bool bJumpToBookmark = true)
        {
            _isUpdatingBookmarkInfo = true;

            _nCurrentBookmarkIdx = nIdx;

            BookmarkItem bookmarkSelected = _listBookmarks[_nCurrentBookmarkIdx];

            if (bJumpToBookmark)
                vlcMediaPlayer.Time = Convert.ToInt64(bookmarkSelected.BookmarkStart.GetTimeDouble());
            // axMediaPlayer1.Ctlcontrols.currentPosition = bookmarkSelected.BookmarkStart.GetTimeDouble();

            //pictureBox1.Image = imageList1.Images[(sender as ListView).SelectedItems[0].Index];
            // 이미지를 썸네일 크기로 변환해서 표시(TODO : 썸네일 크기 상수화)
            if (bookmarkSelected.imageThumbnail != null)
                pictureBox1.Image = bookmarkSelected.imageThumbnail.GetThumbnailImage(pictureBox1.Width, pictureBox1.Height, null, new IntPtr());
            else if (pictureBox1.Image != null)
                pictureBox1.Image = null;


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

            _itemCurrentBookmark.Selected = true;
            listViewBookmark.Focus();

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

            // 입력될 값이 고정태그일 경우 볼드 표시
            if (_listFixedTags.Find(x => x.Equals(sTag)) != null)
                labelNewTag.Font = new Font(labelNewTag.Font, FontStyle.Bold);

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
                    // 태그 고정 기능 : 고정된 태그는 새 책갈피 생성시 자동 입력하도록 함
                    if ((Control.ModifierKeys & Keys.Control) != 0)
                    {
                        if ((s as Label).Font.Bold == false)
                        {
                            // 컨트롤+더블클릭시 태그 고정
                            (s as Label).Font = new Font((s as Label).Font, FontStyle.Bold);
                            _listFixedTags.Add((s as Label).Text);
                        }
                        else
                        {
                            // 고정된 태그 해제
                            (s as Label).Font = new Font((s as Label).Font, FontStyle.Regular);
                            _listFixedTags.Remove((s as Label).Text);
                        }
                    }
                    else
                    {
                        // 태그 수정 : 기존 태그 입력값을 입력칸에 넣어준 뒤, 기존 태그를 삭제해버림
                        textBoxTagInput.Text = (s as Label).Text;
                        RemoveFromTagList((s as Label).Text);
                    }
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
            for (int i = 2; i < panelTagList.Controls.Count; i++)
            {
                if (panelTagList.Controls[i].Text == sTag)
                {
                    panelTagList.Controls.RemoveAt(i);
                    _listBookmarks[_nCurrentBookmarkIdx].vTags.Remove(sTag);
                    bTagDeleted = true;
                }
            }
            if (bTagDeleted)
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
            labelNewTag.MouseDoubleClick += label6_MouseDoubleClick;

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
            _listFixedTags.Clear();
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
                        item.SubItems[0].Text = itemCurrent.BookmarkStart.GetTime();
                        item.SubItems[2].Text = itemCurrent.sBookmarkName;
                    }
                }

                // TODO : 태그 정보도 업데이트
            }
        }

        private void numericBookmarkStartHour_MouseClick(object sender, MouseEventArgs e)
        {
        }

        private void numericBookmarkStartMin_MouseClick(object sender, MouseEventArgs e)
        {
        }

        private void numericBookmarkStartSec_MouseClick(object sender, MouseEventArgs e)
        {
        }

        private void numericBookmarkEndHour_MouseClick(object sender, MouseEventArgs e)
        {
        }

        private void numericBookmarkEndMin_MouseClick(object sender, MouseEventArgs e)
        {
        }

        private void numericBookmarkEndSec_MouseClick(object sender, MouseEventArgs e)
        {
        }

        private void textBoxBookmarkName_TextChanged(object sender, EventArgs e)
        {
            UpdateBookmarkDataFromInput();
        }

        // 플레이어의 시간 변경
        private void JumpPlayerToTime(int nHour, int nMin, int nSec)
        {
            int nSeekTime = nHour * 3600 + nMin * 60 + nSec;
            vlcMediaPlayer.Time = Convert.ToInt64(nSeekTime * 1000);
            // axMediaPlayer1.Ctlcontrols.currentPosition = nSeekTime;
        }

        private void numericBookmarkStartHour_ValueChanged(object sender, EventArgs e)
        {
            if (_isUpdatingBookmarkInfo == false)
            {
                if (checkAutoSeekToTime.Checked)
                {
                    JumpPlayerToTime(
                        Convert.ToInt32(numericBookmarkStartHour.Value),
                        Convert.ToInt32(numericBookmarkStartMin.Value),
                        Convert.ToInt32(numericBookmarkStartSec.Value));
                }

                UpdateBookmarkDataFromInput();
            }
        }

        private void numericBookmarkStartMin_ValueChanged(object sender, EventArgs e)
        {
            if (_isUpdatingBookmarkInfo == false)
            {
                // 60을 넘겼을 경우 시간에 +1 후 초기화
                if ((sender as NumericUpDown).Value == 60)
                {
                    _isUpdatingBookmarkInfo = true;
                    numericBookmarkStartMin.Value = 0;
                    numericBookmarkStartHour.Value++;
                    _isUpdatingBookmarkInfo = false;
                }
                if ((sender as NumericUpDown).Value < 0)
                {
                    // 0시간이라 더이상 내릴 수 없을 경우 값을 변경하지 않음
                    if (numericBookmarkStartHour.Value == 0)
                        numericBookmarkStartMin.Value = 0;
                    else
                    {
                        _isUpdatingBookmarkInfo = true;
                        numericBookmarkStartMin.Value = 59;
                        numericBookmarkStartHour.Value--;
                        _isUpdatingBookmarkInfo = false;
                    }
                }

                if (checkAutoSeekToTime.Checked)
                {
                    JumpPlayerToTime(
                        Convert.ToInt32(numericBookmarkStartHour.Value),
                        Convert.ToInt32(numericBookmarkStartMin.Value),
                        Convert.ToInt32(numericBookmarkStartSec.Value));
                }

                UpdateBookmarkDataFromInput();
            }
        }

        private void numericBookmarkStartSec_ValueChanged(object sender, EventArgs e)
        {
            if (_isUpdatingBookmarkInfo == false)
            {
                // 60을 넘겼을 경우 시간에 +1 후 초기화
                if ((sender as NumericUpDown).Value == 60)
                {
                    _isUpdatingBookmarkInfo = true;
                    numericBookmarkStartSec.Value = 0;
                    numericBookmarkStartMin.Value++;

                    if(numericBookmarkStartMin.Value == 60)
                    {
                        numericBookmarkStartHour.Value++;
                        numericBookmarkStartMin.Value = 0;
                    }

                    _isUpdatingBookmarkInfo = false;
                }
                if ((sender as NumericUpDown).Value < 0)
                {
                    // 0시간 0분이라 더이상 내릴 수 없을 경우 값을 변경하지 않음
                    if (numericBookmarkStartHour.Value == 0
                        && numericBookmarkStartMin.Value == 0)
                        numericBookmarkStartSec.Value = 0;
                    else
                    {
                        _isUpdatingBookmarkInfo = true;
                        numericBookmarkStartSec.Value = 59;

                        if ( numericBookmarkStartMin.Value == 0 )
                        {
                            numericBookmarkStartMin.Value = 59;
                            numericBookmarkStartHour.Value--;
                        }
                        else
                            numericBookmarkStartMin.Value--;

                        _isUpdatingBookmarkInfo = false;
                    }
                }

                if (checkAutoSeekToTime.Checked)
                {
                    JumpPlayerToTime(
                        Convert.ToInt32(numericBookmarkStartHour.Value),
                        Convert.ToInt32(numericBookmarkStartMin.Value),
                        Convert.ToInt32(numericBookmarkStartSec.Value));
                }

                UpdateBookmarkDataFromInput();
            }
        }

        private void numericBookmarkEndHour_ValueChanged(object sender, EventArgs e)
        {
            if (_isUpdatingBookmarkInfo == false)
            {
                if (checkAutoSeekToTime.Checked)
                {
                    JumpPlayerToTime(
                        Convert.ToInt32(numericBookmarkEndHour.Value),
                        Convert.ToInt32(numericBookmarkEndMin.Value),
                        Convert.ToInt32(numericBookmarkEndSec.Value));
                }

                UpdateBookmarkDataFromInput();
            }
        }

        private void numericBookmarkEndMin_ValueChanged(object sender, EventArgs e)
        {
            if (_isUpdatingBookmarkInfo == false)
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
                    // 0시간이라 더이상 내릴 수 없을 경우 값을 변경하지 않음
                    if (numericBookmarkEndHour.Value == 0)
                        numericBookmarkEndMin.Value = 0;
                    else
                    {
                        _isUpdatingBookmarkInfo = true;
                        numericBookmarkEndMin.Value = 59;
                        numericBookmarkEndHour.Value--;
                        _isUpdatingBookmarkInfo = false;
                    }
                }

                if (checkAutoSeekToTime.Checked)
                {
                    JumpPlayerToTime(
                        Convert.ToInt32(numericBookmarkEndHour.Value),
                        Convert.ToInt32(numericBookmarkEndMin.Value),
                        Convert.ToInt32(numericBookmarkEndSec.Value));
                }

                UpdateBookmarkDataFromInput();
            }
        }

        private void numericBookmarkEndSec_ValueChanged(object sender, EventArgs e)
        {
            if (_isUpdatingBookmarkInfo == false)
            {
                // 60을 넘겼을 경우 시간에 +1 후 초기화
                if ((sender as NumericUpDown).Value == 60)
                {
                    _isUpdatingBookmarkInfo = true;
                    numericBookmarkEndSec.Value = 0;
                    numericBookmarkEndMin.Value++;

                    if (numericBookmarkEndMin.Value == 60)
                    {
                        numericBookmarkEndHour.Value++;
                        numericBookmarkEndMin.Value = 0;
                    }

                    _isUpdatingBookmarkInfo = false;
                }
                if ((sender as NumericUpDown).Value < 0)
                {
                    // 0시간 0분이라 더이상 내릴 수 없을 경우 값을 변경하지 않음
                    if (numericBookmarkEndHour.Value == 0
                        && numericBookmarkEndMin.Value == 0)
                        numericBookmarkEndSec.Value = 0;
                    else
                    {
                        _isUpdatingBookmarkInfo = true;
                        numericBookmarkEndSec.Value = 59;

                        if (numericBookmarkEndMin.Value == 0)
                        {
                            numericBookmarkEndMin.Value = 59;
                            numericBookmarkEndHour.Value--;
                        }
                        else
                            numericBookmarkEndMin.Value--;

                        _isUpdatingBookmarkInfo = false;
                    }
                }

                if (checkAutoSeekToTime.Checked)
                {
                    JumpPlayerToTime(
                        Convert.ToInt32(numericBookmarkEndHour.Value),
                        Convert.ToInt32(numericBookmarkEndMin.Value),
                        Convert.ToInt32(numericBookmarkEndSec.Value));
                }

                UpdateBookmarkDataFromInput();
            }
        }

        // 책갈피 정보를 XML화해서 파일로 저장
        private void buttonSaveBookmark_Click(object sender, EventArgs e)
        {
            XmlDocument xml = new XmlDocument();

            // utf-16 인코딩 정의
            XmlDeclaration xmldecl = xml.CreateXmlDeclaration("1.0", "utf-16", null);
            xml.InsertBefore(xmldecl, xml.DocumentElement);

            XmlElement nodeRoot = xml.CreateElement("bookmarks");
            nodeRoot.SetAttribute("version", "1.1");

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
            foreach (KeyValuePair<int, BookmarkItem> kvItem in _listBookmarks)
            {
                // kvItem.Value.
                XmlElement nodeBookmark = xml.CreateElement("bookmarkdata");

                nodeBookmark.SetAttribute("bookmarkStart", kvItem.Value.BookmarkStart.GetTimeDouble().ToString());
                nodeBookmark.SetAttribute("bookmarkEnd", kvItem.Value.BookmarkEnd.GetTimeDouble().ToString());
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

            string sSaveFilename;
            SaveFileDialog dialogSave = new SaveFileDialog();
            dialogSave.Filter = SCENECLIP_FILE_OPENTEXT;

            if (_sFilenamePlaying.StartsWith("http"))
            {
                // url에서 열 경우 파일명 가져오는 방식을 변경
                string sFileName = _sFilenamePlaying.Substring(_sFilenamePlaying.LastIndexOf('/') + 1);
                sFileName = sFileName.Substring(0, sFileName.LastIndexOf('.')) + SCENECLIP_FILE_EXT;

                sSaveFilename = sFileName;
            }
            else
            {
                sSaveFilename = _sFilenamePlaying.Substring(0, _sFilenamePlaying.LastIndexOf('.')) + SCENECLIP_FILE_EXT;
            }

            dialogSave.FileName = sSaveFilename;

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
            dialogOpen.Filter = SCENECLIP_FILE_OPENTEXT;
            string sOpenFilename;

            if (_sFilenamePlaying.StartsWith("http"))
            {
                // url에서 열 경우 파일명 가져오는 방식을 변경
                string sFileName = _sFilenamePlaying.Substring(_sFilenamePlaying.LastIndexOf('/') + 1);
                sFileName = sFileName.Substring(0, sFileName.LastIndexOf('.')) + SCENECLIP_FILE_EXT;

                sOpenFilename = sFileName;
            }
            else
                sOpenFilename = _sFilenamePlaying.Substring(0, _sFilenamePlaying.LastIndexOf('.')) + SCENECLIP_FILE_EXT;

            dialogOpen.FileName = sOpenFilename;

            if (dialogOpen.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                LoadBookmarkFormFile(dialogOpen.FileName);
            }
        }

        private void LoadBookmarkFormFile(string sFileName)
        {
            XmlDocument xmlOpen = new XmlDocument();

            // utf-16 인코딩 정의
            XmlDeclaration xmldecl = xmlOpen.CreateXmlDeclaration("1.0", "utf-16", null);
            try
            {
                xmlOpen.Load(sFileName);

                // 기존 책갈피 내용 초기화
                _nBookmarkCount = 0;
                _listBookmarks.Clear();

                // 리스트 초기화
                listViewBookmark.Clear();
                InitializeBookmarkList();

                XmlNodeList nodeBookmarkRoot = xmlOpen.SelectNodes("/bookmarks");
                double dBookmarkVersion = 0;

                if (nodeBookmarkRoot.Count > 0 && nodeBookmarkRoot[0].Attributes["version"] != null)
                    dBookmarkVersion = Convert.ToDouble(nodeBookmarkRoot[0].Attributes["version"].Value);

                XmlNodeList nodeBookmarks = xmlOpen.SelectNodes("/bookmarks/bookmarkdata");

                // 책갈피 내용별 루프
                foreach (XmlNode nodeData in nodeBookmarks)
                {
                    // 이름, 시작시간, 끝시간 읽어오기
                    string sBookmarkName = nodeData.Attributes["bookmarkName"].Value;
                    double dBookmarkStart = Convert.ToDouble(nodeData.Attributes["bookmarkStart"].Value);
                    double dBookmarkEnd = Convert.ToDouble(nodeData.Attributes["bookmarkEnd"].Value);

                    // 1.1버전 아래에서는 시간값 기준이 밀리초가 아닌 초로 되어 있으므로 보정
                    if (dBookmarkVersion < 1.1)
                    {
                        dBookmarkStart *= 1000;
                        dBookmarkEnd *= 1000;
                    }

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
                    ListViewItem item = new ListViewItem(itemBookmark.BookmarkStart.GetTime());
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

        private void buttonQuit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // private void buttonParse_Click(object sender, EventArgs e)
        // FormParseDialog 다이얼로그를 출력시키고, 시간 정보(단위 : 초.밀리초)를 받아옴
        // 받아온 시간정보를 이용해 책갈피 작성
        private void buttonParse_Click(object sender, EventArgs e)
        {
            var dialogParse = new FormParseDialog(_sFilenamePlaying);

            // 고정태그가 있으면 전달(편집용으로)
            if (_listFixedTags.Count > 0)
                dialogParse._vsFixedTagList = _listFixedTags;

            var result = dialogParse.ShowDialog();

            if (result == DialogResult.OK)
            {
                // 책갈피 정보 초기화
                InitializeBookmarkdata();

                // 고정태그 정보 가져오기
                _listFixedTags = dialogParse._vsFixedTagList;

                /*
                 * 받은 책갈피 시간정보로 실제 책갈피를 생성
                 * */
                foreach(BookmarkItem itemBookmark in dialogParse.VBookmarkGenerated)
                {
                    _nBookmarkCount++;
                    _listBookmarks.Add(_nBookmarkCount, itemBookmark);

                    // 리스트에 등록
                    ListViewItem item = new ListViewItem(itemBookmark.BookmarkStart.GetTime());
                    item.SubItems.Add((itemBookmark.BookmarkStart.GetTimeDouble()/1000).ToString());
                    item.SubItems.Add(itemBookmark.sBookmarkName);
                    item.SubItems.Add(_nBookmarkCount.ToString());

                    listViewBookmark.Items.Add(item);
                }
            }
        }

        private void buttonSeekPrev_Click(object sender, EventArgs e)
        {
            if (_sFilenamePlaying != "")
            {
                int nSeekTime = Convert.ToInt32(numericSeekTimeAmount.Value);
                if (comboBoxSeekType.SelectedItem.ToString() == "분")
                    nSeekTime *= 60;
                else if (comboBoxSeekType.SelectedItem.ToString() == "시간")
                    nSeekTime *= 3600;

                vlcMediaPlayer.Time -= Convert.ToInt64(nSeekTime * 1000);
                // axMediaPlayer1.Ctlcontrols.currentPosition -= nSeekTime;
            }
        }

        private void buttonSeekNext_Click(object sender, EventArgs e)
        {
            if (_sFilenamePlaying != "")
            {
                int nSeekTime = Convert.ToInt32(numericSeekTimeAmount.Value);
                if (comboBoxSeekType.SelectedItem.ToString() == "분")
                    nSeekTime *= 60;
                else if (comboBoxSeekType.SelectedItem.ToString() == "시간")
                    nSeekTime *= 3600;

                vlcMediaPlayer.Time += Convert.ToInt64(nSeekTime * 1000);
                // axMediaPlayer1.Ctlcontrols.currentPosition += nSeekTime;
            }
        }

        private void buttonExportBandicut_Click(object sender, EventArgs e)
        {
            XmlDocument xml = new XmlDocument();

            // utf-16 인코딩 정의
            XmlDeclaration xmldecl = xml.CreateXmlDeclaration("1.0", "utf-16", null);
            xml.InsertBefore(xmldecl, xml.DocumentElement);

            XmlNode nodeRoot = xml.CreateElement("BandicutProjectFile");
            xml.AppendChild(nodeRoot);

            // 각 책갈피 리스트를 반복해 입력
            // 반디컷 프로젝트파일 예제
            /*
             * <?xml version="1.0" encoding="utf-16"?>
             *      <BandicutProjectFile>
             *          <Setting Type="Cut" Join="No" />
             *          <VideoItem	Index="0"	Crc="0"	VideoIndex="0"	AudioIndex="0"
		                    Start="0"		End="1921934000(시간값(초) * 1000000)"
		                    Title="Notitle"
		                    File="D:\Movs\working\2017-03-30-2114-47-페르소나4.mp4" />
                        <VideoItem	Index="1"	Crc="0"	VideoIndex="0"	AudioIndex="0"
		                    Start="1915934000"		End="7049700000"
		                    Title="Notitle"
		                    File="D:\Movs\working\2017-03-30-2114-47-페르소나4.mp4" />
             *      </BandicutProjectFile>
             * </xml>
             * */

            // <Setting Type="Cut" Join="No" />
            XmlElement nodeSetting = xml.CreateElement("Setting");
            nodeSetting.SetAttribute("Type", "Cut");
            nodeSetting.SetAttribute("Join", "No");
            nodeRoot.AppendChild(nodeSetting);

            int nIdx = 0;
            foreach (KeyValuePair<int, BookmarkItem> kvItem in _listBookmarks)
            {
                XmlElement nodeBookmark = xml.CreateElement("VideoItem");

                nodeBookmark.SetAttribute("Index", nIdx.ToString());
                nodeBookmark.SetAttribute("Crc", "0");
                nodeBookmark.SetAttribute("VideoIndex", "0");
                nodeBookmark.SetAttribute("AudioIndex", "0");

                // 시작, 끝시각 보정 - 끝시각이 0이거나 적절하지 않다면 시작시각과 1초 차이나게 수정
                double dStart = kvItem.Value.BookmarkStart.GetTimeDouble();
                double dEnd = kvItem.Value.BookmarkEnd.GetTimeDouble();
                if (dStart > dEnd)
                    dEnd = dStart + 1;

                nodeBookmark.SetAttribute("Start", (dStart * 1000).ToString());
                nodeBookmark.SetAttribute("End", (dEnd * 1000).ToString());
                nodeBookmark.SetAttribute("Title", kvItem.Value.sBookmarkName);

                // 파일경로 보정 - 파일명만 남게 수정
                string sFileName = _sFilenamePlaying.Substring(_sFilenamePlaying.LastIndexOf('\\') + 1);
                nodeBookmark.SetAttribute("File", sFileName);

                XmlNode nodeTags = xml.CreateElement("tags");
                nodeBookmark.AppendChild(nodeTags);

                // 태그 저장(기본 반디컷 프로젝트에서는 사용되지 않지만 임시로 등록. 나중에 호환 가능할지도?)
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

                nIdx++;
            }

            string sSaveFilename;
            SaveFileDialog dialogSave = new SaveFileDialog();

            dialogSave.Filter = BANDICUT_FILE_OPENTEXT;
            sSaveFilename = _sFilenamePlaying.Substring(0, _sFilenamePlaying.LastIndexOf('.')) + BANDICUT_FILE_EXT;

            dialogSave.FileName = sSaveFilename;

            if (dialogSave.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    xml.Save(dialogSave.FileName);
                    // using (TextWriter sw = new StreamWriter(dialogSave.FileName, false, Encoding.UTF32))
                    //     xml.Save(sw);

                    MessageBox.Show("저장 : " + dialogSave.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("저장 실패 : " + ex.Message);
                }
            }
        }

        private void buttonSetCurrentTimeToStart_Click(object sender, EventArgs e)
        {
            BookmarkTimeData timedata = new BookmarkTimeData(vlcMediaPlayer.Time);
            _isUpdatingBookmarkInfo = true;
            numericBookmarkStartHour.Value = timedata.Hour;
            numericBookmarkStartMin.Value = timedata.Min;
            numericBookmarkStartSec.Value = timedata.Sec;
            _isUpdatingBookmarkInfo = false;
        }

        private void buttonSetCurrentTimeToEnd_Click(object sender, EventArgs e)
        {
            BookmarkTimeData timedata = new BookmarkTimeData(vlcMediaPlayer.Time);
            _isUpdatingBookmarkInfo = true;
            numericBookmarkEndHour.Value = timedata.Hour;
            numericBookmarkEndMin.Value = timedata.Min;
            numericBookmarkEndSec.Value = timedata.Sec;
            _isUpdatingBookmarkInfo = false;
        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            if (_nBookmarkCount != 0)
            {
                // mediaplayer에서 이미지 가져오기
                string sSnapshotPath = Path.Combine(Application.StartupPath, "Thumbnail");
                string sSnapshotFileName = _sFilenamePlaying.Substring(_sFilenamePlaying.LastIndexOf('\\') + 1) + "_" + vlcMediaPlayer.Time.ToString() + ".jpg";

                // 임시설정 - non-ascii 문자를 전부 제거. 현재 잘 해결되지 않았음(TODO : 한글 등의 파일명이 있어도 썸네일이 잘 생성되도록)
                sSnapshotFileName = Encoding.ASCII.GetString(Encoding.ASCII.GetBytes(ToUTF8(sSnapshotFileName))).Replace("?", string.Empty);

                string sSnapshotFullPath = sSnapshotPath + @"\" + sSnapshotFileName;
                Directory.CreateDirectory(sSnapshotPath);


                BookmarkItem bookmarkSelected = _listBookmarks[_nCurrentBookmarkIdx];

                // 기존 썸네일 파일이 존재한다면 삭제
                if (bookmarkSelected.sThumbnailPath != null)
                {
                    bookmarkSelected.imageThumbnail.Dispose();
                    File.Delete(sSnapshotPath + @"\" + bookmarkSelected.sThumbnailPath);
                }

                // 스크린샷 경로가 없으면 새로 만듦
                if (!Directory.Exists(sSnapshotPath))
                    Directory.CreateDirectory(sSnapshotPath);

                vlcMediaPlayer.TakeSnapshot(sSnapshotFullPath);

                // 스크린샷의 파일명에 한글 등이 포함되어 있을 경우 UTF-8로 변경되어 파일명이 깨짐.
                // 해당 문제를 수정하기 위해 파일명이 UTF-8형식으로 깨질 경우 파일명을 변경하도록 코드 수정.
                if (!File.Exists(sSnapshotFullPath))
                {
                    if (File.Exists(ToUTF8(sSnapshotFullPath)))
                        File.Move(ToUTF8(sSnapshotFullPath), sSnapshotFullPath);
                }

                bookmarkSelected.sThumbnailPath = sSnapshotFileName;

                if (File.Exists(sSnapshotFullPath))
                {
                    Bitmap bitmap = new Bitmap(sSnapshotFullPath);
                    bookmarkSelected.imageThumbnail = bitmap;

                    pictureBox1.Image = bookmarkSelected.imageThumbnail.GetThumbnailImage(pictureBox1.Width, pictureBox1.Height, null, new IntPtr());
                }
            }
        }

        private void panelVideoProgress_MouseDown(object sender, MouseEventArgs e)
        {
            if (vlcMediaPlayer.IsPlaying)
            {
                int nPosition = e.X - TRACKBAR_VIDEOPROGRESS_MODIFY_POSITION_VALUE;
                if (nPosition < 0) nPosition = 0;

                int nProgressValue = Convert.ToInt32(trackBarVideoProgress.Maximum * vlcMediaPlayer.Position);

                _nVideoProgress =
                    (nProgressValue < trackBarVideoProgress.Maximum) ?
                    nProgressValue : trackBarVideoProgress.Maximum;

                vlcMediaPlayer.Position = ((float)nPosition / (trackBarVideoProgress.Width - TRACKBAR_VIDEOPROGRESS_MODIFY_POSITION_VALUE * 2));

            }
        }

        private void panelVolume_MouseDown(object sender, MouseEventArgs e)
        {
            int nPosition = Convert.ToInt32(((float)e.X - TRACKBAR_AUDIOVOLUME_MODIFY_POSITION_VALUE)
                / (trackBarVolumeControl.Width - TRACKBAR_AUDIOVOLUME_MODIFY_POSITION_VALUE * 2) * 100);

            if (nPosition < 0) nPosition = 0;
            if (nPosition > trackBarVolumeControl.Maximum)
                nPosition = trackBarVolumeControl.Maximum;

            trackBarVolumeControl.Value = nPosition;
            if (vlcMediaPlayer.IsPlaying)
                vlcMediaPlayer.Audio.Volume = nPosition;
        }

        private void timerDisplayPlaytime_Tick(object sender, EventArgs e)
        {

            if (labelPlayTime.Text != _sVideoPlaytime)
                labelPlayTime.Text = _sVideoPlaytime;

            if (trackBarVideoProgress.Value != _nVideoProgress)
                trackBarVideoProgress.Value = _nVideoProgress;

            // 구간반복재생 사용시 처리
            if( checkBoxPartialplay.Checked && _listBookmarks.ContainsKey(_nCurrentBookmarkIdx) )
            {
                // 현재시간이 책갈피 종료시간을 넘겼을 경우
                if(vlcMediaPlayer.Time > _listBookmarks[_nCurrentBookmarkIdx].BookmarkEnd.GetTimeDouble())
                {
                    if (radioPartialplayOptionLoop.Checked)
                    {
                        BookmarkTimeData timeData = _listBookmarks[_nCurrentBookmarkIdx].BookmarkStart;
                        JumpPlayerToTime(timeData.Hour, timeData.Min, timeData.Sec);
                    }
                    else if( radioPartialplayOptionJump.Checked)
                    {
                        // 시간 단위로 이후에 작성된 책갈피를 검색
                        int nIdx = listViewBookmark.Items.IndexOf(_itemCurrentBookmark);

                        // 맨 마지막 순서가 아니면 다음 책갈피를 선택
                        if (nIdx < listViewBookmark.Items.Count - 1)
                        {
                            _itemCurrentBookmark = listViewBookmark.Items[nIdx + 1];
                            _nCurrentBookmarkIdx = Convert.ToInt32(_itemCurrentBookmark.SubItems[3].Text);
                            UpdateBookmarkInputData(_nCurrentBookmarkIdx);
                        }
                        else if(nIdx == listViewBookmark.Items.Count - 1)
                        {
                            _itemCurrentBookmark = listViewBookmark.Items[0];
                            _nCurrentBookmarkIdx = Convert.ToInt32(_itemCurrentBookmark.SubItems[3].Text);
                            UpdateBookmarkInputData(_nCurrentBookmarkIdx);
                        }
                    }
                }
            }
        }

        private void buttonBookmark_Click(object sender, EventArgs e)
        {

            if (_sFilenamePlaying != "")
            {
                // 책갈피 리스트에서 현재 추가할 정보의 인덱스
                int nCurrentBookmarkIndex = ++_nBookmarkCount;

                BookmarkTimeData timeVideo = new BookmarkTimeData(vlcMediaPlayer.Time);

                int nModifyTime = (int)numericBookmarkTimeModifyValue.Value;
                int nModifyType = 1;
                if (comboBoxBookmarkTimeModifyType.Text == "분")
                    nModifyType *= 60;
                else if (comboBoxBookmarkTimeModifyType.Text == "시")
                    nModifyType *= 60 * 60;

                string sVideoTime = timeVideo.GetTime();
                double dVideoTime = timeVideo.GetTimeDouble();
                double dVideoStartTime = dVideoTime;
                double dVideoEndTime = dVideoTime;

                // 책갈피 시간 보정
                if (checkBoxBookmarkTimeModifyHead.Checked)
                    dVideoStartTime -= (nModifyTime * nModifyType * MODIFY_SEC_TO_VLCTIME);
                if (checkBoxBookmarkTimeModifyTail.Checked)
                    dVideoEndTime += (nModifyTime * nModifyType * MODIFY_SEC_TO_VLCTIME);

                // 시간이 0시간일 경우 문구 앞에 00을 추가함
                if (sVideoTime.Split(':').Length < 3) sVideoTime = "00:" + sVideoTime;

                BookmarkItem itemNewBookmark = new BookmarkItem("책갈피 " + sVideoTime, dVideoStartTime);
                itemNewBookmark.BookmarkEnd.UpdateTime(dVideoEndTime);

                // mediaplayer에서 이미지 가져오기
                string sSnapshotPath = Path.Combine(Application.StartupPath, "Thumbnail");
                string sSnapshotFileName = _sFilenamePlaying.Substring(_sFilenamePlaying.LastIndexOf('\\') + 1) + "_" + vlcMediaPlayer.Time.ToString() + ".jpg";

                // url에서 열 경우 파일명 가져오는 방식을 변경
                if (sSnapshotFileName.StartsWith("http"))
                    sSnapshotFileName = sSnapshotFileName.Substring(sSnapshotFileName.LastIndexOf('/'));

                // 임시설정 - non-ascii 문자를 전부 제거. 현재 잘 해결되지 않았음(TODO : 한글 등의 파일명이 있어도 썸네일이 잘 생성되도록)
                sSnapshotFileName = Encoding.ASCII.GetString(Encoding.ASCII.GetBytes(ToUTF8(sSnapshotFileName))).Replace("?", string.Empty);

                string sSnapshotFullPath = sSnapshotPath + @"\" + sSnapshotFileName;


                // 스크린샷 경로가 없으면 새로 만듦
                if (!Directory.Exists(sSnapshotPath))
                    Directory.CreateDirectory(sSnapshotPath);                              

                vlcMediaPlayer.TakeSnapshot(sSnapshotFullPath);

                // 스크린샷의 파일명에 한글 등이 포함되어 있을 경우 UTF-8로 변경되어 파일명이 깨짐.
                // 해당 문제를 수정하기 위해 파일명이 UTF-8형식으로 깨질 경우 파일명을 변경하도록 코드 수정.
                if (!File.Exists(sSnapshotFullPath))
                {
                    if (File.Exists(ToUTF8(sSnapshotFullPath)))
                        File.Move(ToUTF8(sSnapshotFullPath), sSnapshotFullPath);
                }

                itemNewBookmark.sThumbnailPath = sSnapshotFileName;

                if (File.Exists(sSnapshotFullPath))
                {
                    Bitmap bitmap = new Bitmap(sSnapshotFullPath);
                    itemNewBookmark.imageThumbnail = bitmap;
                }

                // 고정된 태그 자동 입력
                if (_listFixedTags.Count > 0)
                {
                    foreach (string tag in _listFixedTags)
                    {
                        itemNewBookmark.vTags.Add(tag);
                    }
                }

                // 책갈피 목록에 추가            
                _listBookmarks.Add(nCurrentBookmarkIndex, itemNewBookmark);


                // 리스트에 등록
                ListViewItem item = new ListViewItem(itemNewBookmark.BookmarkStart.GetTime());
                item.SubItems.Add(dVideoStartTime.ToString());
                item.SubItems.Add(itemNewBookmark.sBookmarkName);
                item.SubItems.Add(nCurrentBookmarkIndex.ToString());

                item.ImageIndex = imageList1.Images.Count;

                listViewBookmark.Items.Add(item);

                // 등록한 아이템을 현재 책갈피 아이템으로 설정
                _itemCurrentBookmark = item;

                // 책갈피 편집부분에도 표시
                UpdateBookmarkInputData(nCurrentBookmarkIndex, false);

                //listBookmark.DisplayMember = "sVideoTime";
                //listBookmark.Items.Add(item);          
            }
        }

        private void buttonRemoveBookmark_Click(object sender, EventArgs e)
        {
            if (listViewBookmark.SelectedItems.Count > 0)
            {
                _isUpdatingBookmarkInfo = true;
                {
                    int nBookmarkIdx = listViewBookmark.FocusedItem.Index;

                    // 책갈피 삭제시 다음 책갈피로 포커스 이동
                    if (listViewBookmark.Items.Count - 1 != nBookmarkIdx)
                    {
                        listViewBookmark.Items[nBookmarkIdx + 1].Selected = true;
                        listViewBookmark.Select();
                    }
                    // 현재 책갈피 값을 다음 값으로 수정                    
                    // 시간 단위로 이후에 작성된 책갈피를 검색
                    int nIdx = listViewBookmark.Items.IndexOf(_itemCurrentBookmark);

                    // 맨 마지막 순서가 아니면 다음 책갈피를 선택
                    if (nIdx < listViewBookmark.Items.Count - 1)
                    {
                        _itemCurrentBookmark = listViewBookmark.Items[nIdx + 1];
                        _nCurrentBookmarkIdx = Convert.ToInt32(_itemCurrentBookmark.SubItems[3].Text);
                    }

                    _listBookmarks.Remove(Convert.ToInt32(listViewBookmark.FocusedItem.SubItems[3].Text));

                    listViewBookmark.Items.RemoveAt(nBookmarkIdx);
                }
                _isUpdatingBookmarkInfo = false;
            }
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            int nNewWidth = this.Width - panelMediaPlayer.Location.X - 21;
            int nNewHeight = this.Height - panelMediaPlayer.Location.Y - 120;

            vlcMediaPlayer.Width = nNewWidth;
            vlcMediaPlayer.Height = nNewHeight;
        }

        private void label6_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if( e.Button == MouseButtons.Left )
            {
                FormEditFixedTag dialog = new FormEditFixedTag();
                if (_listFixedTags.Count > 0)
                {
                    dialog.SetFixedBookmark(_listFixedTags);
                }

                var result = dialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    _listFixedTags.Clear();
                    _listFixedTags = dialog._vsFixedTagList.ToList();
                }
            }
        }

        private void buttonSetCurrentTimeToStart_MouseClick(object sender, MouseEventArgs e)
        {
        }

        private void buttonSetCurrentTimeToEnd_MouseClick(object sender, MouseEventArgs e)
        {
        }

        // 이전 책갈피로 이동
        private void buttonJumpPrevBookmark_Click(object sender, EventArgs e)
        {
            if (_sFilenamePlaying != "")
            {
                // 시간 단위로 이전에 작성된 책갈피를 검색
                int nIdx = listViewBookmark.Items.IndexOf(_itemCurrentBookmark);
                if (nIdx > 0)
                {
                    _itemCurrentBookmark = listViewBookmark.Items[nIdx - 1];
                    _nCurrentBookmarkIdx = Convert.ToInt32(_itemCurrentBookmark.SubItems[3].Text);
                    UpdateBookmarkInputData(_nCurrentBookmarkIdx);
                }
            }
        }

        // 다음 책갈피로 이동
        private void buttonJumpNextBookmark_Click(object sender, EventArgs e)
        {
            if (_sFilenamePlaying != "")
            {
                // 시간 단위로 이후에 작성된 책갈피를 검색
                int nIdx = listViewBookmark.Items.IndexOf(_itemCurrentBookmark);

                // 맨 마지막 순서가 아니면 다음 책갈피를 선택
                if (nIdx < listViewBookmark.Items.Count - 1)
                {
                    _itemCurrentBookmark = listViewBookmark.Items[nIdx + 1];
                    _nCurrentBookmarkIdx = Convert.ToInt32(_itemCurrentBookmark.SubItems[3].Text);
                    UpdateBookmarkInputData(_nCurrentBookmarkIdx);
                }
            }
        }

        private void buttonOpenFile_MouseClick(object sender, MouseEventArgs e)
        {
        }

        private void buttonOpenFile_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                InputDialog dialogInput = new InputDialog();
                var ret = dialogInput.ShowDialog();

                if (ret == DialogResult.OK)
                {
                    InitializeBookmarkdata();
                    _sFilenamePlaying = dialogInput._sInputValue;

                    // 경로 보정
                    if (_sFilenamePlaying.StartsWith("://")) _sFilenamePlaying = "http" + _sFilenamePlaying;
                    else if (_sFilenamePlaying.StartsWith("p://")) _sFilenamePlaying = "htt" + _sFilenamePlaying;
                    else if (_sFilenamePlaying.StartsWith("s://")) _sFilenamePlaying = "http" + _sFilenamePlaying;

                    vlcMediaPlayer.SetMedia(new Uri(_sFilenamePlaying));
                    vlcMediaPlayer.Audio.Volume = trackBarVolumeControl.Value;
                    vlcMediaPlayer.Play();
                }
            }
        }

        private void buttonModifyFixedTag_Click(object sender, EventArgs e)
        {
            FormEditFixedTag dialog = new FormEditFixedTag();
            if (_listFixedTags.Count > 0)
            {
                dialog.SetFixedBookmark(_listFixedTags);
            }

            var result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                _listFixedTags.Clear();
                _listFixedTags = dialog._vsFixedTagList.ToList();
            }
        }

        private void checkBoxPartialPlay_CheckedChanged(object sender, EventArgs e)
        {
            bool bChecked = checkBoxPartialplay.Checked;

            labelPartialplayOption.Visible = bChecked;
            radioPartialplayOptionJump.Visible = bChecked;
            radioPartialplayOptionLoop.Visible = bChecked;

        }

        private void buttonSetCurrentTimeToStart_MouseUp(object sender, MouseEventArgs e)
        {
            if (_sFilenamePlaying != "")
            {
                // 우클릭시 책갈피 시작부분으로 이동
                if (e.Button == MouseButtons.Right)
                {
                    JumpPlayerToTime((int)numericBookmarkStartHour.Value, (int)numericBookmarkStartMin.Value, (int)numericBookmarkStartSec.Value);
                }
            }
        }

        private void buttonSetCurrentTimeToEnd_MouseUp(object sender, MouseEventArgs e)
        {
            if (_sFilenamePlaying != "")
            {
                // 우클릭시 책갈피 끝부분으로 이동
                if (e.Button == MouseButtons.Right)
                {
                    JumpPlayerToTime((int)numericBookmarkEndHour.Value, (int)numericBookmarkEndMin.Value, (int)numericBookmarkEndSec.Value);
                }
            }
        }
    }
}
