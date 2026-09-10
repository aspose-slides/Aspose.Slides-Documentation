---
title: Настройка 3D диаграмм в презентациях с использованием Python
linktitle: 3D Диаграмма
type: docs
url: /ru/python-java/3d-chart/
keywords:
- 3D диаграмма
- вращение
- глубина
- PowerPoint
- презентация
- Python
- Java
- Aspose.Slides
description: "Узнайте, как создавать и настраивать 3‑D диаграммы в Aspose.Slides для Python via Java, с поддержкой файлов PPT и PPTX — улучшите свои презентации уже сегодня."
---
## **Обзор**

Эта статья объясняет, как настроить 3D‑диаграмму в Aspose.Slides, конфигурируя параметры [Rotation3D](https://reference.aspose.com/slides/ru/python-java/aspose.slides/rotation3d/) такие как [setRotationX](https://reference.aspose.com/slides/ru/python-java/aspose.slides/rotation3d/#setRotationX), [setRotationY](https://reference.aspose.com/slides/ru/python-java/aspose.slides/rotation3d/#setRotationY), [setDepthPercents](https://reference.aspose.com/slides/ru/python-java/aspose.slides/rotation3d/#setDepthPercents) и [setRightAngleAxes](https://reference.aspose.com/slides/ru/python-java/aspose.slides/rotation3d/#setRightAngleAxes). В ней показано создание презентации, добавление 3D‑диаграммы с данными по умолчанию, применение необходимых настроек 3D‑вида и сохранение изменённой презентации в файл PPTX.

## **Установка вращения по X, вращения по Y и глубины 3D‑диаграммы**
Aspose.Slides for Python via Java предоставляет простой API для задания этих свойств. Ниже приведён пример, показывающий, как установить вращение по X, вращение по Y и глубину 3D‑диаграммы.

1. Создать экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/).
1. Получить доступ к первому слайду.
1. Добавить диаграмму с данными по умолчанию.
1. Установить свойства 3D‑вращения.
1. Записать изменённую презентацию в файл PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    # Доступ к первому слайду.
    slide = presentation.getSlides().get_Item(0)

    # Добавить диаграмму с данными по умолчанию.
    chart = slide.getShapes().addChart(ChartType.StackedColumn3D, 0, 0, 500, 500)

    # Установить индекс листа данных диаграммы.
    default_worksheet_index = 0

    # Получить рабочую книгу данных диаграммы.
    workbook = chart.getChartData().getChartDataWorkbook()

    # Добавить серии.
    series_cell = workbook.getCell(default_worksheet_index, 0, 1, "Series 1")
    chart.getChartData().getSeries().add(series_cell, chart.getType())
    series_cell = workbook.getCell(default_worksheet_index, 0, 2, "Series 2")
    chart.getChartData().getSeries().add(series_cell, chart.getType())

    # Добавить категории.
    category_cell = workbook.getCell(default_worksheet_index, 1, 0, "Category 1")
    chart.getChartData().getCategories().add(category_cell)
    category_cell = workbook.getCell(default_worksheet_index, 2, 0, "Category 2")
    chart.getChartData().getCategories().add(category_cell)
    category_cell = workbook.getCell(default_worksheet_index, 3, 0, "Category 3")
    chart.getChartData().getCategories().add(category_cell)

    # Установить свойства 3D‑вращения.
    chart.getRotation3D().setRightAngleAxes(True)
    chart.getRotation3D().setRotationX(jpype.JByte(40))
    chart.getRotation3D().setRotationY(270)
    chart.getRotation3D().setDepthPercents(150)

    # Доступ к второй серии диаграммы.
    series = chart.getChartData().getSeries().get_Item(1)

    # Заполнить данные серии.
    data_cell = workbook.getCell(default_worksheet_index, 1, 1, jpype.JInt(20))
    series.getDataPoints().addDataPointForBarSeries(data_cell)
    data_cell = workbook.getCell(default_worksheet_index, 2, 1, jpype.JInt(50))
    series.getDataPoints().addDataPointForBarSeries(data_cell)
    data_cell = workbook.getCell(default_worksheet_index, 3, 1, jpype.JInt(30))
    series.getDataPoints().addDataPointForBarSeries(data_cell)
    data_cell = workbook.getCell(default_worksheet_index, 1, 2, jpype.JInt(30))
    series.getDataPoints().addDataPointForBarSeries(data_cell)
    data_cell = workbook.getCell(default_worksheet_index, 2, 2, jpype.JInt(10))
    series.getDataPoints().addDataPointForBarSeries(data_cell)
    data_cell = workbook.getCell(default_worksheet_index, 3, 2, jpype.JInt(60))
    series.getDataPoints().addDataPointForBarSeries(data_cell)

    # Сохранить презентацию.
    presentation.save("Rotation3D_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Часто задаваемые вопросы**

**Какие типы диаграмм поддерживают 3D‑режим в Aspose.Slides?**

Aspose.Slides поддерживает 3D‑варианты столбчатых диаграмм, включая Column 3D, Clustered Column 3D, Stacked Column 3D и 100 % Stacked Column 3D, а также связанные 3D‑типы, доступные через класс [ChartType](https://reference.aspose.com/slides/ru/python-java/aspose.slides/charttype/). Для получения точного актуального списка проверьте члены [ChartType](https://reference.aspose.com/slides/ru/python-java/aspose.slides/charttype/) в справочнике API установленной версии.

**Можно ли получить растровое изображение 3D‑диаграммы для отчёта или веба?**

Да. Вы можете экспортировать диаграмму в изображение через [chart API](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shape/#getImage) или [отрендерить весь слайд](/slides/ru/python-java/convert-powerpoint-to-png/) в форматы PNG или JPEG. Это удобно, когда нужен пиксельно‑точный предварительный просмотр или необходимо встроить диаграмму в документы, дашборды или веб‑страницы без использования PowerPoint.

**Насколько производительно построение и рендеринг больших 3D‑диаграмм?**

Производительность зависит от объёма данных и визуальной сложности. Для лучших результатов держите 3D‑эффекты минимальными, избегайте тяжёлых текстур на стенах и областях построения, по возможности ограничивайте количество точек данных в серии и рендерьте в размер, соответствующий целевому экрану или печати (разрешение и размеры).