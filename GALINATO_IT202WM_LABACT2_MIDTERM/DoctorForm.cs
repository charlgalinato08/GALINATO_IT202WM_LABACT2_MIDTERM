using System;
using System.Windows.Forms;
using System.Drawing;

namespace HospitalManagementSystem
{
    // =====================================================================
    // DoctorForm.cs — CHILD FORM #2
    //
    // Fields required by the assignment:
    //   Doctor Name | Specialization
    // =====================================================================

    public class DoctorForm : Form
    {
        private Label   lblTitle, lblName, lblSpecialization;
        private TextBox txtName;
        private ComboBox cmbSpecialization; // dropdown list of specializations
        private Button  btnSave, btnClear;

        public DoctorForm()
        {
            this.Text          = "Doctor Profile";
            this.Size          = new Size(400, 300);
            this.StartPosition = FormStartPosition.CenterParent;
            this.BackColor     = Color.White;

            BuildControls();
        }

        private void BuildControls()
        {
            // ── Title ─────────────────────────────────────────────────────
            lblTitle = new Label
            {
                Text      = "🩺  Doctor Profile",
                Font      = new Font("Segoe UI", 14, FontStyle.Bold),
                ForeColor = Color.DarkGreen,
                Location  = new Point(20, 15),
                Size      = new Size(340, 30)
            };

            // ── Doctor Name ───────────────────────────────────────────────
            lblName = new Label
            {
                Text     = "Doctor Name:",
                Location = new Point(20, 68),
                Size     = new Size(110, 22)
            };
            txtName = new TextBox
            {
                Location = new Point(140, 65),
                Size     = new Size(220, 22)
            };

            // ── Specialization (ComboBox = dropdown) ──────────────────────
            lblSpecialization = new Label
            {
                Text     = "Specialization:",
                Location = new Point(20, 118),
                Size     = new Size(110, 22)
            };

            cmbSpecialization = new ComboBox
            {
                Location     = new Point(140, 115),
                Size         = new Size(220, 22),
                DropDownStyle = ComboBoxStyle.DropDownList // force selection from list
            };

            // Add common hospital specializations to the dropdown
            cmbSpecialization.Items.AddRange(new string[]
            {
                "General Medicine",
                "Cardiology",
                "Pediatrics",
                "Orthopedics",
                "Neurology",
                "Dermatology",
                "Radiology",
                "Surgery",
                "Oncology",
                "Psychiatry"
            });

            // ── Buttons ───────────────────────────────────────────────────
            btnSave = new Button
            {
                Text      = "Save Profile",
                Location  = new Point(90, 200),
                Size      = new Size(100, 35),
                BackColor = Color.ForestGreen,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnSave.Click += BtnSave_Click;

            btnClear = new Button
            {
                Text      = "Clear",
                Location  = new Point(205, 200),
                Size      = new Size(80, 35),
                BackColor = Color.Gray,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnClear.Click += BtnClear_Click;

            // ── Add to form ───────────────────────────────────────────────
            this.Controls.AddRange(new Control[]
            {
                lblTitle,
                lblName, txtName,
                lblSpecialization, cmbSpecialization,
                btnSave, btnClear
            });
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Please enter the doctor's name.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbSpecialization.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a specialization.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MessageBox.Show(
                $"Doctor profile saved!\n\n" +
                $"Name: Dr. {txtName.Text}\n" +
                $"Specialization: {cmbSpecialization.SelectedItem}",
                "Profile Saved",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            txtName.Clear();
            cmbSpecialization.SelectedIndex = -1;
            txtName.Focus();
        }
    }
}
