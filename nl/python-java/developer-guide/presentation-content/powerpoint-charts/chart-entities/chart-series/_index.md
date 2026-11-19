---
title: Beheer grafiekreeksen in presentaties in Python
linktitle: Gegevensreeksen
type: docs
url: /nl/python-java/chart-series/
keywords:
- grafiekreeks
- reeksoverlap
- reeskleur
- reeksnaam
- datapunt
- werkboekcel
- reeksafstand
- negatieve waarde
- PowerPoint
- presentatie
- Python
- Java
- Aspose.Slides
description: "Leer hoe u grafiekreeksen, datapunten, werkboekcellen, opmaak, overlap, gatbreedte en negatieve waarden in presentaties kunt beheren met Aspose.Slides voor Python via Java."
---
## **Overzicht**

Een grafiek kan zijn geplotte waarden opslaan in werkboekcellen of rechtstreeks als numerieke literalwaarden. Een [ChartSeries](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/) representeert één set gerelateerde waarden, en elk [ChartDataPoint](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/) representeert een punt in die reeks. [ChartCategory](https://reference.aspose.com/slides/python-java/aspose.slides/chartcategory/) objecten leveren de labels of groepeerwaarden die door de series worden gedeeld. In diagrammen die met standaardgegevens zijn aangemaakt, gebruiken seriesnamen, categorieën en puntwaarden [ChartDataCell](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/) objecten uit het diagramwerkboek.

Voor een typische categoriegrafiek gebruikt het standaardwerkboek rij 0 voor serienamen, kolom 0 voor categorienamen, en de overige cellen voor serieswaarden. Werkblad‑, rij‑ en kolom‑indexen die worden doorgegeven aan [ChartDataWorkbook.getCell](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/#getCell) zijn nul‑gebaseerd. Deze indeling is handig wanneer je een diagram maakt met standaardgegevens, maar ga er niet van uit dat elk bestaand diagram dit gebruikt. Voor een geladen presentatie, inspecteer de cellen waarnaar de series, categorieën en datapoints verwijzen voordat je werkboekwaarden wijzigt.

Diagraminstellingen hebben drie verschillende scopes:

- Instellingen op seriesniveau, zoals [ChartSeries.getFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getFormat), bieden de standaardweergave voor alle punten in één serie.
- Instellingen voor datapunt, zoals [ChartDataPoint.getFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getFormat), overschrijven de serie‑weergave voor één punt.
- Groepsinstellingen gelden voor compatibele series die tot dezelfde [ChartSeriesGroup](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/) behoren. Toegang tot de groep verkrijg je via [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getParentSeriesGroup) wanneer je opties wilt instellen zoals overlap of gatbreedte.

Wanneer er geen expliciete punt‑ of series‑vulling is ingesteld, bepalen de diagramstijl en het thema de automatische weergave. Wanneer zowel series‑ als puntopmaak aanwezig zijn, heeft de puntopmaak voor dat punt voorrang.

![chart-series-powerpoint](chart-series-powerpoint.png)

Voor een gegroepeerd cilindergrafiek, zie hoe [changing the 3D series type or bar shape](/slides/nl/python-java/3d-chart/#change-the-3d-series-type-and-bar-shape) de eerste serie beïnvloedt.

## **Stel serieswaarden in met numerieke literalwaarden**

Gebruik numerieke literalwaarden wanneer serieswaarden afkomstig zijn van toepassingsdata of berekeningen en geen verwijzingen naar werkbladcellen nodig hebben. Roep [setDataSourceTypeForValues](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapointcollection/#setDataSourceTypeForValues) aan met [DataSourceType.DoubleLiterals](https://reference.aspose.com/slides/python-java/aspose.slides/datasourcetype/#DoubleLiterals) voordat je het [getValue](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getValue)‑resultaat van elk punt toewijst via [setAsLiteralDouble](https://reference.aspose.com/slides/python-java/aspose.slides/doublechartvalue/#setAsLiteralDouble).

De collectiesetting regelt het brontype van alle puntwaarden in die serie. Elke puntwaarde‑[getDataSourceType](https://reference.aspose.com/slides/python-java/aspose.slides/basechartvalue/#getDataSourceType)‑methode geeft het geselecteerde type weer; wijzig het via de collectiesetting. Met `Worksheet` gebruik je [getAsCell](https://reference.aspose.com/slides/python-java/aspose.slides/doublechartvalue/#getAsCell) om de gerefereerde cel te benaderen. Met `DoubleLiterals` gebruik je [getAsLiteralDouble](https://reference.aspose.com/slides/python-java/aspose.slides/doublechartvalue/#getAsLiteralDouble) of `setAsLiteralDouble` om het getal direct te lezen of te schrijven.

Het volgende voorbeeld maakt een kolomgrafiek met standaardseries en -categorieën, en kent vervolgens berekende waarden van 10, 20, enzovoort toe aan de bestaande punten van de eerste serie. Het slaat de presentatie op, opent deze opnieuw en drukt de opgeslagen waarden af.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, DataSourceType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 300)
    series = chart.getChartData().getSeries().get_Item(0)

    series.getDataPoints().setDataSourceTypeForValues(DataSourceType.DoubleLiterals)
    for i in range(series.getDataPoints().size()):
        series.getDataPoints().get_Item(i).getValue().setAsLiteralDouble((i + 1) * 10)

    presentation.save("numeric_literals.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()

reopened_presentation = Presentation("numeric_literals.pptx")
try:
    reopened_slide = reopened_presentation.getSlides().get_Item(0)
    reopened_chart = reopened_slide.getShapes().get_Item(0)
    reopened_series = reopened_chart.getChartData().getSeries().get_Item(0)
    for point in reopened_series.getDataPoints():
        print(point.getValue().getAsLiteralDouble())
finally:
    reopened_presentation.dispose()
```

Het brontype van de puntwaarde staat los van [ChartData.getDataSourceType](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getDataSourceType), dat de interne of externe werkboekconfiguratie van het diagram identificeert. Het gebruik van numerieke literalwaarden verwijdert op zichzelf niet het ingesloten werkboek. In dit voorbeeld blijft het werkboek beschikbaar voor categorielabels, serienamen en de andere series. Zie [Diagram werkboek](/slides/nl/python-java/chart-workbook/) voor werkboekbeheer.

Voor spreidings‑ en bubbelgrafieken gebruik je [setDataSourceTypeForXValues](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapointcollection/#setDataSourceTypeForXValues) en [setDataSourceTypeForYValues](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapointcollection/#setDataSourceTypeForYValues) om de bronnen te kiezen voor [getXValue](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getXValue) en [getYValue](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getYValue). Bubbelgrafieken gebruiken ook [setDataSourceTypeForBubbleSizes](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapointcollection/#setDataSourceTypeForBubbleSizes) voor [getBubbleSize](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getBubbleSize). Stel elke toepasselijke bron in op `DoubleLiterals` voordat je nummers toewijst via de `setAsLiteralDouble`‑methode van die waarde.

## **Stel de overlap van de serie in**

[ChartSeries.getOverlap](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getOverlap) geeft weer hoeveel balken of kolommen overlappen in een 2D‑grafiek, van -100 tot 100 procent. Het is een alleen‑lezen projectie van de instelling op de bovenliggende seriesgroep. Gebruik [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setOverlap) om elke compatibele serie in die groep bij te werken. Deze optie is van toepassing op diagramtypen die gegroepeerde balken of kolommen weergeven; het beïnvloedt geen niet‑gerelateerde seriesgroepen in een combinatie‑grafiek.

Het volgende voorbeeld stelt de overlap in voor de groep die de eerste serie bevat:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

first_slide_index = 0
first_series_index = 0
overlap_percent = 30

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    # Het nieuwe diagram bevat voorbeeldseries, categorieën en waarden.
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    series = chart.getChartData().getSeries().get_Item(first_series_index)
    series.getParentSeriesGroup().setOverlap(overlap_percent)

    presentation.save("series_overlap.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Het resultaat:

![De serie-overlap](series_overlap.png)

## **Wijzig de vulkleur van de serie**

Gebruik [ChartSeries.getFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getFormat) om de standaardvulling voor een hele serie in te stellen. Als een punt al een expliciete vulling heeft, overschrijft de [ChartDataPoint.getFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getFormat)‑instelling de serie‑vulling voor dat punt.

Het volgende voorbeeld past een effen blauwe vulling toe op de eerste serie:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

first_slide_index = 0
first_series_index = 0

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    series = chart.getChartData().getSeries().get_Item(first_series_index)
    series.getFormat().getFill().setFillType(FillType.Solid)
    series.getFormat().getFill().getSolidFillColor().setColor(Color.BLUE)

    presentation.save("series_color.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Het resultaat:

![De kleur van de serie](series_color.png)

## **Wijzig de serienaam**

Een serienaam wordt opgeslagen in het diagram‑datwerkboek en wordt normaal weergegeven in de legende. In het standaardwerkboek dat wordt aangemaakt voor een gegroepeerde kolomgrafiek, bevindt cel B1 zich op rij 0, kolom 1 en bevat de naam van de eerste serie. De benoemde variabelen in het volgende voorbeeld maken die structuur expliciet:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

first_slide_index = 0
worksheet_index = 0
series_name_row_index = 0
first_series_column_index = 1

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    workbook = chart.getChartData().getChartDataWorkbook()
    series_name_cell = workbook.getCell(worksheet_index, series_name_row_index, first_series_column_index)
    series_name_cell.setValue("Revenue")

    presentation.save("series_name.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Je kunt ook de cel bijwerken die al wordt verwezen door [ChartSeries.getName](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getName). Deze aanpak voorkomt dat je een specifieke rij en kolom in een bestaand diagram aanneemt:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

first_slide_index = 0
first_series_index = 0
first_name_cell_index = 0

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    series = chart.getChartData().getSeries().get_Item(first_series_index)
    series_name_cell = series.getName().getAsCells().get_Item(first_name_cell_index)
    series_name_cell.setValue("Revenue")

    presentation.save("series_name.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Het resultaat:

![De serienaam](series_name.png)

### **Maak een serie met een naam uit meerdere cellen**

Een samengestelde serienaam is handig wanneer een productnaam en een rapportageperiode in aparte werkboekcellen zijn opgeslagen. Bijvoorbeeld, je kunt `Product A` in B1 en `2026` in C1 combineren tot één serienaam, terwijl beide delen aan hun broncellen gekoppeld blijven.

Gebruik [ChartDataWorkbook.getCellCollection](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/#getCellCollection) om het naambereik op te halen, en geef die collectie door aan [ChartSeriesCollection.add](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriescollection/#add). Het argument `skipHiddenCells` bepaalt of verborgen cellen worden meegenomen: `True` sluit ze uit, terwijl `False` ze opneemt. In dit voorbeeld wordt `False` gebruikt om elke cel in het naambereik op te nemen.

Het volgende voorbeeld maakt een presentatie met één serie en twee datapoints. Cellen B1:C1 leveren alleen de serienaam; A2:A3 leveren de categorielabels, en B2:B3 leveren de numerieke waarden.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 620, 180)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()
    chart.setLegend(True)

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    # Deze twee cellen leveren de serienaam.
    workbook.getCell(0, 0, 1, "Product A")
    workbook.getCell(0, 0, 2, "2026")
    name_cells = workbook.getCellCollection("Sheet1!$B$1:$C$1", False)
    series = chart.getChartData().getSeries().add(name_cells, ChartType.ClusteredColumn)

    # Aparte cellen leveren de categorieën en numerieke datapunten.
    north_category = workbook.getCell(0, 1, 0, "North")
    south_category = workbook.getCell(0, 2, 0, "South")
    chart.getChartData().getCategories().add(north_category)
    chart.getChartData().getCategories().add(south_category)
    north_value = workbook.getCell(0, 1, 1, jpype.JInt(120))
    south_value = workbook.getCell(0, 2, 1, jpype.JInt(150))
    series.getDataPoints().addDataPointForBarSeries(north_value)
    series.getDataPoints().addDataPointForBarSeries(south_value)

    presentation.save("composite_series_name.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

De resulterende serienaam is `Product A 2026`, met een spatie tussen de twee celwaarden. De legende toont dit als één item voor beide kolommen. De afbeelding hieronder illustreert het resultaat:

![Kolomgrafiek met Noord- en Zuid-waarden en de samengestelde serienaam Product A 2026 in de legende](composite_series_name.png)

## **Haal de automatische vulkleur van de serie op**

[ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getAutomaticSeriesColor) retourneert de kleur die wordt berekend op basis van de serie‑index en de diagramstijl. Dit is de kleur die wordt gebruikt wanneer de serie‑vulling niet expliciet is gedefinieerd. Het aanroepen van de methode leest de berekende kleur; het wijst geen nieuwe vulling toe.

Het volgende voorbeeld drukt de automatische kleur van elke standaardserie af:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

first_slide_index = 0

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    series_count = chart.getChartData().getSeries().size()
    for series_index in range(series_count):
        series = chart.getChartData().getSeries().get_Item(series_index)
        automatic_color = series.getAutomaticSeriesColor()
        print(f"Series {series_index}: {automatic_color}")
finally:
    presentation.dispose()
```

Voorbeeldoutput voor de standaarddiagramstijl:

```text
Series 0: java.awt.Color[r=79,g=129,b=189]
Series 1: java.awt.Color[r=192,g=80,b=77]
Series 2: java.awt.Color[r=155,g=187,b=89]
```

De exacte kleuren hangen af van de diagramstijl en het thema.

## **Stel de omgekeerde vulkleur in voor een diagramserie**

Voor staaf‑, kolom‑ en bubbel‑series kan [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#setInvertIfNegative) negatieve waarden met een andere vulling weergeven. Stel de reguliere serie‑vulling in op effen, schakel inversie in, en wijs de kleur voor negatieve waarden toe via [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getInvertedSolidFillColor). Negatieve getallen blijven ongewijzigd in het werkboek; alleen hun weergavekleur verandert.

Het volgende voorbeeld vervangt de standaard diagramdata door één serie. Werkblad‑rij 0 bevat de serienaam, kolom 0 bevat categorienamen en kolom 1 bevat de waarden:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

first_slide_index = 0
worksheet_index = 0
header_row_index = 0
category_column_index = 0
first_series_column_index = 1
first_data_row_index = 1

category_names = ["Category 1", "Category 2", "Category 3"]
series_values = [-20, 50, -30]

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)
    chart_data = chart.getChartData()
    workbook = chart_data.getChartDataWorkbook()

    chart_data.getSeries().clear()
    chart_data.getCategories().clear()

    series_name_cell = workbook.getCell(worksheet_index, header_row_index, first_series_column_index, "Series 1")
    chart_type = chart.getType()
    series = chart_data.getSeries().add(series_name_cell, chart_type)

    for category_index in range(len(category_names)):
        data_row_index = first_data_row_index + category_index
        category_name = category_names[category_index]
        series_value = series_values[category_index]

        category_cell = workbook.getCell(worksheet_index, data_row_index, category_column_index, category_name)
        chart_data.getCategories().add(category_cell)

        value_cell = workbook.getCell(worksheet_index, data_row_index, first_series_column_index, series_value)
        series.getDataPoints().addDataPointForBarSeries(value_cell)

    automatic_series_color = series.getAutomaticSeriesColor()
    series.getFormat().getFill().setFillType(FillType.Solid)
    series.getFormat().getFill().getSolidFillColor().setColor(automatic_series_color)
    series.setInvertIfNegative(True)
    series.getInvertedSolidFillColor().setColor(Color.RED)

    presentation.save("inverted_solid_fill_color.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Het resultaat:

![De omgekeerde effen vulkleur](inverted_solid_fill_color.png)

Je kunt inversie voor één punt inschakelen via [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#setInvertIfNegative). In het volgende voorbeeld is inversie uitgeschakeld voor de serie en alleen ingeschakeld voor het geselecteerde punt. Het punt krijgt ook een negatieve waarde zodat het effect zichtbaar is:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

first_slide_index = 0
first_series_index = 0
target_data_point_index = 2
negative_value = -30

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    series = chart.getChartData().getSeries().get_Item(first_series_index)
    automatic_series_color = series.getAutomaticSeriesColor()
    series.getFormat().getFill().setFillType(FillType.Solid)
    series.getFormat().getFill().getSolidFillColor().setColor(automatic_series_color)
    series.getInvertedSolidFillColor().setColor(Color.RED)
    series.setInvertIfNegative(False)

    data_point = series.getDataPoints().get_Item(target_data_point_index)
    data_point.getValue().getAsCell().setValue(negative_value)
    data_point.setInvertIfNegative(True)

    presentation.save("data_point_invert_color_if_negative.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Wis een specifieke datapuntwaarde**

Om één punt leeg te maken zonder de andere punten te verwijderen, stel je de onderliggende werkboekcel in op `None`. Voor een kolomgrafiek is de geplotte waarde beschikbaar via [ChartDataPoint.getValue](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getValue). Het datapunt blijft op dezelfde categoriepstatie, maar het diagram behandelt de waarde als leeg volgens de instellingen voor lege waarden van het diagram.

Het volgende voorbeeld wist alleen het tweede punt in de eerste serie:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

first_slide_index = 0
first_series_index = 0
target_data_point_index = 1

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    series = chart.getChartData().getSeries().get_Item(first_series_index)
    data_point = series.getDataPoints().get_Item(target_data_point_index)
    data_point.getValue().getAsCell().setValue(None)

    presentation.save("clear_data_point_value.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Spreidingsgrafieken gebruiken afzonderlijke X‑ en Y‑cellen, en bubbelgrafieken gebruiken ook een grootte‑cel. Wis alleen de cel die de waarde vertegenwoordigt die je wilt verwijderen. Roep [ChartDataPointCollection.clear](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapointcollection/#clear) niet aan wanneer je de andere punten wilt behouden, omdat die methode elk datapunt uit de collectie verwijdert.

## **Beheer de weergave van lege cellen**

Verborgen cellen die waarden bevatten vormen een apart geval ten opzichte van lege cellen. Zie [Gegevens opnemen vanuit verborgen rijen en kolommen](/slides/nl/python-java/chart-workbook/#include-data-from-hidden-rows-and-columns) om gegevens van verborgen werkbladrijen en -kolommen op te nemen of uit te sluiten.

Een lege werkboekcel staat voor ontbrekende gegevens; een cel die `0` bevat staat voor een bekende numerieke waarde. Roep [ChartDataCell.setValue](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/#setValue) aan met `None` om een cel leeg te maken. Een numerieke nul blijft een nul, ongeacht de instelling voor lege cellen.

Gebruik [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setDisplayBlanksAs) om te kiezen hoe het diagram lege cellen weergeeft. Deze instelling geldt voor het gehele diagram. Het wijzigt hoe lege ruimtes worden geplot, zonder de lege werkboekcel te vullen met nul of een geïnterpoleerde waarde.

Het volgende zelfstandige voorbeeld maakt een lijngrafiek met één serie, wist de waarde voor Dag 3, en slaat hetzelfde diagram op in elke modus. Er is geen invoerbestand nodig. De [ChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/) gebruikt werkblad 0, kolom 0 voor categorielabels en kolom 1 voor waarden; rij 0 bevat de serienaam. De uiteindelijke data is `10, 20, leeg, 30, 40`.

```python
import jpage
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, DisplayBlanksAsType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 40, 40, 640, 400)
    chart_data = chart.getChartData()
    workbook = chart_data.getChartDataWorkbook()

    chart_data.getSeries().clear()
    chart_data.getCategories().clear()

    series_name_cell = workbook.getCell(0, 0, 1, "Measurements")
    series = chart_data.getSeries().add(series_name_cell, chart.getType())
    values = [10, 20, 25, 30, 40]

    for i, value in enumerate(values):
        category_cell = workbook.getCell(0, i + 1, 0, f"Day {i + 1}")
        chart_data.getCategories().add(category_cell)
        value_cell = workbook.getCell(0, i + 1, 1, jpype.JInt(value))
        series.getDataPoints().addDataPointForLineSeries(value_cell)

    # Laat dag 3 echt leeg, terwijl de categorie en het datapunt behouden blijven.
    workbook.getCell(0, 3, 1).setValue(None)

    modes = [DisplayBlanksAsType.Gap, DisplayBlanksAsType.Zero, DisplayBlanksAsType.Span]
    mode_names = ["Gap", "Zero", "Span"]
    for mode, mode_name in zip(modes, mode_names):
        chart.setDisplayBlanksAs(mode)
        presentation.save(f"empty_cells_{mode_name}.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Elk uitvoerbestand slaat de vóór het opslaan toegewezen modus op: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` en `empty_cells_Span.pptx`. Om slechts één versie op te slaan, wijs je de gewenste modus toe en sla je de presentatie één keer op in plaats van over de modi te itereren.

De vergelijking hieronder toont dezelfde data in alle drie de bestanden. Dag 3 is in elk geval leeg in het werkboek:

![Lijngrafieken met identieke data: Gap onderbreekt de lijn op Dag 3, Zero laat de lijn naar nul zakken, en Span verbindt Dag 2 met Dag 4.](display_blanks_as.png)

Het zichtbare effect hangt af van het diagramtype. Een lijngrafiek maakt alle drie de modi gemakkelijk vergelijkbaar. Staaf‑ en kolomgrafieken hebben geen lijn om over een ontbrekende categorie te verbinden, zodat `Span` niet het hierboven getoonde verbindingssegment kan produceren; een ontbrekende kolom en een kolom met nulhoogte kunnen er ook gelijk uitzien. Evenzo heeft een spreidingsgrafiek met alleen markeringen geen verbindingslijn. Verwacht niet drie verschillende resultaten voor elk diagramtype; controleer de output voor het type dat je gebruikt.

## **Stel de gatbreedte van de serie in**

Gatbreedte is de ruimte tussen aangrenzende balk‑ of kolomclusters, uitgedrukt als een percentage van de breedte van de balk of kolom. Net als overlap behoort het tot de bovenliggende seriesgroep in plaats van tot één serie. Roep [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapWidth) één keer voor de groep aan. Een grotere waarde creëert meer ruimte tussen de clusters; een kleinere waarde maakt ze dichter.

Het volgende voorbeeld wijzigt de gatbreedte en slaat alleen de uiteindelijke presentatie op:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

first_slide_index = 0
first_series_index = 0
gap_width_percent = 30

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.StackedColumn, 20, 20, 500, 200)

    series = chart.getChartData().getSeries().get_Item(first_series_index)
    series.getParentSeriesGroup().setGapWidth(gap_width_percent)

    presentation.save("gap_width_30.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Het resultaat:

![De gatbreedte](gap_width.png)

## **Toon of verberg serielijnen**

Serielijnen verbinden visueel gerelateerde delen van een diagram. Gebruik [ChartSeriesGroup.setSeriesLines](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setSeriesLines) om ze te tonen of te verbergen in ondersteunde gestapelde staaf‑ en OfPie‑grafieken. In tweedimensionale gestapelde staaf‑ en kolomgrafieken verbinden ze overeenkomstige stapelgrenzen over categorieën. In Pie of Pie‑ en Bar of Pie‑grafieken verbinden ze de hoofdplot met de secundaire plot. Deze instelling is geen algemene connector voor andere diagramtypen.

Toegang tot de groep verkrijg je via [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getParentSeriesGroup). De instelling geldt voor elke serie in die groep. [ChartSeries.hasSeriesLines](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#hasSeriesLines) is alleen‑lezen en weerspiegelt de instelling van de bovenliggende groep; roep de setter van de groep aan om deze bij te werken.

Het volgende voorbeeld maakt één [PieOfPie](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/#PieOfPie) diagram met standaarddata. Het slaat hetzelfde diagram eerst op met serielijnen ingeschakeld en vervolgens uitgeschakeld, waardoor twee presentaties voor vergelijking ontstaan.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.PieOfPie, 50, 50, 600, 400)
    series = chart.getChartData().getSeries().get_Item(0)
    series_group = series.getParentSeriesGroup()

    series_group.setSeriesLines(True)
    presentation.save("series_lines_enabled.pptx", SaveFormat.Pptx)

    series_group.setSeriesLines(False)
    presentation.save("series_lines_disabled.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

| Serielijnen ingeschakeld | Serielijnen uitgeschakeld |
| --- | --- |
| ![Pie of Pie-diagram met serielijnen ingeschakeld](series_lines_enabled.png) | ![Pie of Pie-diagram met serielijnen uitgeschakeld](series_lines_disabled.png) |
| De twee lijnen verbinden de hoofd‑pie met de secundaire pie. | Beide pies blijven zichtbaar, maar de verbindingslijnen zijn verborgen. |

Serielijnen verschillen van datalabel‑leidingslijnen, die labels met hun datapoints verbinden; rasterlijnen, die intervallen langs de assen markeren; en de lijnen in een lijngrafiek, die gegevenswaarden weergeven. Deze instelling beheert die elementen niet.

## **FAQ**

**Welke diagramtypen ondersteunen dataseries?**

Alle diagramtypen die worden vertegenwoordigd door de [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) enumeratie gebruiken diagramgegevens, maar hun series hebben niet allemaal dezelfde waardestructuur of instellingen. Bijvoorbeeld, categoriegrafieken gebruiken categorieën en waarden, spreidingsgrafieken gebruiken X‑ en Y‑waarden, en bubbelgrafieken voegen bubbelgroottes toe. Gebruik de datapunt‑creatiemethode die overeenkomt met het serietype. Opties zoals overlap en gatbreedte gelden alleen voor compatibele balk‑ of kolomgroepen.

**Wat is een diagram‑seriesgroep?**

Een [ChartSeriesGroup](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/) bevat compatibele series die groeps‑niveau plotinstellingen delen. Een combinatie‑diagram kan meer dan één groep bevatten, dus het wijzigen van de groep die via één serie wordt bereikt, verandert niet per se elke serie in het diagram.

**Bevat een nieuw aangemaakt diagram standaardgegevens?**

Ja. Standaard maakt [ShapeCollection.addChart](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addChart) voorbeeldseries, -categorieën en -waarden aan. Je kunt die cellen bewerken of zowel de serie‑ als categorieverzamelingen wissen voordat je een volledig aangepaste dataset toevoegt. Een overload kan ook een diagram zonder standaardgegevens maken.

**Hoe zijn diagramobjecten verbonden met werkboekcellen?**

Serienamen, categorielabels en datapuntwaarden verwijzen naar cellen in een [ChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/). Het wijzigen van een verwezen cel werkt het corresponderende diagramonderdeel bij. Wanneer je aangepaste data maakt, houd je de categorierijen en serie‑waardrijen op één lijn zodat elk punt onder de beoogde categorie wordt geplot.

**Hoe wis ik één punt in plaats van de hele serie?**

Stel de betreffende waarde‑cel in op `None` om de categoriepstatie van het punt als een leeg punt te behouden. Gebruik [ChartDataPointCollection.clear](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapointcollection/#clear) alleen wanneer je alle punten uit die serie wilt verwijderen. Als je ook categorieën verwijdert, werk je elke serie bij zodat hun waarden nog steeds overeenkomen met de categorieverzameling.

**Hoe worden lege punten weergegeven?**

Het resultaat hangt af van het diagramtype en de waarde geconfigureerd via [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setDisplayBlanksAs). Ondersteunde diagrammen kunnen lege waarden weergeven als gaten, als nulwaarden, of door naburige punten te verbinden. Kies de instelling die overeenkomt met de betekenis van ontbrekende gegevens in je presentatie. Zie [Beheer de weergave van lege cellen](#control-the-display-of-empty-cells) voor een volledig voorbeeld en een visuele vergelijking.

**Hoe worden negatieve waarden opgemaakt?**

Voor ondersteunde balk‑, kolom‑ en bubbel‑series roep je [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#setInvertIfNegative) aan en stel je de kleur in die wordt geretourneerd door [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getInvertedSolidFillColor). Je kunt het gedrag voor een individueel punt overschrijven met [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#setInvertIfNegative). Deze methoden beïnvloeden de opmaak, niet de opgeslagen numerieke waarden.

**Welke opmaak heeft voorrang wanneer zowel een serie als een punt zijn opgemaakt?**

Expliciete datapunt‑opmaak heeft voorrang voor dat punt. Andere punten blijven de expliciete serie‑opmaak gebruiken of, wanneer de serie‑opmaak niet gedefinieerd is, de automatische diagramstijl en het thema. Groepsinstellingen zoals overlap en gatbreedte regelen de lay‑out en zijn geen overrides op punt‑niveau.

**Is er een limiet aan het aantal series dat een diagram kan bevatten?**

Aspose.Slides stelt geen afzonderlijke vaste limiet voor het aantal series. In de praktijk bepalen bestandsbeperkingen van de presentatie, beschikbare geheugen, render‑tijd en leesbaarheid van het diagram een praktische limiet.

**Wat moet ik aanpassen wanneer kolommen te dicht bij elkaar of te ver uit elkaar staan?**

Roep [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapWidth) aan op de juiste bovenliggende seriesgroep. Verhoog de waarde om de ruimte tussen de clusters te vergroten, of verlaag deze om de clusters dichter bij elkaar te brengen.