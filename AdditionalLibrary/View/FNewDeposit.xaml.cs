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
    /// Interaction logic for FNewDeposit.xaml
    /// </summary>
    public partial class FNewDeposit : Window
    {
        // Переменные для заполнения полей формы при загрузке.
        public string name;
        public double amount;
        public DepositType type;

        /// <summary>
        /// Конструктор.
        /// </summary>
        public FNewDeposit()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Метод для установки значений при загрузе форы.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.txtClient.Text = name;
        }

        /// <summary>
        /// Метод для нажания на кнопку "Отмена".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Метод для нажания на кнопку "Ок".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            // Проверяем, чтобы поля были не пустые.
            if(string.IsNullOrEmpty(txtAmount.Text) || string.IsNullOrEmpty(cmbType.Text))
            {
                MessageBox.Show("Необходимо заполнить все поля.");
                return;
            }

            // Проверяем поле с вкладом, чтобы были правильные даныне.
            try
            {
                // Записываем сумму в переменную.
                amount = Convert.ToDouble(txtAmount.Text);

                // Проверяем, чтобы сумма была больше 0.
                if(amount <= 0)
                {
                    MessageBox.Show("Сумма слишком маленькая.");
                    return;
                }

                // Назначаем тип депозита.
                if (cmbType.Text == "С капитализацией")
                    type = DepositType.WithСapitalization;
                else
                    type = DepositType.WithoutСapitalization;

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            this.DialogResult = true;
        }
    }
}
