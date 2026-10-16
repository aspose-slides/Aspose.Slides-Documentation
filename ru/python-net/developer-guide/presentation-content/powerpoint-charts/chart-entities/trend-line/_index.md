---
title: Добавить линии тренда к диаграммам презентаций в Python
linktitle: Линия тренда
type: docs
url: /ru/python-net/trend-line/
keywords:
- диаграмма
- линия тренда
- экспоненциальная линия тренда
- линейная линия тренда
- логарифмическая линия тренда
- линия тренда скользящее среднее
- полиномиальная линия тренда
- степенная линия тренда
- пользовательская линия тренда
- PowerPoint
- презентация
- Python
- Aspose.Slides
description: "Быстро добавляйте и настраивайте линии тренда в диаграммах PowerPoint с помощью Aspose.Slides для Python через .NET — практическое руководство, чтобы заинтересовать вашу аудиторию."
---
## **Обзор**

В этой статье объясняется, как добавить линии тренда к диаграммам презентаций с использованием Aspose.Slides. Показано, как создать диаграмму, добавить линии тренда к сериям диаграммы и работать с несколькими типами линий тренда, включая экспоненциальные, линейные, логарифмические, скользящее среднее, полиномиальные и степенные. Также описывается, как добавить пользовательскую линию к диаграмме, вставив форму линии, и включён короткий FAQ о значениях проекции линии тренда вперёд и назад, а также о том, сохраняются ли линии тренда при экспорте в PDF или SVG и при рендеринге диаграмм в изображения.

## **Добавить линию тренда**

Используйте [TrendlineCollection.add](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendlinecollection/add/) для добавления линии тренда к серии диаграммы, выбирая её тип с помощью [TrendlineType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendlinetype/). Пример создаёт сгруппированную столбчатую диаграмму с данными по умолчанию и добавляет по две линии тренда к каждой из её трёх серий.

Экспоненциальная линия тренда скрывает своё уравнение и значение R‑квадрат с помощью [display_equation](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/display_equation/) и [display_r_squared_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/display_r_squared_value/), в то время как линейная линия тренда имеет красный цвет. Логарифмическая линия тренда использует [add_text_frame_for_overriding](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/add_text_frame_for_overriding/) для пользовательской подписи. Скользящее среднее использует [period](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/period/) равный трём точкам данных и пользовательское [trendline_name](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/trendline_name/).

Полиномиальная линия тренда имеет [order](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/order/) равный трём и расширяется на одну категорию вперёд с помощью [forward](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/forward/). Степенная линия тренда расширяется на одну категорию назад с помощью [backward](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/backward/).

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 400)

    first_series = chart.chart_data.series[0]

    exponential_trendline = first_series.trend_lines.add(charts.TrendlineType.EXPONENTIAL)
    exponential_trendline.display_equation = False
    exponential_trendline.display_r_squared_value = False

    linear_trendline = first_series.trend_lines.add(charts.TrendlineType.LINEAR)
    linear_trendline.format.line.fill_format.fill_type = slides.FillType.SOLID
    linear_trendline.format.line.fill_format.solid_fill_color.r = 255
    linear_trendline.format.line.fill_format.solid_fill_color.g = 0
    linear_trendline.format.line.fill_format.solid_fill_color.b = 0

    second_series = chart.chart_data.series[1]

    logarithmic_trendline = second_series.trend_lines.add(charts.TrendlineType.LOGARITHMIC)
    logarithmic_trendline.add_text_frame_for_overriding("New log trend line")

    moving_average_trendline = second_series.trend_lines.add(charts.TrendlineType.MOVING_AVERAGE)
    moving_average_trendline.period = 3
    moving_average_trendline.trendline_name = "New TrendLine Name"

    third_series = chart.chart_data.series[2]

    polynomial_trendline = third_series.trend_lines.add(charts.TrendlineType.POLYNOMIAL)
    polynomial_trendline.forward = 1
    polynomial_trendline.order = 3

    power_trendline = third_series.trend_lines.add(charts.TrendlineType.POWER)
    power_trendline.backward = 1

    presentation.save("ChartTrendLines.pptx", slides.export.SaveFormat.PPTX)
```

## **Установить пересечение линии тренда**

Используйте [intercept](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/intercept/) чтобы зафиксировать значение Y линии тренда при X = 0. Эта настройка поддерживается для линейных, экспоненциальных и полиномиальных линий тренда.

Например, модель стоимости производства может потребовать начинать с известных фиксированных расходов в 100, даже если измерения при ненулевых объёмах производства указывают на другую базу. Для линейной линии тренда фиксирование пересечения ограничивает уравнение `y = ax + b` до `b = 100`; наклон подгоняется к данным при этом ограничении. Это не просто перемещает уже подогнанную линию. Настройки пересечения осей определяют, где пересекаются оси диаграммы, а не коэффициенты подогнанной линии тренда.

В следующем примере создаётся точечная (XY) диаграмма с объёмами производства от 1 до 4 и затратами 170, 200, 230 и 260. Диаграмма сохраняется с автоматическим пересечением по умолчанию, затем пересечение устанавливается в 100, и сохраняется второй PPTX. Два файла отличаются только настройкой пересечения. Линия тренда отображает своё уравнение и расширяется назад до X = 0.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.SCATTER_WITH_MARKERS, 20, 20, 480, 210)
    chart.has_legend = False

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    name_cell = workbook.get_cell(0, 0, 1, "Production cost")
    series = chart.chart_data.series.add(name_cell, charts.ChartType.SCATTER_WITH_MARKERS)
    costs = [170, 200, 230, 260]

    for i, cost in enumerate(costs):
        x_cell = workbook.get_cell(0, i + 1, 0, i + 1)
        y_cell = workbook.get_cell(0, i + 1, 1, cost)
        series.data_points.add_data_point_for_scatter_series(x_cell, y_cell)

    trendline = series.trend_lines.add(charts.TrendlineType.LINEAR)
    trendline.display_equation = True
    trendline.backward = 1

    presentation.save("AutomaticIntercept.pptx", slides.export.SaveFormat.PPTX)

    trendline.intercept = 100
    presentation.save("FixedIntercept.pptx", slides.export.SaveFormat.PPTX)
```

При автоматическом расчёте эти данные дают `y = 30x + 140`. Установка пересечения в 100 вместо этого даёт примерно `y = 43.33x + 100`: подогнанное значение при нуле совпадает с известной базой, но линия больше не проходит через каждую точку данных.

| Автоматическое пересечение | Фиксированное пересечение 100 |
| --- | --- |
| ![Линейная линия тренда с автоматически рассчитанным пересечением 140](intercept-automatic.png) | ![Линейная линия тренда с фиксированным пересечением 100](intercept-fixed.png) |

Оба изображения используют одни и те же данные и масштабы осей. Линии тренда расширены назад до X = 0, чтобы показать их пересечения.

По умолчанию свойство содержит `float("nan")`, что представляет неуказанное пересечение, а не ноль. Затем пересечение рассчитывается автоматически из данных.

## **Добавить пользовательскую линию**

Пользовательская линия — это форма, нарисованная поверх диаграммы, а не линия тренда, рассчитанная по данным серии. В этом примере используется [ShapeCollection.add_auto_shape](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_auto_shape/) чтобы добавить горизонтальную линию на слайд поверх диаграммы. Позиция линии задаётся в координатах слайда в пунктах, поэтому она начинается от левого края диаграммы и находится на полпути вниз по диаграмме. Ее ширина соответствует ширине диаграммы. [line_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/line_format/) задаёт линии сплошной красный цвет.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 500, 400)

    line = slide.shapes.add_auto_shape(slides.ShapeType.LINE, chart.x, chart.y + chart.height / 2, chart.width, 0)
    line.line_format.fill_format.fill_type = slides.FillType.SOLID
    line.line_format.fill_format.solid_fill_color.r = 255
    line.line_format.fill_format.solid_fill_color.g = 0
    line.line_format.fill_format.solid_fill_color.b = 0

    presentation.save("AddCustomLines.pptx", slides.export.SaveFormat.PPTX)
```

## **Вопросы и ответы**

**Что означают «forward» и «backward» для линии тренда?**

Это длина линии тренда, проецируемой вперёд/назад: для точечных (XY) диаграмм — в единицах осей; для не точечных диаграмм — в количестве категорий. Допустимы только неотрицательные значения.

**Будет ли линия тренда сохранена при экспорте презентации в PDF или SVG, или при рендеринге слайда в изображение?**

Да. Aspose.Slides преобразует презентации в [PDF](/slides/ru/python-net/convert-powerpoint-to-pdf/) или [SVG](/slides/ru/python-net/render-a-slide-as-an-svg-image/) и рендерит диаграммы в изображения; линии тренда, как часть диаграммы, сохраняются во время этих операций. Также доступен метод для [экспортировать изображение диаграммы](/slides/ru/python-net/create-shape-thumbnails/).