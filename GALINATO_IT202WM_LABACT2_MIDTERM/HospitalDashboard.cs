using System;
using System.Windows.Forms;

namespace HospitalManagementSystem
{
    

    public partial class HospitalDashboard : Form
    {
        
        public HospitalDashboard()
        {
            InitializeComponent();

            // IMPORTANT: This makes the form an MDI container
            // (child forms will open inside this window)
            this.IsMdiContainer = true;

            this.Text = "Hospital Management System — Dashboard";
            this.WindowState = FormWindowState.Maximized; // Start full-screen
        }

       
        private void menuNewPatient_Click(object sender, EventArgs e)
        {
            OpenChildForm(new PatientForm());
        }

      
        private void menuNewDoctor_Click(object sender, EventArgs e)
        {
            OpenChildForm(new DoctorForm());
        }

       
        private void menuNewBilling_Click(object sender, EventArgs e)
        {
            OpenChildForm(new BillingForm());
        }

        
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

       

        private void menuCascade_Click(object sender, EventArgs e)
        {
            
            this.LayoutMdi(MdiLayout.Cascade);
        }

        private void menuTileHorizontal_Click(object sender, EventArgs e)
        {
            
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void menuTileVertical_Click(object sender, EventArgs e)
        {
            
            this.LayoutMdi(MdiLayout.TileVertical);
        }

        

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

    
        
        private void OpenChildForm(Form childForm)
        {
            childForm.MdiParent = this; // Link child to parent
            childForm.Show();           // Display it
        }

        
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
