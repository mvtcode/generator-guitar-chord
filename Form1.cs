using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;

namespace GenChord
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void BT_OpenList_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "XML File|*.xml|All File|*.*";
            openFile.Multiselect = true;
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = "";
                foreach (string fileName in openFile.FileNames)
                {
                    List_Input.Items.Add(fileName);
                }
            }
        }

        private void BT_Save_Click(object sender, EventArgs e)
        {
            if (List_Input.Items.Count > 0)
            {
                FolderBrowserDialog fbd = new FolderBrowserDialog();
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    readFile(fbd.SelectedPath);
                }
            }
        }

        private string readFile(string folder)
        {
            for (int i = 0; i < List_Input.Items.Count; i++)
            {
                List_Input.SelectedIndex = i;

                var sFile = List_Input.Items[i];
                if (sFile != null)
                {
                    StreamReader reader = new StreamReader(sFile.ToString());
                    string s = reader.ReadToEnd();
                    reader.Close();
                    reader.Dispose();

                    var obj = ReadData(s);
                    if (obj != null)
                    {
                        string sJson = "";
                        try
                        {
                            if (obj.Apps.Count > 1)
                            {
                                for (int j = 0; j < obj.Apps.Count; j++)
                                {
                                    if (sJson != "") sJson += ",";
                                    string sFileSave = obj.name + "." + (j + 1);
                                    string xS = GenChord(sFileSave, obj.Apps[j]);
                                    writeFile(folder + "\\" + obj.name.Replace('/', '.').Replace("#", ".sharp") + "." +
                                        (j + 1) + ".svg", xS);
                                    sJson += "";

                                }
                            }
                            else
                            {
                                if (sJson != "") sJson += ",";
                                string xS = GenChord(obj.name, obj.Apps[0]);
                                writeFile(folder + "\\" + obj.name.Replace('/', '.').Replace("#", ".sharp") + ".svg", xS);
                                sJson += "";
                            }
                        }
                        catch (Exception e)
                        {
                        }
                        finally
                        {
                            
                        }
                    }
                }
            }
            return "";
        }

        private static void writeFile(string sFile,string sContent)
        {
            StreamWriter writer = new StreamWriter(sFile,false);
            writer.Write(sContent);
            writer.Close();
            writer.Dispose();
        }

        public static string GenChord(string name, app oApp)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<svg width=\"460\" height=\"480\" xmlns=\"http://www.w3.org/2000/svg\">");
            sb.AppendFormat("<g><title>Chord {0}</title>", name);

            if (oApp.ListS[5] == -1)
                sb.AppendFormat("<line stroke=\"#999999\" stroke-width=\"15\" x1=\"0\" y1=\"50\" x2=\"460\" y2=\"50\" />");
            else
                sb.AppendFormat("<line stroke=\"#dddddd\" stroke-width=\"10\" x1=\"0\" y1=\"50\" x2=\"460\" y2=\"50\" />");

            for (int i = 4; i >= 0; i--)
            {
                if (oApp.ListS[4-i] == -1)
                    sb.AppendFormat("<line stroke=\"#999999\" stroke-width=\"15\" x1=\"0\" y1=\"{0}\" x2=\"460\" y2=\"{0}\" />", 50 + (i + 1) * 60);
                else
                    sb.AppendFormat("<line stroke=\"#dddddd\" stroke-width=\"10\" x1=\"0\" y1=\"{0}\" x2=\"460\" y2=\"{0}\" />", 50 + (i + 1) * 60);
            }

            sb.Append("<line stroke=\"#888888\" fill=\"none\" stroke-width=\"4\" x1=\"30\" y1=\"0\" x2=\"30\" y2=\"390\"/>");
            for (int i = 5; i >= 0; i--)
                sb.AppendFormat("<line stroke=\"#888888\" fill=\"none\" stroke-width=\"4\" x1=\"{0}\" y1=\"0\" x2=\"{0}\" y2=\"390\"/>", 30 + i * 80);
            //
            for (int i = 0; i < 4; i++)
            {
                if (oApp.Listf[i].str != 0 && oApp.Listf[i].pos != 0)
                {
                    int cx = 70 + (5 - oApp.Listf[i].pos) * 80;
                    int cy = 50 + (6 - oApp.Listf[i].str) * 60;
                    sb.AppendFormat("<circle fill=\"#0000ff\" stroke-width=\"4\" cx=\"{0}\" cy=\"{1}\" r=\"30\" stroke=\"#ffffff\"/>", cx, cy);
                    sb.AppendFormat("<text x=\"{0}\" y=\"{1}\" fill=\"#ffffff\" font-size=\"40\" font-family=\"Sans-serif\" text-anchor=\"middle\" font-weight=\"bold\">{2}</text>", cx, cy + 15, i + 1);

                    if (oApp.Listf[i].length > 1)
                    {
                        sb.AppendFormat("<rect fill=\"#0000ff\" stroke-width=\"0\" x=\"{0}\" y=\"{1}\" width=\"35\" height=\"{2}\" />", cx - 17, cy + 40, oApp.Listf[i].length * 60 - 40 - 30);//390 - ((oApp.Listf[i].length-1)*60)
                    }
                }
            }
            //

            sb.AppendFormat("<text fill=\"#ff0000\" x=\"261.80005\" y=\"447.66667\" font-size=\"24\" font-family=\"Sans-serif\" text-anchor=\"middle\" xml:space=\"preserve\" transform=\"matrix(3.33334 0 0 3 -638.238 -882)\" font-weight=\"bold\">{0}</text>", name);
            sb.Append("</g></svg>");
            return sb.ToString();
        }

        public static ChordInfo ReadData(string sXML)
        {
            try
            {
                ChordInfo info = new ChordInfo();
                XmlDocument xDoc = new XmlDocument();
                XmlReader reader = XmlReader.Create(new StringReader(sXML));
                xDoc.Load(reader);

                XmlNodeList oID = xDoc.GetElementsByTagName("ID");
                string sRead = oID[0].InnerText;
                info.id = sRead;

                XmlNodeList oName = xDoc.GetElementsByTagName("Name");
                sRead = oName[0].InnerText;
                info.name = sRead;

                List<app> oList = new List<app>();
                XmlNodeList oApps = xDoc.GetElementsByTagName("App");
                for (int i = 0; i < oApps.Count; i++)
                {
                    app item = new app();

                    item.Fret = oApps.Item(i).ChildNodes[0].InnerText;


                    List<Finger> oListF = new List<Finger>();
                    for (int j = 2; j <= 5; j++)
                    {
                        Finger of = new Finger();
                        var of1 = oApps.Item(i).ChildNodes[j];
                        of.str = int.Parse(of1.ChildNodes[0].InnerText);
                        of.pos = int.Parse(of1.ChildNodes[1].InnerText);
                        of.length = int.Parse(of1.ChildNodes[2].InnerText);
                        oListF.Add(of);
                    }
                    item.Listf = oListF;

                    List<int> oListS = new List<int>();
                    for (int j = 6; j <= 11; j++)
                    {
                        oListS.Add(int.Parse(oApps.Item(i).ChildNodes[j].InnerText));
                    }
                    item.ListS = oListS;

                    oList.Add(item);
                }

                info.Apps = oList;
                return info;
            }
            catch (Exception e)
            {
                MessageBox.Show("Error format file Chord file", "Error", MessageBoxButtons.OK);
                return null;
            }
        }

        private void List_Input_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = "";

            var sFile = List_Input.SelectedItem;
            if (sFile != null)
            {
                StreamReader reader = new StreamReader(sFile.ToString());
                string s = reader.ReadToEnd();
                textBox1.Text = s;
                reader.Close();
                reader.Dispose();
            }
        }

        private void BT_Clear_Click(object sender, EventArgs e)
        {
            List_Input.Items.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var i = List_Input.SelectedIndex;
            if (i != null && i >= 0) List_Input.Items.RemoveAt(i);
        }
    }
}
