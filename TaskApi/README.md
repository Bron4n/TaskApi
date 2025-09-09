📌 Task API

Простое REST API для управления задачами (Task Management API).
Проект разработан на .NET 6 с использованием InMemory-хранилища.

🚀 Getting Started
Требования

.NET 6 SDK

Postman (для тестирования)

Запуск проекта
dotnet run


После запуска API будет доступно по адресу:

https://localhost:7141/api/tasks

📦 Models
TaskItem

Модель задачи, с которой работает API.

| Поле          | Тип      | Описание                        | Пример                                 |
| ------------- | -------- | ------------------------------- | -------------------------------------- |
| `id`          | Guid     | Уникальный идентификатор задачи | `c7fdddbe-5580-4c1f-a088-ab4f619b34eb` |
| `title`       | string   | Заголовок задачи                | `Сделать домашку`                      |
| `description` | string   | Подробное описание задачи       | `Написать и протестировать REST API`   |
| `createdAt`   | DateTime | Дата и время создания           | `2025-09-06T07:04:31.1346907Z`         |
| `dueAt`       | DateTime | Дата и время дедлайна           | `2025-09-20T12:00:00Z`                 |
| `priority`    | int      | Приоритет (1–5)                 | `3`                                    |
| `isCompleted` | bool     | Статус выполнения               | `false`                                |


GET /api/tasks

Пример ответа (200 OK):

[
  {
    "id": "c7fdddbe-5580-4c1f-a088-ab4f619b34eb",
    "title": "Сделать домашку",
    "description": "Написать и протестировать REST API",
    "createdAt": "2025-09-06T07:04:31.1346907Z",
    "dueAt": "2025-09-20T12:00:00Z",
    "priority": 3,
    "isCompleted": false
  }
]

🔹 Получить задачу по ID

GET /api/tasks/{id}

Пример:

GET /api/tasks/c7fdddbe-5580-4c1f-a088-ab4f619b34eb


Ответ (200 OK):

{
  "id": "c7fdddbe-5580-4c1f-a088-ab4f619b34eb",
  "title": "Сделать домашку",
  "description": "Написать и протестировать REST API",
  "createdAt": "2025-09-06T07:04:31.1346907Z",
  "dueAt": "2025-09-20T12:00:00Z",
  "priority": 3,
  "isCompleted": false
}


Ошибки:

400 Bad Request — неверный формат ID

404 Not Found — задача не найдена

🔹 Создать задачу

POST /api/tasks

Тело запроса:

{
  "title": "Сделать домашку",
  "description": "Написать и протестировать REST API",
  "dueAt": "2025-09-20T12:00:00Z",
  "priority": 3
}


Ответ (201 Created):

{
  "id": "c7fdddbe-5580-4c1f-a088-ab4f619b34eb",
  "title": "Сделать домашку",
  "description": "Написать и протестировать REST API",
  "createdAt": "2025-09-06T07:04:31.1346907Z",
  "dueAt": "2025-09-20T12:00:00Z",
  "priority": 3,
  "isCompleted": false
}


Ошибки:

400 Bad Request — некорректные данные

🔹 Обновить задачу

PUT /api/tasks/{id}

Тело запроса:

{
  "title": "Сделать домашку (обновлено)",
  "description": "Написать и протестировать REST API (с тестами)",
  "dueAt": "2025-09-25T12:00:00Z",
  "priority": 5,
  "isCompleted": true
}


Ответ (200 OK):

{
  "id": "c7fdddbe-5580-4c1f-a088-ab4f619b34eb",
  "title": "Сделать домашку (обновлено)",
  "description": "Написать и протестировать REST API (с тестами)",
  "createdAt": "2025-09-06T07:04:31.1346907Z",
  "dueAt": "2025-09-25T12:00:00Z",
  "priority": 5,
  "isCompleted": true
}


Ошибки:

400 Bad Request — неверный формат ID или данные

404 Not Found — задача не найдена

🔹 Удалить задачу

DELETE /api/tasks/{id}

Ответ (204 No Content):
Задача успешно удалена.

Ошибки:

400 Bad Request — неверный формат ID

404 Not Found — задача не найдена