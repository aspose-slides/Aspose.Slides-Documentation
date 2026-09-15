---
title: Переводчик презентаций на базе ИИ
linktitle: Переводчик на базе ИИ
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
- ИИ‑агент
- Веб‑клиент
- PowerPoint
- OpenDocument
- презентация
- Android
- Java
- Aspose.Slides
description: "Переводите слайды PowerPoint с помощью ИИ, используя Aspose.Slides для Android на Java. Локализуйте PPT, PPTX и ODP, сохраняющие макет — быстро и удобно для разработчиков. Попробуйте."
---
## **Введение**

Aspose.Slides — мощный API для программного управления презентациями PowerPoint. Помимо создания, редактирования и конвертации слайдов, он предлагает функции на основе ИИ, такие как API перевода презентаций для многоязычного содержимого слайдов.

## **Как это работает**

Aspose.Slides не включает встроенные возможности ИИ, а интегрируется с внешними моделями ИИ через интернет. Эта функциональность предоставляется классом [SlidesAIAgent](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/slidesaiagent/) , который использует реализацию интерфейса [IAIWebClient](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iaiwebclient/) , чтобы взаимодействовать с сервисами ИИ.

Вы можете использовать встроенный [OpenAIWebClient](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/openaiwebclient/) , чтобы подключиться к API OpenAI, или реализовать собственный [IAIWebClient](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iaiwebclient/) , чтобы использовать другого поставщика ИИ или языковую модель.

Aspose.Slides управляет связью, разбирает ответы ИИ и интеллектуально вставляет переведённый контент, сохраняя оригинальную раскладку и форматирование слайдов.

{{% alert color="info" title="Note" %}}
Учтите, что API OpenAI — платный сервис, поэтому вам потребуется создать аккаунт и предоставить ваш API‑ключ при использовании встроенного [OpenAIWebClient](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/openaiwebclient/).
{{% /alert %}}

## **Пример**

В этом примере мы переводим презентацию PowerPoint на японский язык, используя встроенный [OpenAIWebClient](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/openaiwebclient/) с указанной OpenAI [моделью](https://platform.openai.com/docs/models).

```java
import com.aspose.slides.*;

// Загрузите презентацию для перевода.
Presentation presentation = new Presentation("sample.pptx");

// Создайте клиент ИИ с OpenAIWebClient, указав вашу модель и API‑ключ.
OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null);

try {
    // Инициализируйте SlidesAIAgent клиентом ИИ.
    SlidesAIAgent aiAgent = new SlidesAIAgent(aiWebClient);

    // Переведите презентацию на японский.
    aiAgent.translate(presentation, "japanese");

    // Сохраните переведённую презентацию в формате PDF.
    presentation.save("sample_jp.pdf", SaveFormat.Pdf);
} finally {
    aiWebClient.close();
    presentation.dispose();
}
```

По умолчанию встроенный [OpenAIWebClient](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/openaiwebclient/) создаёт и управляет собственным внутренним экземпляром [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) , автоматически обрабатывая его жизненный цикл. Однако, если вы предпочитаете управлять [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) самостоятельно — в основном для настройки необходимых параметров, таких как прокси, или для использования [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) , либо другого [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) для лучшего управления ресурсами и производительности — вы можете предоставить свой собственный экземпляр `HttpURLConnection` при построении [OpenAIWebClient](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/openaiwebclient/).

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.net.HttpURLConnection;
import java.net.URI;

try {
    // Настройте экземпляр HttpURLConnection самостоятельно (например, с пользовательскими тайм‑аутами, настройками прокси и т.д.).
    HttpURLConnection urlConnection = (HttpURLConnection) URI.create("https://api.openai.com/v1/chat/completions").toURL().openConnection();
    urlConnection.setConnectTimeout(10000);
    urlConnection.setReadTimeout(60000);

    // Передайте соединение конструктору OpenAIWebClient.
    OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null, urlConnection);
} catch (IOException e) {
    e.printStackTrace();
}
```

### **Пример Azure OpenAI**

Вы можете настроить переводчик для использования вашего развертывания Azure OpenAI с помощью [OpenAICompatibleWebClient](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/openaicompatiblewebclient/).

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

Этот фрагмент кода демонстрирует перевод презентации с использованием вашего конечного пункта Azure OpenAI. Замените значения-заполнители на имя вашего развертывания, API‑ключ и URL конечной точки.

## **Ключевые преимущества**

API перевода презентаций Aspose.Slides предоставляет решение на основе ИИ для создания многоязычных презентаций PowerPoint. Автоматизируя перевод и сохраняя макет и дизайн, он экономит время и уменьшает количество ошибок по сравнению с ручными процессами. Независимо от того, являетесь ли вы разработчиком, преподавателем или бизнес‑профессионалом, этот API позволяет создавать привлекательные локализованные презентации для глобальной аудитории — расширяя охват и улучшая коммуникацию.