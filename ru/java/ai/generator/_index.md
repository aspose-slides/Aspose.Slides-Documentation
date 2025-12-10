---
title: Генератор многоязычных слайдов на основе ИИ
linktitle: Генератор на основе ИИ
type: docs
weight: 40
url: /ru/java/ai/generator/
keywords:
- многоязычная презентация
- многоязычный слайд
- генератор презентаций ИИ
- генератор слайдов ИИ
- функция на основе ИИ
- AI-агент
- PowerPoint
- OpenDocument
- презентация
- Java
- Aspose.Slides
description: "Создавайте многоязычные слайды из текста с помощью Aspose.Slides для Java. Применяйте ваш шаблон и экспортируйте отполированные наборы в PowerPoint и OpenDocument. Узнайте больше."
---

## **Aspose.Slides Presentation AI API: генератор слайдов на основе ИИ**

Aspose.Slides представляет новую функцию, основанную на ИИ — Presentation Generator, которая позволяет разработчикам автоматически создавать хорошо структурированные презентации PowerPoint из простых текстовых вводов, таких как описания тем, резюме, цитаты или пунктирные списки.

Пользователи могут регулировать уровень детализации контента и при желании применить пользовательский шаблон презентации для определения визуального оформления.

В настоящее время AI Presentation Generator структурирует контент с помощью текстовых блоков, маркированных списков и таблиц. Генерация изображений пока не поддерживается; однако изображения можно легко добавить позже с помощью инструментов Aspose.Slides или вручную.

В результате получается полная презентация PowerPoint, которую можно использовать «как есть» или экспортировать в любой формат, поддерживаемый API Aspose.Slides. Хотя генератор выдаёт результаты высокого качества, может потребоваться небольшая пост‑правка для удовлетворения конкретных требований.

## **Как это работает**

Aspose.Slides не включает встроенные модели ИИ; вместо этого он интегрируется с внешними AI‑сервисами через интернет. Эта интеграция реализована классом [SlidesAIAgent](https://reference.aspose.com/slides/java/com.aspose.slides/slidesaiagent/), который использует реализацию интерфейса [IAIWebClient](https://reference.aspose.com/slides/java/com.aspose.slides/iaiwebclient/) для общения с AI‑моделью.

Вы можете использовать встроенный [OpenAIWebClient](https://reference.aspose.com/slides/java/com.aspose.slides/openaiwebclient/), который подключается к API OpenAI, либо предоставить собственную реализацию [IAIWebClient](https://reference.aspose.com/slides/java/com.aspose.slides/iaiwebclient/) для работы с другим поставщиком ИИ или языковой моделью. Aspose.Slides управляет всей коммуникацией с AI‑сервисом и обрабатывает ответы ИИ для генерации слайдов. Учтите, что API OpenAI является платным сервисом, поэтому при использовании встроенного [OpenAIWebClient](https://reference.aspose.com/slides/java/com.aspose.slides/openaiwebclient/) требуется учётная запись и API‑ключ.

## **Давайте кодировать**

### **Пример 1**

Этот пример демонстрирует, как сгенерировать презентацию на тему Aspose.Slides с помощью встроенного [OpenAIWebClient](https://reference.aspose.com/slides/java/com.aspose.slides/openaiwebclient/).
```java
// Создайте экземпляр OpenAIWebClient — встроенную реализацию веб‑клиента OpenAI.
OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null);
try {
    // Создайте экземпляр SlidesAIAgent, предоставляющий доступ к функциям на основе ИИ.
    var aiAgent = new SlidesAIAgent(aiWebClient);

    // Определите инструкцию для создания презентации.
    var instruction = "Generate a presentation about Aspose.Slides for .NET, highlighting its capabilities and advantages over competitors.";

    // Создайте презентацию со средним объёмом контента на основе инструкции.
    IPresentation presentation = aiAgent.generatePresentation(instruction, PresentationContentAmountType.Medium);
    try {
    // Сохраните сгенерированную презентацию на локальный диск в файл PowerPoint (.pptx).
    presentation.save("Aspose.Slides.NET.pptx", SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
} finally {
    aiWebClient.close();
}
```


### **Пример 2**

В следующем примере показаны перегрузки метода [generatePresentation](https://reference.aspose.com/slides/java/com.aspose.slides/slidesaiagent/#generatePresentation-java.lang.String-int-). В данном случае используется внешне управляемый объект [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) и `master presentation` пользователя.

По умолчанию встроенный [OpenAIWebClient](https://reference.aspose.com/slides/java/com.aspose.slides/openaiwebclient/) создаёт и управляет собственным внутренним объектом [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html), автоматически контролируя его жизненный цикл. Однако если вы предпочитаете управлять [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) самостоятельно — например, при использовании [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) или [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) для улучшенного управления ресурсами и производительности — вы можете передать свой объект [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) при создании [OpenAIWebClient](https://reference.aspose.com/slides/java/com.aspose.slides/openaiwebclient/).
```java
// Передайте HttpURLConnection конструктору OpenAIWebClient.
OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", "organizationId", urlConnection);
try {
    // Создайте экземпляр SlidesAIAgent.
    var aiAgent = new SlidesAIAgent(aiWebClient);

    // Определите инструкцию для создания презентации.
    var instruction = "Generate a presentation about Aspose.Slides for .NET, highlighting its capabilities and advantages over competitors.";

    // Загрузите мастер-презентацию с локального диска для использования в качестве шаблона дизайна.
    Presentation masterPresentation = new Presentation("masterPresentation.pptx");

    // Создайте подробную презентацию, используя инструкцию и мастер-шаблон.
    IPresentation presentation = aiAgent.generatePresentation(instruction, PresentationContentAmountType.Detailed, masterPresentation);

    try {
        // Сохраните сгенерированную презентацию в формате PDF.
        presentation.save("Aspose.Slides.NET.pdf", SaveFormat.Pdf);
    } finally {
        presentation.dispose();
        masterPresentation.dispose();
    }
} finally {
    aiWebClient.close();
}
```


## **Ключевые преимущества**

Новый AI Presentation Generator в Aspose.Slides предоставляет быстрый и гибкий способ создания структурированных наборов слайдов из простых текстовых запросов. Благодаря поддержке пользовательских шаблонов и внешне управляемых экземпляров [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) его можно без проблем интегрировать в широкий спектр приложений.

Типичные сценарии использования включают создание маркетинговых презентаций, учебных материалов, клиентских отчётов и внутренних наборов слайдов. Несмотря на то, что генерация изображений пока не поддерживается, инструмент уже предоставляет прочную основу для автоматизации создания презентаций, а в будущем ожидаются дальнейшие улучшения.