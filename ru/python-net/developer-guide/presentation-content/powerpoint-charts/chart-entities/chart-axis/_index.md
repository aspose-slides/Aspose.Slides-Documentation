---
title: Настройка осей диаграмм в презентациях с помощью Python
linktitle: Ось диаграммы
type: docs
url: /ru/python-net/chart-axis/
keywords:
- ось диаграммы
- вертикальная ось
- горизонтальная ось
- настройка оси
- манипулирование осью
- управление осью
- свойства оси
- максимальное значение
- минимальное значение
- линия оси
- формат даты
- заголовок оси
- позиция оси
- PowerPoint
- OpenDocument
- презентация
- Python
- Aspose.Slides
description: "Узнайте, как использовать Aspose.Slides для Python через .NET, чтобы настраивать оси диаграмм в презентациях PowerPoint и OpenDocument для отчетов и визуализаций."
---
## **Обзор**

Эта статья объясняет, как настраивать оси диаграмм с помощью Aspose.Slides для Python через .NET. В ней рассматриваются вычисленные значения осей, переключение строк и столбцов диаграммы, видимость осей, интервалы подписи категорий и делений, даты категорий и их форматирование, вращение заголовка, позиционирование осей, единицы отображения и логарифмическое масштабирование.

## **Получить максимальные значения на вертикальной оси диаграмм**

Создайте [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) и добавьте областную диаграмму с данными по умолчанию. Вызовите [validate_chart_layout](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/validate_chart_layout/) перед чтением вычисленных значений осей, чтобы расположение диаграммы было актуальным.

Прочитайте [actual_max_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_max_value/) и [actual_min_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_min_value/) для пределов оси, а также [actual_major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_major_unit/) и [actual_minor_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_minor_unit/) для интервалов делений. [actual_major_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_major_unit_scale/) и [actual_minor_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_minor_unit_scale/) предоставляют масштабы временных единиц, актуальные для датированных осей. Пример сохраняет эти значения в локальные переменные и сохраняет диаграмму.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.AREA, 100, 100, 500, 350)
    chart.validate_chart_layout()

    max_value = chart.axes.vertical_axis.actual_max_value
    min_value = chart.axes.vertical_axis.actual_min_value

    major_unit = chart.axes.vertical_axis.actual_major_unit
    minor_unit = chart.axes.vertical_axis.actual_minor_unit

    major_unit_scale = chart.axes.vertical_axis.actual_major_unit_scale
    minor_unit_scale = chart.axes.vertical_axis.actual_minor_unit_scale

    presentation.save("AxisValues_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Переставить данные между осями**

Используйте [switch_row_column](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/switch_row_column/) для обмена ролями рядов и категорий в данных диаграммы. Каждая бывшая категория становится рядом, а каждый бывший ряд — категорией. Это меняет способ группировки данных; это не меняет местами горизонтальную и вертикальную оси. Пример использует [set_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_range/) для привязки данных по умолчанию к `Sheet1!A1:D5`, включая строку заголовка и столбец категорий, перед переключением строк и столбцов. Он сохраняет диаграмму с четырьмя рядами и тремя категориями.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 400, 300)

    chart.chart_data.set_range("Sheet1!A1:D5")
    chart.chart_data.switch_row_column()

    presentation.save("SwitchChartRowColumns_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Отключить вертикальную ось для линейных диаграмм**

Установите [is_visible](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_visible/) в `False` для вертикальной оси, чтобы скрыть её. Пример создаёт линейную диаграмму с данными по умолчанию и сохраняет её с скрытой вертикальной осью.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE, 100, 100, 400, 300)
    chart.axes.vertical_axis.is_visible = False

    presentation.save("HiddenVerticalAxis.pptx", slides.export.SaveFormat.PPTX)
```

## **Отключить горизонтальную ось для линейных диаграмм**

Установите [is_visible](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_visible/) в `False` для горизонтальной оси, чтобы скрыть её. Пример создаёт линейную диаграмму с данными по умолчанию и сохраняет её с скрытой горизонтальной осью.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE, 100, 100, 400, 300)
    chart.axes.horizontal_axis.is_visible = False

    presentation.save("HiddenHorizontalAxis.pptx", slides.export.SaveFormat.PPTX)
```

## **Изменить ось категорий**

Установите [category_axis_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/category_axis_type/) для выбора оси категорий даты или текста. Этот пример требует `ExistingChart.pptx`, где диаграмма является первой фигурой на первом слайде, а ячейки категорий содержат числовые значения даты Excel. Он меняет горизонтальную ось на ось даты. Установка [is_automatic_major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_major_unit/) в `False`, [major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit/) в `1` и [major_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit_scale/) в months размещает основные деления с интервалом в один месяц.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("ExistingChart.pptx") as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes[0]
    chart.axes.horizontal_axis.category_axis_type = charts.CategoryAxisType.DATE
    chart.axes.horizontal_axis.is_automatic_major_unit = False
    chart.axes.horizontal_axis.major_unit = 1
    chart.axes.horizontal_axis.major_unit_scale = charts.TimeUnitType.MONTHS

    presentation.save("ChangeChartCategoryAxis_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Управление интервалами подписей оси категорий**

Когда диаграмма содержит много категорий, уменьшите число видимых подписей оси, не удаляя категории или точки данных. Установите [is_automatic_tick_label_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_tick_label_spacing/) в `False`, затем задайте [tick_label_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_label_spacing/) желаемый интервал категории. Для текстовых категорий в их обычном порядке нумерация начинается с первой категории:

| Интервал | Подписи, отображаемые в примере |
| --- | --- |
| `1` | Категория 1, Категория 2, Категория 3, ... Категория 24 |
| `2` | Категория 1, Категория 3, Категория 5, ... Категория 23 |
| `3` | Категория 1, Категория 4, Категория 7, ... Категория 22 |

Интервал `3` отображает каждую третью подпись, оставляя две подписи скрытыми между отображаемыми. Это не удаляет соответствующие столбцы. Автоматический выбор интервала основывается на доступном пространстве; он не обязательно отображает каждую подпись.

Деления имеют отдельные настройки. Установите [is_automatic_tick_marks_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_tick_marks_spacing/) в `False` и используйте [tick_marks_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_marks_spacing/) для задания их интервала. Например, `1` оставляет деление на каждом интервале категории, тогда как подписи появляются только каждые три категории. Установите [major_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_tick_mark/) в видимый стиль, чтобы увидеть результат. Возврат любого из автоматических свойств к `True` позволяет диаграмме снова выбрать подходящий интервал.

Следующий самостоятельный пример создаёт 24 категории и один ряд, затем сохраняет три слайда в `CategoryAxisIntervals.pptx`: автоматический интервал, ручной интервал подписей с независимыми делениями и восстановленный автоматический интервал. Две копии сохраняют исходные данные диаграммы. Вводная презентация не требуется. Горизонтальный текст подписи облегчает восприятие плотности.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 30, 40, 660, 320)

    chart.has_legend = False
    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    series = chart.chart_data.series.add(charts.ChartType.CLUSTERED_COLUMN)
    for i in range(24):
        category_cell = workbook.get_cell(0, i + 1, 0, f"Category {i + 1}")
        chart.chart_data.categories.add(category_cell)
        value_cell = workbook.get_cell(0, i + 1, 1, 10 + i % 6 * 5)
        series.data_points.add_data_point_for_bar_series(value_cell)

    axis = chart.axes.horizontal_axis
    axis.category_axis_type = charts.CategoryAxisType.TEXT
    axis.text_format.text_block_format.rotation_angle = 0
    axis.text_format.portion_format.font_height = 12
    axis.major_tick_mark = charts.TickMarkType.OUTSIDE
    axis.is_automatic_tick_label_spacing = True
    axis.is_automatic_tick_marks_spacing = True

    # Слайд 2: показывать каждую третью подпись, но сохранять деление для каждой категории.
    manual_slide = presentation.slides.add_clone(slide)
    manual_chart = manual_slide.shapes[0]
    manual_axis = manual_chart.axes.horizontal_axis
    manual_axis.is_automatic_tick_label_spacing = False
    manual_axis.tick_label_spacing = 3
    manual_axis.is_automatic_tick_marks_spacing = False
    manual_axis.tick_marks_spacing = 1

    # Слайд 3: позволить диаграмме снова выбрать оба интервала.
    restored_slide = presentation.slides.add_clone(manual_slide)
    restored_chart = restored_slide.shapes[0]
    restored_chart.axes.horizontal_axis.is_automatic_tick_label_spacing = True
    restored_chart.axes.horizontal_axis.is_automatic_tick_marks_spacing = True

    presentation.save("CategoryAxisIntervals.pptx", slides.export.SaveFormat.PPTX)
```

**Automatic spacing (slide 1):** In this rendering, every second category label is displayed and wraps onto two lines. The automatic result can vary with chart size, fonts, and the renderer.

![Automatic category label spacing with all 24 columns visible](category-axis-automatic.png)

**Manual spacing (slide 2):** Every third label is displayed on one line, while tick marks remain at every category interval. All 24 columns, including those without labels, remain visible with the same values. Slide 3 restores the automatic appearance shown above.

![Manual category label interval of three with all 24 columns visible](category-axis-manual.png)

### **Выберите правильную ось и интервал**

Используйте этот интервал количества категорий для текстовой оси категорий, например оси категорий столбчатой, линейной, областной или гистограммы. В столбчатой диаграмме это горизонтальная ось. В горизонтальной гистограмме ось категорий вертикальна, поэтому применяйте эти настройки к [vertical_axis](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axesmanager/vertical_axis/). Интервал делений также применяется к оси рядов в диаграммах, где она присутствует.

Не используйте интервалы подписей категорий для задания числовой шкалы оси значений. На оси значений [major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit/) определяет разницу в значениях: например, основной шаг `10` создаёт деления на 0, 10, 20 и т.д., когда ось начинается с нуля. Интервал подписи категории `3` вместо этого считает позиции категорий, независимо от их значений. Диаграммы рассеяния и пузырьковые используют оси значений, а не текстовую ось категорий. Для оси даты используйте временные основные единицы и масштабы, как описано в [Изменить ось категорий](#change-a-category-axis).

## **Установить формат даты для значений оси категорий**

Пример заменяет данные диаграммы на четыре годовых значения. Даты хранятся как серийные номера OLE Automation в первом листе (индекс `0`). Установите [category_axis_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/category_axis_type/) в ось даты, отключите [is_number_format_linked_to_source](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_number_format_linked_to_source/) и задайте `yyyy` в [number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/number_format/) чтобы подписи категорий отображали четырёхзначный год независимо от форматирования ячеек.

```python
from datetime import date

import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE, 50, 50, 450, 300)

    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    series = chart.chart_data.series.add(charts.ChartType.LINE)
    for i in range(4):
        category_date = date(2015 + i, 1, 1)
        serial_date = (category_date - date(1899, 12, 30)).days
        category_cell = workbook.get_cell(0, i + 1, 0, serial_date)
        chart.chart_data.categories.add(category_cell)

        value_cell = workbook.get_cell(0, i + 1, 1, i + 1)
        series.data_points.add_data_point_for_line_series(value_cell)

    chart.axes.horizontal_axis.category_axis_type = charts.CategoryAxisType.DATE
    chart.axes.horizontal_axis.is_number_format_linked_to_source = False
    chart.axes.horizontal_axis.number_format = "yyyy"

    presentation.save("DateAxisFormat.pptx", slides.export.SaveFormat.PPTX)
```

## **Установить угол поворота заголовка оси диаграммы**

Включите [has_title](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/has_title/) на вертикальной оси, задайте текст заголовка и установите [rotation_angle](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/rotation_angle/) для поворота заголовка. Угол измеряется в градусах; этот пример сохраняет столбчатую диаграмму с заголовком оси значений, повернутым на 90 градусов.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
    chart.axes.vertical_axis.has_title = True
    chart.axes.vertical_axis.title.add_text_frame_for_overriding("Value")
    chart.axes.vertical_axis.title.text_format.text_block_format.rotation_angle = 90

    presentation.save("RotatedAxisTitle.pptx", slides.export.SaveFormat.PPTX)
```

## **Установить позицию оси на категории или оси значений**

Используйте [axis_between_categories](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/axis_between_categories/) для управления тем, пересекает ли ось значений ось категорий между категориями или на отметках категории. Это свойство применяется к осям категорий. Пример устанавливает его в `True` на горизонтальной оси категорий столбчатой диаграммы и сохраняет результат.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
    chart.axes.horizontal_axis.axis_between_categories = True

    presentation.save("AxisBetweenCategories.pptx", slides.export.SaveFormat.PPTX)
```

## **Установить единицу отображения на оси значений диаграммы**

Установите [display_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/display_unit/) для масштабирования подписей на оси значений без изменения базовых данных. При [DisplayUnitType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/displayunittype/) `MILLIONS` значение 60 000 000 отображается как 60. Пример создаёт столбчатую диаграмму и применяет единицу отображения миллионов к её вертикальной оси.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
    chart.axes.vertical_axis.display_unit = charts.DisplayUnitType.MILLIONS

    presentation.save("Result.pptx", slides.export.SaveFormat.PPTX)
```

## **Настроить логарифмическую ось значений**

Логарифмическая ось значений полезна, когда положительные значения охватывают несколько порядков величины. Например, сервис может получать 10, 100, 1 000, 10 000 и 100 000 запросов за пять периодов. При линейной шкале меньшие значения находятся близко друг к другу у нуля. Логарифмическая шкала делает их относительный рост легче сравнивать: равные расстояния представляют равные отношения, а не равные разницы.

Установите [is_logarithmic](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_logarithmic/) в `True` на оси значений и используйте [log_base](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/log_base/) для выбора основания. Это меняет отображение существующих значений; это не меняет данные и не добавляет логарифмическую линию тренда. Линия тренда представляет подгонку зависимости в данных и является отдельной функцией.

### **Выберите ось значений и основание**

Для линейной или столбчатой диаграммы ось значений — это [vertical_axis](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axesmanager/vertical_axis/). Для горизонтальной гистограммы — [horizontal_axis](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axesmanager/horizontal_axis/). Диаграммы рассеяния и пузырьковые имеют две оси значений, поэтому выбирайте горизонтальную ось для значений X, вертикальную ось для Y или обе. Не применяйте логарифмическое масштабирование к оси категорий.

Основание логарифмической шкалы по умолчанию `10`. Для PPTX‑диаграмм используйте основание от `2` до `1000` включительно; также поддерживаются дробные основания, такие как `2.5`. При основании `10` последовательные степени 10, 100, 1 000 и 10 000 равномерно распределены.

### **Сравнить линейное и логарифмическое масштабирование**

Следующий самостоятельный пример создаёт линейную диаграмму с пятью количествами запросов на первом слайде, затем клонирует этот слайд и включает логарифмическую ось значений с основанием 10 на втором. Оба слайда сохраняют одинаковые данные.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE, 30, 40, 660, 200)

    chart.has_legend = False

    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    series = chart.chart_data.series.add(charts.ChartType.LINE)
    values = [10, 100, 1000, 10000, 100000]

    for i, value in enumerate(values):
        category_cell = workbook.get_cell(0, i + 1, 0, f"Period {i + 1}")
        chart.chart_data.categories.add(category_cell)

        value_cell = workbook.get_cell(0, i + 1, 1, value)
        series.data_points.add_data_point_for_line_series(value_cell)

    # Оставьте первый слайд линейным и измените только масштаб оси значений копии.
    logarithmic_slide = presentation.slides.add_clone(slide)
    logarithmic_chart = logarithmic_slide.shapes[0]
    value_axis = logarithmic_chart.axes.vertical_axis
    value_axis.is_logarithmic = True
    value_axis.log_base = 10

    presentation.save("LogarithmicAxis.pptx", slides.export.SaveFormat.PPTX)
```

**Linear scale (slide 1):** Equal vertical distances represent equal differences in request counts. The largest value dominates the chart, making the smaller values difficult to distinguish.

![Line chart in PowerPoint showing five request counts on a linear value axis](value-axis-linear.png)

**Logarithmic scale (slide 2):** Equal vertical distances represent equal ratios. Each period has ten times as many requests as the previous one, so the points form a straight rising line on the base-10 scale. The axis labels still show the original request counts.

![The same five request counts in PowerPoint on a base-10 logarithmic value axis](value-axis-logarithmic.png)

### **Обрабатывать нулевые и отрицательные значения**

Логарифмическая шкала может отображать только строго положительные значения. Проверьте данные перед включением её. Если нулевые или отрицательные значения имеют смысл, оставьте линейную шкалу или отображайте их отдельно. Если исключение этих значений оправдано анализом, объясните причину. Не заменяйте их тихо небольшими положительными числами, так как это меняет смысл данных. Любой вручную установленный минимум или максимум для логарифмической оси также должен быть положительным.

## **FAQ**

**Как установить значение, где одна ось пересекает другую (пересечение осей)?**

Используйте [cross_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_type/) для выбора поведения пересечения. Чтобы задать числовое значение пересечения, установите [cross_at](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_at/). Эти настройки позволяют переместить пересечение осей к подходящему базовому уровню.

**Как позиционировать подписи делений относительно оси?**

Установите [tick_label_position](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_label_position/) используя [TickLabelPositionType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ticklabelpositiontype/): `LOW`, `HIGH`, `NEXT_TO` или `NONE`. Чтобы управлять самими делениями, используйте [major_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_tick_mark/) или [minor_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/minor_tick_mark/); они отдельны от позиционирования подписей.