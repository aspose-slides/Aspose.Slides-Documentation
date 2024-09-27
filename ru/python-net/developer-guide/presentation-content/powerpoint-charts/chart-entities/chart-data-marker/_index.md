---
title: Маркеры данных графика
type: docs
url: /ru/python-net/chart-data-marker/
keywords: "Опции маркеров графиков, Презентация PowerPoint, Python, Aspose.Slides для Python через .NET"
description: "Настройка параметров маркеров графиков в презентациях PowerPoint на Python"
---

## **Настройка параметров маркеров графиков**
Маркеры можно установить на точки данных графика внутри конкретных серий. Для настройки параметров маркеров графиков выполните следующие шаги:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
- Создайте график по умолчанию.
- Установите изображение.
- Получите первую серию графика.
- Добавьте новую точку данных.
- Запишите презентацию на диск.

В приведенном ниже примере мы установили параметры маркеров графиков на уровне точек данных.

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# Создайте экземпляр класса Presentation
with slides.Presentation() as presentation:

    slide = presentation.slides[0]

    # Создание графика по умолчанию
    chart = slide.shapes.add_chart(charts.ChartType.LINE_WITH_MARKERS, 0, 0, 400, 400)

    # Получение индекса рабочего листа данных графика по умолчанию
    defaultWorksheetIndex = 0

    # Получение рабочего листа данных графика
    fact = chart.chart_data.chart_data_workbook

    # Удаление демонстрационных серий
    chart.chart_data.series.clear()

    # Добавление новой серии
    chart.chart_data.series.add(fact.get_cell(defaultWorksheetIndex, 1, 1, "Серия 1"), chart.type)
            
    # Установка изображения
    image1 = draw.Bitmap(path + "aspose-logo.jpg")
    imgx1 = presentation.images.add_image(image1)

    # Установка изображения
    image2 = draw.Bitmap(path + "Tulips.jpg")
    imgx2 = presentation.images.add_image(image2)

    # Получение первой серии графика
    series = chart.chart_data.series[0]

    # Добавление новой точки (1:3) туда.
    point = series.data_points.add_data_point_for_line_series(fact.get_cell(defaultWorksheetIndex, 1, 1, 4.5))
    point.marker.format.fill.fill_type = slides.FillType.PICTURE
    point.marker.format.fill.picture_fill_format.picture.image = imgx1

    point = series.data_points.add_data_point_for_line_series(fact.get_cell(defaultWorksheetIndex, 2, 1, 2.5))
    point.marker.format.fill.fill_type = slides.FillType.PICTURE
    point.marker.format.fill.picture_fill_format.picture.image = imgx2

    point = series.data_points.add_data_point_for_line_series(fact.get_cell(defaultWorksheetIndex, 3, 1, 3.5))
    point.marker.format.fill.fill_type = slides.FillType.PICTURE
    point.marker.format.fill.picture_fill_format.picture.image = imgx1

    point = series.data_points.add_data_point_for_line_series(fact.get_cell(defaultWorksheetIndex, 4, 1, 4.5))
    point.marker.format.fill.fill_type = slides.FillType.PICTURE
    point.marker.format.fill.picture_fill_format.picture.image = imgx2

    # Изменение размера маркера серии графика
    series.marker.size = 15

    # Запись презентации на диск
    presentation.save("MarkOptions_out.pptx", slides.export.SaveFormat.PPTX)
```