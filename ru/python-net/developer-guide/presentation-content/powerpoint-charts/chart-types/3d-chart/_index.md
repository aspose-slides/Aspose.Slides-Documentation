---
title: 3D Диаграмма
type: docs
url: /ru/python-net/3d-chart/
keywords: "3d диаграмма, rotationX, rotationY, depthpercent, презентация PowerPoint, Python, Aspose.Slides для Python через .NET"
description: "Установите rotationX, rotationY и depthpercents для 3D диаграммы в презентации PowerPoint на Python"
---

## **Установка свойств RotationX, RotationY и DepthPercents для 3D Диаграммы**
Aspose.Slides для Python через .NET предоставляет простой API для установки этих свойств. Эта статья поможет вам узнать, как установить различные свойства, такие как X, Y вращение, **DepthPercents** и т.д. Пример кода применяет установку вышеуказанных свойств.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Получите первый слайд.
1. Добавьте диаграмму с данными по умолчанию.
1. Установите свойства Rotation3D.
1. Запишите измененную презентацию в файл PPTX.

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# Создайте экземпляр класса Presentation
with slides.Presentation() as presentation:
            
    # Получите первый слайд
    slide = presentation.slides[0]

    # Добавьте диаграмму с данными по умолчанию
    chart = slide.shapes.add_chart(charts.ChartType.STACKED_COLUMN_3D, 0, 0, 500, 500)

    # Установка индекса таблицы данных диаграммы
    defaultWorksheetIndex = 0

    # Получение таблицы данных диаграммы
    fact = chart.chart_data.chart_data_workbook

    # Добавьте серии
    chart.chart_data.series.add(fact.get_cell(defaultWorksheetIndex, 0, 1, "Серия 1"), chart.type)
    chart.chart_data.series.add(fact.get_cell(defaultWorksheetIndex, 0, 2, "Серия 2"), chart.type)

    # Добавьте категории
    chart.chart_data.categories.add(fact.get_cell(defaultWorksheetIndex, 1, 0, "Категория 1"))
    chart.chart_data.categories.add(fact.get_cell(defaultWorksheetIndex, 2, 0, "Категория 2"))
    chart.chart_data.categories.add(fact.get_cell(defaultWorksheetIndex, 3, 0, "Категория 3"))

    # Установите свойства Rotation3D
    chart.rotation_3d.right_angle_axes = True
    chart.rotation_3d.rotation_x = 40
    chart.rotation_3d.rotation_y = 270
    chart.rotation_3d.depth_percents = 150

    # Возьмите вторую серию диаграммы
    series = chart.chart_data.series[1]

    # Теперь заполняем данные серии
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 1, 1, 20))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 2, 1, 50))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 3, 1, 30))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 1, 2, 30))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 2, 2, 10))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 3, 2, 60))

    # Установите значение OverLap
    series.parent_series_group.overlap = 100         

    # Запишите презентацию на диск
    presentation.save("Rotation3D_out.pptx", slides.export.SaveFormat.PPTX)
```