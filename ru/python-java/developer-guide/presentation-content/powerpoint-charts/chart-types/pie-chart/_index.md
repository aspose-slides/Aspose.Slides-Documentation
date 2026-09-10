---
title: Настройка круговых диаграмм в презентациях с использованием Python через Java
linktitle: Круговая диаграмма
type: docs
url: /ru/python-java/pie-chart/
keywords:
- круговая диаграмма
- управление диаграммой
- настройка диаграммы
- параметры диаграммы
- настройки диаграммы
- параметры построения
- цвет сектора
- PowerPoint
- презентация
- Python
- Java
- Aspose.Slides
description: "Узнайте, как создавать и настраивать круговые диаграммы в Python через Java с помощью Aspose.Slides, экспортировать их в PowerPoint и за считанные секунды улучшать подачу данных."
---
## **Обзор**

В этой статье объясняется, как работать с круговыми диаграммами в Aspose.Slides. Показано, как настроить параметры вторичного построения для диаграмм Pie of Pie и Bar of Pie, а также как включить автоматическое раскрашивание секторов стандартной круговой диаграммы.

В примерах делается акцент на практических шагах настройки диаграмм, таких как добавление диаграммы на слайд, настройка параметров рядов и подписей, замена данных диаграммы по умолчанию пользовательскими категориями и значениями, а также сохранение обновлённой презентации.

## **Параметры вторичного построения для диаграмм Pie of Pie и Bar of Pie**

Aspose.Slides for Python via Java поддерживает параметры вторичного построения для диаграмм Pie of Pie и Bar of Pie. В этом разделе показано, как задать эти параметры с помощью Aspose.Slides. Выполните следующие действия:

1. Создайте объект [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/).
1. Добавьте диаграмму на слайд.
1. Укажите параметры вторичного построения диаграммы.
1. Сохраните презентацию на диск.

В следующем примере задаются различные свойства диаграммы Pie of Pie.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, PieSplitType, Presentation, SaveFormat

# Создать экземпляр класса Presentation.
presentation = Presentation()
try:
    # Добавить диаграмму на слайд.
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.PieOfPie, 50, 50, 500, 400)

    # Установить разные свойства.
    series = chart.getChartData().getSeries().get_Item(0)
    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)
    series_group = series.getParentSeriesGroup()
    series_group.setSecondPieSize(149)
    series_group.setPieSplitBy(PieSplitType.ByPercentage)
    series_group.setPieSplitPosition(53)

    # Сохранить презентацию на диск.
    presentation.save("SecondPlotOptionsforCharts_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Установка автоматических цветов секторов круговой диаграммы**

Aspose.Slides for Python via Java предоставляет простой API для установки автоматических цветов секторов круговой диаграммы. В следующем примере показано, как применить эти настройки.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/).
1. Получите первый слайд.
1. Добавьте диаграмму с данными по умолчанию.
1. Установите заголовок диаграммы.
1. Установите индекс листа данных диаграммы.
1. Получите рабочую книгу данных диаграммы.
1. Удалите ряд и категории по умолчанию.
1. Добавьте новые категории.
1. Добавьте новый ряд.
1. Установите отображение значений для нового ряда.

Сохраните изменённую презентацию в файл PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, NullableBool, Presentation, SaveFormat

# Создать экземпляр класса Presentation.
presentation = Presentation()
try:
    # Добавить диаграмму с данными по умолчанию.
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 100, 100, 400, 400)

    # Установить заголовок диаграммы.
    chart.getChartTitle().addTextFrameForOverriding("Sample Title")
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True_)
    chart.getChartTitle().setHeight(20)
    chart.setTitle(True)

    # Установить индекс листа данных диаграммы.
    default_worksheet_index = 0

    # Получить рабочую книгу данных диаграммы.
    workbook = chart.getChartData().getChartDataWorkbook()

    # Удалить ряд и категории по умолчанию.
    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    # Добавить новые категории.
    first_category_cell = workbook.getCell(0, 1, 0, "First Qtr")
    chart.getChartData().getCategories().add(first_category_cell)
    second_category_cell = workbook.getCell(0, 2, 0, "2nd Qtr")
    chart.getChartData().getCategories().add(second_category_cell)
    third_category_cell = workbook.getCell(0, 3, 0, "3rd Qtr")
    chart.getChartData().getCategories().add(third_category_cell)

    # Добавить новый ряд.
    series_cell = workbook.getCell(0, 0, 1, "Series 1")
    series = chart.getChartData().getSeries().add(series_cell, chart.getType())

    # Заполнить данные ряда.
    first_value_cell = workbook.getCell(default_worksheet_index, 1, 1, jpype.JInt(20))
    series.getDataPoints().addDataPointForPieSeries(first_value_cell)
    second_value_cell = workbook.getCell(default_worksheet_index, 2, 1, jpype.JInt(50))
    series.getDataPoints().addDataPointForPieSeries(second_value_cell)
    third_value_cell = workbook.getCell(default_worksheet_index, 3, 1, jpype.JInt(30))
    series.getDataPoints().addDataPointForPieSeries(third_value_cell)

    # Установить отображение значений для нового ряда.
    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)

    series.getParentSeriesGroup().setColorVaried(True)
    presentation.save("Pie.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Поддерживаются ли варианты 'Pie of Pie' и 'Bar of Pie'?**

Да, библиотека [поддерживает](https://reference.aspose.com/slides/ru/python-java/aspose.slides/charttype/) вторичное построение для круговых диаграмм, включая типы 'Pie of Pie' и 'Bar of Pie'.

**Можно ли экспортировать только диаграмму как изображение (например, PNG)?**

Да, вы можете [экспортировать саму диаграмму как изображение](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shape/#getImage) (например, PNG) без всей презентации.