using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CarParkSimulator
{
    public partial class SimulatorInterface : Form
    {
        // Attributes ///        
        private TicketMachine ticketMachine;
        private ActiveTickets activeTickets;
        private TicketValidator ticketValidator;
        private Barrier entryBarrier;
        private Barrier exitBarrier;
        private FullSign fullSign;
        private CarPark carPark;
        private EntrySensor entrySensor;
        private ExitSensor exitSensor;
        /////////////////


        // Constructor //
        public SimulatorInterface()
        {
            InitializeComponent();
        }
        /////////////////


        // Operations ///
        private void ResetSystem(object sender, EventArgs e)
        {
            string input = Microsoft.VisualBasic.Interaction.InputBox("How many spaces does the car park have?", "Welcome", "5", -1, -1);
            int spaces;

            if(!int.TryParse(input, out spaces))
            {
                MessageBox.Show("Invalid number of spaces!");
                return;
            }

            // STUDENTS:
            ///// Class contructors are not defined so there will be errors
            ///// This code is correct for the basic version though
            activeTickets = new ActiveTickets();
            ticketMachine = new TicketMachine(activeTickets);
            ticketValidator = new TicketValidator(activeTickets);
            entryBarrier = new Barrier();
            exitBarrier = new Barrier();
            fullSign = new FullSign();
            carPark = new CarPark(ticketMachine, ticketValidator, fullSign, entryBarrier, exitBarrier, spaces);
            entrySensor = new EntrySensor(carPark);
            exitSensor = new ExitSensor(carPark);

            ticketMachine.AssignCarPark(carPark);
            ticketValidator.AssignCarPark(carPark);

            /////////////////////////////////////////

            btnCarArrivesAtEntrance.Visible = true;
            btnDriverPressesForTicket.Visible = false;
            btnCarEntersCarPark.Visible = false;
            btnCarArrivesAtExit.Visible = false;
            btnDriverEntersTicket.Visible = false;
            btnCarExitsCarPark.Visible = false;
            btnInsertTicket.Visible = false;
            btnInsertCoins.Visible = false;

            UpdateDisplay(true);
        }

        private void CarArrivesAtEntrance(object sender, EventArgs e)
        {
            btnCarArrivesAtEntrance.Visible = false;
            btnDriverPressesForTicket.Visible = true;

            entrySensor.CarDetected();

            UpdateDisplay(true);
        }

        private void DriverPressesForTicket(object sender, EventArgs e)
        {
            btnDriverPressesForTicket.Visible = false;
            btnCarEntersCarPark.Visible = true;

            ticketMachine.PrintTicket();

            UpdateDisplay(true);
        }

        private void CarEntersCarPark(object sender, EventArgs e)
        {
            btnCarEntersCarPark.Visible = false;
            btnCarArrivesAtEntrance.Visible = true;


            btnCarArrivesAtExit.Visible = true;

            entrySensor.CarLeftSensor();

            carPark.carParksInRandomSpace();

            UpdateDisplay(true);
        }

        private void CarArrivesAtExit(object sender, EventArgs e)
        {
            carPark.carLeavesRandomSpace();
            exitSensor.CarDetected();
            UpdateDisplay(true);
            btnCarArrivesAtExit.Visible = false;
            btnDriverEntersTicket.Visible = true;
        }

        private void DriverEntersTicket(object sender, EventArgs e)
        {
            Ticket selectedTicket = this.GetTicketFromList();

            if(selectedTicket != null)
            {
                    if (selectedTicket.IsPaid())
                    {
                        btnDriverEntersTicket.Visible = false;
                        btnCarExitsCarPark.Visible = true;

                        ticketValidator.TicketEntered(selectedTicket);
                        UpdateDisplay(true);
                        return;
                    } else
                    {
                        MessageBox.Show("This ticket hasn't been paid for! Please visit your nearest payment machine.");
                        btnDriverEntersTicket.Visible = false;
                        btnCarArrivesAtExit.Visible = true;
                        return;
                    }
            }
            else
            {
                MessageBox.Show("Please select your ticket from the list of tickets.");
                return;
            }
        }

        private void CarExitsCarPark(object sender, EventArgs e)
        {
            btnCarExitsCarPark.Visible = false;
            btnCarArrivesAtExit.Visible = true;
            btnCarArrivesAtEntrance.Visible = true;

            exitSensor.CarLeftSensor();
            btnCarArrivesAtExit.Visible = !carPark.IsEmpty();

            UpdateDisplay(true);
        }

        private void UpdateDisplay(bool updateTicketList)
        {
            lblTicketMachine.Text = ticketMachine.GetMessage();
            lblTicketValidator.Text = ticketValidator.GetMessage();
            lblEntrySensor.Text = entrySensor.IsCarOnSensor().ToString();
            lblEntryBarrier.Text = entryBarrier.IsLifted().ToString();
            lblExitSensor.Text = exitSensor.IsCarOnSensor().ToString();
            lblExitBarrier.Text = exitBarrier.IsLifted().ToString();
            lblFullSign.Text = fullSign.IsLit().ToString();
            lblSpaces.Text = carPark.GetCurrentSpaces().ToString();

            if (updateTicketList)
            {
                lstActiveTickets.Items.Clear();

                foreach (Ticket t in activeTickets.GetTickets())
                {
                    lstActiveTickets.Items.Add("#" + t.getID() + " : " + t.IsPaid());
                }
            }

            if (lstActiveTickets.SelectedItem != null)
            {
                btnInsertTicket.Visible = true;
            }

            if (btnDriverPressesForTicket.Visible == true)
            {
                btnCarArrivesAtEntrance.Visible = false;
                btnCarEntersCarPark.Visible = false;
            }

            if (btnCarEntersCarPark.Visible == true)
            {
                btnCarArrivesAtEntrance.Visible = false;
                btnDriverPressesForTicket.Visible = false;
            }

            if (btnInsertCoins.Visible == true)
            {
                btnInsertTicket.Visible = false;
            }

            if(panelPayment.Visible == true)
            {
                btnInsertCoins.Visible = false;
            }

            if (btnDriverEntersTicket.Visible == true)
            {
                btnCarArrivesAtExit.Visible = false;
                btnCarExitsCarPark.Visible = false;
            }

            if (btnCarExitsCarPark.Visible == true)
            {
                btnCarArrivesAtExit.Visible = false;
                btnDriverEntersTicket.Visible = false;
            }

            if (carPark.GetCurrentSpaces() == 0)
            {
                btnCarArrivesAtEntrance.Visible = false;
            }
        }

        private void SimulatorInterface_Load(object sender, EventArgs e)
        {

        }

        private void lstActiveTickets_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateDisplay(false);

            Ticket selectedTicket = this.GetTicketFromList();

            if(selectedTicket != null)
            {
                this.btnInsertTicket.Visible = !selectedTicket.IsPaid();
            }
        }

        private void btnInsertTicket_Click(object sender, EventArgs e)
        {
            Ticket selectedTicket = this.GetTicketFromList();

            if (selectedTicket != null)
            {
                if (!selectedTicket.IsPaid())
                {
                    this.carPark.GetPaymentMachine().InsertTicket(selectedTicket);

                    btnInsertCoins.Visible = true;
                    btnInsertTicket.Visible = false;
                    return;
                } else
                {
                    MessageBox.Show("Your ticket has already been paid for!");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Please select your ticket from the list of tickets.");
                return;
            }
        }

        public Ticket GetTicketFromList()
        {
            object item = lstActiveTickets.SelectedItem;

            if (item != null)
            {
                string ticketID = item.ToString().Substring(1, 7);
                return activeTickets.GetTicket(ticketID);
            }
            return null;
        }

        private carParkView carParkView;

        private void button2_Click(object sender, EventArgs e)
        {
            carParkView form = new carParkView(carPark);

            carParkView = form;

            form.Show();
        }

        private void btn50p_Click(object sender, EventArgs e)
        {
            this.InsertCoin(0.5M);
        }

        private void btn1Pound_Click(object sender, EventArgs e)
        {
            this.InsertCoin(1);
        }

        private void btn10p_Click(object sender, EventArgs e)
        {
            this.InsertCoin(0.1M);
        }

        private void btn20p_Click(object sender, EventArgs e)
        {
            this.InsertCoin(0.2M);
        }

        private void InsertCoin(decimal amount)
        {
            CoinSlot.Image = Properties.Resources.CoinEntered;
            Wait.Enabled = true;

            string message = this.carPark.GetPaymentMachine().CheckIfFullyPaid(amount);
            if (message != null)
            {
                MessageBox.Show(message);
                panelPayment.Visible = false;
                btnInsertCoins.Visible = false;

                UpdateDisplay(true);
            }
            else
            {
                this.lblCost.Text = this.carPark.GetPaymentMachine().GetCostLabel();
            }
        }

        private void Wait_Tick(object sender, EventArgs e)
        {
            CoinSlot.Image = Properties.Resources.CoinSlot;
            Wait.Enabled = false;
        }
        private void btnInsertCoins_Click(object sender, EventArgs e)
        {
            Ticket ticket = this.carPark.GetPaymentMachine().GetCurrentTicket();
            if (ticket != null)
            {
                this.carPark.GetPaymentMachine().CalculateCost();
                this.lblCost.Text = this.carPark.GetPaymentMachine().GetCostLabel();
                panelPayment.Visible = true;
                UpdateDisplay(true);
            }
        }
    }
}