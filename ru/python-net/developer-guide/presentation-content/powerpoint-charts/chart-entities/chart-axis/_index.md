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
- название оси
- положение оси
- PowerPoint
- OpenDocument
- презентация
- Python
- Aspose.Slides
description: "Узнайте, как использовать Aspose.Slides для Python через .NET, чтобы настраивать оси диаграмм в презентациях PowerPoint и OpenDocument для отчетов и визуализаций."
---

## **Получение максимальных значений на вертикальной оси диаграмм**
Aspose.Slides for Python via .NET позволяет получать минимальные и максимальные значения на вертикальной оси. Выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
2. Получите доступ к первому слайду.
3. Добавьте диаграмму с данными по умолчанию.
4. Получите фактическое максимальное значение оси.
5. Получите фактическое минимальное значение оси.
6. Получите фактическую основную единицу оси.
7. Получите фактическую вспомогательную единицу оси.
8. Получите фактический масштаб основной единицы оси.
9. Получите фактический масштаб вспомогательной единицы оси.

Этот пример кода — реализация перечисленных шагов — показывает, как получить требуемые значения в Python:

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
	
	# Сохраняет презентацию
	pres.save("ErrorBars_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Перемещение данных между осями**
Aspose.Slides позволяет быстро поменять местами данные между осями — данные, представленные на вертикальной оси (y‑axis), перемещаются на горизонтальную ось (x‑axis) и наоборот.

Этот Python‑код показывает, как выполнить задачу перемещения данных между осями диаграммы:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Создает пустую презентацию
with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 400, 300)

    #Меняет местами строки и столбцы
    chart.chart_data.switch_row_column()
            
    # Сохраняет презентацию
    pres.save("SwitchChartRowColumns_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Отключение вертикальной оси для линейных диаграмм**
Этот Python‑код показывает, как скрыть вертикальную ось для линейной диаграммы:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.LINE, 100, 100, 400, 300)
    chart.axes.vertical_axis.is_visible = False
    
    pres.save("chart-is_visible.pptx", slides.export.SaveFormat.PPTX)
```

## **Отключение горизонтальной оси для линейных диаграмм**
Этот код показывает, как скрыть горизонтальную ось для линейной диаграммы:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
 
with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.LINE, 100, 100, 400, 300)
    chart.axes.horizontal_axis.is_visible = False

    pres.save("chart-2.pptx", slides.export.SaveFormat.PPTX)
```

## **Изменение оси категорий**
Используя свойство **CategoryAxisType**, вы можете указать предпочтительный тип оси категорий (**date** или **text**). Этот код на Python демонстрирует операцию:

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
Aspose.Slides for Python via .NET позволяет установить формат даты для значения оси категорий. Операция показана в этом Python‑коде:

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

## **Установка угла вращения заголовка оси диаграммы**
Aspose.Slides for Python via .NET позволяет установить угол вращения заголовка оси диаграммы. Этот Python‑код демонстрирует операцию:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
    chart.axes.vertical_axis.has_title = True
    chart.axes.vertical_axis.title.text_format.text_block_format.rotation_angle = 90

    pres.save("test.pptx", slides.export.SaveFormat.PPTX)
```

## **Установка позиции оси в категории или значении оси**
Aspose.Slides for Python via .NET позволяет установить позицию оси в категории или значении оси. Этот Python‑код показывает, как выполнить задачу:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
	chart.axes.horizontal_axis.axis_between_categories = True

	pres.save("AsposeScatterChart.pptx", slides.export.SaveFormat.PPTX)
```

## **Включение подписи единицы отображения на оси значений диаграммы**
Aspose.Slides for Python via .NET позволяет настроить диаграмму так, чтобы на оси значений отображалась подпись единицы. Этот Python‑код демонстрирует операцию:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
	chart.axes.vertical_axis.display_unit = charts.DisplayUnitType.MILLIONS
	pres.save("Result.pptx", slides.export.SaveFormat.PPTX)
```

## **Часто задаваемые вопросы**

**Как задать значение, в котором одна ось пересекает другую (пересечение осей)?**

Оси предоставляют [настройку пересечения](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_type/): вы можете выбрать пересечение в нуле, на максимальной категории/значении или в конкретном числовом значении. Это полезно для смещения оси X вверх или вниз или для выделения базовой линии.

**Как разместить подписи делений относительно оси (внутри, снаружи, рядом)?**

Установите [позицию подписи](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_tick_mark/) в значение "cross", "outside" или "inside". Это влияет на читаемость и помогает сэкономить пространство, особенно на небольших диаграммах.