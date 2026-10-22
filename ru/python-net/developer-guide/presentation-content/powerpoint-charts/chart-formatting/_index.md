---
title: Форматирование диаграмм в презентациях с использованием Python
linktitle: Форматирование диаграмм
type: docs
weight: 60
url: /ru/python-net/chart-formatting/
keywords:
- формат диаграммы
- форматирование диаграмм
- элемент диаграммы
- свойства диаграммы
- настройки диаграммы
- опции диаграммы
- свойства шрифта
- скруглённая граница
- PowerPoint
- презентация
- Python
- Aspose.Slides
description: "Изучите форматирование диаграмм в Aspose.Slides для Python через .NET и улучшите вашу презентацию PowerPoint с помощью пользовательских осей, шрифтов, числовых форматов и скруглённых границ диаграмм."
---
## **Обзор**

Эта статья объясняет, как форматировать диаграммы в презентациях PowerPoint с помощью Aspose.Slides. Она показывает, как настраивать ключевые элементы диаграммы, такие как оси, линии сетки, заголовки, легенды, область построения и заполнения стен, чтобы улучшить внешний вид и читаемость данных диаграммы.

Также демонстрируется, как установить свойства шрифта для текста диаграммы, применить предустановленные числовые форматы к данным диаграммы и включить скруглённые углы для области диаграммы. Вместе эти примеры показывают, как контролировать как визуальный стиль, так и представление данных диаграмм в презентации.

## **Форматирование элементов диаграммы**

Используйте [Chart](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/) для форматирования заголовков диаграмм, осей, линий сетки, легенд и области построения. Этот пример создаёт линейную диаграмму с маркерами и данными по умолчанию, затем применяет отдельные стили текста и линий к её значениям и категориальным осям. Размеры шрифтов и толщины линий указаны в пунктах; подписи категорий повернуты на 45 градусов.

Ось значений использует [number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/number_format/) независимо от исходных ячеек. Её масштаб идёт от -2 до 15 с основными интервалами 2 и вспомогательными интервалами 0,5. Пример также сочетает процентное форматирование с [display_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/display_unit/), установленным в тысячи, поэтому адаптируйте эти настройки к смыслу и масштабу ваших данных. Легенда остаётся вне области построения, потому что [overlay](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/overlay/) отключён. Заполнение задней стены и пола настраивается через [back_wall](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/back_wall/) и [floor](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/floor/), но эти поверхности видимы только в 3D‑диаграммах.

```python
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:

    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE_WITH_MARKERS, 50, 50, 500, 400)

    chart.has_title = True
    chart.chart_title.add_text_frame_for_overriding("")
    chart_title = chart.chart_title.text_frame_for_overriding.paragraphs[0].portions[0]
    chart_title.text = "Sample Chart"
    chart_title.portion_format.fill_format.fill_type = slides.FillType.SOLID
    chart_title.portion_format.fill_format.solid_fill_color.color = slides.Color.gray
    chart_title.portion_format.font_height = 20
    chart_title.portion_format.font_bold = slides.NullableBool.TRUE
    chart_title.portion_format.font_italic = slides.NullableBool.TRUE

    chart.axes.vertical_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.vertical_axis.major_grid_lines_format.line.fill_format.solid_fill_color.color = slides.Color.blue
    chart.axes.vertical_axis.major_grid_lines_format.line.width = 5
    chart.axes.vertical_axis.major_grid_lines_format.line.dash_style = slides.LineDashStyle.DASH_DOT

    chart.axes.vertical_axis.minor_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.vertical_axis.minor_grid_lines_format.line.fill_format.solid_fill_color.color = slides.Color.red
    chart.axes.vertical_axis.minor_grid_lines_format.line.width = 3

    chart.axes.vertical_axis.is_number_format_linked_to_source = False
    chart.axes.vertical_axis.display_unit = charts.DisplayUnitType.THOUSANDS
    chart.axes.vertical_axis.number_format = "0.0%"

    chart.axes.vertical_axis.is_automatic_major_unit = False
    chart.axes.vertical_axis.is_automatic_max_value = False
    chart.axes.vertical_axis.is_automatic_minor_unit = False
    chart.axes.vertical_axis.is_automatic_min_value = False

    chart.axes.vertical_axis.max_value = 15
    chart.axes.vertical_axis.min_value = -2
    chart.axes.vertical_axis.minor_unit = 0.5
    chart.axes.vertical_axis.major_unit = 2.0

    vertical_axis_portion_format = chart.axes.vertical_axis.text_format.portion_format
    vertical_axis_portion_format.font_bold = slides.NullableBool.TRUE
    vertical_axis_portion_format.font_height = 16
    vertical_axis_portion_format.font_italic = slides.NullableBool.TRUE
    vertical_axis_portion_format.fill_format.fill_type = slides.FillType.SOLID
    vertical_axis_portion_format.fill_format.solid_fill_color.color = slides.Color.dark_green
    vertical_axis_portion_format.latin_font = slides.FontData("Times New Roman")

    chart.axes.vertical_axis.has_title = True
    chart.axes.vertical_axis.title.add_text_frame_for_overriding("")
    vertical_axis_title = chart.axes.vertical_axis.title.text_frame_for_overriding.paragraphs[0].portions[0]
    vertical_axis_title.text = "Primary Axis"
    vertical_axis_title.portion_format.fill_format.fill_type = slides.FillType.SOLID
    vertical_axis_title.portion_format.fill_format.solid_fill_color.color = slides.Color.gray
    vertical_axis_title.portion_format.font_height = 20
    vertical_axis_title.portion_format.font_bold = slides.NullableBool.TRUE
    vertical_axis_title.portion_format.font_italic = slides.NullableBool.TRUE

    chart.axes.horizontal_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.horizontal_axis.major_grid_lines_format.line.fill_format.solid_fill_color.color = slides.Color.green
    chart.axes.horizontal_axis.major_grid_lines_format.line.width = 5

    chart.axes.horizontal_axis.minor_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.horizontal_axis.minor_grid_lines_format.line.fill_format.solid_fill_color.color = slides.Color.yellow
    chart.axes.horizontal_axis.minor_grid_lines_format.line.width = 3

    horizontal_axis_portion_format = chart.axes.horizontal_axis.text_format.portion_format
    horizontal_axis_portion_format.font_bold = slides.NullableBool.TRUE
    horizontal_axis_portion_format.font_height = 16
    horizontal_axis_portion_format.font_italic = slides.NullableBool.TRUE
    horizontal_axis_portion_format.fill_format.fill_type = slides.FillType.SOLID
    horizontal_axis_portion_format.fill_format.solid_fill_color.color = slides.Color.blue
    horizontal_axis_portion_format.latin_font = slides.FontData("Arial")

    chart.axes.horizontal_axis.has_title = True
    chart.axes.horizontal_axis.title.add_text_frame_for_overriding("")

    horizontal_axis_title = chart.axes.horizontal_axis.title.text_frame_for_overriding.paragraphs[0].portions[0]
    horizontal_axis_title.text = "Sample Category"
    horizontal_axis_title.portion_format.fill_format.fill_type = slides.FillType.SOLID
    horizontal_axis_title.portion_format.fill_format.solid_fill_color.color = slides.Color.gray
    horizontal_axis_title.portion_format.font_height = 20
    horizontal_axis_title.portion_format.font_bold = slides.NullableBool.TRUE
    horizontal_axis_title.portion_format.font_italic = slides.NullableBool.TRUE

    chart.axes.horizontal_axis.tick_label_position = charts.TickLabelPositionType.LOW

    chart.axes.horizontal_axis.tick_label_rotation_angle = 45

    legend_portion_format = chart.legend.text_format.portion_format
    legend_portion_format.font_bold = slides.NullableBool.TRUE
    legend_portion_format.font_height = 16
    legend_portion_format.font_italic = slides.NullableBool.TRUE
    legend_portion_format.fill_format.fill_type = slides.FillType.SOLID
    legend_portion_format.fill_format.solid_fill_color.color = slides.Color.dark_red

    chart.legend.overlay = False

    chart.back_wall.thickness = 1
    chart.back_wall.format.fill.fill_type = slides.FillType.SOLID
    chart.back_wall.format.fill.solid_fill_color.color = slides.Color.orange

    chart.floor.format.fill.fill_type = slides.FillType.SOLID
    chart.floor.format.fill.solid_fill_color.color = slides.Color.red

    chart.plot_area.format.fill.fill_type = slides.FillType.SOLID
    chart.plot_area.format.fill.solid_fill_color.color = slides.Color.light_cyan

    presentation.save("FormattedChart.pptx", slides.export.SaveFormat.PPTX)
```

## **Установить свойства шрифта для диаграммы**

Установите размер шрифта по умолчанию для текста диаграммы через [Chart.text_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/text_format/). Пример создаёт сгруппированную столбчатую диаграмму с 20‑пунктовым шрифтом и включает отображение значений для первой серии через [show_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/show_value/). Текстовые элементы со своими явными настройками шрифта могут переопределять значение по умолчанию диаграммы.

```python
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 500, 400)
    chart.text_format.portion_format.font_height = 20
    chart.chart_data.series[0].labels.default_data_label_format.show_value = True

    presentation.save("ChartFontProperties.pptx", slides.export.SaveFormat.PPTX)
```

## **Установить числовой формат**

Используйте [ChartDataCell.preset_number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/preset_number_format/) для применения встроенного числового формата к ячейкам рабочей книги диаграммы. Этот пример создаёт сгруппированную столбчатую диаграмму с данными по умолчанию, хранящимися в ячейках, и применяет индекс формата 10 (`0.00%`) к каждой ячейке значений серии. Это меняет способ отображения значений в рабочей книге без изменения самих чисел; например, 0.25 выводится как 25.00%. Форматы осей и подписей данных можно настраивать независимо.

```python
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 400)

    for series in chart.chart_data.series:
        for data_point in series.data_points:
            data_point.value.as_cell.preset_number_format = 10  # 0.00%

    presentation.save("PresetNumberFormat.pptx", slides.export.SaveFormat.PPTX)
```

Следующая таблица перечисляет встроенные индексы числовых форматов с характерными форматами Excel для локали English (United States). Точные строки формата и их отображение могут различаться в зависимости от приложения и локали, особенно для валют и дат. Некоторые форматы Excel также отличаются от значений по умолчанию в стандарте OOXML, как описано в [Microsoft's number format implementation notes](https://learn.microsoft.com/en-us/openspecs/office_standards/ms-oi29500/17d11129-219b-4e2c-88db-45844d21e528).

| Индекс | Формат |
| --- | --- |
| 0 | `General` |
| 1 | `0` |
| 2 | `0.00` |
| 3 | `#,##0` |
| 4 | `#,##0.00` |
| 5 | `"$"#,##0_);("$"#,##0)` |
| 6 | `"$"#,##0_);[Red]("$"#,##0)` |
| 7 | `"$"#,##0.00_);("$"#,##0.00)` |
| 8 | `"$"#,##0.00_);[Red]("$"#,##0.00)` |
| 9 | `0%` |
| 10 | `0.00%` |
| 11 | `0.00E+00` |
| 12 | `# ?/?` |
| 13 | `# ??/??` |
| 14 | `m/d/yyyy` |
| 15 | `d-mmm-yy` |
| 16 | `d-mmm` |
| 17 | `mmm-yy` |
| 18 | `h:mm AM/PM` |
| 19 | `h:mm:ss AM/PM` |
| 20 | `h:mm` |
| 21 | `h:mm:ss` |
| 22 | `m/d/yyyy h:mm` |
| 37 | `#,##0_);(#,##0)` |
| 38 | `#,##0_);[Red](#,##0)` |
| 39 | `#,##0.00_);(#,##0.00)` |
| 40 | `#,##0.00_);[Red](#,##0.00)` |
| 41 | `_(* #,##0_);_(* (#,##0);_(* "-"_);_(@_)` |
| 42 | `_("$"* #,##0_);_("$"* (#,##0);_("$"* "-"_);_(@_)` |
| 43 | `_(* #,##0.00_);_(* (#,##0.00);_(* "-"??_);_(@_)` |
| 44 | `_("$"* #,##0.00_);_("$"* (#,##0.00);_("$"* "-"??_);_(@_)` |
| 45 | `mm:ss` |
| 46 | `[h]:mm:ss` |
| 47 | `mm:ss.0` |
| 48 | `##0.0E+0` |
| 49 | `@` |

## **Установить скруглённые границы области диаграммы**

Включите [Chart.has_rounded_corners](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/has_rounded_corners/) для скругления углов области диаграммы. Пример создаёт сгруппированную столбчатую диаграмму и использует [line_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/line_format/) для задания контуру сплошного серого цвета и одиночного стиля линии перед сохранением презентации.

```python
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 100, 600, 400)
    chart.line_format.fill_format.fill_type = slides.FillType.SOLID
    chart.line_format.fill_format.solid_fill_color.color = slides.Color.gray
    chart.line_format.style = slides.LineStyle.SINGLE
    chart.has_rounded_corners = True

    presentation.save("RoundedBorders.pptx", slides.export.SaveFormat.PPTX)
```

## **Редактировать существующие аннотации диаграммы**

Диаграмма может содержать пользовательские фигуры, например текстовую аннотацию, объясняющую статус отчёта. Доступ к этим фигурам осуществляется через [Chart.user_shapes](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/user_shapes/). Его коллекция [shapes](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/shapes/) содержит фигуры, принадлежащие диаграмме.

Обычный текстовый блок, помещённый поверх диаграммы, принадлежит слайду, даже если выглядит как часть диаграммы. Перебор через [Slide.shapes](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/shapes/) находит диаграмму и обычные фигуры слайда, но не перечисляет отдельные фигуры внутри диаграммы. Заголовки диаграмм и подписи данных являются отдельными элементами диаграммы, а не пользовательскими аннотациями в этой коллекции.

Скачайте [chart-annotations.pptx](chart-annotations.pptx) и разместите его в рабочем каталоге приложения. На первом слайде находится диаграмма с разъединённой аннотацией «Preliminary results», линией, принадлежащей диаграмме, и обычным текстовым блоком слайда «Slide overlay». Пример находит первую диаграмму на этом слайде и меняет аннотацию на «Final results», когда отчёт готов к публикации. Он проверяет, не пуста ли коллекция, и редактирует только [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) с [text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/text_frame/), который не равен `None` и содержит ожидаемый текст.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart-annotations.pptx") as presentation:
    slide = presentation.slides[0]
    chart = next((shape for shape in slide.shapes if isinstance(shape, charts.Chart)), None)

    if chart is None or len(chart.user_shapes.shapes) == 0:
        print("No chart or chart-owned shapes found.")
    else:
        updated = False
        for shape in chart.user_shapes.shapes:
            if isinstance(shape, slides.AutoShape) and shape.text_frame is not None:
                if shape.text_frame.text == "Preliminary results":
                    shape.text_frame.text = "Final results"
                    updated = True
                    break

        if updated:
            presentation.save("chart-annotations-updated.pptx", slides.export.SaveFormat.PPTX)
        else:
            print("No matching text annotation found.")
```

Линия и текстовый блок слайда остаются без изменений. Ниже показаны исходное изображение и сохранённый, открытый повторно результат:

| До редактирования | После редактирования |
| --- | --- |
| ![Chart annotation reading Preliminary results](chart-annotations-before.png) | ![Chart annotation reading Final results](chart-annotations-after.png) |

{{% alert color="info" title="Note" %}}
Пример проверяет только фигуры верхнего уровня, принадлежащие диаграмме. Если аннотация находится внутри [GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/), проверьте также коллекцию [shapes](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/shapes/) этой группы. Делайте это рекурсивно для вложенных групп, применяя те же проверочные условия к их дочерним фигурам. Сама группа является контейнером; не рассматривайте её как текстовый блок.
{{% /alert %}}

## **FAQ**

**Могу ли я установить полупрозрачные заливки для столбцов/областей, оставив границу непрозрачной?**

Да. Прозрачность заливки и контур настраиваются отдельно. Это полезно для повышения читаемости сетки и данных в плотных визуализациях.

**Как справиться с подписью данных, когда они перекрываются?**

Уменьшите размер шрифта, отключите необязательные компоненты подписи (например, категории), скорректируйте позицию подписи, при необходимости показывайте подписи только для выбранных точек или переключите формат на «значение + легенда».

**Могу ли я применять градиентные или узорчатые заливки к сериям?**

Да. Серии поддерживают сплошные, градиентные и узорчатые заливки. На практике используйте градиенты умеренно и избегайте комбинаций, снижающих контрастность относительно сетки и текста.