---
title: Настройка осей диаграмм в презентациях с использованием Python
linktitle: Ось диаграммы
type: docs
url: /ru/python-java/chart-axis/
keywords:
- ось диаграммы
- вертикальная ось
- горизонтальная ось
- настроить ось
- модифицировать ось
- управлять осью
- свойства оси
- максимальное значение
- минимальное значение
- линия оси
- формат даты
- заголовок оси
- позиция оси
- PowerPoint
- презентация
- Python
- Aspose.Slides
description: "Узнайте, как использовать Aspose.Slides for Python via Java для настройки осей диаграмм в презентациях PowerPoint для отчетов и визуализаций."
---
## **Обзор**

В этой статье объясняется, как настраивать оси диаграмм в Aspose.Slides. Показано, как получить фактические значения осей, поменять данные между осями, скрыть вертикальную или горизонтальную ось для линейных диаграмм, изменить тип категориальной оси, установить формат даты для значений категориальной оси, повернуть заголовок оси, задать положение оси и установить единицу отображения оси значений.

## **Получить максимальные значения на вертикальной оси диаграммы**

Aspose.Slides for Python via Java позволяет получать минимальные и максимальные значения на вертикальной оси. Выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/).
1. Получите доступ к первому слайду.
1. Добавьте диаграмму с данными по умолчанию.
1. Получите фактическое максимальное значение на оси.
1. Получите фактическое минимальное значение на оси.
1. Получите фактическую основную единицу оси.
1. Получите фактическую вспомогательную единицу оси.
1. Получите фактический масштаб основной единицы оси.
1. Получите фактический масштаб вспомогательной единицы оси.

Этот пример кода — реализация описанных выше шагов — показывает, как получить необходимые значения на Python:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Area, 100, 100, 500, 350)
    chart.validateChartLayout()

    max_value = chart.getAxes().getVerticalAxis().getActualMaxValue()
    min_value = chart.getAxes().getVerticalAxis().getActualMinValue()

    major_unit = chart.getAxes().getVerticalAxis().getActualMajorUnit()
    minor_unit = chart.getAxes().getVerticalAxis().getActualMinorUnit()

    major_unit_scale = chart.getAxes().getVerticalAxis().getActualMajorUnitScale()
    minor_unit_scale = chart.getAxes().getVerticalAxis().getActualMinorUnitScale()

    # Сохраняет презентацию
    presentation.save("MaxValuesVerticalAxis_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Поменять данные между осями**

Aspose.Slides позволяет быстро поменять данные между осями — данные, отображаемые на вертикальной оси (y‑axis), перемещаются на горизонтальную ось (x‑axis) и наоборот.

Этот код на Python показывает, как выполнить задачу обмена данными между осями на диаграмме:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 400, 300)

    # Загружает данные диаграммы по умолчанию в книгу данных — switchRowColumn транспонирует книгу,
    # поэтому её нужно сначала заполнить
    workbook = chart.getChartData().getChartDataWorkbook()

    # Переключает строки и столбцы
    chart.getChartData().switchRowColumn()

    # Сохраняет презентацию
    presentation.save("SwitchChartRowColumns_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Отключить вертикальную ось для линейных диаграмм**

Этот код на Python показывает, как скрыть вертикальную ось в линейной диаграмме:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 100, 100, 400, 300)
    chart.getAxes().getVerticalAxis().setVisible(False)

    presentation.save("chart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Отключить горизонтальную ось для линейных диаграмм**

Этот код показывает, как скрыть горизонтальную ось в линейной диаграмме:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 100, 100, 400, 300)
    chart.getAxes().getHorizontalAxis().setVisible(False)

    presentation.save("chart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Изменить категориальную ось**

С помощью метода [setCategoryAxisType](https://reference.aspose.com/slides/ru/python-java/aspose.slides/axis/#setCategoryAxisType) вы можете указать предпочтительный тип категориальной оси (**date** или **text**). Этот код на Python демонстрирует операцию:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Chart, SaveFormat, CategoryAxisType, TimeUnitType

presentation = Presentation("ExistingChart.pptx")
try:
    if presentation.getSlides().size() > 0 and presentation.getSlides().get_Item(0).getShapes().size() > 0:
        chart = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
        if isinstance(chart, Chart):
            chart.getAxes().getHorizontalAxis().setCategoryAxisType(CategoryAxisType.Date)
            chart.getAxes().getHorizontalAxis().setAutomaticMajorUnit(False)
            chart.getAxes().getHorizontalAxis().setMajorUnit(1)
            chart.getAxes().getHorizontalAxis().setMajorUnitScale(TimeUnitType.Months)
            presentation.save("ChangeChartCategoryAxis_out.pptx", SaveFormat.Pptx)
        else:
            print("The first shape is not a chart.")
    else:
        print("The presentation has no first shape to update.")
finally:
    presentation.dispose()
```

## **Установить формат даты для значений категориальной оси**

Aspose.Slides for Python via Java позволяет установить формат даты для значения категориальной оси. Операция продемонстрирована в этом коде на Python:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat, CategoryAxisType

from datetime import datetime

def convert_to_oa_date(date):
    base_date = datetime(1899, 12, 30)
    return (date - base_date).total_seconds() / 86400


presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Area, 50, 50, 450, 300)

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()
    category_date = datetime(2015, 2, 1)
    category_value = convert_to_oa_date(category_date)
    category_cell = workbook.getCell(0, "A2", category_value)
    chart.getChartData().getCategories().add(category_cell)
    category_date = datetime(2016, 2, 1)
    category_value = convert_to_oa_date(category_date)
    category_cell = workbook.getCell(0, "A3", category_value)
    chart.getChartData().getCategories().add(category_cell)
    category_date = datetime(2017, 2, 1)
    category_value = convert_to_oa_date(category_date)
    category_cell = workbook.getCell(0, "A4", category_value)
    chart.getChartData().getCategories().add(category_cell)
    category_date = datetime(2018, 2, 1)
    category_value = convert_to_oa_date(category_date)
    category_cell = workbook.getCell(0, "A5", category_value)
    chart.getChartData().getCategories().add(category_cell)

    series = chart.getChartData().getSeries().add(ChartType.Line)
    value_cell = workbook.getCell(0, "B2", 1.0)
    series.getDataPoints().addDataPointForLineSeries(value_cell)
    value_cell = workbook.getCell(0, "B3", 2.0)
    series.getDataPoints().addDataPointForLineSeries(value_cell)
    value_cell = workbook.getCell(0, "B4", 3.0)
    series.getDataPoints().addDataPointForLineSeries(value_cell)
    value_cell = workbook.getCell(0, "B5", 4.0)
    series.getDataPoints().addDataPointForLineSeries(value_cell)
    chart.getAxes().getHorizontalAxis().setCategoryAxisType(CategoryAxisType.Date)
    chart.getAxes().getHorizontalAxis().setNumberFormatLinkedToSource(False)
    chart.getAxes().getHorizontalAxis().setNumberFormat("yyyy")

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Установить угол поворота заголовка оси диаграммы**

Aspose.Slides for Python via Java позволяет установить угол поворота заголовка оси диаграммы. Этот код на Python демонстрирует операцию:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300)

    chart.getAxes().getVerticalAxis().setTitle(True)
    chart.getAxes().getVerticalAxis().getTitle().getTextFormat().getTextBlockFormat().setRotationAngle(90)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Установить положение оси на категориальной или оси значений**

Aspose.Slides for Python via Java позволяет задать положение оси на категориальной или оси значений. Этот код на Python показывает, как выполнить задачу:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300)

    chart.getAxes().getHorizontalAxis().setAxisBetweenCategories(True)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Установить единицу отображения на оси значений диаграммы**

Aspose.Slides for Python via Java позволяет установить единицу отображения оси значений диаграммы. Ось затем масштабирует подписи делений согласно этой единице: с [DisplayUnitType.Millions](https://reference.aspose.com/slides/ru/python-java/aspose.slides/displayunittype/#Millions) ось, достигающая 60 000 000, будет помечена от 0 до 60. Этот код на Python демонстрирует операцию:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat, DisplayUnitType

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300)

    chart.getAxes().getVerticalAxis().setDisplayUnit(DisplayUnitType.Millions)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Как задать значение, при котором одна ось пересекает другую (пересечение осей)?**

Оси предоставляют [настройку пересечения](https://reference.aspose.com/slides/ru/python-java/aspose.slides/axis/#setCrossType): вы можете выбрать пересечение в нуле, на максимальной категории/значении или в конкретном числовом значении. Это полезно для смещения оси X вверх или вниз либо для выделения базовой линии.

**Как расположить метки делений относительно оси (пересечение, снаружи, внутри)?**

Установите [позицию меток делений](https://reference.aspose.com/slides/ru/python-java/aspose.slides/axis/#setMajorTickMark) в "cross", "outside" или "inside". Это влияет на читаемость и помогает экономить место, особенно в небольших диаграммах.