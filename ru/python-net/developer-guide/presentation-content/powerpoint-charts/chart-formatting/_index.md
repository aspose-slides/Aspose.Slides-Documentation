---
title: Форматирование диаграмм в презентациях с использованием Python
linktitle: Форматирование диаграмм
type: docs
weight: 60
url: /ru/python-net/chart-formatting/
keywords:
- форматировать диаграмму
- форматирование диаграмм
- объект диаграммы
- свойства диаграммы
- настройки диаграммы
- параметры диаграммы
- свойства шрифта
- скруглённая граница
- PowerPoint
- презентация
- Python
- Aspose.Slides
description: "Изучите форматирование диаграмм в Aspose.Slides для Python через .NET и улучшите свою презентацию PowerPoint с помощью пользовательских осей, шрифтов, числовых форматов и скруглённых границ диаграмм."
---
## **Обзор**

В этой статье объясняется, как форматировать диаграммы в презентациях PowerPoint с помощью Aspose.Slides. Показано, как настраивать основные элементы диаграммы, такие как оси, сетка, заголовки, легенды, область построения и заливку стен, чтобы улучшить внешний вид и читаемость данных диаграммы. Также демонстрируется, как установить свойства шрифта для текста диаграммы, применить предустановленные числовые форматы к данным диаграммы и включить закруглённые уголки области диаграммы. Вместе эти примеры показывают, как управлять как визуальным стилем, так и представлением данных диаграмм в презентации.

Для отдельной заливки и контуров на растущих и падающих интервалах см. [пример диаграммы акций](/slides/ru/python-net/create-chart/#create-stock-charts).

## **Форматирование элементов диаграммы**

Используйте [Chart](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/) для форматирования заголовков диаграммы, осей, линий сетки, легенд и области построения. Этот пример создаёт линейную диаграмму с маркерами и данными по умолчанию, затем применяет отдельные стили текста и линий к её оси значений и оси категорий. Размеры шрифта и ширина линий задаются в пунктах; подписи категорий повернуты на 45 градусов.

Ось значений использует [number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/number_format/) независимо от исходных ячеек. её шкала идёт от -2 до 15, с основными интервалами 2 и второстепенными интервалами 0,5. В примере также комбинируется форматирование процентов с [display_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/display_unit/) установленным в тысячи, поэтому адаптируйте эти настройки к смыслу и масштабу ваших данных. Легенда остаётся вне области построения, потому что [overlay](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/overlay/) отключён. Заполнение задней стены и пола настраивается через [back_wall](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/back_wall/) и [floor](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/floor/), но эти поверхности видны только в 3D‑диаграммах.

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

Установите размер шрифта по умолчанию для текста диаграммы через [Chart.text_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/text_format/). Пример создаёт сгруппированную столбчатую диаграмму с шрифтом 20 пунктов и включает метки значений для первой серии через [show_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/show_value/). Текстовые элементы со своими явными настройками шрифта могут переопределять значение по умолчанию диаграммы.

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

## **Повторное использование форматирования текстового фрейма для легенды диаграммы**

Чтобы согласовать легенду с заголовком слайда, задайте шрифт через [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_portion_format/) у первого абзаца заголовка. Вызовите [copy_from](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttextformat/copy_from/) у [text_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/text_format/) легенды. Это копирует настройки текстового фрейма, форматирование первого абзаца и свойства шрифта по умолчанию этого абзаца. Форматирование, применённое непосредственно к отдельным частям или к последующим абзацам, остаётся локальным для источника.

В примере в качестве шаблона используется заголовок с жирным шрифтом, темно‑синим цветом, 26‑пунктовым Calibri. После стилизации легенды используется [copy_to](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttextformat/copy_to/) , чтобы применить то же форматирование к отдельной подписи.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    shapes = presentation.slides[0].shapes

    heading = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 20, 640, 40, False)
    source_text_frame = heading.add_text_frame("Quarterly sales")
    font = source_text_frame.paragraphs[0].paragraph_format.default_portion_format
    font.latin_font = slides.FontData("Calibri")
    font.font_height = 26
    font.font_bold = slides.NullableBool.TRUE
    font.fill_format.fill_type = slides.FillType.SOLID
    font.fill_format.solid_fill_color.color = slides.Color.from_argb(32, 64, 96)

    chart = shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 40, 75, 640, 360)
    chart.style = charts.StyleType.STYLE3
    workbook = chart.chart_data.chart_data_workbook
    for column, name in enumerate(("Retail", "Online", "Wholesale"), start=1):
        workbook.get_cell(0, 0, column).value = name
    for quarter in range(1, 5):
        workbook.get_cell(0, quarter, 0).value = f"Q{quarter}"

    chart.has_legend = True
    chart.legend.position = charts.LegendPositionType.BOTTOM
    chart.legend.text_format.copy_from(source_text_frame)

    caption = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 460, 640, 40, False)
    caption_text_frame = caption.add_text_frame("Sales in millions of dollars")
    chart.legend.text_format.copy_to(caption_text_frame)

    presentation.save("legend-formatting.pptx", slides.export.SaveFormat.PPTX)
```

В сохранённой презентации легенда и подпись соответствуют заголовку по размеру, толщине и цвету. Легенда по‑прежнему отображает имена серий, а подпись сохраняет собственный текст. Если часть подписи уже имеет явный размер шрифта, этот размер имеет приоритет над скопированным значением по умолчанию абзаца.

| До копирования | После копирования |
| --- | --- |
| ![Квартальная диаграмма продаж с обычными чёрными метками легенды и чёрной подписью](legend-formatting-before.png) | ![Та же диаграмма с более крупными, жирными тёмно‑синими метками легенды и соответствующей подписью](legend-formatting.png) |

## **Установить числовой формат**

Используйте [ChartDataCell.preset_number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/preset_number_format/) для применения встроенного числового формата к ячейкам рабочей книги диаграммы. Этот пример создаёт сгруппированную столбчатую диаграмму с данными по умолчанию, поддерживаемыми ячейками, и применяет индекс формата 10 (`0.00%`) к каждой ячейке значения серии. Это меняет отображение значений в рабочей книге без изменения самих чисел; например, 0,25 отображается как 25,00 %. Форматы осей и меток данных можно настраивать отдельно.

```python
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 400)

    for series in chart.chart_data.series:
        for data_point in series.data_points:
            data_point.value.as_cell.preset_number_format = 10  # 0,00%

    presentation.save("PresetNumberFormat.pptx", slides.export.SaveFormat.PPTX)
```

В следующей таблице перечислены встроенные индексы числовых форматов с типичными форматами Excel для локали English (United States). Точные строки формата и их отображение могут различаться в зависимости от приложения и локали, особенно для валют и дат. Некоторые форматы Excel также отличаются от значений по умолчанию в стандарте OOXML, как описано в [Microsoft's number format implementation notes](https://learn.microsoft.com/en-us/openspecs/office_standards/ms-oi29500/17d11129-219b-4e2c-88db-45844d21e528).

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

Включите [Chart.has_rounded_corners](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/has_rounded_corners/) чтобы округлить уголки области диаграммы. Пример создаёт сгруппированную столбчатую диаграмму и использует [line_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/line_format/) для придания её контуру сплошного серого цвета и одно‑линейного стиля перед сохранением презентации.

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

Диаграмма может содержать пользовательские формы, например текстовую аннотацию, объясняющую статус отчёта. Доступ к этим формам осуществляется через [Chart.user_shapes](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/user_shapes/). Его коллекция [shapes](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/shapes/) содержит формы, принадлежащие диаграмме.

Обычный текстовый блок, размещённый над диаграммой, относится к слайду, даже если выглядит как часть диаграммы. Перебор через [Slide.shapes](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/shapes/) находит диаграмму и обычные формы слайда, но не перечисляет отдельные формы внутри диаграммы. Заголовки диаграмм и метки данных являются отдельными элементами диаграммы, а не пользовательскими аннотациями в этой коллекции.

Скачайте [chart-annotations.pptx](chart-annotations.pptx) и разместите его в рабочем каталоге приложения. Его первый слайд содержит диаграмму с не сгруппированной аннотацией «Preliminary results», принадлежащей диаграмме линией и обычным текстовым блоком слайда «Slide overlay». Пример находит первую диаграмму на этом слайде и меняет аннотацию на «Final results», когда отчет готов к публикации. Он проверяет коллекцию на пустоту и редактирует только [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) с [text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/text_frame/) , который не равен `None` и содержит ожидаемый текст.

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

Линия и текстовый блок слайда остаются без изменений. Ниже показаны изображения входных данных и сохранённого, повторно открытого результата:

| До редактирования | После редактирования |
| --- | --- |
| ![Аннотация диаграммы с текстом «Preliminary results»](chart-annotations-before.png) | ![Аннотация диаграммы с текстом «Final results»](chart-annotations-after.png) |

{{% alert color="info" title="Note" %}}
Пример проверяет только формы верхнего уровня, принадлежащие диаграмме. Если аннотация находится внутри [GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/), проверьте также коллекцию [shapes](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/shapes/) этой группы. Повторяйте это рекурсивно для вложенных групп, применяя те же проверки текста к их дочерним формам. Группа сама по себе является контейнером; не рассматривайте её как текстовый блок.
{{% /alert %}}

## **FAQ**

**Могу ли я задать полупрозрачные заливки для столбцов/областей, оставив границу непрозрачной?**

Да. Прозрачность заливки и обводка настраиваются отдельно. Это полезно для улучшения читаемости сетки и данных в плотных визуализациях.

**Как справиться с метками данных, когда они перекрываются?**

Уменьшите размер шрифта, отключите несущественные компоненты меток (например, категории), отрегулируйте позицию метки, при необходимости показывайте метки только для выбранных точек или переключите формат на "value + legend".

**Могу ли я применить градиентную или шаблонную заливку к сериям?**

Да. Серии поддерживают сплошные, градиентные и шаблонные заливки. На практике используйте градиенты умеренно и избегайте комбинаций, снижающих контраст с сеткой и текстом.