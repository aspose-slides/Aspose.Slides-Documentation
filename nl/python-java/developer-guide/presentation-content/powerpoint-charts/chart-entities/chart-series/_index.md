---
title: Beheer van grafiekgegevensseries in presentaties in Python
linktitle: Gegevensseries
type: docs
url: /nl/python-java/chart-series/
keywords:
- grafiekserie
- serie-overlap
- serie-kleur
- serie-naam
- datapunt
- werkmapcel
- serie-gat
- negatieve waarde
- PowerPoint
- presentatie
- Python
- Java
- Aspose.Slides
description: "Leer hoe u grafiekseries, datapoints, werkmapcellen, opmaak, overlapping, gatbreedte en negatieve waarden in presentaties kunt beheren met Aspose.Slides voor Python via Java."
---
## **Overzicht**

Een grafiek slaat haar getekende gegevens op in een grafiek‑gegevens‑werkmap. Een [ChartSeries](https://reference.aspose.com/slides/nl/python-java/aspose.slides/chartseries/) vertegenwoordigt één set verwante waarden, en elk [ChartDataPoint](https://reference.aspose.com/slides/nl/python-java/aspose.slides/chartdatapoint/) in de serie verwijst naar één of meer werkmapcellen. [ChartCategory](https://reference.aspose.com/slides/nl/python-java/aspose.slides/chartcategory/)‑objecten bieden de labels of groeperingswaarden die door de series gedeeld worden. De serienaam, categorieën en puntwaarden zijn daardoor gekoppeld aan [ChartDataCell](https://reference.aspose.com/slides/nl/python-java/aspose.slides/chartdatacell/)‑objecten in plaats van alleen als weergavetekst opgeslagen te worden.

Voor een typische categorie‑grafiek gebruikt de standaardwerkmap rij 0 voor serienamen, kolom 0 voor categorienamen en de resterende cellen voor serie‑waarden. Werkblad‑, rij‑ en kolomindexen die aan [ChartDataWorkbook.getCell](https://reference.aspose.com/slides/nl/python-java/aspose.slides/chartdataworkbook/#getCell) worden doorgegeven, zijn nul‑gebaseerd. Deze indeling is handig wanneer je een grafiek met standaardgegevens maakt, maar veronderstel niet dat elke bestaande grafiek deze indeling hanteert. Voor een geladen presentatie moet je de cellen die door de series, categorieën en datapoints worden gerefereerd onderzoeken voordat je werkmapwaarden wijzigt.

Grafiekinstellingen hebben drie verschillende scopes:

- Instellingen op serieniveau, zoals [ChartSeries.getFormat](https://reference.aspose.com/slides/nl/python-java/aspose.slides/chartseries/#getFormat), bieden de standaarduiterlijk voor alle punten in één serie.
- Instellingen per datapunt, zoals [ChartDataPoint.getFormat](https://reference.aspose.com/slides/nl/python-java/aspose.slides/chartdatapoint/#getFormat), overschrijven het serie‑uiterlijk voor één punt.
- Groepsinstellingen zijn van toepassing op compatibele series die tot dezelfde [ChartSeriesGroup](https://reference.aspose.com/slides/nl/python-java/aspose.slides/chartseriesgroup/) behoren. Toegang tot de groep verkrijg je via [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/nl/python-java/aspose.slides/chartseries/#getParentSeriesGroup) wanneer je opties moet instellen zoals overlap of gatbreedte.

Wanneer er geen expliciete vulling voor punt of serie is ingesteld, bepalen de grafiekstijl en het thema het automatische uiterlijk. Wanneer zowel serie‑ als punt‑formattering aanwezig zijn, heeft de punt‑formattering voorrang voor dat punt.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Instellen van de overlap van de grafiekserie**

[ChartSeries.getOverlap](https://reference.aspose.com/slides/nl/python-java/aspose.slides/chartseries/#getOverlap) meldt hoeveel balken of kolommen overlappen in een 2D‑grafiek, van –100 tot 100 procent. Het is een alleen‑lezen projectie van de instelling op de bovenliggende serie‑groep. Gebruik [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/nl/python-java/aspose.slides/chartseriesgroup/#setOverlap) om elke compatibele serie in die groep bij te werken. Deze optie is van toepassing op grafiektype‑s die gegroepeerde balken of kolommen tonen; hij heeft geen invloed op niet‑gerelateerde serie‑groepen in een combinatiegrafiek.

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

    # De nieuwe grafiek bevat voorbeeldseries, categorieën en waarden.
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    series = chart.getChartData().getSeries().get_Item(first_series_index)
    series.getParentSeriesGroup().setOverlap(overlap_percent)

    presentation.save("series_overlap.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Het resultaat:

![The series overlap](series_overlap.png)

## **Wijzigen van de vulkleur van de serie**

Gebruik [ChartSeries.getFormat](https://reference.aspose.com/slides/nl/python-java/aspose.slides/chartseries/#getFormat) om de standaardvulling voor een volledige serie in te stellen. Als een punt al een expliciete vulling heeft, overschrijft de [ChartDataPoint.getFormat](https://reference.aspose.com/slides/nl/python-java/aspose.slides/chartdatapoint/#getFormat)‑instelling de serie‑vulling voor dat punt.

Het volgende voorbeeld past een homogene blauwe vulling toe op de eerste serie:

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

## **Wijzigen van de serienaam**

Een serienaam wordt opgeslagen in de grafiek‑gegevens‑werkmap en normaal weergegeven in de legenda. In de standaardwerkmap die voor een gegroepeerde kolomgrafiek wordt aangemaakt, bevindt cel B1 zich op rij 0, kolom 1 en bevat de naam van de eerste serie. De benoemde variabelen in het volgende voorbeeld maken die structuur expliciet:

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

Je kunt ook de cel bijwerken die al wordt gerefereerd door [ChartSeries.getName](https://reference.aspose.com/slides/nl/python-java/aspose.slides/chartseries/#getName). Deze benadering voorkomt dat je een specifieke rij en kolom in een bestaande grafiek aanneemt:

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

## **Automatisch de vulkleur van de serie ophalen**

[ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/nl/python-java/aspose.slides/chartseries/#getAutomaticSeriesColor) retourneert de kleur die wordt berekend op basis van de serienaam en de grafiekstijl. Dit is de kleur die wordt gebruikt wanneer de serie‑vulling niet expliciet is gedefinieerd. Het aanroepen van de methode leest de berekende kleur; hij wijst geen nieuwe vulling toe.

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

Voorbeeldoutput voor de standaardgrafiekstijl:

```text
Series 0: java.awt.Color[r=79,g=129,b=189]
Series 1: java.awt.Color[r=192,g=80,b=77]
Series 2: java.awt.Color[r=155,g=187,b=89]
```

De exacte kleuren hangen af van de grafiekstijl en het thema.

## **Inverted vulkleur instellen voor een grafiekserie**

Voor balk‑, kolom‑ en bubbel‑series kan [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/nl/python-java/aspose.slides/chartseries/#setInvertIfNegative) negatieve waarden met een andere vulling weergeven. Stel de reguliere serie‑vulling in op solid, schakel inversie in, en wijs de negatieve‑waarde‑kleur toe via [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/nl/python-java/aspose.slides/chartseries/#getInvertedSolidFillColor). Negatieve getallen blijven ongewijzigd in de werkmap; alleen hun weergavekleur verandert.

Het volgende voorbeeld vervangt de standaardgrafiekgegevens door één serie. Werkblad‑rij 0 bevat de serienaam, kolom 0 bevat categorienamen, en kolom 1 bevat de waarden:

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

Je kunt inversie voor één punt inschakelen via [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/nl/python-java/aspose.slides/chartdatapoint/#setInvertIfNegative). In het volgende voorbeeld is inversie uitgeschakeld voor de serie en alleen ingeschakeld voor het geselecteerde punt. Het punt krijgt ook een negatieve waarde zodat het effect zichtbaar is:

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

## **Een specifieke datapuntwaarde wissen**

Om één punt leeg te maken zonder de andere punten te verwijderen, stel je de onderliggende werkmapcel in op `None`. Voor een kolomgrafiek is de getekende waarde beschikbaar via [ChartDataPoint.getValue](https://reference.aspose.com/slides/nl/python-java/aspose.slides/chartdatapoint/#getValue). Het datapunt blijft op dezelfde categorielocatie, maar de grafiek behandelt zijn waarde als leeg volgens de blanco‑waarde‑instellingen van de grafiek.

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

Spreidingsgrafieken gebruiken afzonderlijke X‑ en Y‑cellen, en bubbelgrafieken gebruiken bovendien een grootte‑cel. Wis alleen de cel die de waarde vertegenwoordigt die je wilt verwijderen. Roep [ChartDataPointCollection.clear](https://reference.aspose.com/slides/nl/python-java/aspose.slides/chartdatapointcollection/#clear) niet aan wanneer je de andere punten wilt behouden, want die methode verwijdert elk datapunt uit de collectie.

## **Weergave van lege cellen beheren**

Verborgen cellen die waarden bevatten zijn een ander geval dan lege cellen. Zie [Include Data from Hidden Rows and Columns](/slides/nl/python-java/chart-workbook/#include-data-from-hidden-rows-and-columns) om gegevens uit verborgen werkbladrijen en -kolommen in of uit te sluiten.

Een lege werkmapcel vertegenwoordigt ontbrekende gegevens; een cel die `0` bevat, vertegenwoordigt een bekende numerieke waarde. Roep [ChartDataCell.setValue](https://reference.aspose.com/slides/nl/python-java/aspose.slides/chartdatacell/#setValue) met `None` aan om een cel leeg te maken. Een numerieke nul blijft een nul, ongeacht de lege‑cel‑instelling.

Gebruik [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/nl/python-java/aspose.slides/chart/#setDisplayBlanksAs) om te kiezen hoe de grafiek lege cellen weergeeft. Deze instelling geldt voor de hele grafiek. Hij verandert hoe lege waarden worden getekend, zonder de lege werkmapcel te vullen met nul of een geïnterpoleerde waarde.

Het volgende zelfstandige voorbeeld maakt een lijngrafiek met één serie, wist de waarde voor Dag 3, en slaat dezelfde grafiek op met elke modus. Er is geen invoerbestand nodig. De [ChartDataWorkbook](https://reference.aspose.com/slides/nl/python-java/aspose.slides/chartdataworkbook/) gebruikt werkblad 0, kolom 0 voor categorielabels, en kolom 1 voor waarden; rij 0 bevat de serienaam. De uiteindelijke gegevens zijn `10, 20, empty, 30, 40`.

```python
import jpype
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

    # Laat Dag 3 echt leeg, terwijl de categorie en datapunt behouden blijven.
    workbook.getCell(0, 3, 1).setValue(None)

    modes = [DisplayBlanksAsType.Gap, DisplayBlanksAsType.Zero, DisplayBlanksAsType.Span]
    mode_names = ["Gap", "Zero", "Span"]
    for mode, mode_name in zip(modes, mode_names):
        chart.setDisplayBlanksAs(mode)
        presentation.save(f"empty_cells_{mode_name}.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Elke uitvoerbestand slaat de modus op die vóór het opslaan is toegewezen: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` en `empty_cells_Span.pptx`. Om slechts één versie op te slaan, wijs je de gewenste modus toe en sla je de presentatie eenmalig op in plaats van over de modi te itereren.

De vergelijking hieronder toont dezelfde gegevens in alle drie de bestanden. Dag 3 is in de werkmap in elk geval leeg:

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

Het zichtbare effect hangt af van het grafiektype. Een lijngrafiek maakt alle drie de modi gemakkelijk te vergelijken. Balk‑ en kolomgrafieken hebben geen lijn om over een ontbrekende categorie heen te verbinden, dus `Span` kan niet het verbindingssegment produceren dat hierboven wordt getoond; een ontbrekende kolom en een nul‑hoogte kolom kunnen er ook op elkaar lijken. Evenzo heeft een spreidingsgrafiek met alleen markers geen verbindingslijn. Verwacht niet drie verschillende resultaten voor elk grafiektype; controleer de output voor het type dat je gebruikt.

## **Instellen van de gatbreedte van de serie**

Gatbreedte is de ruimte tussen aangrenzende balk‑ of kolomclusters, uitgedrukt als een percentage van de balk‑ of kolombreedte. Net als overlap behoort het tot de bovenliggende serie‑groep in plaats van tot één serie. Roep [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/nl/python-java/aspose.slides/chartseriesgroup/#setGapWidth) eenmaal voor de groep aan. Een grotere waarde creëert meer ruimte tussen clusters; een kleinere waarde maakt ze dichter opeen.

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

**Welke grafiektype‑s ondersteunen dataseries?**

Alle grafiektype‑s die worden vertegenwoordigd door de [ChartType](https://reference.aspose.com/slides/nl/python-java/aspose.slides/charttype/)‑enumeratie gebruiken grafiekgegevens, maar hun series hebben niet allemaal dezelfde waardestructuur of instellingen. Bijvoorbeeld: categoriegrafieken gebruiken categorieën en waarden, spreidingsgrafieken gebruiken X‑ en Y‑waarden, en bubbelgrafieken voegen bubbelgroottes toe. Gebruik de methode voor datapuntcreatie die overeenkomt met het serietype. Opties zoals overlap en gatbreedte zijn alleen van toepassing op compatibele balk‑ of kolomgroepen.

**Wat is een grafiekserie‑groep?**

Een [ChartSeriesGroup](https://reference.aspose.com/slides/nl/python-java/aspose.slides/chartseriesgroup/) bevat compatibele series die groeps‑niveau plotinstellingen delen. Een combinatiegrafiek kan meer dan één groep bevatten, zodat het wijzigen van de groep die via één serie wordt bereikt, niet noodzakelijk elke serie in de grafiek wijzigt.

**Bevat een nieuw aangemaakte grafiek standaardgegevens?**

Ja. Standaard maakt [ShapeCollection.addChart](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shapecollection/#addChart) voorbeeld‑series, -categorieën en -waarden aan. Je kunt die cellen bewerken of zowel de serie‑ als de categorieverzamelingen wissen voordat je een volledig eigen gegevensset toevoegt. Een overload kan ook een grafiek zonder standaardgegevens creëren.

**Hoe zijn grafiekobjecten gekoppeld aan werkmapcellen?**

Serienamen, categorielabels en datapunt‑waarden refereren cellen in een [ChartDataWorkbook](https://reference.aspose.com/slides/nl/python-java/aspose.slides/chartdataworkbook/). Het wijzigen van een gerefereerde cel werkt het corresponderende grafiekelement bij. Wanneer je aangepaste gegevens maakt, houd je de categorie‑rijen en serie‑waarde‑rijen uitgelijnd zodat elk punt onder de beoogde categorie wordt getekend.

**Hoe wis ik één punt in plaats van de volledige serie?**

Stel de betreffende waarde‑cel in op `None` om de positie van de categorie van het punt te behouden als een leeg punt. Gebruik [ChartDataPointCollection.clear](https://reference.aspose.com/slides/nl/python-java/aspose.slides/chartdatapointcollection/#clear) alleen wanneer je alle punten van die serie wilt verwijderen. Als je ook categorieën verwijdert, werk je elke serie bij zodat hun waarden op één lijn blijven met de categorieverzameling.

**Hoe worden lege punten weergegeven?**

Het resultaat hangt af van het grafiektype en de waarde die via [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/nl/python-java/aspose.slides/chart/#setDisplayBlanksAs) is geconfigureerd. Ondersteunde grafieken kunnen lege waarden weergeven als gaten, als nul‑waarden, of door aangrenzende punten te verbinden. Kies de instelling die past bij de betekenis van ontbrekende data in je presentatie. Zie [Control the Display of Empty Cells](#control-the-display-of-empty-cells) voor een volledig voorbeeld en visuele vergelijking.

**Hoe worden negatieve waarden opgemaakt?**

Voor ondersteunde balk‑, kolom‑ en bubbel‑series roep je [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/nl/python-java/aspose.slides/chartseries/#setInvertIfNegative) aan en stel je de kleur in die wordt geretourneerd door [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/nl/python-java/aspose.slides/chartseries/#getInvertedSolidFillColor). Je kunt het gedrag voor een individueel punt overschrijven met [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/nl/python-java/aspose.slides/chartdatapoint/#setInvertIfNegative). Deze methoden beïnvloeden de opmaak, niet de opgeslagen numerieke waarden.

**Welke opmaak wint wanneer zowel een serie als een punt zijn opgemaakt?**

Expliciete datapunt‑opmaak heeft voorrang voor dat punt. Andere punten blijven de expliciete serie‑opmaak gebruiken of, wanneer de serie‑opmaak niet gedefinieerd is, de automatische grafiekstijl en het thema. Groepsinstellingen zoals overlap en gatbreedte regelen de lay‑out en vormen geen formatteeroverriding op punt‑niveau.

**Is er een limiet aan het aantal series dat een grafiek kan bevatten?**

Aspose.Slides legt geen aparte vaste limiet op voor het aantal series. In de praktijk bepalen bestandsbeperkingen, beschikbaar geheugen, render‑tijd en leesbaarheid van de grafiek een bruikbare limiet.

**Wat moet ik aanpassen wanneer kolommen te dicht bij elkaar of te ver uit elkaar staan?**

Roep [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/nl/python-java/aspose.slides/chartseriesgroup/#setGapWidth) aan op de juiste bovenliggende serie‑groep. Verhoog de waarde om de ruimte tussen clusters te vergroten, of verlaag deze om de clusters dichter bij elkaar te brengen.