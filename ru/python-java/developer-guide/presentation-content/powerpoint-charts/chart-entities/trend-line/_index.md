---
title: Добавление линий тренда к диаграммам презентаций в Python
linktitle: Линия тренда
type: docs
url: /ru/python-java/trend-line/
keywords:
- диаграмма
- линия тренда
- экспоненциальная линия тренда
- линейная линия тренда
- логарифмическая линия тренда
- линия скользящего среднего
- полиномиальная линия тренда
- степенная линия тренда
- пользовательская линия тренда
- PowerPoint
- презентация
- Python
- Java
- Aspose.Slides
description: "Быстро добавляйте и настраивайте линии тренда в диаграммах PowerPoint с помощью Aspose.Slides для Python через Java — практическое руководство для привлечения вашей аудитории."
---
## **Обзор**

В этой статье объясняется, как добавить линии тренда к диаграммам презентаций с помощью Aspose.Slides. Показано, как создать диаграмму, добавить линии тренда к сериям диаграммы и работать с несколькими типами линий тренда, включая экспоненциальные, линейные, логарифмические, скользящее среднее, полиномиальные и степенные.

Также описывается, как добавить пользовательскую линию к диаграмме, вставив форму линии, и приводится краткий FAQ о значениях проекции линии тренда вперёд и назад, а также о том, сохраняются ли линии тренда при экспорте в PDF или SVG и при рендеринге диаграмм в виде изображений.

## **Добавить линию тренда**

Aspose.Slides for Python via Java предоставляет простой API для управления различными линиями тренда диаграмм:

1. Создайте экземпляр класса [Презентация](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/).
2. Получите ссылку на слайд по его индексу.
3. Добавьте диаграмму с данными по умолчанию и нужным типом (в этом примере используется [ChartType.ClusteredColumn](https://reference.aspose.com/slides/ru/python-java/aspose.slides/charttype/#ClusteredColumn)).
4. Добавьте экспоненциальную линию тренда к серии диаграммы 1.
5. Добавьте линейную линию тренда к серии диаграммы 1.
6. Добавьте логарифмическую линию тренда к серии диаграммы 2.
7. Добавьте линию скользящего среднего к серии диаграммы 2.
8. Добавьте полиномиальную линию тренда к серии диаграммы 3.
9. Добавьте степенную линию тренда к серии диаграммы 3.
10. Запишите изменённую презентацию в файл PPTX.

Следующий код создаёт диаграмму с линиями тренда.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat, TrendlineType
from java.awt import Color

# Создайте экземпляр класса Presentation.
presentation = Presentation()
try:
    # Создайте диаграмму сгруппированных столбцов.
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 400)

    # Добавьте экспоненциальную линию тренда к серии диаграммы 1.
    exponential_trend_line = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(TrendlineType.Exponential)
    exponential_trend_line.setDisplayEquation(False)
    exponential_trend_line.setDisplayRSquaredValue(False)

    # Добавьте линейную линию тренда к серии диаграммы 1.
    linear_trend_line = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(TrendlineType.Linear)
    linear_trend_line.setTrendlineType(TrendlineType.Linear)
    linear_trend_line.getFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    linear_trend_line.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED)

    # Добавьте логарифмическую линию тренда к серии диаграммы 2.
    logarithmic_trend_line = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.Logarithmic)
    logarithmic_trend_line.setTrendlineType(TrendlineType.Logarithmic)
    logarithmic_trend_line.addTextFrameForOverriding("New log trend line")

    # Добавьте линию скользящего среднего к серии диаграммы 2.
    moving_average_trend_line = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.MovingAverage)
    moving_average_trend_line.setTrendlineType(TrendlineType.MovingAverage)
    moving_average_trend_line.setPeriod(jpype.JByte(3))
    moving_average_trend_line.setTrendlineName("New TrendLine Name")

    # Добавьте полиномиальную линию тренда к серии диаграммы 3.
    polynomial_trend_line = chart.getChartData().getSeries().get_Item(2).getTrendLines().add(TrendlineType.Polynomial)
    polynomial_trend_line.setTrendlineType(TrendlineType.Polynomial)
    polynomial_trend_line.setForward(1)
    polynomial_trend_line.setOrder(jpype.JByte(3))

    # Добавьте степенную линию тренда к серии диаграммы 3.
    power_trend_line = chart.getChartData().getSeries().get_Item(2).getTrendLines().add(TrendlineType.Power)
    power_trend_line.setTrendlineType(TrendlineType.Power)
    power_trend_line.setBackward(1)

    # Сохраните презентацию.
    presentation.save("ChartTrendLines_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Добавить пользовательскую линию**

Aspose.Slides for Python via Java предоставляет простой API для добавления пользовательских линий к диаграмме. Чтобы добавить простую линию к диаграмме на выбранном слайде, выполните следующие шаги:

- Создайте экземпляр класса [Презентация](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/).
- Получите ссылку на слайд по его индексу.
- Создайте новую диаграмму, используя метод [addChart](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shapecollection/#addChart) класса [ShapeCollection](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shapecollection/).
- Добавьте форму линии, используя метод [addAutoShape](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shapecollection/#addAutoShape) с типом [ShapeType.Line](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shapetype/#Line).
- Установите цвет линии формы.
- Запишите изменённую презентацию в файл PPTX.

Следующий код создаёт диаграмму с пользовательской линией.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

# Создайте экземпляр класса Presentation.
presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 400)
    shape = chart.getUserShapes().getShapes().addAutoShape(ShapeType.Line, 0, chart.getHeight() / 2, chart.getWidth(), 0)

    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED)

    presentation.save("Presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Вопросы и ответы**

**Что означают «вперёд» и «назад» для линии тренда?**

Это длины линии тренда, проецируемой вперёд или назад: для диаграмм разброса (XY) они измеряются в единицах осей; для недисперсионных диаграмм — в количестве категорий. Допустимы только неотрицательные значения.

**Сохраняется ли линия тренда при экспорте презентации в PDF или SVG, а также при рендеринге слайда в изображение?**

Да. Aspose.Slides конвертирует презентации в [PDF](/slides/ru/python-java/convert-powerpoint-to-pdf/)/[SVG](/slides/ru/python-java/render-a-slide-as-an-svg-image/) и рендерит диаграммы в изображения; линии тренда, как часть диаграммы, сохраняются во время этих операций. Также доступен метод для [экспортировать изображение диаграммы](/slides/ru/python-java/create-shape-thumbnails/).