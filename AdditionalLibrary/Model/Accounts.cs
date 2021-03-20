using System;

namespace AdditionalLibrary
{
    class Accounts
    {
        // Переменные для установки значений.
        private Guid index;
        private Guid clientsIndex;

        /// <summary>
        /// Индекс счета.
        /// </summary>
        public Guid Index { get { return index; } }

        /// <summary>
        /// Индекс клиента.
        /// </summary>
        public Guid СlientsIndex { get { return clientsIndex; } }

        /// <summary>
        /// Сумма на счету.
        /// </summary>
        public double Amount { get; set; }

        /// <summary>
        /// Тип депозита.
        /// </summary>
        public DepositType TypeOfDeposit { get; set; }

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="cIndex">Индекс клиента.</param>
        /// <param name="amount">Сумма.</param>
        /// <param name="depositType">Тип депозита.</param>
        public Accounts(Guid cIndex, double amount, DepositType depositType)
        {
            this.index = Guid.NewGuid();
            this.clientsIndex = cIndex;
            this.Amount = Math.Round(amount, 2);
            this.TypeOfDeposit = depositType;
        }
    }
}
