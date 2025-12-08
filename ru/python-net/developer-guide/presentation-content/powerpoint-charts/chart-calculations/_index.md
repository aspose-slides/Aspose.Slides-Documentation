---
title: Оптимизация вычислений диаграмм для презентаций на Python
linktitle: Вычисления диаграмм
type: docs
weight: 50
url: /ru/python-net/chart-calculations/
keywords:
- вычисления диаграмм
- элементы диаграмм
- позиция элемента
- фактическая позиция
- дочерний элемент
- родительский элемент
- значения диаграммы
- фактическое значение
- PowerPoint
- OpenDocument
- презентация
- Python
- Aspose.Slides
description: "Поймите вычисления диаграмм, обновление данных и контроль точности в Aspose.Slides for Python via .NET для PPT, PPTX и ODP, с практическими примерами кода."
---

## **Вычисление фактических значений элементов диаграммы**
Aspose.Slides for Python via .NET предоставляет простой API для получения этих свойств. Это поможет вам вычислять фактические значения элементов диаграммы. Фактические значения включают позицию элементов, реализующих интерфейс IActualLayout (IActualLayout.ActualX, IActualLayout.ActualY, IActualLayout.ActualWidth, IActualLayout.ActualHeight) и фактические значения осей (IAxis.ActualMaxValue, IAxis.ActualMinValue, IAxis.ActualMajorUnit, IAxis.ActualMinorUnit, IAxis.ActualMajorUnitScale, IAxis.ActualMinorUnitScale).
```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 500, 350)
    chart.validate_chart_layout()

    maxValue = chart.axes.vertical_axis.actual_max_value
    minValue = chart.axes.vertical_axis.actual_min_value
    majorUnit = chart.axes.horizontal_axis.actual_major_unit
    minorUnit = chart.axes.horizontal_axis.actual_minor_unit
```


## **Вычисление фактической позиции родительских элементов диаграммы**
Aspose.Slides for Python via .NET предоставляет простой API для получения этих свойств. Свойства IActualLayout предоставляют информацию о фактической позиции родительского элемента диаграммы. Необходимо предварительно вызвать метод IChart.ValidateChartLayout(), чтобы заполнить свойства фактическими значениями.
```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 500, 350)
    chart.validate_chart_layout()

    x = chart.plot_area.actual_x
    y = chart.plot_area.actual_y
    w = chart.plot_area.actual_width
    h = chart.plot_area.actual_height
```


## **Скрыть информацию в диаграмме**
Эта статья помогает понять, как скрыть информацию на диаграмме. С помощью Aspose.Slides for Python via .NET вы можете скрыть **Заголовок, Вертикальная ось, Горизонтальная ось** и **Линии сетки** на диаграмме. Ниже приведён пример кода, показывающий, как использовать эти свойства.
```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    slide = pres.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.LINE_WITH_MARKERS, 140, 118, 320, 370)

    # Скрытие заголовка диаграммы
    chart.has_title = False

    # Скрытие оси значений
    chart.axes.vertical_axis.is_visible = False

    # Видимость оси категорий
    chart.axes.horizontal_axis.is_visible = False

    # Скрытие легенды
    chart.has_legend = False

    # Скрытие основных линий сетки
    chart.axes.horizontal_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.NO_FILL

    #for i in range(len(chart.chart_data.series)):
    #    chart.chart_data.series.remove_at(i)

    series = chart.chart_data.series[0]

    series.marker.symbol = charts.MarkerStyleType.CIRCLE
    series.labels.default_data_label_format.show_value = True
    series.labels.default_data_label_format.position = charts.LegendDataLabelPosition.TOP
    series.marker.size = 15

    # Установка цвета линии серии
    series.format.line.fill_format.fill_type = slides.FillType.SOLID
    series.format.line.fill_format.solid_fill_color.color = draw.Color.purple
    series.format.line.dash_style = slides.LineDashStyle.SOLID

    pres.save("HideInformationFromChart.pptx", slides.export.SaveFormat.PPTX)
```


## **FAQ**

**Можно ли использовать внешние книги Excel в качестве источника данных и как это влияет на перерасчёт?**

Да. Диаграмма может ссылаться на внешнюю книгу: при подключении или обновлении внешнего источника формулы и значения берутся из этой книги, и диаграмма отображает изменения во время операций открытия/редактирования. API позволяет вам [указать путь к внешней книге](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/) и управлять связанными данными.

**Могу ли я вычислять и отображать линии тренда без самостоятельной реализации регрессии?**

Да. [Линии тренда](/slides/ru/python-net/trend-line/) (линейные, экспоненциальные и другие) добавляются и обновляются Aspose.Slides; их параметры автоматически пересчитываются из данных сериалов, поэтому вам не нужно реализовывать собственные расчёты.

**Если презентация содержит несколько диаграмм с внешними ссылками, могу ли я управлять тем, какую книгу каждая диаграмма использует для вычисляемых значений?**

Да. Каждая диаграмма может указывать на свою собственную [внешнюю книгу](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/), либо вы можете создать/заменить внешнюю книгу для каждой диаграммы независимо от остальных.