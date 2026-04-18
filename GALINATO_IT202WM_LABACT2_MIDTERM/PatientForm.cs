using System;
using System.Windows.Forms;
using System.Drawing;

namespace HospitalManagementSystem
{
    // =====================================================================
    // PatientForm.cs — CHILD FORM #1
    //
    // A child form is a normal Form, EXCEPT we set MdiParent = dashboard
    // before calling Show(), so it floats INSIDE the dashboard window.
    //
    // Fields required by the assignment:
    //   Patient Name | Age | Address | Diagnosis
    // =====================================================================

    public class PatientForm : Form
    {
        // ── Controls ──────────────────────────────────────────────────────
        private Label  lblTitle;
        private Label  lblName, lblAge, lblAddress, lblDiagnosis;
        private TextBox txtName, txtAge, txtAddress, txtDiagnosis;
        private Button btnSave, btnClear;

        // ------------------------------------------------------------------
        // Constructor
        // ------------------------------------------------------------------
        public PatientForm()
        {
            this.Text        = "Patient Record";
            this.Size        = new Size(420, 380);
            this.StartPosition = FormStartPosition.CenterParent;
            this.BackColor   = Color.White;

            BuildControls(); // set up all textboxes and labels
        }

        // ------------------------------------------------------------------
        // Build the form layout in code (no designer needed)
        // ------------------------------------------------------------------
        private void BuildControls()
        {
            // ── Title label ───────────────────────────────────────────────
            lblTitle = new Label
            {
                Text      = "🏥  Patient Information",
                Font      = new Font("Segoe UI", 14, FontStyle.Bold),
                ForeColor = Color.DarkBlue,
                Location  = new Point(20, 15),
                Size      = new Size(360, 30)
            };

            // ── Patient Name ──────────────────────────────────────────────
            lblName = MakeLabel("Patient Name:", 60);
            txtName = MakeTextBox(60);

            // ── Age ───────────────────────────────────────────────────────
            lblAge = MakeLabel("Age:", 110);
            txtAge = MakeTextBox(110);

            // ── Address ───────────────────────────────────────────────────
            lblAddress = MakeLabel("Address:", 160);
            txtAddress = MakeTextBox(160);

            // ── Diagnosis ─────────────────────────────────────────────────
            lblDiagnosis = MakeLabel("Diagnosis:", 210);
            txtDiagnosis = new TextBox
            {
                Location  = new Point(140, 210),
                Size      = new Size(240, 60),
                Multiline = true  // allows multiple lines for longer diagnoses
            };

            // ── Buttons ───────────────────────────────────────────────────
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

            // ── Add all controls to the form ──────────────────────────────
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

        // ------------------------------------------------------------------
        // Button events
        // ------------------------------------------------------------------

        private void BtnSave_Click(object sender, EventArgs e)
        {
            // Basic validation — make sure name is not empty
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Please enter the patient's name.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Show confirmation (in a real app you would save to a database)
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
            // Reset all fields
            txtName.Clear();
            txtAge.Clear();
            txtAddress.Clear();
            txtDiagnosis.Clear();
            txtName.Focus(); // move cursor back to the first field
        }

        // ------------------------------------------------------------------
        // Helper methods — avoid repeating the same label/textbox setup code
        // ------------------------------------------------------------------

        /// <summary>Creates a standard label at a given Y position.</summary>
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

        /// <summary>Creates a standard single-line TextBox at a given Y position.</summary>
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
