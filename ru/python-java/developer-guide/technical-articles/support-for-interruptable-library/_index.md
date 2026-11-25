---
title: Прерывание длительных операций с презентациями в Python
linktitle: Прерывание операций с презентациями
type: docs
weight: 120
url: /ru/python-java/support-for-interruptable-library/
keywords:
- прерываемые операции
- токен прерывания
- токен отмены
- длительная задача
- прервать задачу
- PowerPoint
- OpenDocument
- презентация
- Python
- Java
- Aspose.Slides
description: "Узнайте, как отменять длительные операции с презентациями в Aspose.Slides for Python via Java и получать частичный результат при экспорте слайдов в цикле."
---
## **Обзор**

Aspose.Slides for Python via Java может прерывать длительные операции, такие как загрузка, сохранение и рендеринг презентаций. Ваше приложение может использовать тот же токен прерывания, чтобы остановить цикл до начала обработки следующего слайда.

## **Прервать операцию с презентацией**

Создайте [InterruptionTokenSource](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/), получите его токен с помощью [getToken](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/#getToken), и передайте токен в метод [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setInterruptionToken). Передайте параметры загрузки в [Presentation constructor](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/). Чтобы запросить отмену, вызовите [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/#interrupt) у источника. Прерываемая операция останавливается, когда обнаруживает запрос. Используйте `jpype.JClass`, чтобы отловить в Python Java‑исключение `com.aspose.slides.exceptions.OperationCanceledException`.

Пример преобразует `sample.pptx` в `sample.ppt` в фоновом потоке. Вызывающий поток ждёт до 10 секунд завершения конвертации. Если конвертация всё ещё работает, он запрашивает отмену и ждёт завершения рабочего потока.

```python
from concurrent.futures import ThreadPoolExecutor, TimeoutError

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import InterruptionTokenSource, LoadOptions, Presentation, SaveFormat

OperationCanceledException = jpype.JClass("com.aspose.slides.exceptions.OperationCanceledException")


def convert_presentation(source):
    options = LoadOptions()
    options.setInterruptionToken(source.getToken())
    try:
        presentation = Presentation("sample.pptx", options)
        try:
            presentation.save("sample.ppt", SaveFormat.Ppt)
        finally:
            presentation.dispose()
    except OperationCanceledException:
        print("Conversion canceled")


source = InterruptionTokenSource()
with ThreadPoolExecutor(max_workers=1) as executor:
    conversion = executor.submit(convert_presentation, source)
    try:
        conversion.result(timeout=10)
    except TimeoutError:
        source.interrupt()
        conversion.result()
```

## **Подключить тайм‑аут Python к Aspose.Slides**

Чтобы установить ограничение времени для операции с презентацией, используйте [threading.Timer](https://docs.python.org/3/library/threading.html#threading.Timer), чтобы вызвать [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/#interrupt) по истечении тайм‑аута. В примере отводится 20 секунд на загрузку `sample.pptx` и экспорт в `sample.pdf`. Если экспорт завершается раньше, приложение отменяет запланированный запрос.

```python
from threading import Timer

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import InterruptionTokenSource, LoadOptions, Presentation, SaveFormat

OperationCanceledException = jpype.JClass("com.aspose.slides.exceptions.OperationCanceledException")

source = InterruptionTokenSource()
options = LoadOptions()
options.setInterruptionToken(source.getToken())

timer = Timer(20, source.interrupt)
timer.start()
try:
    presentation = Presentation("sample.pptx", options)
    try:
        presentation.save("sample.pdf", SaveFormat.Pdf)
    finally:
        presentation.dispose()
except OperationCanceledException:
    print("Presentation processing was canceled")
finally:
    timer.cancel()
    timer.join()
```

## **Остановить перед обработкой следующего слайда**

Используйте тот же [InterruptionToken](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontoken/) как для презентации, так и для цикла, который экспортирует её слайды. Перед каждым экспортом проверяйте [isInterruptionRequested](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontoken/#isInterruptionRequested). Если вызывающий может использовать частичный результат, возвращайте номера слайдов, успешно экспортированных.

Используйте презентацию с именем `sample.pptx`, содержащую как минимум два слайда. Перегрузка [Presentation.save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save), принимающая Java `int[]`, использует нумерацию слайдов, начинающуюся с 1. Используйте `jpype.JArray(jpype.JInt)`, чтобы построить массив в Python. Пример сохраняет каждый слайд в отдельный PDF и запрашивает отмену сразу после записи первого успешного экспорта.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import InterruptionTokenSource, LoadOptions, Presentation, SaveFormat

OperationCanceledException = jpype.JClass("com.aspose.slides.exceptions.OperationCanceledException")


def export_slides(path, source):
    completed = []
    token = source.getToken()
    options = LoadOptions()
    options.setInterruptionToken(token)
    presentation = Presentation(path, options)
    try:
        for number in range(1, presentation.getSlides().size() + 1):
            if token.isInterruptionRequested():
                break

            print(f"Starting slide {number}")
            slide_numbers = jpype.JArray(jpype.JInt)([number])
            try:
                presentation.save(f"slide-{number}.pdf", slide_numbers, SaveFormat.Pdf)
            except OperationCanceledException:
                if token.isInterruptionRequested():
                    break
                raise

            completed.append(number)
            if number == 1:
                source.interrupt()
        return completed
    finally:
        presentation.dispose()


source = InterruptionTokenSource()
completed = export_slides("sample.pptx", source)
print(f"Completed: {completed}")
```

Пример записывает `slide-1.pdf` и выводит `Starting slide 1`, затем `Completed: [1]`. Цикл обнаруживает запрос перед началом слайда 2. Если отмена происходит во время сохранения, цикл выходит до того, как отметит этот слайд как завершённый.

Если вызывающему необходимо обработать отмену, замените проверку и её `break` в начале цикла на `token.throwIfInterruptionRequested()`. Удалите `try`/`except` вокруг сохранения, чтобы отмена во время экспорта тоже доходила до вызывающего. При том же вводе пример выводит только `Starting slide 1` и записывает `slide-1.pdf`. В начале второй итерации [throwIfInterruptionRequested](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontoken/#throwIfInterruptionRequested) вызывает `com.aspose.slides.exceptions.OperationCanceledException` до начала следующего экспорта. Исключение распространяется на вызывающего до того, как функция сможет вернуть список.

## **FAQ**

**Когда следует запрашивать отмену?**  
Запрашивайте отмену, когда операция превышает ваш лимит времени или когда приложению больше не нужен результат.

**В чём разница между [InterruptionToken](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontoken/) и [InterruptionTokenSource](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/)?**  
Источник позволяет вашему приложению запросить отмену. Токен позволяет Aspose.Slides и вашему приложению проверять наличие такого запроса.

**Могу ли я отменить операцию из таймера Python?**  
Да. Запланируйте вызов [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/#interrupt) у источника, связанного с презентацией.

**Какие операции я могу прервать?**  
Вы можете прерывать загрузку, сохранение и рендеринг. Передайте токен в [Presentation constructor](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) через [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setInterruptionToken). Затем презентация может наблюдать отмену во время последующих операций, таких как сохранение в PDF.

**Останавливается ли операция сразу?**  
Отмена кооперативна. Операция периодически проверяет токен и останавливается, когда обнаруживает запрос.

**Что происходит, если я вызову [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/#interrupt) после завершения операции?**  
Завершённая операция сохраняет свой результат.

**Могут ли несколько операций использовать один [InterruptionTokenSource](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/)?**  
Да. Вызов [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/#interrupt) запрашивает отмену для каждой операции, использующей токен из этого источника. Используйте отдельный источник для каждой операции, которую хотите отменять независимо.