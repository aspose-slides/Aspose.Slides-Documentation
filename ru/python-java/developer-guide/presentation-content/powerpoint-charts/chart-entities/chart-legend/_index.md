---
title: Настройка легенд диаграмм в презентациях с использованием Python
linktitle: Легенда диаграммы
type: docs
url: /ru/python-java/chart-legend/
keywords:
- легенда диаграммы
- позиция легенды
- размер шрифта
- PowerPoint
- презентация
- Python
- Java
- Aspose.Slides
description: "Настраивайте легенды диаграмм с Aspose.Slides для Python через Java, чтобы оптимизировать презентации PowerPoint с индивидуальным форматированием легенд."
---
## **Обзор**

Aspose.Slides for Python via Java предоставляет возможности настройки легенд диаграмм в презентациях PowerPoint. В этой статье показано, как задать позицию и размер легенды, установить размер шрифта для всей легенды, отформатировать отдельный элемент легенды и скрыть или восстановить выбранные элементы.

Раздел FAQ охватывает связанные поведения, включая резервирование места для легенды, отображение многострочных меток и наследование форматирования из темы презентации.

## **Позиционирование легенды**

Используйте методы легенды [setX](https://reference.aspose.com/slides/python-java/aspose.slides/legend/#setX), [setY](https://reference.aspose.com/slides/python-java/aspose.slides/legend/#setY), [setWidth](https://reference.aspose.com/slides/python-java/aspose.slides/legend/#setWidth) и [setHeight](https://reference.aspose.com/slides/python-java/aspose.slides/legend/#setHeight) для указания её позиции и размеров в долях от размеров диаграммы.

В этом примере создаётся презентация и добавляется сгруппированная столбчатая диаграмма с данными по умолчанию на первый слайд. Деление желаемых смещений и размеров легенды на ширину и высоту диаграммы преобразует их в относительные значения: легенда смещена на 50 пунктов от левого верхнего угла диаграммы и имеет размер 100 × 100 пунктов.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 500)

    # Выражение позиции и размера легенды относительно диаграммы.
    chart.getLegend().setX(50 / chart.getWidth())
    chart.getLegend().setY(50 / chart.getHeight())
    chart.getLegend().setWidth(100 / chart.getWidth())
    chart.getLegend().setHeight(100 / chart.getHeight())

    presentation.save("legend_position.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Установить размер шрифта легенды**

Используйте метод легенды [getTextFormat](https://reference.aspose.com/slides/python-java/aspose.slides/legend/#getTextFormat) для доступа к её форматированию текста и [setFontHeight](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setFontHeight) для установки размера шрифта в пунктах.

В этом примере создаётся диаграмма с данными по умолчанию и задаётся размер шрифта текста легенды 20 пунктов. Также отключаются автоматические границы для вертикальной оси и задаётся диапазон от ‑5 до 10.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)

    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(20)
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(False)
    chart.getAxes().getVerticalAxis().setMinValue(-5)
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(False)
    chart.getAxes().getVerticalAxis().setMaxValue(10)

    presentation.save("legend_font_size.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Установить размер шрифта отдельного элемента легенды**

Используйте коллекцию, возвращаемую методом легенды [getEntries](https://reference.aspose.com/slides/python-java/aspose.slides/legend/#getEntries), чтобы получить доступ к форматированию конкретного элемента. Индексы элементов начинаются с нуля, поэтому индекс `1` относится ко второму элементу.

В этом примере создаётся сгруппированная столбчатая диаграмма, данные которой по умолчанию включают как минимум две серии. Второй элемент легенды форматируется полужирным, курсивом и с синим текстом размером 20 пунктов.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, NullableBool, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)
    text_format = chart.getLegend().getEntries().get_Item(1).getTextFormat()

    text_format.getPortionFormat().setFontBold(NullableBool.True_)
    text_format.getPortionFormat().setFontHeight(20)
    text_format.getPortionFormat().setFontItalic(NullableBool.True_)
    text_format.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    text_format.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    presentation.save("legend_entry_format.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Скрыть отдельные элементы легенды**

Чтобы исключить вспомогательную серию из легенды, оставив её данные видимыми, вызовите [LegendEntryProperties.setHide](https://reference.aspose.com/slides/python-java/aspose.slides/legendentryproperties/#setHide) со значением `True` через [ChartSeries.getRelatedLegendEntry](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getRelatedLegendEntry). Это скрывает только выбранный элемент легенды; серия и её точки данных остаются. Вызов [Chart.setLegend](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setLegend) со значением `False`, наоборот, скрывает всю легенду.

Ниже приведён пример, который создаёт сгруппированную столбчатую диаграмму с несколькими сериями, используя данные по умолчанию. Он скрывает элемент легенды второй серии (индекс `1`) и сохраняет презентацию. Затем восстанавливает элемент, вызвав [setHide](https://reference.aspose.com/slides/python-java/aspose.slides/legendentryproperties/#setHide) со значением `False`, и сохраняет вторую копию. Столбцы остаются видимыми в обоих файлах.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)
    chart.setLegend(True)

    legend_entry = chart.getChartData().getSeries().get_Item(1).getRelatedLegendEntry()

    legend_entry.setHide(True)
    presentation.save("hidden_legend_entry.pptx", SaveFormat.Pptx)

    # Восстановить тот же элемент без изменения данных диаграммы.
    legend_entry.setHide(False)
    presentation.save("restored_legend_entry.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Сравнение ниже показывает одну и ту же диаграмму со всеми видимыми элементами легенды и со скрытым вторым элементом. Столбцы второй серии остаются без изменений.

![Сравнение диаграммы с видимыми всеми элементами легенды и с скрытым вторым элементом; все столбцы остаются видимыми.](hide-legend-entry.png)

В столбчатых, линейных и гистограммных диаграммах элементы легенды обозначают серии. В круговых диаграммах они обозначают отдельные точки данных (срезы), поэтому используйте [ChartDataPoint.getRelatedLegendEntry](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getRelatedLegendEntry) для выбранного среза. API документирует этот метод для типов диаграмм `Pie`, `Pie3D`, `ExplodedPie`, `ExplodedPie3D`, `PieOfPie` и `BarOfPie`. Не следует считать, что он применим к кольцевым диаграммам, которые в этот список не включены.

## **FAQ**

**Могу ли я заставить диаграмму резервировать место для легенды вместо наложения её?**  
Да. Вызовите [setOverlay](https://reference.aspose.com/slides/python-java/aspose.slides/legend/#setOverlay) со значением `False`, чтобы зарезервировать пространство для легенды, а не позволять ей перекрывать область построения.

**Можно ли сделать многострочные подписи в легенде?**  
Да. Длинные подписи могут переноситься, если доступной ширины недостаточно. Вы также можете использовать символы переноса строки в названиях серий, чтобы задать разрывы строк.

**Как сделать так, чтобы легенда следовала цветовой схеме темы презентации?**  
Оставьте цвета, заливки и шрифты легенды неопределёнными, чтобы она могла наследовать форматирование из темы. Явное форматирование переопределяет соответствующие настройки темы.