---
title: Добавление линий тренда к диаграммам презентаций в Python
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
description: "Быстро добавляйте и настраивайте линии тренда в диаграммах PowerPoint и OpenDocument с помощью Aspose.Slides for Python via .NET — практическое руководство и примеры кода для повышения точности прогнозирования и привлечения вашей аудитории."
---

## **Добавление линии тренда**
Aspose.Slides for Python via .NET предоставляет простой API для управления различными линиями тренда диаграмм:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Получите ссылку на слайд по его индексу.
3. Добавьте диаграмму с данными по умолчанию и выбранным типом (в этом примере используется ChartType.CLUSTERED_COLUMN).
4. Добавление экспоненциальной линии тренда для серии 1 диаграммы.
5. Добавление линейной линии тренда для серии 1 диаграммы.
6. Добавление логарифмической линии тренда для серии 2 диаграммы.
7. Добавление линии тренда скользящего среднего для серии 2 диаграммы.
8. Добавление полиномиальной линии тренда для серии 3 диаграммы.
9. Добавление степенной линии тренда для серии 3 диаграммы.
10. Запишите изменённую презентацию в файл PPTX.

Следующий код используется для создания диаграммы с линиями тренда.

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# Создание пустой презентации
with slides.Presentation() as pres:

    # Создание диаграммы с группированными столбцами
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

## **Добавление пользовательской линии**
Aspose.Slides for Python via .NET предоставляет простой API для добавления пользовательских линий в диаграмму. Чтобы добавить простую сплошную линию на выбранный слайд презентации, выполните следующие шаги:

- Создайте экземпляр класса Presentation
- Получите ссылку на слайд, используя его индекс
- Создайте новую диаграмму с помощью метода AddChart объекта Shapes
- Добавьте AutoShape типа Line с помощью метода AddAutoShape объекта Shapes
- Установите цвет линий фигуры.
- Запишите изменённую презентацию в файл PPTX

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

**Что означают 'forward' и 'backward' для линии тренда?**

Это длина линии тренда, проецируемой вперёд/назад: для точечных (XY) диаграмм — в единицах осей; для недиаграмм точек — в количестве категорий. Допускаются только неотрицательные значения.

**Будет ли линия тренда сохраняться при экспорте презентации в PDF или SVG, или при рендеринге слайда в изображение?**

Да. Aspose.Slides преобразует презентации в [PDF](/slides/ru/python-net/convert-powerpoint-to-pdf/)/[SVG](/slides/ru/python-net/render-a-slide-as-an-svg-image/) и рендерит диаграммы в изображения; линии тренда, как часть диаграммы, сохраняются во время этих операций. Также доступен метод для [экспорта изображения диаграммы](/slides/ru/python-net/create-shape-thumbnails/).