using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AdditionalLibrary
{
    /// <summary>
    /// Interaction logic for FMoneyTransfer.xaml
    /// </summary>
    public partial class FMoneyTransfer : Window
    {
        // Переменные для заполнения полей формы при загрузке.
        public Guid clientIndex;
        public double amount;
        public Guid accountIndex;

        // Создаем аккаунт.
        Accounts account;
        
        // Создаем клиента.
        Clients client;

        /// <summary>
        /// Конструктор.
        /// </summary>
        public FMoneyTransfer()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Заполняем списоки.
            this.listAccounts.ItemsSource = Fill.account.Where(x => x.СlientsIndex == clientIndex 
                                                                && x.TypeOfDeposit != DepositType.Credit);

            this.listClients.ItemsSource = Fill.client.Where(x => x.Index != clientIndex);
            
        }

        /// <summary>
        /// Метод для кнопки "Отмена".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Метод для перехвата события нажатие на кнопку "Перевести".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTransfer_Click(object sender, RoutedEventArgs e)
        {
            // Записываем выделенную запись.
            account = (Accounts)listAccounts.SelectedItem;
            client = (Clients)listClients.SelectedItem;

            // Проверяем, чтобы в поле вписали данные и выделили записи.
            if (Check())
                return;

            // Проверяем, чтобы ввели правильные данные.
            try
            {
                // Записываем сумму из поля.
                amount = Convert.ToDouble(txtAmount.Text);

                // Проверяем, чтобы сумма была больше 0.
                if ( amount <= 0)
                    throw new ValueLessThanZeroException("Ошибка : Сумма слишком маленькая.");

                // Проверяем, чтобы сумма была не больше чем есть на счету.
                if (account.Amount < amount)
                    throw new AmountNotMoreException("Ошибка : Сумма слишком большая.");
            }
            catch (ValueLessThanZeroException ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            catch (AmountNotMoreException ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Ошибка : Необходимо ввести только цифры.");
                return;
            }

            this.clientIndex = client.Index;
            this.accountIndex = account.Index;
            this.listClients.SelectedItem = null;
            this.DialogResult = true;
        }

        /// <summary>
        /// Метод для перехвата события при выделении записи в списке со счетами.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listAccounts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Записываем выделенную запись.
            account = (Accounts)listAccounts.SelectedItem;

            // Добавляем сумму в поле.
            this.txtAmount.Text = account.Amount.ToString();
        }

        /// <summary>
        /// Метод проверят IsNullOrEmpty и выделение записей в списках.
        /// </summary>
        /// <returns>true or false</returns>
        private bool Check()
        {
            // Проверям, чтобы поле с суммой было не пусто.
            if (string.IsNullOrEmpty(txtAmount.Text))
            {
                MessageBox.Show("Необходимо вписать сумму для перевода.");
                return true;
            }

            // Проверяем, чтобы выделили счет.
            if (account == null)
            {
                MessageBox.Show("Необходимо выделить \"С какого счета перевод\"");
                return true;
            }

            // Проверяем, чтобы выделили клиента.
            if (client == null)
            {
                MessageBox.Show("Необходимо выделить \"Кому переводить\"");
                return true;
            }

            return false;
        }
    }
}
