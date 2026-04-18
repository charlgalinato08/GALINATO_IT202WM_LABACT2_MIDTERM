using System;
using System.Windows.Forms;

namespace HospitalManagementSystem
{
    // =====================================================================
    // HospitalDashboard.cs  — MDI PARENT FORM
    // This is the MAIN window. All other forms (Patient, Doctor, Billing)
    // open INSIDE this window. That is what MDI means:
    //   Multiple Document Interface
    // =====================================================================

    public partial class HospitalDashboard : Form
    {
        // ------------------------------------------------------------------
        // Constructor — runs once when the program starts
        // ------------------------------------------------------------------
        public HospitalDashboard()
        {
            InitializeComponent();

            // IMPORTANT: This makes the form an MDI container
            // (child forms will open inside this window)
            this.IsMdiContainer = true;

            this.Text = "Hospital Management System — Dashboard";
            this.WindowState = FormWindowState.Maximized; // Start full-screen
        }

        // ==================================================================
        //  MENUSTRIP CLICK HANDLERS
        //  These run when the user clicks File > New Patient, etc.
        // ==================================================================

        // File > New Patient
        private void menuNewPatient_Click(object sender, EventArgs e)
        {
            OpenChildForm(new PatientForm());
        }

        // File > New Doctor
        private void menuNewDoctor_Click(object sender, EventArgs e)
        {
            OpenChildForm(new DoctorForm());
        }

        // File > New Billing
        private void menuNewBilling_Click(object sender, EventArgs e)
        {
            OpenChildForm(new BillingForm());
        }

        // File > Exit
        private void menuExit_Click(object sender, EventArgs e)
        {
            // Ask the user before closing
            DialogResult result = MessageBox.Show(
                "Are you sure you want to exit?",
                "Exit",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
                Application.Exit();
        }

        // ==================================================================
        //  WINDOW MENU HANDLERS  (Cascade, Tile Horizontal, Tile Vertical)
        // ==================================================================

        private void menuCascade_Click(object sender, EventArgs e)
        {
            // Arranges child windows diagonally (stacked)
            this.LayoutMdi(MdiLayout.Cascade);
        }

        private void menuTileHorizontal_Click(object sender, EventArgs e)
        {
            // Arranges child windows side by side horizontally
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void menuTileVertical_Click(object sender, EventArgs e)
        {
            // Arranges child windows stacked vertically
            this.LayoutMdi(MdiLayout.TileVertical);
        }

        // ==================================================================
        //  TOOLSTRIP BUTTON HANDLERS
        //  These run when the user clicks the toolbar buttons at the top
        // ==================================================================

        private void toolBtnPatient_Click(object sender, EventArgs e)
        {
            OpenChildForm(new PatientForm());
        }

        private void toolBtnDoctor_Click(object sender, EventArgs e)
        {
            OpenChildForm(new DoctorForm());
        }

        private void toolBtnBilling_Click(object sender, EventArgs e)
        {
            OpenChildForm(new BillingForm());
        }

        private void toolBtnArrange_Click(object sender, EventArgs e)
        {
            // Default arrangement when clicking "Arrange Windows"
            this.LayoutMdi(MdiLayout.Cascade);
        }

        // ==================================================================
        //  CONTEXT MENU HANDLERS  (right-click menu on the dashboard)
        // ==================================================================

        private void contextOpenPatient_Click(object sender, EventArgs e)
        {
            OpenChildForm(new PatientForm());
        }

        private void contextOpenDoctor_Click(object sender, EventArgs e)
        {
            OpenChildForm(new DoctorForm());
        }

        private void contextCloseAll_Click(object sender, EventArgs e)
        {
            CloseAllChildForms();
        }

        // ==================================================================
        //  HELPER METHODS
        // ==================================================================

        /// <summary>
        /// Opens any child form inside the MDI parent (this dashboard).
        /// MdiParent = this  ← this line is the key!
        /// </summary>
        private void OpenChildForm(Form childForm)
        {
            childForm.MdiParent = this; // Link child to parent
            childForm.Show();           // Display it
        }

        /// <summary>
        /// Closes ALL open child forms inside the dashboard.
        /// </summary>
        private void CloseAllChildForms()
        {
            // this.MdiChildren gives us an array of all open child forms
            foreach (Form child in this.MdiChildren)
            {
                child.Close();
            }
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // HospitalDashboard
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "HospitalDashboard";
            this.Load += new System.EventHandler(this.HospitalDashboard_Load);
            this.ResumeLayout(false);

        }

        private void HospitalDashboard_Load(object sender, EventArgs e)
        {

        }
    }
}
