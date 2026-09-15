---
title: Переводчик презентаций с поддержкой ИИ
linktitle: Переводчик с поддержкой ИИ
type: docs
weight: 20
url: /ru/php-java/ai/translator/
keywords:
- Переводчик презентаций с ИИ
- Переводчик слайдов с ИИ
- Функция с поддержкой ИИ
- Многоязычная презентация
- Многоязычный слайд
- Перевод презентации
- Перевод слайда
- Функции, управляемые ИИ
- Возможности ИИ
- AI‑агент
- Веб‑клиент
- PowerPoint
- OpenDocument
- презентация
- PHP
- Aspose.Slides
description: "Переводите слайды PowerPoint с помощью ИИ, используя Aspose.Slides для PHP. Локализуйте PPT, PPTX и ODP, сохраняя макет — быстро и удобно для разработчиков. Попробуйте."
---
## **Введение**

Aspose.Slides — мощный API для программного управления презентациями PowerPoint. В дополнение к созданию, редактированию и конвертации слайдов, он предлагает функции, основанные на ИИ, такие как Presentation Translation API для многоязычного содержимого слайдов.

## **Как это работает**

Aspose.Slides не включает встроенные возможности ИИ, а интегрируется с внешними моделями ИИ через интернет. Эта функциональность предоставляется классом [SlidesAIAgent](https://reference.aspose.com/slides/ru/php-java/aspose.slides/slidesaiagent/) для общения с AI‑службами.

Вы можете использовать встроенный [OpenAIWebClient](https://reference.aspose.com/slides/ru/php-java/aspose.slides/openaiwebclient/) для подключения к API OpenAI.

Aspose.Slides обрабатывает связь, разбирает ответы ИИ и интеллектуально вставляет переведённый контент, сохраняя оригинальное расположение и форматирование слайдов.

{{% alert color="info" title="Примечание" %}}
Обратите внимание, что API OpenAI является платным сервисом, поэтому вам потребуется создать учётную запись и указать ваш API‑ключ при использовании встроенного [OpenAIWebClient](https://reference.aspose.com/slides/ru/php-java/aspose.slides/openaiwebclient/).
{{% /alert %}}

## **Пример**

В этом примере мы переводим презентацию PowerPoint на японский язык, используя встроенный [OpenAIWebClient](https://reference.aspose.com/slides/ru/php-java/aspose.slides/openaiwebclient/) с указанной моделью OpenAI [model](https://platform.openai.com/docs/models).

```php
// Загрузить презентацию для перевода.
$presentation = new Presentation("sample.pptx");

// Создать AI‑клиент с OpenAIWebClient, указав вашу модель и API‑ключ.
$aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null);

try {
    // Инициализировать SlidesAIAgent с AI‑клиентом.
    $aiAgent = new SlidesAIAgent($aiWebClient);

    // Перевести презентацию на японский.
    $aiAgent->translate($presentation, "japanese");

    // Сохранить переводную презентацию в формате PDF.
    $presentation->save("sample_jp.pdf", SaveFormat::Pdf);
} finally {
    $aiWebClient->close();
    $presentation->dispose();
}
```

По умолчанию встроенный [OpenAIWebClient](https://reference.aspose.com/slides/ru/php-java/aspose.slides/openaiwebclient/) создаёт и управляет собственным внутренним экземпляром [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html), автоматически контролируя его жизненный цикл. Однако если вы предпочитаете управлять [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) самостоятельно — например, чтобы настроить прокси, использовать [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) или другой [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) для лучшего управления ресурсами и производительности — вы можете передать собственный экземпляр `HttpURLConnection` при создании [OpenAIWebClient](https://reference.aspose.com/slides/ru/php-java/aspose.slides/openaiwebclient/).

```php
// Создать и предварительно настроить ваш собственный экземпляр HttpURLConnection (настраиваемые тайм‑ауты, параметры прокси и т.д.).
$url = new Java("java.net.URL", "https://api.openai.com/v1/chat/completions");
$urlConnection = $url->openConnection();
$urlConnection->setConnectTimeout(10000);
$urlConnection->setReadTimeout(60000);

// Передать соединение AI‑клиенту.
$aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null, $urlConnection);
```

### **Пример Azure OpenAI**

Вы можете настроить переводчик для использования вашего развертывания Azure OpenAI с помощью [OpenAICompatibleWebClient](https://reference.aspose.com/slides/ru/php-java/aspose.slides/openaicompatiblewebclient/).

```php
use aspose\slides\OpenAICompatibleWebClient;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlidesAIAgent;

$model = "your-azure-deployment-name";
$apiKey = "your-azure-api-key";
$baseUrl = "https://your-resource.openai.azure.com/openai/v1/";

$aiWebClient = new OpenAICompatibleWebClient($model, $apiKey, $baseUrl);
try {
    $aiAgent = new SlidesAIAgent($aiWebClient);
    $presentation = new Presentation("Presentation.pptx");
    try {
        $aiAgent->translate($presentation, "spanish");
        $presentation->save("Translated.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
} finally {
    $aiWebClient->dispose();
}
```

Этот фрагмент кода демонстрирует перевод презентации с использованием вашего конечного адреса Azure OpenAI. Замените значения заполнителей на имя развертывания, API‑ключ и URL конечной точки.

## **Ключевые преимущества**

Presentation Translation API от Aspose.Slides предоставляет решение на базе ИИ для создания многоязычных презентаций PowerPoint. Автоматизируя перевод и сохраняя оригинальное оформление и дизайн, он экономит время и снижает количество ошибок по сравнению с ручными процессами. Независимо от того, являетесь ли вы разработчиком, преподавателем или бизнес‑профессионалом, этот API позволяет создавать привлекательные локализованные презентации для глобальной аудитории — расширяя охват и улучшая коммуникацию.