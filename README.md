# База знаний для хранения информации о выпускаемых компонентах
**Настройка запуска** 
* Убедитесь что MSSQLServer запущен на локальной машине
* Выполните сборку
## Структура базы данных
[![Engine-DB1.jpg](https://i.postimg.cc/P526QkqC/Engine-DB1.jpg)](https://postimg.cc/PCvzd9YH)
[![Engine-DB2.jpg](https://i.postimg.cc/6p3Vw49Q/Engine-DB2.jpg)](https://postimg.cc/dLbZj1ZM)
## Главное окно приложения
[![Main-Winsow.jpg](https://i.postimg.cc/zvk9kfcX/Main-Winsow.jpg)](https://postimg.cc/9wr8mc2v)
* При необходимости для создания базы данных выполните
  ```
  dotnet ef migrations add migration_2 -s EngineKnowledgeBase -p EngineKnowledgeBase.DataAccess
  ```
  ```
  dotnet ef database update -s EngineKnowledgeBase -p EngineKnowledgeBase.DataAccess
  ```
  
