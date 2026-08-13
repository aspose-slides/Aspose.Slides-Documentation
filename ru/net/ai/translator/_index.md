---
title: Транслатор презентаций на базе ИИ
linktitle: Транслатор на базе ИИ
type: docs
weight: 20
url: /ru/net/ai/translator/
keywords:
- ИИ‑транслатор презентаций
- ИИ‑транслатор слайдов
- Функция на базе ИИ
- Многоязычная презентация
- Многоязычный слайд
- Перевод презентации
- Перевод слайда
- Функции, управляемые ИИ
- Возможности ИИ
- Агент ИИ
- Веб‑клиент
- PowerPoint
- OpenDocument
- презентация
- .NET
- C#
- Aspose.Slides
description: "Переводите слайды PowerPoint с помощью ИИ, используя Aspose.Slides для .NET. Локализуйте файлы PPT, PPTX и ODP, сохраняя макет — быстро и удобно для разработчиков. Попробуйте."
---
## **Введение**

Aspose.Slides — мощный API для программного управления презентациями PowerPoint. Помимо создания, редактирования и преобразования слайдов, он предлагает функции на основе ИИ — такие как [Presentation Translation API](https://reference.aspose.com/slides/ru/net/aspose.slides.ai/) для многоязычного содержания слайдов.

## **Как это работает**

Aspose.Slides не включает встроенные возможности ИИ, но интегрируется с внешними моделями ИИ через Интернет. Эта функциональность доступна через класс [SlidesAIAgent](https://reference.aspose.com/slides/ru/net/aspose.slides.ai/slidesaiagent), который использует реализацию интерфейса [IAIWebClient](https://reference.aspose.com/slides/ru/net/aspose.slides.ai/iaiwebclient/) для взаимодействия с сервисами ИИ.

Вы можете использовать встроенный [OpenAIWebClient](https://reference.aspose.com/slides/ru/net/aspose.slides.ai/openaiwebclient/) для подключения к API OpenAI или реализовать свой собственный [IAIWebClient](https://reference.aspose.com/slides/ru/net/aspose.slides.ai/iaiwebclient/) для использования другого поставщика ИИ или языковой модели.

Aspose.Slides обрабатывает коммуникацию, анализирует ответы ИИ и интеллектуально вставляет переведённый контент, при этом сохраняет исходный макет и форматирование слайдов.

{{% alert color="info" %}}
Обратите внимание, что API OpenAI является платным сервисом, поэтому вам необходимо создать учётную запись и предоставить ваш API‑ключ при использовании встроенного [OpenAIWebClient](https://reference.aspose.com/slides/ru/net/aspose.slides.ai/openaiwebclient/).
{{% /alert %}}

## **Пример**

В этом примере мы переводим презентацию PowerPoint на японский язык, используя встроенный [OpenAIWebClient](https://reference.aspose.com/slides/ru/net/aspose.slides.ai/openaiwebclient/) с указанной моделью OpenAI [model](https://platform.openai.com/docs/models).

```csharp
using Aspose.Slides;
using Aspose.Slides.AI;
using Aspose.Slides.Export;

// Загрузить презентацию для перевода.
using var presentation = new Presentation("sample.pptx");

// Создать AI‑клиент с OpenAIWebClient, указав вашу модель и API‑ключ.
using var aiWebClient = new OpenAIWebClient(model: "gpt-4o-mini", apiKey: "apiKey", organizationId: null);

// Инициализировать SlidesAIAgent с AI‑клиентом.
var aiAgent = new SlidesAIAgent(aiWebClient);

// Перевести презентацию на японский язык.
await aiAgent.TranslateAsync(presentation, "japanese");

// Сохранить переведённую презентацию в формате PDF.
presentation.Save("sample_jp.pdf", SaveFormat.Pdf);
```

По умолчанию встроенный [OpenAIWebClient](https://reference.aspose.com/slides/ru/net/aspose.slides.ai/openaiwebclient/) создаёт и управляет собственным внутренним экземпляром [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient), автоматически обрабатывая его жизненный цикл и освобождение. Однако, если вы предпочитаете управлять [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient) самостоятельно — например, при использовании [IHttpClientFactory](https://learn.microsoft.com/en-us/dotnet/core/extensions/httpclient-factory) для лучшего управления ресурсами и производительности — вы можете предоставить свой собственный экземпляр `HttpClient` при создании [OpenAIWebClient](https://reference.aspose.com/slides/ru/net/aspose.slides.ai/openaiwebclient/).

```csharp
using System.Net.Http;
using Aspose.Slides.AI;

// Используйте HttpClient, которым вы управляете сами — например, созданный IHttpClientFactory
// внедрено через инъекцию зависимостей.
HttpClient httpClient = new HttpClient();
using var aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null, httpClient);
```

Aspose.Slides обычно используется в синхронных средах. Чтобы поддержать это, класс [SlidesAIAgent](https://reference.aspose.com/slides/ru/net/aspose.slides.ai/slidesaiagent/) предоставляет как синхронные, так и асинхронные методы — позволяя выбрать подход, который лучше всего соответствует рабочему процессу вашего приложения.

## **Ключевые преимущества**

Aspose.Slides [Presentation Translation API](https://reference.aspose.com/slides/ru/net/aspose.slides.ai/) предоставляет решение на основе ИИ для создания многоязычных презентаций PowerPoint. Автоматизируя перевод при сохранении макета и дизайна, оно экономит время и минимизирует ошибки по сравнению с ручными процессами. Независимо от того, являетесь ли вы разработчиком, преподавателем или бизнес‑профессионалом, этот API позволяет создавать привлекательные локализованные презентации для глобальной аудитории — расширяя ваш охват и улучшая коммуникацию.