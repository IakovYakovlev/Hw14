using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace AdditionalLibrary
{
    class Loan : IButtonListener
    {
        public Clients client;

        // Создаем список активностей.
        ActionsMessage actionMessage = new ActionsMessage();

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="selectedItem">Список с выделенной записью.</param>
        public Loan(ListView selectedItem)
        {
            client = (Clients)selectedItem.SelectedItem;

            // Подписываем на обновления.
            ActionsMessage actionMessageList = new ActionsMessage();
            actionMessage.Post += actionMessageList.ClientsActions;
        }

        /// <summary>
        /// Реализация интерфейса IButtonListener.
        /// </summary>
        public void ButtonPressed()
        {
            // Проверяем, чтобы выделили запись.
            if (client == null)
            {
                System.Windows.Forms.MessageBox.Show("Необходимо выбрать, кому выдается кредит.");
                return;
            }

            // Создаем форму.
            FLoan loan = new FLoan();

            // Устанавлиеваем значения в переменных формы.
            loan.name = client.Name;
            loan.creditHistory = client.CreditType;

            // Если нажали "Ок", тогда выдаем кредит.
            if (loan.ShowDialog() == true)
            {
                Fill.account.Add(new Accounts(client.Index, loan.credit, DepositType.Credit));
                actionMessage.Message(client.Name, "Взял кредит", loan.credit);
            }
        }
    }
}
