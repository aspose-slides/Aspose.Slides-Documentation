---
title: Grafiekassen aanpassen in presentaties met Python
linktitle: Grafiekas
type: docs
url: /nl/python-java/chart-axis/
keywords:
- grafiekas
- verticale as
- horizontale as
- as aanpassen
- as manipuleren
- as beheren
- as-eigenschappen
- maximale waarde
- minimale waarde
- aslijn
- datumnotatie
- as-titel
- aspositie
- PowerPoint
- presentatie
- Python
- Aspose.Slides
description: "Ontdek hoe je Aspose.Slides for Python via Java kunt gebruiken om grafiekassen aan te passen in PowerPoint-presentaties voor rapporten en visualisaties."
---
## **Overzicht**

Dit artikel legt uit hoe je grafiekassen kunt aanpassen in Aspose.Slides. Het laat zien hoe je de werkelijke aswaarden verkrijgt, gegevens tussen assen verwisselt, de verticale of horizontale as voor lijndiagrammen verbergt, het type categorie‑as wijzigt, het datumformaat voor categorie‑aswaarden instelt, een as‑titel roteert, de aspositie instelt en de weergave‑eenheid van de waardenas instelt.

## **Haal de maximale waarden op de verticale as van een grafiek op**

Aspose.Slides for Python via Java stelt je in staat de minimale en maximale waarden op een verticale as te verkrijgen. Volg deze stappen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/)‑klasse.
1. Toegang tot de eerste dia.
1. Voeg een grafiek toe met standaardgegevens.
1. Verkrijg de werkelijke maximale waarde op de as.
1. Verkrijg de werkelijke minimale waarde op de as.
1. Verkrijg de werkelijke hoofd‑eenheid van de as.
1. Verkrijg de werkelijke sub‑eenheid van de as.
1. Verkrijg de werkelijke schaal van de hoofd‑eenheid van de as.
1. Verkrijg de werkelijke schaal van de sub‑eenheid van de as.

Deze voorbeeldcode – een implementatie van de bovenstaande stappen – laat zien hoe je de vereiste waarden in Python verkrijgt:

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

    # Slaat de presentatie op
    presentation.save("MaxValuesVerticalAxis_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Gegevens tussen assen verwisselen**

Aspose.Slides maakt het mogelijk om snel de gegevens tussen assen te verwisselen – de gegevens die op de verticale as (y‑as) staan, worden naar de horizontale as (x‑as) verplaatst en omgekeerd.

Deze Python‑code laat zien hoe je de gegevensverwisseling tussen assen in een grafiek uitvoert:

```python
import jpage
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 400, 300)

    # Laadt de standaardgegevens van de grafiek in de werkmap — switchRowColumn transponeert de werkmap, dus deze moet eerst worden gevuld
    workbook = chart.getChartData().getChartDataWorkbook()

    # Wisselt rijen en kolommen
    chart.getChartData().switchRowColumn()

    # Slaat de presentatie op
    presentation.save("SwitchChartRowColumns_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Verticale as uitschakelen voor lijndiagrammen**

Deze Python‑code laat zien hoe je de verticale as voor een lijndiagram verbergt:

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

## **Horizontale as uitschakelen voor lijndiagrammen**

Deze code laat zien hoe je de horizontale as voor een lijndiagram verbergt:

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

## **Een categorie‑as wijzigen**

Met de [setCategoryAxisType](https://reference.aspose.com/slides/nl/python-java/aspose.slides/axis/#setCategoryAxisType)‑methode kun je het gewenste categorie‑astype (**date** of **text**) specificeren. Deze code in Python demonstreert de bewerking:

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

## **Datumopmaak voor categorie‑aswaarden instellen**

Aspose.Slides for Python via Java maakt het mogelijk om het datumformaat voor een categorie‑aswaarde in te stellen. De bewerking wordt getoond in deze Python‑code:

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

## **Rotatiehoek voor een grafiekas‑titel instellen**

Aspose.Slides for Python via Java maakt het mogelijk om de rotatiehoek voor een grafiekas‑titel in te stellen. Deze Python‑code demonstreert de bewerking:

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

## **Aspositie op een categorie‑ of waardenas instellen**

Aspose.Slides for Python via Java maakt het mogelijk om de aspositie op een categorie‑ of waardenas in te stellen. Deze Python‑code toont hoe je de taak uitvoert:

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

## **Weergave‑eenheid op een grafiekwaardenas instellen**

Aspose.Slides for Python via Java maakt het mogelijk om de weergave‑eenheid van een grafiekwaardenas in te stellen. De as schaalt vervolgens zijn tick‑labels volgens die eenheid: met [DisplayUnitType.Millions](https://reference.aspose.com/slides/nl/python-java/aspose.slides/displayunittype/#Millions) worden labels van 0 tot 60 weergegeven voor een as die tot 60.000.000 loopt. Deze Python‑code demonstreert de bewerking:

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

**Hoe stel ik de waarde in waarop één as de andere kruist (as‑kruising)?**

Assen bieden een [crossing setting](https://reference.aspose.com/slides/nl/python-java/aspose.slides/axis/#setCrossType): je kunt kiezen om te kruisen op nul, op de maximale categorie/waarde, of op een specifieke numerieke waarde. Dit is handig om de X‑as omhoog of omlaag te verschuiven of om een basislijn te benadrukken.

**Hoe kan ik de tick‑markeringen ten opzichte van de as positioneren (kruisend, buiten, binnen)?**

Stel de [tick mark position](https://reference.aspose.com/slides/nl/python-java/aspose.slides/axis/#setMajorTickMark) in op "cross", "outside" of "inside". Dit beïnvloedt de leesbaarheid en helpt ruimte te besparen, vooral bij kleine grafieken.