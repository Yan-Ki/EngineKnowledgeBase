# База знаний для хранения информации о выпускаемых компонентах
**Настройка запуска** 
* Убедитесь что MSSQLServer запущен на локальной машине
* Для создания базы данных выполните
  ```PowerShell
  dotnet ef database update -s EngineKnowledgeBase -p EngineKnowledgeBase.DataAccess
  ```
* Выполните сборку
## Структура базы данных
[![EngineBD.jpg](https://i.postimg.cc/5tS96Qbj/EngineBD.jpg)](https://postimg.cc/Ff1X6RfQ)
  
