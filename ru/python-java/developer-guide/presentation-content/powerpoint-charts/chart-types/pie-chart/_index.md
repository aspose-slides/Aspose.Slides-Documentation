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
description: "Создавайте и настраивайте круговые диаграммы в Python через Java с помощью Aspose.Slides. Настраивайте вторичные графики, отображайте подписи данных и применяйте автоматическое раскрашивание секторов в PowerPoint."
---
## **Обзор**

Эта статья объясняет, как работать с круговыми диаграммами в Aspose.Slides. В ней показано, как настроить параметры вторичного графика для диаграмм Pie of Pie и Bar of Pie, а также как включить автоматическое раскрашивание секторов для обычной круговой диаграммы.

Примеры сосредоточены на задачах настройки диаграмм, таких как добавление диаграммы на слайд, настройка параметров рядов и меток, замена данных диаграммы по умолчанию пользовательскими категориями и значениями, а также сохранение обновлённой презентации.

## **Параметры вторичного графика для диаграмм Pie of Pie и Bar of Pie**

Aspose.Slides for Python via Java поддерживает параметры вторичного графика для диаграмм Pie of Pie и Bar of Pie. Эти параметры управляют размером вторичного графика и тем, как точки данных распределяются между двумя графиками.

Следующий пример создаёт диаграмму Pie of Pie в новой презентации и отображает значения точек данных в виде меток. Метод [setSecondPieSize](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setSecondPieSize) устанавливает размер вторичного графика равным 149% основного графика. [setPieSplitBy](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setPieSplitBy) выбирает разбиение по процентам, а [setPieSplitPosition](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setPieSplitPosition) устанавливает пороговое значение в 53%.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, PieSplitType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.PieOfPie, 50, 50, 500, 400)
    series = chart.getChartData().getSeries().get_Item(0)

    # Отображать значения и настраивать вторичный график.
    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)
    series_group = series.getParentSeriesGroup()
    series_group.setSecondPieSize(149)
    series_group.setPieSplitBy(PieSplitType.ByPercentage)
    series_group.setPieSplitPosition(53)

    presentation.save("pie_of_pie.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Выбрать категории для вторичного графика**

Используйте пользовательское разбиение, когда нужно группировать определённые категории во вторичном графике независимо от их процентных значений. Например, в отчёте о продажах можно отобразить Онлайн и Мероприятия вместе, чтобы читатели могли сравнить эти два канала, хотя они составляют 35% и 10% от общего объёма продаж.

Вызовите [setPieSplitBy](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setPieSplitBy) с [PieSplitType.Custom](https://reference.aspose.com/slides/python-java/aspose.slides/piesplittype/#Custom) и выберите точки через [getPieSplitCustomPoints](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#getPieSplitCustomPoints). Метод [add](https://reference.aspose.com/slides/python-java/aspose.slides/piesplitcustompointcollection/#add) коллекции принимает нулевой индекс в серии; используйте [addItem](https://reference.aspose.com/slides/python-java/aspose.slides/piesplitcustompointcollection/#addItem), чтобы добавить объект точки данных. В этом примере индекс 1 выбирает Онлайн, а точка с индексом 3 выбирает Мероприятия. Партнёры также временно добавляются, а затем исключаются с помощью [removeItem](https://reference.aspose.com/slides/python-java/aspose.slides/piesplitcustompointcollection/#removeItem).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, PieSplitType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.PieOfPie, 50, 50, 600, 200)

    # Заменить данные по умолчанию продажами по каналам.
    workbook = chart.getChartData().getChartDataWorkbook()
    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()
    category_names = ["Retail", "Online", "Partners", "Events"]
    values = [40, 35, 15, 10]
    series_name_cell = workbook.getCell(0, 0, 1, "Sales")
    series = chart.getChartData().getSeries().add(series_name_cell, chart.getType())

    for i in range(len(category_names)):
        category_cell = workbook.getCell(0, i + 1, 0, category_names[i])
        chart.getChartData().getCategories().add(category_cell)

        value_cell = workbook.getCell(0, i + 1, 1, jpype.JInt(values[i]))
        series.getDataPoints().addDataPointForPieSeries(value_cell)

    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)
    series_group = series.getParentSeriesGroup()
    series_group.setPieSplitBy(PieSplitType.Custom)
    series_group.setColorVaried(True)

    # Выбрать Online по его нулевому индексу и Events по объекту точки данных.
    series_group.getPieSplitCustomPoints().add(1)
    series_group.getPieSplitCustomPoints().addItem(series.getDataPoints().get_Item(3))

    # Исключить Partners из выбора без удаления его исходных данных.
    series_group.getPieSplitCustomPoints().add(2)
    series_group.getPieSplitCustomPoints().removeItem(series.getDataPoints().get_Item(2))

    presentation.save("pie_of_pie_custom.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Онлайн (35) и Мероприятия (10) отображаются как отдельные сектора во вторичном графике. В основном графике они представлены одним объединённым сектором со значением 45, наряду с Розничной торговлей (40) и Партнёрами (15). Удаление Партнёров из пользовательского выбора оставляет их в основном графике; они не удаляются из исходных данных диаграммы.

На следующем изображении показана сохранённая презентация в PowerPoint:

![Диаграмма Pie of Pie с Онлайн и Мероприятиями во вторичном графике и их объединённым значением 45 в основном графике](pie_of_pie_custom.png)

## **Установить автоматическое раскрашивание секторов круговой диаграммы**

Aspose.Slides for Python via Java может автоматически назначать разные цвета секторам круговой диаграммы. Следующий пример создаёт круговую диаграмму с заголовком по центру и заменяет данные по умолчанию тремя квартальными категориями и их значениями. Метод [setShowValue](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setShowValue) отображает значения 20, 50 и 30 в виде меток, а [setColorVaried](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setColorVaried) включает различный цвет для каждого сектора.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, NullableBool, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Pie, 100, 100, 400, 400)

    # Добавить заголовок диаграммы по центру.
    chart.getChartTitle().addTextFrameForOverriding("Sample Title")
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True_)
    chart.getChartTitle().setHeight(20)
    chart.setTitle(True)

    # Заменить данные по умолчанию с использованием первого листа.
    workbook = chart.getChartData().getChartDataWorkbook()
    worksheet_index = 0
    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()
    category_names = ["First Qtr", "2nd Qtr", "3rd Qtr"]
    values = [20, 50, 30]
    series_name_cell = workbook.getCell(worksheet_index, 0, 1, "Series 1")
    series = chart.getChartData().getSeries().add(series_name_cell, chart.getType())

    for i in range(len(category_names)):
        category_cell = workbook.getCell(worksheet_index, i + 1, 0, category_names[i])
        chart.getChartData().getCategories().add(category_cell)

        value_cell = workbook.getCell(worksheet_index, i + 1, 1, jpype.JInt(values[i]))
        series.getDataPoints().addDataPointForPieSeries(value_cell)

    # Отобразить значения и назначить разные цвета секторам.
    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)
    series.getParentSeriesGroup().setColorVaried(True)

    presentation.save("pie.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Часто задаваемые вопросы**

**Поддерживаются ли варианты Pie of Pie и Bar of Pie?**

Да, библиотека [поддерживает](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) вторичный график для круговых диаграмм, включая типы Pie of Pie и Bar of Pie.

**Могу ли я экспортировать только диаграмму как изображение (например, PNG)?**

Да, вы можете [экспортировать саму диаграмму как изображение](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getImage) (например PNG) без экспорта всей презентации.