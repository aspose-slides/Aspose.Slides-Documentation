---
title: Grafieken in PowerPoint-presentaties maken of bijwerken met Python
linktitle: Grafieken maken of bijwerken
type: docs
weight: 10
url: /nl/python-java/create-chart/
keywords:
- grafiek toevoegen
- grafiek maken
- grafiek bewerken
- grafiek wijzigen
- grafiek bijwerken
- spreidingsgrafiek
- taartgrafiek
- lijngrafiek
- boomkaartgrafiek
- aandelen-grafiek
- box-en-whisker-grafiek
- trechtergrafiek
- sunburst-grafiek
- histogramgrafiek
- radargrafiek
- multi-categorie-grafiek
- PowerPoint
- presentatie
- Python
- Java
- Aspose.Slides
description: "Grafieken maken en aanpassen in PowerPoint-presentaties met Aspose.Slides voor Python via Java. Grafieken toevoegen, opmaken en bewerken met praktische code-voorbeelden in Python."
---
## **Overzicht**

Dit artikel biedt een uitgebreide gids over hoe u grafieken maakt en aanpast met Aspose.Slides for Python via Java. U leert hoe u programmatisch een grafiek aan een dia toevoegt, deze vult met gegevens en verschillende opmaakopties toepast om te voldoen aan uw specifieke ontwerpvereisten. Door het artikel heen illustreren gedetailleerde codevoorbeelden elke stap, van het initialiseren van de presentatie en het grafiekobject tot het configureren van series, assen en legenda’s. Door deze gids te volgen, krijgt u een degelijk begrip van hoe u dynamische grafiekgeneratie integreert in uw Python‑toepassingen, waardoor het proces van het maken van gegevens‑gedreven presentaties wordt gestroomlijnd.

## **Grafiek maken**

Grafieken helpen mensen snel gegevens te visualiseren en inzichten te verkrijgen die niet meteen duidelijk zijn vanuit een tabel of spreadsheet.

**Waarom grafieken maken?**

Met grafieken kunt u:

* grote hoeveelheden gegevens op één dia in een presentatie aggregateren, comprimeren of samenvatten;
* patronen en trends in gegevens blootleggen;
* de richting en het momentum van gegevens in de tijd of ten opzichte van een specifieke meeteenheid afleiden;
* uitschieters, afwijkingen, fouten en onzinnige gegevens opsporen;
* complexe gegevens communiceren of presenteren.

In PowerPoint kunt u grafieken maken via de *Insert*-functie, die sjablonen biedt voor het ontwerpen van vele soorten grafieken. Met Aspose.Slides kunt u zowel normale grafieken (gebaseerd op populaire grafiektype) als aangepaste grafieken maken.

{{% alert color="info" title="Note" %}}
Gebruik de [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/)‑enumeratie in het [asposeslides.api](https://reference.aspose.com/slides/python-java/aspose.slides/)‑pakket. De waarden in deze enumeratie komen overeen met verschillende grafiektype.
{{% /alert %}}

### **Clustered kolomgrafieken maken**

Dit voorbeeld gebruikt [addChart](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addChart) om een gegroepeerde kolomgrafiek te maken die twee series over drie categorieën vergelijkt. De series gebruiken rode en groene opvullingen, en individuele labels tonen categorienamen, serienamen en waarden. Werkblad‑index 0 verwijst naar het eerste blad in de ingebedde grafiek‑werkmap.

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

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 300)

    chart.getChartTitle().addTextFrameForOverriding("Sample Title")
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True_)
    chart.getChartTitle().setHeight(20)
    chart.setTitle(True)

    workbook = chart.getChartData().getChartDataWorkbook()
    worksheet_index = 0

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    series_name_cell = workbook.getCell(worksheet_index, 0, 1, "Series 1")
    chart.getChartData().getSeries().add(series_name_cell, chart.getType())
    series_name_cell = workbook.getCell(worksheet_index, 0, 2, "Series 2")
    chart.getChartData().getSeries().add(series_name_cell, chart.getType())

    category_cell = workbook.getCell(worksheet_index, 1, 0, "Category 1")
    chart.getChartData().getCategories().add(category_cell)
    category_cell = workbook.getCell(worksheet_index, 2, 0, "Category 2")
    chart.getChartData().getCategories().add(category_cell)
    category_cell = workbook.getCell(worksheet_index, 3, 0, "Category 3")
    chart.getChartData().getCategories().add(category_cell)

    series = chart.getChartData().getSeries().get_Item(0)

    value_cell = workbook.getCell(worksheet_index, 1, 1, 20)
    series.getDataPoints().addDataPointForBarSeries(value_cell)
    value_cell = workbook.getCell(worksheet_index, 2, 1, 50)
    series.getDataPoints().addDataPointForBarSeries(value_cell)
    value_cell = workbook.getCell(worksheet_index, 3, 1, 30)
    series.getDataPoints().addDataPointForBarSeries(value_cell)

    series.getFormat().getFill().setFillType(FillType.Solid)
    series.getFormat().getFill().getSolidFillColor().setColor(Color.RED)

    series = chart.getChartData().getSeries().get_Item(1)

    value_cell = workbook.getCell(worksheet_index, 1, 2, 30)
    series.getDataPoints().addDataPointForBarSeries(value_cell)
    value_cell = workbook.getCell(worksheet_index, 2, 2, 10)
    series.getDataPoints().addDataPointForBarSeries(value_cell)
    value_cell = workbook.getCell(worksheet_index, 3, 2, 60)
    series.getDataPoints().addDataPointForBarSeries(value_cell)

    series.getFormat().getFill().setFillType(FillType.Solid)
    color = Color(0, 128, 0)
    series.getFormat().getFill().getSolidFillColor().setColor(color)

    label = series.getDataPoints().get_Item(0).getLabel()
    label.getDataLabelFormat().setShowCategoryName(True)

    label = series.getDataPoints().get_Item(1).getLabel()
    label.getDataLabelFormat().setShowSeriesName(True)

    label = series.getDataPoints().get_Item(2).getLabel()
    label.getDataLabelFormat().setShowValue(True)
    label.getDataLabelFormat().setShowSeriesName(True)
    label.getDataLabelFormat().setSeparator("/")

    presentation.save("AsposeChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Het resultaat:

![De gegroepeerde kolomgrafiek](clustered_column_chart.png)

### **Scatter‑grafieken maken**

Scatter‑grafieken (ook bekend als spreidingsdiagrammen of x‑y‑grafieken) worden vaak gebruikt om patronen te zoeken of correlaties tussen twee variabelen aan te tonen.

Gebruik een scatter‑grafiek wanneer:

* u gepaarde numerieke gegevens heeft;
* u twee variabelen heeft die goed bij elkaar passen;
* u wilt bepalen of de twee variabelen gerelateerd zijn;
* u een onafhankelijke variabele heeft met meerdere waarden voor een afhankelijke variabele.

Dit voorbeeld plot twee sets x‑y‑waarden. De eerste serie gebruikt rechte lijnen met ster‑markers, terwijl de tweede gladde lijnen met cirkel‑markers gebruikt; beide gebruiken een marker‑grootte van 10, geconfigureerd met [setSize](https://reference.aspose.com/slides/python-java/aspose.slides/marker/#setSize). De [setSymbol](https://reference.aspose.com/slides/python-java/aspose.slides/marker/#setSymbol)‑methode bepaalt de marker‑vorm.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, MarkerStyleType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ScatterWithSmoothLines, 20, 20, 500, 300)

    workbook = chart.getChartData().getChartDataWorkbook()
    worksheet_index = 0

    chart.getChartData().getSeries().clear()

    series_name_cell = workbook.getCell(worksheet_index, 1, 1, "Series 1")
    chart.getChartData().getSeries().add(series_name_cell, chart.getType())
    series_name_cell = workbook.getCell(worksheet_index, 1, 3, "Series 2")
    chart.getChartData().getSeries().add(series_name_cell, chart.getType())

    series = chart.getChartData().getSeries().get_Item(0)

    x_value_cell = workbook.getCell(worksheet_index, 2, 1, 1)
    y_value_cell = workbook.getCell(worksheet_index, 2, 2, 3)
    series.getDataPoints().addDataPointForScatterSeries(x_value_cell, y_value_cell)

    x_value_cell = workbook.getCell(worksheet_index, 3, 1, 2)
    y_value_cell = workbook.getCell(worksheet_index, 3, 2, 10)
    series.getDataPoints().addDataPointForScatterSeries(x_value_cell, y_value_cell)

    series.setType(ChartType.ScatterWithStraightLinesAndMarkers)

    series.getMarker().setSize(10)
    series.getMarker().setSymbol(MarkerStyleType.Star)

    series = chart.getChartData().getSeries().get_Item(1)

    x_value_cell = workbook.getCell(worksheet_index, 2, 3, 5)
    y_value_cell = workbook.getCell(worksheet_index, 2, 4, 2)
    series.getDataPoints().addDataPointForScatterSeries(x_value_cell, y_value_cell)

    x_value_cell = workbook.getCell(worksheet_index, 3, 3, 3)
    y_value_cell = workbook.getCell(worksheet_index, 3, 4, 1)
    series.getDataPoints().addDataPointForScatterSeries(x_value_cell, y_value_cell)

    x_value_cell = workbook.getCell(worksheet_index, 4, 3, 2)
    y_value_cell = workbook.getCell(worksheet_index, 4, 4, 2)
    series.getDataPoints().addDataPointForScatterSeries(x_value_cell, y_value_cell)

    x_value_cell = workbook.getCell(worksheet_index, 5, 3, 5)
    y_value_cell = workbook.getCell(worksheet_index, 5, 4, 1)
    series.getDataPoints().addDataPointForScatterSeries(x_value_cell, y_value_cell)

    series.getMarker().setSize(10)
    series.getMarker().setSymbol(MarkerStyleType.Circle)

    presentation.save("AsposeChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Het resultaat:

![De scatter‑grafiek](scatter_chart.png)

### **Taartgrafieken maken**

Taartgrafieken worden het best gebruikt om de verhouding deel‑tot‑geheel in gegevens te laten zien, vooral wanneer de gegevens categorische labels met numerieke waarden bevatten. Als uw gegevens echter veel delen of labels bevatten, wilt u misschien in plaats daarvan een staafgrafiek overwegen.

Dit voorbeeld maakt een taartgrafiek met drie kwartaalwaarden. elke part heeft een aangepaste opvulling en rand, en de labels tonen verschillende combinaties van waarden, percentages en seriinformatie. De [setFirstSliceAngle](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setFirstSliceAngle)‑methode zet de eerste part op 180 graden.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, LineDashStyle, LineStyle, NullableBool, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Pie, 20, 20, 500, 300)

    chart.getChartTitle().addTextFrameForOverriding("Sample Title")
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True_)
    chart.getChartTitle().setHeight(20)
    chart.setTitle(True)

    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(True)

    workbook = chart.getChartData().getChartDataWorkbook()
    worksheet_index = 0

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    category_cell = workbook.getCell(0, 1, 0, "1st Qtr")
    chart.getChartData().getCategories().add(category_cell)
    category_cell = workbook.getCell(0, 2, 0, "2nd Qtr")
    chart.getChartData().getCategories().add(category_cell)
    category_cell = workbook.getCell(0, 3, 0, "3rd Qtr")
    chart.getChartData().getCategories().add(category_cell)

    series_name_cell = workbook.getCell(0, 0, 1, "Series 1")
    series = chart.getChartData().getSeries().add(series_name_cell, chart.getType())

    value_cell = workbook.getCell(worksheet_index, 1, 1, 20)
    series.getDataPoints().addDataPointForPieSeries(value_cell)
    value_cell = workbook.getCell(worksheet_index, 2, 1, 50)
    series.getDataPoints().addDataPointForPieSeries(value_cell)
    value_cell = workbook.getCell(worksheet_index, 3, 1, 30)
    series.getDataPoints().addDataPointForPieSeries(value_cell)

    chart.getChartData().getSeriesGroups().get_Item(0).setColorVaried(True)

    first_slice = series.getDataPoints().get_Item(0)
    first_slice.getFormat().getFill().setFillType(FillType.Solid)
    first_slice.getFormat().getFill().getSolidFillColor().setColor(Color.CYAN)

    first_slice.getFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    first_slice.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.GRAY)
    first_slice.getFormat().getLine().setWidth(3.0)
    first_slice.getFormat().getLine().setStyle(LineStyle.ThinThick)
    first_slice.getFormat().getLine().setDashStyle(LineDashStyle.LargeDash)

    second_slice = series.getDataPoints().get_Item(1)
    second_slice.getFormat().getFill().setFillType(FillType.Solid)
    color = Color(165, 42, 42)
    second_slice.getFormat().getFill().getSolidFillColor().setColor(color)

    second_slice.getFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    second_slice.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    second_slice.getFormat().getLine().setWidth(3.0)
    second_slice.getFormat().getLine().setStyle(LineStyle.Single)
    second_slice.getFormat().getLine().setDashStyle(LineDashStyle.LargeDashDot)

    third_slice = series.getDataPoints().get_Item(2)
    third_slice.getFormat().setFill().setFillType(FillType.Solid)
    color = Color(255, 127, 80)
    third_slice.getFormat().getFill().getSolidFillColor().setColor(color)

    third_slice.getFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    third_slice.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED)
    third_slice.getFormat().getLine().setWidth(2.0)
    third_slice.getFormat().getLine().setStyle(LineStyle.ThinThin)
    third_slice.getFormat().getLine().setDashStyle(LineDashStyle.LargeDashDotDot)

    first_label = series.getDataPoints().get_Item(0).getLabel()
    first_label.getDataLabelFormat().setShowValue(True)

    second_label = series.getDataPoints().get_Item(1).getLabel()
    second_label.getDataLabelFormat().setShowValue(True)
    second_label.getDataLabelFormat().setShowLegendKey(True)
    second_label.getDataLabelFormat().setShowPercentage(True)

    third_label = series.getDataPoints().get_Item(2).getLabel()
    third_label.getDataLabelFormat().setShowSeriesName(True)
    third_label.getDataLabelFormat().setShowPercentage(True)

    series.getLabels().getDefaultDataLabelFormat().setShowLeaderLines(True)

    chart.getChartData().getSeriesGroups().get_Item(0).setFirstSliceAngle(180)

    presentation.save("PieChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Het resultaat:

![De taartgrafiek](pie_chart.png)

Om de leesbaarheid van labels buiten de taart te verbeteren, zie [Format Leader Lines](/slides/nl/python-java/chart-data-label/#format-leader-lines) voor een voorbeeld dat labels positioneert en de kleur, breedte, transparantie en stippellijn‑stijl van de lijnen aanpast.

### **Lijngrafieken maken**

Lijngrafieken (ook bekend als lijndiagrammen) worden het best gebruikt in situaties waarin u veranderingen in waarde over de tijd wilt laten zien. Met een lijngrafiek kunt u een grote hoeveelheid gegevens in één keer vergelijken, veranderingen en trends in de tijd volgen, afwijkingen in dataseries benadrukken, enzovoort.

Dit voorbeeld gebruikt [addChart](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addChart) om een lijngrafiek met de standaard series en categorieën te maken, waarna de presentatie als PPTX wordt opgeslagen.

```python
import jpile
import asposeslides

if not jpile.isJVMStarted():
    jpile.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    line_chart = slide.getShapes().addChart(ChartType.Line, 20, 20, 500, 300)

    presentation.save("line_chart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Standaard worden punten op een lijngrafiek verbonden door rechte doorlopende lijnen. Als u wilt dat de punten met streepjes worden verbonden, roep dan [setDashStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setDashStyle) aan met een waarde uit [LineDashStyle](https://reference.aspose.com/slides/python-java/aspose.slides/linedashstyle/):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, LineDashStyle, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    line_chart = slide.getShapes().addChart(ChartType.Line, 20, 20, 500, 300)

    for series in line_chart.getChartData().getSeries():
        series.getFormat().getLine().setDashStyle(LineDashStyle.Dash)
finally:
    presentation.dispose()
```

Het resultaat:

![De lijngrafiek](line_chart.png)

### **Tree‑map‑grafieken maken**

Tree‑map‑grafieken worden het best gebruikt voor verkoopgegevens wanneer u de relatieve grootte van datacategorieën wilt tonen en snel de aandacht wilt vestigen op items die grote bijdragers zijn binnen elke categorie.

Dit voorbeeld maakt een tree‑map met acht bladeren gegroepeerd in vier stelen en twee vertakkingen. De [setGroupingItem](https://reference.aspose.com/slides/python-java/aspose.slides/chartcategorylevelsmanager/#setGroupingItem)‑methode wijst stelen toe op groeperingsniveau 1 en takken op niveau 2. Waarden bepalen de relatieve rechthoek‑groottes, terwijl categorielabels en overlappende bovenliggende labels de hiërarchie identificeren.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, ParentLabelLayoutType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Treemap, 20, 20, 500, 300)

    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    # Tak 1
    category_cell = workbook.getCell(0, "C1", "Leaf1")
    leaf = chart.getChartData().getCategories().add(category_cell)
    leaf.getGroupingLevels().setGroupingItem(1, "Stem1")
    leaf.getGroupingLevels().setGroupingItem(2, "Branch1")

    category_cell = workbook.getCell(0, "C2", "Leaf2")
    chart.getChartData().getCategories().add(category_cell)

    category_cell = workbook.getCell(0, "C3", "Leaf3")
    leaf = chart.getChartData().getCategories().add(category_cell)
    leaf.getGroupingLevels().setGroupingItem(1, "Stem2")

    category_cell = workbook.getCell(0, "C4", "Leaf4")
    chart.getChartData().getCategories().add(category_cell)

    # Tak 2
    category_cell = workbook.getCell(0, "C5", "Leaf5")
    leaf = chart.getChartData().getCategories().add(category_cell)
    leaf.getGroupingLevels().setGroupingItem(1, "Stem3")
    leaf.getGroupingLevels().setGroupingItem(2, "Branch2")

    category_cell = workbook.getCell(0, "C6", "Leaf6")
    chart.getChartData().getCategories().add(category_cell)

    category_cell = workbook.getCell(0, "C7", "Leaf7")
    leaf = chart.getChartData().getCategories().add(category_cell)
    leaf.getGroupingLevels().setGroupingItem(1, "Stem4")

    category_cell = workbook.getCell(0, "C8", "Leaf8")
    chart.getChartData().getCategories().add(category_cell)

    series = chart.getChartData().getSeries().add(ChartType.Treemap)
    series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(True)
    value_cell = workbook.getCell(0, "D1", 4)
    series.getDataPoints().addDataPointForTreemapSeries(value_cell)
    value_cell = workbook.getCell(0, "D2", 5)
    series.getDataPoints().addDataPointForTreemapSeries(value_cell)
    value_cell = workbook.getCell(0, "D3", 3)
    series.getDataPoints().addDataPointForTreemapSeries(value_cell)
    value_cell = workbook.getCell(0, "D4", 6)
    series.getDataPoints().addDataPointForTreemapSeries(value_cell)
    value_cell = workbook.getCell(0, "D5", 9)
    series.getDataPoints().addDataPointForTreemapSeries(value_cell)
    value_cell = workbook.getCell(0, "D6", 9)
    series.getDataPoints().addDataPointForTreemapSeries(value_cell)
    value_cell = workbook.getCell(0, "D7", 4)
    series.getDataPoints().addDataPointForTreemapSeries(value_cell)
    value_cell = workbook.getCell(0, "D8", 3)
    series.getDataPoints().addDataPointForTreemapSeries(value_cell)

    series.setParentLabelLayout(ParentLabelLayoutType.Overlapping)

    presentation.save("Treemap.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Het resultaat:

![De treemap‑grafiek](treemap_chart.png)

### **Waterval‑grafieken maken**

Een waterval‑grafiek toont hoe positieve en negatieve veranderingen bijdragen aan een eindwaarde. Bijvoorbeeld, een winst‑opdeling kan beginnen met omzet, kosten aftrekken en andere inkomsten toevoegen. Veranderingskolommen zweven tussen de vorige en nieuwe lopende waarden, terwijl totaal‑kolommen van nul tot de geaccumuleerde waarde reiken.

Het volgende voorbeeld gebruikt bedragen in duizenden Amerikaanse dollars:

| Categorie | Werkboekwaarde | Kolomtype |
| --- | ---: | --- |
| Omzet | 1000 | Toename |
| Kostprijs | -400 | Afneming |
| Bruto‑winst | 600 | Tussen­totaal |
| Bedrijfskosten | -200 | Afneming |
| Overige inkomsten | 50 | Toename |
| Netto‑winst | 450 | Eindtotaal |

Om een punt te markeren als een tussen‑ of eindtotaal, roep zijn [setSetAsTotal](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#setSetAsTotal)‑methode aan met `True`. Geef het werkboek‑cel‑bedrag op voor dat punt: `600` voor bruto‑winst (`1000 - 400`) en `450` voor netto‑winst (`600 - 200 + 50`). De methode markeert de kolom als totaal; hij berekent of vult de celwaarde niet. Gebruik geen nul als tijdelijke aanduiding en lever geen andere verandering voor een totaalpunt. Een totaal‑kolom toont de geaccumuleerde waarde zonder deze opnieuw op te tellen bij de lopende waarde.

Deze volledige Python‑voorbeeld maakt een grafiek met het `Waterfall`‑lid van [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/), wist de standaardgegevens en vult de ingebedde werkmap. Werkblad‑index `0` selecteert het eerste werkblad; kolom A bevat categorienamen en kolom B bevat waarden. Elke waardecel wordt toegevoegd met [addDataPointForWaterfallSeries](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapointcollection/#addDataPointForWaterfallSeries). De nul‑gebaseerde puntindices `2` en `5` identificeren respectievelijk het tussen‑ en eindtotaal. Het aanroepen van [setShowValue](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setShowValue) met `True` toont de bedragen op de kolommen. Er is geen invoerpresentatie of werkboek vereist.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Waterfall, 20, 20, 680, 200)

    chart.setTitle(True)
    chart.getChartTitle().addTextFrameForOverriding("Profit breakdown (USD thousands)")
    chart.getChartTitle().setOverlay(False)
    chart.setLegend(False)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    worksheet_index = 0

    workbook.clear(worksheet_index)

    series_name_cell = workbook.getCell(worksheet_index, 0, 1, "Profit")
    series = chart.getChartData().getSeries().add(series_name_cell, ChartType.Waterfall)
    categories = ["Revenue", "Cost of sales", "Gross profit", "Operating expenses", "Other income", "Net profit"]
    values = [1000, -400, 600, -200, 50, 450]

    for i in range(len(categories)):
        category_cell = workbook.getCell(worksheet_index, i + 1, 0, categories[i])
        chart.getChartData().getCategories().add(category_cell)
        value_cell = workbook.getCell(worksheet_index, i + 1, 1, values[i])
        series.getDataPoints().addDataPointForWaterfallSeries(value_cell)

    # De derde en zesde punten vertegenwoordigen totalen, geen extra wijzigingen.
    series.getDataPoints().get_Item(2).setSetAsTotal(True)
    series.getDataPoints().get_Item(5).setSetAsTotal(True)
    series.setShowConnectorLines(True)
    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)

    presentation.save("WaterfallChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Roep de series‑niveau‑[setShowConnectorLines](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#setShowConnectorLines)‑methode aan met `True` om lijnen weer te geven die opeenvolgende kolommen verbinden en de lopende waarde makkelijker te volgen maken. Om deze lijnen te verbergen, vervang de methode‑aanroep in het voorbeeld door `series.setShowConnectorLines(False)` vóór het opslaan. Dit wijzigt alleen de zichtbaarheid van de lijn, niet de data of totalen.

De opgeslagen presentatie toont bruto‑winst van 600 en netto‑winst van 450, beide totalen getekend vanaf nul:

![Waterval‑grafiek die omzet, kosten, bruto‑winst van 600 en netto‑winst van 450 toont, met waardelabels en verbindingslijnen](waterfall_chart.png)

### **Aandelen‑grafieken maken**

Aandelen‑grafieken worden gebruikt om financiële gegevens zoals open‑, hoog‑, laag‑ en slotprijzen weer te geven, waardoor markttrends en volatiliteit geanalyseerd kunnen worden. Ze bieden essentiële inzichten in de prestaties van aandelen, wat beleggers en analisten helpt weloverwogen beslissingen te nemen.

Dit voorbeeld maakt een open‑high‑low‑close‑grafiek met vier series in die volgorde en drie categorieën. De [setUpDownBars](https://reference.aspose.com/slides/python-java/aspose.slides/updownbarsmanager/#setUpDownBars)‑methode schakelt op‑/neer‑balken in, en [getHiLowLinesFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#getHiLowLinesFormat) regelt de hoog‑laag‑lijnen die de prijsklassen tonen, terwijl de individuele serie‑lijnen en kleine horizontale rasterlijnen verborgen zijn.

De manager die wordt geretourneerd door [getUpDownBars](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#getUpDownBars) biedt afzonderlijke formatteringsobjecten via [getUpBarsFormat](https://reference.aspose.com/slides/python-java/aspose.slides/updownbarsmanager/#getUpBarsFormat) en [getDownBarsFormat](https://reference.aspose.com/slides/python-java/aspose.slides/updownbarsmanager/#getDownBarsFormat). Gebruik voor elk object de [getFill](https://reference.aspose.com/slides/python-java/aspose.slides/format/#getFill)‑ en [getLine](https://reference.aspose.com/slides/python-java/aspose.slides/format/#getLine)‑methoden om de opvulling en omtrek onafhankelijk in te stellen. Dit voorbeeld gebruikt groene balken met donker‑groene omtrekken voor stijgende intervallen en oranje‑rood met donker‑rood voor dalende intervallen.

Geef numerieke waarden op voor alle vier series per categorie, waarbij Hoog en Laag Open en Close omsluiten. De balken vergelijken Close met Open **binnen dezelfde categorie**, niet met de vorige categorie: A daalt van 72 naar 25, terwijl B stijgt van 25 naar 38 en C stijgt van 38 naar 50. Gelijke Open‑ en Close‑waarden produceren geen zichtbaar ingevuld interval. Op‑/neer‑balken beslaan Open‑Close; hoog‑laag‑lijnen beslaan Laag‑Hoog. Deze balken behoren tot de series‑groep en zijn geen gewone staaf‑grafiek‑series.

Deze opmaak werkt ook met [Line and LineWithMarkers](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/)‑grafieken die minstens twee series in dezelfde groep en bijbehorende numerieke waarden per categorie bevatten. Voor deze niet‑gestapelde lijn‑grafieken vergelijken op‑/neer‑balken de eerste en laatste serie: een hogere laatste waarde levert een op‑balk op, een lagere laatste waarde een neer‑balk. Het omkeren van die series keert de classificatie om. Het onderstaande voorbeeld gebruikt [OpenHighLowClose](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/); ga er niet vanuit dat andere aandelen‑, gestapelde‑lijn‑ of 3D‑varianten dezelfde gegevensindeling of intervalinterpretatie hanteren.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.OpenHighLowClose, 20, 20, 500, 150, False)

    workbook = chart.getChartData().getChartDataWorkbook()

    category_cell = workbook.getCell(0, 1, 0, "A")
    chart.getChartData().getCategories().add(category_cell)
    category_cell = workbook.getCell(0, 2, 0, "B")
    chart.getChartData().getCategories().add(category_cell)
    category_cell = workbook.getCell(0, 3, 0, "C")
    chart.getChartData().getCategories().add(category_cell)

    series_name_cell = workbook.getCell(0, 0, 1, "Open")
    chart.getChartData().getSeries().add(series_name_cell, ChartType.OpenHighLowClose)
    series_name_cell = workbook.getCell(0, 0, 2, "High")
    chart.getChartData().getSeries().add(series_name_cell, ChartType.OpenHighLowClose)
    series_name_cell = workbook.getCell(0, 0, 3, "Low")
    chart.getChartData().getSeries().add(series_name_cell, ChartType.OpenHighLowClose)
    series_name_cell = workbook.getCell(0, 0, 4, "Close")
    chart.getChartData().getSeries().add(series_name_cell, ChartType.OpenHighLowClose)

    series = chart.getChartData().getSeries().get_Item(0)
    value_cell = workbook.getCell(0, 1, 1, 72)
    series.getDataPoints().addDataPointForStockSeries(value_cell)
    value_cell = workbook.getCell(0, 2, 1, 25)
    series.getDataPoints().addDataPointForStockSeries(value_cell)
    value_cell = workbook.getCell(0, 3, 1, 38)
    series.getDataPoints().addDataPointForStockSeries(value_cell)

    series = chart.getChartData().getSeries().get_Item(1)
    value_cell = workbook.getCell(0, 1, 2, 172)
    series.getDataPoints().addDataPointForStockSeries(value_cell)
    value_cell = workbook.getCell(0, 2, 2, 57)
    series.getDataPoints().addDataPointForStockSeries(value_cell)
    value_cell = workbook.getCell(0, 3, 2, 57)
    series.getDataPoints().addDataPointForStockSeries(value_cell)

    series = chart.getChartData().getSeries().get_Item(2)
    value_cell = workbook.getCell(0, 1, 3, 12)
    series.getDataPoints().addDataPointForStockSeries(value_cell)
    value_cell = workbook.getCell(0, 2, 3, 12)
    series.getDataPoints().addDataPointForStockSeries(value_cell)
    value_cell = workbook.getCell(0, 3, 3, 13)
    series.getDataPoints().addDataPointForStockSeries(value_cell)

    series = chart.getChartData().getSeries().get_Item(3)
    value_cell = workbook.getCell(0, 1, 4, 25)
    series.getDataPoints().addDataPointForStockSeries(value_cell)
    value_cell = workbook.getCell(0, 2, 4, 38)
    series.getDataPoints().addDataPointForStockSeries(value_cell)
    value_cell = workbook.getCell(0, 3, 4, 50)
    series.getDataPoints().addDataPointForStockSeries(value_cell)

    up_down_bars = chart.getChartData().getSeriesGroups().get_Item(0).getUpDownBars()
    up_down_bars.setUpDownBars(True)

    up_down_bars.getUpBarsFormat().getFill().setFillType(FillType.Solid)
    up_fill_color = Color(50, 205, 50)
    up_down_bars.getUpBarsFormat().getFill().getSolidFillColor().setColor(up_fill_color)
    up_down_bars.getUpBarsFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    up_line_color = Color(0, 100, 0)
    up_down_bars.getUpBarsFormat().getLine().getFillFormat().getSolidFillColor().setColor(up_line_color)
    up_down_bars.getUpBarsFormat().getLine().setWidth(2)

    up_down_bars.getDownBarsFormat().getFill().setFillType(FillType.Solid)
    down_fill_color = Color(255, 69, 0)
    up_down_bars.getDownBarsFormat().getFill().getSolidFillColor().setColor(down_fill_color)
    up_down_bars.getDownBarsFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    down_line_color = Color(139, 0, 0)
    up_down_bars.getDownBarsFormat().getLine().getFillFormat().getSolidFillColor().setColor(down_line_color)
    up_down_bars.getDownBarsFormat().getLine().setWidth(2)
    chart.getChartData().getSeriesGroups().get_Item(0).getHiLowLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid)

    for stock_series in chart.getChartData().getSeries():
        stock_series.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill)

    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill)

    presentation.save("Stock-chart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Het resultaat, geëxporteerd vanuit PowerPoint:

![Aandelen‑grafiek met een oranje‑rood dalend interval voor A en groene stijgende intervallen voor B en C](stock_chart.png)

### **Box‑en‑whisker‑grafieken maken**

Box‑en‑whisker‑grafieken worden gebruikt om de verdeling van gegevens weer te geven door belangrijke statistische maten, zoals de mediaan, kwartielen en mogelijke uitschieters, samen te vatten. Ze zijn bijzonder nuttig bij verkennende data‑analyse en statistische onderzoeken om snel de variabiliteit van gegevens te begrijpen en eventuele anomalieën te identificeren.

Dit voorbeeld maakt een box‑en‑whisker‑grafiek van zes waarden. De [setQuartileMethod](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#setQuartileMethod)‑methode selecteert de exclusieve kwartiel‑berekening. Het voorbeeld schakelt ook gemiddelde‑lijnen, gemiddelde‑markers, inner‑points en outlier‑points in.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, QuartileMethodType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.BoxAndWhisker, 20, 20, 500, 300)

    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    category_cell = workbook.getCell(0, "A1", "Category 1")
    chart.getChartData().getCategories().add(category_cell)
    category_cell = workbook.getCell(0, "A2", "Category 2")
    chart.getChartData().getCategories().add(category_cell)
    category_cell = workbook.getCell(0, "A3", "Category 3")
    chart.getChartData().getCategories().add(category_cell)
    category_cell = workbook.getCell(0, "A4", "Category 4")
    chart.getChartData().getCategories().add(category_cell)
    category_cell = workbook.getCell(0, "A5", "Category 5")
    chart.getChartData().getCategories().add(category_cell)
    category_cell = workbook.getCell(0, "A6", "Category 6")
    chart.getChartData().getCategories().add(category_cell)

    series = chart.getChartData().getSeries().add(ChartType.BoxAndWhisker)

    series.setQuartileMethod(QuartileMethodType.Exclusive)
    series.setShowMeanLine(True)
    series.setShowMeanMarkers(True)
    series.setShowInnerPoints(True)
    series.setShowOutlierPoints(True)

    value_cell = workbook.getCell(0, "B1", 15)
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(value_cell)
    value_cell = workbook.getCell(0, "B2", 41)
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(value_cell)
    value_cell = workbook.getCell(0, "B3", 16)
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(value_cell)
    value_cell = workbook.getCell(0, "B4", 10)
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(value_cell)
    value_cell = workbook.getCell(0, "B5", 23)
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(value_cell)
    value_cell = workbook.getCell(0, "B6", 16)
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(value_cell)

    presentation.save("BoxAndWhisker.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Funnel‑grafieken maken**

Funnel‑grafieken worden gebruikt om processen te visualiseren die opeenvolgende fasen omvatten, waarbij het volume van gegevens afneemt naarmate het van de ene stap naar de volgende gaat. Ze zijn bijzonder nuttig voor het analyseren van conversieratio’s, het identificeren van knelpunten en het volgen van de efficiëntie van verkoop‑ of marketingprocessen.

Dit voorbeeld gebruikt [addChart](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addChart) om een funnel‑grafiek toe te voegen aan de eerste dia van een bestaande presentatie. Het vervangt de standaardgegevens door zes categorieën en waarden variërend van 50 tot 500, waarna de bijgewerkte presentatie wordt opgeslagen. De invoerpresentatie moet minimaal één dia bevatten.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation("test.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Funnel, 50, 50, 500, 400)

    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    category_cell = workbook.getCell(0, "A1", "Category 1")
    chart.getChartData().getCategories().add(category_cell)
    category_cell = workbook.getCell(0, "A2", "Category 2")
    chart.getChartData().getCategories().add(category_cell)
    category_cell = workbook.getCell(0, "A3", "Category 3")
    chart.getChartData().getCategories().add(category_cell)
    category_cell = workbook.getCell(0, "A4", "Category 4")
    chart.getChartData().getCategories().add(category_cell)
    category_cell = workbook.getCell(0, "A5", "Category 5")
    chart.getChartData().getCategories().add(category_cell)
    category_cell = workbook.getCell(0, "A6", "Category 6")
    chart.getChartData().getCategories().add(category_cell)

    series = chart.getChartData().getSeries().add(ChartType.Funnel)

    value_cell = workbook.getCell(0, "B1", 50)
    series.getDataPoints().addDataPointForFunnelSeries(value_cell)
    value_cell = workbook.getCell(0, "B2", 100)
    series.getDataPoints().addDataPointForFunnelSeries(value_cell)
    value_cell = workbook.getCell(0, "B3", 200)
    series.getDataPoints().addDataPointForFunnelSeries(value_cell)
    value_cell = workbook.getCell(0, "B4", 300)
    series.getDataPoints().addDataPointForFunnelSeries(value_cell)
    value_cell = workbook.getCell(0, "B5", 400)
    series.getDataPoints().addDataPointForFunnelSeries(value_cell)
    value_cell = workbook.getCell(0, "B6", 500)
    series.getDataPoints().addDataPointForFunnelSeries(value_cell)

    presentation.save("Funnel.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Het resultaat:

![De funnel‑grafiek](funnel_chart.png)

### **Sunburst‑grafieken maken**

Sunburst‑grafieken worden gebruikt om hiërarchische gegevens te visualiseren, waarbij niveaus als concentrische ringen worden weergegeven. Ze helpen deel‑tot‑geheel‑relaties te illustreren en zijn ideaal voor het weergeven van geneste categorieën en subcategorieën in een duidelijk, compact formaat.

Dit voorbeeld maakt een sunburst‑grafiek met acht bladeren gegroepeerd in vier stelen en twee vertakkingen. De [setGroupingItem](https://reference.aspose.com/slides/python-java/aspose.slides/chartcategorylevelsmanager/#setGroupingItem)‑methode wijst stelen toe op groeperingsniveau 1 en takken op niveau 2. Categorie‑labels identificeren de segmenten en de waarden bepalen hun relatieve grootte.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Sunburst, 20, 20, 500, 300)

    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    # Tak 1
    category_cell = workbook.getCell(0, "C1", "Leaf1")
    leaf = chart.getChartData().getCategories().add(category_cell)
    leaf.getGroupingLevels().setGroupingItem(1, "Stem1")
    leaf.getGroupingLevels().setGroupingItem(2, "Branch1")

    category_cell = workbook.getCell(0, "C2", "Leaf2")
    chart.getChartData().getCategories().add(category_cell)

    category_cell = workbook.getCell(0, "C3", "Leaf3")
    leaf = chart.getChartData().getCategories().add(category_cell)
    leaf.getGroupingLevels().setGroupingItem(1, "Stem2")

    category_cell = workbook.getCell(0, "C4", "Leaf4")
    chart.getChartData().getCategories().add(category_cell)

    # Tak 2
    category_cell = workbook.getCell(0, "C5", "Leaf5")
    leaf = chart.getChartData().getCategories().add(category_cell)
    leaf.getGroupingLevels().setGroupingItem(1, "Stem3")
    leaf.getGroupingLevels().setGroupingItem(2, "Branch2")

    category_cell = workbook.getCell(0, "C6", "Leaf6")
    chart.getChartData().getCategories().add(category_cell)

    category_cell = workbook.getCell(0, "C7", "Leaf7")
    leaf = chart.getChartData().getCategories().add(category_cell)
    leaf.getGroupingLevels().setGroupingItem(1, "Stem4")

    category_cell = workbook.getCell(0, "C8", "Leaf8")
    chart.getChartData().getCategories().add(category_cell)

    series = chart.getChartData().getSeries().add(ChartType.Sunburst)
    series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(True)
    value_cell = workbook.getCell(0, "D1", 4)
    series.getDataPoints().addDataPointForSunburstSeries(value_cell)
    value_cell = workbook.getCell(0, "D2", 5)
    series.getDataPoints().addDataPointForSunburstSeries(value_cell)
    value_cell = workbook.getCell(0, "D3", 3)
    series.getDataPoints().addDataPointForSunburstSeries(value_cell)
    value_cell = workbook.getCell(0, "D4", 6)
    series.getDataPoints().addDataPointForSunburstSeries(value_cell)
    value_cell = workbook.getCell(0, "D5", 9)
    series.getDataPoints().addDataPointForSunburstSeries(value_cell)
    value_cell = workbook.getCell(0, "D6", 9)
    series.getDataPoints().addDataPointForSunburstSeries(value_cell)
    value_cell = workbook.getCell(0, "D7", 4)
    series.getDataPoints().addDataPointForSunburstSeries(value_cell)
    value_cell = workbook.getCell(0, "D8", 3)
    series.getDataPoints().addDataPointForSunburstSeries(value_cell)

    presentation.save("Sunburst.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Het resultaat:

![De sunburst‑grafiek](sunburst_chart.png)

### **Histogram‑grafieken maken**

Histogram‑grafieken tonen hoe numerieke waarden over intervallen (bins) zijn verdeeld. Voor maandelijkse rapporten over orderverwerkingstijden gebruikt u dezelfde bin‑breedte en drempels om de intervallen consistent te houden en verdelingen makkelijker te vergelijken.

Roep [setAggregationType](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAggregationType) aan op de horizontale as met een modus uit [AxisAggregationType](https://reference.aspose.com/slides/python-java/aspose.slides/axisaggregationtype/). [setBinWidth](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setBinWidth) is alleen van toepassing op `ByBinWidth`; [setNumberOfBins](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setNumberOfBins) alleen op `ByNumberOfBins`. Gebruik `Automatic` om de grafiek de bins te laten kiezen.

#### **Vaste bin‑breedte gebruiken**

Dit voorbeeld groepeert verwerkingstijden in intervallen van 10 minuten, met aparte bins voor tijden van ≤ 10 minuten en > 40 minuten. Schakel deze bins in met [setUnderflowBin](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setUnderflowBin) en [setOverflowBin](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setOverflowBin). Wanneer u expliciete drempels opgeeft via [setUnderflowBin](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setUnderflowBin) en [setOverflowBin](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setOverflowBin), roep dan [setAutomaticUnderflowBin](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAutomaticUnderflowBin) en [setAutomaticOverflowBin](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAutomaticOverflowBin) aan met `False`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AxisAggregationType, ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Histogram, 20, 20, 680, 200)

    chart.setLegend(False)
    chart.setTitle(False)

    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    series = chart.getChartData().getSeries().add(ChartType.Histogram)
    values = [5, 10, 10, 11, 15, 20, 20, 21, 25, 30, 30, 31, 35, 40, 40, 41, 50]
    for i, value in enumerate(values):
        value_cell = workbook.getCell(0, i, 0, float(value))
        series.getDataPoints().addDataPointForHistogramSeries(value_cell)

    axis = chart.getAxes().getHorizontalAxis()
    axis.setAggregationType(AxisAggregationType.ByBinWidth)
    axis.setBinWidth(10.0)
    axis.setUnderflowBin(True)
    axis.setAutomaticUnderflowBin(False)
    axis.setUnderflowBin(10.0)
    axis.setOverflowBin(True)
    axis.setAutomaticOverflowBin(False)
    axis.setOverflowBin(40.0)

    presentation.save("Histogram-bin-width.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

De in PowerPoint weergegeven presentatie toont bin‑aantallen van **3, 4, 4, 4, 2**. De underflow‑bin omvat `5, 10, 10`, dus de drempel is inclusief. De overflow‑bin omvat alleen `41, 50`, dus de drempel is exclusief; beide waarden gelijk aan `40` blijven in het voorgaande interval. De binnen‑bins bevatten waarden groter dan hun ondergrens en kleiner dan of gelijk aan hun bovengrens.

![Histogram met 10‑minuten‑bins en expliciete underflow‑ en overflow‑drempels](histogram_bin_width.png)

#### **Aantal bins specificeren**

Voor een vaste detailniveau in plaats van vaste intervallen, vraag vijf bins aan voor dezelfde data. Dit voorbeeld laat underflow‑ en overflow‑bins uitgeschakeld. De grafiek bepaalt de breedte uit het gegevensbereik, zodat grenzen tussen rapporten kunnen wijzigen.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AxisAggregationType, ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Histogram, 20, 20, 680, 200)

    chart.setLegend(False)
    chart.setTitle(False)

    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    series = chart.getChartData().getSeries().add(ChartType.Histogram)
    values = [5, 10, 10, 11, 15, 20, 20, 21, 25, 30, 30, 31, 35, 40, 40, 41, 50]
    for i, value in enumerate(values):
        value_cell = workbook.getCell(0, i, 0, float(value))
        series.getDataPoints().addDataPointForHistogramSeries(value_cell)

    axis = chart.getAxes().getHorizontalAxis()
    axis.setAggregationType(AxisAggregationType.ByNumberOfBins)
    axis.setNumberOfBins(5)

    presentation.save("Histogram-bin-count.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

De vijf bins hebben aantallen van **4, 4, 4, 4, 1**. Vergelijk deze verdeling met het bovenste resultaat met vaste breedte: de invoerwaarden zijn identiek, maar de grenzen verschillen.

![Histogram met vijf bins berekend uit dezelfde data](histogram_bin_count.png)

### **Radar‑grafieken maken**

Radar‑grafieken worden gebruikt om multivariate gegevens in een tweedimensionaal formaat weer te geven, waardoor meerdere variabelen tegelijk gemakkelijk kunnen worden vergeleken. Ze zijn bijzonder nuttig voor het identificeren van patronen, sterktes en zwaktes over meerdere prestatiemetingen of attributen.

Dit voorbeeld gebruikt [addChart](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addChart) om een radar‑grafiek met de standaard series en categorieën te maken, waarna de presentatie als PPTX wordt opgeslagen.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getShapes().addChart(ChartType.Radar, 20, 20, 500, 300)

    presentation.save("Radar-chart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Het resultaat:

![De radar‑grafiek](radar_chart.png)

### **Multi‑categorie‑grafieken maken**

Multi‑categorie‑grafieken worden gebruikt om gegevens weer te geven die meer dan één categorische groepering bevatten, zodat u waarden over meerdere dimensies tegelijk kunt vergelijken. Ze zijn bijzonder nuttig wanneer u trends en relaties binnen complexe, meerlagige datasets wilt analyseren.

Dit voorbeeld maakt een gegroepeerde kolomgrafiek met acht categorieën, gerangschikt in vier paren. De [setGroupingItem](https://reference.aspose.com/slides/python-java/aspose.slides/chartcategorylevelsmanager/#setGroupingItem)‑methode geeft elk paar een gedeeld label op groeperingsniveau 1, waardoor een categorische as ontstaat met zowel individuele als groepslabels.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 300)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    worksheet_index = 0

    category_cell = workbook.getCell(0, "c2", "A")
    category = chart.getChartData().getCategories().add(category_cell)
    category.getGroupingLevels().setGroupingItem(1, "Group1")
    category_cell = workbook.getCell(0, "c3", "B")
    category = chart.getChartData().getCategories().add(category_cell)

    category_cell = workbook.getCell(0, "c4", "C")
    category = chart.getChartData().getCategories().add(category_cell)
    category.getGroupingLevels().setGroupingItem(1, "Group2")
    category_cell = workbook.getCell(0, "c5", "D")
    category = chart.getChartData().getCategories().add(category_cell)

    category_cell = workbook.getCell(0, "c6", "E")
    category = chart.getChartData().getCategories().add(category_cell)
    category.getGroupingLevels().setGroupingItem(1, "Group3")
    category_cell = workbook.getCell(0, "c7", "F")
    category = chart.getChartData().getCategories().add(category_cell)

    category_cell = workbook.getCell(0, "c8", "G")
    category = chart.getChartData().getCategories().add(category_cell)
    category.getGroupingLevels().setGroupingItem(1, "Group4")
    category_cell = workbook.getCell(0, "c9", "H")
    category = chart.getChartData().getCategories().add(category_cell)

    series_name_cell = workbook.getCell(0, "D1", "Series 1")
    series = chart.getChartData().getSeries().add(series_name_cell, ChartType.ClusteredColumn)

    value_cell = workbook.getCell(worksheet_index, "D2", 10)
    series.getDataPoints().addDataPointForBarSeries(value_cell)
    value_cell = workbook.getCell(worksheet_index, "D3", 20)
    series.getDataPoints().addDataPointForBarSeries(value_cell)
    value_cell = workbook.getCell(worksheet_index, "D4", 30)
    series.getDataPoints().addDataPointForBarSeries(value_cell)
    value_cell = workbook.getCell(worksheet_index, "D5", 40)
    series.getDataPoints().addDataPointForBarSeries(value_cell)
    value_cell = workbook.getCell(worksheet_index, "D6", 50)
    series.getDataPoints().addDataPointForBarSeries(value_cell)
    value_cell = workbook.getCell(worksheet_index, "D7", 60)
    series.getDataPoints().addDataPointForBarSeries(value_cell)
    value_cell = workbook.getCell(worksheet_index, "D8", 70)
    series.getDataPoints().addDataPointForBarSeries(value_cell)
    value_cell = workbook.getCell(worksheet_index, "D9", 80)
    series.getDataPoints().addDataPointForBarSeries(value_cell)

    presentation.save("AsposeChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Het resultaat:

![De multi‑categorie‑grafiek](multi_category_chart.png)

#### **Een kwartaal‑label verwijderen**

Download [quarters.pptx](quarters.pptx) en plaats het in de werkmap. De grafiek toont negen maanden en één verkoopserie met waarden van 10 tot 18. Op de categorische as beslaat Q1 januari tot maart, Q2 april tot juni, en Q3 juli tot september.

April is de vierde categorie (index 3) en bevat het Q2‑label. Gebruik [getGroupingLevels](https://reference.aspose.com/slides/python-java/aspose.slides/chartcategory/#getGroupingLevels) om de groeperingsniveaus van april op te vragen, en roep dan [deleteGroupingItem](https://reference.aspose.com/slides/python-java/aspose.slides/chartcategorylevelsmanager/#deleteGroupingItem) aan met niveau 1 om het kwartaal‑label te verwijderen. Niveau 0 vertegenwoordigt de maand zelf en kan niet worden verwijderd met deze methode.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("quarters.pptx")
try:
    chart = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    april = chart.getChartData().getCategories().get_Item(3)
    april.getGroupingLevels().deleteGroupingItem(1)

    presentation.save("quarters-updated.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()

reopened = Presentation("quarters-updated.pptx")
try:
    chart = reopened.getSlides().get_Item(0).getShapes().get_Item(0)
    data = chart.getChartData()
    
    points = data.getSeries().get_Item(0).getDataPoints()
    print(", ".join(str(month.getAsCell().getValue()) for month in data.getCategories()))
    print(", ".join(str(point.getValue().getData()) for point in points))
finally:
    reopened.dispose()
```

Na het heropenen van de grafiek print het voorbeeld de oorspronkelijke maanden (`Jan, Feb, Mar, Apr, May, Jun, Jul, Aug, Sep`) en verkoopwaarden (`10.0, 11.0, 12.0, 13.0, 14.0, 15.0, 16.0, 17.0, 18.0`) in dezelfde volgorde. Open `quarters-updated.pptx` in PowerPoint om de as‑labels te vergelijken. Het Q2‑label en de groepsgrens vóór april verdwijnen, zodat Q1 van januari tot juni loopt. Q3 begint nog steeds in juli.

![Kwartaal‑labels vóór en na verwijdering. Links strekt Q2 zich uit van april tot juni. Rechts strekt Q1 zich uit van januari tot juni.](quarter-label-comparison.png)

### **Kaart‑grafieken maken**

Kaart‑grafieken worden gebruikt om geografische gegevens te visualiseren door informatie toe te wijzen aan specifieke locaties zoals landen, staten of steden. Ze zijn bijzonder nuttig voor het analyseren van regionale trends, demografische gegevens en ruimtelijke distributies op een heldere, visueel aantrekkelijke manier.

Dit voorbeeld gebruikt [addChart](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addChart) om een kaart‑grafiek met de standaard geografische gegevens te maken en deze op te slaan voor weergave in PowerPoint.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Map, 20, 20, 500, 300)

    presentation.save("mapChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Het resultaat:

![De kaart‑grafiek](map_chart.png)

{{% alert color="info" title="Note" %}}
De afbeelding hierboven toont de opgeslagen presentatie geopend in PowerPoint. Aspose.Slides schrijft de kaart‑grafiek en de bijbehorende gegevens correct, maar tekent zelf geen kaart‑grafieken: wanneer een dia met een kaart‑grafiek wordt gerenderd naar een afbeelding of geconverteerd naar PDF of SVG, blijft het grafiekgebied leeg. Andere vormen op dezelfde dia blijven onaangetast.
{{% /alert %}}

### **Combinatie‑grafieken maken**

Een combinatie‑grafiek (of combo‑grafiek) combineert twee of meer grafiektype in één grafiek. Deze grafiek stelt u in staat om verschillen tussen twee of meer datasets te benadrukken, te vergelijken of te onderzoeken, waardoor u relaties tussen hen kunt identificeren.

![De combinatie‑grafiek](combination_chart.png)

Dit voorbeeld combineert twee gegroepeerde kolom‑series met een lijn‑serie over vier categorieën. De kolommen gebruiken de primaire verticale as, terwijl [setPlotOnSecondAxis](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#setPlotOnSecondAxis) de lijn op een secundaire verticale as rechts plaatst. De hulpfuncties configureren de titel, legenda, as‑labels en rasterlijnen.

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

    # Stel de grafiektitel in.
    chart.setTitle(True)
    chart.getChartTitle().addTextFrameForOverriding("Chart Title")
    chart.getChartTitle().setOverlay(False)
    title_paragraph = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0)
    title_format = title_paragraph.getParagraphFormat().getDefaultPortionFormat()
    title_format.setFontBold(NullableBool.False_)
    title_format.setFontHeight(18.0)

    # Stel de grafieklegenda in.
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

    # Stel de kleur van de verticale belangrijke rasterlijnen in.
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

## **Grafieken bijwerken**

Aspose.Slides for Python via Java stelt u in staat PowerPoint‑grafieken bij te werken door grafiekgegevens, opmaak en styling aan te passen. Deze functionaliteit vereenvoudigt het proces van het actueel houden van presentaties met dynamische content en zorgt ervoor dat grafieken accuraat de huidige gegevens en visuele standaarden weergeven.

Dit voorbeeld werkt de grafiek met de naam "My chart" op de eerste dia van een bestaande presentatie bij. Het vereist twee kolom‑series met elk drie gegevenspunten, met categorielabels in kolom A en serienamen in de eerste rij van het eerste werkblad. Het voorbeeld gebruikt [getCell](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/#getCell) om werkboekcellen te wijzigen, werkt series‑waarden bij, voegt een derde series toe en verandert de grafiek naar gegroepeerde cilinders via [setType](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setType).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, ChartType, Presentation, SaveFormat

chart_name = "My chart"

presentation = Presentation("ExistingChart.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for shape in slide.getShapes():
        if isinstance(shape, Chart) and chart_name == shape.getName():
            chart = shape
            worksheet_index = 0

            workbook = chart.getChartData().getChartDataWorkbook()

            workbook.getCell(worksheet_index, 1, 0, "Modified Category 1")
            workbook.getCell(worksheet_index, 2, 0, "Modified Category 2")

            series = chart.getChartData().getSeries().get_Item(0)

            workbook.getCell(worksheet_index, 0, 1, "New_Series 1")
            series.getDataPoints().get_Item(0).getValue().setData(90)
            series.getDataPoints().get_Item(1).getValue().setData(123)
            series.getDataPoints().get_Item(2).getValue().setData(44)

            series = chart.getChartData().getSeries().get_Item(1)

            workbook.getCell(worksheet_index, 0, 2, "New_Series 2")
            series.getDataPoints().get_Item(0).getValue().setData(23)
            series.getDataPoints().get_Item(1).getValue().setData(67)
            series.getDataPoints().get_Item(2).getValue().setData(99)

            series_name_cell = workbook.getCell(worksheet_index, 0, 3, "Series 3")
            series = chart.getChartData().getSeries().add(series_name_cell, chart.getType())

            value_cell = workbook.getCell(worksheet_index, 1, 3, 20)
            series.getDataPoints().addDataPointForBarSeries(value_cell)
            value_cell = workbook.getCell(worksheet_index, 2, 3, 50)
            series.getDataPoints().addDataPointForBarSeries(value_cell)
            value_cell = workbook.getCell(worksheet_index, 3, 3, 30)
            series.getDataPoints().addDataPointForBarSeries(value_cell)

            chart.setType(ChartType.ClusteredCylinder)

    presentation.save("AsposeChartModified.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Gegevensbereik voor een grafiek instellen**

Voor het inspecteren van het bereik dat al door een bestaande grafiek wordt gebruikt, zie [Retrieve a Chart's Data Range](/slides/nl/python-java/chart-workbook/#retrieve-a-charts-data-range).

Aspose.Slides for Python via Java biedt de flexibiliteit om een specifiek gegevensbereik uit een werkblad als bron voor de grafiekgegevens in te stellen. Dit betekent dat u direct een deel van uw werkblad kunt koppelen aan de grafiek, waardoor u kunt bepalen welke cellen bijdragen aan de series en categorieën van de grafiek. Als resultaat kunt u uw grafieken eenvoudig bijwerken en synchroniseren met de nieuwste gegevenswijzigingen in uw werkblad, zodat uw PowerPoint‑presentaties actuele en nauwkeurige informatie weerspiegelen.

Dit voorbeeld gebruikt [setRange](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setRange) om de gegevensbron van de grafiek met de naam "My chart" op de eerste dia van een bestaande presentatie in te stellen op `Sheet1!A1:B4`. De grafiek‑werkmap moet dat werkblad en een gevulde range bevatten met een seriekop in de eerste rij, categorielabels in kolom A en drie waarden in kolom B.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation, SaveFormat

chart_name = "My chart"

presentation = Presentation("ExistingChart.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for shape in slide.getShapes():
        if isinstance(shape, Chart) and chart_name == shape.getName():
            chart = shape
            chart.getChartData().setRange("Sheet1!A1:B4")

    presentation.save("SetDataRange.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Standaard‑markers in grafieken gebruiken**

Wanneer u standaard‑markers in grafieken gebruikt, krijgt elke grafiek‑serie automatisch een verschillend standaard‑markersymbool toegewezen.

Dit voorbeeld gebruikt [addChart](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addChart) om een grafiek met twee lijngrafieken en een legenda te maken. De marker‑instellingen die worden opgevraagd via [getMarker](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getMarker) behouden de automatisch toegewezen markersymbolen. De eerste serie bevat een negatieve waarde en een ontbrekende waarde, weergegeven door `None`, terwijl de tweede een waarde voor elke categorie heeft.

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

    series_name_cell = workbook.getCell(0, 0, 1, "Series 1")
    series = chart.getChartData().getSeries().add(series_name_cell, chart.getType())

    category_cell = workbook.getCell(0, 1, 0, "C1")
    chart.getChartData().getCategories().add(category_cell)
    value_cell = workbook.getCell(0, 1, 1, 24)
    series.getDataPoints().addDataPointForLineSeries(value_cell)

    category_cell = workbook.getCell(0, 2, 0, "C2")
    chart.getChartData().getCategories().add(category_cell)
    value_cell = workbook.getCell(0, 2, 1, 23)
    series.getDataPoints().addDataPointForLineSeries(value_cell)

    category_cell = workbook.getCell(0, 3, 0, "C3")
    chart.getChartData().getCategories().add(category_cell)
    value_cell = workbook.getCell(0, 3, 1, -10)
    series.getDataPoints().addDataPointForLineSeries(value_cell)

    category_cell = workbook.getCell(0, 4, 0, "C4")
    chart.getChartData().getCategories().add(category_cell)
    value_cell = workbook.getCell(0, 4, 1, None)
    series.getDataPoints().addDataPointForLineSeries(value_cell)

    series_name_cell = workbook.getCell(0, 0, 2, "Series 2")
    second_series = chart.getChartData().getSeries().add(series_name_cell, chart.getType())

    value_cell = workbook.getCell(0, 1, 2, 30)
    second_series.getDataPoints().addDataPointForLineSeries(value_cell)
    value_cell = workbook.getCell(0, 2, 2, 10)
    second_series.getDataPoints().addDataPointForLineSeries(value_cell)
    value_cell = workbook.getCell(0, 3, 2, 60)
    second_series.getDataPoints().addDataPointForLineSeries(value_cell)
    value_cell = workbook.getCell(0, 4, 2, 40)
    second_series.getDataPoints().addDataPointForLineSeries(value_cell)

    chart.setLegend(True)
    chart.getLegend().setOverlay(False)

    presentation.save("DefaultMarkersInChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Welke grafiektype worden ondersteund door Aspose.Slides for Python via Java?**

Aspose.Slides for Python via Java ondersteunt een breed scala aan grafiektype, waaronder staaf, lijn, taart, gebied, spreiding, histogram, radar en nog veel meer. Deze flexibiliteit stelt u in staat het meest geschikte grafiektype te kiezen voor uw datavisualisatie‑behoeften.

**Hoe voeg ik een nieuwe grafiek toe aan een dia?**

Om een grafiek toe te voegen, maakt u eerst een instantie van de [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/)‑klasse, haalt u de gewenste dia op via zijn index, en roept u vervolgens de methode aan om een grafiek toe te voegen, waarbij u het grafiektype en de initiële gegevens opgeeft. Dit proces integreert de grafiek direct in uw presentatie.

**Hoe kan ik de gegevens in een grafiek bijwerken?**

U kunt de gegevens van een grafiek bijwerken door toegang te krijgen tot de werkmap met grafiekgegevens ([ChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/)), eventuele standaard‑series en -categorieën te wissen, en vervolgens uw aangepaste gegevens toe te voegen. Hiermee kunt u de grafiek programmatic verversen zodat deze de nieuwste gegevens weergeeft.

**Is het mogelijk het uiterlijk van de grafiek aan te passen?**

Ja, Aspose.Slides for Python via Java biedt uitgebreide aanpassingsmogelijkheden. U kunt kleuren, lettertypen, labels, legenda’s en andere opmaakelementen wijzigen om het uiterlijk van de grafiek af te stemmen op uw specifieke ontwerpvereisten.