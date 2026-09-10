---
title: Создание или обновление диаграмм PowerPoint презентаций на Python
linktitle: Создать или обновить диаграммы
type: docs
weight: 10
url: /ru/python-java/create-chart/
keywords:
- добавить диаграмму
- создать диаграмму
- редактировать диаграмму
- изменить диаграмму
- обновить диаграмму
- точечная диаграмма
- круговая диаграмма
- линейная диаграмма
- диаграмма Tree Map
- фондовая диаграмма
- ящичная диаграмма
- воронкообразная диаграмма
- диаграмма Sunburst
- гистограмма
- радарная диаграмма
- мультикатегорийная диаграмма
- PowerPoint
- презентация
- Python
- Java
- Aspose.Slides
description: "Создавайте и настраивайте диаграммы в презентациях PowerPoint с помощью Aspose.Slides для Python через Java. Добавляйте, форматируйте и редактируйте диаграммы с практическими примерами кода на Python."
---
## **Обзор**

В этой статье представлено полное руководство по созданию и настройке диаграмм с помощью Aspose.Slides. Вы узнаете, как программно добавить диаграмму на слайд, заполнить её данными и применить различные параметры форматирования, соответствующие конкретным требованиям дизайна. На протяжении статьи детальные примеры кода иллюстрируют каждый шаг — от инициализации презентации и объекта диаграммы до настройки рядов, осей и легенд. Следуя этому руководству, вы получите прочное понимание того, как интегрировать динамическое создание диаграмм в свои приложения, упростив процесс создания презентаций, основанных на данных.

## **Создание диаграммы**

Диаграммы позволяют быстро визуализировать данные и получить инсайты, которые могут быть неочевидны в таблице или электронной таблице.

**Зачем создавать диаграммы?**

Используя диаграммы, вы можете:

* агрегировать, уплотнять или суммировать большие объёмы данных на одном слайде презентации
* выявлять закономерности и тренды в данных
* определять направление и динамику данных во времени или относительно конкретной единицы измерения
* обнаруживать выбросы, аномалии, отклонения, ошибки, бессмысленные данные и т.п.
* передавать сложные данные в понятном виде

В PowerPoint диаграммы создаются через функцию *Insert*, которая предоставляет шаблоны для проектирования разных типов диаграмм. С помощью Aspose.Slides вы можете создавать как обычные диаграммы (на основе популярных типов), так и пользовательские диаграммы.

{{% alert color="info" title="Note" %}}

Для создания диаграмм используйте класс [ChartType](https://reference.aspose.com/slides/ru/python-java/aspose.slides/charttype/). Поля этого класса соответствуют различным типам диаграмм.

{{% /alert %}}

### **Создание сгруппированных столбчатых диаграмм**

В этом разделе объясняется, как создать сгруппированные столбчатые диаграммы с помощью Aspose.Slides. Вы научитесь инициализировать презентацию, добавить диаграмму и настроить её элементы, такие как заголовок, данные, ряды, категории и стили. Выполните следующие шаги, чтобы увидеть, как генерируется стандартная сгруппированная столбчатая диаграмма:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation).
1. Получите ссылку на слайд, указав его индекс.
1. Добавьте диаграмму с некоторыми данными и укажите тип `ChartType.ClusteredColumn`.
1. Добавьте заголовок к диаграмме.
1. Получите доступ к листу данных диаграммы.
1. Очистите все стандартные ряды и категории.
1. Добавьте новые ряды и категории.
1. Добавьте новые данные диаграммы для рядов.
1. Примените заливку к рядам диаграммы.
1. Добавьте подписи к рядам диаграммы.
1. Сохраните изменённую презентацию в файл PPTX.

Пример кода на C# демонстрирует создание сгруппированной столбчатой диаграммы:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, NullableBool, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

# Создаёт экземпляр класса презентации, представляющего файл PPTX.
presentation = Presentation()
try:
    # Получает первый слайд
    slide = presentation.getSlides().get_Item(0)

    # Добавляет диаграмму с её данными по умолчанию
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 0, 0, 500, 500)

    # Устанавливает заголовок диаграммы
    chart.getChartTitle().addTextFrameForOverriding("Sample Title")
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True_)
    chart.getChartTitle().setHeight(20)
    chart.setTitle(True)

    # Устанавливает индекс листа данных диаграммы
    default_worksheet_index = 0

    # Получает лист данных диаграммы
    workbook = chart.getChartData().getChartDataWorkbook()

    # Удаляет автоматически сгенерированные серии и категории
    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    # Добавляет новые серии
    cell = workbook.getCell(default_worksheet_index, 0, 1, "Series 1")
    chart.getChartData().getSeries().add(cell,chart.getType())
    cell = workbook.getCell(default_worksheet_index, 0, 2, "Series 2")
    chart.getChartData().getSeries().add(cell,chart.getType())

    # Добавляет новые категории
    cell = workbook.getCell(default_worksheet_index, 1, 0, "Category 1")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(default_worksheet_index, 2, 0, "Category 2")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(default_worksheet_index, 3, 0, "Category 3")
    chart.getChartData().getCategories().add(cell)

    # Берёт первую серию диаграммы
    series = chart.getChartData().getSeries().get_Item(0)

    # Теперь заполняет данные серии
    cell = workbook.getCell(default_worksheet_index, 1, 1, 20)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, 2, 1, 50)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, 3, 1, 30)
    series.getDataPoints().addDataPointForBarSeries(cell)

    # Устанавливает цвет заливки для серии
    series.getFormat().getFill().setFillType(FillType.Solid)
    series.getFormat().getFill().getSolidFillColor().setColor(Color.RED)

    # Берёт вторую серию диаграммы
    series = chart.getChartData().getSeries().get_Item(1)

    # Заполняет данные серии
    cell = workbook.getCell(default_worksheet_index, 1, 2, 30)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, 2, 2, 10)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, 3, 2, 60)
    series.getDataPoints().addDataPointForBarSeries(cell)

    # Устанавливает цвет заливки для серии
    series.getFormat().getFill().setFillType(FillType.Solid)
    series.getFormat().getFill().getSolidFillColor().setColor(Color.GREEN)

    #Создаёт пользовательские подписи для каждой категории новой серии
    # Устанавливает первую подпись для отображения названия категории
    label = series.getDataPoints().get_Item(0).getLabel()
    label.getDataLabelFormat().setShowCategoryName(True)

    label = series.getDataPoints().get_Item(1).getLabel()
    label.getDataLabelFormat().setShowSeriesName(True)

    # Отображает значение для третьей подписи
    label = series.getDataPoints().get_Item(2).getLabel()
    label.getDataLabelFormat().setShowValue(True)
    label.getDataLabelFormat().setShowSeriesName(True)
    label.getDataLabelFormat().setSeparator("/")

    # Saves the presentation with chart
    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Создание точечных диаграмм**
Точечные диаграммы (также известные как scatter plots или графики x‑y) часто используют для проверки закономерностей или демонстрации корреляций между двумя переменными.

Используйте точечную диаграмму, когда:

* у вас есть парные числовые данные
* две переменные хорошо сочетаются друг с другом
* вы хотите определить, связаны ли две переменные
* у вас есть независимая переменная, имеющая несколько значений для зависимой переменной

1. Выполните шаги из раздела [Create Clustered Column Charts](#create-clustered-column-charts).
2. На третьем шаге добавьте диаграмму с данными и укажите тип диаграммы из следующих вариантов:
   1. [ChartType.ScatterWithMarkers](https://reference.aspose.com/slides/ru/python-java/aspose.slides/charttype/#ScatterWithMarkers) - _Представляет точечную диаграмму с маркерами._
   2. [ChartType.ScatterWithSmoothLinesAndMarkers](https://reference.aspose.com/slides/ru/python-java/aspose.slides/charttype/#ScatterWithSmoothLinesAndMarkers) - _Представляет точечную диаграмму, соединённую кривыми, с маркерами данных._
   3. [ChartType.ScatterWithSmoothLines](https://reference.aspose.com/slides/ru/python-java/aspose.slides/charttype/#ScatterWithSmoothLines) - _Представляет точечную диаграмму, соединённую кривыми, без маркеров данных._
   4. [ChartType.ScatterWithStraightLinesAndMarkers](https://reference.aspose.com/slides/ru/python-java/aspose.slides/charttype/#ScatterWithStraightLinesAndMarkers) - _Представляет точечную диаграмму, соединённую прямыми линиями, с маркерами данных._
   5. [ChartType.ScatterWithStraightLines](https://reference.aspose.com/slides/ru/python-java/aspose.slides/charttype/#ScatterWithStraightLines) - _Представляет точечную диаграмму, соединённую прямыми линиями, без маркеров данных._

Пример кода на Python показывает, как создать точечную диаграмму с разными маркерами для каждого ряда:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, MarkerStyleType, Presentation, SaveFormat

# Создаёт экземпляр класса презентации, представляющего файл PPTX.
presentation = Presentation()
try:
    # Получает первый слайд
    slide = presentation.getSlides().get_Item(0)

    # Создаёт диаграмму по умолчанию
    chart = slide.getShapes().addChart(ChartType.ScatterWithSmoothLines, 0, 0, 400, 400)

    # Получает индекс листа данных диаграммы по умолчанию
    default_worksheet_index = 0

    # Получает лист данных диаграммы
    workbook = chart.getChartData().getChartDataWorkbook()

    # Удаляет демонстрационную серию
    chart.getChartData().getSeries().clear()

    # Добавляет новые серии
    cell = workbook.getCell(default_worksheet_index, 1, 1, "Series 1")
    chart.getChartData().getSeries().add(cell, chart.getType())
    cell = workbook.getCell(default_worksheet_index, 1, 3, "Series 2")
    chart.getChartData().getSeries().add(cell, chart.getType())

    # Берёт первую серию диаграммы
    series = chart.getChartData().getSeries().get_Item(0)

    # Добавляет новую точку (1:3) в серию
    x_cell = workbook.getCell(default_worksheet_index, 2, 1, 1)
    y_cell = workbook.getCell(default_worksheet_index, 2, 2, 3)
    series.getDataPoints().addDataPointForScatterSeries(x_cell, y_cell)

    # Добавляет новую точку (2:10)
    x_cell = workbook.getCell(default_worksheet_index, 3, 1, 2)
    y_cell = workbook.getCell(default_worksheet_index, 3, 2, 10)
    series.getDataPoints().addDataPointForScatterSeries(x_cell, y_cell)

    # Изменяет тип серии
    series.setType(ChartType.ScatterWithStraightLinesAndMarkers)

    # Изменяет маркер серии диаграммы
    series.getMarker().setSize(10)
    series.getMarker().setSymbol(MarkerStyleType.Star)

    # Берёт вторую серию диаграммы
    series = chart.getChartData().getSeries().get_Item(1)

    # Добавляет новую точку (5:2) туда
    x_cell = workbook.getCell(default_worksheet_index, 2, 3, 5)
    y_cell = workbook.getCell(default_worksheet_index, 2, 4, 2)
    series.getDataPoints().addDataPointForScatterSeries(x_cell, y_cell)

    # Добавляет новую точку (3:1)
    x_cell = workbook.getCell(default_worksheet_index, 3, 3, 3)
    y_cell = workbook.getCell(default_worksheet_index, 3, 4, 1)
    series.getDataPoints().addDataPointForScatterSeries(x_cell, y_cell)

    # Добавляет новую точку (2:2)
    x_cell = workbook.getCell(default_worksheet_index, 4, 3, 2)
    y_cell = workbook.getCell(default_worksheet_index, 4, 4, 2)
    series.getDataPoints().addDataPointForScatterSeries(x_cell, y_cell)

    # Добавляет новую точку (5:1)
    x_cell = workbook.getCell(default_worksheet_index, 5, 3, 5)
    y_cell = workbook.getCell(default_worksheet_index, 5, 4, 1)
    series.getDataPoints().addDataPointForScatterSeries(x_cell, y_cell)

    # Изменяет маркер серии диаграммы
    series.getMarker().setSize(10)
    series.getMarker().setSymbol(MarkerStyleType.Circle)

    presentation.save("AsposeChart_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Создание круговых диаграмм**

Круговые диаграммы лучше использовать для отображения соотношения части к целому, особенно когда данные содержат категориальные метки с числовыми значениями. Однако если данных слишком много, стоит рассмотреть столбчатую диаграмму.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/).
2. Получите ссылку на слайд, указав его индекс.
3. Добавьте диаграмму с данными по умолчанию и укажите тип [ChartType.Pie](https://reference.aspose.com/slides/ru/python-java/aspose.slides/charttype/#Pie).
4. Получите доступ к книге данных диаграммы [ChartDataWorkbook](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chartdataworkbook/).
5. Очистите стандартные ряды и категории.
6. Добавьте новые ряды и категории.
7. Добавьте новые данные диаграммы для рядов.
8. Добавьте новые точки и примените пользовательские цвета к секторам круговой диаграммы.
9. Установите подписи для рядов.
10. Включите линии‑выноски для подписей рядов.
11. Задайте угол поворота секторов круговой диаграммы.
12. Сохраните изменённую презентацию в файл PPTX.

Пример кода на Python демонстрирует создание круговой диаграммы:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, LineDashStyle, LineStyle, NullableBool, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

# Создаёт экземпляр класса презентации, представляющего файл PPTX.
presentation = Presentation()
try:
    # Получает первый слайд
    slide = presentation.getSlides().get_Item(0)

    # Добавляет диаграмму с данными по умолчанию
    chart = slide.getShapes().addChart(ChartType.Pie, 100, 100, 400, 400)

    # Устанавливает заголовок диаграммы
    chart.getChartTitle().addTextFrameForOverriding("Sample Title")
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True_)
    chart.getChartTitle().setHeight(20)
    chart.setTitle(True)

    # Устанавливает индекс листа данных диаграммы
    default_worksheet_index = 0

    # Получает лист данных диаграммы
    workbook = chart.getChartData().getChartDataWorkbook()

    # Удаляет автоматически сгенерированные серии и категории
    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    # Добавляет новые категории
    cell = workbook.getCell(0, 1, 0, "First Qtr")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, 2, 0, "2nd Qtr")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, 3, 0, "3rd Qtr")
    chart.getChartData().getCategories().add(cell)

    # Добавляет новые серии
    cell = workbook.getCell(0, 0, 1, "Series 1")
    series = chart.getChartData().getSeries().add(cell, chart.getType())

    #Заполняет данные серии
    cell = workbook.getCell(default_worksheet_index, 1, 1, 20)
    series.getDataPoints().addDataPointForPieSeries(cell)
    cell = workbook.getCell(default_worksheet_index, 2, 1, 50)
    series.getDataPoints().addDataPointForPieSeries(cell)
    cell = workbook.getCell(default_worksheet_index, 3, 1, 30)
    series.getDataPoints().addDataPointForPieSeries(cell)

    # Добавление новых точек и установка цвета сектора
    chart.getChartData().getSeriesGroups().get_Item(0).setColorVaried(True)

    point = series.getDataPoints().get_Item(0)
    point.getFormat().getFill().setFillType(FillType.Solid)
    point.getFormat().getFill().getSolidFillColor().setColor(Color.CYAN)

    # Устанавливает границу сектора
    point.getFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    point.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.GRAY)
    point.getFormat().getLine().setWidth(3.0)
    point.getFormat().getLine().setStyle(LineStyle.ThinThick)
    point.getFormat().getLine().setDashStyle(LineDashStyle.DashDot)

    second_point = series.getDataPoints().get_Item(1)
    second_point.getFormat().getFill().setFillType(FillType.Solid)
    second_point.getFormat().getFill().getSolidFillColor().setColor(Color.ORANGE)

    # Устанавливает границу сектора
    second_point.getFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    second_point.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    second_point.getFormat().getLine().setWidth(3.0)
    second_point.getFormat().getLine().setStyle(LineStyle.Single)
    second_point.getFormat().getLine().setDashStyle(LineDashStyle.LargeDashDot)

    third_point = series.getDataPoints().get_Item(2)
    third_point.getFormat().getFill().setFillType(FillType.Solid)
    third_point.getFormat().getFill().getSolidFillColor().setColor(Color.YELLOW)

    # Устанавливает границу сектора
    third_point.getFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    third_point.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED)
    third_point.getFormat().getLine().setWidth(2.0)
    third_point.getFormat().getLine().setStyle(LineStyle.ThinThin)
    third_point.getFormat().getLine().setDashStyle(LineDashStyle.LargeDashDotDot)

    # Создаёт пользовательские подписи для каждой категории новой серии
    first_label = series.getDataPoints().get_Item(0).getLabel()

    first_label.getDataLabelFormat().setShowValue(True)

    second_label = series.getDataPoints().get_Item(1).getLabel()
    second_label.getDataLabelFormat().setShowValue(True)
    second_label.getDataLabelFormat().setShowLegendKey(True)
    second_label.getDataLabelFormat().setShowPercentage(True)

    third_label = series.getDataPoints().get_Item(2).getLabel()
    third_label.getDataLabelFormat().setShowSeriesName(True)
    third_label.getDataLabelFormat().setShowPercentage(True)

    # Отображает линии‑выноски для диаграммы
    series.getLabels().getDefaultDataLabelFormat().setShowLeaderLines(True)

    # Устанавливает угол поворота секторов круговой диаграммы
    chart.getChartData().getSeriesGroups().get_Item(0).setFirstSliceAngle(180)

    # Сохраняет презентацию с диаграммой
    presentation.save("PieChart_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Создание линейных диаграмм**

Линейные диаграммы (также известные как line graphs) лучше использовать, когда нужно показать изменения значений во времени. С помощью линейной диаграммы можно сравнить большой объём данных, отслеживать изменения и тренды, выделять аномалии в рядах и многое другое.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/).
1. Получите ссылку на слайд, указав его индекс.
1. Добавьте диаграмму с данными по умолчанию и укажите тип [ChartType.Line](https://reference.aspose.com/slides/ru/python-java/aspose.slides/charttype/#Line).
1. Сохраните изменённую презентацию в файл PPTX.

Пример кода на Python показывает создание линейной диаграммы:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    line_chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 10, 50, 600, 350)

    presentation.save("line_chart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

По умолчанию точки линейной диаграммы соединяются сплошными прямыми линиями. Если хотите соединять их пунктиром, укажите нужный тип штриха следующим образом:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, LineDashStyle, Presentation, SaveFormat

presentation = Presentation()
try:
    line_chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 10, 50, 600, 350)

    for series in line_chart.getChartData().getSeries():
        series.getFormat().getLine().setDashStyle(LineDashStyle.Dash)

    presentation.save("line_chart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Создание иерархических диаграмм (Tree Map)**

Иерархические диаграммы лучше всего подходят для данных о продажах, когда нужно показать относительный размер категорий и быстро привлечь внимание к крупным вкладам внутри каждой категории.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/).
2. Получите ссылку на слайд, указав его индекс.
3. Добавьте диаграмму с данными по умолчанию и укажите тип [ChartType.Treemap](https://reference.aspose.com/slides/ru/python-java/aspose.slides/charttype/#Treemap).
4. Получите доступ к книге данных диаграммы [ChartDataWorkbook](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chartdataworkbook/).
5. Очистите стандартные ряды и категории.
6. Добавьте новые ряды и категории.
7. Добавьте новые данные диаграммы для рядов.
8. Сохраните изменённую презентацию в файл PPTX.

Пример кода на Python показывает создание иерархической диаграммы:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, ParentLabelLayoutType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Treemap, 50, 50, 500, 400)
    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    #ветка 1
    cell = workbook.getCell(0, "C1", "Leaf1")
    leaf = chart.getChartData().getCategories().add(cell)
    leaf.getGroupingLevels().setGroupingItem(1, "Stem1")
    leaf.getGroupingLevels().setGroupingItem(2, "Branch1")

    cell = workbook.getCell(0, "C2", "Leaf2")
    chart.getChartData().getCategories().add(cell)

    cell = workbook.getCell(0, "C3", "Leaf3")
    leaf = chart.getChartData().getCategories().add(cell)
    leaf.getGroupingLevels().setGroupingItem(1, "Stem2")

    cell = workbook.getCell(0, "C4", "Leaf4")
    chart.getChartData().getCategories().add(cell)

    #ветка 2
    cell = workbook.getCell(0, "C5", "Leaf5")
    leaf = chart.getChartData().getCategories().add(cell)
    leaf.getGroupingLevels().setGroupingItem(1, "Stem3")
    leaf.getGroupingLevels().setGroupingItem(2, "Branch2")

    cell = workbook.getCell(0, "C6", "Leaf6")
    chart.getChartData().getCategories().add(cell)

    cell = workbook.getCell(0, "C7", "Leaf7")
    leaf = chart.getChartData().getCategories().add(cell)
    leaf.getGroupingLevels().setGroupingItem(1, "Stem4")

    cell = workbook.getCell(0, "C8", "Leaf8")
    chart.getChartData().getCategories().add(cell)

    series = chart.getChartData().getSeries().add(ChartType.Treemap)
    series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(True)
    cell = workbook.getCell(0, "D1", 4)
    series.getDataPoints().addDataPointForTreemapSeries(cell)
    cell = workbook.getCell(0, "D2", 5)
    series.getDataPoints().addDataPointForTreemapSeries(cell)
    cell = workbook.getCell(0, "D3", 3)
    series.getDataPoints().addDataPointForTreemapSeries(cell)
    cell = workbook.getCell(0, "D4", 6)
    series.getDataPoints().addDataPointForTreemapSeries(cell)
    cell = workbook.getCell(0, "D5", 9)
    series.getDataPoints().addDataPointForTreemapSeries(cell)
    cell = workbook.getCell(0, "D6", 9)
    series.getDataPoints().addDataPointForTreemapSeries(cell)
    cell = workbook.getCell(0, "D7", 4)
    series.getDataPoints().addDataPointForTreemapSeries(cell)
    cell = workbook.getCell(0, "D8", 3)
    series.getDataPoints().addDataPointForTreemapSeries(cell)

    series.setParentLabelLayout(ParentLabelLayoutType.Overlapping)

    presentation.save("Treemap.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Создание фондовых диаграмм**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/).
2. Получите ссылку на слайд, указав его индекс.
3. Добавьте диаграмму с данными по умолчанию и укажите тип [ChartType.OpenHighLowClose](https://reference.aspose.com/slides/ru/python-java/aspose.slides/charttype/#OpenHighLowClose).
4. Получите доступ к книге данных диаграммы [ChartDataWorkbook](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chartdataworkbook/).
5. Очистите стандартные ряды и категории.
6. Добавьте новые ряды и категории.
7. Добавьте новые данные диаграммы для рядов.
8. Укажите формат линий high‑low.
9. Сохраните изменённую презентацию в файл PPTX.

Пример кода на Python демонстрирует создание фондовой диаграммы:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.OpenHighLowClose, 50, 50, 600, 400, False)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()

    cell = workbook.getCell(0, 1, 0, "A")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, 2, 0, "B")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, 3, 0, "C")
    chart.getChartData().getCategories().add(cell)

    cell = workbook.getCell(0, 0, 1, "Open")
    chart.getChartData().getSeries().add(cell, chart.getType())
    cell = workbook.getCell(0, 0, 2, "High")
    chart.getChartData().getSeries().add(cell, chart.getType())
    cell = workbook.getCell(0, 0, 3, "Low")
    chart.getChartData().getSeries().add(cell, chart.getType())
    cell = workbook.getCell(0, 0, 4, "Close")
    chart.getChartData().getSeries().add(cell, chart.getType())

    series = chart.getChartData().getSeries().get_Item(0)

    cell = workbook.getCell(0, 1, 1, 72)
    series.getDataPoints().addDataPointForStockSeries(cell)
    cell = workbook.getCell(0, 2, 1, 25)
    series.getDataPoints().addDataPointForStockSeries(cell)
    cell = workbook.getCell(0, 3, 1, 38)
    series.getDataPoints().addDataPointForStockSeries(cell)

    series = chart.getChartData().getSeries().get_Item(1)
    cell = workbook.getCell(0, 1, 2, 172)
    series.getDataPoints().addDataPointForStockSeries(cell)
    cell = workbook.getCell(0, 2, 2, 57)
    series.getDataPoints().addDataPointForStockSeries(cell)
    cell = workbook.getCell(0, 3, 2, 57)
    series.getDataPoints().addDataPointForStockSeries(cell)

    series = chart.getChartData().getSeries().get_Item(2)
    cell = workbook.getCell(0, 1, 3, 12)
    series.getDataPoints().addDataPointForStockSeries(cell)
    cell = workbook.getCell(0, 2, 3, 12)
    series.getDataPoints().addDataPointForStockSeries(cell)
    cell = workbook.getCell(0, 3, 3, 13)
    series.getDataPoints().addDataPointForStockSeries(cell)

    series = chart.getChartData().getSeries().get_Item(3)
    cell = workbook.getCell(0, 1, 4, 25)
    series.getDataPoints().addDataPointForStockSeries(cell)
    cell = workbook.getCell(0, 2, 4, 38)
    series.getDataPoints().addDataPointForStockSeries(cell)
    cell = workbook.getCell(0, 3, 4, 50)
    series.getDataPoints().addDataPointForStockSeries(cell)

    chart.getChartData().getSeriesGroups().get_Item(0).getUpDownBars().setUpDownBars(True)
    chart.getChartData().getSeriesGroups().get_Item(0).getHiLowLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid)

    for series in chart.getChartData().getSeries():
        series.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Создание диаграмм «box‑and‑whisker»**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/).
2. Получите ссылку на слайд, указав его индекс.
3. Добавьте диаграмму с данными по умолчанию и укажите тип [ChartType.BoxAndWhisker](https://reference.aspose.com/slides/ru/python-java/aspose.slides/charttype/#BoxAndWhisker).
4. Получите доступ к книге данных диаграммы [ChartDataWorkbook](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chartdataworkbook/).
5. Очистите стандартные ряды и категории.
6. Добавьте новые ряды и категории.
7. Добавьте новые данные диаграммы для рядов.
8. Сохраните изменённую презентацию в файл PPTX.

Пример кода на Python показывает создание диаграммы «box‑and‑whisker»:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, QuartileMethodType, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.BoxAndWhisker, 50, 50, 500, 400)
    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    cell = workbook.getCell(0, "A1", "Category 1")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, "A2", "Category 1")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, "A3", "Category 1")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, "A4", "Category 1")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, "A5", "Category 1")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, "A6", "Category 1")
    chart.getChartData().getCategories().add(cell)

    series = chart.getChartData().getSeries().add(ChartType.BoxAndWhisker)

    series.setQuartileMethod(QuartileMethodType.Exclusive)
    series.setShowMeanLine(True)
    series.setShowMeanMarkers(True)
    series.setShowInnerPoints(True)
    series.setShowOutlierPoints(True)

    cell = workbook.getCell(0, "B1", 15)
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(cell)
    cell = workbook.getCell(0, "B2", 41)
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(cell)
    cell = workbook.getCell(0, "B3", 16)
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(cell)
    cell = workbook.getCell(0, "B4", 10)
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(cell)
    cell = workbook.getCell(0, "B5", 23)
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(cell)
    cell = workbook.getCell(0, "B6", 16)
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(cell)

    presentation.save("BoxAndWhisker.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Создание воронкообразных диаграмм**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/).
2. Получите ссылку на слайд, указав его индекс.
3. Добавьте диаграмму с данными по умолчанию и укажите тип [ChartType.Funnel](https://reference.aspose.com/slides/ru/python-java/aspose.slides/charttype/#Funnel).
4. Сохраните изменённую презентацию в файл PPTX.

Пример кода на Python демонстрирует создание воронкообразной диаграммы:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Funnel, 50, 50, 500, 400)
    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()

    workbook.clear(0)

    cell = workbook.getCell(0, "A1", "Category 1")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, "A2", "Category 2")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, "A3", "Category 3")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, "A4", "Category 4")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, "A5", "Category 5")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, "A6", "Category 6")
    chart.getChartData().getCategories().add(cell)

    series = chart.getChartData().getSeries().add(ChartType.Funnel)

    cell = workbook.getCell(0, "B1", 50)
    series.getDataPoints().addDataPointForFunnelSeries(cell)
    cell = workbook.getCell(0, "B2", 100)
    series.getDataPoints().addDataPointForFunnelSeries(cell)
    cell = workbook.getCell(0, "B3", 200)
    series.getDataPoints().addDataPointForFunnelSeries(cell)
    cell = workbook.getCell(0, "B4", 300)
    series.getDataPoints().addDataPointForFunnelSeries(cell)
    cell = workbook.getCell(0, "B5", 400)
    series.getDataPoints().addDataPointForFunnelSeries(cell)
    cell = workbook.getCell(0, "B6", 500)
    series.getDataPoints().addDataPointForFunnelSeries(cell)

    presentation.save("Funnel.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Создание радиальных диаграмм (Sunburst)**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/).
2. Получите ссылку на слайд, указав его индекс.
3. Добавьте диаграмму с данными по умолчанию и укажите тип [ChartType.Sunburst](https://reference.aspose.com/slides/ru/python-java/aspose.slides/charttype/#Sunburst).
4. Сохраните изменённую презентацию в файл PPTX.

Пример кода на Python показывает создание радиальной (sunburst) диаграммы:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Sunburst, 50, 50, 500, 400)
    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    #ветка 1
    cell = workbook.getCell(0, "C1", "Leaf1")
    leaf = chart.getChartData().getCategories().add(cell)
    leaf.getGroupingLevels().setGroupingItem(1, "Stem1")
    leaf.getGroupingLevels().setGroupingItem(2, "Branch1")

    cell = workbook.getCell(0, "C2", "Leaf2")
    chart.getChartData().getCategories().add(cell)

    cell = workbook.getCell(0, "C3", "Leaf3")
    leaf = chart.getChartData().getCategories().add(cell)
    leaf.getGroupingLevels().setGroupingItem(1, "Stem2")

    cell = workbook.getCell(0, "C4", "Leaf4")
    chart.getChartData().getCategories().add(cell)

    #ветка 2
    cell = workbook.getCell(0, "C5", "Leaf5")
    leaf = chart.getChartData().getCategories().add(cell)
    leaf.getGroupingLevels().setGroupingItem(1, "Stem3")
    leaf.getGroupingLevels().setGroupingItem(2, "Branch2")

    cell = workbook.getCell(0, "C6", "Leaf6")
    chart.getChartData().getCategories().add(cell)

    cell = workbook.getCell(0, "C7", "Leaf7")
    leaf = chart.getChartData().getCategories().add(cell)
    leaf.getGroupingLevels().setGroupingItem(1, "Stem4")

    cell = workbook.getCell(0, "C8", "Leaf8")
    chart.getChartData().getCategories().add(cell)

    series = chart.getChartData().getSeries().add(ChartType.Sunburst)
    series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(True)
    cell = workbook.getCell(0, "D1", 4)
    series.getDataPoints().addDataPointForSunburstSeries(cell)
    cell = workbook.getCell(0, "D2", 5)
    series.getDataPoints().addDataPointForSunburstSeries(cell)
    cell = workbook.getCell(0, "D3", 3)
    series.getDataPoints().addDataPointForSunburstSeries(cell)
    cell = workbook.getCell(0, "D4", 6)
    series.getDataPoints().addDataPointForSunburstSeries(cell)
    cell = workbook.getCell(0, "D5", 9)
    series.getDataPoints().addDataPointForSunburstSeries(cell)
    cell = workbook.getCell(0, "D6", 9)
    series.getDataPoints().addDataPointForSunburstSeries(cell)
    cell = workbook.getCell(0, "D7", 4)
    series.getDataPoints().addDataPointForSunburstSeries(cell)
    cell = workbook.getCell(0, "D8", 3)
    series.getDataPoints().addDataPointForSunburstSeries(cell)

    presentation.save("Sunburst.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Создание гистограмм**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/).
2. Получите ссылку на слайд, указав его индекс.
3. Добавьте диаграмму с данными по умолчанию и укажите тип [ChartType.Histogram](https://reference.aspose.com/slides/ru/python-java/aspose.slides/charttype/#Histogram).
4. Получите доступ к книге данных диаграммы [ChartDataWorkbook](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chartdataworkbook/).
5. Очистите стандартные ряды и категории.
6. Добавьте новые ряды и категории.
7. Сохраните изменённую презентацию в файл PPTX.

Пример кода на Python демонстрирует создание гистограммы:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AxisAggregationType, ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Histogram, 50, 50, 500, 400)
    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    series = chart.getChartData().getSeries().add(ChartType.Histogram)
    cell = workbook.getCell(0, "A1", 15)
    series.getDataPoints().addDataPointForHistogramSeries(cell)
    cell = workbook.getCell(0, "A2", -41)
    series.getDataPoints().addDataPointForHistogramSeries(cell)
    cell = workbook.getCell(0, "A3", 16)
    series.getDataPoints().addDataPointForHistogramSeries(cell)
    cell = workbook.getCell(0, "A4", 10)
    series.getDataPoints().addDataPointForHistogramSeries(cell)
    cell = workbook.getCell(0, "A5", -23)
    series.getDataPoints().addDataPointForHistogramSeries(cell)
    cell = workbook.getCell(0, "A6", 16)
    series.getDataPoints().addDataPointForHistogramSeries(cell)

    chart.getAxes().getHorizontalAxis().setAggregationType(AxisAggregationType.Automatic)

    presentation.save("Histogram.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Создание радиальных (Radar) диаграмм**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/).
2. Получите ссылку на слайд, указав его индекс.
3. Добавьте диаграмму с данными и укажите желаемый тип диаграммы ([ChartType.Radar](https://reference.aspose.com/slides/ru/python-java/aspose.slides/charttype/#Radar) в данном случае).
4. Сохраните изменённую презентацию в файл PPTX.

Пример кода на Python показывает создание радиальной диаграммы:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Radar, 20, 20, 400, 300)
    presentation.save("Radar-chart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Создание мультикатегорийных диаграмм**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/).
2. Получите ссылку на слайд, указав его индекс.
3. Добавьте диаграмму с данными по умолчанию и укажите тип [ChartType.ClusteredColumn](https://reference.aspose.com/slides/ru/python-java/aspose.slides/charttype/#ClusteredColumn).
4. Получите доступ к книге данных диаграммы [ChartDataWorkbook](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chartdataworkbook/).
5. Очистите стандартные ряды и категории.
6. Добавьте новые ряды и категории.
7. Добавьте новые данные диаграммы для рядов.
8. Сохраните изменённую презентацию в файл PPTX.

Пример кода на Python показывает создание мультикатегорийной диаграммы:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 600, 450)
    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)
    default_worksheet_index = 0

    cell = workbook.getCell(0, "c2", "A")
    category = chart.getChartData().getCategories().add(cell)
    category.getGroupingLevels().setGroupingItem(1, "Group1")
    cell = workbook.getCell(0, "c3", "B")
    category = chart.getChartData().getCategories().add(cell)

    cell = workbook.getCell(0, "c4", "C")
    category = chart.getChartData().getCategories().add(cell)
    category.getGroupingLevels().setGroupingItem(1, "Group2")
    cell = workbook.getCell(0, "c5", "D")
    category = chart.getChartData().getCategories().add(cell)

    cell = workbook.getCell(0, "c6", "E")
    category = chart.getChartData().getCategories().add(cell)
    category.getGroupingLevels().setGroupingItem(1, "Group3")
    cell = workbook.getCell(0, "c7", "F")
    category = chart.getChartData().getCategories().add(cell)

    cell = workbook.getCell(0, "c8", "G")
    category = chart.getChartData().getCategories().add(cell)
    category.getGroupingLevels().setGroupingItem(1, "Group4")
    cell = workbook.getCell(0, "c9", "H")
    category = chart.getChartData().getCategories().add(cell)

    # Добавление серии
    cell = workbook.getCell(0, "D1", "Series 1")
    series = chart.getChartData().getSeries().add(cell, ChartType.ClusteredColumn)

    cell = workbook.getCell(default_worksheet_index, "D2", 10)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, "D3", 20)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, "D4", 30)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, "D5", 40)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, "D6", 50)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, "D7", 60)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, "D8", 70)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, "D9", 80)
    series.getDataPoints().addDataPointForBarSeries(cell)

    # Сохранить презентацию с диаграммой
    presentation.save("AsposeChart_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Создание картографических диаграмм**

Картографические диаграммы визуализируют географические данные и помогают сравнивать значения по регионам.

Пример кода на Python демонстрирует создание картографической диаграммы:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Map, 50, 50, 500, 400)
    presentation.save("mapChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Создание комбинированных диаграмм**

Комбинированная диаграмма (combo chart) объединяет два и более типа диаграмм в одном графике. Такая диаграмма позволяет выделять, сравнивать или анализировать различия между несколькими наборами данных, помогая выявлять их взаимосвязи.

![The combination chart](combination_chart.png)

Следующий код на Python показывает, как создать показанную выше комбинированную диаграмму в презентации PowerPoint:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AxisPositionType, ChartType, CrossesType, FillType, LegendPositionType, NullableBool, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

def create_combo_chart():
    presentation = Presentation()
    slide = presentation.getSlides().get_Item(0)
    try:
        chart = create_chart_with_first_series(slide)

        add_second_series_to_chart(chart)
        add_third_series_to_chart(chart)

        set_primary_axes_format(chart)
        set_secondary_axes_format(chart)

        presentation.save("combo-chart.pptx", SaveFormat.Pptx)
    finally:
        presentation.dispose()

def create_chart_with_first_series(slide):
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)

    # Установить заголовок диаграммы.
    chart.setTitle(True)
    chart.getChartTitle().addTextFrameForOverriding("Chart Title")
    chart.getChartTitle().setOverlay(False)
    title_paragraph = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0)
    title_format = title_paragraph.getParagraphFormat().getDefaultPortionFormat()
    title_format.setFontBold(NullableBool.False_)
    title_format.setFontHeight(18.0)

    # Установить легенду диаграммы.
    chart.getLegend().setPosition(LegendPositionType.Bottom)
    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(12.0)

    # Удалить автоматически сгенерированные серии и категории.
    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    worksheet_index = 0
    workbook = chart.getChartData().getChartDataWorkbook()

    # Добавить новые категории.
    cell = workbook.getCell(worksheet_index, 1, 0, "Category 1")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(worksheet_index, 2, 0, "Category 2")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(worksheet_index, 3, 0, "Category 3")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(worksheet_index, 4, 0, "Category 4")
    chart.getChartData().getCategories().add(cell)

    # Добавить первую серию.
    series_name_cell = workbook.getCell(worksheet_index, 0, 1, "Series 1")
    series = chart.getChartData().getSeries().add(series_name_cell, chart.getType())

    series.getParentSeriesGroup().setOverlap(jpype.JByte(-25))
    series.getParentSeriesGroup().setGapWidth(220)

    cell = workbook.getCell(worksheet_index, 1, 1, 4.3)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(worksheet_index, 2, 1, 2.5)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(worksheet_index, 3, 1, 3.5)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(worksheet_index, 4, 1, 4.5)
    series.getDataPoints().addDataPointForBarSeries(cell)

    return chart

def add_second_series_to_chart(chart):
    workbook = chart.getChartData().getChartDataWorkbook()
    worksheet_index = 0

    series_name_cell = workbook.getCell(worksheet_index, 0, 2, "Series 2")
    series = chart.getChartData().getSeries().add(series_name_cell, ChartType.ClusteredColumn)

    series.getParentSeriesGroup().setOverlap(jpype.JByte(-25))
    series.getParentSeriesGroup().setGapWidth(220)

    cell = workbook.getCell(worksheet_index, 1, 2, 2.4)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(worksheet_index, 2, 2, 4.4)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(worksheet_index, 3, 2, 1.8)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(worksheet_index, 4, 2, 2.8)
    series.getDataPoints().addDataPointForBarSeries(cell)

def add_third_series_to_chart(chart):
    workbook = chart.getChartData().getChartDataWorkbook()
    worksheet_index = 0

    series_name_cell = workbook.getCell(worksheet_index, 0, 3, "Series 3")
    series = chart.getChartData().getSeries().add(series_name_cell, ChartType.Line)

    cell = workbook.getCell(worksheet_index, 1, 3, 2.0)
    series.getDataPoints().addDataPointForLineSeries(cell)
    cell = workbook.getCell(worksheet_index, 2, 3, 2.0)
    series.getDataPoints().addDataPointForLineSeries(cell)
    cell = workbook.getCell(worksheet_index, 3, 3, 3.0)
    series.getDataPoints().addDataPointForLineSeries(cell)
    cell = workbook.getCell(worksheet_index, 4, 3, 5.0)
    series.getDataPoints().addDataPointForLineSeries(cell)

    series.setPlotOnSecondAxis(True)

def set_primary_axes_format(chart):
    # Установить горизонтальную ось.
    horizontal_axis = chart.getAxes().getHorizontalAxis()
    horizontal_axis.getTextFormat().getPortionFormat().setFontHeight(12.0)
    horizontal_axis.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill)

    set_axis_title(horizontal_axis, "X Axis")

    # Установить вертикальную ось.
    vertical_axis = chart.getAxes().getVerticalAxis()
    vertical_axis.getTextFormat().getPortionFormat().setFontHeight(12.0)
    vertical_axis.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill)

    set_axis_title(vertical_axis, "Y Axis 1")

    # Установить цвет основных линий сетки вертикальной оси.
    major_grid_lines_format = vertical_axis.getMajorGridLinesFormat().getLine().getFillFormat()
    major_grid_lines_format.setFillType(FillType.Solid)
    color = Color(217, 217, 217)
    major_grid_lines_format.getSolidFillColor().setColor(color)

def set_secondary_axes_format(chart):
    # Установить вторичную горизонтальную ось.
    secondary_horizontal_axis = chart.getAxes().getSecondaryHorizontalAxis()
    secondary_horizontal_axis.setPosition(AxisPositionType.Bottom)
    secondary_horizontal_axis.setCrossType(CrossesType.Maximum)
    secondary_horizontal_axis.setVisible(False)
    secondary_horizontal_axis.getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill)
    secondary_horizontal_axis.getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill)

    # Установить вторичную вертикальную ось.
    secondary_vertical_axis = chart.getAxes().getSecondaryVerticalAxis()
    secondary_vertical_axis.setPosition(AxisPositionType.Right)
    secondary_vertical_axis.getTextFormat().getPortionFormat().setFontHeight(12.0)
    secondary_vertical_axis.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill)
    secondary_vertical_axis.getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill)
    secondary_vertical_axis.getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill)

    set_axis_title(secondary_vertical_axis, "Y Axis 2")

def set_axis_title(axis, axis_title):
    axis.setTitle(True)
    axis.getTitle().setOverlay(False)
    title_paragraph = axis.getTitle().addTextFrameForOverriding(axis_title).getParagraphs().get_Item(0)
    title_format = title_paragraph.getParagraphFormat().getDefaultPortionFormat()
    title_format.setFontBold(NullableBool.False_)
    title_format.setFontHeight(12.0)

create_combo_chart()
```

## **Обновление диаграмм**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/) — это презентация, содержащая диаграмму, которую нужно обновить.
2. Получите ссылку на слайд, указав его индекс.
3. Пройдитесь по всем фигурам, чтобы найти нужную диаграмму.
4. Получите доступ к листу данных диаграммы.
5. Измените данные ряда, изменив значения.
6. Добавьте новый ряд и заполните его данными.
7. Сохраните изменённую презентацию в файл PPTX.

Пример кода на Python демонстрирует обновление диаграммы:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

# Открывает презентацию, содержащую диаграмму для обновления
presentation = Presentation("ExistingChart.pptx")
try:
    # Получает первый слайд
    slide = presentation.getSlides().get_Item(0)

    # Получает диаграмму со слайда
    chart = slide.getShapes().get_Item(0)

    # Устанавливает индекс листа данных диаграммы
    default_worksheet_index = 0

    # Получает лист данных диаграммы
    workbook = chart.getChartData().getChartDataWorkbook()

    # Изменяет название категории диаграммы
    workbook.getCell(default_worksheet_index, 1, 0, "Modified Category 1")
    workbook.getCell(default_worksheet_index, 2, 0, "Modified Category 2")

    # Берёт первую серию диаграммы
    series = chart.getChartData().getSeries().get_Item(0)

    # Теперь обновляем данные серии
    workbook.getCell(default_worksheet_index, 0, 1, "New_Series1")# Изменение имени серии
    series.getDataPoints().get_Item(0).getValue().setData(90)
    series.getDataPoints().get_Item(1).getValue().setData(123)
    series.getDataPoints().get_Item(2).getValue().setData(44)

    # Берёт вторую серию диаграммы
    series = chart.getChartData().getSeries().get_Item(1)

    # Теперь обновляем данные серии
    workbook.getCell(default_worksheet_index, 0, 2, "New_Series2")# Изменение имени серии
    series.getDataPoints().get_Item(0).getValue().setData(23)
    series.getDataPoints().get_Item(1).getValue().setData(67)
    series.getDataPoints().get_Item(2).getValue().setData(99)

    # Теперь добавляем новую серию
    cell = workbook.getCell(default_worksheet_index, 0, 3, "Series 3")
    chart.getChartData().getSeries().add(cell, chart.getType())

    # Берёт третью серию диаграммы
    series = chart.getChartData().getSeries().get_Item(2)

    # Теперь заполняем данные серии
    cell = workbook.getCell(default_worksheet_index, 1, 3, 20)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, 2, 3, 50)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, 3, 3, 30)
    series.getDataPoints().addDataPointForBarSeries(cell)

    chart.setType(ChartType.ClusteredCylinder)

    # Сохраняет презентацию с диаграммой
    presentation.save("AsposeChartModified_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Установка диапазона данных для диаграммы**

Чтобы задать диапазон данных для диаграммы, выполните следующее:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/) — это презентация, содержащая диаграмму.
2. Получите ссылку на слайд, указав его индекс.
3. Пройдитесь по всем фигурам, чтобы найти нужную диаграмму.
4. Получите доступ к данным диаграммы и задайте диапазон.
5. Сохраните изменённую презентацию в файл PPTX.

Пример кода на Python показывает, как установить диапазон данных для диаграммы:

```python
import jpage
import asposeslides

if not jpage.isJVMStarted():
    jpage.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Открывает презентацию, содержащую диаграмму
presentation = Presentation("ExistingChart.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().get_Item(0)

    chart.getChartData().setRange("Sheet1!A1:B4")

    presentation.save("SetDataRange_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Использование стандартных маркеров в диаграммах**

При использовании стандартных маркеров каждая серия диаграммы автоматически получает различный символ маркера.

Пример кода на Python показывает автоматическую установку маркера для серии диаграммы:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 10, 10, 400, 400)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    cell = workbook.getCell(0, 0, 1, "Series 1")
    chart.getChartData().getSeries().add(cell, chart.getType())
    series = chart.getChartData().getSeries().get_Item(0)

    cell = workbook.getCell(0, 1, 0, "C1")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, 1, 1, 24)
    series.getDataPoints().addDataPointForLineSeries(cell)
    cell = workbook.getCell(0, 2, 0, "C2")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, 2, 1, 23)
    series.getDataPoints().addDataPointForLineSeries(cell)
    cell = workbook.getCell(0, 3, 0, "C3")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, 3, 1, -10)
    series.getDataPoints().addDataPointForLineSeries(cell)
    cell = workbook.getCell(0, 4, 0, "C4")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, 4, 1, None)
    series.getDataPoints().addDataPointForLineSeries(cell)

    cell = workbook.getCell(0, 0, 2, "Series 2")
    chart.getChartData().getSeries().add(cell, chart.getType())
    #Возьмите вторую серию диаграммы
    second_series = chart.getChartData().getSeries().get_Item(1)

    #Сейчас заполняем данные серии
    cell = workbook.getCell(0, 1, 2, 30)
    second_series.getDataPoints().addDataPointForLineSeries(cell)
    cell = workbook.getCell(0, 2, 2, 10)
    second_series.getDataPoints().addDataPointForLineSeries(cell)
    cell = workbook.getCell(0, 3, 2, 60)
    second_series.getDataPoints().addDataPointForLineSeries(cell)
    cell = workbook.getCell(0, 4, 2, 40)
    second_series.getDataPoints().addDataPointForLineSeries(cell)

    chart.setLegend(True)
    chart.getLegend().setOverlay(False)

    presentation.save("DefaultMarkersInChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Какие типы диаграмм поддерживает Aspose.Slides?**

Aspose.Slides поддерживает широкий спектр [типов диаграмм](https://reference.aspose.com/slides/ru/python-java/aspose.slides/charttype/), включая столбчатые, линейные, круговые, областные, точечные, гистограммы, радиальные и многие другие. Такая гибкость позволяет выбрать наиболее подходящий тип для визуализации ваших данных.

**Как добавить новую диаграмму на слайд?**

Чтобы добавить диаграмму, сначала создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/), получите нужный слайд по индексу, а затем вызовите метод добавления диаграммы, указав тип диаграммы и начальные данные. Этот процесс интегрирует диаграмму непосредственно в вашу презентацию.

**Как обновить данные, отображаемые в диаграмме?**

Вы можете обновить данные диаграммы, получив доступ к её книге данных ([ChartDataWorkbook](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chartdataworkbook/)), очистив стандартные ряды и категории, а затем добавив свои собственные данные. Это позволяет актуализировать диаграмму в соответствии с новыми данными.

**Можно ли изменить внешний вид диаграммы?**

Да, Aspose.Slides предоставляет обширные возможности настройки. Вы можете изменять цвета, шрифты, подписи, легенды и другие [элементы форматирования](/slides/ru/python-java/chart-entities/), адаптируя внешний вид диаграммы под конкретные требования дизайна.