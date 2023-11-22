using System.Windows.Forms;

namespace FSW
{
    public partial class Form1 : Form
    {
        private string sharedFolderPath = @"D:\SharedFolder";
        private string messageFileName = "ChatMessage.txt";
        private string dekriptovano = "Dekriptovano.txt";



        private bool isCryptEnabled = false; // Da li je kriptovanje uključeno
        private bool isCryptEnabled2 = false;





        public Form1()
        {
            InitializeComponent();

            // Kreirajte FileSystemWatcher
            FileSystemWatcher watcher = new FileSystemWatcher();
            watcher.Path = sharedFolderPath;
            watcher.Filter = messageFileName;
            watcher.NotifyFilter = NotifyFilters.LastWrite;
            watcher.Changed += OnFileChanged;
            watcher.EnableRaisingEvents = true;

            

        }




        // Event handler za promenu fajla
        private void OnFileChanged(object sender, FileSystemEventArgs e)
        {
            if (e.Name == messageFileName)
            {
                string poruka = File.ReadAllText(Path.Combine(sharedFolderPath, messageFileName));
                string encryptedMessage = isCryptEnabled2 ? EncryptMessage(poruka) : poruka;

                textBoxSendMessage.Clear();


                // Prikazivanje dekriptovane poruke
                DisplayMessage(encryptedMessage);

                textBoxReceivedMessages1.Invoke((MethodInvoker)delegate
                {
                    textBoxReceivedMessages1.Text = encryptedMessage;
                });


            }
        }


        // Funkcija za kriptovanje poruke
        private string EncryptMessage(string message)
        {

            // Primer sa ključevima "KEYWORD1" i "KEYWORD2"
            FoursquareCipher cipher = new FoursquareCipher("ZGPTFOIHMUWDRCNYKEQAXVSBL", "MFNBDCRHSAXYOGVITUEWLQZKP");


            string originalMessage = message;

            // Šifrovanje teksta
            string encryptedMessage = cipher.Encrypt(originalMessage);


            return encryptedMessage;
        }

        // Funkcija za dekriptovanje poruke
        private string DecryptMessage(string encryptedMessage)
        {

            // Primer sa ključevima "KEYWORD1" i "KEYWORD2"
            FoursquareCipher cipher = new FoursquareCipher("ZGPTFOIHMUWDRCNYKEQAXVSBL", "MFNBDCRHSAXYOGVITUEWLQZKP");


            // Dekriptovanje šifrovanog teksta
            string decryptedMessage = cipher.Decrypt(encryptedMessage);


            return "Decrypted: " + decryptedMessage;
        }

        // Funkcija za prikazivanje poruke
        private void DisplayMessage(string message)
        {
            // Prikazivanje poruke u TextBox-u
            textBoxReceivedMessages1.Invoke((MethodInvoker)delegate
            {
                textBoxReceivedMessages1.AppendText(message + Environment.NewLine);
            });
        }

        // Event handler za dugme slanja poruke
        private void btnSend1_Click(object sender, EventArgs e)
        {
            string message = textBoxSendMessage.Text;
            string encryptedMessage;

            if (!string.IsNullOrEmpty(message))
            {


                if (isCryptEnabled2)
                    encryptedMessage = EncryptMessage(message);
                else
                    encryptedMessage = message;



                File.WriteAllText(Path.Combine(sharedFolderPath, messageFileName), encryptedMessage);


                textBoxSendMessage.Clear();
            }
        }



        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBoxSendMessage_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBoxReceivedMessages1.Clear();
        }

        private void checkBoxCrypt_CheckedChanged_1(object sender, EventArgs e)
        {


            if (checkBoxCrypt.Checked)
            {
                // CheckBox je čekiran
                isCryptEnabled2 = true;
                // Dodajte odgovarajuću logiku ako je potrebno
            }
            else
            {
                // CheckBox nije čekiran
                isCryptEnabled2 = false;
                // Dodajte odgovarajuću logiku ako je potrebno
            }



        }

        private void decryptButton_Click(object sender, EventArgs e)
        {
            // Uzimam kriptovanu poruku iz textBoxReceivedMessages
            string encryptedMessage = textBoxReceivedMessages1.Text;

            // Implementiram dekriptovanje poruke
            string decryptedMessage = DecryptMessage(encryptedMessage);

            // Prikazujem dekriptovanu poruku u textBoxDecrypted
            decryptedBox.Invoke((MethodInvoker)delegate
            {
                decryptedBox.Text = decryptedMessage;
            });

            SaveDecryptedMessageToFile(decryptedMessage);

        }


        //za upisivanje dekriptovane poruke u fajl
        private void SaveDecryptedMessageToFile(string decryptedMessage)
        {
            string dekriptovanoFilePath = Path.Combine(sharedFolderPath, dekriptovano);
            File.WriteAllText(dekriptovanoFilePath, decryptedMessage);
        }


        //kad god vrsim promenu fajla ChatMessage.txt i sejvujem, ta rec se automatski kriptuje i vidi se u formi

    }
}
