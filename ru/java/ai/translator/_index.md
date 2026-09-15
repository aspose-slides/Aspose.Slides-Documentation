---
title: Переводчик презентаций на основе ИИ
linktitle: Переводчик с поддержкой ИИ
type: docs
weight: 20
url: /ru/java/ai/translator/
keywords:
- ИИ переводчик презентаций
- ИИ переводчик слайдов
- функция на базе ИИ
- многоязычная презентация
- многоязычный слайд
- перевод презентации
- перевод слайда
- функции на основе ИИ
- возможности ИИ
- агент ИИ
- веб-клиент
- PowerPoint
- OpenDocument
- презентация
- Java
- Aspose.Slides
description: "Переводите слайды PowerPoint с помощью ИИ, используя Aspose.Slides для Java. Локализуйте PPT, PPTX и ODP, сохраняя макет — быстро и удобно для разработчиков. Попробуйте."
---
## **Введение**

Aspose.Slides — мощный API для программного управления презентациями PowerPoint. Помимо создания, редактирования и конвертации слайдов, он предоставляет функции, основанные на ИИ, такие как API перевода презентаций для многоязычного содержимого слайдов.

## **Как это работает**

Aspose.Slides не содержит встроенных возможностей ИИ, но интегрируется с внешними AI‑моделями через интернет. Эта функциональность предоставляется классом [SlidesAIAgent](https://reference.aspose.com/slides/ru/java/com.aspose.slides/slidesaiagent/), который использует реализацию интерфейса [IAIWebClient](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iaiwebclient/) для взаимодействия с AI‑службами.

Вы можете использовать встроенный [OpenAIWebClient](https://reference.aspose.com/slides/ru/java/com.aspose.slides/openaiwebclient/) для подключения к API OpenAI или реализовать собственный [IAIWebClient](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iaiwebclient/) для использования другого поставщика AI или языковой модели.

Aspose.Slides обрабатывает коммуникацию, разбирает ответы AI и интеллектуально вставляет переведённый контент, сохраняя исходную компоновку и форматирование слайдов.

{{% alert color="info" title="Note" %}}
Обратите внимание, что API OpenAI — платный сервис, поэтому вам понадобится создать учётную запись и предоставить свой API‑ключ при использовании встроенного [OpenAIWebClient](https://reference.aspose.com/slides/ru/java/com.aspose.slides/openaiwebclient/).
{{% /alert %}}

## **Пример**

В этом примере мы переводим презентацию PowerPoint на японский язык, используя встроенный [OpenAIWebClient](https://reference.aspose.com/slides/ru/java/com.aspose.slides/openaiwebclient/) с указанной моделью OpenAI [model](https://platform.openai.com/docs/models).

```java
import com.aspose.slides.*;

// Загрузить презентацию для перевода.
Presentation presentation = new Presentation("sample.pptx");

// Создать AI‑клиент с OpenAIWebClient, указав вашу модель и API‑ключ.
OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null);

try {
    // Инициализировать SlidesAIAgent с AI‑клиентом.
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

По умолчанию встроенный [OpenAIWebClient](https://reference.aspose.com/slides/ru/java/com.aspose.slides/openaiwebclient/) создаёт и управляет собственным внутренним экземпляром [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html), автоматически обрабатывая его жизненный цикл. Однако, если вы хотите управлять [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) самостоятельно — в основном для настройки таких важных параметров, как прокси, или чтобы использовать [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) или другой [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) для лучшего управления ресурсами и производительности — вы можете предоставить свой собственный экземпляр `HttpURLConnection` при создании [OpenAIWebClient](https://reference.aspose.com/slides/ru/java/com.aspose.slides/openaiwebclient/).

```java
import com.aspose.slides.*;
import java.net.HttpURLConnection;
import java.net.InetSocketAddress;
import java.net.Proxy;
import java.net.URL;

// Настройте экземпляр HttpURLConnection самостоятельно (кастомные тайм-ауты, настройки прокси и т.д.).
Proxy proxy = new Proxy(Proxy.Type.HTTP, new InetSocketAddress("proxy.example.com", 8080));
HttpURLConnection urlConnection = (HttpURLConnection)new URL("https://api.openai.com/v1/chat/completions").openConnection(proxy);
urlConnection.setConnectTimeout(30000);
urlConnection.setReadTimeout(60000);

OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null, urlConnection);
```

### **Пример Azure OpenAI**

Вы можете настроить переводчик для использования вашего развертывания Azure OpenAI с помощью [OpenAICompatibleWebClient](https://reference.aspose.com/slides/ru/java/com.aspose.slides/openaicompatiblewebclient/).

```java
import com.aspose.slides.*;

String model = "your-azure-deployment-name";
String apiKey = "your-azure-api-key";
String baseUrl = "https://your-resource.openai.azure.com/openai/v1/";

OpenAICompatibleWebClient aiWebClient = new OpenAICompatibleWebClient(model, apiKey, baseUrl);
try {
    SlidesAIAgent aiAgent = new SlidesAIAgent(aiWebClient);
    Presentation presentation = new Presentation("Presentation.pptx");
    try {
        aiAgent.translate(presentation, "spanish");
        presentation.save("Translated.pptx", SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
} finally {
    aiWebClient.dispose();
}
```

Этот фрагмент демонстрирует перевод презентации с использованием вашего конечного пункта Azure OpenAI. Замените значения заполнителей на имя вашего развертывания, API‑ключ и URL конечной точки.

## **Ключевые преимущества**

API перевода презентаций Aspose.Slides предоставляет решение на базе ИИ для создания многоязычных презентаций PowerPoint. Автоматизируя перевод при сохранении макета и дизайна, он экономит время и минимизирует ошибки по сравнению с ручными процессами. Независимо от того, являетесь ли вы разработчиком, преподавателем или бизнес‑профессионалом, этот API позволяет создавать увлекательные локализованные презентации для глобальной аудитории, расширяя охват и улучшая коммуникацию.