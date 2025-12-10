---
title: Переводчик презентаций с поддержкой ИИ
linktitle: Переводчик с поддержкой ИИ
type: docs
weight: 20
url: /ru/java/ai/translator/
keywords:
- ИИ переводчик презентаций
- ИИ переводчик слайдов
- функция с поддержкой ИИ
- многоязычная презентация
- многоязычный слайд
- перевод презентации
- перевод слайда
- функции, управляемые ИИ
- возможности ИИ
- агент ИИ
- веб-клиент
- PowerPoint
- OpenDocument
- презентация
- Java
- Aspose.Slides
description: "Переведите слайды PowerPoint с помощью ИИ, используя Aspose.Slides для Java. Локализуйте PPT, PPTX и ODP, сохраняя макет—быстро и удобно для разработчиков. Попробуйте."
---

## **Aspose.Slides Presentation Translation API: AI‑поддерживаемый многоязычный перевод слайдов**

Aspose.Slides — мощный API для программного управления презентациями PowerPoint. Помимо создания, редактирования и конвертации слайдов, он предлагает функции на основе ИИ — такие как API перевода презентаций для многоязычного содержания слайдов.

## **Как это работает**

Aspose.Slides не включает встроенные возможности ИИ, а интегрируется с внешними моделями ИИ через интернет. Эта функциональность предоставляется через класс [SlidesAIAgent](https://reference.aspose.com/slides/java/com.aspose.slides/slidesaiagent/), который использует реализацию интерфейса [IAIWebClient](https://reference.aspose.com/slides/java/com.aspose.slides/iaiwebclient/) для связи с AI‑сервисами.

Вы можете использовать встроенный [OpenAIWebClient](https://reference.aspose.com/slides/java/com.aspose.slides/openaiwebclient/) для подключения к API OpenAI или реализовать собственный [IAIWebClient](https://reference.aspose.com/slides/java/com.aspose.slides/iaiwebclient/) для использования другого поставщика ИИ или языковой модели.

Aspose.Slides обрабатывает связь, парсит ответы ИИ и интеллектуально вставляет переведённый контент, сохраняя исходный макет и форматирование слайдов.

{{% alert color="primary" %}}
Обратите внимание, что API OpenAI является платным сервисом, поэтому вам потребуется создать учётную запись и предоставить ваш API‑ключ при использовании встроенного [OpenAIWebClient](https://reference.aspose.com/slides/java/com.aspose.slides/openaiwebclient/).
{{% /alert %}}

## **Пример**

В этом примере мы переводим презентацию PowerPoint на японский язык, используя встроенный [OpenAIWebClient](https://reference.aspose.com/slides/java/com.aspose.slides/openaiwebclient/) с указанной OpenAI [модель](https://platform.openai.com/docs/models).
```java
// Загрузить презентацию для перевода.
Presentation presentation = new Presentation("sample.pptx");

// Create an AI client with OpenAIWebClient, specifying your model and API key.
OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null);

try {
    // Инициализировать SlidesAIAgent с AI клиентом.
    SlidesAIAgent aiAgent = new SlidesAIAgent(aiWebClient);

    // Перевести презентацию на японский язык.
    aiAgent.translate(presentation, "japanese");

    // Сохранить переведенную презентацию в формате PDF.
    presentation.save("sample_jp.pdf", SaveFormat.Pdf);
} finally {
    aiWebClient.close();
    presentation.dispose();
}
```


По умолчанию встроенный [OpenAIWebClient](https://reference.aspose.com/slides/java/com.aspose.slides/openaiwebclient/) создаёт и управляет собственным внутренним объектом [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html), автоматически контролируя его жизненный цикл. Однако, если вы предпочитаете управлять [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) самостоятельно — в первую очередь для настройки таких параметров, как прокси, или для использования [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) или другого [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) с целью лучшего управления ресурсами и производительности — вы можете предоставить свой собственный экземпляр `HttpURLConnection` при создании [OpenAIWebClient](https://reference.aspose.com/slides/java/com.aspose.slides/openaiwebclient/).
```java
// Предположим, у вас есть предварительно настроенный экземпляр HttpURLConnection (например, с пользовательскими тайм-аутами, настройками прокси и т.д.).
HttpURLConnection urlConnection = yourPreconfiguredConnection;
OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null, urlConnection);
```


## **Ключевые преимущества**

Aspose.Slides Presentation Translation API предлагает решение на основе ИИ для создания многоязычных презентаций PowerPoint. Автоматизируя перевод и сохраняя макет и дизайн, он экономит время и снижает количество ошибок по сравнению с ручными процессами. Независимо от того, являетесь ли вы разработчиком, преподавателем или бизнес‑профессионалом, этот API позволяет создавать привлекательные локализованные презентации для глобальной аудитории — расширяя охват и улучшая коммуникацию.