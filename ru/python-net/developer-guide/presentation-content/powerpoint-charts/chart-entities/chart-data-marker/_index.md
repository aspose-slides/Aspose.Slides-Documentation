---
title: Управление маркерами данных диаграммы в презентациях с помощью Python
linktitle: Маркер данных
type: docs
url: /ru/python-net/chart-data-marker/
keywords:
- диаграмма
- точка данных
- маркер
- параметры маркера
- размер маркера
- тип заливки
- PowerPoint
- OpenDocument
- презентация
- Python
- Aspose.Slides
description: "Узнайте, как настраивать маркеры данных диаграммы в Aspose.Slides, повышая влияние презентаций в форматах PPT, PPTX и ODP с помощью понятных примеров кода."
---

## **Задать параметры маркеров диаграммы**
Маркеры можно задавать для точек данных диаграммы внутри определенных серий. Чтобы задать параметры маркеров диаграммы, выполните следующие шаги:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
- Создайте диаграмму по умолчанию.
- Установите изображение.
- Возьмите первую серию диаграммы.
- Добавьте новую точку данных.
- Запишите презентацию на диск.

В приведённом ниже примере мы задали параметры маркеров диаграммы на уровне точек данных.
```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# Создать экземпляр класса Presentation
with slides.Presentation() as presentation:

    slide = presentation.slides[0]

    # Создание диаграммы по умолчанию
    chart = slide.shapes.add_chart(charts.ChartType.LINE_WITH_MARKERS, 0, 0, 400, 400)

    # Получение индекса листа данных диаграммы по умолчанию
    defaultWorksheetIndex = 0

    # Получение листа данных диаграммы
    fact = chart.chart_data.chart_data_workbook

    # Удалить демонстрационную серию
    chart.chart_data.series.clear()

    # Добавить новую серию
    chart.chart_data.series.add(fact.get_cell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.type)
            
    # Установить изображение
    image1 = draw.Bitmap(path + "aspose-logo.jpg")
    imgx1 = presentation.images.add_image(image1)

    # Установить изображение
    image2 = draw.Bitmap(path + "Tulips.jpg")
    imgx2 = presentation.images.add_image(image2)

    # Взять первую серию диаграммы
    series = chart.chart_data.series[0]

    # Добавить новую точку (1:3) туда.
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

    # Изменение маркера серии диаграммы
    series.marker.size = 15

    # Сохранить презентацию на диск
    presentation.save("MarkOptions_out.pptx", slides.export.SaveFormat.PPTX)
```


## **FAQ**

**Какие формы маркеров доступны сразу же?**

Доступны стандартные формы (круг, квадрат, ромб, треугольник и т.д.); список определяется перечислением [MarkerStyleType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/markerstyletype/). Если нужна нестандартная форма, используйте маркер с заполнением изображением, чтобы имитировать пользовательскую визуализацию.

**Сохраняются ли маркеры при экспорте диаграммы в изображение или SVG?**

Да. При рендеринге диаграмм в [растровые форматы](/slides/ru/python-net/convert-powerpoint-to-png/) или сохранении [форм как SVG](/slides/ru/python-net/render-a-slide-as-an-svg-image/), маркеры сохраняют свой внешний вид и настройки, включая размер, заливку и контур.