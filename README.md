# WebProgrammingBD
База данных на сервере MySQL будет создана с использованием команд миграции Entity Framework.
После создания моделей нужно сгенерировать миграции и применить их:
dotnet ef migrations add InitialCreate
dotnet ef database update
Эти команды создадут необходимые таблицы на сервере MySQL по указанной модели.
