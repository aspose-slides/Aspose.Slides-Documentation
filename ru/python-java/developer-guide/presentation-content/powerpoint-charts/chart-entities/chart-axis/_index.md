---
title: Настройка осей диаграмм в презентациях с помощью Python
linktitle: Ось диаграммы
type: docs
url: /ru/python-java/chart-axis/
keywords:
- ось диаграммы
- вертикальная ось
- горизонтальная ось
- настройка оси
- манипулирование осью
- управление осью
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
description: "Узнайте, как использовать Aspose.Slides для Python через Java, чтобы настраивать оси диаграмм в презентациях PowerPoint для отчетов и визуализаций."
---
## **Обзор**

Эта статья объясняет, как настраивать оси диаграммы с помощью Aspose.Slides для Python через Java. Она охватывает рассчитанные значения осей, переключение строк и столбцов диаграммы, видимость осей, интервалы меток категорий и делений, категории дат и их форматирование, вращение заголовка, позицию осей, единицы отображения и логарифмическое масштабирование.

## **Получить максимальные значения по вертикальной оси диаграммы**

Создайте [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) и добавьте областную диаграмму с данными по умолчанию. Вызовите [validateChartLayout](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#validateChartLayout) перед чтением вычисленных значений осей, чтобы макет диаграммы был актуален.

Прочитайте [getActualMaxValue](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMaxValue) и [getActualMinValue](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMinValue) для пределов оси, а также [getActualMajorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMajorUnit) и [getActualMinorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMinorUnit) для интервалов делений. [getActualMajorUnitScale](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMajorUnitScale) и [getActualMinorUnitScale](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMinorUnitScale) предоставляют масштаб единиц времени, который имеет значение для датовых осей. В примере эти значения сохраняются в локальные переменные и диаграмма сохраняется.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Area, 100, 100, 500, 350)
    chart.validateChartLayout()

    max_value = chart.getAxes().getVerticalAxis().getActualMaxValue()
    min_value = chart.getAxes().getVerticalAxis().getActualMinValue()

    major_unit = chart.getAxes().getVerticalAxis().getActualMajorUnit()
    minor_unit = chart.getAxes().getVerticalAxis().getActualMinorUnit()

    major_unit_scale = chart.getAxes().getVerticalAxis().getActualMajorUnitScale()
    minor_unit_scale = chart.getAxes().getVerticalAxis().getActualMinorUnitScale()

    presentation.save("AxisValues_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Поменять данные между осями**

Используйте [switchRowColumn](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#switchRowColumn) для обмена ролями рядов и категорий в данных диаграммы. Каждая прежняя категория становится рядом, а каждый прежний ряд — категорией. Это меняет способ группировки данных; оси горизонтальная и вертикальная не меняются местами. В примере используется [setRange](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setRange) для привязки данных по умолчанию к `Sheet1!A1:D5`, включая строку заголовка и столбец категорий, перед переключением строк и столбцов. Диаграмма сохраняется с четырьмя рядами и тремя категориями.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 400, 300)
    chart.getChartData().setRange("Sheet1!A1:D5")
    chart.getChartData().switchRowColumn()

    presentation.save("SwitchChartRowColumns_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Отключить вертикальную ось для линейных диаграмм**

Вызовите [setVisible](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setVisible) с `False` для вертикальной оси, чтобы скрыть её. В примере создаётся линейная диаграмма с данными по умолчанию и сохраняется с скрытой вертикальной осью.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Line, 100, 100, 400, 300)
    chart.getAxes().getVerticalAxis().setVisible(False)

    presentation.save("HiddenVerticalAxis.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Отключить горизонтальную ось для линейных диаграмм**

Вызовите [setVisible](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setVisible) с `False` для горизонтальной оси, чтобы скрыть её. В примере создаётся линейная диаграмма с данными по умолчанию и сохраняется с скрытой горизонтальной осью.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Line, 100, 100, 400, 300)
    chart.getAxes().getHorizontalAxis().setVisible(False)

    presentation.save("HiddenHorizontalAxis.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Изменить ось категорий**

Используйте [setCategoryAxisType](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCategoryAxisType) для выбора датовой или текстовой оси категорий. Этот пример требует `ExistingChart.pptx`, где диаграмма является первой фигурой на первом слайде, а ячейки категорий содержат числовые значения дат Excel. Он меняет горизонтальную ось на датовую. Вызов [setAutomaticMajorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAutomaticMajorUnit) с `False`, [setMajorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorUnit) с `1` и [setMajorUnitScale](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorUnitScale) с [TimeUnitType.Months](https://reference.aspose.com/slides/python-java/aspose.slides/timeunittype/#Months) размещает основные деления через один месяц.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, CategoryAxisType, TimeUnitType

presentation = Presentation("ExistingChart.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().get_Item(0)
    chart.getAxes().getHorizontalAxis().setCategoryAxisType(CategoryAxisType.Date)
    chart.getAxes().getHorizontalAxis().setAutomaticMajorUnit(False)
    chart.getAxes().getHorizontalAxis().setMajorUnit(1)
    chart.getAxes().getHorizontalAxis().setMajorUnitScale(TimeUnitType.Months)

    presentation.save("ChangeChartCategoryAxis_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Управление интервалами меток оси категорий**

Когда у диаграммы много категорий, уменьшите количество видимых меток оси, не удаляя категории или точки данных. Вызовите [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAutomaticTickLabelSpacing) с `False`, затем передайте желаемый интервал категорий в [setTickLabelSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setTickLabelSpacing). Для текстовых категорий в их обычном порядке отсчёт начинается с первой категории:

| Инте��вал | Отображаемые метки в примере |
| --- | --- |
| `1` | Категория 1, Категория 2, Категория 3, ... Категория 24 |
| `2` | Категория 1, Категория 3, Категория 5, ... Категория 23 |
| `3` | Категория 1, Категория 4, Категория 7, ... Категория 22 |

Интервал `3` отображает каждую третью метку, скрывая две метки между отображаемыми. Он не удаляет соответствующие столбцы. Автоматический интервал выбирает значение на основе доступного пространства; он не обязательно отображает каждую метку.

Для делений существуют отдельные настройки. Вызовите [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAutomaticTickMarksSpacing) с `False` и используйте [setTickMarksSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setTickMarksSpacing), чтобы задать их интервал. Например, `1` сохраняет деление на каждом интервале категории, в то время как метки появляются только каждые три категории. Используйте [setMajorTickMark](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorTickMark) с видимым стилем, чтобы увидеть результат. Повторный вызов любого из автоматических параметров с `True` позволяет диаграмме снова выбрать автоматический интервал.

Следующий самостоятельный пример создает 24 категории и один ряд, затем сохраняет три слайда в `CategoryAxisIntervals.pptx`: автоматический интервал, ручной интервал меток с независимыми делениями и восстановленный автоматический интервал. Обе копии сохраняют исходные данные диаграммы. Входная презентация не требуется. Горизонтальный текст меток делает разницу в плотности легко заметной.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat, CategoryAxisType, TickMarkType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 30, 40, 660, 320)

    chart.setLegend(False)
    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    series = chart.getChartData().getSeries().add(ChartType.ClusteredColumn)
    for i in range(24):
        category_cell = workbook.getCell(0, i + 1, 0, f"Category {i + 1}")
        chart.getChartData().getCategories().add(category_cell)
        value_cell = workbook.getCell(0, i + 1, 1, float(10 + i % 6 * 5))
        series.getDataPoints().addDataPointForBarSeries(value_cell)

    axis = chart.getAxes().getHorizontalAxis()
    axis.setCategoryAxisType(CategoryAxisType.Text)
    axis.getTextFormat().getTextBlockFormat().setRotationAngle(0)
    axis.getTextFormat().getPortionFormat().setFontHeight(12)
    axis.setMajorTickMark(TickMarkType.Outside)
    axis.setAutomaticTickLabelSpacing(True)
    axis.setAutomaticTickMarksSpacing(True)

    # Слайд 2: показывать каждую третью метку, но сохранять деление для каждой категории.
    manual_slide = presentation.getSlides().addClone(slide)
    manual_chart = manual_slide.getShapes().get_Item(0)
    manual_axis = manual_chart.getAxes().getHorizontalAxis()
    manual_axis.setAutomaticTickLabelSpacing(False)
    manual_axis.setTickLabelSpacing(3)
    manual_axis.setAutomaticTickMarksSpacing(False)
    manual_axis.setTickMarksSpacing(1)

    # Слайд 3: позволить диаграмме снова выбрать оба интервала.
    restored_slide = presentation.getSlides().addClone(manual_slide)
    restored_chart = restored_slide.getShapes().get_Item(0)
    restored_chart.getAxes().getHorizontalAxis().setAutomaticTickLabelSpacing(True)
    restored_chart.getAxes().getHorizontalAxis().setAutomaticTickMarksSpacing(True)

    presentation.save("CategoryAxisIntervals.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

**Автоматический интервал (слайд 1):** В этом отображении каждая вторая метка категории отображается и переносится на две строки. Автоматический результат может различаться в зависимости от размера диаграммы, шрифтов и средства рендеринга.

![Автоматический интервал меток категорий при видимых всех 24 столбцах](category-axis-automatic.png)

**Ручной интервал (слайд 2):** Каждая третья метка отображается в одну строку, в то время как деления остаются на каждом интервале категории. Все 24 столбца, включая те, что без меток, остаются видимыми с теми же значениями. Слайд 3 восстанавливает автоматический вид, показанный выше.

![Ручной интервал меток категорий в три при видимых всех 24 столбцах](category-axis-manual.png)

### **Выберите правильную ось и интервал**

Используйте этот интервал подсчёта категорий для текстовой оси категорий, например, оси категорий столбчатой, линейной, областной или гистограммы. В столбчатой диаграмме это горизонтальная ось. В горизонтальной гистограмме ось категорий вертикальна, поэтому применяйте эти настройки к оси, возвращаемой [getVerticalAxis](https://reference.aspose.com/slides/python-java/aspose.slides/axesmanager/#getVerticalAxis). Интервал делений также применяется к оси рядов в диаграммах, где она присутствует.

Не используйте интервал меток категорий для установки числовой шкалы оси значений. На оси значений [setMajorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorUnit) задаёт разницу в значениях: например, основной шаг `10` создаёт деления на 0, 10, 20 и т.д., когда ось начинается с нуля. Интервал меток категорий `3` считает позиции категорий, независимо от их значений данных. Диаграммы разброса и пузыри используют оси значений, а не текстовую ось категорий. Для датовой оси используйте временные основные единицы и масштабы, как описано в [Change a Category Axis](#change-a-category-axis).

## **Установить формат даты для значений оси категорий**

В примере заменяется набор данных диаграммы по умолчанию четырьмя годовыми значениями. Даты хранятся как серийные номера OLE Automation в первом листе (индекс `0`), рассчитываемые как количество дней с 30 декабря 1899 года. Используйте [setCategoryAxisType](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCategoryAxisType) с [CategoryAxisType.Date](https://reference.aspose.com/slides/python-java/aspose.slides/categoryaxistype/#Date), вызовите [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setNumberFormatLinkedToSource) с `False` и передайте `yyyy` в [setNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setNumberFormat), чтобы метки категорий отображали четырёхзначные годы независимо от формата ячеек.

```python
from datetime import date

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat, CategoryAxisType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Line, 50, 50, 450, 300)

    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    base_date = date(1899, 12, 30)

    series = chart.getChartData().getSeries().add(ChartType.Line)
    for i in range(4):
        category_date = date(2015 + i, 1, 1)
        category_value = float((category_date - base_date).days)
        category_cell = workbook.getCell(0, i + 1, 0, category_value)
        chart.getChartData().getCategories().add(category_cell)

        value_cell = workbook.getCell(0, i + 1, 1, float(i + 1))
        series.getDataPoints().addDataPointForLineSeries(value_cell)

    chart.getAxes().getHorizontalAxis().setCategoryAxisType(CategoryAxisType.Date)
    chart.getAxes().getHorizontalAxis().setNumberFormatLinkedToSource(False)
    chart.getAxes().getHorizontalAxis().setNumberFormat("yyyy")

    presentation.save("DateAxisFormat.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Установить угол вращения заголовка оси диаграммы**

Вызовите [setTitle](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setTitle) с `True` для вертикальной оси, укажите текст заголовка и задайте угол вращения в форматировании текстового блока заголовка. Угол измеряется в градусах; в этом примере сохраняется столбчатая диаграмма с заголовком оси значений, повернутым на 90 градусов.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300)
    chart.getAxes().getVerticalAxis().setTitle(True)
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("Value")
    chart.getAxes().getVerticalAxis().getTitle().getTextFormat().getTextBlockFormat().setRotationAngle(90)

    presentation.save("RotatedAxisTitle.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Установить положение оси на оси категорий или значений**

Используйте [setAxisBetweenCategories](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAxisBetweenCategories), чтобы управлять тем, пересекает ли ось значений ось категорий между категориями или на метках категорий. Эта настройка применяется к осям категорий. В примере значение установлено в `True` для горизонтальной оси категорий столбчатой диаграммы, и результат сохраняется.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300)
    chart.getAxes().getHorizontalAxis().setAxisBetweenCategories(True)

    presentation.save("AxisBetweenCategories.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Установить единицу отображения на оси значений диаграммы**

Используйте [setDisplayUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setDisplayUnit), чтобы масштабировать метки на оси значений без изменения исходных данных. При установке [DisplayUnitType](https://reference.aspose.com/slides/python-java/aspose.slides/displayunittype/) в `Millions` значение 60 000 000 отображается как 60. В примере создаётся столбчатая диаграмма, и к её вертикальной оси применяется единица отображения «миллионы».

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat, DisplayUnitType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300)
    chart.getAxes().getVerticalAxis().setDisplayUnit(DisplayUnitType.Millions)

    presentation.save("Result.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Настроить логарифмическую ось значений**

Логарифмическая ось значений полезна, когда положительные значения охватывают несколько порядков величины. Например, сервис может получать 10, 100, 1 000, 10 000 и 100 000 запросов за пять периодов. При линейной шкале небольшие значения находятся близко друг к другу рядом с нулём. Логарифмическая шкала облегчает сравнение их относительного роста: равные расстояния представляют равные соотношения, а не равные разницы.

Вызовите [setLogarithmic](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setLogarithmic) с `True` для оси значений и используйте [setLogBase](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setLogBase), чтобы выбрать основание. Это изменяет отображение существующих значений; данные не меняются и не добавляется логарифмическая трендовая линия. Трендовая линия представляет собой подгонку зависимости в данных и является отдельной функцией.

### **Выберите ось значений и основание**

Для линейной или столбчатой диаграммы ось значений возвращается методом [getVerticalAxis](https://reference.aspose.com/slides/python-java/aspose.slides/axesmanager/#getVerticalAxis). Для горизонтальной гистограммы — методом [getHorizontalAxis](https://reference.aspose.com/slides/python-java/aspose.slides/axesmanager/#getHorizontalAxis). Диаграммы разброса и пузырей имеют две оси значений, поэтому выбирайте горизонтальную ось для значений X, вертикальную ось для значений Y, или обе. Не применяйте логарифмическое масштабирование к оси категорий.

Основание логарифма по умолчанию — `10`. Для диаграмм PPTX используйте основание от `2` до `1000` включительно; поддерживаются также дробные основания, такие как `2.5`. При основании `10` последовательные степени, такие как 10, 100, 1 000 и 10 000, расположены на одинаковом расстоянии.

### **Сравнение линейного и логарифмического масштабирования**

В следующем самостоятельном примере создаётся линейная диаграмма с пятью количествами запросов на первом слайде, затем этот слайд клонируется и на втором включается логарифмическая ось значений с основанием 10. Оба слайда сохраняют те же данные.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Line, 30, 40, 660, 200)

    chart.setLegend(False)

    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    series = chart.getChartData().getSeries().add(ChartType.Line)
    values = [10, 100, 1000, 10000, 100000]

    for i, value in enumerate(values):
        category_cell = workbook.getCell(0, i + 1, 0, f"Period {i + 1}")
        chart.getChartData().getCategories().add(category_cell)

        value_cell = workbook.getCell(0, i + 1, 1, float(value))
        series.getDataPoints().addDataPointForLineSeries(value_cell)

    # Сохранить первый слайд линейным и изменить только масштаб оси значений копии.
    logarithmic_slide = presentation.getSlides().addClone(slide)
    logarithmic_chart = logarithmic_slide.getShapes().get_Item(0)
    value_axis = logarithmic_chart.getAxes().getVerticalAxis()
    value_axis.setLogarithmic(True)
    value_axis.setLogBase(10)

    presentation.save("LogarithmicAxis.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

**Линейная шкала (слайд 1):** Равные вертикальные расстояния представляют равные различия в количестве запросов. Наибольшее значение доминирует в диаграмме, делая малые значения трудно различимыми.

![Линейная диаграмма в PowerPoint, показывающая пять количеств запросов на линейной оси значений](value-axis-linear.png)

**Логарифмическая шкала (слайд 2):** Равные вертикальные расстояния представляют равные отношения. Каждый период имеет в десять раз больше запросов, чем предыдущий, поэтому точки образуют прямую восходящую линию на шкале с основанием 10. Метки оси по‑прежнему показывают исходные количества запросов.

![Те же пять количеств запросов в PowerPoint на логарифмической оси значений с основанием 10](value-axis-logarithmic.png)

### **Обработка нулевых и отрицательных значений**

Логарифмическая шкала может отображать только строго положительные значения. Проверьте данные перед её включением. Если нулевые или отрицательные значения имеют смысл, сохраняйте линейную шкалу или отображайте их отдельно. Если исключение этих значений уместно для анализа, объясните пропуск. Не заменяйте их молча небольшими положительными числами, так как это меняет смысл данных. Любой вручную заданный минимум или максимум для логарифмической оси также должен быть положительным.

## **FAQ**

**Как задать значение, в котором одна ось пересекает другую (пересечение осей)?**

Используйте [setCrossType](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCrossType), чтобы выбрать поведение пересечения. Чтобы задать числовое значение пересечения, используйте [setCrossAt](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCrossAt). Эти настройки позволяют переместить пересечение осей к подходящей базовой линии.

**Как можно позиционировать метки делений относительно оси?**

Вызовите [setTickLabelPosition](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setTickLabelPosition) с использованием [TickLabelPositionType](https://reference.aspose.com/slides/python-java/aspose.slides/ticklabelpositiontype/): `Low`, `High`, `NextTo` или `None`. Чтобы управлять самими делениями, используйте [setMajorTickMark](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorTickMark) или [setMinorTickMark](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMinorTickMark); они отделены от позиционирования меток.