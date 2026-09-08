---
title: Управление показом слайдов в Python через Java
linktitle: Показ слайдов
type: docs
weight: 90
url: /ru/python-java/manage-slide-show/
keywords:
- тип показа
- представлено докладчиком
- просмотр индивидуально
- просмотр в киоске
- параметры показа
- бесконечный цикл
- показ без озвучки
- показ без анимации
- цвет пера
- показать слайды
- пользовательский показ
- переходить слайды
- вручную
- с использованием таймингов
- PowerPoint
- OpenDocument
- презентация
- Python
- Java
- Aspose.Slides
description: "Узнайте, как управлять показом слайдов в Aspose.Slides для Python через Java. Легко контролируйте переходы слайдов, тайминги и многое другое в форматах PPT, PPTX и ODP."
---
## **Введение**

Параметры **Set Up Show** в Microsoft PowerPoint позволяют выбрать тип показа, включить зацикливание, выбрать слайды и управлять переходом слайдов. С помощью Aspose.Slides для Python через Java вы можете программно настроить эти параметры и сохранить их в файле презентации.

Метод [Presentation.getSlideShowSettings](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/#getSlideShowSettings) возвращает объект [SlideShowSettings](https://reference.aspose.com/slides/ru/python-java/aspose.slides/slideshowsettings/), управляющий этими параметрами. Приведённые ниже примеры требуют Aspose.Slides для Python через Java и совместимую среду выполнения Java. Каждый пример при необходимости запускает JVM и освобождает презентацию после завершения.

## **Выбор типа показа**

[SlideShowSettings.setSlideShowType](https://reference.aspose.com/slides/ru/python-java/aspose.slides/slideshowsettings/#setSlideShowType) определяет тип показа слайдов, которым может быть экземпляр одного из следующих классов: [PresentedBySpeaker](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentedbyspeaker/), [BrowsedByIndividual](https://reference.aspose.com/slides/ru/python-java/aspose.slides/browsedbyindividual/), или [BrowsedAtKiosk](https://reference.aspose.com/slides/ru/python-java/aspose.slides/browsedatkiosk/). Использование этого метода позволяет адаптировать презентацию к различным сценариям использования, таким как автоматические киоски или ручные презентации.

Пример кода ниже создаёт новую презентацию и задаёт тип показа «Browsed by an individual», не отображая полосы прокрутки.

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

[SlideShowSettings.setLoop](https://reference.aspose.com/slides/ru/python-java/aspose.slides/slideshowsettings/#setLoop) определяет, следует ли повторять показ слайдов в цикле до ручной остановки. Это полезно для автоматических презентаций, которые должны работать непрерывно. [SlideShowSettings.setShowNarration](https://reference.aspose.com/slides/ru/python-java/aspose.slides/slideshowsettings/#setShowNarration) определяет, следует ли воспроизводить голосовые комментарии во время показа слайдов. Это полезно для автоматических презентаций, содержащих голосовое сопровождение для аудитории. [SlideShowSettings.setShowAnimation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/slideshowsettings/#setShowAnimation) определяет, следует ли воспроизводить анимацию, добавленную к объектам слайдов. Это полезно для предоставления полного визуального эффекта презентации.

Следующий пример кода создаёт новую презентацию и запускает цикл показа слайдов.

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

Метод [SlideShowSettings.setSlides](https://reference.aspose.com/slides/ru/python-java/aspose.slides/slideshowsettings/#setSlides) позволяет выбрать диапазон слайдов, которые будут отображаться во время презентации. Это полезно, когда нужно показать только часть презентации, а не все слайды. В следующем примере кода создаётся презентация из девяти слайдов и выбираются слайды 2‑9. Диапазон использует нумерацию слайдов, начинающуюся с единицы.

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

Метод [SlideShowSettings.setUseTimings](https://reference.aspose.com/slides/ru/python-java/aspose.slides/slideshowsettings/#setUseTimings) позволяет включать или отключать использование предустановленных таймингов для каждого слайда. Это полезно для автоматического показа слайдов с заранее заданной длительностью отображения. Пример кода ниже создаёт новую презентацию и отключает использование таймингов.

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

## **Отображение медиа‑элементов управления**

Метод [SlideShowSettings.setShowMediaControls](https://reference.aspose.com/slides/ru/python-java/aspose.slides/slideshowsettings/#setShowMediaControls) определяет, следует ли отображать элементы управления медиа (например, воспроизведение, пауза и остановка) во время показа слайдов, когда воспроизводится мультимедийный контент (например, видео или аудио). Это полезно, когда вы хотите предоставить ведущему управление воспроизведением медиа во время презентации.

Следующий пример кода создаёт новую презентацию и включает отображение медиа‑элементов управления.

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

**Могу ли я сохранить презентацию так, чтобы она открывалась сразу в режиме показа слайдов?**  
Да. Сохраните файл в формате PPSX или PPSM; эти форматы открываются сразу в режиме показа слайдов в PowerPoint. В Aspose.Slides выберите соответствующий формат сохранения [при экспорте](/slides/ru/python-java/save-presentation/).

**Могу ли я исключить отдельные слайды из показа, не удаляя их из файла?**  
Да. Пометите слайд как [hidden](https://reference.aspose.com/slides/ru/python-java/aspose.slides/slide/#setHidden). Скрытые слайды остаются в презентации, но не отображаются во время показа слайдов.

**Может ли Aspose.Slides воспроизводить показ слайдов или управлять живой презентацией на экране?**  
Нет. Aspose.Slides редактирует, анализирует и преобразует файлы презентаций; фактическое воспроизведение происходит в приложении‑просмотрщике, таком как PowerPoint.