---
title: Генератор многоязычных слайдов с ИИ
linktitle: Генератор на основе ИИ
type: docs
weight: 40
url: /ru/python-java/ai/generator/
keywords:
- многоязычная презентация
- многоязычный слайд
- генератор презентаций ИИ
- генератор слайдов ИИ
- шаблон презентации
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "Создавайте многоязычные презентации из текста с помощью Aspose.Slides для Python через Java. Выбирайте детализацию содержимого, применяйте шаблон и экспортируйте в PowerPoint или PDF."
---
## **Введение**

Генератор презентаций AI в Aspose.Slides для Python через Java создаёт презентации на основе описаний тем, резюме, цитат или маркеров. Укажите требуемый язык в подсказке, выберите объём содержимого и при желании предоставьте шаблон презентации для определения макета и дизайна.

Генератор структурирует содержимое с помощью текстовых блоков, маркированных списков и таблиц. Он не создаёт изображения; их можно добавить в полученную презентацию позже. Проверьте сгенерированное содержимое и макет перед тем, как делиться презентацией.

## **Как это работает**

[SlidesAIAgent](https://reference.aspose.com/slides/ru/python-java/aspose.slides/slidesaiagent/) использует AI‑клиент для общения с внешней моделью. Примеры ниже используют встроенный [OpenAIWebClient](https://reference.aspose.com/slides/ru/python-java/aspose.slides/openaiwebclient/). Aspose.Slides обрабатывает ответы модели и формирует презентацию, которую можно редактировать или экспортировать.

Вызовите [SlidesAIAgent.generatePresentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/slidesaiagent/#generatePresentation) с текстовым описанием и значением [PresentationContentAmountType](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentationcontentamounttype/). Перегрузка с третьим аргументом принимает презентацию, которую использовать в качестве шаблона дизайна.

## **Требования**

Следуйте разделу [Установка](/slides/ru/python-java/installation/), чтобы настроить Python, Java, JPype и Aspose.Slides. Установите переменные окружения `OPENAI_API_KEY` и `OPENAI_MODEL` перед запуском примеров. Выберите модель, поддерживаемую встроенным клиентом и доступную в вашей учётной записи API.

{{% alert color="info" title="Note" %}}
Сервис AI требует подключения к интернету и отдельного доступа к API. Подсказки отправляются в настроенный сервис, а его плата за использование начисляется независимо от вашей лицензии Aspose.Slides.
{{% /alert %}}

Каждый пример запускает JVM только если она ещё не запущена и оставляет её доступной для последующих операций. См. [руководство по жизненному циклу JVM](/slides/ru/python-java/limitations-and-api-differences/#import-the-library) при адаптации кода для блокнотов.

## **Создание презентации из текста**

Этот пример генерирует английскую презентацию со средним объёмом содержимого и сохраняет её как файл PowerPoint.

```python
import os
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OpenAIWebClient, PresentationContentAmountType, SaveFormat, SlidesAIAgent

model = os.environ["OPENAI_MODEL"]
api_key = os.environ["OPENAI_API_KEY"]
ai_client = OpenAIWebClient(model, api_key, None)
try:
    ai_agent = SlidesAIAgent(ai_client)
    instruction = "Generate an English presentation about Aspose.Slides for Python via Java, highlighting its capabilities and use cases."
    presentation = ai_agent.generatePresentation(instruction, PresentationContentAmountType.Medium)
    try:
        presentation.save("generated.pptx", SaveFormat.Pptx)
    finally:
        presentation.dispose()
finally:
    ai_client.close()
```

## **Создание презентации с использованием шаблона**

Поместите `masterPresentation.pptx` в рабочий каталог. Этот пример загружает его с помощью [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/), генерирует испанскую презентацию с [Detailed](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentationcontentamounttype/#Detailed) содержимым и экспортирует её в PDF. Шаблон и сгенерированная презентация освобождаются даже в случае ошибки генерации или сохранения.

```python
import os
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OpenAIWebClient, Presentation, PresentationContentAmountType, SaveFormat, SlidesAIAgent

model = os.environ["OPENAI_MODEL"]
api_key = os.environ["OPENAI_API_KEY"]
ai_client = OpenAIWebClient(model, api_key, None)
try:
    ai_agent = SlidesAIAgent(ai_client)
    template = Presentation("masterPresentation.pptx")
    try:
        instruction = "Generate a Spanish presentation about Aspose.Slides for Python via Java, highlighting its capabilities and use cases."
        presentation = ai_agent.generatePresentation(instruction, PresentationContentAmountType.Detailed, template)
        try:
            presentation.save("generated.pdf", SaveFormat.Pdf)
        finally:
            presentation.dispose()
    finally:
        template.dispose()
finally:
    ai_client.close()
```

Если необходимо настроить прокси или таймауты соединения, см. [Configure the HTTP Connection](/slides/ru/python-java/ai/translator/#configure-the-http-connection). Вы также можете передать полученный клиент генератору.

## **Ключевые преимущества**

Генерация может сократить начальную работу по подготовке учебных материалов, обзоров продуктов, клиентских отчётов и внутренних презентаций. Подсказки контролируют тему и язык, а шаблон позволяет повторно использовать существующий дизайн презентации.

## **FAQ**

**Как я могу контролировать длину сгенерированной презентации?**

Выберите [Brief](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentationcontentamounttype/#Brief), [Medium](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentationcontentamounttype/#Medium) или [Detailed](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentationcontentamounttype/#Detailed). Эти настройки влияют как на количество слайдов, так и на степень детализации каждого слайда; они не задают точное количество слайдов.

**Могу ли я генерировать слайды на другом языке?**

Да. Укажите требуемый язык в текстовом описании. Результат зависит от языковых возможностей выбранной модели.

**Можно ли сохранить редактируемую версию при экспорте в PDF?**

Да. Перед удалением сгенерированной презентации также сохраните её как PPTX, используя подход из первого примера.