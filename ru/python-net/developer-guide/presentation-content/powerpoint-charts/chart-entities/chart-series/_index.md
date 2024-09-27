---
title: Серия графиков
type: docs
url: /ru/python-net/chart-series/
keywords: "Серии графиков, цвет серий, презентация PowerPoint, Python, Aspose.Slides для Python через .NET"
description: "Серии графиков в презентациях PowerPoint на Python"
---

Серия — это строка или столбец чисел, отображаемых на графике.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Установить наложение серий графиков**

С помощью свойства [IChartSeriesOverlap](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartseries/) вы можете задать, насколько должны перекрываться столбцы и бары на 2D-графике (диапазон: -100 до 100). Это свойство применяется ко всем сериям родительской группы серий: это проекция соответствующего свойства группы. Поэтому это свойство является только для чтения.

Используйте свойство `parent_series_group.overlap` для чтения/записи, чтобы установить ваше предпочтительное значение для `overlap`.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Добавьте кластерный столбчатый график на слайде.
1. Получите доступ к первой серии графика.
1. Получите доступ к `parent_series_group` серии графика и установите ваше предпочтительное значение наложения для серии.
1. Запишите измененную презентацию в файл PPTX.

Этот код на Python демонстрирует, как установить наложение для серии графиков:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
    # Добавляет график
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400, True)
    series = chart.chart_data.series
    if series[0].overlap == 0:
        # Устанавливает наложение серии
        series[0].parent_series_group.overlap = -30

    # Записывает файл презентации на диск
    presentation.save("SetChartSeriesOverlap_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Изменение цвета серии**
Aspose.Slides для Python через .NET позволяет вам изменить цвет серии следующим образом:

1. Создайте экземпляр класса `Presentation`.
1. Добавьте график на слайде.
1. Получите доступ к серии, цвет которой вы хотите изменить.
1. Установите ваш предпочтительный тип заливки и цвет заливки.
1. Сохраните изменённую презентацию.

Этот код на Python демонстрирует, как изменить цвет серии:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.PIE, 50, 50, 600, 400)
    point = chart.chart_data.series[0].data_points[1]
    
    point.explosion = 30
    point.format.fill.fill_type = slides.FillType.SOLID
    point.format.fill.solid_fill_color.color = draw.Color.blue

    pres.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Изменение цвета категории серии**
Aspose.Slides для Python через .NET позволяет вам изменить цвет категории серии следующим образом:

1. Создайте экземпляр класса `Presentation`.
1. Добавьте график на слайде.
1. Получите доступ к категории серии, цвет которой вы хотите изменить.
1. Установите ваш предпочтительный тип заливки и цвет заливки.
1. Сохраните изменённую презентацию.

Этот код на Python демонстрирует, как изменить цвет категории серии:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
    point = chart.chart_data.series[0].data_points[0]
    
    point.format.fill.fill_type = slides.FillType.SOLID
    point.format.fill.solid_fill_color.color = draw.Color.blue

    pres.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Изменение имени серии** 

По умолчанию имена в легенде для графика являются содержимым ячеек, расположенных над каждым столбцом или строкой данных.

В нашем примере (образец изображения):

* столбцы это *Серия 1, Серия 2, Серия 3*;
* строки это *Категория 1, Категория 2, Категория 3,* и *Категория 4.* 

Aspose.Slides для Python через .NET позволяет вам обновить или изменить имя серии в её данных графика и легенде. 

Этот код на Python демонстрирует, как изменить имя серии в данных графика `ChartDataWorkbook`:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.COLUMN_3D, 50, 50, 600, 400, True)
    
    seriesCell = chart.chart_data.chart_data_workbook.get_cell(0, 0, 1)
    seriesCell.value = "Новое имя"
    
    pres.save("pres.pptx", slides.export.SaveFormat.PPTX)
```

Этот код на Python демонстрирует, как изменить имя серии в её легенде через `Series`:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.COLUMN_3D, 50, 50, 600, 400, True)
    series = chart.chart_data.series[0]
    
    series.name.as_cells[0].value = "Новое имя"

    pres.save("pres.pptx", slides.export.SaveFormat.PPTX) 
```

## **Установить цвет заливки серии графиков**

Aspose.Slides для Python через .NET позволяет вам установить автоматический цвет заливки для серий графиков внутри области построения следующим образом:

1. Создайте экземпляр класса `Presentation`.
2. Получите ссылку на слайд по его индексу.
3. Добавьте график с данными по умолчанию в зависимости от вашего предпочтительного типа (в приведённом ниже примере мы использовали `ChartType.CLUSTERED_COLUMN`).
4. Получите доступ к сериям графиков и установите цвет заливки на автоматический.
5. Сохраните презентацию в файл PPTX.

Этот код на Python демонстрирует, как установить автоматический цвет заливки для серии графиков:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
    # Создаёт кластерный столбчатый график
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 50, 600, 400)

    # Устанавливает формат заливки серии на автоматический
    for i in range(len(chart.chart_data.series)):
        chart.chart_data.series[i].get_automatic_series_color()

    # Записывает файл презентации на диск
    presentation.save("AutoFillSeries_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Установить цвет заливки серий с инвертированием**
Aspose.Slides позволяет установить цвет заливки серий с инвертированием внутри области построения следующим образом:

1. Создайте экземпляр класса `Presentation`.
2. Получите ссылку на слайд по его индексу.
3. Добавьте график с данными по умолчанию в зависимости от вашего предпочтительного типа (в приведённом ниже примере мы использовали `ChartType.CLUSTERED_COLUMN`).
4. Получите доступ к сериям графиков и установите цвет заливки на инвертированный.
5. Сохраните презентацию в файл PPTX.

Этот код на Python демонстрирует операцию:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 400, 300)
    workBook = chart.chart_data.chart_data_workbook

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    # Добавляет новые серии и категории
    chart.chart_data.series.add(workBook.get_cell(0, 0, 1, "Серия 1"), chart.type)
    chart.chart_data.categories.add(workBook.get_cell(0, 1, 0, "Категория 1"))
    chart.chart_data.categories.add(workBook.get_cell(0, 2, 0, "Категория 2"))
    chart.chart_data.categories.add(workBook.get_cell(0, 3, 0, "Категория 3"))

    # Берёт первую серию графиков и заполняет её данные.
    series = chart.chart_data.series[0]
    series.data_points.add_data_point_for_bar_series(workBook.get_cell(0, 1, 1, -20))
    series.data_points.add_data_point_for_bar_series(workBook.get_cell(0, 2, 1, 50))
    series.data_points.add_data_point_for_bar_series(workBook.get_cell(0, 3, 1, -30))
    seriesColor = series.get_automatic_series_color()
    series.invert_if_negative = True
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = seriesColor
    series.inverted_solid_fill_color.color = draw.Color.red
    pres.save("SetInvertFillColorChart_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Установить инверсию серий, когда значение отрицательное**
Aspose.Slides позволяет вам установить инверсию с помощью свойства `ChartDataPoint.invert_if_negative`. Когда инверсия установлена с помощью свойств, точка данных инвертирует свои цвета, когда получает отрицательное значение. 

Этот код на Python демонстрирует операцию:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400, True)
    series = chart.chart_data.series
    chart.chart_data.series.clear()

    series.add(chart.chart_data.chart_data_workbook.get_cell(0, "B1"), chart.type)
    series[0].data_points.add_data_point_for_bar_series(chart.chart_data.chart_data_workbook.get_cell(0, "B2", -5))
    series[0].data_points.add_data_point_for_bar_series(chart.chart_data.chart_data_workbook.get_cell(0, "B3", 3))
    series[0].data_points.add_data_point_for_bar_series(chart.chart_data.chart_data_workbook.get_cell(0, "B4", -2))
    series[0].data_points.add_data_point_for_bar_series(chart.chart_data.chart_data_workbook.get_cell(0, "B5", 1))

    series[0].invert_if_negative = False

    series[0].data_points[2].invert_if_negative = True

    pres.save("out.pptx", slides.export.SaveFormat.PPTX)
```

## **Очистить данные конкретных точек данных**
Aspose.Slides для Python через .NET позволяет вам очистить данные `data_points` для конкретной серии графиков следующим образом:

1. Создайте экземпляр класса `Presentation`.
2. Получите ссылку на слайд по его индексу.
3. Получите ссылку на график по его индексу.
4. Пройдите через все `data_points` графика и установите `x_value` и `y_value` в null.
5. Очистите все `data_points` для конкретной серии графиков.
6. Запишите изменённую презентацию в файл PPTX.

Этот код на Python демонстрирует операцию:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation(path + "TestChart.pptx") as pres:
    sl = pres.slides[0]
    chart = sl.shapes[0]

    for dataPoint in chart.chart_data.series[0].data_points:
        dataPoint.x_value.as_cell.value = None
        dataPoint.y_value.as_cell.value = None

    chart.chart_data.series[0].data_points.clear()

    pres.save("ClearSpecificChartSeriesDataPointsData.pptx", slides.export.SaveFormat.PPTX)
```

## **Установить ширину промежутков серий**
Aspose.Slides для Python через .NET позволяет вам установить ширину промежутков для серии с помощью свойства **`gap_width`** следующим образом:

1. Создайте экземпляр класса `Presentation`.
2. Получите доступ к первому слайду.
3. Добавьте график с данными по умолчанию.
4. Получите доступ к любой серии графиков.
5. Установите свойство `gap_width`.
6. Запишите изменённую презентацию в файл PPTX.

Этот код на Python демонстрирует, как установить ширину промежутков для серии:

```py
# Создаёт пустую презентацию 
with slides.Presentation() as presentation:

    # Получает первый слайд презентации
    slide = presentation.slides[0]

    # Добавляет график с данными по умолчанию
    chart = slide.shapes.add_chart(charts.ChartType.STACKED_COLUMN, 0, 0, 500, 500)

    # Устанавливает индекс рабочего листа графика
    defaultWorksheetIndex = 0

    # Получает рабочий лист данных графика
    fact = chart.chart_data.chart_data_workbook

    # Добавляет серии
    chart.chart_data.series.add(fact.get_cell(defaultWorksheetIndex, 0, 1, "Серия 1"), chart.type)
    chart.chart_data.series.add(fact.get_cell(defaultWorksheetIndex, 0, 2, "Серия 2"), chart.type)

    # Добавляет категории
    chart.chart_data.categories.add(fact.get_cell(defaultWorksheetIndex, 1, 0, "Категория 1"))
    chart.chart_data.categories.add(fact.get_cell(defaultWorksheetIndex, 2, 0, "Категория 2"))
    chart.chart_data.categories.add(fact.get_cell(defaultWorksheetIndex, 3, 0, "Категория 3"))

    # Берёт вторую серию графиков
    series = chart.chart_data.series[1]

    # Заполняет данные серии
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 1, 1, 20))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 2, 1, 50))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 3, 1, 30))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 1, 2, 30))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 2, 2, 10))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 3, 2, 60))

    # Устанавливает значение GapWidth
    series.parent_series_group.gap_width = 50

    # Сохраняет презентацию на диск
    presentation.save("GapWidth_out.pptx", slides.export.SaveFormat.PPTX)
```