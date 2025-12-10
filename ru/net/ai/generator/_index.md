---
title: Генератор многоязычных слайдов на основе ИИ
linktitle: Генератор на основе ИИ
type: docs
weight: 40
url: /ru/net/ai/generator/
keywords:
- многоязычная презентация
- многоязычный слайд
- генератор презентаций на основе ИИ
- генератор слайдов на основе ИИ
- функция на основе ИИ
- ИИ‑агент
- PowerPoint
- OpenDocument
- презентация
- .NET
- C#
- Aspose.Slides
description: "Создавайте многоязычные слайды из текста с помощью Aspose.Slides для .NET. Применяйте свой шаблон и экспортируйте отполированные наборы в PowerPoint и OpenDocument. Узнайте больше."
---

## **Aspose.Slides Presentation AI API: генератор слайдов на основе ИИ**

Aspose.Slides представляет новую функцию, основанную на ИИ, — Presentation Generator, которая позволяет разработчикам автоматически создавать хорошо структурированные презентации PowerPoint из простых текстовых вводов, таких как описания тем, резюме, цитаты или маркированные списки.

Пользователи могут регулировать уровень детализации содержания и при необходимости применять пользовательский шаблон презентации для определения визуального дизайна.

В текущей версии AI Presentation Generator структурирует содержание с помощью текстовых блоков, маркированных списков и таблиц. Генерация изображений пока не поддерживается; однако изображения можно легко добавить позже с помощью инструментов Aspose.Slides или вручную.

В результате получается готовая презентация PowerPoint, которую можно использовать сразу или экспортировать в любой формат, поддерживаемый API Aspose.Slides. Хотя генератор выдаёт результаты высокого качества, может потребоваться небольшая постобработка для удовлетворения конкретных требований.

## **Как это работает**

Aspose.Slides не содержит встроенных моделей ИИ; вместо этого он интегрируется с внешними AI‑сервисами через интернет. Эта интеграция реализована классом [SlidesAIAgent](https://reference.aspose.com/slides/net/aspose.slides.ai/slidesaiagent/), который использует реализацию интерфейса [IAIWebClient](https://reference.aspose.com/slides/net/aspose.slides.ai/iaiwebclient/) для взаимодействия с AI‑моделью.

Вы можете использовать встроенный [OpenAIWebClient](https://reference.aspose.com/slides/net/aspose.slides.ai/openaiwebclient/), который подключается к API OpenAI, или предоставить собственную реализацию [IAIWebClient](https://reference.aspose.com/slides/net/aspose.slides.ai/iaiwebclient/) для работы с другим поставщиком ИИ или языковой моделью. Aspose.Slides управляет всей коммуникацией с AI‑сервисом и обрабатывает ответы ИИ для создания слайдов. Обратите внимание, что API OpenAI является платным сервисом, поэтому при использовании встроенного [OpenAIWebClient](https://reference.aspose.com/slides/net/aspose.slides.ai/openaiwebclient/) требуется учетная запись и ключ API.

## **Пишем код**

### **Пример 1**

Этот пример демонстрирует, как сгенерировать презентацию по теме Aspose.Slides с использованием встроенного [OpenAIWebClient](https://reference.aspose.com/slides/net/aspose.slides.ai/openaiwebclient/).

```csharp
// Create an instance of OpenAIWebClient, the built-in implementation of the OpenAI web client.
using var aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null);

// Create an instance of SlidesAIAgent, which provides access to AI-powered features.
var aiAgent = new SlidesAIAgent(aiWebClient);

// Define the instruction for generating the presentation.
var instruction = "Generate a presentation about Aspose.Slides for .NET, highlighting its capabilities and advantages over competitors.";

// Generate a presentation with a medium amount of content based on the instruction.
using IPresentation presentation = await aiAgent.GeneratePresentationAsync(instruction, PresentationContentAmountType.Medium);

// Save the generated presentation to the local disk as a PowerPoint (.pptx) file.
presentation.Save("Aspose.Slides.NET.pptx", SaveFormat.Pptx);
```

### **Пример 2**

Следующий пример демонстрирует перегрузки метода [GeneratePresentation](https://reference.aspose.com/slides/net/aspose.slides.ai/slidesaiagent/generatepresentation/). В данном случае используется внешне управляемый экземпляр [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient) и `master presentation` пользователя.

По умолчанию встроенный [OpenAIWebClient](https://reference.aspose.com/slides/net/aspose.slides.ai/openaiwebclient/) создает и управляет собственным внутренним экземпляром [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient), автоматически обрабатывая его жизненный цикл и освобождение ресурсов. Однако, если вы предпочитаете самостоятельно управлять [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient) — например, используя [IHttpClientFactory](https://learn.microsoft.com/en-us/dotnet/core/extensions/httpclient-factory) для улучшенного управления ресурсами и производительности — вы можете передать свой экземпляр [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient) при построении [OpenAIWebClient](https://reference.aspose.com/slides/net/aspose.slides.ai/openaiwebclient/).

```csharp
// Create an externally managed HttpClient instance.
using var httpClient = new HttpClient();

// Pass the HttpClient to the OpenAIWebClient constructor.
using var aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", "organizationId", httpClient);

// Create an instance of SlidesAIAgent.
var aiAgent = new SlidesAIAgent(aiWebClient);

// Define the instruction for generating the presentation.
var instruction = "Generate a presentation about Aspose.Slides for .NET, highlighting its capabilities and advantages over competitors.";

// Load a master presentation from the local disk to use as the design template.
using var masterPresentation = new Presentation("masterPresentation.pptx");

// Generate a detailed presentation using the instruction and master template.
using IPresentation presentation = await aiAgent.GeneratePresentationAsync(instruction, PresentationContentAmountType.Detailed, masterPresentation);

// Save the generated presentation as a PDF.
presentation.Save("Aspose.Slides.NET.pdf", SaveFormat.Pdf);
```

Стоит отметить, что многие клиенты используют Aspose.Slides в синхронных контекстах. Чтобы поддержать это, класс [SlidesAIAgent](https://reference.aspose.com/slides/net/aspose.slides.ai/slidesaiagent/) предоставляет как синхронные, так и асинхронные методы, позволяя выбрать подход, наиболее соответствующий рабочему процессу вашего приложения.

## **Ключевые преимущества**

Новый AI Presentation Generator в Aspose.Slides предлагает быстрый и гибкий способ создания структурированных наборов слайдов из простых текстовых подсказок. Поддержка пользовательских шаблонов, внешне управляемых экземпляров [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient) и как синхронных, так и асинхронных рабочих процессов позволяет без проблем интегрировать его в широкий спектр приложений.

Типичные сценарии использования включают создание маркетинговых презентаций, учебных материалов, отчетов для клиентов и внутренних наборов слайдов. Хотя генерация изображений пока не поддерживается, инструмент уже предоставляет прочную основу для автоматизации создания презентаций, а в дальнейшем ожидаются дополнительные улучшения.