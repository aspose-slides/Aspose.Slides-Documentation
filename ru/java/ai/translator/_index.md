---
title: Переводчик презентаций на основе ИИ
linktitle: Переводчик на основе ИИ
type: docs
weight: 20
url: /ru/java/ai/translator/
keywords:
- ИИ переводчик презентаций
- ИИ переводчик слайдов
- функция на основе ИИ
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
- Java
- Aspose.Slides
description: "Переводите слайды PowerPoint с помощью ИИ, используя Aspose.Slides для Java. Локализуйте PPT, PPTX и ODP, сохраняя макет—быстро и удобно для разработчиков. Попробуйте."
---
## **Введение**

Aspose.Slides — это мощный API для программного управления презентациями PowerPoint. Помимо создания, редактирования и конвертации слайдов, он предоставляет функции на основе ИИ, такие как API перевода презентаций для многоязычного содержимого слайдов.

## **Как это работает**

Aspose.Slides не содержит встроенных возможностей ИИ, но интегрируется с внешними моделями ИИ через интернет. Эта функциональность доступна через класс [SlidesAIAgent](https://reference.aspose.com/slides/ru/java/com.aspose.slides/slidesaiagent/), который использует реализацию интерфейса [IAIWebClient](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iaiwebclient/), чтобы взаимодействовать с сервисами ИИ.

Вы можете использовать встроенный [OpenAIWebClient](https://reference.aspose.com/slides/ru/java/com.aspose.slides/openaiwebclient/), чтобы подключиться к API OpenAI, или реализовать собственный [IAIWebClient](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iaiwebclient/), чтобы использовать другого поставщика ИИ или языковую модель.

Aspose.Slides обрабатывает коммуникацию, разбирает ответы ИИ и интеллектуально вставляет переведённое содержимое, сохраняя исходную компоновку и форматирование слайдов.

{{% alert color="info" %}}
Обратите внимание, что API OpenAI является платным сервисом, поэтому вам потребуется создать учетную запись и предоставить свой API‑ключ при использовании встроенного [OpenAIWebClient](https://reference.aspose.com/slides/ru/java/com.aspose.slides/openaiwebclient/).
{{% /alert %}}

## **Пример**

В этом примере мы переводим презентацию PowerPoint на японский язык, используя встроенный [OpenAIWebClient](https://reference.aspose.com/slides/ru/java/com.aspose.slides/openaiwebclient/) с указанной OpenAI [моделью](https://platform.openai.com/docs/models).

```java
import com.aspose.slides.*;

// Загрузить презентацию для перевода.
Presentation presentation = new Presentation("sample.pptx");

// Создать AI‑клиент с OpenAIWebClient, указав модель и API‑ключ.
OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null);

try {
    // Инициализировать SlidesAIAgent с клиентом ИИ.
    SlidesAIAgent aiAgent = new SlidesAIAgent(aiWebClient);

    // Перевести презентацию на японский.
    aiAgent.translate(presentation, "japanese");

    // Сохранить переведённую презентацию в формате PDF.
    presentation.save("sample_jp.pdf", SaveFormat.Pdf);
} finally {
    aiWebClient.close();
    presentation.dispose();
}
```

По умолчанию встроенный [OpenAIWebClient](https://reference.aspose.com/slides/ru/java/com.aspose.slides/openaiwebclient/) создаёт и управляет собственным внутренним экземпляром [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html), автоматически контролируя его жизненный цикл. Однако, если вы предпочитаете управлять [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) самостоятельно — в первую очередь для настройки таких важных параметров, как прокси, или для использования [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) или другого [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) для лучшего управления ресурсами и производительности — вы можете предоставить свой собственный экземпляр `HttpURLConnection` при создании [OpenAIWebClient](https://reference.aspose.com/slides/ru/java/com.aspose.slides/openaiwebclient/).

```java
import com.aspose.slides.*;
import java.net.HttpURLConnection;
import java.net.InetSocketAddress;
import java.net.Proxy;
import java.net.URL;

// Настройте экземпляр HttpURLConnection самостоятельно (пользовательские тайм-ауты, настройки прокси и т.д.).
Proxy proxy = new Proxy(Proxy.Type.HTTP, new InetSocketAddress("proxy.example.com", 8080));
HttpURLConnection urlConnection = (HttpURLConnection)new URL("https://api.openai.com/v1/chat/completions").openConnection(proxy);
urlConnection.setConnectTimeout(30000);
urlConnection.setReadTimeout(60000);

OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null, urlConnection);
```

## **Ключевые преимущества**

API перевода презентаций Aspose.Slides предоставляет решение на основе ИИ для создания многоязычных презентаций PowerPoint. Автоматизируя перевод при сохранении макета и дизайна, он экономит время и уменьшает количество ошибок по сравнению с ручными процессами. Независимо от того, разработчик вы, преподаватель или бизнес‑профессионал, этот API позволяет создавать привлекательные, локализованные презентации для глобальной аудитории — расширяя ваш охват и улучшая коммуникацию.