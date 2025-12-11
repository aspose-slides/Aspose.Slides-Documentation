---
title: Переводчик презентаций с поддержкой ИИ
linktitle: Переводчик с поддержкой ИИ
type: docs
weight: 20
url: /ru/androidjava/ai/translator/
keywords:
- Переводчик презентаций ИИ
- Переводчик слайдов ИИ
- Функция на основе ИИ
- Многоязычная презентация
- Многоязычный слайд
- Перевод презентации
- Перевод слайда
- Функции, управляемые ИИ
- Возможности ИИ
- агент ИИ
- Веб‑клиент
- PowerPoint
- OpenDocument
- презентация
- Android
- Java
- Aspose.Slides
description: "Переводите слайды PowerPoint с помощью ИИ, используя Aspose.Slides для Android на Java. Локализуйте PPT, PPTX и ODP, сохраняя макет — быстро и удобно для разработчиков. Попробуйте."
---

## **API Перевода Презентаций Aspose.Slides: AI-управляемый Многоязычный Перевод Слайдов**

Aspose.Slides — мощный API для программного управления презентациями PowerPoint. Помимо создания, редактирования и конвертации слайдов, он предоставляет функции на основе ИИ — такие как API Перевода Презентаций для многоязычного контента слайдов.

## **Как это работает**

Aspose.Slides не включает встроенные возможности ИИ, а интегрируется с внешними моделями ИИ через интернет. Эта функция доступна через класс [SlidesAIAgent](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidesaiagent/), который использует реализацию интерфейса [IAIWebClient](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaiwebclient/) для связи с сервисами ИИ.

Вы можете использовать встроенный [OpenAIWebClient](https://reference.aspose.com/slides/androidjava/com.aspose.slides/openaiwebclient/) для подключения к API OpenAI или реализовать собственный [IAIWebClient](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaiwebclient/) для использования другого поставщика ИИ или языковой модели.

Aspose.Slides обрабатывает коммуникацию, разбирает ответы ИИ и интеллектуально вставляет переведённый контент, сохраняя оригинальное расположение элементов слайда и форматирование.

{{% alert color="primary" %}}
Обратите внимание, что API OpenAI — платный сервис, поэтому для использования встроенного [OpenAIWebClient](https://reference.aspose.com/slides/androidjava/com.aspose.slides/openaiwebclient/) вам потребуется создать учётную запись и указать ваш API‑ключ.
{{% /alert %}}

## **Пример**

В этом примере мы переводим презентацию PowerPoint на японский язык, используя встроенный [OpenAIWebClient](https://reference.aspose.com/slides/androidjava/com.aspose.slides/openaiwebclient/) с указанной моделью OpenAI [model](https://platform.openai.com/docs/models).
```java
// Загрузите презентацию для перевода.
Presentation presentation = new Presentation("sample.pptx");

// Создайте AI‑клиент с OpenAIWebClient, указав вашу модель и API‑ключ.
OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null);

try {
    // Инициализируйте SlidesAIAgent с AI‑клиентом.
    SlidesAIAgent aiAgent = new SlidesAIAgent(aiWebClient);

    // Переведите презентацию на японский язык.
    aiAgent.translate(presentation, "japanese");

    // Сохраните переведённую презентацию в PDF.
    presentation.save("sample_jp.pdf", SaveFormat.Pdf);
} finally {
    aiWebClient.close();
    presentation.dispose();
}
```


По умолчанию встроенный [OpenAIWebClient](https://reference.aspose.com/slides/androidjava/com.aspose.slides/openaiwebclient/) создаёт и управляет собственной внутренней инстанцией [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html), автоматически обрабатывая её жизненный цикл. Однако если вы хотите управлять [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) самостоятельно — например, чтобы настроить прокси, использовать [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) или другой [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) для лучшего управления ресурсами и повышения производительности — вы можете передать свою собственную инстанцию `HttpURLConnection` при построении [OpenAIWebClient](https://reference.aspose.com/slides/androidjava/com.aspose.slides/openaiwebclient/).
```java
// Предположим, у вас есть предварительно настроенный экземпляр HttpURLConnection (например, с пользовательскими таймаутами, настройками прокси и т.д.)
HttpURLConnection urlConnection = yourPreconfiguredConnection;
OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null, urlConnection);
```


## **Ключевые преимущества**

API Перевода Презентаций Aspose.Slides предлагает решение на основе ИИ для создания многоязычных презентаций PowerPoint. Автоматизируя перевод и одновременно сохраняя макет и дизайн, он экономит время и минимизирует ошибки по сравнению с ручными рабочими процессами. Независимо от того, разработчик вы, преподаватель или бизнес‑профессионал, этот API позволяет создавать привлекательные локализованные презентации для глобальной аудитории, расширяя охват и улучшая коммуникацию.