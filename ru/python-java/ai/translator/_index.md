---
title: Переводчик презентаций на базе ИИ
linktitle: Переводчик на базе ИИ
type: docs
weight: 20
url: /ru/python-java/ai/translator/
keywords:
- Переводчик презентаций ИИ
- Переводчик слайдов ИИ
- многоязычная презентация
- перевод презентации
- перевод слайдов
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "Переводите презентации с помощью ИИ, используя Aspose.Slides для Python через Java. Локализуйте текст слайдов и сохраняйте переведённую презентацию в формате PowerPoint или PDF."
---
## **Введение**

Aspose.Slides for Python via Java предоставляет API для ИИ‑перевода презентаций, позволяющее локализовать содержимое слайдов. Переведите существующую презентацию на указанный язык, а затем сохраните переведённую версию в нужном вашему аудитории формате.

## **Как это работает**

[SlidesAIAgent](https://reference.aspose.com/slides/ru/python-java/aspose.slides/slidesaiagent/) общается с внешним сервисом ИИ через AI‑клиент. В примерах используется встроенный [OpenAIWebClient](https://reference.aspose.com/slides/ru/python-java/aspose.slides/openaiwebclient/).

[SlidesAIAgent.translate](https://reference.aspose.com/slides/ru/python-java/aspose.slides/slidesaiagent/#translate) обновляет переданную ему презентацию. Aspose.Slides обрабатывает ответы ИИ и заменяет текст на слайдах, сохраняя существующее расположение и форматирование. Просмотрите результат: переведённый текст может быть длиннее оригинала и потребовать корректировки макета.

## **Требования**

Следуйте инструкциям в разделе [Installation](/slides/ru/python-java/installation/), чтобы настроить библиотеку и её среду выполнения. Установите переменные окружения `OPENAI_API_KEY` и `OPENAI_MODEL` перед запуском примеров. Выберите модель, поддерживаемую встроенным клиентом и доступную в вашей учётной записи API.

{{% alert color="info" title="Note" %}}
Для перевода требуется подключение к интернету, а текст презентации отправляется в настроенный сервис ИИ. Доступ к его API и расходы на использование являются отдельными от вашей лицензии Aspose.Slides.
{{% /alert %}}

Примеры переиспользуют активную JVM или запускают её при необходимости. Смотрите руководство по жизненному циклу JVM [JVM lifecycle guidance](/slides/ru/python-java/limitations-and-api-differences/#import-the-library) для использования в ноутбуке.

## **Перевести презентацию**

Поместите `sample.pptx` в рабочий каталог. Этот пример загружает её с помощью [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/), переводит её текст на японский язык и сохраняет результат в PDF. Он освобождает презентацию и закрывает AI‑клиент даже в случае ошибки выполнения.

```python
import os
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OpenAIWebClient, Presentation, SaveFormat, SlidesAIAgent

model = os.environ["OPENAI_MODEL"]
api_key = os.environ["OPENAI_API_KEY"]
ai_client = OpenAIWebClient(model, api_key, None)
try:
    presentation = Presentation("sample.pptx")
    try:
        ai_agent = SlidesAIAgent(ai_client)
        ai_agent.translate(presentation, "Japanese")
        presentation.save("sample_ja.pdf", SaveFormat.Pdf)
    finally:
        presentation.dispose()
finally:
    ai_client.close()
```

## **Настройка HTTP‑соединения**

По умолчанию [OpenAIWebClient](https://reference.aspose.com/slides/ru/python-java/aspose.slides/openaiwebclient/) управляет своим HTTP‑соединением внутренне. Его конструктор с четырьмя аргументами также принимает внешне управляемый Java‑объект [HttpURLConnection](https://docs.oracle.com/en/java/javase/17/docs/api/java.base/java/net/HttpURLConnection.html). Используйте эту перегрузку, когда необходимо настроить прокси‑сервер или тайм‑ауты соединения.

В следующем примере создаётся Java‑прокси HTTP с помощью [Proxy](https://docs.oracle.com/en/java/javase/17/docs/api/java.base/java/net/Proxy.html) и открывается соединение через [URL.openConnection](https://docs.oracle.com/en/java/javase/17/docs/api/java.base/java/net/URL.html#openConnection(java.net.Proxy)). Замените `proxy.example.com` и порт на настройки вашего прокси. Соединение передаётся напрямую через JPype; вместо него нельзя использовать Python‑сессию HTTP.

```python
import os
import jpype
import jpype.imports
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from java.net import InetSocketAddress, Proxy, URL
from asposeslides.api import OpenAIWebClient, Presentation, SaveFormat, SlidesAIAgent

model = os.environ["OPENAI_MODEL"]
api_key = os.environ["OPENAI_API_KEY"]
proxy_address = InetSocketAddress("proxy.example.com", 8080)
proxy = Proxy(Proxy.Type.HTTP, proxy_address)
endpoint = URL("https://api.openai.com/v1/chat/completions")
connection = endpoint.openConnection(proxy)
try:
    connection.setConnectTimeout(30000)
    connection.setReadTimeout(60000)
    ai_client = OpenAIWebClient(model, api_key, None, connection)
    try:
        presentation = Presentation("sample.pptx")
        try:
            ai_agent = SlidesAIAgent(ai_client)
            ai_agent.translate(presentation, "Japanese")
            presentation.save("sample_ja.pptx", SaveFormat.Pptx)
        finally:
            presentation.dispose()
    finally:
        ai_client.close()
finally:
    connection.disconnect()
```

## **Ключевые преимущества**

Автоматический перевод помогает готовить многоязычные учебные материалы, презентации продуктов и отчёты для клиентов, при этом повторно используя существующий дизайн слайдов. Сохраните презентацию в редактируемом виде для дальнейшего обзора или экспортируйте её в PDF для распространения.

## **FAQ**

**Создаёт ли перевод отдельный объект презентации?**

Нет. [SlidesAIAgent.translate](https://reference.aspose.com/slides/ru/python-java/aspose.slides/slidesaiagent/#translate) изменяет переданную презентацию. Сохраните её под новым именем файла, чтобы оригинал остался без изменений.

**Как указать целевой язык?**

Передайте название языка, например `"Japanese"` или `"Spanish"`, в качестве второго аргумента. Качество перевода и покрытие языков зависят от выбранной модели.

**Можно ли перевести без использования прокси?**

Да. Используйте конструктор клиента с тремя аргументами, показанный в первом примере. Пример с пользовательским соединением нужен только тогда, когда вашему приложению требуются явные настройки соединения.