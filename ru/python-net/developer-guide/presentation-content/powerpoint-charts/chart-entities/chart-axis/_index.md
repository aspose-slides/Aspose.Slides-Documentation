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

В этой статье объясняется, как настраивать оси диаграмм с помощью Aspose.Slides для Python через .NET. Рассматриваются вычисляемые значения осей, переключение строк и столбцов диаграммы, видимость осей, интервалы подписей категорий и делений, даты категорий и их форматирование, поворот заголовка, позиционирование осей, единицы отображения и логарифмическое масштабирование.

## **Получить максимальные значения на вертикальной оси в диаграммах**

Создайте [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) и добавьте областную диаграмму с данными по умолчанию. Вызовите [validate_chart_layout](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/validate_chart_layout/) перед чтением вычисляемых значений осей, чтобы макет диаграммы был актуален.

Прочитайте [actual_max_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_max_value/) и [actual_min_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_min_value/) для пределов оси, а также [actual_major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_major_unit/) и [actual_minor_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_minor_unit/) для интервалов делений. [actual_major_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_major_unit_scale/) и [actual_minor_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_minor_unit_scale/) предоставляют масштаб единиц времени, что актуально для осей даты. Пример сохраняет эти значения в локальные переменные и сохраняет диаграмму.

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

## **Перестановка данных между осями**

Используйте [switch_row_column](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/switch_row_column/) для обмена ролями рядов и категорий в данных диаграммы. Каждая прежняя категория становится рядом, а каждый прежний ряд становится категорией. Это меняет способ группировки данных; это не меняет горизонтальные и вертикальные оси. Пример использует [set_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_range/) для привязки данных по умолчанию к `Sheet1!A1:D5`, включая строку заголовков и столбец категорий, перед переключением строк и столбцов. Он сохраняет диаграмму с четырьмя рядами и тремя категориями.

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

## **Обратный порядок построения оси**

Используйте [is_plot_order_reversed](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_plot_order_reversed/) для обратного порядка построения категориальной или оси значений. Например, горизонтальная гистограмма может отображать этапы проекта сверху вниз в том же порядке, что и лист: Планирование, Разработка, Тестирование. Обратный порядок меняет направление построения; он не сортирует и не переставляет данные листа. Для сравнения, [switch_row_column](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/switch_row_column/) меняет роли рядов и категорий.

Следующий пример создает горизонтальную гистограмму с тремя этапами и одним рядом. Он сохраняет презентацию из трех слайдов: обычный порядок, обратные категории и обратные значения. Каждая копия использует тот же набор данных, и только одна ось обратна в каждой копии.

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

    # Слайд 2: отобразить первую категорию вверху.
    category_slide = presentation.slides.add_clone(slide)
    category_chart = category_slide.shapes[0]
    category_chart.axes.vertical_axis.is_plot_order_reversed = True
    # Оставить горизонтальную ось значений внизу.
    category_chart.axes.vertical_axis.cross_type = charts.CrossesType.MAXIMUM

    # Слайд 3: инвертировать только горизонтальную числовую шкалу.
    value_slide = presentation.slides.add_clone(slide)
    value_chart = value_slide.shapes[0]
    value_chart.axes.horizontal_axis.is_plot_order_reversed = True

    presentation.save("ReversedAxes.pptx", slides.export.SaveFormat.PPTX)
```

Обратный порядок оси может также переместить перпендикулярную ось на противоположную сторону построения. [cross_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_type/) управляет тем, где другая ось пересекает настраиваемую ось. На слайде 2 установка значения `MAXIMUM` для обратной категориальной оси сохраняет горизонтальную ось значений внизу. Для конкретной точки пересечения используйте [cross_at](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_at/). Проверяйте настройки пересечения при изменении направления, особенно если в диаграмме уже задана пользовательская точка пересечения. Установите `is_plot_order_reversed` обратно в `False`, чтобы восстановить обычное направление построения; настройки пересечения независимы.

| Обычный порядок (слайд 1) | Обратные категории (слайд 2) | Обратные значения (слайд 3) |
| --- | --- | --- |
| ![Горизонтальная гистограмма с обычным порядком категорий и оси значений](axis-order-normal.png) | ![Горизонтальная гистограмма с отображением категорий сверху вниз](axis-order-categories-reversed.png) | ![Горизонтальная гистограмма с обратной осью значений и нулём справа](axis-order-values-reversed.png) |
| Категории идут снизу вверх; значения растут слева направо. | Планирование, Разработка и Тестирование идут сверху вниз. Значения и порядок строк листа остаются без изменений. | Категории сохраняют обычный порядок; значения растут справа налево. Категориальная ось пересекает ноль справа. |

## **Отключить вертикальную ось для линейных диаграмм**

Установите [is_visible](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_visible/) в `False` для вертикальной оси, чтобы скрыть её. Пример создает линейную диаграмму с данными по умолчанию и сохраняет её с скрытой вертикальной осью.

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

Установите [is_visible](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_visible/) в `False` для горизонтальной оси, чтобы скрыть её. Пример создает линейную диаграмму с данными по умолчанию и сохраняет её с скрытой горизонтальной осью.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE, 100, 100, 400, 300)
    chart.axes.horizontal_axis.is_visible = False

    presentation.save("HiddenHorizontalAxis.pptx", slides.export.SaveFormat.PPTX)
```

## **Отображение или скрытие линий сетки диаграммы**

Прочитайте [show_major_grid_lines](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/show_major_grid_lines/) и [show_minor_grid_lines](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/show_minor_grid_lines/) для проверки, какие линии сетки отображает ось. Оба свойства только для чтения. Чтобы показать мелкие линии сетки, задайте заливку линии в [minor_grid_lines_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/minor_grid_lines_format/) как сплошную и выберите видимый цвет. Чтобы скрыть их, установите тип заливки в `FillType.NO_FILL`. Для основных линий сетки используйте [major_grid_lines_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_grid_lines_format/)`.line.fill_format`. Изменение заливки сохраняет видимость оси и деления.

Вертикальная ось этой сгруппированной столбчатой диаграммы начинается с видимыми основными линиями сетки и скрытыми мелкими. Пример показывает мелкие линии сетки оранжевым цветом, затем снова скрывает их перед сохранением презентации.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 30, 30, 660, 230)
    axis = chart.axes.vertical_axis
    print(f"Initial: major={axis.show_major_grid_lines}, minor={axis.show_minor_grid_lines}")

    minor_fill = axis.minor_grid_lines_format.line.fill_format
    minor_fill.fill_type = slides.FillType.SOLID
    minor_fill.solid_fill_color.color = slides.Color.dark_orange
    print(f"Enabled: minor={axis.show_minor_grid_lines}")

    minor_fill.fill_type = slides.FillType.NO_FILL
    print(f"Hidden: major={axis.show_major_grid_lines}, minor={axis.show_minor_grid_lines}")

    presentation.save("ChartGridlines.pptx", slides.export.SaveFormat.PPTX)
```

| Включены мелкие линии сетки | Скрыты мелкие линии сетки |
| --- | --- |
| ![Оранжевые мелкие линии сетки между основными линиями на вертикальной оси](minor-gridlines-enabled.png) | ![Та же столбчатая диаграмма, где видимы только основные линии сетки](minor-gridlines-hidden.png) |

## **Изменить ось категорий**

Задайте [category_axis_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/category_axis_type/) для выбора оси категорий даты или текста. Этот пример требует `ExistingChart.pptx`, где диаграмма является первой фигурой на первом слайде, а ячейки категорий содержат числовые значения дат Excel. Он меняет горизонтальную ось на ось даты. Установив [is_automatic_major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_major_unit/) в `False`, [major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit/) в `1` и [major_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit_scale/) в `months`, основные деления будут через один‑месячный интервал.

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

### **Определить тип оси категорий по данным**

Вызовите [set_category_axis_type_automatically](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/set_category_axis_type_automatically/) после заполнения категорий, затем прочитайте [category_axis_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/category_axis_type/) для проверки выбранного типа. Это полезно, когда одна и та же диаграмма получает либо текстовые подписи, либо числовые значения дат. Метод определяет тип в момент вызова; он не включает постоянный режим, который переоценивает последующие изменения данных. Вызовите его снова после замены категорий.

В следующем примере создаётся диаграмма с текстовыми категориями и выводится `TEXT`. Затем значения ячеек категорий заменяются датами, и метод вызывается повторно, выводя `DATE`. Даты хранятся как числовые значения OLE Automation, рассчитанные как количество дней, прошедших с 30 декабря 1899 года, а не как строковые даты. [custom_number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/custom_number_format/) управляет их отображением; он не преобразует текст в числовые даты. Подробнее о ячейках категорий см. [Chart Workbook](/slides/ru/python-net/chart-workbook/).

Используйте автоматическое определение, когда входные данные известны как текстовые категории или числовые даты, как в этом примере. Для обычных числовых меток, смешанных категорий или пустых данных явно задавайте [category_axis_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/category_axis_type/) в соответствии с предполагаемым смыслом. Одни только числовые значения не устанавливают, что категории представляют даты.

```python
from datetime import date

import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 30, 40, 660, 320)

    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    series_name = workbook.get_cell(0, 0, 1, "Sales")
    series = chart.chart_data.series.add(series_name, chart.type)
    labels = ["First", "Second", "Third"]

    for i, label in enumerate(labels):
        category_cell = workbook.get_cell(0, i + 1, 0, label)
        chart.chart_data.categories.add(category_cell)

        value_cell = workbook.get_cell(0, i + 1, 1, (i + 1) * 10)
        series.data_points.add_data_point_for_bar_series(value_cell)

    axis = chart.axes.horizontal_axis
    axis.set_category_axis_type_automatically()
    print(axis.category_axis_type.name)  # ТЕКСТ

    dates = [date(2026, 1, 1), date(2026, 1, 2), date(2026, 2, 1)]

    for i, category_date in enumerate(dates):
        category_cell = workbook.get_cell(0, i + 1, 0)
        category_cell.value = float((category_date - date(1899, 12, 30)).days)
        category_cell.custom_number_format = "yyyy-mm-dd"

    axis.set_category_axis_type_automatically()
    print(axis.category_axis_type.name)  # ДАТА

    presentation.save("AutomaticCategoryAxis.pptx", slides.export.SaveFormat.PPTX)
```

## **Управление интервалами подписей оси категорий**

Когда в диаграмме много категорий, уменьшите количество видимых подписей оси, не удаляя категории и точки данных. Установите [is_automatic_tick_label_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_tick_label_spacing/) в `False`, затем задайте [tick_label_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_label_spacing/) желаемый интервал категорий. Для текстовых категорий в их обычном порядке счёт начинается с первой категории:

| Интервал | Подписи, отображаемые в примере |
| --- | --- |
| `1` | Категория 1, Категория 2, Категория 3, ... Категория 24 |
| `2` | Категория 1, Категория 3, Категория 5, ... Категория 23 |
| `3` | Категория 1, Категория 4, Категория 7, ... Категория 22 |

Интервал `3` отображает каждую третью подпись, оставляя две подписи скрытыми между отображаемыми. Это не удаляет соответствующие столбцы. Автоматический интервал выбирает значение на основе доступного пространства; он не обязательно отображает каждую подпись.

Деления имеют отдельные настройки. Установите [is_automatic_tick_marks_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_tick_marks_spacing/) в `False` и используйте [tick_marks_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_marks_spacing/) для задания их интервала. Например, `1` оставит деление на каждом интервале категории, тогда как подписи будут отображаться только каждые три категории. Задайте [major_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_tick_mark/) видимым стилем, чтобы увидеть результат. Возврат любого из автоматических параметров к `True` позволяет диаграмме снова выбрать интервал автоматически.

Следующий автономный пример создаёт 24 категории и один ряд, затем сохраняет три слайда в `CategoryAxisIntervals.pptx`: автоматический интервал, ручной интервал подписей с независимыми делениями и восстановленный автоматический интервал. Две копии сохраняют исходные данные диаграммы. Вводная презентация не требуется. Горизонтальный текст подписи упрощает восприятие плотности.

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

    # Слайд 2: показывать каждую третью метку, но оставлять деление для каждой категории.
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

**Автоматический интервал (слайд 1):** В этом отображении каждая вторая подпись категории видна и переносится на две строки. Автоматический результат может варьироваться в зависимости от размера диаграммы, шрифтов и рендерера.

![Автоматический интервал подписей категорий при видимых всех 24 столбцах](category-axis-automatic.png)

**Ручной интервал (слайд 2):** Каждая третья подпись отображается в одну строку, в то время как деления остаются на каждом интервале категории. Все 24 столбца, включая те, где подписи отсутствуют, остаются видимыми с теми же значениями. Слайд 3 восстанавливает автоматический вид, показанный выше.

![Ручной интервал подписей категорий с тремя видимыми столбцами](category-axis-manual.png)

### **Выберите правильную ось и интервал**

Используйте этот интервал количества категорий для текстовой оси категорий, такой как ось категорий столбчатой, линейной, областной или гистограммы. В столбчатой диаграмме это горизонтальная ось. В горизонтальной гистограмме ось категорий вертикальна, поэтому применяйте эти настройки к [vertical_axis](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axesmanager/vertical_axis/). Интервал делений также применяется к оси рядов в диаграммах, где она присутствует.

Не используйте интервал подписей категорий для задания числовой шкалы оси значений. На оси значений [major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit/) указывает разницу в значениях: например, основной интервал `10` создаёт деления 0, 10, 20 и т.д., когда ось начинается с нуля. Интервал подписи категории `3` считает позиции категорий независимо от их данных. Диаграммы разброса и “пузырьковые” используют оси значений, а не текстовую ось категорий. Для оси даты используйте основанные на времени основные единицы и масштабы, как описано в разделе [Изменить ось категорий](#изменить-ось-категорий).

## **Установить формат даты для значений оси категорий**

Пример заменяет данные диаграммы четырьмя годовыми значениями. Даты хранятся как серийные номера OLE Automation в первом листе (индекс `0`). Установите [category_axis_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/category_axis_type/) в ось даты, отключите [is_number_format_linked_to_source](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_number_format_linked_to_source/) и задайте `yyyy` в [number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/number_format/), чтобы подписи категорий отображали четырехзначные годы независимо от формата ячеек.

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

## **Установить позицию оси на оси категорий или значений**

Используйте [axis_between_categories](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/axis_between_categories/) для управления тем, пересекает ли ось значений ось категорий между категориями или на отметках делений. Это свойство применяется к осям категорий. Пример устанавливает его в `True` на горизонтальной оси категорий столбчатой диаграммы и сохраняет результат.

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

Задайте [display_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/display_unit/) для масштабирования подписей оси значений без изменения исходных данных. При значении [DisplayUnitType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/displayunittype/) `MILLIONS` значение 60 000 000 отображается как 60. Пример создаёт столбчатую диаграмму и применяет единицу отображения «миллионы» к её вертикальной оси.

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

Логарифмическая ось значений полезна, когда положительные значения охватывают несколько порядков величины. Например, сервис может получать 10, 100, 1 000, 10 000 и 100 000 запросов за пять периодов. При линейной шкале меньшие значения находятся близко друг к другу у нуля. Логарифмическая шкала делает их относительный рост легче сравнивать: равные расстояния представляют одинаковые соотношения, а не одинаковые различия.

Установите [is_logarithmic](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_logarithmic/) в `True` на оси значений и используйте [log_base](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/log_base/) для выбора базы. Это меняет только отображение существующих значений; данные не меняются и не добавляется логарифмическая тренд‑линия. Тренд‑линия представляет собой подгонку зависимости в данных и является отдельной функцией.

### **Выбор оси значений и базы**

Для линейной или столбчатой диаграммы ось значений — это [vertical_axis](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axesmanager/vertical_axis/). Для горизонтальной гистограммы — это [horizontal_axis](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axesmanager/horizontal_axis/). Диаграммы разброса и “пузырьковые” имеют две оси значений, поэтому выбирайте горизонтальную ось для X‑значений, вертикальную — для Y‑значений, либо обе. Не применяйте логарифмическое масштабирование к оси категорий.

База логарифма по умолчанию — `10`. Для PPTX‑диаграмм используйте базу от `2` до `1000` включительно; поддерживаются также дробные базы, такие как `2.5`. При базе `10` последовательные степени 10, 100, 1 000 и 10 000 располагаются равномерно.

### **Сравнение линейного и логарифмического масштабирования**

Следующий автономный пример создаёт линейную диаграмму с пятью подсчётами запросов на первом слайде, затем дублирует этот слайд и включает логарифмическую ось значений с основанием 10 на втором. Оба слайда сохраняют те же данные.

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

    # Сохранить первый слайд линейным и изменить только масштаб оси значений копии.
    logarithmic_slide = presentation.slides.add_clone(slide)
    logarithmic_chart = logarithmic_slide.shapes[0]
    value_axis = logarithmic_chart.axes.vertical_axis
    value_axis.is_logarithmic = True
    value_axis.log_base = 10

    presentation.save("LogarithmicAxis.pptx", slides.export.SaveFormat.PPTX)
```

**Линейный масштаб (слайд 1):** Равные вертикальные расстояния представляют равные различия в количестве запросов. Наибольшее значение доминирует в диаграмме, делая более мелкие значения трудными для различия.

![Линейная диаграмма в PowerPoint, показывающая пять подсчётов запросов на линейной оси значений](value-axis-linear.png)

**Логарифмический масштаб (слайд 2):** Равные вертикальные расстояния представляют равные соотношения. Каждый период имеет в десять раз больше запросов, чем предыдущий, поэтому точки образуют прямую восходящую линию на шкале с основанием 10. Подписи оси всё равно показывают исходные количества запросов.

![Те же пять подсчётов запросов в PowerPoint на логарифмической оси значений с основанием 10](value-axis-logarithmic.png)

### **Обработка нулевых и отрицательных значений**

Логарифмическая шкала может отображать только строго положительные значения. Проверьте данные перед её включением. Если нулевые или отрицательные значения имеют смысл, оставьте линейную шкалу или показывайте их отдельным способом. Если исключение этих значений оправдано для анализа, объясните причину исключения. Не заменяйте их тихо небольшими положительными числами, поскольку это меняет смысл данных. Любой вручную заданный минимум или максимум для логарифмической оси также должен быть положительным.

## **Часто задаваемые вопросы**

**Как задать значение, в котором одна ось пересекает другую (пересечение осей)?**

Используйте [cross_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_type/) для выбора поведения пересечения. Чтобы указать числовое значение пересечения, задайте [cross_at](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_at/). Эти настройки позволяют переместить пересечение оси к подходящей базовой линии.

**Как позиционировать подписи делений относительно оси?**

Задайте [tick_label_position](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_label_position/) с использованием [TickLabelPositionType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ticklabelpositiontype/): `LOW`, `HIGH`, `NEXT_TO` или `NONE`. Для управления самими делениями используйте [major_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_tick_mark/) или [minor_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/minor_tick_mark/); они независимы от позиционирования подписей.