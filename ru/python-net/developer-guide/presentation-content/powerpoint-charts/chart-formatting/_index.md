---
title: Форматирование диаграмм в презентациях с помощью Python
linktitle: Форматирование диаграмм
type: docs
weight: 60
url: /ru/python-net/chart-formatting/
keywords:
- форматировать диаграмму
- форматирование диаграмм
- сущность диаграммы
- свойства диаграммы
- настройки диаграммы
- параметры диаграммы
- свойства шрифта
- скруглённая граница
- PowerPoint
- OpenDocument
- презентация
- Python
- Aspose.Slides
description: "Изучите форматирование диаграмм в Aspose.Slides для Python через .NET и улучшите свою презентацию PowerPoint или OpenDocument профессиональным, привлекающим внимание оформлением."
---

## **Обзор**

Это руководство показывает, как форматировать диаграммы PowerPoint с помощью Aspose.Slides для Python. Оно шаг за шагом рассматривает настройку основных элементов диаграммы — таких как оси категорий и значений, сетка, подписи, заголовки, легенды и вторичные оси — и демонстрирует, как управлять шрифтами, числовыми форматами, заливками, контурами, цветами области построения и задней стены, а также скругленными углами диаграммы с помощью лаконичных, готовых к выполнению примеров кода. Следуя пошаговым примерам, вы создадите [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/), добавите и настроите диаграмму и сохраните результат в PPTX, применив точные визуальные и типографские настройки.

## **Форматирование элементов диаграммы**

Aspose.Slides for Python позволяет разработчикам добавлять пользовательские диаграммы на слайды с нуля. В этом разделе объясняется, как форматировать различные элементы диаграммы, включая оси категорий и значений.

Aspose.Slides предоставляет простой API для управления элементами диаграммы и применения пользовательского форматирования:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте диаграмму с данными по умолчанию нужного типа (в этом примере `ChartType.LINE_WITH_MARKERS`).
1. Доступ к оси значений диаграммы и настройте следующее:
   1. Задайте **формат линии** для основных линий сетки оси значений.
   1. Задайте **формат линии** для вспомогательных линий сетки оси значений.
   1. Задайте **числовой формат** оси значений.
   1. Задайте **минимум, максимум, основной и вспомогательный шаги** оси значений.
   1. Задайте **свойства текста** для подписей оси значений.
   1. Задайте **заголовок** оси значений.
   1. Задайте **формат линии** для оси значений.
1. Доступ к оси категорий диаграммы и настройте следующее:
   1. Задайте **формат линии** для основных линий сетки оси категорий.
   1. Задайте **формат линии** для вспомогательных линий сетки оси категорий.
   1. Задайте **свойства текста** для подписей оси категорий.
   1. Задайте **заголовок** оси категорий.
   1. Задайте **позицию подписей** оси категорий.
   1. Задайте **угол поворота** подписей оси категорий.
1. Доступ к легенде диаграммы и задайте её **свойства текста**.
1. Покажите легенду диаграммы без перекрытия диаграммы.
1. Доступ к **вторичной оси значений** диаграммы и настройте следующее:
   1. Включите вторичную **ось значений**.
   1. Задайте **формат линии** для вторичной оси значений.
   1. Задайте **числовой формат** для вторичной оси значений.
   1. Задайте **минимум, максимум, основной и вспомогательный шаги** для вторичной оси значений.
1. Постройте первую серию диаграммы на вторичной оси значений.
1. Задайте цвет заливки задней стены диаграммы.
1. Задайте цвет заливки области построения диаграммы.
1. Запишите изменённую презентацию в файл PPTX.

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# Instantiate the Presentation class.
with slides.Presentation() as presentation:

    # Access the first slide.
    slide = presentation.slides[0]

    # Add a sample chart.
    chart = slide.shapes.add_chart(charts.ChartType.LINE_WITH_MARKERS, 50, 50, 500, 400)

    # Set the chart title.
    chart.has_title = True
    chart.chart_title.add_text_frame_for_overriding("")
    chart_title = chart.chart_title.text_frame_for_overriding.paragraphs[0].portions[0]
    chart_title.text = "Sample Chart"
    chart_title.portion_format.fill_format.fill_type = slides.FillType.SOLID
    chart_title.portion_format.fill_format.solid_fill_color.color = draw.Color.gray
    chart_title.portion_format.font_height = 20
    chart_title.portion_format.font_bold = 1
    chart_title.portion_format.font_italic = 1

    # Set major gridline format for the value axis.
    chart.axes.vertical_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.vertical_axis.major_grid_lines_format.line.fill_format.solid_fill_color.color = draw.Color.blue
    chart.axes.vertical_axis.major_grid_lines_format.line.width = 5
    chart.axes.vertical_axis.major_grid_lines_format.line.dash_style = slides.LineDashStyle.DASH_DOT

    # Set minor gridline format for the value axis.
    chart.axes.vertical_axis.minor_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.vertical_axis.minor_grid_lines_format.line.fill_format.solid_fill_color.color = draw.Color.red
    chart.axes.vertical_axis.minor_grid_lines_format.line.width = 3

    # Set the value axis number format.
    chart.axes.vertical_axis.is_number_format_linked_to_source = False
    chart.axes.vertical_axis.display_unit = charts.DisplayUnitType.THOUSANDS
    chart.axes.vertical_axis.number_format = "0.0%"

    # Set value-axis maximum, minimum, major unit, and minor unit.
    chart.axes.vertical_axis.is_automatic_major_unit = False
    chart.axes.vertical_axis.is_automatic_max_value = False
    chart.axes.vertical_axis.is_automatic_minor_unit = False
    chart.axes.vertical_axis.is_automatic_min_value = False

    chart.axes.vertical_axis.max_value = 15
    chart.axes.vertical_axis.min_value = -2
    chart.axes.vertical_axis.minor_unit = 0.5
    chart.axes.vertical_axis.major_unit = 2.0

    # Set value-axis text properties.
    vertical_axis_portion_format = chart.axes.vertical_axis.text_format.portion_format
    vertical_axis_portion_format.font_bold = 1
    vertical_axis_portion_format.font_height = 16
    vertical_axis_portion_format.font_italic = 1
    vertical_axis_portion_format.fill_format.fill_type = slides.FillType.SOLID 
    vertical_axis_portion_format.fill_format.solid_fill_color.color = draw.Color.dark_green
    vertical_axis_portion_format.latin_font = slides.FontData("Times New Roman")

    # Set the value axis title.
    chart.axes.vertical_axis.has_title = True
    chart.axes.vertical_axis.title.add_text_frame_for_overriding("")
    vertical_axis_title = chart.axes.vertical_axis.title.text_frame_for_overriding.paragraphs[0].portions[0]
    vertical_axis_title.text = "Primary Axis"
    vertical_axis_title.portion_format.fill_format.fill_type = slides.FillType.SOLID
    vertical_axis_title.portion_format.fill_format.solid_fill_color.color = draw.Color.gray
    vertical_axis_title.portion_format.font_height = 20
    vertical_axis_title.portion_format.font_bold = 1
    vertical_axis_title.portion_format.font_italic = 1

    # Set major gridline format for the category axis.
    chart.axes.horizontal_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.horizontal_axis.major_grid_lines_format.line.fill_format.solid_fill_color.color = draw.Color.green
    chart.axes.horizontal_axis.major_grid_lines_format.line.width = 5

    # Set minor gridline format for the category axis.
    chart.axes.horizontal_axis.minor_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.horizontal_axis.minor_grid_lines_format.line.fill_format.solid_fill_color.color = draw.Color.yellow
    chart.axes.horizontal_axis.minor_grid_lines_format.line.width = 3

    # Set category-axis text properties.
    horizontal_axis_portion_format = chart.axes.horizontal_axis.text_format.portion_format
    horizontal_axis_portion_format.font_bold = 1
    horizontal_axis_portion_format.font_height = 16
    horizontal_axis_portion_format.font_italic = 1
    horizontal_axis_portion_format.fill_format.fill_type = slides.FillType.SOLID 
    horizontal_axis_portion_format.fill_format.solid_fill_color.color = draw.Color.blue
    horizontal_axis_portion_format.latin_font = slides.FontData("Arial")

    # Set the category axis title.
    chart.axes.horizontal_axis.has_title = True
    chart.axes.horizontal_axis.title.add_text_frame_for_overriding("")

    horizontal_axis_title = chart.axes.horizontal_axis.title.text_frame_for_overriding.paragraphs[0].portions[0]
    horizontal_axis_title.text = "Sample Category"
    horizontal_axis_title.portion_format.fill_format.fill_type = slides.FillType.SOLID
    horizontal_axis_title.portion_format.fill_format.solid_fill_color.color = draw.Color.gray
    horizontal_axis_title.portion_format.font_height = 20
    horizontal_axis_title.portion_format.font_bold = 1
    horizontal_axis_title.portion_format.font_italic = 1

    # Set the category-axis label position.
    chart.axes.horizontal_axis.tick_label_position = charts.TickLabelPositionType.LOW

    # Set the category-axis label rotation angle.
    chart.axes.horizontal_axis.tick_label_rotation_angle = 45

    # Set legend text properties.
    legend_portion_format = chart.legend.text_format.portion_format
    legend_portion_format.font_bold = 1
    legend_portion_format.font_height = 16
    legend_portion_format.font_italic = 1
    legend_portion_format.fill_format.fill_type = slides.FillType.SOLID 
    legend_portion_format.fill_format.solid_fill_color.color = draw.Color.dark_red

    # Show the chart legend overlapping the chart.
    chart.legend.overlay = True
                
    # Set chart back wall color.
    chart.back_wall.thickness = 1
    chart.back_wall.format.fill.fill_type = slides.FillType.SOLID
    chart.back_wall.format.fill.solid_fill_color.color = draw.Color.orange

    chart.floor.format.fill.fill_type = slides.FillType.SOLID
    chart.floor.format.fill.solid_fill_color.color = draw.Color.red

    # Set the plot area color.
    chart.plot_area.format.fill.fill_type = slides.FillType.SOLID
    chart.plot_area.format.fill.solid_fill_color.color = draw.Color.light_cyan

    # Save the presentation.
    presentation.save("FormattedChart.pptx", slides.export.SaveFormat.PPTX)
```

## **Установка свойств шрифта диаграммы**

Aspose.Slides for Python поддерживает задание свойств шрифта для диаграмм. Выполните следующие шаги, чтобы настроить шрифтовые свойства диаграммы:

1. Создайте объект [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Добавьте диаграмму на слайд.
1. Установите высоту шрифта.
1. Сохраните изменённую презентацию.

Пример кода:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 500, 400)
    chart.text_format.portion_format.font_height = 20
    chart.chart_data.series[0].labels.default_data_label_format.show_value = True

    presentation.save("ChartFontProperties.pptx", slides.export.SaveFormat.PPTX)
```

## **Установка числового формата**

Aspose.Slides for Python предоставляет простой API для управления форматами данных диаграммы:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте диаграмму с данными по умолчанию любого требуемого типа.
1. Задайте предустановленный числовой формат из доступных значений.
1. Пройдите по ячейкам данных диаграммы в каждой серии и задайте числовой формат.
1. Сохраните презентацию.
1. Задайте пользовательский числовой формат.
1. Пройдите по ячейкам данных диаграммы в каждой серии и задайте иной числовой формат.
1. Сохраните презентацию.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Instantiate the Presentation class.
with slides.Presentation() as presentation:
    # Access the first slide.
    slide = presentation.slides[0]

    # Add a default clustered column chart.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 400)

    # Set the preset number format.
    # Traverse each chart series.
    for series in chart.chart_data.series:
        # Traverse each data point in the series.
        for cell in series.data_points:
            # Set the number format.
            cell.value.as_cell.preset_number_format = 10  # 0.00%

    # Save the presentation.
    presentation.save("PresetNumberFormat.pptx", slides.export.SaveFormat.PPTX)
```

Доступные предустановленные числовые форматы и их индексы приведены ниже.

|**0**|Общий|
| :- | :- |
|**1**|0|
|**2**|0,00|
|**3**|#,##0|
|**4**|#,##0,00|
|**5**|$#,##0;$-#,##0|
|**6**|$#,##0;Red$-#,##0|
|**7**|$#,##0,00;$-#,##0,00|
|**8**|$#,##0,00;Red$-#,##0,00|
|**9**|0%|
|**10**|0,00%|
|**11**|0,00E+00|
|**12**|# ?/?|
|**13**|# /|
|**14**|m/d/yy|
|**15**|d-mmm-yy|
|**16**|d-mmm|
|**17**|mmm-yy|
|**18**|h:mm AM/PM|
|**19**|h:mm:ss AM/PM|
|**20**|h:mm|
|**21**|h:mm:ss|
|**22**|m/d/yy h:mm|
|**37**|#,##0;-#,##0|
|**38**|#,##0;Red-#,##0|
|**39**|#,##0,00;-#,##0,00|
|**40**|#,##0,00;Red-#,##0,00|
|**41**|_ * #,##0_ ;_ * "_ ;_ @_|
|**42**|_ $* #,##0_ ;_ $* "_ ;_ @_|
|**43**|_ * #,##0,00_ ;_ * "??_ ;_ @_|
|**44**|_ $* #,##0,00_ ;_ $* "??_ ;_ @_|
|**45**|mm:ss|
|**46**|h :mm:ss|
|**47**|[mm:ss.0](http://mmss.0)|
|**48**|##0.0E+00|
|**49**|@|

## **Установка скруглённых границ для области диаграммы**

Aspose.Slides for Python поддерживает конфигурацию области диаграммы через свойство `Chart.has_rounded_corners`.

1. Создайте объект [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Добавьте диаграмму на слайд.
3. Задайте тип заливки и цвет заливки диаграммы.
4. Установите свойство скруглённых углов в `True`.
5. Сохраните изменённую презентацию.

Пример:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
	slide = presentation.slides[0]

	chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 100, 600, 400)
	chart.line_format.fill_format.fill_type = slides.FillType.SOLID
	chart.line_format.style = slides.LineStyle.SINGLE
	chart.has_rounded_corners = True

	presentation.save("RoundedBorders.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Можно ли задать полупрозрачные заливки для столбцов/областей, оставив границу непрозрачной?**

Да. Прозрачность заливки и контур задаются отдельно. Это полезно для повышения читаемости сетки и данных в плотных визуализациях.

**Как справиться с наложением подписей данных?**

Уменьшите размер шрифта, отключите необязательные компоненты подписи (например, категории), задайте смещение/позицию подписи, показывайте подписи только для выбранных точек при необходимости или переключите формат на «значение + легенда».

**Можно ли применить градиентные или шаблонные заливки к сериям?**

Да. Как сплошные, так и градиентные/шаблонные заливки обычно доступны. На практике используйте градиенты умеренно и избегайте комбинаций, снижающих контрастность относительно сетки и текста.