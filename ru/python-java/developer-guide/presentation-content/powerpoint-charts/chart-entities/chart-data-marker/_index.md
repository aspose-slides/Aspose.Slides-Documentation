---
title: Управление маркерами данных диаграмм в презентациях с использованием Python
linktitle: Маркер данных
type: docs
url: /ru/python-java/chart-data-marker/
keywords:
- диаграмма
- точка данных
- маркер
- параметры маркера
- размер маркера
- тип заливки
- PowerPoint
- презентация
- Python
- Java
- Aspose.Slides
description: "Узнайте, как настраивать маркеры данных диаграмм в Aspose.Slides для Python через Java, повышая эффективность презентаций в форматах PPT и PPTX с помощью понятных примеров кода на Python."
---
## **Обзор**

В этой статье объясняется, как работать с маркерами данных диаграмм в Aspose.Slides. Показано, как создать диаграмму, получить доступ к серии и её точкам данных, применить заполнение изображением к маркерам на уровне точек данных, изменить размер маркера и сохранить обновленную презентацию. Также отмечается, что стандартные формы маркеров доступны через перечисление [MarkerStyleType](https://reference.aspose.com/slides/ru/python-java/aspose.slides/markerstyletype/) и что внешний вид маркеров сохраняется при экспорте диаграмм в растровые форматы или SVG.

## **Настройка параметров маркеров диаграммы**
Маркеры можно задавать для точек данных диаграммы в определенной серии. Чтобы установить параметры маркеров диаграммы, выполните следующие действия:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/).
- Создайте диаграмму по умолчанию.
- Установите изображения.
- Получите доступ к первой серии диаграммы.
- Добавьте новые точки данных.
- Запишите презентацию на диск.

Следующий пример устанавливает параметры маркеров диаграммы на уровне точек данных.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat

# Создать пустую презентацию.
presentation = Presentation()
try:
    # Доступ к первому слайду
    slide = presentation.getSlides().get_Item(0)

    # Создание диаграммы по умолчанию
    chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 0, 0, 400, 400)

    # Получить индекс листа данных диаграммы по умолчанию.
    default_worksheet_index = 0

    # Получить рабочую книгу данных диаграммы.
    workbook = chart.getChartData().getChartDataWorkbook()

    # Удалить демонстрационную серию
    chart.getChartData().getSeries().clear()

    # Добавить новую серию
    series_name_cell = workbook.getCell(default_worksheet_index, 1, 1, "Series 1")
    chart.getChartData().getSeries().add(series_name_cell, chart.getType())

    # Загрузить первое изображение.
    desert_bytes = Path("Desert.jpg").read_bytes()
    desert_image = presentation.getImages().addImage(jpype.JArray(jpype.JByte)(desert_bytes))

    # Загрузить второе изображение.
    tulips_bytes = Path("Tulips.jpg").read_bytes()
    tulips_image = presentation.getImages().addImage(jpype.JArray(jpype.JByte)(tulips_bytes))

    # Доступ к первой серии диаграммы.
    series = chart.getChartData().getSeries().get_Item(0)

    # Добавить точки данных.
    value_cell = workbook.getCell(default_worksheet_index, 1, 1, 4.5)
    point = series.getDataPoints().addDataPointForLineSeries(value_cell)
    point.getMarker().getFormat().getFill().setFillType(FillType.Picture)
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(desert_image)

    value_cell = workbook.getCell(default_worksheet_index, 2, 1, 2.5)
    point = series.getDataPoints().addDataPointForLineSeries(value_cell)
    point.getMarker().getFormat().getFill().setFillType(FillType.Picture)
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(tulips_image)

    value_cell = workbook.getCell(default_worksheet_index, 3, 1, 3.5)
    point = series.getDataPoints().addDataPointForLineSeries(value_cell)
    point.getMarker().getFormat().getFill().setFillType(FillType.Picture)
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(desert_image)

    value_cell = workbook.getCell(default_worksheet_index, 4, 1, 4.5)
    point = series.getDataPoints().addDataPointForLineSeries(value_cell)
    point.getMarker().getFormat().getFill().setFillType(FillType.Picture)
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(tulips_image)

    # Изменить размер маркера серии диаграммы.
    series.getMarker().setSize(15)

    # Сохранить презентацию с диаграммой
    presentation.save("MarkOptions_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Какие формы маркеров доступны из коробки?**

Стандартные формы доступны (круг, квадрат, ромб, треугольник и т.д.); список определяется классом [MarkerStyleType](https://reference.aspose.com/slides/ru/python-java/aspose.slides/markerstyletype/). Если требуется нестандартная форма, используйте маркер с заполнением изображением для имитации пользовательских визуальных элементов.

**Сохраняются ли маркеры при экспорте диаграммы в изображение или SVG?**

Да. При рендеринге диаграмм в [растровые форматы](/slides/ru/python-java/convert-powerpoint-to-png/) или сохранении [форм в SVG](/slides/ru/python-java/render-a-slide-as-an-svg-image/) маркеры сохраняют свой внешний вид и параметры, включая размер, заливку и контур.