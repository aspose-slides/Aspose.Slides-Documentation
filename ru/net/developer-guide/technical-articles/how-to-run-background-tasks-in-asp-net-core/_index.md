---
title: Как запускать фоновые задачи в ASP.NET Core
type: docs
weight: 300
url: /ru/net/how-to-run-background-tasks-in-asp-net-core/
---

## **Обзор**
Обработка файлов (например, экспорт презентации в PDF) является типичной задачей на стороне сервера. Простой процесс обработки файлов внутри обработчика запроса (когда клиент ждет, пока сервер выполняет работу) имеет следующие недостатки:

- *Плохой интерфейс*. Страница зависает, и пользователю приходится ждать результата. Перезагрузка страницы отменит задачу.
- *Таймаут операции*. Мы не можем гарантировать, что обработка будет завершена в фиксированный период времени, поэтому пользователь рано или поздно увидит "таймаут операции".
- *Низкая пропускная способность и масштабируемость*. ASP.NET Core предназначен для обработки множества запросов асинхронно. Задачи, связанные с процессором, длительного выполнения блокируют потоки и снижают пропускную способность сервера.
- *Плохая отказоустойчивость*. Когда что-то идет не так в середине долгосрочной задачи (например, проблемы с подключением), обработка просто прекращается, и нам приходится снова запускать процесс обработки с самого начала.

[Лучший подход](https://docs.microsoft.com/en-us/aspnet/core/performance/performance-best-practices#complete-long-running-tasks-outside-of-http-requests) заключается в том, чтобы сначала запланировать задачу асинхронно, затем завершить её в фоновом режиме и, наконец, вернуть результат обработки.

В этом случае пользователь может видеть актуальный статус (и даже покинуть или перезагрузить страницу), ресурсы сервера могут эффективно масштабироваться и гибко настраиваться. Также может использоваться политика повторных попыток.

Таким образом, типичное решение для фоновой обработки включает в себя следующие части:
1. API для планирования задачи.
2. API для отслеживания статуса задачи.
3. Фоновый рабочий процесс для обработки запланированных задач.
4. API для хранения/получения результата.

## **Пример фоновой задачи**
Чтобы продемонстрировать этот подход, давайте рассмотрим [**пример веб-приложения ASP.NET Core 3.1**](https://wiki.lutsk.dynabic.com/download/Aspose%20Slides/slidesnet/Discussion%20on%20Russian/Issues/Platform%20specific/How%20to%20run%20Background%20Tasks%20in%20ASP.NET%20Core/WebHome/BackgroundJobDemo.zip?rev=1.1). Веб-приложение содержит веб-страницу, на которой пользователь может загрузить презентацию, нажать кнопку "Экспорт в PDF", после чего презентация будет загружена и преобразована в формат PDF фоновым работником.
## **Веб-приложение**
Пример веб-приложения (проект *BackgroundJobDemo*) включает в себя:

- Страницу загрузки файлов (страница razor Upload).
- Страницу прогресса (страница razor Progress с несколькими функциями JavaScript для проверки и отображения статуса).
- Контроллер (JobStatusController), предоставляющий статус обработки (api/status/{jobId}).
- Контроллер (JobResultController), возвращающий экспортированный PDF файл (api/result/{id}).
- Фоновый работник, основанный на службе хостинга ASP.NET Core (см. класс WorkerService).

Страницы razor, контроллеры и фоновый работник делегируют всю фактическую работу через интерфейсы, определенные в проекте *BackgroundJobDemo.Common*. Конкретные реализации управления задачами и обработки определены в отдельных проектах (*BackgroundJobDemo.Local*, *BackgroundJobDemo.Aws* и т.д.) и могут быть легко переключены в методе Startup.ConfigureServices.

Для демонстрационных целей страница "Загрузить" использует буферизированное связывание модели, но для загрузки больших файлов рекомендуется [небуферизованный поток](https://docs.microsoft.com/en-us/aspnet/core/mvc/models/file-uploads). Для развертывания в производственной среде следует учитывать [аспекты безопасности](https://docs.microsoft.com/en-us/aspnet/core/mvc/models/file-uploads#security-considerations). Страница "Прогресс" опрашивает статус запланированной задачи с помощью JavaScript каждые 2 секунды (период может быть изменен). Опрос статуса является типичным поведением, но для более сложных случаев могут потребоваться уведомления в реальном времени (реальные коммуникации выходят за рамки данной статьи) через WebSocket. [SignalR](https://dotnet.microsoft.com/apps/aspnet/signalr) является простым, но мощным инструментом для коммуникаций в реальном времени.

Хостинг фонового работника в процессе сервера удобен для простых приложений, но имеет [недостатки](https://haacked.com/archive/2011/10/16/the-dangers-of-implementing-recurring-background-tasks-in-asp-net.aspx). Более надежным и масштабируемым решением является развертывание работника в отдельном процессе (см. например *BackgroundJobDemo.Worker* консольное приложение).
## **Базовая реализация**
Проект *BackgroundJobDemo.Local* содержит простую реализацию управления задачами с использованием базы данных SQLite (путь к файлу базы данных указывается через LocalConfig.DbFilePath, см. в Startup.ConfigureServices). Загруженные и обработанные файлы хранятся на файловой системе (путь к папке хранения указывается через LocalConfig.FileStorageFolderPath, см. в Startup.ConfigureServices). Для лучшей отказоустойчивости и производительности в реальных приложениях планирование задач должно быть реализовано с использованием очередей сообщений (например, RabbitMQ, AWS SQS, Azure Storage Queue).
## **Распределенная реализация на основе Amazon Web Services**
Проект *BackgroundJobDemo.Aws* реализует обработку задач через Amazon Web Services и демонстрирует распределенную архитектуру, которую можно горизонтально масштабировать. Она включает следующие компоненты:

- Веб-приложение - взаимодействует с пользователем и планирует задачи экспорта PPTX в PDF и т.д.
- Рабочий процесс - обрабатывает экспорт (в процессе, вне процесса или Amazon Lambda).
- Очередь сообщений - хранит задачи для обработки (Amazon SQS).
- Хранение файлов - сохраняет загруженные и обработанные файлы (Amazon S3).
- Хранилище ключ-значение - предоставляет статус обработки задач (Amazon DynamoDB).

Типичная распределенная архитектура основывается на [очередях сообщений](https://aws.amazon.com/message-queue/): веб-приложение помещает фоновые задачи в очередь, фоновый работник получает задачу из очереди и выполняет необходимую работу. Таким образом, компоненты системы (веб-приложение и фоновый работник) разъединены, а обработка является асинхронной и надежной. Очередь гарантирует, что все сообщения (задачи) доставляются работникам. У сообщений в очереди есть *тайм-аут видимости* - когда один работник получает сообщение для обработки, сообщение становится невидимым для других работников, и только работник, обрабатывающий сообщение, может удалить его из очереди. Если обработка не завершена в течение тайм-аута видимости (например, ошибка или проблема с сетью) - необработанное сообщение снова становится видимым для работников.

Наша реализация использует [Amazon Simple Queue Service](https://aws.amazon.com/sqs/) (SQS) - полностью управляемые очереди сообщений для микросервисов, распределенных систем и безсерверных приложений.

Очереди сообщений предназначены для легковесных сообщений (например, лимит размера сообщения SQS составляет 256 КБ), поэтому они должны содержать только описание задачи. Все тяжелые данные (например, файлы для обработки) должны размещаться в отдельном хранилище и ссылаться на сообщение. [Amazon S3](https://aws.amazon.com/s3/) - это облачное хранилище, построенное для хранения и извлечения любого объема данных из любого места. Этот сервис используется для хранения загруженных и обработанных файлов.

Хранилище ключ-значение необходимо для хранения и извлечения результата обработки задачи по идентификатору. В примере был использован [Amazon DynamoDB](https://aws.amazon.com/dynamodb/) (быстрая и гибкая служба NoSQL базы данных для любого масштаба).

Чтобы запустить демонстрационное приложение с Amazon Web Services:

1. Создайте и настройте в одном регионе AWS:
   1. Очередь SQS,
   1. Корзину S3,
   1. Таблицу DynamoDB.
2. Подключите веб-приложение к созданным службам с помощью метода расширения AddAws (URL очереди SQS, имя корзины S3, имя таблицы DynamoDB и регион AWS) из Startup.ConfigureServices. 
## **Ссылки**
- Лучшие практики производительности ASP.NET Core <https://docs.microsoft.com/en-us/aspnet/core/performance/performance-best-practices>
- Загрузка файлов в ASP.NET Core <https://docs.microsoft.com/en-us/aspnet/core/mvc/models/file-uploads>
- ASP.NET в реальном времени с SignalR <https://dotnet.microsoft.com/apps/aspnet/signalr>
- Очереди сообщений <https://aws.amazon.com/message-queue/>
- Amazon Simple Queue Service <https://aws.amazon.com/sqs/>
- Amazon S3 <https://aws.amazon.com/s3/>
- Amazon DynamoDB <https://aws.amazon.com/dynamodb/>