# ASVedomost
Инструкция пользования:
1. Установить Microsoft SQL Server 2022 и SQL Server management studio 2019
2. В SQL Server management studio 2019 импортировать базу данных Relsy.bacpac. Видеоинструкция, как импортировать базу данных: https://youtu.be/OKQFoqY79fE?t=61
3. Установить Microsoft Visual Studio 2022
4. Распаковать архив Interface.zip
5. Открыть в корневой папке Interface файл проекта Interface.sln для просмотра кода программы
6. Открыть класс ConnectBD.cs и в строке SqlConnection _connect = new SqlConnection(@"Data Source= "Название сервера";Initial Catalog= "Название базы данных";Integrated Security=True; TrustServerCertificate=True");
указать, где "Название сервера" ваш сервер, который указан в окне подключения SQL Server management studio 2019, и "Название базы данных" название вашей базы данных, который вы ыказывали при импорте (по умолчанию Relsy).
7. Начать отладку и тестировать программу
