---
title: Поддержка прерываемой библиотеки
type: docs
weight: 120
url: /ru/python-java/support-for-interruptable-library/
keywords:
- прерываемая библиотека
- токен прерывания
- токен отмены
- длительная задача
- прерывание задачи
- PowerPoint
- OpenDocument
- презентация
- Python
- Java
- Aspose.Slides
description: "Сделайте длительные задачи отменяемыми с помощью Aspose.Slides for Python via Java. Прерывайте рендеринг и конвертацию PowerPoint и OpenDocument безопасно, с примерами."
---
## **Обзор**

Aspose.Slides предоставляет механизм прерываемой обработки для длительных задач, связанных с презентациями, таких как десериализация, сериализация и рендеринг. Этот механизм основан на классах [InterruptionToken](https://reference.aspose.com/slides/ru/python-java/aspose.slides/interruptiontoken/) и [InterruptionTokenSource](https://reference.aspose.com/slides/ru/python-java/aspose.slides/interruptiontokensource/).

[InterruptionToken](https://reference.aspose.com/slides/ru/python-java/aspose.slides/interruptiontoken/) может быть назначен объекту [LoadOptions](https://reference.aspose.com/slides/ru/python-java/aspose.slides/loadoptions/) и передан в конструктор [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/). Когда вызывается [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/ru/python-java/aspose.slides/interruptiontokensource/#interrupt), связанная длительная задача прерывается.

## **Прерываемая библиотека**

Aspose.Slides for Python via Java предоставляет классы [InterruptionToken](https://reference.aspose.com/slides/ru/python-java/aspose.slides/interruptiontoken/) и [InterruptionTokenSource](https://reference.aspose.com/slides/ru/python-java/aspose.slides/interruptiontokensource/). Они позволяют прерывать длительные задачи, такие как десериализация, сериализация и рендеринг.

- [InterruptionTokenSource](https://reference.aspose.com/slides/ru/python-java/aspose.slides/interruptiontokensource/) является источником токена(ов), передаваемых в [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/ru/python-java/aspose.slides/loadoptions/#setInterruptionToken).
- Когда вызывается [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/ru/python-java/aspose.slides/loadoptions/#setInterruptionToken) и экземпляр [LoadOptions](https://reference.aspose.com/slides/ru/python-java/aspose.slides/loadoptions/) передаётся в конструктор [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/), вызов [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/ru/python-java/aspose.slides/interruptiontokensource/#interrupt) прерывает любую длительную задачу, связанную с этой [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/).

Следующий фрагмент кода демонстрирует прерывание выполняющейся задачи:

```python
from concurrent.futures import ThreadPoolExecutor
import time

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import InterruptionTokenSource, LoadOptions, Presentation, SaveFormat


token_source = InterruptionTokenSource()


def convert_presentation():
    load_options = LoadOptions()
    load_options.setInterruptionToken(token_source.getToken())

    presentation = Presentation("sample.pptx", load_options)
    try:
        presentation.save("sample.ppt", SaveFormat.Ppt)
    finally:
        presentation.dispose()


with ThreadPoolExecutor(max_workers=1) as executor:
    conversion_task = executor.submit(convert_presentation)  # Запустить действие в отдельном потоке.
    time.sleep(10)  # Тайм-аут.
    token_source.interrupt()  # Остановить конвертацию.
    conversion_task.result()
```

## **Часто задаваемые вопросы**

**Какова цель библиотеки прерывания Aspose.Slides?**

Она предоставляет механизм прерывания длительных операций — таких как загрузка, сохранение или рендеринг презентаций — до их завершения. Это полезно, когда время обработки должно быть ограничено или задача более не нужна.

**В чём разница между [InterruptionToken](https://reference.aspose.com/slides/ru/python-java/aspose.slides/interruptiontoken/) и [InterruptionTokenSource](https://reference.aspose.com/slides/ru/python-java/aspose.slides/interruptiontokensource/)?**

- [InterruptionToken](https://reference.aspose.com/slides/ru/python-java/aspose.slides/interruptiontoken/) передаётся в API Aspose.Slides и проверяется во время длительных операций.
- [InterruptionTokenSource](https://reference.aspose.com/slides/ru/python-java/aspose.slides/interruptiontokensource/) используется в вашем коде для создания токенов и инициирования прерываний вызовом [interrupt](https://reference.aspose.com/slides/ru/python-java/aspose.slides/interruptiontokensource/#interrupt).

**Какие задачи можно прерывать?**

Любая задача Aspose.Slides, принимающая [InterruptionToken](https://reference.aspose.com/slides/ru/python-java/aspose.slides/interruptiontoken/) — например, загрузка презентации с помощью [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/) или сохранение через [Presentation.save](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/#save) — может быть прервана.

**Прерывание происходит мгновенно?**

Нет. Прерывание является кооперативным: операция периодически проверяет токен и останавливается, как только обнаруживает, что был вызван [interrupt](https://reference.aspose.com/slides/ru/python-java/aspose.slides/interruptiontokensource/#interrupt).

**Что происходит, если вызвать [interrupt](https://reference.aspose.com/slides/ru/python-java/aspose.slides/interruptiontokensource/#interrupt) после завершения задачи?**

Ничего — вызов не имеет эффекта, если соответствующая задача уже завершена.

**Можно ли повторно использовать один и тот же [InterruptionTokenSource](https://reference.aspose.com/slides/ru/python-java/aspose.slides/interruptiontokensource/) для нескольких задач?**

Да — но после вызова [interrupt](https://reference.aspose.com/slides/ru/python-java/aspose.slides/interruptiontokensource/#interrupt) для этого источника все задачи, использующие его токены, будут прерваны. Используйте отдельные источники токенов для независимого управления задачами.