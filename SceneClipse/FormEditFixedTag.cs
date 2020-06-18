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
    public partial class FormEditFixedTag : Form
    {
        public List<string> _vsFixedTagList = new List<string>();

        public FormEditFixedTag()
        {
            InitializeComponent();
            InitializeList();
        }

        // InitializeList()
        // 리스트뷰 초기화
        private void InitializeList()
        {
            listViewFixedTags.Columns.Add("태그", listViewFixedTags.Width);
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if( listViewFixedTags.Items.Count > 0)
            {
                _vsFixedTagList.Clear();
                foreach (ListViewItem itemTag in listViewFixedTags.Items)
                {
                    _vsFixedTagList.Add(itemTag.Text);
                }
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            AddItemToList(textBoxFixedTagInput.Text);
        }

        private void AddItemToList(string sText)
        {
            // 리스트에 등록
            ListViewItem item = new ListViewItem(sText);
            item.SubItems.Add(sText);

            listViewFixedTags.Items.Add(item);

            textBoxFixedTagInput.Clear();
            textBoxFixedTagInput.Focus();
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            if(listViewFixedTags.SelectedItems.Count > 0)
            {
                listViewFixedTags.Items.Remove(listViewFixedTags.FocusedItem);
            }
        }

        public void SetFixedBookmark(List<string> vsFixedTagList)
        {
            _vsFixedTagList = vsFixedTagList.ToList();
            foreach( string sTag in _vsFixedTagList )
            {
                // 리스트에 등록
                ListViewItem item = new ListViewItem(sTag);
                item.SubItems.Add(sTag);

                listViewFixedTags.Items.Add(item);
            }
        }

        private void textBoxFixedTagInput_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void textBoxFixedTagInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AddItemToList(textBoxFixedTagInput.Text);
            }
        }
    }
}
