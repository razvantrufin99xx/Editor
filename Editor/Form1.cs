using Microsoft.VisualBasic.ApplicationServices;
using static System.Collections.Specialized.BitVector32;
using static System.Windows.Forms.DataFormats;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Transactions;
using System.Windows.Forms;
using System;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;
using System.Reflection.Emit;

namespace Editor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public bool iswordwrapon = false;
        public Font f;
        public Color BackGroundColor = Color.White;
        public Color ForeGroundColor = Color.Black;
        public string filePath = "New File";

        public bool isEdited = false;


        public bool reload()
        {
            f = this.Font;
            setLabelSize();
            setLabelFamilyFontName();
            wordwrap();
            refresh();
            setLabelWordWrap();
            setLabelFileName();
            addStandardColorsThemes();
            return true;
        }
        public bool showsplashform()
        {
            splashform s = new splashform();
            s.Show();
            s.Focus();
            return true;
        }

        public bool setFormSizeMaximum()
        {
            WindowState = FormWindowState.Maximized;
            return true;
        }
        private void Form1_Load(object sender, EventArgs e)
        {

            reload();
            setFormSizeMaximum();

        }




        public bool wordwrap()
        {
            if (iswordwrapon == true) { iswordwrapon = false; textBox1.WordWrap = false; return false; }
            else { iswordwrapon = true; textBox1.WordWrap = true; return true; }
        }
        public bool refresh()
        {
            textBox1.Refresh();
            return true;
        }
        public bool setLabelWordWrap()
        {
            lblwordwrap.Text = "WrapWord: " + iswordwrapon.ToString();
            return true;
        }

        //wordwrap
        private void button15_Click(object sender, EventArgs e)
        {
            wordwrap();
            refresh();
            setLabelWordWrap();
        }
        public bool writeLoremIpsumText()
        {
            string s = "What is Lorem Ipsum ? Lorem Ipsum is simply dummy text of the printing and typesetting industry.Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.                Why do we use it ?           It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more - or - less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy.Various versions have evolved over the years, sometimes by accident, sometimes on purpose(injected humour and the like).                Where does it come from ?           Contrary to popular belief, Lorem Ipsum is not simply random text.It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old.Richard McClintock, a Latin professor at Hampden - Sydney College in Virginia, looked up one of the more obscure Latin words, consectetur, from a Lorem Ipsum passage, and going through the cites of the word in classical literature, discovered the undoubtable source.Lorem Ipsum comes from sections 1.10.32 and 1.10.33 of de Finibus Bonorum et Malorum(The Extremes of Good and Evil) by Cicero, written in 45 BC.This book is a treatise on the theory of ethics, very popular during the Renaissance.The first line of Lorem Ipsum, Lorem ipsum dolor sit amet.., comes from a line in section 1.10.32. The standard chunk of Lorem Ipsum used since the 1500s is reproduced below for those interested. Sections 1.10.32 and 1.10.33 from de Finibus Bonorum et Malorum by Cicero are also reproduced in their exact original form, accompanied by English versions from the 1914 translation by H.Rackham.            ";
            this.textBox1.Text += s;
            refresh();
            return true;
        }

        public bool setLabelSize()
        {

            lblSize.Text = "Size: " + f.Size.ToString();
            return true;
        }
        public bool setLabelFamilyFontName()
        {
            lblFont.Text = "FontFamilyName: " + f.Name.ToString();

            return true;
        }
        //changeFont
        public bool changeFont()
        {
            this.fontDialog1 = new FontDialog();
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                f = this.fontDialog1.Font;
                textBox1.Font = f;
            }
            setLabelSize();
            setLabelFamilyFontName();
            return true;
        }
        private void button14_Click(object sender, EventArgs e)
        {
            changeFont();
        }
        //insert lorem ipsum
        private void button19_Click(object sender, EventArgs e)
        {
            writeLoremIpsumText();
        }
        //select all
        public bool selectAll()
        {
            this.textBox1.Select(0, this.textBox1.Text.Length - 1);
            this.textBox1.Focus();
            return true;
        }
        private void button16_Click(object sender, EventArgs e)
        {
            selectAll();


        }
        //background 
        public bool setBackgroundColor(Color c)
        {

            this.BackGroundColor = c;
            textBox1.BackColor = BackGroundColor;

            return true;
        }
        public bool setBackgroundColor()
        {
            this.colorDialog1 = new ColorDialog();
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                this.BackGroundColor = this.colorDialog1.Color;
                textBox1.BackColor = BackGroundColor;
            }
            return true;
        }
        private void button18_Click(object sender, EventArgs e)
        {
            setBackgroundColor();
        }
        //text color foreground
        public bool setForegroundColor(Color c)
        {

            this.ForeGroundColor = c;
            textBox1.ForeColor = ForeGroundColor;

            return true;
        }
        public bool setForegroundColor()
        {
            this.colorDialog1 = new ColorDialog();
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                this.ForeGroundColor = this.colorDialog1.Color;
                textBox1.ForeColor = ForeGroundColor;
            }
            return true;
        }
        private void button17_Click(object sender, EventArgs e)
        {
            setForegroundColor();
        }


        //set time current
        public bool settimecurrent()
        {
            lblDateTime.Text = DateTime.Now.ToString();
            return true;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            settimecurrent();
        }
        //- sign size of font
        public bool decreaseFontSize()
        {
            textBox1.Font = new Font(textBox1.Font.FontFamily, f.Size - 1);
            f = textBox1.Font;
            setLabelSize();
            setLabelFamilyFontName();
            return true;
        }
        private void button13_Click(object sender, EventArgs e)
        {
            decreaseFontSize();


        }
        //+ sign size of font
        public bool increaseFontSize()
        {
            textBox1.Font = new Font(textBox1.Font.FontFamily, f.Size + 1);
            f = textBox1.Font;
            setLabelSize();
            setLabelFamilyFontName();

            return true;
        }
        private void button20_Click(object sender, EventArgs e)
        {
            increaseFontSize();
        }
        //+sign insert datetime 
        public bool insertdatetime()
        {
            textBox1.Text += DateTime.Now.ToString();
            return true;
        }
        private void button21_Click(object sender, EventArgs e)
        {
            insertdatetime();
        }
        //delete 
        public bool delete()
        {
            if (MessageBox.Show("Do you want to delete the current selection?", "Delete ?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                textBox1.SelectedText = "";

            return true;
        }
        private void button12_Click(object sender, EventArgs e)
        {
            delete();
        }
        //copy
        public bool copy()
        {
            if (textBox1.SelectionLength > 0)
            {
                textBox1.Copy();
            }
            return true;
        }
        private void button10_Click(object sender, EventArgs e)
        {
            copy();
        }
        //cut
        public bool cut()
        {
            if (textBox1.SelectedText.Length > 0)
            {
                textBox1.Cut();
            }
            return true;
        }
        private void button11_Click(object sender, EventArgs e)
        {
            cut();
        }

        //paste
        public bool paste()
        {
            if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text))
            {

                if (textBox1.SelectionLength > 0)
                {

                    if (MessageBox.Show("Do you want to paste over current selection?", "Cut Example", MessageBoxButtons.YesNo) == DialogResult.No)

                        textBox1.SelectionStart = textBox1.SelectionStart + textBox1.SelectionLength;
                }

                textBox1.Paste();
            }
            return true;
        }
        //paste
        private void button9_Click(object sender, EventArgs e)
        {
            paste();

        }
        public bool undo()
        {
            if (textBox1.CanUndo == true)
            {

                textBox1.Undo();

                textBox1.ClearUndo();
            }
            return true;
        }
        //undo
        private void button8_Click(object sender, EventArgs e)
        {
            undo();

        }

        //redo
        public bool redo()
        {
            if (textBox1.CanUndo == true)
            {

                textBox1.Undo();

                textBox1.ClearUndo();
            }
            return true;
        }
        //redo do not work
        private void button7_Click(object sender, EventArgs e)
        {
            redo();
        }
        //save
        public bool save()
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "*.txt|*.txt";
            dlg.RestoreDirectory = true;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(dlg.FileName, textBox1.Text);
            }
            return true;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            save();
        }

        public bool setLabelFileName()
        {
            this.lblFileName.Text = filePath;
            return true;
        }

        public bool setIsEdited()
        {
            this.isEdited = true;
            return true;
        }


        public bool open()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                //Get the path of specified file
                filePath = openFileDialog.FileName;

                //Read the contents of the file into a stream
                var fileStream = openFileDialog.OpenFile();

                using (StreamReader reader = new StreamReader(fileStream))
                {
                    textBox1.Text = reader.ReadToEnd();
                }
                setLabelFileName();
                setIsEdited();
            }
            return true;
        }
        //open
        private void button2_Click(object sender, EventArgs e)
        {

            open();


        }

        //new

        public bool newfile()
        {
            if (isEdited == true)
            {
                if (MessageBox.Show("Do you want to save before the current text?", "You may lose your datas. Save it before if you edited !", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    save();
                    textBox1.Text = "";

                }
                else
                {

                    textBox1.Text = "";
                    filePath = "New File";
                    setLabelFileName();
                }
            }
            else
            {
                textBox1.Text = "";
                filePath = "New File";
                setLabelFileName();
            }

            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            newfile();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            isEdited = true;
        }
        //about
        public bool openAbout()
        {
            AboutBox1 aboutBox = new AboutBox1();
            aboutBox.Show();
            return true;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            openAbout();
        }



        //help

        public bool openHelp()
        {
            HelpForm HelpBox = new HelpForm();
            HelpBox.Show();
            return true;
        }
        private void button5_Click(object sender, EventArgs e)
        {
            openHelp();
        }


        public bool formShown()
        {
            return true;
        }
        private void Form1_Shown(object sender, EventArgs e)
        {
            formShown();
            showsplashform();
        }



        //closing 

        public bool appclosing()
        {
            if (isEdited == true)
            {
                if (MessageBox.Show("Do you want to save before the current text before exit?", "You may lose your datas. Save it before if you edited !", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    save();
                    textBox1.Text = "";
                    return true;
                }
                else
                {
                    return false;

                }
            }
            else
            {
                return true;
            }

            //return true;
        }
        public void savebeforeexiterror(FormClosingEventArgs e)
        {
            if (appclosing() == true) { e.Cancel = true; }
            else
            {
                e.Cancel = false;
            }
        }
        public bool stopClosing(FormClosingEventArgs e)
        {

            var window = MessageBox.Show("Close the window?", "Are you sure?", MessageBoxButtons.YesNo);

            e.Cancel = (window == DialogResult.No);


            return true;
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            stopClosing(e);
            appclosing();
            //error
            //savebeforeexiterror(e);


        }




        //find
        public bool finded = false;
        public int positionOfFindedText = 0;
        public int countOfFindings = 0;
        public int lengthofsearchedtext = 0;
        public int carretposition = 0;
        public int previndexoftextsearched = 0;

        public List<int> positionsFounded = new List<int>();
        public bool addPosition(int thepos)
        {
            positionsFounded.Add(thepos);
            return true;
        }
        public bool searchIfWasFoundedBefore(int indexul)
        {
            bool gasit = false;
            for (int i = 0; i < positionsFounded.Count; i++)
            {
                if (positionsFounded[i] == indexul) gasit = true;
            }


            return gasit;
        }
        public bool findAllPositionsInText()
        {
            previndexoftextsearched++;
            for (int i = 0; i < this.textBox1.TextLength; i++)
            {
                int pos = 0;
                if (previndexoftextsearched != -1)
                {
                    pos = textBox1.Text.IndexOf(this.textBox2.Text, previndexoftextsearched);

                    previndexoftextsearched = pos;

                    addPosition(pos);
                    setFoundedTextLabel();
                }
                if (pos != -1)
                {
                    addPosition(pos);
                    textBox1.SelectionStart = pos;
                    textBox1.SelectionLength = this.textBox2.Text.Length;
                    lengthofsearchedtext = this.textBox2.Text.Length;

                    if (searchIfWasFoundedBefore(pos) == false)
                    {
                        countOfFindings++;
                    }

                    finded = true;
                    positionOfFindedText = pos;
                    // MessageBox("Error");
                    textBox1.ScrollToCaret();
                    textBox1.HideSelection = false;
                    setFoundedTextLabel();

                }




            }

            return true;
        }

        public bool setFoundedTextLabel()
        {
            lblfindedtext.Text = this.finded.ToString() + " : " + this.positionOfFindedText.ToString() + " : " + this.countOfFindings.ToString() + " : " + this.lengthofsearchedtext.ToString();
            return true;
        }

        //its not working good yet
        public bool searchATextInside()
        {
            if (textBox1.Text.Length == 0) { return true; }
            int pos = textBox1.Text.IndexOf(this.textBox2.Text, previndexoftextsearched + 1);
            previndexoftextsearched = pos;
            addPosition(pos);
            //this line find the first occurance of the text and must be modified to find all indexes of text searched and search from a position to end or to beggining

            if (pos != -1)
            {
                addPosition(pos);
                textBox1.SelectionStart = pos;
                textBox1.SelectionLength = this.textBox2.Text.Length;
                lengthofsearchedtext = this.textBox2.Text.Length;

                if (searchIfWasFoundedBefore(pos) == false)
                {
                    countOfFindings++;
                }

                finded = true;
                positionOfFindedText = pos;
                // MessageBox("Error");
                textBox1.ScrollToCaret();
                textBox1.HideSelection = false;
                setFoundedTextLabel();

            }
            return true;
        }
        public bool startNewSearch()
        {

            //clear all and reset
            this.positionsFounded.Clear();
            this.finded = false;
            this.positionOfFindedText = 0;
            this.countOfFindings = 0;
            this.lengthofsearchedtext = 0;
            this.carretposition = 0;
            this.previndexoftextsearched = 0;

            return true;

        }

        public bool addARecord()
        {
            if (this.positionsFounded.Count == 0)
            {
                addPosition(0);
            }
            return true;
        }
        private void button6_Click(object sender, EventArgs e)
        {

            startNewSearch();

            addARecord();

            findAllPositionsInText();

        }

        private void button22_Click(object sender, EventArgs e)
        {
            findAllPositionsInText();
        }

        private void button23_Click(object sender, EventArgs e)
        {
            startNewSearch();
            searchATextInside();
        }



        //resize operations
        public int pointx = 0;

        public bool setPointsX(int x)
        {
            pointx = x;
            return true;
        }

        public int pointy = 0;

        public bool setPointsY(int y)
        {
            pointy = y;
            return true;
        }

        public bool resizeTheWindowUp()
        {
            int w = textBox1.Width;
            int h = textBox1.Height;


            int difw = pointx - textBox1.Left;
            int difh = pointy - textBox1.Top;



            this.textBox1.Width = difw;
            this.textBox1.Height = difh;


            w = textBox1.Width;
            h = textBox1.Height;

            repositionAllLowerControls();

            return true;
        }

        public bool repositionAllLowerControls()
        {

            label1.Top = corner1.Top + 10;
            label2.Top = corner1.Top + 10 + 15;
            label3.Top = corner1.Top + 10 + 30;


            lblFont.Top = corner1.Top + 10;
            lblSize.Top = corner1.Top + 10 + 15;
            lblwordwrap.Top = corner1.Top + 10 + 30;

            button13.Top = corner1.Top + 10 + 15;
            button20.Top = corner1.Top + 10 + 15;

            label4.Top = corner1.Top + 10 + 15;
            label10.Top = corner1.Top + 10 + 30;

            lblFileName.Top = corner1.Top + 10 + 15;

            label7.Top = corner1.Top + 10;
            lblfindedtext.Top = corner1.Top + 10 + 15;

            button21.Top = corner1.Top + 10;
            lblDateTime.Top = corner1.Top + 10;


            return true;
        }
        private void Form1_SizeChanged(object sender, EventArgs e)
        {

        }

        private void button24_Click(object sender, EventArgs e)
        {
            showsplashform();
        }


        //text operations


        //count spaces
        public int countSpaces()
        {
            int c = 0;

            for (int i = 0; i < textBox1.Text.Length; i++)
            {
                if (textBox1.Text[i] == ' ') { c++; }
            }

            return c;
        }

        public bool setLabellblCountSpaces()
        {
            this.lblcounterofspaces.Text = countSpaces().ToString();
            return true;
        }
        private void button25_Click(object sender, EventArgs e)
        {
            setLabellblCountSpaces();
        }


        //new lines

        public int countNewLineChars()
        {
            int nl = 0;
            string x = "\r\n"; //size is 2
            int l = x.Length;

            for (int i = 0; i < textBox1.Text.Length - l; i++)
            {
                if (textBox1.Text.Substring(i, l) == x)
                {
                    nl++;
                }
            }
            return nl;

        }
        public bool setLabellblNewLineChars()
        {
            this.lblNewLineChars.Text = countNewLineChars().ToString();
            return true;
        }
        private void button26_Click(object sender, EventArgs e)
        {
            setLabellblNewLineChars();
        }


        //all chars

        public int countAllchars()
        {

            return textBox1.Text.Length;

        }
        public bool setLabellblAllChars()
        {
            this.lblAllChars.Text = countAllchars().ToString();
            return true;
        }

        private void button27_Click(object sender, EventArgs e)
        {
            setLabellblAllChars();
        }



        //alL DIGITS

        public int countAllDIGITS()
        {

            int digitscounter = 0;
            string x = "0123456789";


            for (int i = 0; i < textBox1.Text.Length; i++)
            {
                if (textBox1.Text.Substring(i, 1) == x.Substring(1, 1))
                {
                    digitscounter++;
                }
                if (textBox1.Text.Substring(i, 1) == x.Substring(2, 1))
                {
                    digitscounter++;
                }
                if (textBox1.Text.Substring(i, 1) == x.Substring(3, 1))
                {
                    digitscounter++;
                }
                if (textBox1.Text.Substring(i, 1) == x.Substring(4, 1))
                {
                    digitscounter++;
                }
                if (textBox1.Text.Substring(i, 1) == x.Substring(5, 1))
                {
                    digitscounter++;
                }
                if (textBox1.Text.Substring(i, 1) == x.Substring(6, 1))
                {
                    digitscounter++;
                }
                if (textBox1.Text.Substring(i, 1) == x.Substring(7, 1))
                {
                    digitscounter++;
                }
                if (textBox1.Text.Substring(i, 1) == x.Substring(8, 1))
                {
                    digitscounter++;
                }
                if (textBox1.Text.Substring(i, 1) == x.Substring(9, 1))
                {
                    digitscounter++;
                }
                if (textBox1.Text.Substring(i, 1) == x.Substring(0, 1))
                {
                    digitscounter++;
                }

            }
            return digitscounter;

        }
        public bool setLabellblAllDigits()
        {
            this.lblAlldigits.Text = countAllDIGITS().ToString();


            return true;
        }

        private void button29_Click(object sender, EventArgs e)
        {
            setLabellblAllDigits();
        }



        //statistics

        public string allthecharacters = "0123456789abcdefghijklmnopqrstuvxzwyABCDEFGHIJKLMNOPQRSTUVXZWY";

        public List<pairs> allsimbolsused = new List<pairs>();
        public bool clearAllsimbolsusedlist()
        {
            allsimbolsused.Clear();
            return true;
        }
        public class pairs
        {
            public string c = "";
            public int counter = 0;

            public pairs(string pc, int pcount)
            {
                this.c = pc;
                this.counter = pcount;
            }
        }


        public int findASimbolInList(string s)
        {
            for (int i = 0; i < allsimbolsused.Count; i++)
            {
                if (allsimbolsused[i].c == s) { return i; }

            }

            return -1;
        }


        public bool findAllSimbols()
        {
            int x = -1;

            if (allsimbolsused.Count <= 0) { return false; }
            for (int i = 0; i < textBox1.Text.Length; i++)
            {
                x = findASimbolInList(textBox1.Text.Substring(i, 1));
                if (x != -1)
                {

                    allsimbolsused[x].counter++;
                    try
                    { }
                    catch { }
                }
            }

            return true;
        }

        public bool addAllSimbolsUsed()
        {
            int x = -1;
            for (int i = 0; i < textBox1.Text.Length; i++)
            {
                x = findASimbolInList(textBox1.Text.Substring(i, 1));
                if (x == -1)
                {
                    allsimbolsused.Add(new pairs(textBox1.Text.Substring(i, 1), 0));
                }

            }
            return true;
        }

        public bool printListOfAllSimbols(ref System.Windows.Forms.TextBox t)
        {
            for (int i = 0; i < allsimbolsused.Count; i++)
            {
                t.Text += allsimbolsused[i].c + " : " + allsimbolsused[i].counter.ToString() + " \r\n";

            }

            return true;
        }


        public bool makeStatistics()
        {
            clearAllsimbolsusedlist();
            addAllSimbolsUsed();
            findAllSimbols();
            printListOfAllSimbols(ref textBox3);
            textBox2.Visible = true;
            return true;
        }



        private void button30_Click(object sender, EventArgs e)
        {
            clearTextBoxContent(ref this.textBox3);

            makeStatistics();
            textBox2.Focus();
        }


        //positionsofspaces
        public List<int> spacespositions = new List<int>();
        public bool clearSpacePositions()
        {
            spacespositions.Clear();
            return true;
        }
        public bool findPositionsOfAllSpaces()
        {


            for (int i = 0; i < textBox1.Text.Length; i++)
            {
                if (textBox1.Text[i] == ' ' ||  textBox1.Text[i] == ',' || textBox1.Text[i] == '.') { spacespositions.Add(i); }
            }

            return true;
        }

        public List<pairstringint> wordslist = new List<pairstringint>();

        //searchifwordexist

        public bool findAWordInWordList(string s)
        {
            for (int i = 0; i < wordslist.Count; i++)
            {
                if (wordslist[i].c == s) { return true; }

            }

            return false;
        }

        //find all words between 2 spaces
        public bool findAllWordsBetween2Spaces()
        {


            for (int i = 0; i < spacespositions.Count; i++)
            {
                try
                {
                    string s = textBox1.Text.Substring(spacespositions[i], spacespositions[i + 1] - spacespositions[i]);


                    if (findAWordInWordList(s) != true)
                    {
                        wordslist.Add(new pairstringint(s, 1));
                    }
                }
                catch { }
            }

            return true;
        }

        //print wordlist to textbox
        public bool printWordList(ref System.Windows.Forms.TextBox t)
        {
            for (int i = 0; i < wordslist.Count; i++)
            {

                t.Text += wordslist[i].c + " : " + wordslist[i].counter.ToString() + "\r\n";
            }

            return true;
        }

        public bool clearWordList()
        {
            this.wordslist.Clear();
            return true;
        }


        public int findAWordInList(string s)
        {
            for (int i = 0; i < wordslist.Count; i++)
            {
                if (wordslist[i].c == s) { return i; }

            }

            return -1;
        }



        public string findAllWordsBetween2Spaces(ref System.Windows.Forms.TextBox t, int start)
        {
            string s = "";

            try
            {
                s = t.Text.Substring(spacespositions[start], spacespositions[start + 1] - spacespositions[start]);
            }
            catch { }
            return s;
        }


        public string nextWordInATextBox(ref System.Windows.Forms.TextBox t, int x)
        {
            string s = "";

            s = findAllWordsBetween2Spaces(ref t, x);

            //debug
            string d = "DEBUG MODE IS OFF";

            if (d == "DEBUG MODE IS ON")
            {
                this.textBox5.Text += s + " :" + x.ToString() + "\r\n";

            }

            //end debug

            return s;
        }




        public bool findAllWords()
        {
            int x = -1;
            int y = 0;

            if (wordslist.Count <= 0) { return false; }
            for (int i = 0; i < textBox1.Text.Length; i += y)
            {
                x = findAWordInList(nextWordInATextBox(ref this.textBox1, i));
                if (x != -1)
                {

                    wordslist[x].counter++;
                    try
                    {
                        y = (spacespositions[i + 1] - spacespositions[i]);
                    }
                    catch { }
                }
            }

            return true;
        }

        public class pairstringint
        {
            public string c = "";
            public int counter = 0;

            public pairstringint(string pc, int pcount)
            {
                this.c = pc;
                this.counter = pcount;
            }
        }

        private void button31_Click(object sender, EventArgs e)
        {
            clearTextBoxContent(ref this.textBox4);
            clearWordList();
            clearSpacePositions();
            findPositionsOfAllSpaces();
            findAllWordsBetween2Spaces();
            findAllWords();
            printWordList(ref this.textBox4);
            setLabellblWordsCounter();
        }

       
        public bool setLabellblWordsCounter()
        {
            this.lblWordsCounter.Text = wordslist.Count.ToString();


            return true;
        }



        //positionsofNewLines
        public List<int> newlinepositions = new List<int>();

        public bool findNewLinePositions()
        {

            string x = "\r\n"; //size is 2
            int l = x.Length;

            for (int i = 0; i < textBox1.Text.Length - l; i++)
            {
                if (textBox1.Text.Substring(i, l) == x)
                {
                    newlinepositions.Add(i);
                }
            }
            return true;

        }


        public bool changeVisibilityOfATextBox(ref System.Windows.Forms.TextBox t)
        {

            if (t.Visible == true) { t.Visible = false; return false; }
            else { t.Visible = true; return true; }
            return true;

        }
        private void button32_Click(object sender, EventArgs e)
        {
            changeVisibilityOfATextBox(ref this.textBox3);
        }

        private void button33_Click(object sender, EventArgs e)
        {
            changeVisibilityOfATextBox(ref this.textBox4);
        }

        public bool clearTextBoxContent(ref System.Windows.Forms.TextBox t)
        {

            t.Text = "";
            return true;
        }

        //theme






        public class themes
        {
            public List<Color> themeColors = new List<Color>();
            public themes(List<Color> clist)
            {
                themeColors.Add(clist[0]);
                themeColors.Add(clist[1]);
                themeColors.Add(clist[2]);
                themeColors.Add(clist[3]);

            }
        }

        public List<themes> thelistofthemes = new List<themes>();

        public bool addNewtheme(Color bkfrm, Color ffrm, Color bktxt, Color ftxt)
        {
            List<Color> x = new List<Color>();
            x.Add(bkfrm);
            x.Add(ffrm);
            x.Add(bktxt);
            x.Add(ftxt);

            thelistofthemes.Add(new themes(x));


            return true;
        }
        public bool addStandardColorsThemes()
        {

            //white and red
            addNewtheme(Color.Red, Color.White, Color.Red, Color.White);
            addNewtheme(Color.Red, Color.Black, Color.Red, Color.Black);
            addNewtheme(Color.Black, Color.White, Color.Black, Color.White);
            addNewtheme(Color.Black, Color.Red, Color.Black, Color.Red);
            addNewtheme(Color.DarkBlue, Color.White, Color.DarkBlue, Color.White);
            addNewtheme(Color.DarkBlue, Color.Yellow, Color.DarkBlue, Color.Yellow);




            return true;
        }

        public int currentTheme = 0;
        public int lastthemeindex = 9;
        public Color defback = Control.DefaultBackColor;
        public Color defore = Color.Black;

        public Color prevback = Control.DefaultBackColor;
        public Color prevfore = Color.Black;

        public bool setPrevBackColor(Color pbc)
        {
            this.prevback = pbc;
            return true;
        }
        public bool setPrevForeColor(Color pfc)
        {
            this.prevfore = pfc;
            return true;
        }

        public bool setBackGroundColorOfForm(Color pcolor)
        {
            this.BackColor = pcolor;
            return true;
        }

        public bool setForeGroundColorOfFormText(Color pcolor)
        {
            this.ForeColor = pcolor;
            return true;
        }

        public bool setBackGroundColorOfText(Color pcolor)
        {
            this.textBox1.BackColor = pcolor;
            return true;
        }

        public bool setForeGroundColorOfText(Color pcolor)
        {
            this.textBox1.ForeColor = pcolor;
            return true;
        }


        public bool setTheTheme(Color back, Color fore)
        {
            setPrevBackColor(this.BackColor);
            setPrevForeColor(this.ForeColor);

            setBackGroundColorOfForm(back);
            setForeGroundColorOfFormText(fore);

            return true;
        }
        public bool setTheTheme()
        {
            if (currentTheme == 0)
            {
                setTheTheme(Color.DarkBlue, Color.White);
                currentTheme++;
                return true;

            }
            else if (currentTheme == 1)
            {
                setTheTheme(Color.White, Color.Black);
                currentTheme++;
                return true;

            }
            else if (currentTheme == 2)
            {
                setTheTheme(Color.Black, Color.White);
                currentTheme++;
                return true;

            }
            else if (currentTheme == 3)
            {
                setTheTheme(thelistofthemes[0].themeColors[0], thelistofthemes[0].themeColors[1]);

                currentTheme++;
                return true;

            }
            else if (currentTheme == 4)
            {
                setTheTheme(thelistofthemes[1].themeColors[0], thelistofthemes[1].themeColors[1]);
                setBackgroundColor(thelistofthemes[1].themeColors[2]);
                setForegroundColor(thelistofthemes[1].themeColors[3]);
                currentTheme++;
                return true;

            }
            else if (currentTheme == 5)
            {
                setTheTheme(thelistofthemes[2].themeColors[0], thelistofthemes[2].themeColors[1]);
                setBackgroundColor(thelistofthemes[2].themeColors[2]);
                setForegroundColor(thelistofthemes[2].themeColors[3]);
                currentTheme++;
                return true;

            }
            else if (currentTheme == 6)
            {
                setTheTheme(thelistofthemes[3].themeColors[0], thelistofthemes[3].themeColors[1]);
                setBackgroundColor(thelistofthemes[3].themeColors[2]);
                setForegroundColor(thelistofthemes[3].themeColors[3]);
                currentTheme++;
                return true;

            }
            else if (currentTheme == 7)
            {
                setTheTheme(thelistofthemes[4].themeColors[0], thelistofthemes[4].themeColors[1]);
                setBackgroundColor(thelistofthemes[4].themeColors[2]);
                setForegroundColor(thelistofthemes[4].themeColors[3]);
                currentTheme++;
                return true;

            }
            else if (currentTheme == 8)
            {
                setTheTheme(thelistofthemes[5].themeColors[0], thelistofthemes[5].themeColors[1]);
                setBackgroundColor(thelistofthemes[5].themeColors[2]);
                setForegroundColor(thelistofthemes[5].themeColors[3]);
                currentTheme++;
                return true;

            }
            if (currentTheme == lastthemeindex)
            {
                currentTheme = 0;
                setTheTheme(this.defback, this.defore);
                currentTheme++;
                return true;
            }

            return true;
        }

        public bool setTheThemeFromStandardThemesUsingIndexOfIt(int indexoftheme)
        {
            setTheTheme(thelistofthemes[indexoftheme].themeColors[0], thelistofthemes[indexoftheme].themeColors[1]);
            setBackgroundColor(thelistofthemes[indexoftheme].themeColors[2]);
            setForegroundColor(thelistofthemes[indexoftheme].themeColors[3]);
            currentTheme++;
            return true;

        }
        private void button28_Click(object sender, EventArgs e)
        {
            setTheTheme();
        }


        //list of operations for textbox1
        public class element
        {
            public string val;
            public int positionx;
            public int positiony;
            public string info;
            public element(string pval, int pposx, int pposy, string pi)
            {
                this.val = pval;
                this.positionx = pposx;
                this.positiony = pposy;
                this.info = pi;
            }

        }

        public List<element> elements = new List<element>();

        public bool addElement(element e)
        {
            elements.Add(e);
            return true;
        }










        //



    }
}