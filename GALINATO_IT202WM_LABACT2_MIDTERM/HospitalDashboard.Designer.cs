using System.Windows.Forms;
using System.Drawing;

namespace HospitalManagementSystem
{
    

    partial class HospitalDashboard
    {
        
        private MenuStrip menuStrip;
        private ToolStrip toolStrip;
        private ContextMenuStrip contextMenuStrip;

        
        private ToolStripMenuItem menuFile;
        private ToolStripMenuItem menuNewPatient;
        private ToolStripMenuItem menuNewDoctor;
        private ToolStripMenuItem menuNewBilling;
        private ToolStripMenuItem menuSeparator;
        private ToolStripMenuItem menuExit;

        private ToolStripMenuItem menuWindow;
        private ToolStripMenuItem menuCascade;
        private ToolStripMenuItem menuTileHorizontal;
        private ToolStripMenuItem menuTileVertical;

        
        private ToolStripButton toolBtnPatient;
        private ToolStripButton toolBtnDoctor;
        private ToolStripButton toolBtnBilling;
        private ToolStripButton toolBtnArrange;

        
        private ToolStripMenuItem contextOpenPatient;
        private ToolStripMenuItem contextOpenDoctor;
        private ToolStripMenuItem contextCloseAll;

       
        private void InitializeComponent()
        {
           
            menuStrip       = new MenuStrip();
            toolStrip       = new ToolStrip();
            contextMenuStrip = new ContextMenuStrip();

            

           
            menuFile        = new ToolStripMenuItem("File");
            menuNewPatient  = new ToolStripMenuItem("New Patient");
            menuNewDoctor   = new ToolStripMenuItem("New Doctor");
            menuNewBilling  = new ToolStripMenuItem("New Billing");
            menuExit        = new ToolStripMenuItem("Exit");

           
            menuNewPatient.Click += menuNewPatient_Click;
            menuNewDoctor.Click  += menuNewDoctor_Click;
            menuNewBilling.Click += menuNewBilling_Click;
            menuExit.Click       += menuExit_Click;

            
            menuFile.DropDownItems.Add(menuNewPatient);
            menuFile.DropDownItems.Add(menuNewDoctor);
            menuFile.DropDownItems.Add(menuNewBilling);
            menuFile.DropDownItems.Add(new ToolStripSeparator()); // divider line
            menuFile.DropDownItems.Add(menuExit);

            
            menuWindow          = new ToolStripMenuItem("Window");
            menuCascade         = new ToolStripMenuItem("Cascade");
            menuTileHorizontal  = new ToolStripMenuItem("Tile Horizontal");
            menuTileVertical    = new ToolStripMenuItem("Tile Vertical");

            menuCascade.Click        += menuCascade_Click;
            menuTileHorizontal.Click += menuTileHorizontal_Click;
            menuTileVertical.Click   += menuTileVertical_Click;

            menuWindow.DropDownItems.Add(menuCascade);
            menuWindow.DropDownItems.Add(menuTileHorizontal);
            menuWindow.DropDownItems.Add(menuTileVertical);

            
            menuStrip.Items.Add(menuFile);
            menuStrip.Items.Add(menuWindow);

            
            toolBtnPatient = new ToolStripButton("👤 Patient Form");
            toolBtnDoctor  = new ToolStripButton("🩺 Doctor Form");
            toolBtnBilling = new ToolStripButton("💳 Billing Form");
            toolBtnArrange = new ToolStripButton("🪟 Arrange Windows");

           
            toolBtnPatient.BackColor = Color.LightBlue;
            toolBtnDoctor.BackColor  = Color.LightGreen;
            toolBtnBilling.BackColor = Color.LightYellow;
            toolBtnArrange.BackColor = Color.LightSalmon;

            toolBtnPatient.Click += toolBtnPatient_Click;
            toolBtnDoctor.Click  += toolBtnDoctor_Click;
            toolBtnBilling.Click += toolBtnBilling_Click;
            toolBtnArrange.Click += toolBtnArrange_Click;

            toolStrip.Items.Add(toolBtnPatient);
            toolStrip.Items.Add(new ToolStripSeparator());
            toolStrip.Items.Add(toolBtnDoctor);
            toolStrip.Items.Add(new ToolStripSeparator());
            toolStrip.Items.Add(toolBtnBilling);
            toolStrip.Items.Add(new ToolStripSeparator());
            toolStrip.Items.Add(toolBtnArrange);

            
            contextOpenPatient = new ToolStripMenuItem("Open Patient Form");
            contextOpenDoctor  = new ToolStripMenuItem("Open Doctor Form");
            contextCloseAll    = new ToolStripMenuItem("Close All Windows");

            contextOpenPatient.Click += contextOpenPatient_Click;
            contextOpenDoctor.Click  += contextOpenDoctor_Click;
            contextCloseAll.Click    += contextCloseAll_Click;

            contextMenuStrip.Items.Add(contextOpenPatient);
            contextMenuStrip.Items.Add(contextOpenDoctor);
            contextMenuStrip.Items.Add(new ToolStripSeparator());
            contextMenuStrip.Items.Add(contextCloseAll);

            
            this.ContextMenuStrip = contextMenuStrip;

           
            this.Controls.Add(menuStrip);
            this.Controls.Add(toolStrip);
            this.MainMenuStrip = menuStrip;
        }
    }
}
