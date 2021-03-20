using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace AdditionalLibrary
{
    class ButtonAdapter
    {
        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="btnName">Название кнопки.</param>
        /// <param name="selectedItem">Список с выделением.</param>
        public ButtonAdapter(string btnName, ListView selectedItem)
        {
            object className = ButtonSwitch(btnName, selectedItem);

            if (className is IButtonListener)
                ButtonPress((IButtonListener)className);
            else
                System.Windows.Forms.MessageBox.Show($"Эта кнопка {btnName}, не обработана!");
        }

        /// <summary>
        /// Метод вызывает событие нажатие на нужную кнопку.
        /// </summary>
        /// <param name="btn"></param>
        public void ButtonPress(IButtonListener btn)
        {
            btn.ButtonPressed();
        }

        /// <summary>
        /// Метод возвращает класс с выделенным элементом исходя из названия кнопки.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="selectedItem"></param>
        /// <returns></returns>
        private object ButtonSwitch(string name, ListView selectedItem)
        {
            switch (name)
            {
                case "btnAutoFill":
                    return new Fill();

                case "btnOpen":
                    return new NewDeposit(selectedItem);

                case "btnTransfer":
                    return new MoneyTransfer(selectedItem);

                case "btnLoan":
                    return new Loan(selectedItem);

                default:
                    return null;
            }
        }
    }
}
