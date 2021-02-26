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

namespace Hw_13
{
    /// <summary>
    /// Interaction logic for FNewDeposit.xaml
    /// </summary>
    public partial class FLoan : Window
    {
        // Переменные для заполнения полей формы при загрузке.
        public CreditHistoryType creditHistory;
        public string name;
        public double credit;

        /// <summary>
        /// Конструктор.
        /// </summary>
        public FLoan()
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

            // Назначаем ставку по кредиту.
            if (creditHistory == CreditHistoryType.Good)
                this.txtRate.Text = "10%";
            else if (creditHistory == CreditHistoryType.Zero)
                this.txtRate.Text = "15%";
            else
                this.txtRate.Text = "20%";
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
            // Проверяем, чтобы ввели правильные данные.
            try
            {
                // Проверяем, чтобы данные ввели.
                if (string.IsNullOrEmpty(this.txtCredit.Text))
                {
                    MessageBox.Show("Просьба вписать сумму кредита.");
                    return;
                }

                // Записываем сумму из поля.
                credit = Convert.ToDouble(this.txtCredit.Text);

                // Проверяем, чтобы сумма была не меньше либо равно 0.
                if (credit <= 0)
                {
                    MessageBox.Show("Сумма слишком маленькая.");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            this.DialogResult = true;
        }
    }
}
