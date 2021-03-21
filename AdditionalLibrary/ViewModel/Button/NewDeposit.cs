using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace AdditionalLibrary
{
    public class NewDeposit : IButtonListener
    {
        public Clients client;

        // Создаем список активностей.
        ActionsMessage actionMessage = new ActionsMessage();

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="selectedItem"></param>
        public NewDeposit(ListView selectedItem)
        {
            client = (Clients)selectedItem.SelectedItem;

            // Подписываем на обновления.
            ActionsMessage actionMessageList = new ActionsMessage();
            actionMessage.Post += actionMessageList.ClientsActions;
        }

        public void ButtonPressed()
        {
            // Проверяем, чтобы выделили запись.
            if (client == null)
            {
                System.Windows.Forms.MessageBox.Show("Необходимо выбрать клиента!");
                return;
            }

            // Создаем форму.
            FNewDeposit newDeposit = new FNewDeposit();

            // Устанавлиеваем значения в переменных формы.
            newDeposit.name = client.Name;

            // Если нажали "Ок", тогда добавляем новый вклад.
            if (newDeposit.ShowDialog() == true)
            {
                Fill.account.Add(new Accounts(client.Index, newDeposit.amount, newDeposit.type));
                actionMessage.Message(client.Name, "Открыл новый счет", newDeposit.amount);
            }
        }
    }
}
