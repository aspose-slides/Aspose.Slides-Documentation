---
title: Оптимизация вычислений диаграмм для презентаций в Python через Java
linktitle: Вычисления диаграмм
type: docs
weight: 50
url: /ru/python-java/chart-calculations/
keywords:
- вычисления диаграмм
- элементы диаграммы
- позиция элемента
- фактическая позиция
- дочерний элемент
- родительский элемент
- значения диаграммы
- фактическое значение
- PowerPoint
- презентация
- Python
- Java
- Aspose.Slides
description: "Понимание вычислений диаграмм, обновления данных и контроля точности в Aspose.Slides для Python через Java для PPT и PPTX, с практическими примерами кода на Python."
---
## **Обзор**

Aspose.Slides предоставляет API для работы с вычислениями диаграмм и данными макета в презентациях. В этой статье показано, как получить фактические значения элементов диаграммы, включая реальное положение и размер элементов диаграммы и фактические значения осей диаграммы. Также объясняется, что эти значения заполняются после проверки макета диаграммы.

Кроме того, в статье демонстрируется, как получить фактическое положение родительских элементов диаграммы и как скрыть компоненты диаграммы, такие как заголовок, оси, легенда и линии сетки. Вместе эти примеры помогут вам программно проверять информацию о макете диаграммы и управлять видимостью элементов диаграммы в презентациях PowerPoint.

## **Вычисление фактических значений элементов диаграммы**
Aspose.Slides for Python via Java предоставляет простой API для получения этих свойств. Методы класса [Axis](https://reference.aspose.com/slides/ru/python-java/aspose.slides/axis/) предоставляют информацию о фактических значениях осей диаграммы ([getActualMaxValue](https://reference.aspose.com/slides/ru/python-java/aspose.slides/axis/#getActualMaxValue), [getActualMinValue](https://reference.aspose.com/slides/ru/python-java/aspose.slides/axis/#getActualMinValue), [getActualMajorUnit](https://reference.aspose.com/slides/ru/python-java/aspose.slides/axis/#getActualMajorUnit), [getActualMinorUnit](https://reference.aspose.com/slides/ru/python-java/aspose.slides/axis/#getActualMinorUnit), [getActualMajorUnitScale](https://reference.aspose.com/slides/ru/python-java/aspose.slides/axis/#getActualMajorUnitScale), [getActualMinorUnitScale](https://reference.aspose.com/slides/ru/python-java/aspose.slides/axis/#getActualMinorUnitScale)). Сначала вызовите метод [Chart.validateChartLayout](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chart/#validateChartLayout), чтобы заполнить эти свойства фактическими значениями.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Area, 100, 100, 500, 350)
    chart.validateChartLayout()

    max_value = chart.getAxes().getVerticalAxis().getActualMaxValue()
    min_value = chart.getAxes().getVerticalAxis().getActualMinValue()

    major_unit = chart.getAxes().getHorizontalAxis().getActualMajorUnit()
    minor_unit = chart.getAxes().getHorizontalAxis().getActualMinorUnit()
finally:
    presentation.dispose()
```

## **Вычисление фактического положения родительских элементов диаграммы**
Aspose.Slides for Python via Java предоставляет простой API для получения этих свойств. Методы класса [ChartPlotArea](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chartplotarea/) предоставляют информацию о фактическом положении и размере области построения диаграммы ([getActualX](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chartplotarea/#getActualX), [getActualY](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chartplotarea/#getActualY), [getActualWidth](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chartplotarea/#getActualWidth), [getActualHeight](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chartplotarea/#getActualHeight)). Сначала вызовите метод [Chart.validateChartLayout](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chart/#validateChartLayout), чтобы заполнить эти свойства фактическими значениями.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 350)
    chart.validateChartLayout()

    x = chart.getPlotArea().getActualX()
    y = chart.getPlotArea().getActualY()
    width = chart.getPlotArea().getActualWidth()
    height = chart.getPlotArea().getActualHeight()
finally:
    presentation.dispose()
```

## **Скрытие элементов диаграммы**
В этом разделе объясняется, как скрыть информацию в диаграмме. С помощью Aspose.Slides for Python via Java вы можете скрыть **Заголовок, Вертикальную ось, Горизонтальную ось** и **Линии сетки**. Следующий пример кода показывает, как использовать эти свойства.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpway.startJVM()

from asposeslides.api import ChartType, FillType, LegendDataLabelPosition, LineDashStyle, MarkerStyleType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 140, 118, 320, 370)

    # Скрыть заголовок диаграммы.
    chart.setTitle(False)

    # Скрыть ось значений.
    chart.getAxes().getVerticalAxis().setVisible(False)

    # Скрыть ось категорий.
    chart.getAxes().getHorizontalAxis().setVisible(False)

    # Скрыть легенду.
    chart.setLegend(False)

    # Скрыть основные линии сетки.
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill)

    # Оставить только первую серию. Удаление с конца сохраняет корректность оставшихся индексов.
    series_collection = chart.getChartData().getSeries()
    while series_collection.size() > 1:
        series_collection.removeAt(series_collection.size() - 1)

    series = series_collection.get_Item(0)

    series.getMarker().setSymbol(MarkerStyleType.Circle)
    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)
    series.getLabels().getDefaultDataLabelFormat().setPosition(LegendDataLabelPosition.Top)
    series.getMarker().setSize(15)

    # Установить цвет линии серии.
    series.getFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    series.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.MAGENTA)
    series.getFormat().getLine().setDashStyle(LineDashStyle.Solid)

    presentation.save("HideInformationFromChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Работают ли внешние книги Excel как источник данных и как это влияет на перерасчёт?**

Да. Диаграмма может ссылаться на внешнюю книгу: при подключении или обновлении внешнего источника формулы и значения берутся из этой книги, и диаграмма отражает изменения во время операций открытия/редактирования. API позволяет указать путь к [external workbook](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chartdata/#setExternalWorkbook) и управлять связанными данными.

**Могу ли я вычислять и отображать линии тренда без собственного реализации регрессии?**

Да. [Trendlines](/slides/ru/python-java/trend-line/) (линейные, экспоненциальные и другие) добавляются и обновляются Aspose.Slides; их параметры автоматически пересчитываются из данных серии, поэтому вам не нужно реализовывать собственные расчёты.

**Если в презентации несколько диаграмм со внешними ссылками, могу ли я контролировать, какую книгу использует каждая диаграмма для вычисленных значений?**

Да. Каждая диаграмма может указывать свою [external workbook](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chartdata/#setExternalWorkbook), либо вы можете создать/заменить внешнюю книгу для каждой диаграммы независимо от остальных.