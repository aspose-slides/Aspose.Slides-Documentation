---
title: Переводчик презентаций с поддержкой ИИ
linktitle: Переводчик с поддержкой ИИ
type: docs
weight: 20
url: /ru/net/ai/translator/
keywords:
- Переводчик презентаций ИИ
- Переводчик слайдов ИИ
- Функция с поддержкой ИИ
- Многоязычная презентация
- Многоязычный слайд
- Перевод презентации
- Перевод слайда
- Функции, управляемые ИИ
- Возможности ИИ
- ИИ‑агент
- Веб‑клиент
- PowerPoint
- OpenDocument
- презентация
- .NET
- C#
- Aspose.Slides
description: "Переводите слайды PowerPoint с помощью ИИ, используя Aspose.Slides для .NET. Локализуйте PPT, PPTX и ODP, сохраняя макет — быстро и удобно для разработчиков. Попробуйте."
---
## **Введение**

Aspose.Slides — мощный API для программного управления презентациями PowerPoint. Помимо создания, редактирования и конвертации слайдов, он предлагает функции на основе ИИ, такие как [Presentation Translation API](https://reference.aspose.com/slides/ru/net/aspose.slides.ai/) для многоязычного контента слайдов.

## **Как это работает**

Aspose.Slides не содержит встроенных возможностей ИИ, а интегрируется с внешними AI‑моделями через интернет. Эта функциональность предоставляется классом [SlidesAIAgent](https://reference.aspose.com/slides/ru/net/aspose.slides.ai/slidesaiagent), который использует реализацию интерфейса [IAIWebClient](https://reference.aspose.com/slides/ru/net/aspose.slides.ai/iaiwebclient/) для общения с AI‑службами.

Вы можете использовать встроенный [OpenAIWebClient](https://reference.aspose.com/slides/ru/net/aspose.slides.ai/openaiwebclient/) для подключения к API OpenAI или реализовать собственный [IAIWebClient](https://reference.aspose.com/slides/ru/net/aspose.slides.ai/iaiwebclient/) для использования другого поставщика ИИ или языковой модели.

Aspose.Slides обрабатывает связь, разбирает ответы ИИ и интеллектуально вставляет переведённый контент, сохраняя оригинальное расположение и форматирование слайдов.

{{% alert color="info" title="Note" %}}
Обратите внимание, что API OpenAI является платным сервисом, поэтому вам потребуется создать учётную запись и указать свой API‑ключ при использовании встроенного [OpenAIWebClient](https://reference.aspose.com/slides/ru/net/aspose.slides.ai/openaiwebclient/).
{{% /alert %}}

## **Пример**

В этом примере мы переводим презентацию PowerPoint на японский язык, используя встроенный [OpenAIWebClient](https://reference.aspose.com/slides/ru/net/aspose.slides.ai/openaiwebclient/) с указанной OpenAI [модель](https://platform.openai.com/docs/models).

```csharp
using Aspose.Slides;
using Aspose.Slides.AI;
using Aspose.Slides.Export;

// Загрузить презентацию для перевода.
using var presentation = new Presentation("sample.pptx");

// Создать AI-клиент с OpenAIWebClient, указав модель и API-ключ.
using var aiWebClient = new OpenAIWebClient(model: "gpt-4o-mini", apiKey: "apiKey", organizationId: null);

// Инициализировать SlidesAIAgent с AI-клиентом.
var aiAgent = new SlidesAIAgent(aiWebClient);

// Перевести презентацию на японский.
await aiAgent.TranslateAsync(presentation, "japanese");

// Сохранить переведенную презентацию в формате PDF.
presentation.Save("sample_jp.pdf", SaveFormat.Pdf);
```

По умолчанию встроенный [OpenAIWebClient](https://reference.aspose.com/slides/ru/net/aspose.slides.ai/openaiwebclient/) создаёт и управляет собственным внутренним экземпляром [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient), автоматически обрабатывая его жизненный цикл и освобождение ресурсов. Однако, если вы предпочитаете управлять [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient) самостоятельно — например, используя [IHttpClientFactory](https://learn.microsoft.com/en-us/dotnet/core/extensions/httpclient-factory) для лучшего управления ресурсами и производительности — вы можете предоставить свой экземпляр `HttpClient` при создании [OpenAIWebClient](https://reference.aspose.com/slides/ru/net/aspose.slides.ai/openaiwebclient/).

```csharp
using System.Net.Http;
using Aspose.Slides.AI;

// Используйте HttpClient, которым вы управляете самостоятельно — например, созданный через IHttpClientFactory
// внедрённый через dependency injection.
HttpClient httpClient = new HttpClient();
using var aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null, httpClient);
```

Aspose.Slides часто используется в синхронных средах. Чтобы поддержать это, класс [SlidesAIAgent](https://reference.aspose.com/slides/ru/net/aspose.slides.ai/slidesaiagent/) предоставляет как синхронные, так и асинхронные методы — позволяя выбрать подход, который наилучшим образом соответствует рабочему процессу вашего приложения.

### **Azure OpenAI Пример**

Aspose.Slides для .NET поддерживает поставщиков, совместимых с OpenAI, включая Azure OpenAI. Вы можете настроить переводчик для использования вашего собственного развертывания Azure с помощью [OpenAICompatibleWebClient](https://reference.aspose.com/slides/ru/net/aspose.slides.ai/openaicompatiblewebclient/).

```csharp
using Aspose.Slides;
using Aspose.Slides.AI;
using Aspose.Slides.Export;

var model = "your-azure-deployment-name";
var apiKey = "your-azure-api-key";
var baseUrl = "https://your-resource.openai.azure.com/openai/v1/";

using var aiWebClient = new OpenAICompatibleWebClient(model, apiKey, baseUrl);
var aiAgent = new SlidesAIAgent(aiWebClient);
using var presentation = new Presentation("Presentation.pptx");
aiAgent.Translate(presentation, "spanish");
presentation.Save("Translated.pptx", SaveFormat.Pptx);
```

Этот фрагмент демонстрирует перевод презентации с использованием вашего конечного пункта Azure OpenAI. Замените значения заполнителей на имя развертывания, API‑ключ и URL конечного пункта.

## **Ключевые преимущества**

API [Presentation Translation API](https://reference.aspose.com/slides/ru/net/aspose.slides.ai/) Aspose.Slides предоставляет решение на основе ИИ для создания многоязычных презентаций PowerPoint. Автоматизируя перевод и сохраняюя макет и дизайн, оно экономит время и уменьшает количество ошибок по сравнению с ручными процессами. Независимо от того, являетесь ли вы разработчиком, преподавателем или бизнес‑профессионалом, этот API позволяет создавать интересные, локализованные презентации для глобальной аудитории — расширяя охват и улучшая коммуникацию.