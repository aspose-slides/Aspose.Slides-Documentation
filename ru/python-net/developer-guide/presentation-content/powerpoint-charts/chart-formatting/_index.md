---
title: Форматирование графиков
type: docs
weight: 60
url: /python-net/chart-formatting/
keywords: "Элементы графика, свойства графика, презентация PowerPoint, Python, Aspose.Slides для Python через .NET"
description: "Форматирование элементов графиков в презентациях PowerPoint на Python"
---

## **Форматирование элементов графиков**
Aspose.Slides для Python через .NET позволяет разработчикам добавлять пользовательские графики на свои слайды с нуля. В этой статье объясняется, как форматировать различные элементы графиков, включая оси категорий и значения графика.

Aspose.Slides для Python через .NET предоставляет простой API для управления различными элементами графиков и их форматирования с использованием настраиваемых значений:

1. Создайте экземпляр класса **Presentation**.
1. Получите ссылку на слайд по его индексу.
1. Добавьте график с данными по умолчанию любого желаемого типа (в этом примере мы будем использовать ChartType.LineWithMarkers).
1. Получите доступ к оси значений графика и установите следующие параметры:
   1. Установите **Формат линии** для основных линий сетки оси значений
   1. Установите **Формат линии** для второстепенных линий сетки оси значений
   1. Установите **Формат чисел** для оси значений
   1. Установите **Минимальные, Максимальные, Основные и Второстепенные единицы** для оси значений
   1. Установите **Свойства текста** для данных оси значений
   1. Установите **Заголовок** для оси значений
   1. Установите **Формат линии** для оси значений
1. Получите доступ к оси категорий графика и установите следующие параметры:
   1. Установите **Формат линии** для основных линий сетки оси категорий
   1. Установите **Формат линии** для второстепенных линий сетки оси категорий
   1. Установите **Свойства текста** для данных оси категорий
   1. Установите **Заголовок** для оси категорий
   1. Установите **Позиционирование меток** для оси категорий
   1. Установите **Угол поворота** для меток оси категорий
1. Получите доступ к легенде графика и установите **Свойства текста** для них
1. Установите отображение легенд графиков без наложения на график
1. Получите доступ ко **вторичной оси значений графика** и установите следующие параметры:
   1. Включите вторичную **ось значений**
   1. Установите **Формат линии** для вторичной оси значений
   1. Установите **Формат чисел** для вторичной оси значений
   1. Установите **Минимальные, Максимальные, Основные и Второстепенные единицы** для вторичной оси значений
1. Теперь отобразите первую серию графиков на вторичной оси значений
1. Установите цвет заливки задней стены графика
1. Установите цвет заливки области построения графика
1. Запишите измененную презентацию в файл PPTX

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# Создание презентации
with slides.Presentation() as pres:

    # Доступ к первому слайду
    slide = pres.slides[0]

    # Добавление примера графика
    chart = slide.shapes.add_chart(charts.ChartType.LINE_WITH_MARKERS, 50, 50, 500, 400)

    # Установка заголовка графика
    chart.has_title = True
    chart.chart_title.add_text_frame_for_overriding("")
    chartTitle = chart.chart_title.text_frame_for_overriding.paragraphs[0].portions[0]
    chartTitle.text = "Пример графика"
    chartTitle.portion_format.fill_format.fill_type = slides.FillType.SOLID
    chartTitle.portion_format.fill_format.solid_fill_color.color = draw.Color.gray
    chartTitle.portion_format.font_height = 20
    chartTitle.portion_format.font_bold = 1
    chartTitle.portion_format.font_italic = 1

    # Установка формата основных линий сетки для оси значений
    chart.axes.vertical_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.vertical_axis.major_grid_lines_format.line.fill_format.solid_fill_color.color = draw.Color.blue
    chart.axes.vertical_axis.major_grid_lines_format.line.width = 5
    chart.axes.vertical_axis.major_grid_lines_format.line.dash_style = slides.LineDashStyle.DASH_DOT

    # Установка формата второстепенных линий сетки для оси значений
    chart.axes.vertical_axis.minor_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.vertical_axis.minor_grid_lines_format.line.fill_format.solid_fill_color.color = draw.Color.red
    chart.axes.vertical_axis.minor_grid_lines_format.line.width = 3

    # Установка формата чисел оси значений
    chart.axes.vertical_axis.is_number_format_linked_to_source = False
    chart.axes.vertical_axis.display_unit = charts.DisplayUnitType.THOUSANDS
    chart.axes.vertical_axis.number_format = "0.0%"

    # Установка максимальных и минимальных значений графика
    chart.axes.vertical_axis.is_automatic_major_unit = False
    chart.axes.vertical_axis.is_automatic_max_value = False
    chart.axes.vertical_axis.is_automatic_minor_unit = False
    chart.axes.vertical_axis.is_automatic_min_value = False

    chart.axes.vertical_axis.max_value = 15
    chart.axes.vertical_axis.min_value = -2
    chart.axes.vertical_axis.minor_unit = 0.5
    chart.axes.vertical_axis.major_unit = 2.0

    # Установка свойств текста оси значений
    txtVal = chart.axes.vertical_axis.text_format.portion_format
    txtVal.font_bold = 1
    txtVal.font_height = 16
    txtVal.font_italic = 1
    txtVal.fill_format.fill_type = slides.FillType.SOLID 
    txtVal.fill_format.solid_fill_color.color = draw.Color.dark_green
    txtVal.latin_font = slides.FontData("Times New Roman")

    # Установка заголовка оси значений
    chart.axes.vertical_axis.has_title = True
    chart.axes.vertical_axis.title.add_text_frame_for_overriding("")
    valtitle = chart.axes.vertical_axis.title.text_frame_for_overriding.paragraphs[0].portions[0]
    valtitle.text = "Основная ось"
    valtitle.portion_format.fill_format.fill_type = slides.FillType.SOLID
    valtitle.portion_format.fill_format.solid_fill_color.color = draw.Color.gray
    valtitle.portion_format.font_height = 20
    valtitle.portion_format.font_bold = 1
    valtitle.portion_format.font_italic = 1

    # Установка формата основных линий сетки для оси категорий
    chart.axes.horizontal_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.horizontal_axis.major_grid_lines_format.line.fill_format.solid_fill_color.color = draw.Color.green
    chart.axes.horizontal_axis.major_grid_lines_format.line.width = 5

    # Установка формата второстепенных линий сетки для оси категорий
    chart.axes.horizontal_axis.minor_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.horizontal_axis.minor_grid_lines_format.line.fill_format.solid_fill_color.color = draw.Color.yellow
    chart.axes.horizontal_axis.minor_grid_lines_format.line.width = 3

    # Установка свойств текста оси категорий
    txtCat = chart.axes.horizontal_axis.text_format.portion_format
    txtCat.font_bold = 1
    txtCat.font_height = 16
    txtCat.font_italic = 1
    txtCat.fill_format.fill_type = slides.FillType.SOLID 
    txtCat.fill_format.solid_fill_color.color = draw.Color.blue
    txtCat.latin_font = slides.FontData("Arial")

    # Установка заголовка категории
    chart.axes.horizontal_axis.has_title = True
    chart.axes.horizontal_axis.title.add_text_frame_for_overriding("")

    catTitle = chart.axes.horizontal_axis.title.text_frame_for_overriding.paragraphs[0].portions[0]
    catTitle.text = "Пример категории"
    catTitle.portion_format.fill_format.fill_type = slides.FillType.SOLID
    catTitle.portion_format.fill_format.solid_fill_color.color = draw.Color.gray
    catTitle.portion_format.font_height = 20
    catTitle.portion_format.font_bold = 1
    catTitle.portion_format.font_italic = 1

    # Установка позиции меток оси категорий
    chart.axes.horizontal_axis.tick_label_position = charts.TickLabelPositionType.LOW

    # Установка угла поворота меток оси категорий
    chart.axes.horizontal_axis.tick_label_rotation_angle = 45

    # Установка свойств текста легенд
    txtleg = chart.legend.text_format.portion_format
    txtleg.font_bold = 1
    txtleg.font_height = 16
    txtleg.font_italic = 1
    txtleg.fill_format.fill_type = slides.FillType.SOLID 
    txtleg.fill_format.solid_fill_color.color = draw.Color.dark_red

    # Установите отображение легенд графика без наложения на график

    chart.legend.overlay = True
                
    # Установка цвета задней стены графика
    chart.back_wall.thickness = 1
    chart.back_wall.format.fill.fill_type = slides.FillType.SOLID
    chart.back_wall.format.fill.solid_fill_color.color = draw.Color.orange

    chart.floor.format.fill.fill_type = slides.FillType.SOLID
    chart.floor.format.fill.solid_fill_color.color = draw.Color.red
    # Установка цвета области построения графика
    chart.plot_area.format.fill.fill_type = slides.FillType.SOLID
    chart.plot_area.format.fill.solid_fill_color.color = draw.Color.light_cyan

    # Сохранить презентацию
    pres.save("FormattedChart_out.pptx", slides.export.SaveFormat.PPTX)
```



## **Установить свойства шрифта для графика**
Aspose.Slides для Python через .NET предоставляет поддержку для установки связанных со шрифтом свойств графика. Пожалуйста, следуйте приведенным ниже шагам для установки свойств шрифта для графика.

- Создайте объект класса Presentation.
- Добавьте график на слайд.
- Установите высоту шрифта.
- Сохраните измененную презентацию.

Приведен ниже пример.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 500, 400)
    chart.text_format.portion_format.font_height = 20
    chart.chart_data.series[0].labels.default_data_label_format.show_value = True
    pres.save("FontPropertiesForChart.pptx", slides.export.SaveFormat.PPTX)
```




## **Установить формат чисел**
Aspose.Slides для Python через .NET предоставляет простой API для управления форматом данных графика:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте график с данными по умолчанию любого желаемого типа (в этом примере используется **ChartType.ClusteredColumn**).
1. Установите предустановленный формат числа из возможных предустановленных значений.
1. Пройдите по ячейкам данных графика в каждой серии графиков и установите формат чисел графика.
1. Сохраните презентацию.
1. Установите пользовательский формат чисел.
1. Пройдите по ячейкам данных графика в каждой серии графиков, устанавливая другой формат данных графика.
1. Сохраните презентацию.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Создание презентации
with slides.Presentation() as pres:
    # Доступ к первому слайду презентации
    slide = pres.slides[0]

    # Добавление графика с предустановленным столбцовым графиком
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 400)

    # Доступ к коллекции серий графиков
    series = chart.chart_data.series

    # Установка предустановленного формата чисел
    # Пройдите по каждой серии графиков
    for ser in series:
        # Пройдите по каждой ячейке данных в серии
        for cell in ser.data_points:
            # Установка формата чисел
            cell.value.as_cell.preset_number_format = 10 #0.00%

    # Сохранение презентации
    pres.save("PresetNumberFormat_out.pptx", slides.export.SaveFormat.PPTX)
```

Возможные предустановленные значения формата чисел вместе с их индексами, которые могут быть использованы, приведены ниже:

|**0**|Общее|
| :- | :- |
|**1**|0|
|**2**|0.00|
|**3**|#,##0|
|**4**|#,##0.00|
|**5**|$#,##0;$-#,##0|
|**6**|$#,##0;Красный$-#,##0|
|**7**|$#,##0.00;$-#,##0.00|
|**8**|$#,##0.00;Красный$-#,##0.00|
|**9**|0%|
|**10**|0.00%|
|**11**|0.00E+00|
|**12**|# ?/?|
|**13**|# /|
|**14**|д/м/гг|
|**15**|д-ммм-гг|
|**16**|д-ммм|
|**17**|ммм-гг|
|**18**|ч:мм AM/PM|
|**19**|ч:мм:сс AM/PM|
|**20**|ч:мм|
|**21**|ч:мм:сс|
|**22**|д/м/гг ч:мм|
|**37**|#,##0;-#,##0|
|**38**|#,##0;Красный-#,##0|
|**39**|#,##0.00;-#,##0.00|
|**40**|#,##0.00;Красный-#,##0.00|
|**41**|_ * #,##0_ ;_ * "_ ;_ @_|
|**42**|_ $* #,##0_ ;_ $* "_ ;_ @_|
|**43**|_ * #,##0.00_ ;_ * "??_ ;_ @_|
|**44**|_ $* #,##0.00_ ;_ $* "??_ ;_ @_|
|**45**|мм:сс|
|**46**|ч :мм:сс|
|**47**|[мм:сс.0](http://mmss.0)|
|**48**|##0.0E+00|
|**49**|@|

## **Установить округленные края области графика**
Aspose.Slides для Python через .NET предоставляет поддержку для установки области графика. **IChart.HasRoundedCorners** и **Chart.HasRoundedCorners** свойства были добавлены в Aspose.Slides.

1. Создайте объект класса `Presentation`.
1. Добавьте график на слайд.
1. Установите тип заливки и цвет заливки графика
1. Установите свойство круглого угла на True.
1. Сохраните измененную презентацию.

 Приведен ниже пример.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
	slide = presentation.slides[0]
	chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 100, 600, 400)
	chart.line_format.fill_format.fill_type = slides.FillType.SOLID
	chart.line_format.style = slides.LineStyle.SINGLE
	chart.has_rounded_corners = True

	presentation.save("out.pptx", slides.export.SaveFormat.PPTX)
```