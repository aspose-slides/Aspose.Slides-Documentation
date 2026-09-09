---
title: Управление слайд‑шоу в Python через Java
linktitle: Слайд‑шоу
type: docs
weight: 90
url: /ru/python-java/manage-slide-show/
keywords:
- тип показа
- представляется спикером
- просматривается индивидуально
- просматривается на киоске
- параметры показа
- непрерывное зацикливание
- показывать без озвучки
- показывать без анимации
- цвет пера
- показывать слайды
- пользовательский показ
- переходить к следующим слайдам
- вручную
- с использованием таймингов
- PowerPoint
- OpenDocument
- презентация
- Python
- Java
- Aspose.Slides
description: "Узнайте, как управлять слайд‑шоу в Aspose.Slides для Python через Java. Управляйте переходами слайдов, таймингами и прочим в форматах PPT, PPTX и ODP с легкостью."
---
## **Введение**

Параметры **Set Up Show** в Microsoft PowerPoint позволяют выбирать тип показа, включать зацикливание, выбирать слайды и управлять переходом слайдов. С помощью Aspose.Slides for Python via Java вы можете программно настраивать эти параметры и сохранять их в файле презентации.

Метод [Presentation.getSlideShowSettings](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/#getSlideShowSettings) возвращает объект [SlideShowSettings](https://reference.aspose.com/slides/ru/python-java/aspose.slides/slideshowsettings/) , который управляет этими параметрами. Приведённые ниже примеры требуют Aspose.Slides for Python via Java и совместимой Java‑среды выполнения. Каждый пример при необходимости запускает JVM и освобождает презентацию после завершения.

## **Выбор типа показа**

[SlideShowSettings.setSlideShowType](https://reference.aspose.com/slides/ru/python-java/aspose.slides/slideshowsettings/#setSlideShowType) определяет тип слайд‑шоу, который может быть экземпляром одной из следующих классов: [PresentedBySpeaker](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentedbyspeaker/), [BrowsedByIndividual](https://reference.aspose.com/slides/ru/python-java/aspose.slides/browsedbyindividual/), или [BrowsedAtKiosk](https://reference.aspose.com/slides/ru/python-java/aspose.slides/browsedatkiosk/). Использование этого метода позволяет адаптировать презентацию к различным сценариям использования, таким как автоматические киоски или ручные выступления.

Пример кода ниже создаёт новую презентацию и задаёт тип показа «Browsed by an individual», при этом не отображая полосу прокрутки.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, BrowsedByIndividual

presentation = Presentation()
try:
    show_type = BrowsedByIndividual()
    show_type.setShowScrollbar(False)
    presentation.getSlideShowSettings().setSlideShowType(show_type)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Включение параметров показа**

[SlideShowSettings.setLoop](https://reference.aspose.com/slides/ru/python-java/aspose.slides/slideshowsettings/#setLoop) определяет, будет ли слайд‑шоу повторяться в цикле до ручной остановки. Это полезно для автоматических презентаций, которые должны работать непрерывно. [SlideShowSettings.setShowNarration](https://reference.aspose.com/slides/ru/python-java/aspose.slides/slideshowsettings/#setShowNarration) определяет, следует ли воспроизводить голосовые повествования во время слайд‑шоу. Это полезно для автоматических презентаций, содержащих голосовые подсказки для аудитории. [SlideShowSettings.setShowAnimation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/slideshowsettings/#setShowAnimation) определяет, следует ли воспроизводить анимацию, добавленную к объектам слайда. Это полезно для предоставления полного визуального эффекта презентации.

Следующий пример кода создаёт новую презентацию и зацикливает слайд‑шоу.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    presentation.getSlideShowSettings().setLoop(True)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Выбор слайдов для показа**

Метод [SlideShowSettings.setSlides](https://reference.aspose.com/slides/ru/python-java/aspose.slides/slideshowsettings/#setSlides) позволяет выбирать диапазон слайдов, которые будут отображаться во время презентации. Это полезно, когда нужно показать только часть презентации, а не все слайды. Пример кода ниже создаёт презентацию из девяти слайдов и выбирает слайды 2‑9. Диапазон использует нумерацию с 1.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlidesRange

presentation = Presentation()
try:
    # Создайте девять слайдов, чтобы выбранный диапазон существовал.
    first_slide = presentation.getSlides().get_Item(0)
    for _ in range(8):
        presentation.getSlides().addClone(first_slide)

    slide_range = SlidesRange()
    slide_range.setStart(2)
    slide_range.setEnd(9)
    presentation.getSlideShowSettings().setSlides(slide_range)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Управление переходом слайдов**

Метод [SlideShowSettings.setUseTimings](https://reference.aspose.com/slides/ru/python-java/aspose.slides/slideshowsettings/#setUseTimings) позволяет включать или отключать использование предустановленных таймингов для каждого слайда. Это полезно для автоматического показа слайдов с заранее определёнными длительностями отображения. Пример кода ниже создаёт новую презентацию и отключает использование таймингов.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    presentation.getSlideShowSettings().setUseTimings(False)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Отображение медиа‑управления**

Метод [SlideShowSettings.setShowMediaControls](https://reference.aspose.com/slides/ru/python-java/aspose.slides/slideshowsettings/#setShowMediaControls) определяет, следует ли отображать элементы управления мультимедиа (например, воспроизведение, пауза и остановка) во время слайд‑шоу, когда воспроизводится мультимедийный контент (например, видео или аудио). Это полезно, когда вы хотите предоставить ведущему возможность управлять воспроизведением медиа во время презентации.

Следующий пример кода создаёт новую презентацию и включает отображение медиа‑управления.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    presentation.getSlideShowSettings().setShowMediaControls(True)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Можно ли сохранить презентацию так, чтобы она открывалась сразу в режиме слайд‑шоу?**

Да. Сохраните файл в формате PPSX или PPSM; эти форматы открываются сразу в режиме слайд‑шоу в PowerPoint. В Aspose.Slides выберите соответствующий формат сохранения [при экспорте](/slides/ru/python-java/save-presentation/).

**Можно ли исключить отдельные слайды из показа, не удаляя их из файла?**

Да. Отметьте слайд как [скрытый](https://reference.aspose.com/slides/ru/python-java/aspose.slides/slide/#setHidden). Скрытые слайды остаются в презентации, но не отображаются во время слайд‑шоу.

**Может ли Aspose.Slides воспроизводить слайд‑шоу или управлять живой презентацией на экране?**

Нет. Aspose.Slides редактирует, анализирует и конвертирует файлы презентаций; реальное воспроизведение осуществляется приложением‑просмотрщиком, таким как PowerPoint.