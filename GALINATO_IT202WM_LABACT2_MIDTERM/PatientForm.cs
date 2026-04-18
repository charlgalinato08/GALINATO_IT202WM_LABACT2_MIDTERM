using System;
using System.Windows.Forms;
using System.Drawing;

namespace HospitalManagementSystem
{
   

    public class PatientForm : Form
    {
        
        private Label  lblTitle;
        private Label  lblName, lblAge, lblAddress, lblDiagnosis;
        private TextBox txtName, txtAge, txtAddress, txtDiagnosis;
        private Button btnSave, btnClear;

       
        public PatientForm()
        {
            this.Text        = "Patient Record";
            this.Size        = new Size(420, 380);
            this.StartPosition = FormStartPosition.CenterParent;
            this.BackColor   = Color.White;

            BuildControls(); // set up all textboxes and labels
        }

        
        private void BuildControls()
        {
            
            lblTitle = new Label
            {
                Text      = "🏥  Patient Information",
                Font      = new Font("Segoe UI", 14, FontStyle.Bold),
                ForeColor = Color.DarkBlue,
                Location  = new Point(20, 15),
                Size      = new Size(360, 30)
            };

           
            lblName = MakeLabel("Patient Name:", 60);
            txtName = MakeTextBox(60);

            
            lblAge = MakeLabel("Age:", 110);
            txtAge = MakeTextBox(110);

            
            lblAddress = MakeLabel("Address:", 160);
            txtAddress = MakeTextBox(160);

            
            lblDiagnosis = MakeLabel("Diagnosis:", 210);
            txtDiagnosis = new TextBox
            {
                Location  = new Point(140, 210),
                Size      = new Size(240, 60),
                Multiline = true  // allows multiple lines for longer diagnoses
            };

            
            btnSave = new Button
            {
                Text      = "Save Record",
                Location  = new Point(100, 300),
                Size      = new Size(100, 35),
                BackColor = Color.SteelBlue,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnSave.Click += BtnSave_Click;

            btnClear = new Button
            {
                Text      = "Clear",
                Location  = new Point(215, 300),
                Size      = new Size(80, 35),
                BackColor = Color.Gray,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnClear.Click += BtnClear_Click;

            
            this.Controls.AddRange(new Control[]
            {
                lblTitle,
                lblName,   txtName,
                lblAge,    txtAge,
                lblAddress,txtAddress,
                lblDiagnosis, txtDiagnosis,
                btnSave, btnClear
            });
        }

       

        private void BtnSave_Click(object sender, EventArgs e)
        {
          
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Please enter the patient's name.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

           
            MessageBox.Show(
                $"Patient record saved!\n\n" +
                $"Name: {txtName.Text}\n" +
                $"Age: {txtAge.Text}\n" +
                $"Address: {txtAddress.Text}\n" +
                $"Diagnosis: {txtDiagnosis.Text}",
                "Record Saved",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            
            txtName.Clear();
            txtAge.Clear();
            txtAddress.Clear();
            txtDiagnosis.Clear();
            txtName.Focus(); // move cursor back to the first field
        }

        

       
        private Label MakeLabel(string text, int y)
        {
            return new Label
            {
                Text     = text,
                Location = new Point(20, y + 3),
                Size     = new Size(110, 22),
                Font     = new Font("Segoe UI", 9)
            };
        }

       
        private TextBox MakeTextBox(int y)
        {
            return new TextBox
            {
                Location = new Point(140, y),
                Size     = new Size(240, 22)
            };
        }
    }
}
