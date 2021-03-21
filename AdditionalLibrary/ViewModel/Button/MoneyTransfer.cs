using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace AdditionalLibrary
{
    public class MoneyTransfer : IButtonListener
    {
        public Clients client;

        // Создаем список активностей.
        ActionsMessage actionMessage = new ActionsMessage();

        public MoneyTransfer(ListView selectedItem)
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
                System.Windows.Forms.MessageBox.Show("Необходимо выбрать, кто будет переводить деньги.");
                return;
            }

            // Создаем новую форму.
            FMoneyTransfer mt = new FMoneyTransfer();

            // Передаем индекс клиента в форму.
            mt.clientIndex = client.Index;

            if (mt.ShowDialog() == true)
            {
                // Отнимает от счета.
                foreach (var acc in Fill.account)
                {
                    if (acc.Index == mt.accountIndex)
                    {
                        acc.Amount = acc.Amount.RoundSubtraction(mt.amount);

                        actionMessage.Message(client.Name, "Отправил деньги", mt.amount);

                        if (acc.Amount == 0)
                        {
                            Fill.account.Remove(acc);
                            break;
                        }

                        break;
                    }
                }

                // Прибавляем к счету.
                foreach (var acc in Fill.account)
                {
                    if (acc.СlientsIndex == mt.clientIndex && acc.TypeOfDeposit != DepositType.Credit)
                    {
                        acc.Amount = acc.Amount.RoundAddition(mt.amount);

                        foreach (var client in Fill.client)
                            if (acc.СlientsIndex == client.Index)
                            {
                                actionMessage.Message(client.Name, "Получил деньги", mt.amount);
                                break;
                            }

                        break;
                    }
                }
            }
        }
    }
}
