---
title: Линия тренда
type: docs
url: /ru/python-net/trend-line/
keywords: "Линия тренда, пользовательская линия PowerPoint презентация, Python, Aspose.Slides для Python через .NET"
description: "Добавьте линию тренда и пользовательскую линию в PowerPoint презентации с помощью Python"
---

## **Добавить линию тренда**
Aspose.Slides для Python через .NET предоставляет простой API для управления различными линиями тренда в графиках:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте график с данными по умолчанию и любого необходимого типа (в этом примере используется ChartType.CLUSTERED_COLUMN).
1. Добавление экспоненциальной линии тренда для серии графика 1.
1. Добавление линейной линии тренда для серии графика 1.
1. Добавление логарифмической линии тренда для серии графика 2.
1. Добавление линии тренда скользящей средней для серии графика 2.
1. Добавление полиномиальной линии тренда для серии графика 3.
1. Добавление степенной линии тренда для серии графика 3.
1. Запишите изменённую презентацию в файл PPTX.

Следующий код используется для создания графика с линиями тренда.

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# Создание пустой презентации
with slides.Presentation() as pres:

    # Создание кластерного столбчатого графика
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 400)

    # Добавление экспоненциальной линии тренда для серии графика 1
    tredLinep = chart.chart_data.series[0].trend_lines.add(charts.TrendlineType.EXPONENTIAL)
    tredLinep.display_equation = False
    tredLinep.display_r_squared_value = False

    # Добавление линейной линии тренда для серии графика 1
    tredLineLin = chart.chart_data.series[0].trend_lines.add(charts.TrendlineType.LINEAR)
    tredLineLin.trendline_type = charts.TrendlineType.LINEAR
    tredLineLin.format.line.fill_format.fill_type = slides.FillType.SOLID
    tredLineLin.format.line.fill_format.solid_fill_color.color = draw.Color.red


    # Добавление логарифмической линии тренда для серии графика 2
    tredLineLog = chart.chart_data.series[1].trend_lines.add(charts.TrendlineType.LOGARITHMIC)
    tredLineLog.trendline_type = charts.TrendlineType.LOGARITHMIC
    tredLineLog.add_text_frame_for_overriding("Новая логарифмическая линия тренда")

    # Добавление линии тренда скользящей средней для серии графика 2
    tredLineMovAvg = chart.chart_data.series[1].trend_lines.add(charts.TrendlineType.MOVING_AVERAGE)
    tredLineMovAvg.trendline_type = charts.TrendlineType.MOVING_AVERAGE
    tredLineMovAvg.period = 3
    tredLineMovAvg.trendline_name = "Новое имя линии тренда"

    # Добавление полиномиальной линии тренда для серии графика 3
    tredLinePol = chart.chart_data.series[2].trend_lines.add(charts.TrendlineType.POLYNOMIAL)
    tredLinePol.trendline_type = charts.TrendlineType.POLYNOMIAL
    tredLinePol.forward = 1
    tredLinePol.order = 3

    # Добавление степенной линии тренда для серии графика 3
    tredLinePower = chart.chart_data.series[1].trend_lines.add(charts.TrendlineType.POWER)
    tredLinePower.trendline_type = charts.TrendlineType.POWER
    tredLinePower.backward = 1

    # Сохранение презентации
    pres.save("Charttrend_lines_out.pptx", slides.export.SaveFormat.PPTX)
```



## **Добавить пользовательскую линию**
Aspose.Slides для Python через .NET предоставляет простой API для добавления пользовательских линий в график. Чтобы добавить простую линию к выбранному слайду презентации, выполните следующие шаги:

- Создайте экземпляр класса Presentation
- Получите ссылку на слайд, используя его индекс
- Создайте новый график, используя метод AddChart, предоставленный объектом Shapes
- Добавьте фигуру AutoShape типа Линия, используя метод AddAutoShape, предоставленный объектом Shapes
- Установите цвет линий фигуры.
- Запишите изменённую презентацию в файл PPTX

Следующий код используется для создания графика с пользовательскими линиями.

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 500, 400)
    shape = chart.user_shapes.shapes.add_auto_shape(slides.ShapeType.LINE, 0, chart.height / 2, chart.width, 0)
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.red
    pres.save("AddCustomLines.pptx", slides.export.SaveFormat.PPTX)
```