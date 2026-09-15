---
title: Переводчик презентаций с ИИ
linktitle: Переводчик с ИИ
type: docs
weight: 20
url: /ru/python-net/ai/translator/
keywords:
- AI переводчик презентаций
- AI переводчик слайдов
- функция на основе ИИ
- многоязычная презентация
- многоязычный слайд
- перевод презентации
- перевод слайда
- функции, управляемые ИИ
- возможности ИИ
- агент ИИ
- веб-клиент
- PowerPoint
- OpenDocument
- презентация
- Python
- Aspose.Slides
description: "Переводите слайды PowerPoint с помощью ИИ, используя Aspose.Slides для Python. Локализуйте PPT, PPTX и ODP, сохраняя макет — быстро и удобно для разработчиков. Попробуйте."
---
## **Введение**

Aspose.Slides — мощный API для программного управления презентациями PowerPoint. Помимо создания, редактирования и конвертации слайдов, он предлагает функции на основе ИИ, такие как [API перевода презентаций](https://reference.aspose.com/slides/ru/python-net/aspose.slides.ai/) для многоязычного контента слайдов.

## **Как это работает**

Aspose.Slides не содержит встроенных возможностей ИИ, но интегрируется с внешними моделями ИИ через интернет. Эта функциональность предоставляется классом [SlidesAIAgent](https://reference.aspose.com/slides/ru/python-net/aspose.slides.ai/slidesaiagent/), который использует подклассы [IAIWebClient](https://reference.aspose.com/slides/ru/python-net/aspose.slides.ai/iaiwebclient/) для общения с сервисами ИИ.

Вы можете использовать встроенный [OpenAIWebClient](https://reference.aspose.com/slides/ru/python-net/aspose.slides.ai/openaiwebclient/) для подключения к API OpenAI или реализовать собственный [IAIWebClient](https://reference.aspose.com/slides/ru/python-net/aspose.slides.ai/iaiwebclient/) для использования другого провайдера ИИ или языковой модели.

Aspose.Slides обрабатывает связь, разбирает ответы ИИ и интеллектуально вставляет переведённый контент, сохраняя оригинальную компоновку и форматирование слайдов.

{{% alert color="info" %}}
Обратите внимание, что API OpenAI является платным сервисом, поэтому вам потребуется создать учётную запись и указать свой API‑ключ при использовании встроенного [OpenAIWebClient](https://reference.aspose.com/slides/ru/python-net/aspose.slides.ai/openaiwebclient/).
{{% /alert %}}

## **Пример**

В этом примере мы переводим презентацию PowerPoint на японский язык, используя встроенный [OpenAIWebClient](https://reference.aspose.com/slides/ru/python-net/aspose.slides.ai/openaiwebclient/) с указанной моделью OpenAI [модель](https://platform.openai.com/docs/models).

```py
import aspose.slides as slides

# Загрузите презентацию для перевода.
with slides.Presentation("sample.pptx") as presentation:

    # Создайте AI‑клиент с OpenAIWebClient, указав вашу модель и API‑ключ.
    with slides.ai.OpenAIWebClient("gpt-4o-mini", "apiKey", "") as ai_web_client:

        # Инициализируйте SlidesAIAgent с AI‑клиентом.
        ai_agent = slides.ai.SlidesAIAgent(ai_web_client)

        # Переведите презентацию на японский.
        ai_agent.translate(presentation, "japanese")

        # Сохраните переведённую презентацию в формате PDF.
        presentation.save("sample_jp.pdf", slides.export.SaveFormat.PDF)
```

### **Пример Azure OpenAI**

Начиная с версии **26.7.0**, Aspose.Slides for Python via .NET поддерживает провайдеров, совместимых с OpenAI, включая Azure OpenAI. Вы можете настроить переводчик для использования вашего собственного развертывания Azure с помощью [OpenAICompatibleWebClient](https://reference.aspose.com/slides/ru/python-net/aspose.slides.ai/openaicompatiblewebclient/).

```py
import aspose.slides as slides

model = "your-azure-deployment-name"
api_key = "your-azure-api-key"
base_url = "https://your-resource.openai.azure.com/openai/v1/"

with slides.ai.OpenAICompatibleWebClient(model, api_key, base_url) as ai_web_client:
    ai_agent = slides.ai.SlidesAIAgent(ai_web_client)
    with slides.Presentation("Presentation.pptx") as presentation:
        ai_agent.translate(presentation, "spanish")
        presentation.save("Translated.pptx", slides.export.SaveFormat.PPTX)
```

Этот фрагмент кода демонстрирует перевод презентации с использованием вашего конечного URL Azure OpenAI. Замените значения‑заполнители на имя вашего развертывания, API‑ключ и URL конечной точки.

## **Ключевые преимущества**

[API перевода презентаций](https://reference.aspose.com/slides/ru/python-net/aspose.slides.ai/) Aspose.Slides предлагает решение на основе ИИ для предоставления многоязычных презентаций PowerPoint. Автоматизируя перевод и сохраняя макет и дизайн, оно экономит время и минимизирует ошибки по сравнению с ручными процессами. Независимо от того, разработчик вы, преподаватель или бизнес‑профессионал, этот API позволяет создавать привлекательные локализованные презентации для глобальной аудитории — расширяя охват и улучшая коммуникацию.