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
using System.Windows.Navigation;
using System.Windows.Shapes;
using AdditionalLibrary;

namespace Hw_13
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Создаем клиента.
        Clients client;

        // Создаем адаптер кнопок.
        ButtonAdapter btn;

        public MainWindow()
        {
            #region Задание.
            // Создать прототип банковской системы, позвляющей управлять клиентами и клиентскими счетами.
            // В информационной системе есть возможность 
            /// Ok! =   перевода денежных средств между счетами пользователей 
            /// Ок! =   Открывать вклады, 1) с капитализацией!!!! и 2) без!!!!
            #region Пример про капитализацию.
            // 100 12%
            // 12 ме - 112
            // 100 12%
            // 101 12%
            // 102.01 12%

            //     100
            // 1   101
            // 2   102,01
            // 3   103,0301
            // 4   104,060401
            // 5   105,101005
            // 6   106,1520151
            // 7   107,2135352
            // 8   108,2856706
            // 9   109,3685273
            // 10  110,4622125
            // 11  111,5668347
            // 12  112,682503
            #endregion
            /// Ok! =   * Продумать возможность выдачи кредитов
            //
            /// Ok! =   Продумать использование обобщений

            /// Ok! =   Продемонстрировать работу созданной системы

            /// Банк
            /// ├── Отдел работы с обычными клиентами
            /// ├── Отдел работы с VIP клиентами
            /// └── Отдел работы с юридическими лицами

            /// Ok! =   Дополнительно: клиентам с хорошей кредитной историей предлагать пониженую ставку по кредиту и 
            ///         повышенную ставку по вкладам
            /// Ok! =   Добавить механизмы оповещений используя делегаты и события
            /// Ok! =   Реализовать журнал действий, который будет хранить записи всех транзакций по 
            ///         счетам / вкладам / кредитам
            //
            // Задание 15.
            /// Ok! =   Создать собственные исключения и добавить их обработку в предыдущий проект
            /// Ok! =   Подумать над использованием методов-расширений и
            // перегрузках операций
            /// Ok! =   Вынести основную логику в отдельную(ые) библиотеку 
            #endregion
            InitializeComponent();
        }

        /// <summary>
        /// Метод для заполнения списка с вкладами.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listClients_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SetListValues();

            // Записываем выделенную запись.
            client = (Clients)listClients.SelectedItem;

            // Проверяем, чтобы выделили запись.
            if (client == null)
                return;

            // Заполняем список со счетами.
            this.listAccounts.ItemsSource = Fill.account.Where(x => x.СlientsIndex == client.Index
                                                                && x.TypeOfDeposit != DepositType.Credit);
            // Заполняем список с кредитами.
            this.listAccountsCredit.ItemsSource = Fill.account.Where(x => x.СlientsIndex == client.Index
                                                                && x.TypeOfDeposit == DepositType.Credit);
        }

        /// <summary>
        /// Загрузка формы.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Заполняем все списки.
            this.listActions.ItemsSource = ActionsMessage.actionList;
            this.listClients.ItemsSource = Fill.client;
            this.listActions.ItemsSource = ActionsMessage.actionList;
        }

        /// <summary>
        /// Событие - нажатие на кнопку.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Click(object sender, RoutedEventArgs e)
        {
            btn = new ButtonAdapter((sender as Button).Name, listClients);
            SetListValues();
        }

        /// <summary>
        /// Метод для установки значения null в списках формы.
        /// </summary>
        private void SetListValues()
        {
            this.listAccounts.ItemsSource = null;
            this.listAccountsCredit.ItemsSource = null;
        }
    }
}
