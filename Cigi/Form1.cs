namespace Cigi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void TextBoxDohanyMaradek_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Csak számokat és vezérlõ karaktereket (pl. backspace) engedélyezünk
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
