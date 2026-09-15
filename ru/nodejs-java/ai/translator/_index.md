---
title: Переводчик презентаций на основе ИИ
linktitle: Переводчик на основе ИИ
type: docs
weight: 20
url: /ru/nodejs-java/ai/translator/
keywords:
- AI переводчик презентаций
- AI переводчик слайдов
- функция, основанная на ИИ
- многоязычная презентация
- многоязычный слайд
- перевод презентации
- перевод слайда
- функции, управляемые ИИ
- возможности ИИ
- агент ИИ
- веб‑клиент
- PowerPoint
- OpenDocument
- презентация
- Node.js
- JavaScript
- Aspose.Slides
description: "Переводите слайды PowerPoint с помощью ИИ, используя Aspose.Slides для Node.js. Локализуйте PPT, PPTX и ODP, сохраняя макет — быстро и удобно для разработчиков. Попробуйте."
---
## **Введение**

Aspose.Slides — мощный API для программного управления презентациями PowerPoint. Помимо создания, редактирования и конвертации слайдов, он предлагает функции на основе ИИ — такие как API перевода презентаций для многоязычного содержания слайдов.

## **Как это работает**

Aspose.Slides не содержит встроенных возможностей ИИ, но интегрируется с внешними моделями ИИ через интернет. Эта функция доступна через класс [SlidesAIAgent](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/slidesaiagent/) для взаимодействия с сервисами ИИ.

Вы можете использовать встроенный [OpenAIWebClient](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/openaiwebclient/) для подключения к API OpenAI.

Aspose.Slides обрабатывает связь, разбирает ответы ИИ и интеллектуально вставляет переведённый контент, сохраняя исходную компоновку и форматирование слайда.

{{% alert color="info" title="Примечание" %}}

Обратите внимание, что API OpenAI является платным сервисом, поэтому вам потребуется создать учётную запись и указать ваш API‑ключ при использовании встроенного [OpenAIWebClient](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/openaiwebclient/).

{{% /alert %}}

## **Пример**

В этом примере мы переводим презентацию PowerPoint на японский язык с помощью встроенного [OpenAIWebClient](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/openaiwebclient/) и указанной модели OpenAI [model](https://platform.openai.com/docs/models).

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Загрузите презентацию для перевода.
let presentation = new aspose.slides.Presentation("sample.pptx");

// Создайте AI‑клиент с OpenAIWebClient, указав вашу модель и API‑ключ.
let aiWebClient = new aspose.slides.OpenAIWebClient("gpt-4o-mini", "apiKey", null);

try {
    // Инициализируйте SlidesAIAgent с AI‑клиентом.
    let aiAgent = new aspose.slides.SlidesAIAgent(aiWebClient);

    // Переведите презентацию на японский язык.
    aiAgent.translate(presentation, "japanese");

    // Сохраните переведённую презентацию как PDF.
    presentation.save("sample_jp.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    aiWebClient.close();
    presentation.dispose();
}
```

По умолчанию встроенный [OpenAIWebClient](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/openaiwebclient/) создаёт и управляет собственной внутренней экземпляром [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html), автоматически контролируя его жизненный цикл. Однако, если вы предпочитаете управлять [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) самостоятельно — например, чтобы настроить прокси, использовать [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) или другой [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) для лучшего управления ресурсами и производительности — вы можете передать свой собственный экземпляр `HttpURLConnection` при создании [OpenAIWebClient](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/openaiwebclient/).

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Создайте и предварительно настройте экземпляр HttpURLConnection (например, с пользовательскими тайм‑аутами, настройками прокси и т.д.)
let url = java.newInstanceSync("java.net.URL", "https://api.openai.com/v1/chat/completions");
let urlConnection = url.openConnection();
urlConnection.setConnectTimeout(10000);
urlConnection.setReadTimeout(60000);

let aiWebClient = new aspose.slides.OpenAIWebClient("gpt-4o-mini", "apiKey", null, urlConnection);
```

### **Пример Azure OpenAI**

Вы можете настроить переводчик для использования вашего развертывания Azure OpenAI с помощью [OpenAICompatibleWebClient](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/openaicompatiblewebclient/).

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let model = "your-azure-deployment-name";
let apiKey = "your-azure-api-key";
let baseUrl = "https://your-resource.openai.azure.com/openai/v1/";

let aiWebClient = new aspose.slides.OpenAICompatibleWebClient(model, apiKey, baseUrl);
try {
    let aiAgent = new aspose.slides.SlidesAIAgent(aiWebClient);
    let presentation = new aspose.slides.Presentation("presentation.pptx");
    try {
        aiAgent.translate(presentation, "spanish");
        presentation.save("Translated.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
} finally {
    aiWebClient.dispose();
}
```

Этот фрагмент кода демонстрирует перевод презентации с использованием вашего конечного адреса Azure OpenAI. Замените значения‑заполнители на имя вашего развертывания, API‑ключ и URL конечной точки.

## **Ключевые преимущества**

API перевода презентаций Aspose.Slides предлагает решение на базе ИИ для создания многоязычных презентаций PowerPoint. Автоматизируя перевод и сохраняя макет и дизайн, он экономит время и уменьшает количество ошибок по сравнению с ручными процессами. Независимо от того, являетесь ли вы разработчиком, преподавателем или бизнес‑профессионалом, этот API позволяет создавать привлекательные локализованные презентации для глобальной аудитории — расширяя охват и улучшая коммуникацию.