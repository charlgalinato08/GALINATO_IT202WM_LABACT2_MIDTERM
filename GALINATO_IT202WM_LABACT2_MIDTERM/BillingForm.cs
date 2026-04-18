using System;
using System.Windows.Forms;
using System.Drawing;

namespace HospitalManagementSystem
{
    // =====================================================================
    // BillingForm.cs — CHILD FORM #3
    //
    // Fields required by the assignment:
    //   Patient Name | Amount | Payment Status
    // =====================================================================

    public class BillingForm : Form
    {
        private Label   lblTitle, lblPatientName, lblAmount, lblStatus;
        private TextBox txtPatientName, txtAmount;
        private ComboBox cmbStatus;
        private Button  btnSave, btnClear;

        public BillingForm()
        {
            this.Text          = "Billing Record";
            this.Size          = new Size(400, 320);
            this.StartPosition = FormStartPosition.CenterParent;
            this.BackColor     = Color.White;

            BuildControls();
        }

        private void BuildControls()
        {
            // ── Title ─────────────────────────────────────────────────────
            lblTitle = new Label
            {
                Text      = "💳  Billing Record",
                Font      = new Font("Segoe UI", 14, FontStyle.Bold),
                ForeColor = Color.DarkOrange,
                Location  = new Point(20, 15),
                Size      = new Size(340, 30)
            };

            // ── Patient Name ──────────────────────────────────────────────
            lblPatientName = new Label
            {
                Text     = "Patient Name:",
                Location = new Point(20, 68),
                Size     = new Size(110, 22)
            };
            txtPatientName = new TextBox
            {
                Location = new Point(140, 65),
                Size     = new Size(220, 22)
            };

            // ── Amount ────────────────────────────────────────────────────
            lblAmount = new Label
            {
                Text     = "Amount (₱):",
                Location = new Point(20, 118),
                Size     = new Size(110, 22)
            };
            txtAmount = new TextBox
            {
                Location = new Point(140, 115),
                Size     = new Size(220, 22)
            };

            // ── Payment Status ────────────────────────────────────────────
            lblStatus = new Label
            {
                Text     = "Payment Status:",
                Location = new Point(20, 168),
                Size     = new Size(110, 22)
            };
            cmbStatus = new ComboBox
            {
                Location      = new Point(140, 165),
                Size          = new Size(220, 22),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cmbStatus.Items.AddRange(new string[] { "Pending", "Paid", "Partial", "Insurance" });

            // ── Buttons ───────────────────────────────────────────────────
            btnSave = new Button
            {
                Text      = "Save Record",
                Location  = new Point(90, 230),
                Size      = new Size(100, 35),
                BackColor = Color.DarkOrange,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnSave.Click += BtnSave_Click;

            btnClear = new Button
            {
                Text      = "Clear",
                Location  = new Point(205, 230),
                Size      = new Size(80, 35),
                BackColor = Color.Gray,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnClear.Click += BtnClear_Click;

            this.Controls.AddRange(new Control[]
            {
                lblTitle,
                lblPatientName, txtPatientName,
                lblAmount,      txtAmount,
                lblStatus,      cmbStatus,
                btnSave,        btnClear
            });
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            // Validate patient name
            if (string.IsNullOrWhiteSpace(txtPatientName.Text))
            {
                MessageBox.Show("Please enter the patient's name.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validate amount — must be a valid number
            if (!decimal.TryParse(txtAmount.Text, out decimal amount))
            {
                MessageBox.Show("Please enter a valid amount (numbers only).", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbStatus.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a payment status.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MessageBox.Show(
                $"Billing record saved!\n\n" +
                $"Patient: {txtPatientName.Text}\n" +
                $"Amount: ₱{amount:N2}\n" +
                $"Status: {cmbStatus.SelectedItem}",
                "Record Saved",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            txtPatientName.Clear();
            txtAmount.Clear();
            cmbStatus.SelectedIndex = -1;
            txtPatientName.Focus();
        }
    }
}
