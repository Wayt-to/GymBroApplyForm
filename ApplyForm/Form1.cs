using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;

namespace ApplyForm
{
    public partial class Form1 : Form
    {
       
        
        public Form1()
        {
            InitializeComponent();
            openPicDialog.Filter = "Jpg File |*.jpg| Jpeg File |*.jpeg| png File |*.png";
        }

        private void bt_save_Click(object sender, EventArgs e)
        {

            if (tb_name.Text != "" && tb_surname.Text != "" && mtb_IdNumber.Text != "___________" && cb_city.Text!=""&&mt_phone.Text!= "(___) ___-____"&& tb_mail.Text != "" &&tb_adress.Text != ""&&tb_weight.Text!=""&&tb_height.Text!=""&&cb_bodyType.Text!=""&&cb_hairType.Text != "" &&cb_eyeColor.Text != "" &&cb_skinColor.Text != "" &&tb_pullUps.Text != "" &&tb_pushUps.Text != "" &&tb_sitUps.Text != "" &&tb_flex.Text != ""&&tb_mail.Text.Contains('@')&&tb_mail.Text.Contains('.')&&!tb_mail.Text.Contains(' '))
            {
                string filename = tb_name.Text + "_" + tb_surname.Text + "_" + mtb_IdNumber.Text + ".w4yt";
                string path = $"Personnel Folder/{filename}";

                if (!System.IO.File.Exists(path))
                {
                    FileStream fs = new FileStream(path, FileMode.CreateNew);
                    fs.Close();
                    DirectoryInfo di = new DirectoryInfo(path);
                    MessageBox.Show("Personnel File Created Successfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lb_allPersonals.Items.Add(di.Name);

                    StreamWriter sw = new StreamWriter(path, true, Encoding.GetEncoding("UTF-8"));
                    sw.WriteLine(tb_name.Text);
                    sw.WriteLine(tb_surname.Text);
                    sw.WriteLine(mtb_IdNumber.Text);
                    if (rb_male.Checked)
                    {
                        sw.WriteLine("Male");
                    }
                    else if (rb_female.Checked)
                    {
                        sw.WriteLine("Female");
                    }
                    sw.WriteLine(cb_city.SelectedItem.ToString());
                    sw.WriteLine(dtp_date.Value.ToString());
                    sw.WriteLine(mt_phone.Text);
                    sw.WriteLine(tb_mail.Text);
                    sw.WriteLine(tb_adress.Text);
                    if (rb_FYes.Checked)
                    {
                        sw.WriteLine("Yes");
                    }
                    else if (rb_FNo.Checked)
                    {
                        sw.WriteLine("No");
                    }
                    sw.WriteLine(pb_image.ImageLocation);
                    sw.WriteLine(tb_weight.Text);
                    sw.WriteLine(cb_hairType.Text);
                    sw.WriteLine(tb_height.Text);
                    sw.WriteLine(cb_eyeColor.Text);
                    sw.WriteLine(cb_bodyType.Text);
                    sw.WriteLine(cb_skinColor.Text);
                    sw.WriteLine(tb_pushUps.Text);
                    sw.WriteLine(tb_sitUps.Text);
                    sw.WriteLine(tb_pullUps.Text);
                    sw.WriteLine(tb_flex.Text);
                    sw.WriteLine(tb_bmi.Text);
                    sw.WriteLine(lbl_status.Text);
                    sw.WriteLine(tb_note.Text);
                    if (rb_qualified.Checked)
                    {
                        sw.WriteLine("Qualified");
                    }
                    else if (rb_notQualified.Checked)
                    {
                        sw.WriteLine("Not Qualified");
                    }
                    sw.Close();
                }
                else
                {
                    MessageBox.Show("Personnel file already exist, please use edit button to edit personnel information.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                

            }
            else
            {
                MessageBox.Show("Please make sure you fill in all the information correctly.","Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            string over = "";
            if (tb_name.Text != "" && tb_surname.Text != "" && dtp_date.Text != "" && cb_city.Text != "" && mt_phone.Text != "" && tb_mail.Text != "")
            {
                DateTime birth = Convert.ToDateTime(dtp_date.Text);
                TimeSpan sinceBirth = DateTime.Now - birth;
                string age = Convert.ToString(Convert.ToInt32(sinceBirth.TotalDays / 365));
                over += $"Name : {tb_name.Text}\nSurname : {tb_surname.Text}\nIndentity Number : {mtb_IdNumber.Text}\nAge : {age}\nHometown : {cb_city.Text}\nPhone : {mt_phone.Text}\nE-Mail : {tb_mail.Text}";
            }
            lbl_overall.Text = over;

        }

        
        private void Form1_Load(object sender, EventArgs e)
        {
            DirectoryInfo di = new DirectoryInfo("Personnel Folder");
            FileInfo[] files = di.GetFiles();
            lb_allPersonals.Text = "";
            foreach (FileInfo item in files)
            {
                lb_allPersonals.Items.Add(item.Name);
            }

        }

        private void tabControl1_Click(object sender, EventArgs e)
        {
            string over = "";
            if (tb_name.Text!=""&& tb_surname.Text != "" && dtp_date.Text!=""&& cb_city.Text!=""&& mt_phone.Text!=""&& tb_mail.Text!="")
            {
                DateTime birth = Convert.ToDateTime(dtp_date.Text);
                TimeSpan sinceBirth = DateTime.Now - birth;
                string age = Convert.ToString(Convert.ToInt32(sinceBirth.TotalDays / 365));
                over += $"Name : {tb_name.Text}\nSurname : {tb_surname.Text}\nIndentity Number : {mtb_IdNumber.Text}\nAge : {age}\nHometown : {cb_city.Text}\nPhone : {mt_phone.Text}\nE-Mail : {tb_mail.Text}";
            }
            lbl_overall.Text=over;
            

        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure to clear everything on the pannel ?\nAll unsaved data will be lost! ", "Clear", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
                tb_name.Text = "";
                tb_surname.Text = default;
                mtb_IdNumber.Text = default;
                rb_male.Checked = true;
                cb_city.SelectedItem = default;
                dtp_date.Text = default;
                mt_phone.Text = default;
                tb_mail.Text = default;
                tb_adress.Text = default;
                rb_FNo.Checked = true;
                pb_image.ImageLocation = default;
                pb_image2.ImageLocation = default;
                tb_weight.Text = default;
                tb_height.Text = default;
                cb_eyeColor.Text = default;
                cb_bodyType.Text = default;
                cb_skinColor.Text = default;
                tb_pushUps.Text = default;
                tb_sitUps.Text = default;
                tb_pullUps.Text = default;
                tb_flex.Text = default;
                tb_bmi.Text = default;
                lbl_status.Text = default;
                tb_note.Text = default;
                rb_qualified.Checked = default;
                rb_notQualified.Checked = default;
                MessageBox.Show("The panel has been cleared successfully.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btn_get_Click(object sender, EventArgs e)
        {
            string filename = tb_name.Text + "_" + tb_surname.Text + "_" + mtb_IdNumber.Text + ".w4yt";
            string path = $"Personnel Folder/{filename}";
            StreamReader sr = new StreamReader($"Personnel Folder/{lb_allPersonals.SelectedItem.ToString()}");
            string line;
            int lineIndex = 0;
            
            while ((line = sr.ReadLine())!=null)
            {
                lineIndex++;
                switch (lineIndex)
                {
                    case 1:
                        tb_name.Text = line;
                        break;
                    case 2:
                        tb_surname.Text = line;
                        break;
                    case 3:
                        mtb_IdNumber.Text= line;
                        break;
                    case 4:
                        if (line=="Male")
                        {
                            rb_male.Checked = true;
                        }
                        else if (line == "Female")
                        {
                            rb_female.Checked = true;
                        }
                        
                        break;
                    case 5:
                        cb_city.SelectedItem = line;
                        break;
                    case 6:
                        dtp_date.Text = line;
                        break;
                    case 7:
                        mt_phone.Text = line;
                        break;
                    case 8:
                        tb_mail.Text = line;
                        break;
                    case 9:
                        tb_adress.Text = line;
                        break;
                    case 10:
                        if (line == "Yes")
                        {
                            rb_FYes.Checked = true;
                        }
                        else if (line == "No")
                        {
                            rb_FNo.Checked = true;
                        }
                        break;
                    case 11:
                        pb_image.ImageLocation = line;
                        pb_image2.ImageLocation = line;
                        pb_image.SizeMode = PictureBoxSizeMode.Zoom;
                        pb_image2.SizeMode = PictureBoxSizeMode.Zoom;
                        break;
                    case 12:
                        tb_weight.Text = line;
                        break;
                    case 13:
                        cb_hairType.Text = line;
                        break;
                    case 14:
                        tb_height.Text = line;
                        break;
                    case 15:
                        cb_eyeColor.Text = line;
                        break;
                    case 16:
                        cb_bodyType.Text = line;
                        break;
                    case 17:
                        cb_skinColor.Text = line;
                        break;
                    case 18:
                        tb_pushUps.Text = line;
                        break;
                    case 19:
                        tb_sitUps.Text = line;
                        break;
                    case 20:
                        tb_pullUps.Text = line;
                        break;
                    case 21:
                        tb_flex.Text = line;
                        break;
                    case 22:
                        tb_bmi.Text = line;
                        break;
                    case 23:
                        lbl_status.Text = line;
                        break;
                    case 24:
                        tb_note.Text = line;
                        break;
                    case 25:
                        if (line == "Qualified")
                        {
                            rb_qualified.Checked = true;
                        }
                        else if (line == "Not Qualified")
                        {
                            rb_notQualified.Checked = true;
                        }
                        break;
                }
                

            }
            sr.Close();
            string over = "";
            if (tb_name.Text != "" && tb_surname.Text != "" && dtp_date.Text != "" && cb_city.Text != "" && mt_phone.Text != "" && tb_mail.Text != "")
            {
                DateTime birth = Convert.ToDateTime(dtp_date.Text);
                TimeSpan sinceBirth = DateTime.Now - birth;
                string age = Convert.ToString(Convert.ToInt32(sinceBirth.TotalDays / 365));
                over += $"Name : {tb_name.Text}\nSurname : {tb_surname.Text}\nIndentity Number : {mtb_IdNumber.Text}\nAge : {age}\nHometown : {cb_city.Text}\nPhone : {mt_phone.Text}\nE-Mail : {tb_mail.Text}";
            }
            lbl_overall.Text = over;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openPicDialog.ShowDialog()==DialogResult.OK)
            {
                string picPath = openPicDialog.FileName;
                pb_image.ImageLocation = picPath;
                pb_image.SizeMode = PictureBoxSizeMode.Zoom;
                pb_image2.ImageLocation = pb_image.ImageLocation;
                pb_image2.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

       

        private void tb_bmi_TextChanged(object sender, EventArgs e)
        {
            if (tb_weight.Text != "" && tb_height.Text != "")
            {
                    double bmi = (Convert.ToDouble(tb_weight.Text) / (((Convert.ToDouble(tb_height.Text) / 100) * (Convert.ToDouble(tb_height.Text) / 100))));
                if (bmi <= 18 && bmi >= 12)
                {
                    lbl_status.Text = "Average fit person.";
                }
                else if (18 < bmi && bmi <= 25)
                {
                    lbl_status.Text = "Average healty person.";
                }
                else if (25 < bmi && bmi <= 35)
                {
                    lbl_status.Text = "The person should lose weight.";
                }
                else if (0 < bmi && bmi <= 12)
                {
                    lbl_status.Text = "Damn it's really fit. Employee...";
                }
                else if (bmi>35)
                {
                    lbl_status.Text = "Literally obese";
                }
            }
        }

        private void tb_weight_TextChanged(object sender, EventArgs e)
        {
            if (tb_weight.Text != "" && tb_height.Text != "")
            {
                double bmi = (Convert.ToDouble(tb_weight.Text) / (((Convert.ToDouble(tb_height.Text) / 100) * (Convert.ToDouble(tb_height.Text) / 100))));
                tb_bmi.Text = bmi.ToString();
            }
            
        }

        private void tb_height_TextChanged(object sender, EventArgs e)
        {
            if (tb_weight.Text != "" && tb_height.Text != "")
            {
                double bmi = (Convert.ToDouble(tb_weight.Text) / (((Convert.ToDouble(tb_height.Text) / 100) * (Convert.ToDouble(tb_height.Text) / 100))));
                tb_bmi.Text = bmi.ToString();
            }
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            if (tb_name.Text != "" && tb_surname.Text != "" && mtb_IdNumber.Text != "___________" && cb_city.Text != "" && mt_phone.Text != "(___) ___-____" && tb_mail.Text != "" && tb_adress.Text != "" && tb_weight.Text != "" && tb_height.Text != "" && cb_bodyType.Text != "" && cb_hairType.Text != "" && cb_eyeColor.Text != "" && cb_skinColor.Text != "" && tb_pullUps.Text != "" && tb_pushUps.Text != "" && tb_sitUps.Text != "" && tb_flex.Text != "" && tb_mail.Text.Contains('@') && tb_mail.Text.Contains('.') && !tb_mail.Text.Contains(' '))
            {
                if (lb_allPersonals.SelectedItem.ToString()!="")
                {
                    string filename = lb_allPersonals.SelectedItem.ToString();
                    string path = $"Personnel Folder/{filename}";

                    FileStream fs = new FileStream(path, FileMode.Truncate);
                    fs.Close();
                    DirectoryInfo di = new DirectoryInfo(path);
                    MessageBox.Show("Personnel file has been editted successfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    StreamWriter sw = new StreamWriter(path, true, Encoding.GetEncoding("UTF-8"));
                    sw.WriteLine(tb_name.Text);
                    sw.WriteLine(tb_surname.Text);
                    sw.WriteLine(mtb_IdNumber.Text);
                    if (rb_male.Checked)
                    {
                        sw.WriteLine("Male");
                    }
                    else if (rb_female.Checked)
                    {
                        sw.WriteLine("Female");
                    }
                    sw.WriteLine(cb_city.SelectedItem.ToString());
                    sw.WriteLine(dtp_date.Value.ToString());
                    sw.WriteLine(mt_phone.Text);
                    sw.WriteLine(tb_mail.Text);
                    sw.WriteLine(tb_adress.Text);
                    if (rb_FYes.Checked)
                    {
                        sw.WriteLine("Yes");
                    }
                    else if (rb_FNo.Checked)
                    {
                        sw.WriteLine("No");
                    }
                    sw.WriteLine(pb_image.ImageLocation);
                    sw.WriteLine(tb_weight.Text);
                    sw.WriteLine(cb_hairType.Text);
                    sw.WriteLine(tb_height.Text);
                    sw.WriteLine(cb_eyeColor.Text);
                    sw.WriteLine(cb_bodyType.Text);
                    sw.WriteLine(cb_skinColor.Text);
                    sw.WriteLine(tb_pushUps.Text);
                    sw.WriteLine(tb_sitUps.Text);
                    sw.WriteLine(tb_pullUps.Text);
                    sw.WriteLine(tb_flex.Text);
                    sw.WriteLine(tb_bmi.Text);
                    sw.WriteLine(lbl_status.Text);
                    sw.WriteLine(tb_note.Text);
                    if (rb_qualified.Checked)
                    {
                        sw.WriteLine("Qualified");
                    }
                    else if (rb_notQualified.Checked)
                    {
                        sw.WriteLine("Not Qualified");
                    }
                    sw.Close();
                    string filenameNew = tb_name.Text + "_" + tb_surname.Text + "_" + mtb_IdNumber.Text + ".w4yt";
                    if (System.IO.File.Exists(path))
                    {
                        string newPath = $"Personnel Folder/{filenameNew}";
                        System.IO.File.Move(path, newPath);
                        DirectoryInfo dir = new DirectoryInfo("Personnel Folder");
                        FileInfo[] files = dir.GetFiles();
                        lb_allPersonals.Text = "";
                        lb_allPersonals.Items.Clear();
                        foreach (FileInfo item in files)
                        {
                            lb_allPersonals.Items.Add(item.Name);
                        }
                        lb_allPersonals.SelectedItem = filenameNew;
                    }
                }
                else
                {
                    MessageBox.Show("Please select the personnel you want to edit from the list.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                
            }
            else
            {
                MessageBox.Show("Please make sure you fill in all the information correctly.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            string over = "";
            if (tb_name.Text != "" && tb_surname.Text != "" && dtp_date.Text != "" && cb_city.Text != "" && mt_phone.Text != "" && tb_mail.Text != "")
            {
                DateTime birth = Convert.ToDateTime(dtp_date.Text);
                TimeSpan sinceBirth = DateTime.Now - birth;
                string age = Convert.ToString(Convert.ToInt32(sinceBirth.TotalDays / 365));
                over += $"Name : {tb_name.Text}\nSurname : {tb_surname.Text}\nIndentity Number : {mtb_IdNumber.Text}\nAge : {age}\nHometown : {cb_city.Text}\nPhone : {mt_phone.Text}\nE-Mail : {tb_mail.Text}";
            }
            lbl_overall.Text = over;
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure to delete this personnel file ? ", "Delete Personnel",MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr==DialogResult.Yes)
            {
                string filename = lb_allPersonals.SelectedItem.ToString();
                string path = $"Personnel Folder/{filename}";
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                    MessageBox.Show("Personnel file has been succesfully deleted.", "Info", MessageBoxButtons.OK,MessageBoxIcon.Information);
                    tb_name.Text = "";
                    tb_surname.Text = default;
                    mtb_IdNumber.Text = default;
                    rb_male.Checked = true;
                    cb_city.SelectedItem = default;
                    dtp_date.Text = default;
                    mt_phone.Text = default;
                    tb_mail.Text = default;
                    tb_adress.Text = default;
                    rb_FNo.Checked = true;
                    pb_image.ImageLocation = default;
                    pb_image2.ImageLocation = default;
                    tb_weight.Text = default;
                    tb_height.Text = default;
                    cb_eyeColor.Text = default;
                    cb_bodyType.Text = default;
                    cb_skinColor.Text = default;
                    tb_pushUps.Text = default;
                    tb_sitUps.Text = default;
                    tb_pullUps.Text = default;
                    tb_flex.Text = default;
                    tb_bmi.Text = default;
                    lbl_status.Text = default;
                    tb_note.Text = default;
                    rb_qualified.Checked = default;
                    rb_notQualified.Checked = default;
                }
                else
                {
                    MessageBox.Show("Error, please try again later.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                DirectoryInfo di = new DirectoryInfo("Personnel Folder");
                FileInfo[] files = di.GetFiles();
                lb_allPersonals.Text = "";
                lb_allPersonals.Items.Clear();
                foreach (FileInfo item in files)
                {
                    lb_allPersonals.Items.Add(item.Name);
                }
            }
            string over = "";
            if (tb_name.Text != "" && tb_surname.Text != "" && dtp_date.Text != "" && cb_city.Text != "" && mt_phone.Text != "" && tb_mail.Text != "")
            {
                DateTime birth = Convert.ToDateTime(dtp_date.Text);
                TimeSpan sinceBirth = DateTime.Now - birth;
                string age = Convert.ToString(Convert.ToInt32(sinceBirth.TotalDays / 365));
                over += $"Name : {tb_name.Text}\nSurname : {tb_surname.Text}\nIndentity Number : {mtb_IdNumber.Text}\nAge : {age}\nHometown : {cb_city.Text}\nPhone : {mt_phone.Text}\nE-Mail : {tb_mail.Text}";
            }
            lbl_overall.Text = over;


        }

        private void tb_weight_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tb_height_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tb_pushUps_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tb_pullUps_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tb_sitUps_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tb_flex_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
