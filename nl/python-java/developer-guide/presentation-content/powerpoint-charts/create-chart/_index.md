---
title: Maak of werk PowerPoint-presentatiediagrammen bij in Python
linktitle: Maak of werk diagrammen bij
type: docs
weight: 10
url: /nl/python-java/create-chart/
keywords:
- diagram toevoegen
- diagram maken
- diagram bewerken
- diagram wijzigen
- diagram bijwerken
- spreidingsdiagram
- cirkeldiagram
- lijndiagram
- boomkaartdiagram
- aandelendiagram
- box-en-whisker-diagram
- trechterdiagram
- zonnestraaldiagram
- histogramdiagram
- radardiagram
- multi-categorie-diagram
- PowerPoint
- presentatie
- Python
- Java
- Aspose.Slides
description: "Maak en pas diagrammen aan in PowerPoint-presentaties met Aspose.Slides voor Python via Java. Voeg diagrammen toe, formatteer en bewerk ze met praktische code-voorbeelden in Python."
---
## **Overzicht**

Dit artikel biedt een uitgebreide gids over hoe u diagrammen kunt maken en aanpassen met Aspose.Slides. U leert hoe u programmatically een diagram aan een dia toevoegt, deze met gegevens vult en diverse opmaakopties toepast om aan uw specifieke ontwerpeisen te voldoen. Gedurende het artikel illustreren gedetailleerde codevoorbeelden elke stap, van het initialiseren van de presentatie en diagramobject tot het configureren van series, assen en legenda’s. Door deze gids te volgen, krijgt u een solide begrip van hoe u dynamische diagramgeneratie in uw applicaties kunt integreren, waardoor het proces van het maken van gegevensgestuurde presentaties wordt gestroomlijnd.

## **Maak een diagram**

Diagrammen helpen mensen snel data te visualiseren en inzichten te verkrijgen die niet meteen duidelijk zijn vanuit een tabel of spreadsheet.

**Waarom diagrammen maken?**

Met diagrammen kunt u:

* grote hoeveelheden gegevens op één dia in een presentatie samenvatten, condenseren of aggregeren  
* patronen en trends in gegevens blootleggen  
* de richting en momentum van gegevens in de tijd of ten opzichte van een specifieke meeteenheid afleiden  
* uitschieters, afwijkingen, fouten, onzinnige gegevens, enz. opsporen  
* complexe gegevens communiceren of presenteren  

In PowerPoint kunt u diagrammen maken via de *Insert*-functie, die sjablonen biedt voor het ontwerpen van veel verschillende diagramtypen. Met Aspose.Slides kunt u zowel gewone diagrammen (gebaseerd op populaire diagramtypen) als aangepaste diagrammen maken.

{{% alert color="info" title="Note" %}}
Om diagrammen te maken, gebruik je de [ChartType](https://reference.aspose.com/slides/nl/python-java/aspose.slides/charttype/) class. De velden in deze class komen overeen met verschillende diagramtypen.
{{% /alert %}}

### **Maak gegroepeerde kolomdiagrammen**

Deze sectie legt uit hoe u gegroepeerde kolomdiagrammen maakt met Aspose.Slides. U leert hoe u een presentatie initialiseert, een diagram toevoegt en elementen zoals titel, gegevens, series, categorieën en opmaak personaliseert. Volg de onderstaande stappen om te zien hoe een standaard gegroepeerd kolomdiagram wordt gegenereerd:

1. Maak een instantie van de [Presentatie](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation) class.  
2. Haal een referentie op naar een dia via de index.  
3. Voeg een diagram toe met enkele gegevens en specificeer het type `ChartType.ClusteredColumn`.  
4. Voeg een titel toe aan het diagram.  
5. Open het gegevenswerkblad van het diagram.  
6. Verwijder alle standaard series en categorieën.  
7. Voeg nieuwe series en categorieën toe.  
8. Voeg nieuwe diagramgegevens toe voor de diagramseries.  
9. Pas een vulkleur toe op de diagramseries.  
10. Voeg labels toe aan de diagramseries.  
11. Sla de gewijzigde presentatie op als een PPTX‑bestand.

Deze C#‑code toont hoe u een gegroepeerd kolomdiagram maakt:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, NullableBool, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

# Instantieert een presentatieklasse die een PPTX‑bestand vertegenwoordigt.
presentation = Presentation()
try:
    # Toegang tot de eerste dia
    slide = presentation.getSlides().get_Item(0)

    # Voegt een diagram toe met de standaardgegevens
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 0, 0, 500, 500)

    # Stelt de diagramtitel in
    chart.getChartTitle().addTextFrameForOverriding("Sample Title")
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True_)
    chart.getChartTitle().setHeight(20)
    chart.setTitle(True)

    # Stelt de index in voor het diagramgegevensblad
    default_worksheet_index = 0

    # Haalt het diagramgegevenswerkblad op
    workbook = chart.getChartData().getChartDataWorkbook()

    # Verwijdert de standaardgegenereerde series en categorieën
    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    # Voegt nieuwe series toe
    cell = workbook.getCell(default_worksheet_index, 0, 1, "Series 1")
    chart.getChartData().getSeries().add(cell,chart.getType())
    cell = workbook.getCell(default_worksheet_index, 0, 2, "Series 2")
    chart.getChartData().getSeries().add(cell,chart.getType())

    # Voegt nieuwe categorieën toe
    cell = workbook.getCell(default_worksheet_index, 1, 0, "Category 1")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(default_worksheet_index, 2, 0, "Category 2")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(default_worksheet_index, 3, 0, "Category 3")
    chart.getChartData().getCategories().add(cell)

    # Neemt de eerste diagramreeks
    series = chart.getChartData().getSeries().get_Item(0)

    # Vult nu de gegevens van de reeks
    cell = workbook.getCell(default_worksheet_index, 1, 1, 20)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, 2, 1, 50)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, 3, 1, 30)
    series.getDataPoints().addDataPointForBarSeries(cell)

    # Stelt de vulkleur in voor de reeks
    series.getFormat().getFill().setFillType(FillType.Solid)
    series.getFormat().getFill().getSolidFillColor().setColor(Color.RED)

    # Neemt de tweede diagramreeks
    series = chart.getChartData().getSeries().get_Item(1)

    # Vult de gegevens van de reeks
    cell = workbook.getCell(default_worksheet_index, 1, 2, 30)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, 2, 2, 10)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, 3, 2, 60)
    series.getDataPoints().addDataPointForBarSeries(cell)

    # Stelt de vulkleur in voor de reeks
    series.getFormat().getFill().setFillType(FillType.Solid)
    series.getFormat().getFill().getSolidFillColor().setColor(Color.GREEN)

    #Maak aangepaste labels voor elke categorie voor de nieuwe reeks
    # Stelt het eerste label in om de categorienaam weer te geven
    label = series.getDataPoints().get_Item(0).getLabel()
    label.getDataLabelFormat().setShowCategoryName(True)

    label = series.getDataPoints().get_Item(1).getLabel()
    label.getDataLabelFormat().setShowSeriesName(True)

    # Toont de waarde voor het derde label
    label = series.getDataPoints().get_Item(2).getLabel()
    label.getDataLabelFormat().setShowValue(True)
    label.getDataLabelFormat().setShowSeriesName(True)
    label.getDataLabelFormat().setSeparator("/")

    # Slaat de presentatie met diagram op
    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Maak spreidingsdiagrammen**

Spreidingsdiagrammen (ook bekend als scatter plots of x‑y‑grafieken) worden vaak gebruikt om patronen te zoeken of correlaties tussen twee variabelen te demonstreren.

Gebruik een spreidingsdiagram wanneer:

* u gekoppelde numerieke gegevens heeft  
* u twee variabelen heeft die goed bij elkaar passen  
* u wilt bepalen of twee variabelen met elkaar samenhangen  
* u een onafhankelijke variabele heeft die meerdere waarden heeft voor een afhankelijke variabele  

1. Volg de stappen in [Maak gegroepeerde kolomdiagrammen](#make-clustered-column-charts).  
2. Voor stap drie, voeg een diagram toe met enige gegevens en kies één van de volgende type‑opties:  
   1. [ChartType.ScatterWithMarkers](https://reference.aspose.com/slides/nl/python-java/aspose.slides/charttype/#ScatterWithMarkers) - _Stelt een spreidingsdiagram voor._  
   2. [ChartType.ScatterWithSmoothLinesAndMarkers](https://reference.aspose.com/slides/nl/python-java/aspose.slides/charttype/#ScatterWithSmoothLinesAndMarkers) - _Stelt een spreidingsdiagram voor dat met krommen verbonden is, met gegevensmarkeringen._  
   3. [ChartType.ScatterWithSmoothLines](https://reference.aspose.com/slides/nl/python-java/aspose.slides/charttype/#ScatterWithSmoothLines) - _Stelt een spreidingsdiagram voor dat met krommen verbonden is, zonder gegevensmarkeringen._  
   4. [ChartType.ScatterWithStraightLinesAndMarkers](https://reference.aspose.com/slides/nl/python-java/aspose.slides/charttype/#ScatterWithStraightLinesAndMarkers) - _Stelt een spreidingsdiagram voor dat met rechte lijnen verbonden is, met gegevensmarkeringen._  
   5. [ChartType.ScatterWithStraightLines](https://reference.aspose.com/slides/nl/python-java/aspose.slides/charttype/#ScatterWithStraightLines) - _Stelt een spreidingsdiagram voor dat met rechte lijnen verbonden is, zonder gegevensmarkeringen._

Deze Python‑code toont hoe u een spreidingsdiagram maakt met verschillende markeringen per serie:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, MarkerStyleType, Presentation, SaveFormat

# Instantieert een presentatieklasse die een PPTX‑bestand vertegenwoordigt.
presentation = Presentation()
try:
    # Toegang tot de eerste dia
    slide = presentation.getSlides().get_Item(0)

    # Maakt het standaarddiagram
    chart = slide.getShapes().addChart(ChartType.ScatterWithSmoothLines, 0, 0, 400, 400)

    # Haal de index op van het standaarddiagramgegevensblad
    default_worksheet_index = 0

    # Haal het diagramgegevenswerkblad op
    workbook = chart.getChartData().getChartDataWorkbook()

    # Verwijdert de voorbeeldserie
    chart.getChartData().getSeries().clear()

    # Voegt nieuwe series toe
    cell = workbook.getCell(default_worksheet_index, 1, 1, "Series 1")
    chart.getChartData().getSeries().add(cell, chart.getType())
    cell = workbook.getCell(default_worksheet_index, 1, 3, "Series 2")
    chart.getChartData().getSeries().add(cell, chart.getType())

    # Neemt de eerste diagramreeks
    series = chart.getChartData().getSeries().get_Item(0)

    # Voegt een nieuw punt (1:3) toe aan de reeks
    x_cell = workbook.getCell(default_worksheet_index, 2, 1, 1)
    y_cell = workbook.getCell(default_worksheet_index, 2, 2, 3)
    series.getDataPoints().addDataPointForScatterSeries(x_cell, y_cell)

    # Voegt een nieuw punt (2:10) toe
    x_cell = workbook.getCell(default_worksheet_index, 3, 1, 2)
    y_cell = workbook.getCell(default_worksheet_index, 3, 2, 10)
    series.getDataPoints().addDataPointForScatterSeries(x_cell, y_cell)

    # Wijzigt het type van de reeks
    series.setType(ChartType.ScatterWithStraightLinesAndMarkers)

    # Wijzigt de marker van de diagramreeks
    series.getMarker().setSize(10)
    series.getMarker().setSymbol(MarkerStyleType.Star)

    # Neemt de tweede diagramreeks
    series = chart.getChartData().getSeries().get_Item(1)

    # Voegt daar een nieuw punt (5:2) toe
    x_cell = workbook.getCell(default_worksheet_index, 2, 3, 5)
    y_cell = workbook.getCell(default_worksheet_index, 2, 4, 2)
    series.getDataPoints().addDataPointForScatterSeries(x_cell, y_cell)

    # Voegt een nieuw punt (3:1) toe
    x_cell = workbook.getCell(default_worksheet_index, 3, 3, 3)
    y_cell = workbook.getCell(default_worksheet_index, 3, 4, 1)
    series.getDataPoints().addDataPointForScatterSeries(x_cell, y_cell)

    # Voegt een nieuw punt (2:2) toe
    x_cell = workbook.getCell(default_worksheet_index, 4, 3, 2)
    y_cell = workbook.getCell(default_worksheet_index, 4, 4, 2)
    series.getDataPoints().addDataPointForScatterSeries(x_cell, y_cell)

    # Voegt een nieuw punt (5:1) toe
    x_cell = workbook.getCell(default_worksheet_index, 5, 3, 5)
    y_cell = workbook.getCell(default_worksheet_index, 5, 4, 1)
    series.getDataPoints().addDataPointForScatterSeries(x_cell, y_cell)

    # Wijzigt de marker van de diagramreeks
    series.getMarker().setSize(10)
    series.getMarker().setSymbol(MarkerStyleType.Circle)

    presentation.save("AsposeChart_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Maak cirkeldiagrammen**

Cirkeldiagrammen zijn het meest geschikt om de verhouding deel‑tot‑geheel in data te tonen, vooral wanneer de data categorische labels met numerieke waarden bevat. Als uw data echter veel onderdelen of labels bevat, kunt u beter een staafdiagram overwegen.

1. Maak een instantie van de [Presentatie](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/) class.  
2. Haal een referentie op naar een dia via de index.  
3. Voeg een diagram toe met standaardgegevens en specificeer het type [ChartType.Pie](https://reference.aspose.com/slides/nl/python-java/aspose.slides/charttype/#Pie).  
4. Open het gegevenswerkboek van het diagram [ChartDataWorkbook](https://reference.aspose.com/slides/nl/python-java/aspose.slides/chartdataworkbook/).  
5. Verwijder de standaard series en categorieën.  
6. Voeg nieuwe series en categorieën toe.  
7. Voeg nieuwe diagramgegevens toe voor de diagramseries.  
8. Voeg nieuwe punten toe voor het diagram en pas aangepaste kleuren toe op de sectoren van het cirkeldiagram.  
9. Stel labels in voor de series.  
10. Schakel leiderslijnen in voor de serielabels.  
11. Stel de rotatiehoek in voor de sectoren van het cirkeldiagram.  
12. Sla de gewijzigde presentatie op als een PPTX‑bestand.

Deze Python‑code toont hoe u een cirkeldiagram maakt:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, LineDashStyle, LineStyle, NullableBool, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

# Instantieert een presentatieklasse die een PPTX‑bestand vertegenwoordigt.
presentation = Presentation()
try:
    # Toegang tot de eerste dia
    slide = presentation.getSlides().get_Item(0)

    # Voegt een diagram toe met standaardgegevens
    chart = slide.getShapes().addChart(ChartType.Pie, 100, 100, 400, 400)

    # Stelt de diagramtitel in
    chart.getChartTitle().addTextFrameForOverriding("Sample Title")
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True_)
    chart.getChartTitle().setHeight(20)
    chart.setTitle(True)

    # Stelt de index in voor het diagramgegevensblad
    default_worksheet_index = 0

    # Haalt het diagramgegevenswerkblad op
    workbook = chart.getChartData().getChartDataWorkbook()

    # Verwijdert de standaardgegenereerde series en categorieën
    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    # Voegt nieuwe categorieën toe
    cell = workbook.getCell(0, 1, 0, "First Qtr")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, 2, 0, "2nd Qtr")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, 3, 0, "3rd Qtr")
    chart.getChartData().getCategories().add(cell)

    # Voegt nieuwe series toe
    cell = workbook.getCell(0, 0, 1, "Series 1")
    series = chart.getChartData().getSeries().add(cell, chart.getType())

    #Vult de reeksengegevens
    cell = workbook.getCell(default_worksheet_index, 1, 1, 20)
    series.getDataPoints().addDataPointForPieSeries(cell)
    cell = workbook.getCell(default_worksheet_index, 2, 1, 50)
    series.getDataPoints().addDataPointForPieSeries(cell)
    cell = workbook.getCell(default_worksheet_index, 3, 1, 30)
    series.getDataPoints().addDataPointForPieSeries(cell)

    # Adding new points and setting sector color
    chart.getChartData().getSeriesGroups().get_Item(0).setColorVaried(True)

    point = series.getDataPoints().get_Item(0)
    point.getFormat().getFill().setFillType(FillType.Solid)
    point.getFormat().getFill().getSolidFillColor().setColor(Color.CYAN)

    # Stelt de sectierand in
    point.getFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    point.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.GRAY)
    point.getFormat().getLine().setWidth(3.0)
    point.getFormat().getLine().setStyle(LineStyle.ThinThick)
    point.getFormat().getLine().setDashStyle(LineDashStyle.DashDot)

    second_point = series.getDataPoints().get_Item(1)
    second_point.getFormat().getFill().setFillType(FillType.Solid)
    second_point.getFormat().getFill().getSolidFillColor().setColor(Color.ORANGE)

    # Stelt de sectierand in
    second_point.getFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    second_point.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    second_point.getFormat().getLine().setWidth(3.0)
    second_point.getFormat().getLine().setStyle(LineStyle.Single)
    second_point.getFormat().getLine().setDashStyle(LineDashStyle.LargeDashDot)

    third_point = series.getDataPoints().get_Item(2)
    third_point.getFormat().getFill().setFillType(FillType.Solid)
    third_point.getFormat().getFill().getSolidFillColor().setColor(Color.YELLOW)

    # Stelt de sectierand in
    third_point.getFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    third_point.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED)
    third_point.getFormat().getLine().setWidth(2.0)
    third_point.getFormat().getLine().setStyle(LineStyle.ThinThin)
    third_point.getFormat().getLine().setDashStyle(LineDashStyle.LargeDashDotDot)

    # Creates custom labels for each of categories for new series
    first_label = series.getDataPoints().get_Item(0).getLabel()

    first_label.getDataLabelFormat().setShowValue(True)

    second_label = series.getDataPoints().get_Item(1).getLabel()
    second_label.getDataLabelFormat().setShowValue(True)
    second_label.getDataLabelFormat().setShowLegendKey(True)
    second_label.getDataLabelFormat().setShowPercentage(True)

    third_label = series.getDataPoints().get_Item(2).getLabel()
    third_label.getDataLabelFormat().setShowSeriesName(True)
    third_label.getDataLabelFormat().setShowPercentage(True)

    # Shows Leader Lines for Chart
    series.getLabels().getDefaultDataLabelFormat().setShowLeaderLines(True)

    # Sets the Rotation Angle for Pie Chart Sectors
    chart.getChartData().getSeriesGroups().get_Item(0).setFirstSliceAngle(180)

    # Saves the presentation with a chart
    presentation.save("PieChart_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Maak lijndiagrammen**

Lijndiagrammen (ook bekend als lijngrafieken) zijn het beste te gebruiken wanneer u veranderingen in waarde over tijd wilt aantonen. Met een lijndiagram kunt u een grote hoeveelheid gegevens in één oogopslag vergelijken, veranderingen en trends in de loop van de tijd volgen, afwijkingen in gegevensreeksen benadrukken, enzovoort.

1. Maak een instantie van de [Presentatie](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/) class.  
2. Haal een referentie op naar een dia via de index.  
3. Voeg een diagram toe met standaardgegevens en specificeer het type [ChartType.Line](https://reference.aspose.com/slides/nl/python-java/aspose.slides/charttype/#Line).  
4. Sla de gewijzigde presentatie op als een PPTX‑bestand.

Deze Python‑code toont hoe u een lijndiagram maakt:

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

Standaard worden punten op een lijndiagram verbonden door rechte doorlopende lijnen. Als u wilt dat de punten in plaats daarvan worden verbonden door streepjes, kunt u uw gewenste streepjes‑type als volgt opgeven:

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

### **Maak boomkaart‑diagrammen**

Boomkaart‑diagrammen zijn het meest geschikt voor verkoopdata wanneer u de relatieve grootte van datacategorieën wilt tonen en snel de aandacht wilt vestigen op items die grote bijdragers zijn binnen elke categorie.

1. Maak een instantie van de [Presentatie](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/) class.  
2. Haal een referentie op naar een dia via de index.  
3. Voeg een diagram toe met standaardgegevens en specificeer het type [ChartType.Treemap](https://reference.aspose.com/slides/nl/python-java/aspose.slides/charttype/#Treemap).  
4. Open het gegevenswerkboek van het diagram [ChartDataWorkbook](https://reference.aspose.com/slides/nl/python-java/aspose.slides/chartdataworkbook/).  
5. Verwijder de standaard series en categorieën.  
6. Voeg nieuwe series en categorieën toe.  
7. Voeg nieuwe diagramgegevens toe voor de diagramseries.  
8. Sla de gewijzigde presentatie op als een PPTX‑bestand.

Deze Python‑code toont hoe u een boomkaart‑diagram maakt:

```python
import jpype
import asposeslides

if not jpase.isJVMStarted():
    jpase.startJVM()

from asposeslides.api import ChartType, ParentLabelLayoutType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Treemap, 50, 50, 500, 400)
    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    #tak 1
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

    #tak 2
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

### **Maak aandelendiagrammen**

1. Maak een instantie van de [Presentatie](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/) class.  
2. Haal een referentie op naar een dia via de index.  
3. Voeg een diagram toe met standaardgegevens en specificeer het type [ChartType.OpenHighLowClose](https://reference.aspose.com/slides/nl/python-java/aspose.slides/charttype/#OpenHighLowClose).  
4. Open het gegevenswerkboek van het diagram [ChartDataWorkbook](https://reference.aspose.com/slides/nl/python-java/aspose.slides/chartdataworkbook/).  
5. Verwijder de standaard series en categorieën.  
6. Voeg nieuwe series en categorieën toe.  
7. Voeg nieuwe diagramgegevens toe voor de diagramseries.  
8. Specificeer het formaat van de hoog‑laag‑lijnen.  
9. Sla de gewijzigde presentatie op als een PPTX‑bestand.

Deze Python‑code toont hoe u een aandelendiagram maakt:

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

### **Maak box‑en‑whisker‑diagrammen**

1. Maak een instantie van de [Presentatie](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/) class.  
2. Haal een referentie op naar een dia via de index.  
3. Voeg een diagram toe met standaardgegevens en specificeer het type [ChartType.BoxAndWhisker](https://reference.aspose.com/slides/nl/python-java/aspose.slides/charttype/#BoxAndWhisker).  
4. Open het gegevenswerkboek van het diagram [ChartDataWorkbook](https://reference.aspose.com/slides/nl/python-java/aspose.slides/chartdataworkbook/).  
5. Verwijder de standaard series en categorieën.  
6. Voeg nieuwe series en categorieën toe.  
7. Voeg nieuwe diagramgegevens toe voor de diagramseries.  
8. Sla de gewijzigde presentatie op als een PPTX‑bestand.

Deze Python‑code toont hoe u een box‑en‑whisker‑diagram maakt:

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

### **Maak trechterdiagrammen**

1. Maak een instantie van de [Presentatie](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/) class.  
2. Haal een referentie op naar een dia via de index.  
3. Voeg een diagram toe met standaardgegevens en specificeer het type [ChartType.Funnel](https://reference.aspose.com/slides/nl/python-java/aspose.slides/charttype/#Funnel).  
4. Sla de gewijzigde presentatie op als een PPTX‑bestand.

Deze Python‑code toont hoe u een trechterdiagram maakt:

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

### **Maak zonnestraal‑diagrammen**

1. Maak een instantie van de [Presentatie](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/) class.  
2. Haal een referentie op naar een dia via de index.  
3. Voeg een diagram toe met standaardgegevens en specificeer het type [ChartType.Sunburst](https://reference.aspose.com/slides/nl/python-java/aspose.slides/charttype/#Sunburst).  
4. Sla de gewijzigde presentatie op als een PPTX‑bestand.

Deze Python‑code toont hoe u een zonnestraal‑diagram maakt:

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

    #tak 1
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

    #tak 2
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

### **Maak histogram‑diagrammen**

1. Maak een instantie van de [Presentatie](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/) class.  
2. Haal een referentie op naar een dia via de index.  
3. Voeg een diagram toe met standaardgegevens en specificeer het type [ChartType.Histogram](https://reference.aspose.com/slides/nl/python-java/aspose.slides/charttype/#Histogram).  
4. Open het gegevenswerkboek van het diagram [ChartDataWorkbook](https://reference.aspose.com/slides/nl/python-java/aspose.slides/chartdataworkbook/).  
5. Verwijder de standaard series en categorieën.  
6. Voeg nieuwe series en categorieën toe.  
7. Sla de gewijzigde presentatie op als een PPTX‑bestand.

Deze Python‑code toont hoe u een histogram‑diagram maakt:

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

### **Maak radardiagrammen**

1. Maak een instantie van de [Presentatie](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/) class.  
2. Haal een referentie op naar een dia via de index.  
3. Voeg een diagram toe met enige gegevens en specificeer uw gewenste diagramtype ([ChartType.Radar](https://reference.aspose.com/slides/nl/python-java/aspose.slides/charttype/#Radar) in dit geval).  
4. Sla de gewijzigde presentatie op als een PPTX‑bestand.

Deze Python‑code toont hoe u een radardiagram maakt:

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

### **Maak multi‑categorie‑diagrammen**

1. Maak een instantie van de [Presentatie](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/) class.  
2. Haal een referentie op naar een dia via de index.  
3. Voeg een diagram toe met standaardgegevens en specificeer het type [ChartType.ClusteredColumn](https://reference.aspose.com/slides/nl/python-java/aspose.slides/charttype/#ClusteredColumn).  
4. Open het gegevenswerkboek van het diagram [ChartDataWorkbook](https://reference.aspose.com/slides/nl/python-java/aspose.slides/chartdataworkbook/).  
5. Verwijder de standaard series en categorieën.  
6. Voeg nieuwe series en categorieën toe.  
7. Voeg nieuwe diagramgegevens toe voor de diagramseries.  
8. Sla de gewijzigde presentatie op als een PPTX‑bestand.

Deze Python‑code toont hoe u een multi‑categorie‑diagram maakt:

```python
import jpade
import asposeslides

if not jpade.isJVMStarted():
    jpade.startJVM()

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

    # Serie toevoegen
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

    # Presentatie opslaan met diagram
    presentation.save("AsposeChart_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Maak kaart‑diagrammen**

Kaart‑diagrammen visualiseren geografische data en helpen waarden over regio’s heen te vergelijken.

Deze Python‑code toont hoe u een kaart‑diagram maakt:

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

### **Maak combinatiediagrammen**

Een combinatie‑diagram (of combo‑diagram) combineert twee of meer diagramtypen in één grafiek. Dit diagram stelt u in staat om verschillen tussen twee of meer datasets te benadrukken, vergelijken of te onderzoeken, zodat u relaties tussen hen kunt identificeren.

![Het combinatiediagram](combination_chart.png)

De volgende Python‑code laat zien hoe u het bovenstaande combinatiediagram maakt in een PowerPoint‑presentatie:

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

    # Stel de diagramtitel in.
    chart.setTitle(True)
    chart.getChartTitle().addTextFrameForOverriding("Chart Title")
    chart.getChartTitle().setOverlay(False)
    title_paragraph = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0)
    title_format = title_paragraph.getParagraphFormat().getDefaultPortionFormat()
    title_format.setFontBold(NullableBool.False_)
    title_format.setFontHeight(18.0)

    # Stel de diagramlegenda in.
    chart.getLegend().setPosition(LegendPositionType.Bottom)
    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(12.0)

    # Verwijder de standaardgegenereerde series en categorieën.
    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    worksheet_index = 0
    workbook = chart.getChartData().getChartDataWorkbook()

    # Voeg nieuwe categorieën toe.
    cell = workbook.getCell(worksheet_index, 1, 0, "Category 1")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(worksheet_index, 2, 0, "Category 2")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(worksheet_index, 3, 0, "Category 3")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(worksheet_index, 4, 0, "Category 4")
    chart.getChartData().getCategories().add(cell)

    # Voeg de eerste serie toe.
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
    # Stel de horizontale as in.
    horizontal_axis = chart.getAxes().getHorizontalAxis()
    horizontal_axis.getTextFormat().getPortionFormat().setFontHeight(12.0)
    horizontal_axis.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill)

    set_axis_title(horizontal_axis, "X Axis")

    # Stel de verticale as in.
    vertical_axis = chart.getAxes().getVerticalAxis()
    vertical_axis.getTextFormat().getPortionFormat().setFontHeight(12.0)
    vertical_axis.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill)

    set_axis_title(vertical_axis, "Y Axis 1")

    # Stel de kleur van de verticale hoofdrasterlijnen in.
    major_grid_lines_format = vertical_axis.getMajorGridLinesFormat().getLine().getFillFormat()
    major_grid_lines_format.setFillType(FillType.Solid)
    color = Color(217, 217, 217)
    major_grid_lines_format.getSolidFillColor().setColor(color)

def set_secondary_axes_format(chart):
    # Stel de secundaire horizontale as in.
    secondary_horizontal_axis = chart.getAxes().getSecondaryHorizontalAxis()
    secondary_horizontal_axis.setPosition(AxisPositionType.Bottom)
    secondary_horizontal_axis.setCrossType(CrossesType.Maximum)
    secondary_horizontal_axis.setVisible(False)
    secondary_horizontal_axis.getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill)
    secondary_horizontal_axis.getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill)

    # Stel de secundaire verticale as in.
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

## **Diagrammen bijwerken**

1. Maak een instantie van de [Presentatie](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/) class die de presentatie bevat met het diagram dat u wilt bijwerken.  
2. Haal een referentie op naar een dia via de index.  
3. Doorloop alle vormen om het gewenste diagram te vinden.  
4. Open het gegevenswerkblad van het diagram.  
5. Pas de diagramreeks aan door de reekshoe waarden te wijzigen.  
6. Voeg een nieuwe reeks toe en vul de gegevens in.  
7. Sla de gewijzigde presentatie op als een PPTX‑bestand.

Deze Python‑code toont hoe u een diagram bijwerkt:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

# Open de presentatie die het diagram bevat dat moet worden bijgewerkt
presentation = Presentation("ExistingChart.pptx")
try:
    # Toegang tot de eerste dia
    slide = presentation.getSlides().get_Item(0)

    # Haal het diagram op van de dia
    chart = slide.getShapes().get_Item(0)

    # Instellen van de index van het diagramgegevensblad
    default_worksheet_index = 0

    # Ophalen van het werkblad met diagramgegevens
    workbook = chart.getChartData().getChartDataWorkbook()

    # Wijzigen van de diagramcategorienaam
    workbook.getCell(default_worksheet_index, 1, 0, "Modified Category 1")
    workbook.getCell(default_worksheet_index, 2, 0, "Modified Category 2")

    # Haal de eerste diagramreeks
    series = chart.getChartData().getSeries().get_Item(0)

    # Nu worden de gegevens van de reeks bijgewerkt
    workbook.getCell(default_worksheet_index, 0, 1, "New_Series1")# Wijziging van de reeksnaam
    series.getDataPoints().get_Item(0).getValue().setData(90)
    series.getDataPoints().get_Item(1).getValue().setData(123)
    series.getDataPoints().get_Item(2).getValue().setData(44)

    # Haal de tweede diagramreeks
    series = chart.getChartData().getSeries().get_Item(1)

    # Nu worden de gegevens van de reeks bijgewerkt
    workbook.getCell(default_worksheet_index, 0, 2, "New_Series2")# Wijziging van de reeksnaam
    series.getDataPoints().get_Item(0).getValue().setData(23)
    series.getDataPoints().get_Item(1).getValue().setData(67)
    series.getDataPoints().get_Item(2).getValue().setData(99)

    # Nu een nieuwe reeks toevoegen
    cell = workbook.getCell(default_worksheet_index, 0, 3, "Series 3")
    chart.getChartData().getSeries().add(cell, chart.getType())

    # Haal de derde diagramreeks
    series = chart.getChartData().getSeries().get_Item(2)

    # Nu de reeksgegevens invullen
    cell = workbook.getCell(default_worksheet_index, 1, 3, 20)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, 2, 3, 50)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, 3, 3, 30)
    series.getDataPoints().addDataPointForBarSeries(cell)

    chart.setType(ChartType.ClusteredCylinder)

    # Presentatie opslaan met diagram
    presentation.save("AsposeChartModified_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Gegevensbereik voor een diagram instellen**

Om het gegevensbereik voor een diagram in te stellen, doet u het volgende:

1. Maak een instantie van de [Presentatie](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/) class die de presentatie bevat met het diagram.  
2. Haal een referentie op naar een dia via de index.  
3. Doorloop alle vormen om het gewenste diagram te vinden.  
4. Open de diagramgegevens en stel het bereik in.  
5. Sla de gewijzigde presentatie op als een PPTX‑bestand.

Deze Python‑code toont hoe u het gegevensbereik voor een diagram instelt:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Open de presentatie die het diagram bevat
presentation = Presentation("ExistingChart.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().get_Item(0)

    chart.getChartData().setRange("Sheet1!A1:B4")

    presentation.save("SetDataRange_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Standaard markeringen in diagrammen gebruiken**

Wanneer u standaard markeringen in diagrammen gebruikt, krijgt elke diagramreeks automatisch een verschillend markeringsteken.

Deze Python‑code toont hoe u automatisch een diagramreeks‑markering instelt:

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
    # Neem tweede diagramreeks
    second_series = chart.getChartData().getSeries().get_Item(1)

    # Nu seriesgegevens invullen
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

**Welke diagramtypen worden ondersteund door Aspose.Slides?**

Aspose.Slides ondersteunt een breed scala aan [diagramtypen](https://reference.aspose.com/slides/nl/python-java/aspose.slides/charttype/), waaronder staaf, lijn, cirkel, gebied, spreiding, histogram, radar en nog veel meer. Deze flexibiliteit stelt u in staat om het meest geschikte diagramtype voor uw visualisatiebehoeften te kiezen.

**Hoe voeg ik een nieuw diagram toe aan een dia?**

Om een diagram toe te voegen, maakt u eerst een instantie van de [Presentatie](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/) class, haalt u de gewenste dia op via de index en roept u vervolgens de methode aan om een diagram toe te voegen, waarbij u het diagramtype en de begin­gegevens specificeert. Deze procedure integreert het diagram direct in uw presentatie.

**Hoe kan ik de gegevens die in een diagram worden weergegeven bijwerken?**

U kunt de gegevens van een diagram bijwerken door toegang te krijgen tot het gegevenswerkboek van het diagram ([ChartDataWorkbook](https://reference.aspose.com/slides/nl/python-java/aspose.slides/chartdataworkbook/)), eventuele standaard series en categorieën te verwijderen en vervolgens uw aangepaste gegevens toe te voegen. Hiermee kunt u het diagram vernieuwen zodat het de nieuwste gegevens weergeeft.

**Is het mogelijk om het uiterlijk van het diagram aan te passen?**

Ja, Aspose.Slides biedt uitgebreide aanpassingsopties. U kunt kleuren, lettertypen, labels, legenda’s en andere [opmaakelementen](/slides/nl/python-java/chart-entities/) wijzigen om het diagram af te stemmen op uw specifieke ontwerpeisen.