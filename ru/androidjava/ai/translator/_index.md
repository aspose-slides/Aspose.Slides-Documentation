---
title: "Транслятор презентаций с поддержкой ИИ"
linktitle: "Транслятор с поддержкой ИИ"
type: docs
weight: 20
url: /ru/androidjava/ai/translator/
keywords:
- "переводчик презентаций на ИИ"
- "переводчик слайдов на ИИ"
- "функция с поддержкой ИИ"
- "многоязычная презентация"
- "многоязычный слайд"
- "перевод презентаций"
- "перевод слайда"
- "функции на основе ИИ"
- "возможности ИИ"
- "агент ИИ"
- "веб‑клиент"
- "PowerPoint"
- "OpenDocument"
- "презентация"
- "Android"
- "Java"
- "Aspose.Slides"
description: "Переводите слайды PowerPoint с помощью ИИ, используя Aspose.Slides для Android на Java. Локализуйте PPT, PPTX и ODP, сохраняя макет — быстро и удобно для разработчиков. Попробуйте."
---
## **Введение**

Aspose.Slides — мощный API для программного управления презентациями PowerPoint. Помимо создания, редактирования и конвертации слайдов, он предлагает функции, основанные на ИИ, такие как API перевода презентаций для мультиязычного содержания слайдов.

## **Как это работает**

Aspose.Slides не включает встроенные возможности ИИ, а интегрируется с внешними моделями ИИ через интернет. Эта функциональность доступна через класс [SlidesAIAgent](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/slidesaiagent/), который использует реализацию интерфейса [IAIWebClient](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iaiwebclient/) для общения с сервисами ИИ.

Вы можете использовать встроенный [OpenAIWebClient](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/openaiwebclient/) для подключения к API OpenAI или реализовать собственный [IAIWebClient](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iaiwebclient/) для использования другого поставщика ИИ или языковой модели.

Aspose.Slides обрабатывает коммуникацию, разбирает ответы ИИ и интеллектуально вставляет переведённый контент, сохраняющий исходную макет и форматирование слайдов.

{{% alert color="info" %}}
Обратите внимание, что API OpenAI является платным сервисом, поэтому вам понадобится создать аккаунт и указать ваш API‑ключ при использовании встроенного [OpenAIWebClient](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/openaiwebclient/).
{{% /alert %}}

## **Пример**

В этом примере мы переводим презентацию PowerPoint на японский язык, используя встроенный [OpenAIWebClient](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/openaiwebclient/) с указанной моделью OpenAI [model](https://platform.openai.com/docs/models).

```java
import com.aspose.slides.*;

// Загрузите презентацию для перевода.
Presentation presentation = new Presentation("sample.pptx");

// Создайте AI‑клиент с OpenAIWebClient, указав вашу модель и API‑ключ.
OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null);

try {
    // Инициализируйте SlidesAIAgent с AI‑клиентом.
    SlidesAIAgent aiAgent = new SlidesAIAgent(aiWebClient);

    // Переведите презентацию на японский язык.
    aiAgent.translate(presentation, "japanese");

    // Сохраните переведённую презентацию в формате PDF.
    presentation.save("sample_jp.pdf", SaveFormat.Pdf);
} finally {
    aiWebClient.close();
    presentation.dispose();
}
```

По умолчанию встроенный [OpenAIWebClient](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/openaiwebclient/) создаёт и управляет собственным внутренним экземпляром [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html), автоматически обрабатывая его жизненный цикл. Однако, если вы предпочитаете управлять [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) самостоятельно — например, для настройки прокси, использования [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) или другого [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) с лучшим управлением ресурсами и производительностью — вы можете передать собственный экземпляр `HttpURLConnection` при построении [OpenAIWebClient](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/openaiwebclient/).

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.net.HttpURLConnection;
import java.net.URI;

try {
    // Настройте экземпляр HttpURLConnection самостоятельно (например, с пользовательскими тайм-аутами, настройками прокси и т.д.).
    HttpURLConnection urlConnection = (HttpURLConnection) URI.create("https://api.openai.com/v1/chat/completions").toURL().openConnection();
    urlConnection.setConnectTimeout(10000);
    urlConnection.setReadTimeout(60000);

    // Передайте соединение конструктору OpenAIWebClient.
    OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null, urlConnection);
} catch (IOException e) {
    e.printStackTrace();
}
```

## **Ключевые преимущества**

API перевода презентаций Aspose.Slides предлагает решение на основе ИИ для предоставления мультиязычных презентаций PowerPoint. Автоматизируя перевод при сохранении макета и дизайна, он экономит время и минимизирует ошибки по сравнению с ручными процессами. Независимо от того, разработчик вы, преподаватель или бизнес‑профессионал, этот API позволяет создавать привлекательные локализованные презентации для глобальной аудитории — расширяя охват и улучшая коммуникацию.