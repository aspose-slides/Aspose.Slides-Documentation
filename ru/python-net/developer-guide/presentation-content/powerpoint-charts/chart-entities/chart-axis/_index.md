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
description: "Узнайте, как использовать Aspose.Slides для Python через .NET для настройки осей диаграмм в презентациях PowerPoint и OpenDocument для отчетов и визуализаций."
---

## **Получение максимальных значений на вертикальной оси диаграмм**
Aspose.Slides для Python через .NET позволяет получать минимальные и максимальные значения на вертикальной оси. Выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Получите доступ к первому слайду.
3. Добавьте диаграмму с данными по умолчанию.
4. Получите фактическое максимальное значение оси.
5. Получите фактическое минимальное значение оси.
6. Получите фактическую основную единицу измерения оси.
7. Получите фактическую второстепенную единицу измерения оси.
8. Получите фактический масштаб основной единицы оси.
9. Получите фактический масштаб второстепенной единицы оси.

Этот пример кода — реализация описанных шагов — показывает, как получить необходимые значения на Python:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.AREA, 100, 100, 500, 350)
	chart.validate_chart_layout()

	maxValue = chart.axes.vertical_axis.actual_max_value
	minValue = chart.axes.vertical_axis.actual_min_value

	majorUnit = chart.axes.horizontal_axis.actual_major_unit
	minorUnit = chart.axes.horizontal_axis.actual_minor_unit
	
	# Saves the presentation
	pres.save("ErrorBars_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Перемещение данных между осями**
Aspose.Slides позволяет быстро менять местами данные между осями — данные, отображаемые на вертикальной оси (y‑axis), перемещаются на горизонтальную ось (x‑axis) и наоборот. 

Этот код на Python показывает, как выполнить задачу перестановки данных между осями в диаграмме:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Creates empty presentation
with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 400, 300)

    #Switches rows and columns
    chart.chart_data.switch_row_column()
            
    # Saves presentation
    pres.save("SwitchChartRowColumns_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Отключение вертикальной оси для линейных диаграмм**
Этот код на Python показывает, как скрыть вертикальную ось в линейной диаграмме:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.LINE, 100, 100, 400, 300)
    chart.axes.vertical_axis.is_visible = False
    
    pres.save("chart-is_visible.pptx", slides.export.SaveFormat.PPTX)
```

## **Отключение горизонтальной оси для линейных диаграмм**
Этот код показывает, как скрыть горизонтальную ось в линейной диаграмме:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
 
with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.LINE, 100, 100, 400, 300)
    chart.axes.horizontal_axis.is_visible = False

    pres.save("chart-2.pptx", slides.export.SaveFormat.PPTX)
```

## **Изменение оси категорий**
С помощью свойства **CategoryAxisType** можно задать предпочитаемый тип оси категорий (**date** или **text**). Этот код на Python демонстрирует эту операцию: 

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation(path + "ExistingChart.pptx") as presentation:
    chart = presentation.slides[0].shapes[0]
    chart.axes.horizontal_axis.category_axis_type = charts.CategoryAxisType.DATE
    chart.axes.horizontal_axis.is_automatic_major_unit = False
    chart.axes.horizontal_axis.major_unit = 1
    chart.axes.horizontal_axis.major_unit_scale = charts.TimeUnitType.MONTHS
    presentation.save("ChangeChartCategoryAxis_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Установка формата даты для значений оси категорий**
Aspose.Slides для Python через .NET позволяет задать формат даты для значений оси категорий. Операция продемонстрирована в следующем коде на Python:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
from datetime import date

def to_oadate(dt):
    delta = dt - date(1899, 12, 30)
    return delta.days + (delta.seconds + delta.microseconds / 1e6) / (24 * 3600)

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.AREA, 50, 50, 450, 300)

    wb = chart.chart_data.chart_data_workbook

    wb.clear(0)

    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    chart.chart_data.categories.add(wb.get_cell(0, "A2", to_oadate(date(2015, 1, 1))))
    chart.chart_data.categories.add(wb.get_cell(0, "A3", to_oadate(date(2016, 1, 1))))
    chart.chart_data.categories.add(wb.get_cell(0, "A4", to_oadate(date(2017, 1, 1))))
    chart.chart_data.categories.add(wb.get_cell(0, "A5", to_oadate(date(2018, 1, 1))))

    series = chart.chart_data.series.add(charts.ChartType.LINE)
    series.data_points.add_data_point_for_line_series(wb.get_cell(0, "B2", 1))
    series.data_points.add_data_point_for_line_series(wb.get_cell(0, "B3", 2))
    series.data_points.add_data_point_for_line_series(wb.get_cell(0, "B4", 3))
    series.data_points.add_data_point_for_line_series(wb.get_cell(0, "B5", 4))
    chart.axes.horizontal_axis.category_axis_type = charts.CategoryAxisType.DATE
    chart.axes.horizontal_axis.is_number_format_linked_to_source = False
    chart.axes.horizontal_axis.number_format = "yyyy"
    pres.save("test.pptx", slides.export.SaveFormat.PPTX)
```

## **Установка угла поворота заголовка оси диаграммы**
Aspose.Slides для Python через .NET позволяет задать угол поворота заголовка оси диаграммы. Этот код на Python демонстрирует эту операцию:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
    chart.axes.vertical_axis.has_title = True
    chart.axes.vertical_axis.title.text_format.text_block_format.rotation_angle = 90

    pres.save("test.pptx", slides.export.SaveFormat.PPTX)
```

## **Установка позиции оси в оси категорий или значений**
Aspose.Slides для Python через .NET позволяет установить позицию оси в оси категорий или значений. Этот код на Python показывает, как выполнить задачу:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
	chart.axes.horizontal_axis.axis_between_categories = True

	pres.save("AsposeScatterChart.pptx", slides.export.SaveFormat.PPTX)
```

## **Включение отображения единицы измерения на оси значений диаграммы**
Aspose.Slides для Python через .NET позволяет настроить диаграмму так, чтобы отображалась метка единицы измерения на оси значений диаграммы. Этот код на Python демонстрирует эту операцию:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
	chart.axes.vertical_axis.display_unit = charts.DisplayUnitType.MILLIONS
	pres.save("Result.pptx", slides.export.SaveFormat.PPTX)
```

## **Часто задаваемые вопросы**

**Как установить значение, при котором одна ось пересекает другую (пересечение осей)?**

Оси предоставляют [параметр пересечения](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_type/): вы можете выбрать пересечение на нуле, на максимальной категории/значении или на конкретном числовом значении. Это полезно для сдвига оси X вверх или вниз или для выделения базовой линии.

**Как разместить подписи делений относительно оси (рядом, снаружи, внутри)?**

Установите [позицию подписи](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_tick_mark/) в "cross", "outside" или "inside". Это влияет на читаемость и помогает экономить место, особенно в небольших диаграммах.