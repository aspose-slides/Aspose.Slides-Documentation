---
title: Anpassa diagramaxlar i presentationer med Python
linktitle: Diagramaxel
type: docs
url: /sv/python-java/chart-axis/
keywords:
- diagramaxel
- vertikal axel
- horisontell axel
- anpassa axel
- manipulera axel
- hantera axel
- axelegenskaper
- maxvärde
- minvärde
- axellinje
- datumformat
- axelrubrik
- axelposition
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "Upptäck hur du använder Aspose.Slides för Python via Java för att anpassa diagramaxlar i PowerPoint-presentationer för rapporter och visualiseringar."
---
## **Översikt**

Denna artikel förklarar hur du anpassar diagramaxlar i Aspose.Slides. Den visar hur du hämtar faktiska axiellvärden, byter data mellan axlar, döljer den vertikala eller horisontella axeln för linjediagram, ändrar kategoriaxelns typ, ställer in datumformatet för kategoriaxelvärden, roterar en axelrubrik, ställer in axelns position och ställer in displayenheten för värdeaxeln.

## **Hämta de maximala värdena på den vertikala axeln i ett diagram**

Aspose.Slides för Python via Java låter dig hämta minsta och största värden på en vertikal axel. Följ dessa steg:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/).
1. Öppna den första bilden.
1. Lägg till ett diagram med standarddata.
1. Hämta det faktiska maximala värdet på axeln.
1. Hämta det faktiska minsta värdet på axeln.
1. Hämta den faktiska huvudenheten för axeln.
1. Hämta den faktiska delenheten för axeln.
1. Hämta den faktiska skalan för huvudenheten på axeln.
1. Hämta den faktiska skalan för delenheten på axeln.

Denna exempel kod — en implementation av stegen ovan — visar hur du hämtar de erforderliga värdena i Python:

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

    # Sparar presentationen
    presentation.save("MaxValuesVerticalAxis_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Byt data mellan axlar**

Aspose.Slides låter dig snabbt byta data mellan axlar — data som visas på den vertikala axeln (y-axeln) flyttas till den horisontella axeln (x-axeln) och vice versa.

Den här Python-koden visar hur du utför datautbytesuppgiften mellan axlar i ett diagram:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 400, 300)

    # Laddar diagrammets standarddata i arbetsboken — switchRowColumn transposerar arbetsboken,
    # så den måste fyllas i först
    workbook = chart.getChartData().getChartDataWorkbook()

    # Byter rader och kolumner
    chart.getChartData().switchRowColumn()

    # Sparar presentationen
    presentation.save("SwitchChartRowColumns_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Inaktivera den vertikala axeln för linjediagram**

Den här Python-koden visar hur du döljer den vertikala axeln för ett linjediagram:

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

## **Inaktivera den horisontella axeln för linjediagram**

Den här koden visar hur du döljer den horisontella axeln för ett linjediagram:

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

## **Ändra en kategoriaxel**

Med metoden [setCategoryAxisType](https://reference.aspose.com/slides/sv/python-java/aspose.slides/axis/#setCategoryAxisType) kan du ange din föredragna kategoriaxeltyp (**date** eller **text**). Den här koden i Python demonstrerar operationen:

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

## **Ställ in datumformatet för kategoriaxelvärden**

Aspose.Slides för Python via Java låter dig ange datumformatet för ett kategoriaxelvärde. Operationen demonstreras i den här Python-koden:

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

## **Ställ in rotationsvinkeln för en diagramaxelrubrik**

Aspose.Slides för Python via Java låter dig ange rotationsvinkeln för en diagramaxelrubrik. Den här Python-koden demonstrerar operationen:

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

## **Ställ in axelpositionen på en kategori- eller värdeaxel**

Aspose.Slides för Python via Java låter dig ange axelpositionen på en kategori- eller värdeaxel. Den här Python-koden visar hur du utför uppgiften:

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

## **Ställ in displayenheten på en diagramvärdeaxel**

Aspose.Slides för Python via Java låter dig ange displayenheten för en diagramvärdeaxel. Axeln skalar sedan sina ticsetiketter med den enheten: med [DisplayUnitType.Millions](https://reference.aspose.com/slides/sv/python-java/aspose.slides/displayunittype/#Millions) visas en axel som går till 60,000,000 som 0 till 60. Den här Python-koden demonstrerar operationen:

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

**Hur anger jag värdet där en axel korsar den andra (axis crossing)?**

Axlarna erbjuder en [crossing setting](https://reference.aspose.com/slides/sv/python-java/aspose.slides/axis/#setCrossType): du kan välja att korsa vid noll, vid det maximala kategori-/värdet eller vid ett specifikt numeriskt värde. Detta är användbart för att flytta X-axeln upp eller ner eller för att framhäva en baslinje.

**Hur kan jag placera tick-märken relativt axeln (crossing, outside, inside)?**

Ställ in [tick mark position](https://reference.aspose.com/slides/sv/python-java/aspose.slides/axis/#setMajorTickMark) till "cross", "outside" eller "inside". Detta påverkar läsbarheten och hjälper till att spara utrymme, särskilt i små diagram.