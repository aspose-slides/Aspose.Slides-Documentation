---
title: Переводчик презентаций на основе ИИ
linktitle: Переводчик на основе ИИ
type: docs
weight: 20
url: /ru/net/ai/translator/
keywords:
- Переводчик презентаций на основе ИИ
- Переводчик слайдов на основе ИИ
- Функция на основе ИИ
- Многоязычная презентация
- Многоязычный слайд
- Перевод презентаций
- Перевод слайдов
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
description: "Переводите слайды PowerPoint с помощью ИИ, используя Aspose.Slides для .NET. Локализуйте PPT, PPTX и ODP, сохраняя макет—быстро и удобно для разработчиков. Попробуйте."
---

## **Aspose.Slides Presentation Translation API: AI‑управляемый многоязычный перевод слайдов**

Aspose.Slides — мощный API для программного управления презентациями PowerPoint. Помимо создания, редактирования и конвертации слайдов, он предоставляет функции на основе ИИ, такие как [Presentation Translation API](https://reference.aspose.com/slides/net/aspose.slides.ai/) для многоязычного содержимого слайдов.

## **Как это работает**

Aspose.Slides не включает встроенные возможности ИИ, а интегрируется с внешними моделями ИИ через интернет. Эта функциональность предоставляется классом [SlidesAIAgent](https://reference.aspose.com/slides/net/aspose.slides.ai/slidesaiagent), который использует реализацию интерфейса [IAIWebClient](https://reference.aspose.com/slides/net/aspose.slides.ai/iaiwebclient/) для взаимодействия с сервисами ИИ.

Вы можете использовать встроенный [OpenAIWebClient](https://reference.aspose.com/slides/net/aspose.slides.ai/openaiwebclient/) для подключения к API OpenAI или реализовать собственный [IAIWebClient](https://reference.aspose.com/slides/net/aspose.slides.ai/iaiwebclient/) для использования другого поставщика ИИ или языковой модели.

Aspose.Slides обрабатывает коммуникацию, анализирует ответы ИИ и интеллектуально вставляет переведённый контент, сохраняя оригинальное расположение слайдов и их форматирование.

{{% alert color="primary" %}}
Обратите внимание, что API OpenAI является платным сервисом, поэтому вам нужно создать учётную запись и предоставить свой API‑ключ при использовании встроенного [OpenAIWebClient](https://reference.aspose.com/slides/net/aspose.slides.ai/openaiwebclient/).
{{% /alert %}}

## **Пример**

В этом примере мы переводим презентацию PowerPoint на японский язык, используя встроенный [OpenAIWebClient](https://reference.aspose.com/slides/net/aspose.slides.ai/openaiwebclient/) с указанной моделью OpenAI [model](https://platform.openai.com/docs/models).

```csharp
// Load a presentation to translate.
using var presentation = new Presentation("sample.pptx");

// Create an AI client with OpenAIWebClient, specifying your model and API key.
using var aiWebClient = new OpenAIWebClient(model: "gpt-4o-mini", apiKey: "apiKey", organizationId: null);

// Initialize SlidesAIAgent with the AI client.
var aiAgent = new SlidesAIAgent(aiWebClient);

// Translate the presentation to Japanese.
await aiAgent.TranslateAsync(presentation, "japanese");

// Save the translated presentation as a PDF.
presentation.Save("sample_jp.pdf", SaveFormat.Pdf);
```

По умолчанию встроенный [OpenAIWebClient](https://reference.aspose.com/slides/net/aspose.slides.ai/openaiwebclient/) создаёт и управляет собственным внутренним экземпляром [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient), автоматически контролируя его жизненный цикл и освобождение ресурсов. Однако, если вы предпочитаете управлять [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient) самостоятельно — например, используя [IHttpClientFactory](https://learn.microsoft.com/en-us/dotnet/core/extensions/httpclient-factory) для более эффективного управления ресурсами и производительности — вы можете передать свой собственный экземпляр `HttpClient` при создании [OpenAIWebClient](https://reference.aspose.com/slides/net/aspose.slides.ai/openaiwebclient/).

```csharp
// Assume you have an IHttpClientFactory instance (e.g., injected via dependency injection).
HttpClient httpClient = httpClientFactory.CreateClient();
using var aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null, httpClient);
```

Aspose.Slides обычно используется в синхронных средах. Чтобы поддерживать это, класс [SlidesAIAgent](https://reference.aspose.com/slides/net/aspose.slides.ai/slidesaiagent/) предоставляет как синхронные, так и асинхронные методы — позволяя выбрать подход, который лучше всего подходит для рабочего процесса вашего приложения.

## **Ключевые преимущества**

Aspose.Slides [Presentation Translation API](https://reference.aspose.com/slides/net/aspose.slides.ai/) предоставляет решение на основе ИИ для создания многоязычных презентаций PowerPoint. Автоматизируя перевод и сохраняя макет и дизайн, оно экономит время и минимизирует ошибки по сравнению с ручными процессами. Независимо от того, являетесь ли вы разработчиком, преподавателем или бизнес‑профессионалом, этот API позволяет создавать привлекательные локализованные презентации для глобальной аудитории — расширяя охват и улучшая коммуникацию.