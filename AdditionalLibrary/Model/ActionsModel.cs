
using System;

namespace AdditionalLibrary
{
    public class ActionsModel
    {
        /// <summary>
        /// Дата действия.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Имя клиента.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Действие клиента.
        /// </summary>
        public string Actions { get; set; }

        /// <summary>
        /// Сумма.
        /// </summary>
        public double Amount { get; set; }

        public ActionsModel(string name, string actions, double amount)
        {
            this.Date = DateTime.Now;
            this.Name = name;
            this.Actions = actions;
            this.Amount = amount;
        }
    }
}
