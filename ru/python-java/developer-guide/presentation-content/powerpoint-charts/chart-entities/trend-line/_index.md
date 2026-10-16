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
- линия тренда со скользящим средним
- полиномиальная линия тренда
- степенная линия тренда
- пользовательская линия тренда
- PowerPoint
- презентация
- Python
- Java
- Aspose.Slides
description: "Быстро добавляйте и настраивайте линии тренда в диаграммах PowerPoint с помощью Aspose.Slides для Python через Java — практическое руководство по привлечению вашей аудитории."
---
## **Обзор**

Эта статья объясняет, как добавить линии тренда к диаграммам презентаций с помощью Aspose.Slides. Она показывает, как создать диаграмму, добавить линии тренда к сериям диаграммы и работать с несколькими типами линий тренда, включая экспоненциальные, линейные, логарифмические, скользящие средние, полиномиальные и степенные.

Также описывается, как добавить пользовательскую линию к диаграмме, вставив форму линии, и включён короткий FAQ о значениях проекции линии тренда вперёд и назад, а также о том, сохраняются ли линии тренда при экспорте в PDF или SVG и при рендеринге диаграмм в виде изображений.

## **Добавить линию тренда**

Используйте [TrendlineCollection.add](https://reference.aspose.com/slides/python-java/aspose.slides/trendlinecollection/#add), чтобы добавить линию тренда к серии диаграммы, выбирая её тип с помощью [TrendlineType](https://reference.aspose.com/slides/python-java/aspose.slides/trendlinetype/). Пример создаёт сгруппированную столбчатую диаграмму с данными по умолчанию и добавляет по две линии тренда к каждой из её трёх серий.

Экспоненциальная линия тренда скрывает своё уравнение и значение R‑квадрат с помощью [setDisplayEquation](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#setDisplayEquation) и [setDisplayRSquaredValue](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#setDisplayRSquaredValue), тогда как линейная линия тренда окрашена в красный цвет. Логарифмическая линия тренда использует [addTextFrameForOverriding](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#addTextFrameForOverriding) для пользовательской подписи. Скользящее среднее использует [setPeriod](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#setPeriod) в три точки данных и пользовательское [setTrendlineName](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#setTrendlineName).

Полиномиальная линия тренда имеет порядок три, задаётся через [setOrder](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#setOrder) и расширяется на одну категорию вперёд с помощью [setForward](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#setForward). Степенная линия тренда расширяется на одну категорию назад через [setBackward](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#setBackward).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat, TrendlineType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 400)

    first_series = chart.getChartData().getSeries().get_Item(0)

    exponential_trendline = first_series.getTrendLines().add(TrendlineType.Exponential)
    exponential_trendline.setDisplayEquation(False)
    exponential_trendline.setDisplayRSquaredValue(False)

    linear_trendline = first_series.getTrendLines().add(TrendlineType.Linear)
    linear_trendline.getFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    linear_trendline.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED)

    second_series = chart.getChartData().getSeries().get_Item(1)

    logarithmic_trendline = second_series.getTrendLines().add(TrendlineType.Logarithmic)
    logarithmic_trendline.addTextFrameForOverriding("New log trend line")

    moving_average_trendline = second_series.getTrendLines().add(TrendlineType.MovingAverage)
    moving_average_trendline.setPeriod(jpype.JByte(3))
    moving_average_trendline.setTrendlineName("New TrendLine Name")

    third_series = chart.getChartData().getSeries().get_Item(2)

    polynomial_trendline = third_series.getTrendLines().add(TrendlineType.Polynomial)
    polynomial_trendline.setForward(1)
    polynomial_trendline.setOrder(jpype.JByte(3))

    power_trendline = third_series.getTrendLines().add(TrendlineType.Power)
    power_trendline.setBackward(1)

    presentation.save("ChartTrendLines.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Установить пересечение линии тренда**

Используйте [setIntercept](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#setIntercept), чтобы зафиксировать значение Y линии тренда при X = 0. Эта настройка поддерживается для линейных, экспоненциальных и полиномиальных линий тренда.

Например, модель стоимости производства может потребовать начала с известных фиксированных затрат в 100, даже если измерения при ненулевых объёмах производства показывают иной базовый уровень. Для линейной линии тренда фиксирование пересечения ограничивает уравнение `y = ax + b` значением `b = 100`; наклон подгоняется к данным при этом ограничении. Это не просто сдвигает уже подогнанную линию. Параметры пересечения осей управляют тем, где оси диаграммы встречаются, а не коэффициентами подогнанной линии тренда.

В следующем примере создаётся точечная (XY) диаграмма с объёмами производства от 1 до 4 и затратами 170, 200, 230 и 260. Диаграмма сохраняется с автоматически вычисленным пересечением, затем пересечение устанавливается в 100 и сохраняется вторая PPTX. Оба файла различаются только настройкой пересечения. Линия тренда отображает своё уравнение и расширяется назад до X = 0.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat, TrendlineType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ScatterWithMarkers, 20, 20, 480, 210)
    chart.setLegend(False)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    name_cell = workbook.getCell(0, 0, 1, "Production cost")
    series = chart.getChartData().getSeries().add(name_cell, ChartType.ScatterWithMarkers)
    costs = [170, 200, 230, 260]

    for i in range(len(costs)):
        x_cell = workbook.getCell(0, i + 1, 0, i + 1)
        y_cell = workbook.getCell(0, i + 1, 1, costs[i])
        series.getDataPoints().addDataPointForScatterSeries(x_cell, y_cell)

    trendline = series.getTrendLines().add(TrendlineType.Linear)
    trendline.setDisplayEquation(True)
    trendline.setBackward(1)

    presentation.save("AutomaticIntercept.pptx", SaveFormat.Pptx)

    trendline.setIntercept(100)
    presentation.save("FixedIntercept.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

При автоматическом расчёте эти данные дают `y = 30x + 140`. Установка пересечения в 100 вместо этого даёт примерно `y = 43.33x + 100`: подогнанное значение при нуле соответствует известному базовому уровню, а линия больше не проходит через каждую точку данных.

| Автоматический пересечение | Фиксированный пересечение 100 |
| --- | --- |
| ![Линейная линия тренда с автоматически рассчитанным пересечением 140](intercept-automatic.png) | ![Линейная линия тренда с фиксированным пересечением 100](intercept-fixed.png) |

Оба изображения используют одни и те же данные и масштабы осей. Линии тренда расширены назад до X = 0, чтобы показать их пересечения.

По умолчанию [getIntercept](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#getIntercept) возвращает `NaN`, что представляет неопределённое пересечение, а не ноль. Затем пересечение вычисляется автоматически из данных.

## **Добавить пользовательскую линию**

Пользовательская линия — это форма, нарисованная поверх диаграммы, а не линия тренда, вычисленная из данных серии. В этом примере используется [ShapeCollection.addAutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addAutoShape) для добавления горизонтальной линии на слайд над диаграммой. Позиция линии указывается в координатах слайда в пунктах, поэтому она начинается от левого края диаграммы и располагается посередине по высоте диаграммы. Её ширина соответствует ширине диаграммы. Метод [getLineFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getLineFormat) предоставляет доступ к форматированию линии, используемому для применения сплошного красного цвета.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 400)

    line = slide.getShapes().addAutoShape(ShapeType.Line, chart.getX(), chart.getY() + chart.getHeight() / 2, chart.getWidth(), 0)
    line.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    line.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED)

    presentation.save("AddCustomLines.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Что означают «вперёд» и «назад» для линии тренда?**

Это длина линии тренда, проецируемой вперёд/назад: для точечных (XY) диаграмм — в единицах оси; для остальных диаграмм — в количестве категорий. Допускаются только неотрицательные значения.

**Сохраняется ли линия тренда при экспорте презентации в PDF или SVG, а также при рендеринге слайда в изображение?**

Да. Aspose.Slides конвертирует презентации в [PDF](/slides/ru/python-java/convert-powerpoint-to-pdf/) или [SVG](/slides/ru/python-java/render-a-slide-as-an-svg-image/) и рендерит диаграммы в изображения; линии тренда, как часть диаграммы, сохраняются во всех этих операциях. Также доступен метод для [export an image of the chart](/slides/ru/python-java/create-shape-thumbnails/).