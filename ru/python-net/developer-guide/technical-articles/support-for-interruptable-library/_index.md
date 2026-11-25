---
title: Прерывание длительных операций с презентациями в Python
linktitle: Прерывание операций презентации
type: docs
weight: 150
url: /ru/python-net/support-for-interruptable-library/
keywords:
- прерываемые операции
- токен прерывания
- отмена экспорта PDF
- PowerPoint
- Python
- Aspose.Slides
description: "Узнайте, как отменить преобразование презентации в Python и получить список слайдов, завершивших экспорт до отмены."
---
## **Обзор**

Aspose.Slides for Python via .NET поддерживает совместную отмену во время длительных операций, таких как загрузка, сохранение и рендеринг презентаций. При экспорте слайдов по отдельности вы также можете проверять отмену между слайдами и возвращать номера слайдов, которые завершили экспорт.

## **Отмена преобразования презентации**

Создайте [InterruptionTokenSource](https://reference.aspose.com/slides/python-net/aspose.slides/interruptiontokensource/), назначьте его [token](https://reference.aspose.com/slides/python-net/aspose.slides/interruptiontokensource/token/) параметру [LoadOptions.interruption_token](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/interruption_token/), и передайте параметры в [Presentation constructor](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/__init__/). Токен применяется к презентации на протяжении всего её жизненного цикла. Чтобы запросить отмену из вашего приложения, вызовите [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/python-net/aspose.slides/interruptiontokensource/interrupt/).

В примере файл `sample.pptx` конвертируется в `sample.pdf`. [threading.Timer](https://docs.python.org/3/library/threading.html#threading.Timer) вызывает `source.interrupt` через 20 секунд. Запуск таймера до открытия файла заставляет тайм‑аут применяться как к загрузке, так и к сохранению. Приложение с кнопкой Cancel может вызывать тот же метод из обработчика события.

```python
from threading import Timer

import aspose.slides as slides

source = slides.InterruptionTokenSource()
options = slides.LoadOptions()
options.interruption_token = source.token
timer = Timer(20, source.interrupt)

timer.start()
try:
    with slides.Presentation("sample.pptx", options) as presentation:
        options.interruption_token.throw_if_interruption_requested()
        presentation.save("sample.pdf", slides.export.SaveFormat.PDF)
finally:
    timer.cancel()
    timer.join()
```

Явная проверка после загрузки пропускает экспорт, если тайм‑аут уже истёк. Если при загрузке или сохранении обнаруживается запрос, исключение отмены передаётся вызывающему коду. Сохранение также может завершиться до того, как будет обнаружен запрос, в этом случае PDF будет полным.

## **Остановить перед обработкой следующего слайда**

Проверьте [InterruptionToken.is_interruption_requested](https://reference.aspose.com/slides/python-net/aspose.slides/interruptiontoken/is_interruption_requested/) перед каждым экспортом. [Presentation.save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/) принимает список номеров слайдов, начиная с 1. Добавляйте номер в список завершённых только после успешного сохранения его PDF.

Используйте файл с именем `sample.pptx`, содержащий как минимум два слайда. Чтобы результат был воспроизводимым, пример запрашивает отмену сразу после завершения экспорта слайда 1. В приложении запрос может исходить из другого потока, пока сохраняется слайд.

```python
import aspose.slides as slides


def export_slides(path, source):
    completed = []
    token = source.token
    options = slides.LoadOptions()
    options.interruption_token = token

    with slides.Presentation(path, options) as presentation:
        for number in range(1, len(presentation.slides) + 1):
            if token.is_interruption_requested:
                break

            print(f"Starting slide {number}")
            try:
                presentation.save(f"slide-{number}.pdf", [number], slides.export.SaveFormat.PDF)
            except slides.AsposeSlidesException as error:
                if token.is_interruption_requested and "System.OperationCanceledException" in str(error):
                    break
                raise

            completed.append(number)
            if number == 1:
                source.interrupt()

    return completed


source = slides.InterruptionTokenSource()
completed = export_slides("sample.pptx", source)
print(f"Completed: {completed}")
```

В примере создаётся `slide-1.pdf` и выводится `Starting slide 1`, затем `Completed: [1]`. На следующей итерации запрос обнаруживается до начала экспорта слайда 2. Если отмена прерывает сохранение, обработчик исключения возвращает номера, записанные на предыдущих итерациях. Другие ошибки экспорта передаются вызывающему.

Если вызывающий код должен обрабатывать отмену как исключение, замените проверку и её `break` в начале цикла на [token.throw_if_interruption_requested](https://reference.aspose.com/slides/python-net/aspose.slides/interruptiontoken/throw_if_interruption_requested/). Также удалите `try`/`except` вокруг сохранения. При тех же входных данных слайд 1 сохраняется, а вторая итерация генерирует исключение отмены перед началом экспорта слайда 2.

## **Вопросы и ответы**

**Когда запрос на отмену вступает в силу?**

Прерываемая операция проверяет свой токен периодически. Она останавливается, когда обнаруживает запрос. Операция, уже завершившаяся, сохраняет свой результат.

**В чём разница между source и token?**

Source позволяет вашему приложению запросить отмену. Token позволяет как презентации, так и вашему коду проверять наличие этого запроса.

**Могут ли несколько операций использовать один source?**

Да. Вызов `interrupt` запрашивает отмену для каждой операции, использующей токен из этого source. Дайте каждой операции свой собственный source, если нужно отменять её независимо.