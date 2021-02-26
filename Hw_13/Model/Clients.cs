using System;
using System.Collections.Generic;

namespace Hw_13
{
    public class Clients
    {
        // Переменные.
        private Guid index;
        private string name;

        /// <summary>
        /// Индекс клиента.
        /// </summary>
        public Guid Index { get { return index; } }

        /// <summary>
        /// Имя клиента (если юр. лицо, тогда название).
        /// </summary>
        public string Name { get { return name; } }

        /// <summary>
        /// Тип клиента.
        /// </summary>
        public ClientsType Type { get; set; }

        /// <summary>
        /// Кредитная история.
        /// </summary>
        public CreditHistoryType CreditType { get; set; }

        /// <summary>
        /// Конструктор для создания нового клиента.
        /// </summary>
        /// <param name="name">Имя клиента.</param>
        /// <param name="type">Тип клиента.</param>
        /// <param name="creditType">Кредитная история</param>
        public Clients(string clientName, ClientsType clientType, CreditHistoryType creditType)
        {
            this.index = Guid.NewGuid();
            this.name = clientName;
            this.Type = clientType;
            this.CreditType = creditType;
        }
    }
}
