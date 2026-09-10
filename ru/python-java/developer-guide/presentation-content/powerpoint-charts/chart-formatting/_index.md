---
title: Форматирование диаграмм презентации в Python
linktitle: Форматирование диаграмм
type: docs
weight: 60
url: /ru/python-java/chart-formatting/
keywords:
- форматировать диаграмму
- форматирование диаграмм
- объект диаграммы
- свойства диаграммы
- настройки диаграммы
- опции диаграммы
- свойства шрифта
- скруглённая граница
- PowerPoint
- презентация
- Python
- Aspose.Slides
description: "Изучите форматирование диаграмм в Aspose.Slides для Python через Java и улучшите свою презентацию PowerPoint профессиональным, привлекающим внимание оформлением."
---
## **Обзор**

В этой статье объясняется, как форматировать диаграммы в презентациях PowerPoint с помощью Aspose.Slides. Показано, как настраивать ключевые элементы диаграммы, такие как оси, линии сетки, заголовки, легенды, область построения и заливку стенок, чтобы улучшить внешний вид и читаемость данных диаграммы.

Также демонстрируется, как установить свойства шрифта для текста диаграммы, применить предустановленные и пользовательские числовые форматы к данным диаграммы и включить скруглённые углы для области диаграммы. Эти примеры показывают, как управлять как визуальным стилем, так и представлением данных диаграмм в презентации.

## **Форматирование объектов диаграммы**
Aspose.Slides for Python via Java позволяет разработчикам создавать пользовательские диаграммы на слайдах с нуля. Эта статья объясняет, как форматировать различные объекты диаграммы, включая категориальную и значимую оси.

Aspose.Slides for Python via Java предоставляет простой API для управления различными объектами диаграммы и их форматирования с использованием пользовательских значений:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/).
1. Получите слайд по его индексу.
1. Добавьте диаграмму нужного типа с данными по умолчанию (в этом примере используется [ChartType.LineWithMarkers](https://reference.aspose.com/slides/ru/python-java/aspose.slides/charttype/#LineWithMarkers)).
1. Получите ось значений диаграммы и установите следующие свойства:
   1. Установите **Line format** для основных линий сетки оси значений.
   1. Установите **Line format** для вторичных линий сетки оси значений.
   1. Установите **Number Format** для оси значений.
   1. Установите **minimum, maximum, major, and minor units** для оси значений.
   1. Установите **Text Properties** для данных оси значений.
   1. Установите **Title** для оси значений.
1. Получите категориальную ось диаграммы и установите следующие свойства:
   1. Установите **Line format** для основных линий сетки категориальной оси.
   1. Установите **Line format** для вторичных линий сетки категориальной оси.
   1. Установите **Text Properties** для данных категориальной оси.
   1. Установите **Title** для категориальной оси.
   1. Установите **Label Positioning** для категориальной оси.
   1. Установите **Rotation Angle** для подписей категориальной оси.
1. Получите легенду диаграммы и задайте её **text properties**.
1. Отобразите легенду диаграммы без перекрытия самой диаграммы.
1. Получите **secondary value axis** диаграммы и установите следующие свойства:
   1. Включите вторичную **value axis**.
   1. Установите **Line Format** для вторичной оси значений.
   1. Установите **Number Format** для вторичной оси значений.
   1. Установите **minimum, maximum, major, and minor units** для вторичной оси значений.
1. Отобразите первую серию диаграммы на вторичной оси значений.
1. Установите цвет заливки задней стенки диаграммы.
1. Установите цвет заливки области построения диаграммы.
1. Запишите изменённую презентацию в файл PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, DisplayUnitType, FillType, FontData, LineDashStyle, LineStyle, NullableBool, Presentation, PresetColor, SaveFormat, TickLabelPositionType

Color = jpype.JClass("java.awt.Color")
nullable_true = NullableBool.True_

# Создайте экземпляр класса Presentation
presentation = Presentation()
try:
    # Получите первый слайд
    slide = presentation.getSlides().get_Item(0)

    # Добавьте пример диаграммы
    chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 50, 50, 500, 400)

    # Установите заголовок диаграммы
    chart.setTitle(True)
    chart.getChartTitle().addTextFrameForOverriding("")
    chart_title = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0)
    chart_title.setText("Sample Chart")
    chart_title.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    chart_title.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY)
    chart_title.getPortionFormat().setFontHeight(20)
    chart_title.getPortionFormat().setFontBold(nullable_true)
    chart_title.getPortionFormat().setFontItalic(nullable_true)

    # Установите формат основных линий сетки для оси значений
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setWidth(5)
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setDashStyle(LineDashStyle.DashDot)

    # Установите формат вторичных линий сетки для оси значений
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED)
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().setWidth(3)

    # Установите числовой формат оси значений
    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(False)
    chart.getAxes().getVerticalAxis().setDisplayUnit(DisplayUnitType.Thousands)
    chart.getAxes().getVerticalAxis().setNumberFormat("0.0%")

    # Установите максимальные и минимальные значения диаграммы
    chart.getAxes().getVerticalAxis().setAutomaticMajorUnit(False)
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(False)
    chart.getAxes().getVerticalAxis().setAutomaticMinorUnit(False)
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(False)

    chart.getAxes().getVerticalAxis().setMaxValue(15)
    chart.getAxes().getVerticalAxis().setMinValue(-2)
    chart.getAxes().getVerticalAxis().setMinorUnit(0.5)
    chart.getAxes().getVerticalAxis().setMajorUnit(2.0)

    # Установите свойства текста оси значений
    value_axis_text = chart.getAxes().getVerticalAxis().getTextFormat().getPortionFormat()
    value_axis_text.setFontBold(nullable_true)
    value_axis_text.setFontHeight(16)
    value_axis_text.setFontItalic(nullable_true)
    value_axis_text.getFillFormat().setFillType(FillType.Solid)
    value_axis_text.getFillFormat().getSolidFillColor().setPresetColor(PresetColor.DarkGreen)
    value_axis_font = FontData("Times New Roman")
    value_axis_text.setLatinFont(value_axis_font)

    # Установите заголовок оси значений
    chart.getAxes().getVerticalAxis().setTitle(True)
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("")
    value_axis_title = chart.getAxes().getVerticalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0)
    value_axis_title.setText("Primary Axis")
    value_axis_title.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    value_axis_title.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY)
    value_axis_title.getPortionFormat().setFontHeight(20)
    value_axis_title.getPortionFormat().setFontBold(nullable_true)
    value_axis_title.getPortionFormat().setFontItalic(nullable_true)

    # Установите формат основных линий сетки для категориальной оси
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.GREEN)
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().setWidth(5)

    # Установите формат вторичных линий сетки для категориальной оси
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.YELLOW)
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().setWidth(3)

    # Установите свойства текста категориальной оси
    category_axis_text = chart.getAxes().getHorizontalAxis().getTextFormat().getPortionFormat()
    category_axis_text.setFontBold(nullable_true)
    category_axis_text.setFontHeight(16)
    category_axis_text.setFontItalic(nullable_true)
    category_axis_text.getFillFormat().setFillType(FillType.Solid)
    category_axis_text.getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    category_axis_font = FontData("Arial")
    category_axis_text.setLatinFont(category_axis_font)

    # Установите заголовок категориальной оси
    chart.getAxes().getHorizontalAxis().setTitle(True)
    chart.getAxes().getHorizontalAxis().getTitle().addTextFrameForOverriding("")

    category_axis_title = chart.getAxes().getHorizontalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0)
    category_axis_title.setText("Sample Category")
    category_axis_title.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    category_axis_title.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY)
    category_axis_title.getPortionFormat().setFontHeight(20)
    category_axis_title.getPortionFormat().setFontBold(nullable_true)
    category_axis_title.getPortionFormat().setFontItalic(nullable_true)

    # Установите позицию подписи категориальной оси
    chart.getAxes().getHorizontalAxis().setTickLabelPosition(TickLabelPositionType.Low)

    # Установите угол поворота подписи категориальной оси
    chart.getAxes().getHorizontalAxis().setTickLabelRotationAngle(45)

    # Установите свойства текста легенды
    legend_text = chart.getLegend().getTextFormat().getPortionFormat()
    legend_text.setFontBold(nullable_true)
    legend_text.setFontHeight(16)
    legend_text.setFontItalic(nullable_true)
    legend_text.getFillFormat().setFillType(FillType.Solid)
    legend_text.getFillFormat().getSolidFillColor().setPresetColor(PresetColor.DarkRed)

    # Показать легенду диаграммы без перекрытия диаграммы

    chart.getLegend().setOverlay(False)

    chart.getChartData().getSeries().get_Item(0).setPlotOnSecondAxis(True)
    # Установите вторичную ось значений
    chart.getAxes().getSecondaryVerticalAxis().setVisible(True)
    chart.getAxes().getSecondaryVerticalAxis().getFormat().getLine().setStyle(LineStyle.ThickBetweenThin)
    chart.getAxes().getSecondaryVerticalAxis().getFormat().getLine().setWidth(20)

    # Установите числовой формат вторичной оси значений
    chart.getAxes().getSecondaryVerticalAxis().setNumberFormatLinkedToSource(False)
    chart.getAxes().getSecondaryVerticalAxis().setDisplayUnit(DisplayUnitType.Hundreds)
    chart.getAxes().getSecondaryVerticalAxis().setNumberFormat("0.0%")

    # Установите максимальные и минимальные значения диаграммы
    chart.getAxes().getSecondaryVerticalAxis().setAutomaticMajorUnit(False)
    chart.getAxes().getSecondaryVerticalAxis().setAutomaticMaxValue(False)
    chart.getAxes().getSecondaryVerticalAxis().setAutomaticMinorUnit(False)
    chart.getAxes().getSecondaryVerticalAxis().setAutomaticMinValue(False)

    chart.getAxes().getSecondaryVerticalAxis().setMaxValue(20)
    chart.getAxes().getSecondaryVerticalAxis().setMinValue(-5)
    chart.getAxes().getSecondaryVerticalAxis().setMinorUnit(0.5)
    chart.getAxes().getSecondaryVerticalAxis().setMajorUnit(2.0)

    # Установите цвет задней стенки диаграммы
    chart.getBackWall().setThickness(1)
    chart.getBackWall().getFormat().getFill().setFillType(FillType.Solid)
    chart.getBackWall().getFormat().getFill().getSolidFillColor().setColor(Color.ORANGE)

    chart.getFloor().getFormat().getFill().setFillType(FillType.Solid)
    chart.getFloor().getFormat().getFill().getSolidFillColor().setColor(Color.RED)
    # Установите цвет области построения
    chart.getPlotArea().getFormat().getFill().setFillType(FillType.Solid)
    chart.getPlotArea().getFormat().getFill().getSolidFillColor().setPresetColor(PresetColor.LightCyan)

    # Сохраните презентацию
    presentation.save("FormattedChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Установка свойств шрифта для диаграммы**
Aspose.Slides for Python via Java поддерживает установку свойств шрифта для диаграмм. Выполните следующие шаги, чтобы задать свойства шрифта:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/).
- Добавьте диаграмму на слайд.
- Установите высоту шрифта.
- Сохраните изменённую презентацию.

Следующий пример демонстрирует эти шаги.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

# Создайте экземпляр класса Presentation
presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 400)

    chart.getTextFormat().getPortionFormat().setFontHeight(20)
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(True)

    presentation.save("FontPropertiesForChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Установка числового формата**
Aspose.Slides for Python via Java предоставляет простой API для управления форматами данных диаграммы:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/).
1. Получите слайд по его индексу.
1. Добавьте диаграмму нужного типа с данными по умолчанию (в этом примере используется [ChartType.ClusteredColumn](https://reference.aspose.com/slides/ru/python-java/aspose.slides/charttype/#ClusteredColumn)).
1. Установите предустановленный числовой формат из доступных предустановленных значений.
1. Пройдитесь по ячейкам данных в каждой серии диаграммы и задайте им числовой формат.
1. Сохраните презентацию.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

# Создайте экземпляр класса Presentation
presentation = Presentation()
try:
    # Получите первый слайд презентации
    slide = presentation.getSlides().get_Item(0)

    # Добавьте стандартную диаграмму сгруппированных столбцов
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 400)

    # Получите коллекцию серий диаграммы
    chart_series_collection = chart.getChartData().getSeries()

    # Пройдите по каждой серии диаграммы
    for chart_series in chart_series_collection:
        # Пройдите по каждой точке данных в серии
        for data_point in chart_series.getDataPoints():
            # Установите числовой формат
            data_point.getValue().getAsCell().setPresetNumberFormat(jpype.JByte(10))  # 0.00%

    # Сохраните презентацию
    presentation.save("PresetNumberFormat.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Ниже перечислены доступные предустановленные числовые форматы и их индексы:

|**0**|General|
| :- | :- |
|**1**|0|
|**2**|0.00|
|**3**|#,##0|
|**4**|#,##0.00|
|**5**|$#,##0;$-#,##0|
|**6**|$#,##0;Red$-#,##0|
|**7**|$#,##0.00;$-#,##0.00|
|**8**|$#,##0.00;Red$-#,##0.00|
|**9**|0%|
|**10**|0.00%|
|**11**|0.00E+00|
|**12**|# ?/?|
|**13**|# /|
|**14**|m/d/yy|
|**15**|d-mmm-yy|
|**16**|d-mmm|
|**17**|mmm-yy|
|**18**|h:mm AM/PM|
|**19**|h:mm:ss AM/PM|
|**20**|h:mm|
|**21**|h:mm:ss|
|**22**|m/d/yy h:mm|
|**37**|#,##0;-#,##0|
|**38**|#,##0;Red-#,##0|
|**39**|#,##0.00;-#,##0.00|
|**40**|#,##0.00;Red-#,##0.00|
|**41**|_ * #,##0_ ;_ * "_ ;_ @_|
|**42**|_ $* #,##0_ ;_ $* "_ ;_ @_|
|**43**|_ * #,##0.00_ ;_ * "??_ ;_ @_|
|**44**|_ $* #,##0.00_ ;_ $* "??_ ;_ @_|
|**45**|mm:ss|
|**46**|h:mm:ss|
|**47**|mm:ss.0|
|**48**|##0.0E+00|
|**49**|@|

## **Установка скруглённых границ области диаграммы**
Aspose.Slides for Python via Java поддерживает скруглённые углы для области диаграммы через методы [hasRoundedCorners](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chart/#hasRoundedCorners) и [setRoundedCorners](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chart/#setRoundedCorners) класса [Chart](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chart/).

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/).
1. Добавьте диаграмму на слайд.
1. Установите тип и стиль заливки линии границы диаграммы.
1. Включите скруглённые углы.
1. Сохраните изменённую презентацию.

Следующий пример демонстрирует эти шаги.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, LineStyle, Presentation, SaveFormat

# Создайте экземпляр класса Presentation
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 100, 600, 400)
    chart.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    chart.getLineFormat().setStyle(LineStyle.Single)
    chart.setRoundedCorners(True)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Могу ли я задать полупрозрачные заливки для столбцов/областей, оставив контур непрозрачным?**

Да. Прозрачность заливки и контур настраиваются отдельно. Это полезно для повышения читаемости сетки и данных в плотных визуализациях.

**Как работать с подписями данных, когда они перекрываются?**

Уменьшите размер шрифта, отключите необязательные компоненты подписи (например, категории), задайте смещение/позицию подписи, при необходимости отображайте подписи только для выбранных точек или переключите формат на «значение + легенда».

**Можно ли применить градиентные или шаблонные заливки к сериям?**

Да. Обычно доступны как сплошные, так и градиентные/шаблонные заливки. На практике используйте градиенты умеренно и избегайте сочетаний, которые снижают контраст сетки и текста.