---
title: Переводчик презентаций на основе ИИ
linktitle: Переводчик на основе ИИ
type: docs
weight: 20
url: /ru/php-java/ai/translator/
keywords:
- Переводчик презентаций на основе ИИ
- Переводчик слайдов на основе ИИ
- Функция на основе ИИ
- многоязычная презентация
- многоязычный слайд
- перевод презентации
- перевод слайда
- Функции, управляемые ИИ
- Возможности ИИ
- ИИ‑агент
- Веб‑клиент
- PowerPoint
- OpenDocument
- презентация
- PHP
- Aspose.Slides
description: "Переводите слайды PowerPoint с помощью ИИ, используя Aspose.Slides для PHP. Локализуйте PPT, PPTX и ODP, сохраняя макет — быстро и удобно для разработчиков. Попробуйте."
---

## **Aspose.Slides Presentation Translation API: мультиязычный перевод слайдов на основе ИИ**

Aspose.Slides — это мощный API для программного управления презентациями PowerPoint. Помимо создания, редактирования и конвертации слайдов, он предлагает функции, управляемые ИИ, такие как Presentation Translation API для многоязычного содержимого слайдов.

## **Как это работает**

Aspose.Slides не включает встроенные возможности ИИ, а интегрируется с внешними AI‑моделями через интернет. Эта функциональность доступна через класс [SlidesAIAgent](https://reference.aspose.com/slides/php-java/aspose.slides/slidesaiagent/) для взаимодействия с AI‑сервисами.

Вы можете использовать встроенный [OpenAIWebClient](https://reference.aspose.com/slides/php-java/aspose.slides/openaiwebclient/) для подключения к API OpenAI.

Aspose.Slides обрабатывает связь, разбирает ответы ИИ и интеллектуально вставляет переведённый контент, сохраняя оригинальное расположение и форматирование слайдов.

{{% alert color="primary" %}}
Обратите внимание, что API OpenAI является платным сервисом, поэтому вам потребуется создать учётную запись и предоставить свой API‑ключ при использовании встроенного [OpenAIWebClient](https://reference.aspose.com/slides/php-java/aspose.slides/openaiwebclient/).
{{% /alert %}}

## **Пример**

В этом примере мы переводим презентацию PowerPoint на японский язык, используя встроенный [OpenAIWebClient](https://reference.aspose.com/slides/php-java/aspose.slides/openaiwebclient/) с указанной OpenAI [модель](https://platform.openai.com/docs/models).
```php
// Загрузить презентацию для перевода.
$presentation = new Presentation("sample.pptx");

// Create an AI client with OpenAIWebClient, specifying your model and API key.
$aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null);

try {
    // Инициализировать SlidesAIAgent с AI‑клиентом.
    $aiAgent = new SlidesAIAgent($aiWebClient);

    // Перевести презентацию на японский.
    $aiAgent->translate($presentation, "japanese");

    // Сохранить переведённую презентацию в формате PDF.
    $presentation->save("sample_jp.pdf", SaveFormat::Pdf);
} finally {
    $aiWebClient->close();
    $presentation->dispose();
}
```


По умолчанию встроенный [OpenAIWebClient](https://reference.aspose.com/slides/php-java/aspose.slides/openaiwebclient/) создаёт и управляет собственным внутренним объектом [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html), автоматически контролируя его жизненный цикл. Однако, если вы предпочитаете управлять [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) самостоятельно — в частности, чтобы настроить важные параметры, такие как прокси, или использовать [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) или иной [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) для лучшего управления ресурсами и производительности — вы можете предоставить свой собственный экземпляр `HttpURLConnection` при создании [OpenAIWebClient](https://reference.aspose.com/slides/php-java/aspose.slides/openaiwebclient/).
```php
// Предположим, что у вас есть предварительно настроенный экземпляр HttpURLConnection (например, с пользовательскими тайм-аутами, настройками прокси и т.д.)
$urlConnection = $yourPreconfiguredConnection;
$aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null, $urlConnection);
```


## **Ключевые преимущества**

Aspose.Slides Presentation Translation API предлагает решение на основе ИИ для создания многоязычных презентаций PowerPoint. Автоматизируя перевод и сохраняя макет и дизайн, он экономит время и минимизирует ошибки по сравнению с ручными процессами. Независимо от того, являетесь ли вы разработчиком, преподавателем или бизнес‑профессионалом, этот API позволяет создавать увлекательные локализованные презентации для глобальной аудитории — расширяя охват и улучшая коммуникацию.