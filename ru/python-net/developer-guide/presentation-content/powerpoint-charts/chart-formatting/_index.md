---
title: Форматирование диаграмм в презентациях с использованием Python
linktitle: Форматирование диаграмм
type: docs
weight: 60
url: /ru/python-net/chart-formatting/
keywords:
- форматировать диаграмму
- форматирование диаграммы
- объект диаграммы
- свойства диаграммы
- настройки диаграммы
- параметры диаграммы
- свойства шрифта
- скругленная граница
- PowerPoint
- OpenDocument
- презентация
- Python
- Aspose.Slides
description: "Изучите форматирование диаграмм в Aspose.Slides для Python через .NET и придайте своей презентации PowerPoint или OpenDocument профессиональный, привлекающий внимание стиль."
---

## **Обзор**

Это руководство показывает, как форматировать диаграммы PowerPoint с помощью Aspose.Slides для Python. Оно проходит настройку основных объектов диаграмм — таких как оси категорий и значений, линии сетки, подписи, заголовки, легенды и вторичные оси — и демонстрирует управление шрифтами, числовыми форматами, заливками, контурами, цветами области построения и задней стенки, а также скруглёнными углами диаграммы с помощью лаконичных, готовых к запуску примеров кода. Следуя пошаговым примерам, вы создадите [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/), добавите и настроите диаграмму и сохраните результат в PPTX, применив точные визуальные и типографические параметры.

## **Форматирование элементов диаграммы**

Aspose.Slides for Python позволяет разработчикам добавлять собственные диаграммы на слайды с нуля. В этом разделе объясняется, как форматировать различные элементы диаграммы, включая оси категорий и значений.

Aspose.Slides предоставляет простой API для управления элементами диаграммы и применения пользовательского форматирования:

1. Создать экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Получить ссылку на слайд по его индексу.
1. Добавить диаграмму с данными по умолчанию нужного типа (в этом примере `ChartType.LINE_WITH_MARKERS`).
1. Получить доступ к оси значений диаграммы и задать следующее:
   1. Задать **формат линии** для основных линий сетки оси значений.
   1. Задать **формат линии** для вспомогательных линий сетки оси значений.
   1. Задать **числовой формат** для оси значений.
   1. Задать **минимум, максимум, основные и вспомогательные единицы** для оси значений.
   1. Задать **свойства текста** для подписей оси значений.
   1. Задать **заголовок** для оси значений.
   1. Задать **формат линии** для оси значений.
1. Получить доступ к оси категорий диаграммы и задать следующее:
   1. Задать **формат линии** для основных линий сетки оси категорий.
   1. Задать **формат линии** для вспомогательных линий сетки оси категорий.
   1. Задать **свойства текста** для подписей оси категорий.
   1. Задать **заголовок** для оси категорий.
   1. Задать **позицию подписи** для оси категорий.
   1. Задать **угол поворота** для подписей оси категорий.
1. Получить доступ к легенде диаграммы и задать её **свойства текста**.
1. Показать легенду диаграммы без перекрытия диаграммы.
1. Получить доступ к **вторичной оси значений** диаграммы и задать следующее:
   1. Включить вторичную **ось значений**.
   1. Задать **формат линии** для вторичной оси значений.
   1. Задать **числовой формат** для вторичной оси значений.
   1. Задать **минимум, максимум, основные и вспомогательные единицы** для вторичной оси значений.
1. Отобразить первую серию диаграммы на вторичной оси значений.
1. Задать цвет заливки задней стенки диаграммы.
1. Задать цвет заливки области построения диаграммы.
1. Сохранить изменённую презентацию в файл PPTX.

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# Создать экземпляр класса Presentation.
with slides.Presentation() as presentation:

    # Доступ к первому слайду.
    slide = presentation.slides[0]

    # Добавить образцовую диаграмму.
    chart = slide.shapes.add_chart(charts.ChartType.LINE_WITH_MARKERS, 50, 50, 500, 400)

    # Задать заголовок диаграммы.
    chart.has_title = True
    chart.chart_title.add_text_frame_for_overriding("")
    chart_title = chart.chart_title.text_frame_for_overriding.paragraphs[0].portions[0]
    chart_title.text = "Sample Chart"
    chart_title.portion_format.fill_format.fill_type = slides.FillType.SOLID
    chart_title.portion_format.fill_format.solid_fill_color.color = draw.Color.gray
    chart_title.portion_format.font_height = 20
    chart_title.portion_format.font_bold = 1
    chart_title.portion_format.font_italic = 1

    # Задать формат основных линий сетки для оси значений.
    chart.axes.vertical_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.vertical_axis.major_grid_lines_format.line.fill_format.solid_fill_color.color = draw.Color.blue
    chart.axes.vertical_axis.major_grid_lines_format.line.width = 5
    chart.axes.vertical_axis.major_grid_lines_format.line.dash_style = slides.LineDashStyle.DASH_DOT

    # Задать формат вспомогательных линий сетки для оси значений.
    chart.axes.vertical_axis.minor_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.vertical_axis.minor_grid_lines_format.line.fill_format.solid_fill_color.color = draw.Color.red
    chart.axes.vertical_axis.minor_grid_lines_format.line.width = 3

    # Задать числовой формат оси значений.
    chart.axes.vertical_axis.is_number_format_linked_to_source = False
    chart.axes.vertical_axis.display_unit = charts.DisplayUnitType.THOUSANDS
    chart.axes.vertical_axis.number_format = "0.0%"

    # Задать максимум, минимум, основные и вспомогательные единицы оси значений.
    chart.axes.vertical_axis.is_automatic_major_unit = False
    chart.axes.vertical_axis.is_automatic_max_value = False
    chart.axes.vertical_axis.is_automatic_minor_unit = False
    chart.axes.vertical_axis.is_automatic_min_value = False

    chart.axes.vertical_axis.max_value = 15
    chart.axes.vertical_axis.min_value = -2
    chart.axes.vertical_axis.minor_unit = 0.5
    chart.axes.vertical_axis.major_unit = 2.0

    # Задать свойства текста оси значений.
    vertical_axis_portion_format = chart.axes.vertical_axis.text_format.portion_format
    vertical_axis_portion_format.font_bold = 1
    vertical_axis_portion_format.font_height = 16
    vertical_axis_portion_format.font_italic = 1
    vertical_axis_portion_format.fill_format.fill_type = slides.FillType.SOLID 
    vertical_axis_portion_format.fill_format.solid_fill_color.color = draw.Color.dark_green
    vertical_axis_portion_format.latin_font = slides.FontData("Times New Roman")

    # Задать заголовок оси значений.
    chart.axes.vertical_axis.has_title = True
    chart.axes.vertical_axis.title.add_text_frame_for_overriding("")
    vertical_axis_title = chart.axes.vertical_axis.title.text_frame_for_overriding.paragraphs[0].portions[0]
    vertical_axis_title.text = "Primary Axis"
    vertical_axis_title.portion_format.fill_format.fill_type = slides.FillType.SOLID
    vertical_axis_title.portion_format.fill_format.solid_fill_color.color = draw.Color.gray
    vertical_axis_title.portion_format.font_height = 20
    vertical_axis_title.portion_format.font_bold = 1
    vertical_axis_title.portion_format.font_italic = 1

    # Задать формат основных линий сетки для оси категорий.
    chart.axes.horizontal_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.horizontal_axis.major_grid_lines_format.line.fill_format.solid_fill_color.color = draw.Color.green
    chart.axes.horizontal_axis.major_grid_lines_format.line.width = 5

    # Задать формат вспомогательных линий сетки для оси категорий.
    chart.axes.horizontal_axis.minor_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.horizontal_axis.minor_grid_lines_format.line.fill_format.solid_fill_color.color = draw.Color.yellow
    chart.axes.horizontal_axis.minor_grid_lines_format.line.width = 3

    # Задать свойства текста оси категорий.
    horizontal_axis_portion_format = chart.axes.horizontal_axis.text_format.portion_format
    horizontal_axis_portion_format.font_bold = 1
    horizontal_axis_portion_format.font_height = 16
    horizontal_axis_portion_format.font_italic = 1
    horizontal_axis_portion_format.fill_format.fill_type = slides.FillType.SOLID 
    horizontal_axis_portion_format.fill_format.solid_fill_color.color = draw.Color.blue
    horizontal_axis_portion_format.latin_font = slides.FontData("Arial")

    # Задать заголовок оси категорий.
    chart.axes.horizontal_axis.has_title = True
    chart.axes.horizontal_axis.title.add_text_frame_for_overriding("")

    horizontal_axis_title = chart.axes.horizontal_axis.title.text_frame_for_overriding.paragraphs[0].portions[0]
    horizontal_axis_title.text = "Sample Category"
    horizontal_axis_title.portion_format.fill_format.fill_type = slides.FillType.SOLID
    horizontal_axis_title.portion_format.fill_format.solid_fill_color.color = draw.Color.gray
    horizontal_axis_title.portion_format.font_height = 20
    horizontal_axis_title.portion_format.font_bold = 1
    horizontal_axis_title.portion_format.font_italic = 1

    # Задать позицию подписи оси категорий.
    chart.axes.horizontal_axis.tick_label_position = charts.TickLabelPositionType.LOW

    # Задать угол поворота подписи оси категорий.
    chart.axes.horizontal_axis.tick_label_rotation_angle = 45

    # Задать свойства текста легенды.
    legend_portion_format = chart.legend.text_format.portion_format
    legend_portion_format.font_bold = 1
    legend_portion_format.font_height = 16
    legend_portion_format.font_italic = 1
    legend_portion_format.fill_format.fill_type = slides.FillType.SOLID 
    legend_portion_format.fill_format.solid_fill_color.color = draw.Color.dark_red

    # Показать легенду диаграммы, перекрывающую диаграмму.
    chart.legend.overlay = True
                
    # Задать цвет заливки задней стенки диаграммы.
    chart.back_wall.thickness = 1
    chart.back_wall.format.fill.fill_type = slides.FillType.SOLID
    chart.back_wall.format.fill.solid_fill_color.color = draw.Color.orange

    chart.floor.format.fill.fill_type = slides.FillType.SOLID
    chart.floor.format.fill.solid_fill_color.color = draw.Color.red

    # Задать цвет заливки области построения.
    chart.plot_area.format.fill.fill_type = slides.FillType.SOLID
    chart.plot_area.format.fill.solid_fill_color.color = draw.Color.light_cyan

    # Сохранить презентацию.
    presentation.save("FormattedChart.pptx", slides.export.SaveFormat.PPTX)
```

## **Задать свойства шрифта диаграммы**

Aspose.Slides for Python поддерживает задание свойств шрифта для диаграмм. Выполните следующие шаги, чтобы настроить свойства шрифта диаграммы:

1. Создать объект [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Добавить диаграмму на слайд.
1. Задать высоту шрифта.
1. Сохранить изменённую презентацию.

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

## **Задать числовой формат**

Aspose.Slides for Python предоставляет простой API для управления форматами данных диаграммы:

1. Создать экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Получить ссылку на слайд по его индексу.
1. Добавить диаграмму с данными по умолчанию любого требуемого типа.
1. Задать предустановленный числовой формат из доступных значений.
1. Пройтись по ячейкам данных диаграммы в каждой серии и задать числовой формат.
1. Сохранить презентацию.
1. Задать пользовательский числовой формат.
1. Пройтись по ячейкам данных диаграммы в каждой серии и задать иной числовой формат.
1. Сохранить презентацию.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Создать экземпляр класса Presentation.
with slides.Presentation() as presentation:
    # Доступ к первому слайду.
    slide = presentation.slides[0]

    # Добавить диаграмму кластерных столбцов по умолчанию.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 400)

    # Задать предустановленный числовой формат.
    # Пройтись по каждой серии диаграммы.
    for series in chart.chart_data.series:
        # Пройтись по каждой точке данных в серии.
        for cell in series.data_points:
            # Задать числовой формат.
            cell.value.as_cell.preset_number_format = 10  # 0.00%

    # Сохранить презентацию.
    presentation.save("PresetNumberFormat.pptx", slides.export.SaveFormat.PPTX)
```

Доступные предустановленные числовые форматы и их индексы перечислены ниже.

|**0**|General|
| :- | :- |
|**1**|0|
|**2**|0.00|
|**3**|#,##0|
|**4**|#,##0.00|
|**5**|$#,##0;$-#,##0|
|**6**|$#,##0;Red$-#,##0|
|**7**|$#,##0.00;$-#,##0.00|
|**8**|$#,##0.00;Red$-#,##0.00|
|**9**|0%|
|**10**|0.00%|
|**11**|0.00E+00|
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
|**39**|#,##0.00;-#,##0.00|
|**40**|#,##0.00;Red-#,##0.00|
|**41**|_ * #,##0_ ;_ * "_ ;_ @_|
|**42**|_ $* #,##0_ ;_ $* "_ ;_ @_|
|**43**|_ * #,##0.00_ ;_ * "??_ ;_ @_|
|**44**|_ $* #,##0.00_ ;_ $* "??_ ;_ @_|
|**45**|mm:ss|
|**46**|h :mm:ss|
|**47**|[mm:ss.0](http://mmss.0)|
|**48**|##0.0E+00|
|**49**|@|

## **Установить скругленные границы области диаграммы**

Aspose.Slides for Python поддерживает настройку области диаграммы с помощью свойства `Chart.has_rounded_corners`.

1. Создать объект [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Добавить диаграмму на слайд.
3. Задать тип заливки и цвет заливки диаграммы.
4. Установить свойство скруглённых углов в `True`.
5. Сохранить изменённую презентацию.

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

Да. Прозрачность заливки и контура настраиваются отдельно. Это полезно для улучшения читаемости сетки и данных в плотных визуализациях.

**Как поступить с подписями данных, когда они перекрываются?**

Уменьшить размер шрифта, отключить ненужные компоненты подписи (например, категории), задать смещение/позицию подписи, показывать подписи только для выбранных точек при необходимости или переключить формат на «значение + легенда».

**Можно ли применить градиентные или шаблонные заливки к сериям?**

Да. Обычно доступны как сплошные, так и градиентные/шаблонные заливки. На практике используйте градиенты умеренно и избегайте сочетаний, снижающих контраст сетки и текста.