namespace Museum
{
    class Program
    {
        static void Main()
        {
            UserMessage.Welcome();

            var exit = false;
            do
            {
                UserMessage.ShowMenu();
                var select = UserMessage.InputKey();
                switch (select)
                {
                    case 1: // 1. Найти автора
                        UserMessage.FindAuthor();
                        break;
                    case 2: // 2. Найти экспонат
                        UserMessage.FindExhibits();
                        break;
                    case 3: // 3. Найти место хранения
                        UserMessage.FindStorage();
                        break;
                    case 4: // 4. Найти место хранения экспоната
                        UserMessage.FindSpaceStorage();
                        break;
                    case 0: // 0. Выход из программы
                        exit = true;
                        break;
                }
            } while (!exit);

            UserMessage.GoodBye();
        }
    }
}



