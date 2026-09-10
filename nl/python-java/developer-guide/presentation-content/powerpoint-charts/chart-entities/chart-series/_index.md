---
title: Beheer grafiekreeksen in presentaties in Python
linktitle: Gegevensreeksen
type: docs
url: /nl/python-java/chart-series/
keywords:
- grafiekreeks
- reeks overlap
- reeks kleur
- reeksnaam
- datapunt
- werkbladcel
- reeks gat
- negatieve waarde
- PowerPoint
- presentatie
- Python
- Java
- Aspose.Slides
description: "Leer hoe u grafiekreeksen, datapunten, werkbladcellen, opmaak, overlap, gatbreedte en negatieve waarden in presentaties kunt beheren met Aspose.Slides voor Python via Java."
---
## **Overzicht**

Een grafiek slaat zijn geplotte gegevens op in een chart‑data‑werkmap. Een [ChartSeries](https://reference.aspose.com/slides/nl/python-java/aspose.slides/chartseries/) vertegenwoordigt één set verwante waarden, en elke [ChartDataPoint](https://reference.aspose.com/slides/nl/python-java/aspose.slides/chartdatapoint/) in de reeks verwijst naar één of meer werkmapcellen. [ChartCategory](https://reference.aspose.com/slides/nl/python-java/aspose.slides/chartcategory/)‑objecten leveren de etiketten of groeperingswaarden die door de reeksen worden gedeeld. De reeksnaam, categorieën en puntwaarden zijn daarom gekoppeld aan [ChartDataCell](https://reference.aspose.com/slides/nl/python-java/aspose.slides/chartdatacell/)‑objecten in plaats van alleen als weergavetekst te worden opgeslagen.

Voor een typische categorie‑grafiek gebruikt de standaardwerkmap rij 0 voor reeksnamen, kolom 0 voor categorienamen en de overige cellen voor reekswerte. Werkblad‑, rij‑ en kolom‑indexen die aan [ChartDataWorkbook.getCell](https://reference.aspose.com/slides/nl/python-java/aspose.slides/chartdataworkbook/#getCell) worden doorgegeven, zijn nulgebaseerd. Deze indeling is handig wanneer u een grafiek met standaarden gegevens maakt, maar ga er niet vanuit dat iedere bestaande grafiek deze indeling gebruikt. Voor een geladen presentatie inspecteert u de cellen die door de reeksen, categorieën en datapunten worden gerefereerd voordat u werkmapwaarden wijzigt.

Grafiekinstellingen hebben drie verschillende reikwijdtes:

- Instellingen op reeksniveau, zoals [ChartSeries.getFormat](https://reference.aspose.com/slides/nl/python-java/aspose.slides/chartseries/#getFormat), bieden de standaard‑uiterlijk voor alle punten in één reeks.
- Instellingen per datumpunt, zoals [ChartDataPoint.getFormat](https://reference.aspose.com/slides/nl/python-java/aspose.slides/chartdatapoint/#getFormat), overschrijven het reeksen‑uiterlijk voor één punt.
- Groepsinstellingen gelden voor compatibele reeksen die tot dezelfde [ChartSeriesGroup](https://reference.aspose.com/slides/nl/python-java/aspose.slides/chartseriesgroup/) behoren. Toegang tot de groep via [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/nl/python-java/aspose.slides/chartseries/#getParentSeriesGroup) wanneer u opties wilt instellen zoals overlap of gatbreedte.

Wanneer geen expliciete punt‑ of reeksvulling is ingesteld, bepalen de grafiekstijl en het thema het automatische uiterlijk. Wanneer zowel reeks‑ als punt‑opmaak aanwezig zijn, heeft de punt‑opmaak voorrang voor dat punt.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **De overlap van de grafiekreeks instellen**

[ChartSeries.getOverlap](https://reference.aspose.com/slides/nl/python-java/aspose.slides/chartseries/#getOverlap) geeft aan hoeveel balken of kolommen overlappen in een 2D‑grafiek, van -100 tot 100 procent. Het is een alleen‑lezen projectie van de instelling op de bovenliggende reeksgroep. Gebruik [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/nl/python-java/aspose.slides/chartseriesgroup/#setOverlap) om elke compatibele reeks in die groep bij te werken. Deze optie geldt voor grafiektype­n die gegroepeerde balken of kolommen weergeven; hij beïnvloedt niet ongerelateerde reeksgroepen in een combinatiegrafiek.

Het volgende voorbeeld stelt de overlap in voor de groep die de eerste reeks bevat:

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

    # De nieuwe grafiek bevat voorbeeldreeksen, categorieën en waarden.
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    series = chart.getChartData().getSeries().get_Item(first_series_index)
    series.getParentSeriesGroup().setOverlap(overlap_percent)

    presentation.save("series_overlap.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Het resultaat:

![The series overlap](series_overlap.png)

## **De vulkleur van de reeks wijzigen**

Gebruik [ChartSeries.getFormat](https://reference.aspose.com/slides/nl/python-java/aspose.slides/chartseries/#getFormat) om de standaardvulling voor een hele reeks in te stellen. Als een punt al een expliciete vulling heeft, zal de [ChartDataPoint.getFormat](https://reference.aspose.com/slides/nl/python-java/aspose.slides/chartdatapoint/#getFormat)‑instelling de reeksvulling voor dat punt overschrijven.

Het volgende voorbeeld past een egale blauwe vulling toe op de eerste reeks:

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

![The color of the series](series_color.png)

## **De naam van de reeks wijzigen**

Een reeksnamen wordt opgeslagen in de chart‑data‑werkmap en wordt normaal gesproken in de legenda weergegeven. In de standaardwerkmap die wordt aangemaakt voor een gegroepeerde kolomgrafiek, bevindt cel B1 zich op rij 0, kolom 1 en bevat de naam van de eerste reeks. De benoemde variabelen in het volgende voorbeeld maken die structuur expliciet:

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

U kunt ook de cel bijwerken die al door [ChartSeries.getName](https://reference.aspose.com/slides/nl/python-java/aspose.slides/chartseries/#getName) wordt gerefereerd. Deze aanpak vermijdt aannames over een specifieke rij en kolom in een bestaande grafiek:

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

![The series name](series_name.png)

## **De automatische vulkleur van de reeks ophalen**

[ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/nl/python-java/aspose.slides/chartseries/#getAutomaticSeriesColor) retourneert de kleur die wordt berekend op basis van de reeksen‑index en de grafiekstijl. Dit is de kleur die wordt gebruikt wanneer de reeksvulling niet expliciet is gedefinieerd. Het aanroepen van de methode leest de berekende kleur; hij wijzigt geen nieuwe vulling.

Het volgende voorbeeld drukt de automatische kleur van elke standaardreeks af:

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

Voorbeeldoutput voor de standaardgrafiekstijl:

```text
Series 0: java.awt.Color[r=79,g=129,b=189]
Series 1: java.awt.Color[r=192,g=80,b=77]
Series 2: java.awt.Color[r=155,g=187,b=89]
```

De exacte kleuren hangen af van de grafiekstijl en het thema.

## **Omgekeerde vulkleur voor een grafiekreeks instellen**

Voor balk‑, kolom‑ en bubbelformules kan [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/nl/python-java/aspose.slides/chartseries/#setInvertIfNegative) negatieve waarden met een andere vulling weergeven. Stel de reguliere reeksvulling in op egaal, activeer inversie en ken de negatieve‑waarde‑kleur toe via [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/nl/python-java/aspose.slides/chartseries/#getInvertedSolidFillColor). Negatieve getallen blijven onveranderd in de werkmap; alleen hun weergavekleur verandert.

Het volgende voorbeeld vervangt de standaard‑grafiekgegevens door één reeks. Werkblad‑rij 0 bevat de reeksnaam, kolom 0 bevat categorienamen en kolom 1 bevat de waarden:

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

![The inverted solid fill color](inverted_solid_fill_color.png)

U kunt inversie voor één punt inschakelen via [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/nl/python-java/aspose.slides/chartdatapoint/#setInvertIfNegative). In het volgende voorbeeld is inversie uitgeschakeld voor de reeks en alleen ingeschakeld voor het geselecteerde punt. Het punt krijgt bovendien een negatieve waarde zodat het effect zichtbaar is:

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

## **Een specifieke datumpuntwaarde wissen**

Om één punt leeg te maken zonder de andere punten te verwijderen, stelt u de onderliggende werkmapcel in op `None`. Voor een kolomgrafiek is de geplotte waarde beschikbaar via [ChartDataPoint.getValue](https://reference.aspose.com/slides/nl/python-java/aspose.slides/chartdatapoint/#getValue). Het datumpunt blijft op dezelfde categorielocatie, maar de grafiek behandelt zijn waarde als leeg volgens de instellingen voor lege waarden van de grafiek.

Het volgende voorbeeld wist alleen het tweede punt in de eerste reeks:

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

Scatter‑grafieken gebruiken aparte X‑ en Y‑cellen, en bubbelfigur‑grafieken gebruiken ook een grootte‑cel. Wis alleen de cel die de waarde vertegenwoordigt die u wilt verwijderen. Roep niet [ChartDataPointCollection.clear](https://reference.aspose.com/slides/nl/python-java/aspose.slides/chartdatapointcollection/#clear) aan wanneer u de andere punten wilt behouden, want die methode verwijdert elk datumpunt uit de collectie.

## **De gatbreedte van de reeks instellen**

Gatbreedte is de ruimte tussen aangrenzende balk‑ of kolom‑clusters, uitgedrukt als een percentage van de balk‑ of kolombreedte. Net als overlap behoort het tot de bovenliggende reeksgroep in plaats van tot één reeks. Roep [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/nl/python-java/aspose.slides/chartseriesgroup/#setGapWidth) één keer aan voor de groep. Een grotere waarde creëert meer ruimte tussen clusters; een kleinere waarde maakt ze dichter op elkaar.

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

![The gap width](gap_width.png)

## **FAQ**

**Welke grafiektype‑n ondersteunen gegevensreeksen?**

Alle grafiektype‑n die worden vertegenwoordigd door de [ChartType](https://reference.aspose.com/slides/nl/python-java/aspose.slides/charttype/)‑enumeratie gebruiken grafiekgegevens, maar hun reeksen hebben niet allemaal dezelfde waardestructuur of instellingen. Bijvoorbeeld, categorie‑grafieken gebruiken categorieën en waarden, spreidingsgrafieken gebruiken X‑ en Y‑waarden, en bubbels grafieken voegen bubbelformaten toe. Gebruik de methode voor het aanmaken van datapunten die past bij het type reeks. Opties zoals overlap en gatbreedte gelden alleen voor compatibele balk‑ of kolomgroepen.

**Wat is een grafiekreeks‑groep?**

Een [ChartSeriesGroup](https://reference.aspose.com/slides/nl/python-java/aspose.slides/chartseriesgroup/) bevat compatibele reeksen die groeps‑niveau plot‑instellingen delen. Een combinatiegrafiek kan meer dan één groep bevatten, waardoor het wijzigen van de groep die via één reeks wordt bereikt niet per se alle reeksen in de grafiek wijzigt.

**Bevat een nieuw gemaakte grafiek standaardgegevens?**

Ja. Standaard maakt [ShapeCollection.addChart](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shapecollection/#addChart) voorbeeldreeksen, categorieën en waarden aan. U kunt die cellen bewerken of zowel de reeks‑ als categorie‑collecties wissen voordat u een volledig aangepaste dataset toevoegt. Een overload kan ook een grafiek zonder standaardgegevens creëren.

**Hoe zijn grafiekobjecten gekoppeld aan werkmapcellen?**

Reeksnamen, categorielabels en datumpunt‑waarden refereren naar cellen in een [ChartDataWorkbook](https://reference.aspose.com/slides/nl/python-java/aspose.slides/chartdataworkbook/). Het wijzigen van een gerefereerde cel werkt het overeenkomstige grafelement bij. Wanneer u aangepaste data bouwt, houdt u de rijen voor categorieën en reekswerte‑rijen op één lijn zodat elk punt onder de beoogde categorie wordt geplot.

**Hoe kan ik één punt wissen in plaats van de hele reeks?**

Stel de relevante waardecel in op `None` om de positie van het punt in de categorie te behouden als een leeg punt. Gebruik [ChartDataPointCollection.clear](https://reference.aspose.com/slides/nl/python-java/aspose.slides/chartdatapointcollection/#clear) alleen wanneer u alle punten uit die reeks wilt verwijderen. Als u tevens categorieën verwijdert, werk dan elke reeks bij zodat hun waarden uitgelijnd blijven met de categoriec​ollectie.

**Hoe worden lege punten weergegeven?**

Het resultaat hangt af van het grafiektype en de waarde die is ingesteld via [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/nl/python-java/aspose.slides/chart/#setDisplayBlanksAs). Ondersteunde grafieken kunnen lege waarden weergeven als gaten, als nulwaarden, of door naburige punten te verbinden. Kies de instelling die past bij de betekenis van ontbrekende data in uw presentatie.

**Hoe worden negatieve waarden opgemaakt?**

Voor ondersteunde balk‑, kolom‑ en bubbelformules roept u [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/nl/python-java/aspose.slides/chartseries/#setInvertIfNegative) aan en stelt u de kleur in die wordt geretourneerd door [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/nl/python-java/aspose.slides/chartseries/#getInvertedSolidFillColor). U kunt het gedrag voor een individueel punt overschrijven met [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/nl/python-java/aspose.slides/chartdatapoint/#setInvertIfNegative). Deze methoden beïnvloeden alleen de opmaak, niet de opgeslagen numerieke waarden.

**Welke opmaak heeft voorrang wanneer zowel een reeks als een punt zijn opgemaakt?**

Expliciete datumpunt‑opmaak heeft voorrang voor dat punt. Andere punten blijven de expliciete reeks‑opmaak gebruiken of, wanneer de reeks‑opmaak niet is gedefinieerd, de automatische grafiekstijl en het thema. Groepsinstellingen zoals overlap en gatbreedte bepalen de lay‑out en zijn geen punt‑niveau opmaak‑overschrijvingen.

**Is er een limiet aan het aantal reeksen dat een grafiek kan bevatten?**

Aspose.Slides legt geen apart vast limiet op voor het aantal reeksen. In de praktijk bepalen de limieten van het presentatie‑bestand, beschikbaar geheugen, render‑tijd en leesbaarheid van de grafiek een nuttige grens.

**Wat moet ik aanpassen wanneer kolommen te dicht of te ver uit elkaar staan?**

Roep [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/nl/python-java/aspose.slides/chartseriesgroup/#setGapWidth) aan op de juiste bovenliggende reeksgroep. Verhoog de waarde om de ruimte tussen clusters te vergroten, of verlaag deze om de clusters dichter bij elkaar te brengen.