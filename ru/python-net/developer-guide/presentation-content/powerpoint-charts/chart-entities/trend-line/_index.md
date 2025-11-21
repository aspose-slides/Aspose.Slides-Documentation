---
title: Добавить линии тренда к диаграммам презентации на Python
linktitle: Линия тренда
type: docs
url: /ru/python-net/trend-line/
keywords:
- диаграмма
- линия тренда
- экспоненциальная линия тренда
- линейная линия тренда
- логарифмическая линия тренда
- линия тренда скользящего среднего
- полиномиальная линия тренда
- степенная линия тренда
- пользовательская линия тренда
- PowerPoint
- OpenDocument
- презентация
- Python
- Aspose.Slides
description: "Быстро добавляйте и настраивайте линии тренда в диаграммах PowerPoint и OpenDocument с помощью Aspose.Slides for Python via .NET — практическое руководство и примеры кода для повышения точности прогнозов и привлечения вашей аудитории."
---

## **Добавить линию тренда**
Aspose.Slides for Python via .NET предоставляет простой API для управления различными линиями тренда диаграмм:

1. Создать экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Получить ссылку на слайд по его индексу.
1. Добавить диаграмму с данными по умолчанию и нужным типом (в примере используется ChartType.CLUSTERED_COLUMN).
1. Добавить экспоненциальную линию тренда для ряда диаграммы 1.
1. Добавить линейную линию тренда для ряда диаграммы 1.
1. Добавить логарифмическую линию тренда для ряда диаграммы 2.
1. Добавить линию скользящего среднего для ряда диаграммы 2.
1. Добавить полиномиальную линию тренда для ряда диаграммы 3.
1. Добавить степень линии тренда для ряда диаграммы 3.
1. Сохранить изменённую презентацию в файл PPTX.

Следующий код используется для создания диаграммы с линиями тренда.
```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# Создание пустой презентации
with slides.Presentation() as pres:

    # Создание диаграммы сгруппированных столбцов
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 400)

    # Добавление экспоненциальной линии тренда для серии 1 диаграммы
    tredLinep = chart.chart_data.series[0].trend_lines.add(charts.TrendlineType.EXPONENTIAL)
    tredLinep.display_equation = False
    tredLinep.display_r_squared_value = False

    # Добавление линейной линии тренда для серии 1 диаграммы
    tredLineLin = chart.chart_data.series[0].trend_lines.add(charts.TrendlineType.LINEAR)
    tredLineLin.trendline_type = charts.TrendlineType.LINEAR
    tredLineLin.format.line.fill_format.fill_type = slides.FillType.SOLID
    tredLineLin.format.line.fill_format.solid_fill_color.color = draw.Color.red


    # Добавление логарифмической линии тренда для серии 2 диаграммы
    tredLineLog = chart.chart_data.series[1].trend_lines.add(charts.TrendlineType.LOGARITHMIC)
    tredLineLog.trendline_type = charts.TrendlineType.LOGARITHMIC
    tredLineLog.add_text_frame_for_overriding("New log trend line")

    # Добавление линии тренда скользящего среднего для серии 2 диаграммы
    tredLineMovAvg = chart.chart_data.series[1].trend_lines.add(charts.TrendlineType.MOVING_AVERAGE)
    tredLineMovAvg.trendline_type = charts.TrendlineType.MOVING_AVERAGE
    tredLineMovAvg.period = 3
    tredLineMovAvg.trendline_name = "New TrendLine Name"

    # Добавление полиномиальной линии тренда для серии 3 диаграммы
    tredLinePol = chart.chart_data.series[2].trend_lines.add(charts.TrendlineType.POLYNOMIAL)
    tredLinePol.trendline_type = charts.TrendlineType.POLYNOMIAL
    tredLinePol.forward = 1
    tredLinePol.order = 3

    # Добавление степенной линии тренда для серии 3 диаграммы
    tredLinePower = chart.chart_data.series[1].trend_lines.add(charts.TrendlineType.POWER)
    tredLinePower.trendline_type = charts.TrendlineType.POWER
    tredLinePower.backward = 1

    # Сохранение презентации
    pres.save("Charttrend_lines_out.pptx", slides.export.SaveFormat.PPTX)
```




## **Добавить пользовательскую линию**
Aspose.Slides for Python via .NET предоставляет простой API для добавления пользовательских линий в диаграмму. Чтобы добавить простую сплошную линию на выбранный слайд презентации, выполните следующие действия:

- Создать экземпляр класса Presentation
- Получить ссылку на слайд, используя его Index
- Создать новую диаграмму с помощью метода AddChart объекта Shapes
- Добавить AutoShape типа Line с помощью метода AddAutoShape объекта Shapes
- Установить цвет линий фигуры.
- Сохранить изменённую презентацию в файл PPTX

Следующий код используется для создания диаграммы с пользовательскими линиями.
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


## **FAQ**

**Что означают параметры «forward» и «backward» для линии тренда?**

Это длина линии тренда, проецируемой вперёд/назад: для диаграмм рассеяния (XY) — в единицах осей; для недисперсионных диаграмм — в количестве категорий. Допустимы только неотрицательные значения.

**Сохранится ли линия тренда при экспорте презентации в PDF или SVG, либо при рендеринге слайда в изображение?**

Да. Aspose.Slides конвертирует презентации в [PDF](/slides/ru/python-net/convert-powerpoint-to-pdf/)/[SVG](/slides/ru/python-net/render-a-slide-as-an-svg-image/) и рендерит диаграммы в изображения; линии тренда, как часть диаграммы, сохраняются при этих операциях. Также доступен метод для [экспорта изображения самой диаграммы](/slides/ru/python-net/create-shape-thumbnails/).