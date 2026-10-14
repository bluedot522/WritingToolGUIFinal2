
using Microsoft.VisualBasic.ApplicationServices;
using System.Text.Json;
using System.Linq;

namespace WritingToolGUI
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();

        }


        public static int currentPageIndex = 1;

        public static List<Item> displayList = new List<Item>();
        public static List<Item> searchList = new List<Item>();
        private void btnQuit_Click(object sender, EventArgs e)
        {
            //Exits the application
            Application.Exit();
        }

        private void btnAddCharacter_Click(object sender, EventArgs e)
        {

            ClearSearch();
            AddCharacter();

            searchList = Search.RestoreDefaultList();
            currentPageIndex = 1;

            UpdateDisplayList();

            Save.SaveAll();


        }

        private void AddCharacter()
        {
            //Opens a new form for the user to write in
            lblWelcome.Visible = false;
            ClearSearch();
            string type = "Character";
            editForm editForm = new editForm(type);

            editForm.ShowDialog();

            if (editForm.editName != null)
            {


                Item.itemsTotal.Add(new Item
                {
                    Name = editForm.editName,
                    Description = editForm.editDescription,
                    Tags = editForm.editTags,
                    Date = DateTime.Now.ToString("MM/dd/yy"),
                    Type = "Character"
                });
            }

        }

        private void btnAddProject_Click(object sender, EventArgs e)
        {
            ClearSearch();
            AddProject();

            searchList = Search.RestoreDefaultList();
            currentPageIndex = 1;

            UpdateDisplayList();

            Save.SaveAll();

        }

        private void AddProject()

        {
            //Opens a new form for the user to write in
            lblWelcome.Visible = false;
            string type = "Project";
            editForm editForm = new editForm(type);
            editForm.ShowDialog();
            if (editForm.editName != null)
            {

                Item.itemsTotal.Add(new Item
                {
                    Name = editForm.editName,
                    Description = editForm.editDescription,
                    Tags = editForm.editTags,
                    Date = DateTime.Now.ToString("MM/dd/yy"),
                    Type = "Project"
                });
            }


        }

        // Pagination fixed
        private void btnNext_Click(object sender, EventArgs e)
        {
            NextPage();
            CheckNextButtonVisible();
        }

        private void NextPage()
        {
            currentPageIndex += 1;
            UpdateDisplayList();
            btnBack.Visible = true;
        }

        //Loads items saved to file if previous characters/ projects were added
        public void LoadAll()
        {
            string fileName = "All.json";
            string filePath = Path.Combine(Environment.CurrentDirectory, fileName);
            if (File.Exists(filePath))
                try
                {
                    
                    string jsonString = File.ReadAllText(filePath);
                    Item.itemsTotal = JsonSerializer.Deserialize<List<Item>>(jsonString);
                    searchList = Search.RestoreDefaultList();
                    UpdateDisplayList();
                    CheckNextButtonVisible();
                }
                catch (FileNotFoundException)
                {
                    MessageBox.Show("File not found.", "Error", MessageBoxButtons.OK);
                }
                catch (JsonException)
                {
                    MessageBox.Show("JSON is invalid.", "Error", MessageBoxButtons.OK);
                }
                catch (IOException)
                {
                    MessageBox.Show("Error processing file.", "Error", MessageBoxButtons.OK);
                }
                catch (UnauthorizedAccessException)
                {
                    MessageBox.Show("Access denied.", "Error", MessageBoxButtons.OK);

                }
                catch (Exception)
                {
                    MessageBox.Show("An error has occurred.", "Error", MessageBoxButtons.OK);
                }
            else
            {
                MessageBox.Show("No previous entries found.", "Information", MessageBoxButtons.OK);
            }
        }

        // Loads items archived, which will not show in the main list
        public void LoadArchive()
        {
            string fileName = "Archive.json";
            string filePath = Path.Combine(Environment.CurrentDirectory, fileName);
            if (File.Exists(filePath))
                try
                {
                    
                    string jsonString = File.ReadAllText(filePath);
                    Item.itemsArchived = JsonSerializer.Deserialize<List<Item>>(jsonString);

                }
                catch (FileNotFoundException)
                {
                    MessageBox.Show("File not found.", "Error", MessageBoxButtons.OK);
                }
                catch (JsonException)
                {
                    MessageBox.Show("JSON is invalid.", "Error", MessageBoxButtons.OK);
                }
                catch (IOException)
                {
                    MessageBox.Show("Error processing file.", "Error", MessageBoxButtons.OK);
                }
                catch (UnauthorizedAccessException)
                {
                    MessageBox.Show("Access denied.", "Error", MessageBoxButtons.OK);

                }
                catch (Exception)
                {
                    MessageBox.Show("An error has occurred.", "Error", MessageBoxButtons.OK);
                }
            
        }


        public void HideEditButton()
        {
            lnkEdit1.Visible = false;
            lnkEdit2.Visible = false;
            lnkEdit3.Visible = false;
            lnkEdit4.Visible = false;
            lnkEdit5.Visible = false;
        }

        // Updates the text on the display for each page
        public void UpdateText()
        {
            int displayCount = displayList.Count();

            switch (displayCount)
            {
                case 0:
                    MakeLinkInvisible(1);
                    MakeLinkInvisible(2);
                    MakeLinkInvisible(3);
                    MakeLinkInvisible(4);
                    MakeLinkInvisible(5);
                    break;
                case 1:
                    DisplayFirstLink();
                    MakeLinkVisible(1);
                    MakeLinkInvisible(2);
                    MakeLinkInvisible(3);
                    MakeLinkInvisible(4);
                    MakeLinkInvisible(5);
                    break;
                case 2:
                    DisplayFirstLink();
                    DisplaySecondLink();
                    MakeLinkVisible(1);
                    MakeLinkVisible(2);
                    MakeLinkInvisible(3);
                    MakeLinkInvisible(4);
                    MakeLinkInvisible(5);
                    break;
                case 3:
                    DisplayFirstLink();
                    DisplaySecondLink();
                    DisplayThirdLink();
                    MakeLinkVisible(1);
                    MakeLinkVisible(2);
                    MakeLinkVisible(3);
                    MakeLinkInvisible(4);
                    MakeLinkInvisible(5);


                    break;
                case 4:
                    DisplayFirstLink();
                    DisplaySecondLink();
                    DisplayThirdLink();
                    DisplayFourthLink();
                    MakeLinkVisible(1);
                    MakeLinkVisible(2);
                    MakeLinkVisible(3);
                    MakeLinkVisible(4);
                    MakeLinkInvisible(5);
                    break;
                default:
                    DisplayFirstLink();
                    DisplaySecondLink();
                    DisplayThirdLink();
                    DisplayFourthLink();
                    DisplayFifthLink();
                    MakeLinkVisible(1);
                    MakeLinkVisible(2);
                    MakeLinkVisible(3);
                    MakeLinkVisible(4);
                    MakeLinkVisible(5);
                    break;
            }

        }
        public void DisplayFirstLink()
        {
            lnkItem1.Text = displayList[0].Name;
            lblDate1.Text = displayList[0].Date;
            lblTags1.Text = string.Join(", ", displayList[0].Tags);
        }

        public void DisplaySecondLink()
        {
            lnkItem2.Text = displayList[1].Name;
            lblDate2.Text = displayList[1].Date;
            lblTags2.Text = string.Join(", ", displayList[1].Tags);
        }

        public void DisplayThirdLink()
        {
            lnkItem3.Text = displayList[2].Name;
            lblDate3.Text = displayList[2].Date;
            lblTags3.Text = string.Join(", ", displayList[2].Tags);
        }

        public void DisplayFourthLink()
        {
            lnkItem4.Text = displayList[3].Name;
            lblDate4.Text = displayList[3].Date;
            lblTags4.Text = string.Join(", ", displayList[3].Tags);
        }

        public void DisplayFifthLink()
        {
            lnkItem5.Text = displayList[4].Name;
            lblDate5.Text = displayList[4].Date;
            lblTags5.Text = string.Join(", ", displayList[4].Tags);
        }

        public void UpdateDisplayList()
        {
            displayList.Clear();

            int itemRange = ((currentPageIndex - 1) * 5);
            int endRange = searchList.Count() - 1;
            if (searchList.Count == 1)
            {
                endRange = 0;
                displayList.Add(searchList[0]);
            }
            else
            {
                for (int i = itemRange; i <= endRange; ++i)
                {
                    displayList.Add(searchList[i]);
                }

            }
            UpdateText();
            CheckNextButtonVisible();
            CheckIfSearch();

        }

        public void MakeLinkInvisible(int linkIndex)
        {
            switch (linkIndex)
            {
                case 1:
                    lnkItem1.Visible = false;
                    lblDate1.Visible = false;
                    lnkEdit1.Visible = false;
                    lblTags1.Visible = false;
                    break;
                case 2:
                    lnkItem2.Visible = false;
                    lblDate2.Visible = false;
                    lnkEdit2.Visible = false;
                    lblTags2.Visible = false;
                    break;
                case 3:
                    lnkItem3.Visible = false;
                    lblDate3.Visible = false;
                    lnkEdit3.Visible = false;
                    lblTags3.Visible = false;
                    break;
                case 4:
                    lnkItem4.Visible = false;
                    lblDate4.Visible = false;
                    lnkEdit4.Visible = false;
                    lblTags4.Visible = false;
                    break;
                case 5:
                    lnkItem5.Visible = false;
                    lblDate5.Visible = false;
                    lnkEdit5.Visible = false;
                    lblTags5.Visible = false;
                    break;
            }
        }
        public void MakeLinkVisible(int linkIndex)
        {
            if (linkIndex <= 5)
            {
                switch (linkIndex)
                {
                    case 1:
                        lnkItem1.Visible = true;
                        lblDate1.Visible = true;
                        lnkEdit1.Visible = true;
                        lblTags1.Visible = true;
                        break;
                    case 2:
                        lnkItem2.Visible = true;
                        lblDate2.Visible = true;
                        lnkEdit2.Visible = true;
                        lblTags2.Visible = true;
                        break;
                    case 3:
                        lnkItem3.Visible = true;
                        lblDate3.Visible = true;
                        lnkEdit3.Visible = true;
                        lblTags3.Visible = true;
                        break;
                    case 4:
                        lnkItem4.Visible = true;
                        lblDate4.Visible = true;
                        lnkEdit4.Visible = true;
                        lblTags4.Visible = true;
                        break;
                    case 5:
                        lnkItem5.Visible = true;
                        lblDate5.Visible = true;
                        lnkEdit5.Visible = true;
                        lblTags5.Visible = true;
                        break;
                }
            }

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            PreviousPage();
            CheckNextButtonVisible();
        }

        private void PreviousPage()
        {
            currentPageIndex -= 1;
            UpdateDisplayList();

            if (currentPageIndex == 1)
            {
                btnBack.Visible = false;
            }
        }

        //Checks for status of item after the edit window closes and takes appropriate action
        private void CheckForDeletedOrEditedOrAchived(int editIndex)
        {
            if (Item.itemsTotal[editIndex].Status == "Deleted")
            {
                if (Item.itemsTotal[editIndex].Type == "Character")
                {

                    Item.Delete(Item.itemsTotal[editIndex]);
                    Save.SaveAll();


                }
                else
                {

                    Item.Delete(Item.itemsTotal[editIndex]);
                    Save.SaveAll();


                }
                currentPageIndex = 1;
                searchList = Search.RestoreDefaultList();
                CheckNextButtonVisible();
            }
            else if (Item.itemsTotal[editIndex].Status == "Archived")
            {
                if (Item.itemsTotal[editIndex].Type == "Character")
                {
                    Item.itemsArchived.Add(Item.itemsTotal[editIndex]);

                    Item.Delete(Item.itemsTotal[editIndex]);
                    Save.SaveAll();
                    Save.SaveArchive();


                }
                else
                {
                    Item.itemsArchived.Add(Item.itemsTotal[editIndex]);

                    Item.Delete(Item.itemsTotal[editIndex]);
                    Save.SaveAll();
                    Save.SaveArchive();


                }
                currentPageIndex = 1;
                searchList = Search.RestoreDefaultList();
                CheckNextButtonVisible();
            }

            else

            {
                if (Item.itemsTotal[editIndex].Type == "Character")
                {
                    Item.Edit(Item.itemsTotal[editIndex], editForm.editName, editForm.editDescription, editForm.editTags);
                    Save.SaveAll();

                }
                else
                {
                    Item.Edit(Item.itemsTotal[editIndex], editForm.editName, editForm.editDescription, editForm.editTags);
                    Save.SaveAll();

                }

            }
        }
        private void MakeEditForm(int editIndex)
        {
            editForm editForm = new editForm(Item.itemsTotal[editIndex], editIndex);

            if (Item.itemsTotal[editIndex].Type == "Character")
            {
                editForm.Text = $"Edit Character: {Item.itemsTotal[editIndex].Name}";
                editForm.ShowDialog();

            }
            else
            {
                editForm.Text = $"Edit Project: {Item.itemsTotal[editIndex].Name}";
                editForm.ShowDialog();

            }

            CheckForDeletedOrEditedOrAchived(editIndex);

        }

        private void lnkEdit1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int editIndex = ((currentPageIndex - 1) * 5);
            MakeEditForm(editIndex);
            UpdateDisplayList();
        }

        private void lnkEdit2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int editIndex = ((currentPageIndex - 1) * 5) + 1;
            MakeEditForm(editIndex);
            UpdateDisplayList();
        }

        private void lnkEdit3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int editIndex = ((currentPageIndex - 1) * 5) + 2;
            MakeEditForm(editIndex);
            UpdateDisplayList();
        }

        private void lnkEdit4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int editIndex = ((currentPageIndex - 1) * 5) + 3;
            MakeEditForm(editIndex);
            UpdateDisplayList();

        }

        private void lnkEdit5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int editIndex = ((currentPageIndex - 1) * 5) + 4;
            MakeEditForm(editIndex);
            UpdateDisplayList();

        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            btnNext.Visible = false;
            btnBack.Visible = false;
            btnSearch.Enabled = false;

            LoadAll();
            LoadArchive();



        }

        private void CheckNextButtonVisible()
        {
            if (displayList.Count <= 5)
            {
                btnNext.Visible = false;

            }
            else
            {
                btnNext.Visible = true;
            }

            if (currentPageIndex == 1)
            {
                btnBack.Visible = false;
            }
        }

        private void CheckIfSearch()
        {
            if (radioLatest.Checked == true)
            {
                HideEditButton();
            }
            if (radioCharacter.Checked == true)
            {
                HideEditButton();
            }
            if (radioProject.Checked == true)
            {
                HideEditButton();
            }
            if (radioArchive.Checked == true)
            {
                HideEditButton();
            }
            if (txtSearch.Text != "")
            {
                HideEditButton();
            }
        }


        private void lnkItem1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int infoIndex = ((currentPageIndex - 1) * 5);
            infoForm infoForm = new infoForm(searchList[infoIndex], infoIndex);

            infoForm.ShowDialog();


        }

        private void lnkItem2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            int infoIndex = ((currentPageIndex - 1) * 5) + 1;
            infoForm infoForm = new infoForm(searchList[infoIndex], infoIndex);

            infoForm.ShowDialog();
        }

        private void lnkItem3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            int infoIndex = ((currentPageIndex - 1) * 5) + 2;
            infoForm infoForm = new infoForm(searchList[infoIndex], infoIndex);

            infoForm.ShowDialog();
        }

        private void lnkItem4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int infoIndex = ((currentPageIndex - 1) * 5) + 3;
            infoForm infoForm = new infoForm(searchList[infoIndex], infoIndex);

            infoForm.ShowDialog();
        }

        private void lnkItem5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int infoIndex = ((currentPageIndex - 1) * 5) + 4;
            infoForm infoForm = new infoForm(searchList[infoIndex], infoIndex);

            infoForm.ShowDialog();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DoSearch();
            HideEditButton();
            txtSearch.Text = "";
        }

        private void DoSearch()
        {
            if (radioLatest.Checked == true)
            {
                searchList = Search.OrderByDate();
                txtSearch.Enabled = false;
            }
            if (radioArchive.Checked == true)
            {
                searchList = Search.SearchArchive();
                txtSearch.Enabled = false;
            }
            else if (radioCharacter.Checked == true)
            {
                searchList = Search.SearchCharacter();
                txtSearch.Enabled = false;
            }
            else if (radioProject.Checked == true)
            {
                searchList = Search.SearchProject();
                txtSearch.Enabled = false;
            }

            else if (txtSearch.Text != "")
            {
                string keyword = txtSearch.Text;
                searchList = Search.SearchKeyWord(keyword);
            }
            currentPageIndex = 1;
            UpdateDisplayList();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearSearch();
            txtSearch.Enabled = true;
        }

        private void ClearSearch()
        {
            radioLatest.Checked = false;
            radioProject.Checked = false;
            radioCharacter.Checked = false;
            radioArchive.Checked = false;

            txtSearch.Text = "";

            Search.RestoreDefaultList();
            UpdateDisplayList();

        }

        private void radioLatest_CheckedChanged(object sender, EventArgs e)
        {
            if (radioLatest.Checked == true)
            {
                btnSearch.Enabled = true;
            }
            else
            {
                btnSearch.Enabled = false;
            }
        }

        private void radioCharacter_CheckedChanged(object sender, EventArgs e)
        {
            if (radioCharacter.Checked == true)
            {
                btnSearch.Enabled = true;
            }
            else
            {
                btnSearch.Enabled = false;
            }
        }

        private void radioProject_CheckedChanged(object sender, EventArgs e)
        {
            if (radioProject.Checked == true)
            {
                btnSearch.Enabled = true;
            }
            else
            {
                btnSearch.Enabled = false;
            }
        }

        private void radioArchive_CheckedChanged(object sender, EventArgs e)
        {
            if (radioArchive.Checked == true)
            {
                btnSearch.Enabled = true;
            }
            else
            {
                btnSearch.Enabled = false;
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if(txtSearch.Text != null)
            {
                btnSearch.Enabled = true;
            }
        }
    }
}
