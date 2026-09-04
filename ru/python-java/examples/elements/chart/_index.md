---
title: Диаграмма
type: docs
weight: 60
url: /ru/python-java/examples/elements/chart/
keywords:
- диаграмма
- добавить диаграмму
- доступ к диаграмме
- удалить диаграмму
- обновить диаграмму
- примеры кода
- PowerPoint
- OpenDocument
- презентация
- Python
- Java
- Aspose.Slides
description: "Создавайте, получайте доступ, удаляйте и обновляйте диаграммы в презентациях PowerPoint и OpenDocument с помощью Aspose.Slides for Python via Java."
---
Эта статья демонстрирует, как добавлять, получать доступ, удалять и обновлять диаграммы в презентации с помощью **Aspose.Slides for Python via Java**.

Установите пакет, как описано в [Installation](/slides/ru/python-java/installation/). Каждый пример импортирует `asposeslides` перед запуском JVM, затем импортирует API после запуска JVM. Сначала выполните пример добавления, чтобы создать `chart.pptx` для остальных примеров.

## **Добавить диаграмму**

Добавьте диаграмму с областями на первый слайд и сохраните презентацию.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Добавьте диаграмму с областями на первый слайд.
    chart = slide.getShapes().addChart(ChartType.Area, 50, 50, 400, 300)

    presentation.save("chart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Доступ к диаграмме**

Найдите первую диаграмму в коллекции фигур на первом слайде.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation

presentation = Presentation("chart.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    # Получить доступ к первой диаграмме на слайде.
    first_chart = None
    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)
        if isinstance(shape, Chart):
            first_chart = shape
            break

    if first_chart is None:
        print("The first slide contains no charts.")
finally:
    presentation.dispose()
```

## **Удалить диаграмму**

Удалите первую диаграмму со слайда и сохраните изменённую презентацию.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation, SaveFormat

presentation = Presentation("chart.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    # Найти и удалить первую диаграмму на слайде.
    chart = None
    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)
        if isinstance(shape, Chart):
            chart = shape
            break

    if chart is not None:
        slide.getShapes().remove(chart)
    else:
        print("The first slide contains no charts.")

    presentation.save("chart_removed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Обновить данные диаграммы**

Отобразите заголовок диаграммы, измените его текст и сохраните обновлённую презентацию.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation, SaveFormat

presentation = Presentation("chart.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    # Найти первую диаграмму на слайде.
    chart = None
    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)
        if isinstance(shape, Chart):
            chart = shape
            break

    if chart is not None:
        # Показать заголовок диаграммы и изменить его текст.
        chart.setTitle(True)
        chart.getChartTitle().addTextFrameForOverriding("Sales Report")
    else:
        print("The first slide contains no charts.")

    presentation.save("chart_updated.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```