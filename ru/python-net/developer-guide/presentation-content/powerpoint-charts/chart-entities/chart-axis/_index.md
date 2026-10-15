---
title: Настройка осей диаграмм в презентациях с Python
linktitle: Ось диаграммы
type: docs
url: /ru/python-net/chart-axis/
keywords:
- ось диаграммы
- вертикальная ось
- горизонтальная ось
- настройка оси
- управление осью
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
description: "Узнайте, как использовать Aspose.Slides для Python через .NET, чтобы настроить оси диаграмм в презентациях PowerPoint и OpenDocument для отчетов и визуализаций."
---
## **Обзор**

В этой статье объясняется, как настраивать оси диаграмм с помощью Aspose.Slides для Python через .NET. Рассматриваются вычисленные значения осей, переключение строк и столбцов диаграммы, видимость осей, интервалы меток категорий и делений, категории дат и их форматирование, поворот заголовка, позиционирование осей, единицы отображения и логарифмическое масштабирование.

## **Получить максимальные значения на вертикальной оси в диаграммах**

Создайте [Презентацию](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) и добавьте диаграмму области с данными по умолчанию. Вызовите [validate_chart_layout](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/validate_chart_layout/) перед чтением вычисленных значений осей, чтобы макет диаграммы был актуальным.

Прочитайте [actual_max_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_max_value/) и [actual_min_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_min_value/) для пределов оси, а также [actual_major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_major_unit/) и [actual_minor_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_minor_unit/) для интервалов делений. [actual_major_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_major_unit_scale/) и [actual_minor_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_minor_unit_scale/) предоставляют масштаб единиц времени, который актуален для осей дат. Пример сохраняет эти значения в локальные переменные и сохраняет диаграмму.

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

## **Обмен данными между осями**

Используйте [switch_row_column](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/switch_row_column/) для обмена ролями рядов и категорий в данных диаграммы. Каждая прежняя категория становится рядом, а каждый прежний ряд — категорией. Это меняет способ группировки данных; это не меняет местами горизонтальную и вертикальную оси. В примере используется [set_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_range/) для привязки данных по умолчанию к `Sheet1!A1:D5`, включая строку заголовка и столбец категорий, перед переключением строк и столбцов. Он сохраняет диаграмму с четырьмя рядами и тремя категориями.

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

## **Обратить порядок построения оси**

Используйте [is_plot_order_reversed](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_plot_order_reversed/) для обратного порядка построения категориальной или числовой оси. Например, горизонтальная гистограмма может показывать стадии проекта сверху вниз в том же порядке, что и в таблице: Планирование, Разработка, Тестирование. Обратный порядок меняет направление построения; он не сортирует и не переставляет данные книги. Для сравнения, [switch_row_column](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/switch_row_column/) меняет роли рядов и категорий.

Следующий пример создает горизонтальную гистограмму с тремя стадиями и одним рядом. Он сохраняет презентацию из трех слайдов: обычный порядок, обратные категории и обратные значения. Каждая копия использует те же наборы данных, и только одна ось обратна в каждой копии.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_BAR, 50, 40, 620, 320)
    chart.has_legend = False

    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    series = chart.chart_data.series.add(charts.ChartType.CLUSTERED_BAR)
    stages = ["Planning", "Development", "Testing"]
    values = [10, 30, 20]
    for i, stage in enumerate(stages):
        category_cell = workbook.get_cell(0, i + 1, 0, stage)
        chart.chart_data.categories.add(category_cell)
        value_cell = workbook.get_cell(0, i + 1, 1, values[i])
        series.data_points.add_data_point_for_bar_series(value_cell)

    # Слайд 2: отображать первую категорию вверху.
    category_slide = presentation.slides.add_clone(slide)
    category_chart = category_slide.shapes[0]
    category_chart.axes.vertical_axis.is_plot_order_reversed = True
    # Сохранить горизонтальную ось значений внизу.
    category_chart.axes.vertical_axis.cross_type = charts.CrossesType.MAXIMUM

    # Слайд 3: обратить только горизонтальную числовую шкалу.
    value_slide = presentation.slides.add_clone(slide)
    value_chart = value_slide.shapes[0]
    value_chart.axes.horizontal_axis.is_plot_order_reversed = True

    presentation.save("ReversedAxes.pptx", slides.export.SaveFormat.PPTX)
```

Обратный порядок оси может также переместить перпендикулярную ось на противоположную сторону построения. [cross_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_type/) управляет тем, где другая ось пересекает настраиваемую ось. На слайде 2 установка значения `MAXIMUM` на обратной оси категорий сохраняет горизонтальную ось значений внизу. Для указания конкретной точки пересечения используйте [cross_at](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_at/). Проверьте настройки пересечения при изменении направления, особенно если диаграмма уже имеет пользовательскую точку пересечения. Установите `is_plot_order_reversed` обратно в `False`, чтобы восстановить обычное направление построения; настройки пересечения остаются отдельными.

| Обычный порядок (слайд 1) | Обратные категории (слайд 2) | Обратные значения (слайд 3) |
| --- | --- | --- |
| ![Горизонтальная гистограмма с обычным порядком категорий и осей значений](axis-order-normal.png) | ![Горизонтальная гистограмма с категориями, отображаемыми сверху вниз](axis-order-categories-reversed.png) | ![Горизонтальная гистограмма с обратной осью значений и нулём справа](axis-order-values-reversed.png) |
| Категории идут снизу вверх; значения растут слева направо. | Планирование, Разработка и Тестирование идут сверху вниз. Значения и порядок строк книги не изменяются. | Категории сохраняют обычный порядок; значения растут справа налево. Ось категорий пересекает ноль справа. |

## **Отключить вертикальную ось для линейных диаграмм**

Установите [is_visible](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_visible/) в `False` для вертикальной оси, чтобы скрыть её. В примере создаётся линейная диаграмма с данными по умолчанию и сохраняется с скрытой вертикальной осью.

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

Установите [is_visible](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_visible/) в `False` для горизонтальной оси, чтобы скрыть её. В примере создаётся линейная диаграмма с данными по умолчанию и сохраняется с скрытой горизонтальной осью.

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

Установите [category_axis_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/category_axis_type/) для выбора оси категорий даты или текста. Этот пример требует `ExistingChart.pptx`, где диаграмма является первой фигурой на первом слайде, а ячейки категорий содержат числовые значения дат Excel. Он меняет горизонтальную ось на ось даты. Установка [is_automatic_major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_major_unit/) в `False`, [major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit/) в `1` и [major_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit_scale/) в месяца размещает основные деления через один‑месячный интервал.

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

## **Управление интервалами меток оси категорий**

Когда в диаграмме много категорий, уменьшите количество видимых меток оси, не удаляя категории или точки данных. Установите [is_automatic_tick_label_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_tick_label_spacing/) в `False`, затем задайте [tick_label_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_label_spacing/) желаемый интервал категорий. Для текстовых категорий в обычном порядке счёт начинается с первой категории:

| Интервал | Метки, отображаемые в примере |
| --- | --- |
| `1` | Категория 1, Категория 2, Категория 3, ... Категория 24 |
| `2` | Категория 1, Категория 3, Категория 5, ... Категория 23 |
| `3` | Категория 1, Категория 4, Категория 7, ... Категория 22 |

Интервал `3` отображает каждую третью метку, оставляя две скрытыми между отображаемыми. Это не удаляет соответствующие столбцы. Автоматический интервал выбирает значение исходя из доступного места; он не обязательно отображает каждую метку.

Метки делений имеют отдельные настройки. Установите [is_automatic_tick_marks_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_tick_marks_spacing/) в `False` и используйте [tick_marks_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_marks_spacing/) для задания их интервала. Например, `1` сохраняет деление на каждом интервале категории, пока метки появляются только каждые три категории. Установите [major_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_tick_mark/) в видимый стиль, чтобы увидеть результат. Возврат любого из автоматических свойств к `True` позволяет диаграмме снова выбрать этот интервал.

Следующий автономный пример создаёт 24 категории и один ряд, затем сохраняет три слайда в `CategoryAxisIntervals.pptx`: автоматический интервал, ручной интервал меток с независимыми делениями и восстановленный автоматический интервал. Обе копии сохраняют исходные данные диаграммы. Входная презентация не требуется. Горизонтальный текст меток делает различие в плотности легко видимым.

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

    # Слайд 2: показать каждую третью метку, но оставлять деление для каждой категории.
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

**Автоматический интервал (слайд 1):** В этом отображении каждая вторая метка категории показывается и переносится на две строки. Автоматический результат может зависеть от размера диаграммы, шрифтов и средства рендеринга.

![Автоматический интервал меток категорий при отображении всех 24 столбцов](category-axis-automatic.png)

**Ручной интервал (слайд 2):** Каждая третья метка отображается в одной строке, тогда как деления остаются на каждом интервале категории. Все 24 столбца, включая те, у которых нет меток, остаются видимыми с теми же значениями. Слайд 3 восстанавливает автоматический вид, показанный выше.

![Ручной интервал меток категории в три с отображением всех 24 столбцов](category-axis-manual.png)

### **Выберите правильную ось и интервал**

Используйте этот интервал количества категорий для текстовой оси категорий, например для оси категории столбчатой, линейной, площадной или гистограммы. В столбчатой диаграмме это горизонтальная ось. В горизонтальной гистограмме ось категорий вертикальна, поэтому применяйте эти настройки к [vertical_axis](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axesmanager/vertical_axis/). Настройка интервала делений также применяется к оси рядов в диаграммах, где она присутствует.

Не используйте интервал меток категории для задания числовой шкалы оси значений. На оси значений [major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit/) определяет разницу значений: например, основной шаг `10` создаёт деления 0, 10, 20 и т.д., когда ось начинается с нуля. Интервал метки категории `3` считает позиции категорий независимо от их данных. Диаграммы разброса и пузырьковые используют оси значений, а не текстовую ось категорий. Для оси даты используйте временные основные единицы и масштабы, описанные в [Изменить ось категорий](#change-a-category-axis).

## **Установить формат даты для значений оси категорий**

Пример заменяет данные диаграммы по умолчанию четырьмя годовыми значениями. Даты хранятся как серийные числа OLE Automation в первой рабочей таблице (индекс `0`). Установите [category_axis_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/category_axis_type/) в ось даты, отключите [is_number_format_linked_to_source](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_number_format_linked_to_source/) и задайте `yyyy` в [number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/number_format/), чтобы метки категории показывали четырёхзначные годы независимо от формата ячейки.

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

## **Задать угол поворота заголовка оси диаграммы**

Включите [has_title](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/has_title/) на вертикальной оси, задайте текст заголовка и установите [rotation_angle](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/rotation_angle/) для поворота заголовка. Угол измеряется в градусах; пример сохраняет столбчатую диаграмму с заголовком оси значений, повернутым на 90 градусов.

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

## **Задать позицию оси на оси категорий или значений**

Используйте [axis_between_categories](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/axis_between_categories/) для управления тем, пересекает ли ось значений ось категорий между категориями или на делениях категорий. Это свойство относится к осям категорий. Пример устанавливает его в `True` на горизонтальной оси категорий столбчатой диаграммы и сохраняет результат.

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

Установите [display_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/display_unit/) для масштабирования меток оси значений без изменения исходных данных. При установке [DisplayUnitType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/displayunittype/) в `MILLIONS` значение 60 000 000 отображается как 60. Пример создаёт столбчатую диаграмму и применяет единицу отображения «миллионы» к её вертикальной оси.

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

Логарифмическая ось значений полезна, когда положительные значения охватывают несколько порядков величины. Например, сервис может получать 10, 100, 1 000, 10 000 и 100 000 запросов за пять периодов. На линейной шкале небольшие значения собираются рядом у нуля. Логарифмическая шкала делает их относительный рост легче сравнивать: одинаковые расстояния представляют одинаковые соотношения, а не одинаковые разности.

Установите [is_logarithmic](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_logarithmic/) в `True` для оси значений и используйте [log_base](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/log_base/) для выбора основания. Это меняет отображение существующих значений; это не меняет данные и не добавляет логарифмическую линию тренда. Линия тренда представляет подгонку зависимости в данных и является отдельной функцией.

### **Выберите ось значений и основание**

Для линейной или столбчатой диаграммы осью значений является [vertical_axis](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axesmanager/vertical_axis/). Для горизонтальной гистограммы она — [horizontal_axis](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axesmanager/horizontal_axis/). Диаграммы разброса и пузырьковые имеют две оси значений, поэтому выбирайте горизонтальную ось для значений X, вертикальную для Y или обе. Не применяйте логарифмическое масштабирование к оси категорий.

Базовое логарифмическое основание по умолчанию — `10`. Для диаграмм PPTX используйте основание от `2` до `1000` включительно; также поддерживаются дробные основания, такие как `2.5`. При основании `10` последовательные степени 10, 100, 1 000 и 10 000 размещаются равномерно.

### **Сравнение линейного и логарифмического масштабирования**

Следующий автономный пример создаёт линейную диаграмму с пятью величинами запросов на первом слайде, затем клонирует этот слайд и включает логарифмическую ось значений с основанием 10 на втором. Оба слайда сохраняют одинаковые данные.

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

    # Оставить первый слайд линейным и изменить только масштаб оси значений у копии.
    logarithmic_slide = presentation.slides.add_clone(slide)
    logarithmic_chart = logarithmic_slide.shapes[0]
    value_axis = logarithmic_chart.axes.vertical_axis
    value_axis.is_logarithmic = True
    value_axis.log_base = 10

    presentation.save("LogarithmicAxis.pptx", slides.export.SaveFormat.PPTX)
```

**Линейный масштаб (слайд 1):** Равные вертикальные расстояния представляют равные различия в количестве запросов. Наибольшее значение доминирует в диаграмме, делая меньшие значения трудно различимыми.

![Линейная диаграмма в PowerPoint, показывающая пять величин запросов на линейной оси значений](value-axis-linear.png)

**Логарифмический масштаб (слайд 2):** Равные вертикальные расстояния представляют равные отношения. Каждый период имеет в десять раз больше запросов, чем предыдущий, поэтому точки образуют прямую восходящую линию на шкале с основанием 10. Метки оси всё равно показывают исходные количества запросов.

![Те же пять величин запросов в PowerPoint на логарифмической оси значений с основанием 10](value-axis-logarithmic.png)

### **Обрабатывать нулевые и отрицательные значения**

Логарифмическая шкала может отображать только строго положительные значения. Проверьте данные перед включением её. Если нулевые или отрицательные значения имеют смысл, оставьте линейную шкалу или показывайте их отдельно. Если исключение этих значений уместно для анализа, объясните причину. Не заменяйте их скрыто небольшими положительными числами, так как это меняет смысл данных. Любой вручную настроенный минимум или максимум для логарифмической оси также должен быть положительным.

## **Часто задаваемые вопросы**

**Как задать значение, в котором одна ось пересекает другую (пересечение осей)?**  
Используйте [cross_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_type/) для выбора поведения пересечения. Чтобы указать числовое значение пересечения, установите [cross_at](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_at/). Эти настройки позволяют переместить пересечение осей к подходящей базовой линии.

**Как позиционировать метки делений относительно оси?**  
Установите [tick_label_position](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_label_position/) с помощью [TickLabelPositionType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ticklabelpositiontype/): `LOW`, `HIGH`, `NEXT_TO` или `NONE`. Чтобы управлять самими делениями, используйте [major_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_tick_mark/) или [minor_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/minor_tick_mark/); они независимы от позиционирования меток.