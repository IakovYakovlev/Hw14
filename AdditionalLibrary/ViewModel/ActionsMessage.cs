using System;
using System.Collections.ObjectModel;
using System.Windows;

namespace AdditionalLibrary
{
    public class ActionsMessage
    {

        // Создаем статический список для ListView "Журнал действий".
        public static ObservableCollection<ActionsModel> actionList;

        /// <summary>
        /// Инициализируем объекты.
        /// </summary>
        static ActionsMessage()
        {
            actionList = new ObservableCollection<ActionsModel>();
        }

        /// <summary>
        /// Конструктор.
        /// </summary>
        public ActionsMessage() {}

        /// <summary>
        /// Метод для оповещения.
        /// </summary>
        /// <param name="name">Имя клиента.</param>
        /// <param name="action">Действие.</param>
        /// <param name="amount">Сумма.</param>
        public void Message(string name, string action, double amount)
        {
            // Добавляем новую запись в журнал.
            actionList.Add(new ActionsModel(name, action, amount));

            post?.Invoke(name, action, amount.ToString());
        }

        // Создаем события.
        private event Action<string, string, string> post;
        public event Action<string, string, string> Post
        {
            add
            {
                post += value;
            }
            remove
            {
                post -= value;
            }
        }

        /// <summary>
        /// Метод для оповещения.
        /// </summary>
        /// <param name="name">Имя клиента.</param>
        /// <param name="action">Действие.</param>
        /// <param name="amount">Сумма.</param>
        public void ClientsActions(string name, string action, string amount)
        {
            MessageBox.Show($"Клиент : {name}, {action}, сумма : {amount}");
        }
    }
}
