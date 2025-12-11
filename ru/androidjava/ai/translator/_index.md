---
title: Переводчик презентаций на основе ИИ
linktitle: Переводчик на основе ИИ
type: docs
weight: 20
url: /ru/androidjava/ai/translator/
keywords:
- Переводчик презентаций ИИ
- Переводчик слайдов ИИ
- Функция на основе ИИ
- Многоязычная презентация
- Многоязычный слайд
- Перевод презентаций
- Перевод слайдов
- Функции, управляемые ИИ
- Возможности ИИ
- Агент ИИ
- Веб‑клиент
- PowerPoint
- OpenDocument
- презентация
- Android
- Java
- Aspose.Slides
description: "Переводите слайды PowerPoint с помощью ИИ, используя Aspose.Slides для Android на Java. Локализуйте PPT, PPTX и ODP, сохраняя раскладку — быстро и удобно для разработчиков. Попробуйте."
---

## **Aspose.Slides API перевода презентаций: AI-управляемый многоязычный перевод слайдов**

Aspose.Slides — мощный API для программного управления презентациями PowerPoint. Помимо создания, редактирования и конвертации слайдов, он предлагает функции на основе ИИ — такие как API перевода презентаций для многоязычного контента слайдов.

## **Как это работает**

Aspose.Slides не включает встроенные возможности ИИ, а интегрируется с внешними моделями ИИ через интернет. Эта функциональность предоставлена через класс [SlidesAIAgent](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidesaiagent/), который использует реализацию интерфейса [IAIWebClient](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaiwebclient/) для взаимодействия с сервисами ИИ.

Вы можете использовать встроенный [OpenAIWebClient](https://reference.aspose.com/slides/androidjava/com.aspose.slides/openaiwebclient/) для подключения к API OpenAI или реализовать свой собственный [IAIWebClient](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaiwebclient/) для работы с другим поставщиком ИИ или языковой моделью.

Aspose.Slides обрабатывает коммуникацию, разбирает ответы ИИ и интеллектуально вставляет переведённый контент, сохраняя оригинальное расположение и форматирование слайдов.

{{% alert color="primary" %}}
Обратите внимание, что API OpenAI является платным сервисом, поэтому вам понадобится создать учётную запись и указать свой API‑ключ при использовании встроенного [OpenAIWebClient](https://reference.aspose.com/slides/androidjava/com.aspose.slides/openaiwebclient/).
{{% /alert %}}

## **Пример**

В этом примере мы переводим презентацию PowerPoint на японский язык, используя встроенный [OpenAIWebClient](https://reference.aspose.com/slides/androidjava/com.aspose.slides/openaiwebclient/) с указанной моделью OpenAI [model](https://platform.openai.com/docs/models).
```java
// Загрузить презентацию для перевода.
Presentation presentation = new Presentation("sample.pptx");

// Создать AI‑клиент с OpenAIWebClient, указав модель и API‑ключ.
OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null);

try {
    // Инициализировать SlidesAIAgent с AI‑клиентом.
    SlidesAIAgent aiAgent = new SlidesAIAgent(aiWebClient);

    // Перевести презентацию на японский.
    aiAgent.translate(presentation, "japanese");

    // Сохранить переведённую презентацию как PDF.
    presentation.save("sample_jp.pdf", SaveFormat.Pdf);
} finally {
    aiWebClient.close();
    presentation.dispose();
}
```


По умолчанию встроенный [OpenAIWebClient](https://reference.aspose.com/slides/androidjava/com.aspose.slides/openaiwebclient/) создаёт и управляет собственным внутренним экземпляром [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html), автоматически контролируя его жизненный цикл. Однако если вы предпочитаете управлять [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) самостоятельно — например, чтобы настроить обязательные параметры, такие как прокси, или использовать [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) или иной [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) для лучшего управления ресурсами и производительности — вы можете передать свой собственный экземпляр `HttpURLConnection` при создании [OpenAIWebClient](https://reference.aspose.com/slides/androidjava/com.aspose.slides/openaiwebclient/).
```java
// Предположим, что у вас есть предварительно сконфигурированный экземпляр HttpURLConnection (например, с пользовательскими тайм-аутами, настройками прокси и т.д.).
HttpURLConnection urlConnection = yourPreconfiguredConnection;
OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null, urlConnection);
```


## **Ключевые преимущества**

Aspose.Slides API перевода презентаций предлагает решение с поддержкой ИИ для создания многоязычных презентаций PowerPoint. Автоматизируя перевод и одновременно сохраняя макет и дизайн, оно экономит время и уменьшает количество ошибок по сравнению с ручными процессами. Независимо от того, являетесь ли вы разработчиком, преподавателем или бизнес‑профессионалом, этот API позволяет создавать привлекательные локализованные презентации для глобальной аудитории — расширяя охват и улучшая коммуникацию.