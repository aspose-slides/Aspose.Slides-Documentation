---
title: Форматирование диаграмм в презентациях с использованием Python
linktitle: Форматирование диаграмм
type: docs
weight: 60
url: /ru/python-net/chart-formatting/
keywords:
- формат диаграммы
- форматирование диаграмм
- объект диаграммы
- свойства диаграммы
- настройки диаграммы
- опции диаграммы
- свойства шрифта
- скруглённые границы
- PowerPoint
- OpenDocument
- презентация
- Python
- Aspose.Slides
description: "Изучите форматирование диаграмм в Aspose.Slides для Python через .NET и улучшите свою презентацию PowerPoint или OpenDocument с профессиональным, привлекающим внимание оформлением."
---

## **Обзор**

Это руководство демонстрирует, как форматировать диаграммы PowerPoint с помощью Aspose.Slides для Python. Оно пошагово показывает, как настраивать основные элементы диаграммы — оси категорий и значений, линии сетки, подписи, заголовки, легенды и вторичные оси, а также управлять шрифтами, числовыми форматами, заливками, контурами, цветами области построения и задней стены, и скругленными углами диаграммы с помощью кратких исполняемых примеров кода. Следуя примерам, вы создадите [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/), добавите и настроите диаграмму и сохраните результат в PPTX, применив точные визуальные и типографические настройки.

## **Форматирование элементов диаграммы**

Aspose.Slides для Python позволяет разработчикам добавлять пользовательские диаграммы на слайды с нуля. В этом разделе объясняется, как форматировать различные элементы диаграммы, включая оси категорий и значений.

Aspose.Slides предоставляет простой API для управления элементами диаграммы и применения пользовательского форматирования:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте диаграмму с данными по умолчанию нужного типа (в этом примере `ChartType.LINE_WITH_MARKERS`).
1. Получите доступ к оси значений диаграммы и задайте следующее:
   1. Установите **формат линии** для основных линий сетки оси значений.
   1. Установите **формат линии** для вспомогательных линий сетки оси значений.
   1. Установите **числовой формат** для оси значений.
   1. Установите **минимальное, максимальное, основные и вспомогательные единицы** для оси значений.
   1. Установите **свойства текста** для подписей оси значений.
   1. Установите **заголовок** для оси значений.
   1. Установите **формат линии** для оси значений.
1. Получите доступ к оси категорий диаграммы и задайте следующее:
   1. Установите **формат линии** для основных линий сетки оси категорий.
   1. Установите **формат линии** для вспомогательных линий сетки оси категорий.
   1. Установите **свойства текста** для подп��сей оси категорий.
   1. Установите **заголовок** для оси категорий.
   1. Установите **положение подписи** для оси категорий.
   1. Установите **угол поворота** для подписей оси категорий.
1. Получите доступ к легенде диаграммы и задайте её **свойства текста**.
1. Отобразите легенду диаграммы без наложения на саму диаграмму.
1. Получите доступ к **вторичной оси значений** диаграммы и задайте следующее:
   1. Включите вторичную **ось значений**.
   1. Установите **формат линии** для вторичной оси значений.
   1. Установите **числовой формат** для вторичной оси значений.
   1. Установите **минимальное, максимальное, основные и вспомогательные единицы** для вторичной оси значений.
1. Отобразите первую серию диаграммы на вторичной оси значений.
1. Установите цвет заливки задней стены диаграммы.
1. Установите цвет заливки области построения диаграммы.
1. Запишите изменённую презентацию в файл PPTX.
```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# Создать объект класса Presentation.
with slides.Presentation() as presentation:

    # Получить первый слайд.
    slide = presentation.slides[0]

    # Добавить пример диаграммы.
    chart = slide.shapes.add_chart(charts.ChartType.LINE_WITH_MARKERS, 50, 50, 500, 400)

    # Установить заголовок диаграммы.
    chart.has_title = True
    chart.chart_title.add_text_frame_for_overriding("")
    chart_title = chart.chart_title.text_frame_for_overriding.paragraphs[0].portions[0]
    chart_title.text = "Sample Chart"
    chart_title.portion_format.fill_format.fill_type = slides.FillType.SOLID
    chart_title.portion_format.fill_format.solid_fill_color.color = draw.Color.gray
    chart_title.portion_format.font_height = 20
    chart_title.portion_format.font_bold = 1
    chart_title.portion_format.font_italic = 1

    # Установить формат основных линий сетки для оси значений.
    chart.axes.vertical_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.vertical_axis.major_grid_lines_format.line.fill_format.solid_fill_color.color = draw.Color.blue
    chart.axes.vertical_axis.major_grid_lines_format.line.width = 5
    chart.axes.vertical_axis.major_grid_lines_format.line.dash_style = slides.LineDashStyle.DASH_DOT

    # Установить формат вспомогательных линий сетки для оси значений.
    chart.axes.vertical_axis.minor_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.vertical_axis.minor_grid_lines_format.line.fill_format.solid_fill_color.color = draw.Color.red
    chart.axes.vertical_axis.minor_grid_lines_format.line.width = 3

    # Задать числовой формат оси значений.
    chart.axes.vertical_axis.is_number_format_linked_to_source = False
    chart.axes.vertical_axis.display_unit = charts.DisplayUnitType.THOUSANDS
    chart.axes.vertical_axis.number_format = "0.0%"

    # Задать максимум, минимум, основной и вспомогательный шаги оси значений.
    chart.axes.vertical_axis.is_automatic_major_unit = False
    chart.axes.vertical_axis.is_automatic_max_value = False
    chart.axes.vertical_axis.is_automatic_minor_unit = False
    chart.axes.vertical_axis.is_automatic_min_value = False

    chart.axes.vertical_axis.max_value = 15
    chart.axes.vertical_axis.min_value = -2
    chart.axes.vertical_axis.minor_unit = 0.5
    chart.axes.vertical_axis.major_unit = 2.0

    # Установить свойства текста оси значений.
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

    # Установить формат основных линий сетки для оси категорий.
    chart.axes.horizontal_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.horizontal_axis.major_grid_lines_format.line.fill_format.solid_fill_color.color = draw.Color.green
    chart.axes.horizontal_axis.major_grid_lines_format.line.width = 5

    # Установить формат вспомогательных линий сетки для оси категорий.
    chart.axes.horizontal_axis.minor_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.horizontal_axis.minor_grid_lines_format.line.fill_format.solid_fill_color.color = draw.Color.yellow
    chart.axes.horizontal_axis.minor_grid_lines_format.line.width = 3

    # Установить свойства текста оси категорий.
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

    # Установить позицию меток оси категорий.
    chart.axes.horizontal_axis.tick_label_position = charts.TickLabelPositionType.LOW

    # Задать угол поворота меток оси категорий.
    chart.axes.horizontal_axis.tick_label_rotation_angle = 45

    # Установить свойства текста легенды.
    legend_portion_format = chart.legend.text_format.portion_format
    legend_portion_format.font_bold = 1
    legend_portion_format.font_height = 16
    legend_portion_format.font_italic = 1
    legend_portion_format.fill_format.fill_type = slides.FillType.SOLID 
    legend_portion_format.fill_format.solid_fill_color.color = draw.Color.dark_red

    # Отобразить легенду диаграммы, перекрывая диаграмму.
    chart.legend.overlay = True
                
    # Задать цвет задней стенки диаграммы.
    chart.back_wall.thickness = 1
    chart.back_wall.format.fill.fill_type = slides.FillType.SOLID
    chart.back_wall.format.fill.solid_fill_color.color = draw.Color.orange

    chart.floor.format.fill.fill_type = slides.FillType.SOLID
    chart.floor.format.fill.solid_fill_color.color = draw.Color.red

    # Установить цвет области построения.
    chart.plot_area.format.fill.fill_type = slides.FillType.SOLID
    chart.plot_area.format.fill.solid_fill_color.color = draw.Color.light_cyan

    # Сохранить презентацию.
    presentation.save("FormattedChart.pptx", slides.export.SaveFormat.PPTX)
```


## **Установка свойств шрифтов диаграммы**

Aspose.Slides для Python поддерживает настройку свойств шрифтов для диаграмм. Выполните следующие шаги, чтобы сконфигурировать шрифты диаграммы:

1. Создайте объект [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Добавьте диаграмму на слайд.
1. Установите высоту шрифта.
1. Сохраните изменённую презентацию.

Ниже приведён пример кода.
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

Aspose.Slides для Python предоставляет простой API для управления форматами данных диаграммы:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте диаграмму с данными по умолчанию любого требуемого типа.
1. Выберите предустановленный числовой формат из доступных значений.
1. Пройдитесь по ячейкам данных диаграммы в каждой серии и установите числовой формат.
1. Сохраните презентацию.
1. Установите пользовательский числовой формат.
1. Пройдитесь по ячейкам данных диаграммы в каждой серии и задайте иной числовой формат.
1. Сохраните презентацию.
```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Создать объект класса Presentation.
with slides.Presentation() as presentation:
    # Получить первый слайд.
    slide = presentation.slides[0]

    # Добавить диаграмму кластерных столбцов по умолчанию.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 400)

    # Установить предустановленный числовой формат.
    # Пройтись по каждой серии диаграммы.
    for series in chart.chart_data.series:
        # Пройтись по каждому элементу данных в серии.
        for cell in series.data_points:
            # Установить числовой формат.
            cell.value.as_cell.preset_number_format = 10  # 0.00%

    # Сохранить презентацию.
    presentation.save("PresetNumberFormat.pptx", slides.export.SaveFormat.PPTX)
```


Доступные предустановленные числовые форматы и их индексы перечислены ниже.

|**0**|Общий|
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

## **Установка скруглённых границ для области диаграммы**

Aspose.Slides для Python поддерживает настройку области диаграммы с помощью свойства `Chart.has_rounded_corners`.

1. Создайте объект [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Добавьте диаграмму на слайд.
3. Установите тип заливки диаграммы и её цвет.
4. Установите свойство скруглённых углов в `True`.
5. Сохраните изменённую презентацию.

Ниже приведён пример.
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

Уменьшите размер шрифта, отключите ненужные компоненты подписей (например, категории), задайте смещение/позицию подписи, при необходимости отображайте подписи только для выбранных точек или переключите формат на «значение + легенда».

**Можно ли применить градиентные или шаблонные заливки к сериям?**

Да. Обычно доступны как сплошные, так и градиентные/шаблонные заливки. На практике используйте градиенты умеренно и избегайте комбинаций, снижающих контраст со сеткой и текстом.