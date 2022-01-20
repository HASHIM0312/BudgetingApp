namespace BudgetAppClassLibrary
{
    public class Budget
    {
        public Budget()
        {
            Console.Write("How much do you want to spend in a month: ");
            string budgetInput = Console.ReadLine();

            int actualBudgetInput;
            if (Int32.TryParse(budgetInput, out actualBudgetInput))
            {

                Console.WriteLine("Okay, so if you spend over $" + actualBudgetInput + ", I will notify you plus give a warning before making any transactions");



            }

        }

    }
}
