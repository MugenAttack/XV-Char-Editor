using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Msgfile;
namespace CharEditor
{
    struct Zsoul
    {
        public int id;
        public string name;
    }

    public partial class Form1 : Form
    {
        string msgFolder;
        string sysFolder;
        string lang;
        msg Chartxt;
        CMS cmsfile = new CMS();
        PSC pFile = new PSC();
        CharSkill CS = new CharSkill();
        CSO csoFile = new CSO();
        int[] CostumeIndex = {0, 0};
        Zsoul[] ZS;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //check if settings file exists, if not open settings form so it can be updated
            if (!File.Exists("CharEditor_Settings.csv"))
            {
                SettingForm SF = new SettingForm();
                SF.Show();
            }
            else
            {
                //load settings file
                StreamReader sr = new StreamReader(File.Open("CharEditor_Settings.csv", FileMode.Open));
                string line = sr.ReadLine();
                string[] s = line.Split(",".ToCharArray());
                msgFolder = s[1];
                line = sr.ReadLine();
                s = line.Split(",".ToCharArray());
                sysFolder = s[1];
                line = sr.ReadLine();
                s = line.Split(",".ToCharArray());
                lang = s[1];

                cmsfile.Load(sysFolder + "/char_model_spec.cms");
                Chartxt = msgStream.Load(msgFolder + "/proper_noun_character_name_" + lang + ".msg");
                //populate character list
                foreach (CMS_Data cd in cmsfile.Data)
                {
                    string name = Chartxt.Find("chara_" + cd.ShortName + "_000");
                    if (name == "No Matching ID")
                        cbCharacter.Items.Add("Unknown Character");
                    else
                        cbCharacter.Items.Add(name);
                }

                pFile.load(sysFolder + "/parameter_spec_char.psc");

                foreach (string str in pFile.ValNames)
                {
                    var Item = new ListViewItem(new[] { str, "0" });
                    lstPSC.Items.Add(Item);
                }
                CS.populateSkillData(msgFolder, sysFolder + "/custom_skill.cus", lang);

                //populate skill lists
                foreach (skill sk in CS.Supers)
                {
                    cbSuper1.Items.Add(sk.Name);
                    cbSuper2.Items.Add(sk.Name);
                    cbSuper3.Items.Add(sk.Name);
                    cbSuper4.Items.Add(sk.Name);
                }

                foreach (skill sk in CS.Ultimates)
                {
                    cbUlt1.Items.Add(sk.Name);
                    cbUlt2.Items.Add(sk.Name);
                }

                foreach (skill sk in CS.Evasives)
                    cbEva.Items.Add(sk.Name);


                csoFile.Load(sysFolder + "/chara_sound.cso");

                LoadZsoul();

            }


        }

        public void LoadZsoul()
        {
            msg Zmsg = msgStream.Load(msgFolder + "/proper_noun_talisman_name_" + lang + ".msg");

            using (BinaryReader br = new BinaryReader(File.Open(sysFolder + "/item/talisman_item.idb", FileMode.Open)))
            {

                br.BaseStream.Seek(8, SeekOrigin.Begin);
                int count = br.ReadInt32();
                ZS = new Zsoul[count];
                //640
                for (int i = 0; i < count; i++)
                {
                    br.BaseStream.Seek((i * 640) + 16, SeekOrigin.Begin);
                    ZS[i].id = br.ReadInt16();
                    br.BaseStream.Seek(2, SeekOrigin.Current);
                    ZS[i].name = Zmsg.Find(br.ReadInt16());
                }

                foreach (Zsoul z in ZS)
                    cbZSoul.Items.Add(z.name);

            }


        }

        public int FindZIndex(int id)
        {
            for (int i = 0; i < ZS.Length; i++)
            {
                if (ZS[i].id == id)
                    return i;
            }
            return -1;
        }
        private void cbCharacter_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            txtCMS1.Text = cmsfile.Data[cbCharacter.SelectedIndex].Paths[0];
            txtCMS2.Text = cmsfile.Data[cbCharacter.SelectedIndex].Paths[1];
            txtCMS3.Text = cmsfile.Data[cbCharacter.SelectedIndex].Paths[2];
            txtCMS4.Text = cmsfile.Data[cbCharacter.SelectedIndex].Paths[3];
            txtCMS5.Text = cmsfile.Data[cbCharacter.SelectedIndex].Paths[4];
            txtCMS6.Text = cmsfile.Data[cbCharacter.SelectedIndex].Paths[5];
            txtCMS7.Text = cmsfile.Data[cbCharacter.SelectedIndex].Paths[6];

            int index = pFile.FindCharacterIndex(cmsfile.Data[cbCharacter.SelectedIndex].ID);
            
            cbCostumes.Items.Clear();
            for(int i = 0; i < pFile.CharParam[index].p.Length; i++)
            {
                string name = Chartxt.Find("chara_" + cmsfile.Data[cbCharacter.SelectedIndex].ShortName + "_" + i.ToString("000"));
                if (name != "No Matching ID")
                    cbCostumes.Items.Add(i.ToString() + ". " + name);
                else
                {
                    name = Chartxt.Find("chara_" + cmsfile.Data[cbCharacter.SelectedIndex].ShortName + "_000");
                    cbCostumes.Items.Add(i.ToString() + ". " + name);
                }
            }

            index = csoFile.DataExist(cmsfile.Data[cbCharacter.SelectedIndex].ID, cbCostumes.SelectedIndex);
            CostumeIndex[1] = index;
            if (index > -1)
            {
                CSO_Data cd;
                cd = csoFile.Data[index];
                txtCSO1.Text = cd.Paths[0];
                txtCSO1.Text = cd.Paths[1];
                txtCSO1.Text = cd.Paths[2];
                txtCSO1.Text = cd.Paths[3];
            }

            cbCostumes.SelectedIndex = 0;
        }

        private void cbCostumes_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = csoFile.DataExist(cmsfile.Data[cbCharacter.SelectedIndex].ID, cbCostumes.SelectedIndex);
            CostumeIndex[1] = index;
            if (index > -1)
            {
                CSO_Data cd;
                cd = csoFile.Data[index];
                txtCSO1.Text = cd.Paths[0];
                txtCSO2.Text = cd.Paths[1];
                txtCSO3.Text = cd.Paths[2];
                txtCSO4.Text = cd.Paths[3];
            }

            index = CS.DataExist(cmsfile.Data[cbCharacter.SelectedIndex].ID, cbCostumes.SelectedIndex);
            CostumeIndex[0] = index;
            if (index > -1)
            {
                Char_Data cd = CS.Chars[index];
                cbSuper1.SelectedIndex = CS.FindSuper(cd.SuperIDs[0]);
                cbSuper2.SelectedIndex = CS.FindSuper(cd.SuperIDs[1]);
                cbSuper3.SelectedIndex = CS.FindSuper(cd.SuperIDs[2]);
                cbSuper4.SelectedIndex = CS.FindSuper(cd.SuperIDs[3]);

                cbUlt1.SelectedIndex = CS.FindUltimate(cd.UltimateIDs[0]);
                cbUlt2.SelectedIndex = CS.FindUltimate(cd.UltimateIDs[1]);

                cbEva.SelectedIndex = CS.FindEvasive(cd.EvasiveID);

            }

            index = pFile.FindCharacterIndex(cmsfile.Data[cbCharacter.SelectedIndex].ID);
            
            if (index > -1)
            {
                for (int i = 0; i < pFile.type.Length; i++)
                {
                    lstPSC.Items[i].SubItems[1].Text = pFile.getVal(index, cbCostumes.SelectedIndex, i);

                }
            }
            else
            {
                for (int i = 0; i < pFile.type.Length; i++)
                {
                    lstPSC.Items[i].SubItems[1].Text = "0";

                }
            }

            cbZSoul.SelectedIndex = FindZIndex(int.Parse(lstPSC.Items[42].SubItems[1].Text));
        }
        #region cms_text
        private void txtCMS1_TextChanged(object sender, EventArgs e)
        {
            cmsfile.Data[cbCharacter.SelectedIndex].Paths[0] = txtCMS1.Text;
        }

        private void txtCMS2_TextChanged(object sender, EventArgs e)
        {
            cmsfile.Data[cbCharacter.SelectedIndex].Paths[1] = txtCMS2.Text;
        }

        private void txtCMS3_TextChanged(object sender, EventArgs e)
        {
            cmsfile.Data[cbCharacter.SelectedIndex].Paths[2] = txtCMS3.Text;
        }

        private void txtCMS4_TextChanged(object sender, EventArgs e)
        {
            cmsfile.Data[cbCharacter.SelectedIndex].Paths[3] = txtCMS4.Text;
        }

        private void txtCMS5_TextChanged(object sender, EventArgs e)
        {
            cmsfile.Data[cbCharacter.SelectedIndex].Paths[4] = txtCMS5.Text;
        }

        private void txtCMS6_TextChanged(object sender, EventArgs e)
        {
            cmsfile.Data[cbCharacter.SelectedIndex].Paths[5] = txtCMS6.Text;
        }

        private void txtCMS7_TextChanged(object sender, EventArgs e)
        {
            cmsfile.Data[cbCharacter.SelectedIndex].Paths[6] = txtCMS7.Text;
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            cmsfile.Save();
        }

        #endregion

        #region CSO
        private void txtCSO1_TextChanged(object sender, EventArgs e)
        {
            csoFile.Data[CostumeIndex[1]].Paths[0] = txtCSO1.Text;
        }

        private void txtCSO2_TextChanged(object sender, EventArgs e)
        {
            csoFile.Data[CostumeIndex[1]].Paths[1] = txtCSO2.Text;
        }

        private void txtCSO3_TextChanged(object sender, EventArgs e)
        {
            csoFile.Data[CostumeIndex[1]].Paths[2] = txtCSO3.Text;
        }

        private void txtCSO4_TextChanged(object sender, EventArgs e)
        {
            csoFile.Data[CostumeIndex[1]].Paths[3] = txtCSO4.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            csoFile.Save();
        }
        #endregion

        #region skills
        private void cbSuper1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSuper1.SelectedIndex >= 0)
                CS.Chars[CostumeIndex[0]].SuperIDs[0] = CS.Supers[cbSuper1.SelectedIndex].ID;
            else
                CS.Chars[CostumeIndex[0]].SuperIDs[0] = -1;
        }

        private void cbSuper2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSuper2.SelectedIndex >= 0)
                CS.Chars[CostumeIndex[0]].SuperIDs[1] = CS.Supers[cbSuper2.SelectedIndex].ID;
            else
                CS.Chars[CostumeIndex[0]].SuperIDs[1] = -1;
        }

        private void cbSuper3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSuper3.SelectedIndex >= 0)
                CS.Chars[CostumeIndex[0]].SuperIDs[2] = CS.Supers[cbSuper3.SelectedIndex].ID;
            else
                CS.Chars[CostumeIndex[0]].SuperIDs[2] = -1;
        }

        private void cbSuper4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSuper4.SelectedIndex >= 0)
                CS.Chars[CostumeIndex[0]].SuperIDs[3] = CS.Supers[cbSuper4.SelectedIndex].ID;
            else
                CS.Chars[CostumeIndex[0]].SuperIDs[3] = -1;
        }

        private void cbUlt1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbUlt1.SelectedIndex >= 0)
                CS.Chars[CostumeIndex[0]].UltimateIDs[0] = CS.Ultimates[cbUlt1.SelectedIndex].ID;
            else
                CS.Chars[CostumeIndex[0]].UltimateIDs[0] = -1;
        }

        private void cbUlt2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbUlt2.SelectedIndex >= 0)
                CS.Chars[CostumeIndex[0]].UltimateIDs[1] = CS.Ultimates[cbUlt2.SelectedIndex].ID;
            else
                CS.Chars[CostumeIndex[0]].UltimateIDs[1] = -1;
        }

        private void cbEva_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbEva.SelectedIndex >= 0)
                CS.Chars[CostumeIndex[0]].EvasiveID = CS.Evasives[cbEva.SelectedIndex].ID;
            else
                CS.Chars[CostumeIndex[0]].EvasiveID = -1;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            CS.Save();
        }
        #endregion

        private void lstPSC_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstPSC.SelectedItems.Count != 0)
            {
                txtPSCinfo.Text = lstPSC.SelectedItems[0].SubItems[0].Text;
                txtPSCVal.Text = lstPSC.SelectedItems[0].SubItems[1].Text;
            }
        }

        private void txtPSCVal_TextChanged(object sender, EventArgs e)
        {
            lstPSC.SelectedItems[0].SubItems[1].Text = txtPSCVal.Text;
            pFile.SaveVal(pFile.FindCharacterIndex(cmsfile.Data[cbCharacter.SelectedIndex].ID), cbCostumes.SelectedIndex, lstPSC.SelectedItems[0].Index, txtPSCVal.Text);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            pFile.Save();
        }

        private void cbZSoul_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstPSC.Items[42].SubItems[1].Text = ZS[cbZSoul.SelectedIndex].id.ToString();
        }
    }
}
