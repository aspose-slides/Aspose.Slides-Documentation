---
title: Настройка 3D‑диаграмм в презентациях с помощью Python
linktitle: 3D‑диаграмма
type: docs
url: /ru/python-net/3d-chart/
keywords:
- 3D‑диаграмма
- вращение
- глубина
- PowerPoint
- OpenDocument
- презентация
- Python
- Aspose.Slides
description: "Узнайте, как создавать и настраивать 3‑D‑диаграммы в Aspose.Slides for Python via .NET, с поддержкой файлов PPT, PPTX и ODP — улучшите свои презентации уже сегодня."
---

## **Установите свойства RotationX, RotationY и DepthPercents 3D‑диаграммы**
Aspose.Slides for Python via .NET предоставляет простой API для установки этих свойств. В этой статье объясняется, как установить различные свойства, такие как вращение по X и Y, **DepthPercents** и т.д. Пример кода демонстрирует установку перечисленных выше свойств.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Получите доступ к первому слайду.
3. Добавьте диаграмму с данными по умолчанию.
4. Установите свойства Rotation3D.
5. Запишите изменённую презентацию в файл PPTX.
```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# Создать экземпляр класса Presentation
with slides.Presentation() as presentation:
            
    # Получить доступ к первому слайду
    slide = presentation.slides[0]

    # Добавить диаграмму с данными по умолчанию
    chart = slide.shapes.add_chart(charts.ChartType.STACKED_COLUMN_3D, 0, 0, 500, 500)

    # Установка индекса листа данных диаграммы
    defaultWorksheetIndex = 0

    # Получение листа данных диаграммы
    fact = chart.chart_data.chart_data_workbook

    # Добавить серии
    chart.chart_data.series.add(fact.get_cell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.type)
    chart.chart_data.series.add(fact.get_cell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.type)

    # Добавить категории
    chart.chart_data.categories.add(fact.get_cell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"))
    chart.chart_data.categories.add(fact.get_cell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"))
    chart.chart_data.categories.add(fact.get_cell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"))

    # Установить свойства Rotation3D
    chart.rotation_3d.right_angle_axes = True
    chart.rotation_3d.rotation_x = 40
    chart.rotation_3d.rotation_y = 270
    chart.rotation_3d.depth_percents = 150

    # Выбрать вторую серию диаграммы
    series = chart.chart_data.series[1]

    # Сейчас заполняем данные серии
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 1, 1, 20))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 2, 1, 50))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 3, 1, 30))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 1, 2, 30))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 2, 2, 10))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 3, 2, 60))

    # Установить значение OverLap
    series.parent_series_group.overlap = 100         

    # Сохранить презентацию на диск
    presentation.save("Rotation3D_out.pptx", slides.export.SaveFormat.PPTX)
```


## **FAQ**

**Какие типы диаграмм поддерживают 3D‑режим в Aspose.Slides?**

Aspose.Slides поддерживает 3D‑варианты столбчатых диаграмм, включая Column 3D, Clustered Column 3D, Stacked Column 3D и 100 % Stacked Column 3D, а также связанные 3D‑типы, доступные через перечисление [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/). Чтобы получить точный актуальный список, проверьте элементы перечисления [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) в справочнике API установленной версии.

**Можно ли получить растровое изображение 3D‑диаграммы для отчёта или веба?**

Да. Вы можете экспортировать диаграмму в изображение с помощью [chart API](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/get_image/) или [отрисовать весь слайд](/slides/ru/python-net/convert-powerpoint-to-png/) в такие форматы, как PNG или JPEG. Это удобно, когда нужен пиксельно‑точный предварительный просмотр или требуется вставить диаграмму в документы, панели мониторинга или веб‑страницы без необходимости использовать PowerPoint.

**Насколько производительно создание и рендеринг больших 3D‑диаграмм?**

Производительность зависит от объёма данных и визуальной сложности. Для получения наилучших результатов минимизируйте 3D‑эффекты, избегайте тяжёлых текстур на стенах и областях построения, по возможности ограничьте количество точек данных в серии и рендерите в вывод подходящего размера (разрешения и размеров), соответствующего целевому дисплею или печати.