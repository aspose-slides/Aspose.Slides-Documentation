---
title: Beheer diagramreeksen in presentaties in Python
linktitle: Gegevensreeksen
type: docs
url: /nl/python-java/chart-series/
keywords:
- grafiekreeks
- reeks overlapping
- reeks kleur
- reeksnaam
- datapunt
- werkbladcel
- reeks tussenruimte
- negatieve waarde
- PowerPoint
- presentatie
- Python
- Java
- Aspose.Slides
description: "Leer hoe u diagramreeksen, datapunten, werkbladcellen, opmaak, overlapping, tussenruimte en negatieve waarden in presentaties kunt beheren met Aspose.Slides voor Python via Java."
---
## **Overzicht**

Een diagram kan zijn weergegeven waarden opslaan in werkbladcellen of rechtstreeks als numerieke literalen. Een [ChartSeries](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/) vertegenwoordigt één set gerelateerde waarden, en elke [ChartDataPoint](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/) vertegenwoordigt een punt in die serie. [ChartCategory](https://reference.aspose.com/slides/python-java/aspose.slides/chartcategory/)‑objecten leveren de labels of groepeerwaarden die door de series worden gedeeld. In diagrammen die met standaardgegevens zijn gemaakt, gebruiken seriesnamen, categorieën en puntwaarden [ChartDataCell](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/)‑objecten uit het diagram‑werkboek.

Voor een typisch categoriediagram gebruikt het standaardwerkboek rij 0 voor seriesnamen, kolom 0 voor categorienamen en de resterende cellen voor reeksenwaarden. Werkblad‑, rij‑ en kolom‑indexen die aan [ChartDataWorkbook.getCell](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/#getCell) worden doorgegeven, zijn nul‑gebaseerd. Deze indeling is handig wanneer u een diagram met standaardgegevens maakt, maar ga er niet van uit dat elk bestaand diagram dit gebruikt. Voor een geladen presentatie, inspecteer de cellen die door de series, categorieën en datapunten worden gerefereerd voordat u werkboekwaarden wijzigt.

Diagraminstellingen hebben drie verschillende reikwijdtes:

- Instellingen op serieniveau, zoals [ChartSeries.getFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getFormat), geven de standaardweergave voor alle punten in één serie.
- Instellingen per datapunt, zoals [ChartDataPoint.getFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getFormat), overschrijven de serie‑weergave voor één punt.
- Groepsinstellingen zijn van toepassing op compatibele series die tot dezelfde [ChartSeriesGroup](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/) behoren. Open de groep via [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getParentSeriesGroup) wanneer u opties zoals overlapping of tussenruimte wilt instellen.

Wanneer geen expliciete punt‑ of serievulling is ingesteld, bepalen de diagramstijl en het thema de automatische weergave. Wanneer zowel serie‑ als punt‑opmaak aanwezig zijn, heeft de punt‑opmaak voor dat punt voorrang.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Reekswaarden instellen met numerieke literalen**

Gebruik numerieke literalen wanneer reeksenwaarden afkomstig zijn van toepassingsdata of berekeningen en geen verwijzingen naar werkbladcellen nodig hebben. Roep [setDataSourceTypeForValues](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapointcollection/#setDataSourceTypeForValues) aan met [DataSourceType.DoubleLiterals](https://reference.aspose.com/slides/python-java/aspose.slides/datasourcetype/#DoubleLiterals) voordat u het resultaat van elk punt’s [getValue](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getValue) toewijst via [setAsLiteralDouble](https://reference.aspose.com/slides/python-java/aspose.slides/doublechartvalue/#setAsLiteralDouble).

De collectie‑instelling bepaalt het brontype van alle puntwaarden in die reeks. De [getDataSourceType](https://reference.aspose.com/slides/python-java/aspose.slides/basechartvalue/#getDataSourceType)‑methode van elke puntwaarde rapporteert het geselecteerde type; wijzig het via de collectie‑instelling. Met `Worksheet` gebruikt u [getAsCell](https://reference.aspose.com/slides/python-java/aspose.slides/doublechartvalue/#getAsCell) om de gerefereerde cel te benaderen. Met `DoubleLiterals` gebruikt u [getAsLiteralDouble](https://reference.aspose.com/slides/python-java/aspose.slides/doublechartvalue/#getAsLiteralDouble) of `setAsLiteralDouble` om het getal rechtstreeks te lezen of te schrijven.

Het volgende voorbeeld maakt een kolomdiagram met standaard series en categorieën, en kent vervolgens berekende waarden van 10, 20, enzovoort toe aan de bestaande punten van de eerste reeks. Het slaat de presentatie op, opent deze opnieuw en toont de opgeslagen waarden.

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

Het brontype van de puntwaarde staat los van [ChartData.getDataSourceType](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getDataSourceType), dat de interne of externe werkboekconfiguratie van het diagram identificeert. Het gebruik van numerieke literalen verwijdert niet automatisch het ingebedde werkboek. In dit voorbeeld blijft het werkboek beschikbaar voor categorielabels, seriesnamen en de andere series. Zie [Diagramwerkboek](/slides/nl/python-java/chart-workbook/) voor werkboekbeheer.

Voor spreidings‑ en belchtdiagrammen gebruikt u [setDataSourceTypeForXValues](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapointcollection/#setDataSourceTypeForXValues) en [setDataSourceTypeForYValues](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapointcollection/#setDataSourceTypeForYValues) om de bronnen voor [getXValue](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getXValue) en [getYValue](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getYValue) te kiezen. Belchtdiagrammen gebruiken ook [setDataSourceTypeForBubbleSizes](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapointcollection/#setDataSourceTypeForBubbleSizes) voor [getBubbleSize](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getBubbleSize). Stel elke toepasselijke bron in op `DoubleLiterals` voordat u nummers toewijst via de `setAsLiteralDouble`‑methode van die waarde.

## **Overlap van de diagramreeks instellen**

[ChartSeries.getOverlap](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getOverlap) rapporteert hoeveel balken of kolommen overlappen in een 2D‑diagram, van -100 tot 100 procent. Het is een alleen‑lezen projectie van de instelling op de bovenliggende seriesgroep. Gebruik [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setOverlap) om elke compatibele reeks in die groep bij te werken. Deze optie is van toepassing op diagramtypen die gegroepeerde balken of kolommen weergeven; hij beïnvloedt geen ongerelateerde seriesgroepen in een combinatiediagram.

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

    # Het nieuwe diagram bevat voorbeeldreeksen, categorieën en waarden.
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    series = chart.getChartData().getSeries().get_Item(first_series_index)
    series.getParentSeriesGroup().setOverlap(overlap_percent)

    presentation.save("series_overlap.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Het resultaat:

![The series overlap](series_overlap.png)

## **Vulkleur van de reeks wijzigen**

Gebruik [ChartSeries.getFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getFormat) om de standaardvulling voor een gehele reeks in te stellen. Als een punt al een expliciete vulling heeft, overschrijft de [ChartDataPoint.getFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getFormat)‑instelling de serievulling voor dat punt.

```python
import jpide
import asposeslides

if not jpide.isJVMStarted():
    jpide.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat

Color = jpide.JClass("java.awt.Color")

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

Een reeksnaam wordt opgeslagen in het diagram‑datwerkboek en wordt normaal weergegeven in de legenda. In het standaardwerkboek dat voor een gegroepeerd kolomdiagram wordt aangemaakt, bevindt cel B1 zich op rij 0, kolom 1 en bevat de naam van de eerste reeks. De genummerde variabelen in het volgende voorbeeld maken die structuur expliciet:

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

U kunt ook de cel bijwerken die al door [ChartSeries.getName](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getName) wordt gerefereerd. Deze aanpak vermijdt aannames over een bepaalde rij en kolom in een bestaand diagram:

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

### **Een reeks maken met een naam uit meerdere cellen**

Een samengestelde reeksnaam is handig wanneer een productnaam en een rapportageperiode in afzonderlijke werkbladcellen staan. U kunt bijvoorbeeld `Product A` in B1 en `2026` in C1 combineren tot één reeksnaam, terwijl beide delen gekoppeld blijven aan hun broncellen.

Gebruik [ChartDataWorkbook.getCellCollection](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/#getCellCollection) om het naamgebied op te halen, en geef die collectie vervolgens door aan [ChartSeriesCollection.add](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriescollection/#add). Het argument `skipHiddenCells` bepaalt of verborgen cellen worden meegenomen: `True` sluit ze uit, `False` neemt ze op. Dit voorbeeld gebruikt `False` om elke cel in het naamgebied op te nemen.

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

    # Deze twee cellen leveren de naam van de reeks.
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

De resulterende reeksnaam is `Product A 2026`, met een spatie tussen de twee celwaarden. De legenda toont dit als één item voor beide kolommen. De afbeelding hieronder illustreert het resultaat:

![Column chart with North and South values and the composite series name Product A 2026 in the legend](composite_series_name.png)

## **De automatische vulkleur van de reeks ophalen**

[ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getAutomaticSeriesColor) retourneert de kleur berekend op basis van de reeksindex en de diagramstijl. Dit is de kleur die wordt gebruikt wanneer de serievulling niet expliciet is gedefinieerd. Het aanroepen van de methode leest de berekende kleur; hij wijst geen nieuwe vulling toe.

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

## **Inverteer vulkleur voor een diagramreeks instellen**

Voor balk‑, kolom‑ en belreeks‑series kan [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#setInvertIfNegative) negatieve waarden met een andere vulling weergeven. Stel de reguliere serievulling in op vast, schakel inversie in en wijs de negatieve‑waarde‑kleur toe via [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getInvertedSolidFillColor). Negatieve getallen blijven ongewijzigd in het werkboek; alleen hun weergavekleur verandert.

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

U kunt inversie voor één punt inschakelen via [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#setInvertIfNegative). In het volgende voorbeeld is inversie uitgeschakeld voor de reeks en alleen ingeschakeld voor het geselecteerde punt. Het punt krijgt tevens een negatieve waarde zodat het effect zichtbaar is:

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

## **Waarde van een specifiek datapunt wissen**

Om één punt leeg te maken zonder de andere punten te verwijderen, stelt u de onderliggende werkboekcel in op `None`. Voor een kolomdiagram is de weergegeven waarde beschikbaar via [ChartDataPoint.getValue](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getValue). Het datapunt blijft op dezelfde categorielocatie, maar het diagram behandelt de waarde als leeg volgens de instellingen voor lege waarden van het diagram.

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

Spreidingsdiagrammen gebruiken afzonderlijke X‑ en Y‑cellen, en beldiagrammen gebruiken ook een grootte‑cel. Wis alleen de cel die de waarde vertegenwoordigt die u wilt verwijderen. Roep [ChartDataPointCollection.clear](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapointcollection/#clear) niet aan wanneer u de andere punten wilt behouden, want die methode verwijdert alle datapunten uit de collectie.

## **Weergave van lege cellen regelen**

Verborgen cellen die waarden bevatten vormen een apart geval ten opzichte van lege cellen. Zie [Gegevens uit verborgen rijen en kolommen opnemen](/slides/nl/python-java/chart-workbook/#include-data-from-hidden-rows-and-columns) voor hoe u data uit verborgen rijen en kolommen kunt opnemen of uitsluiten.

Een lege werkboekcel vertegenwoordigt missende data; een cel met `0` vertegenwoordigt een bekende numerieke waarde. Roep [ChartDataCell.setValue](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/#setValue) aan met `None` om een cel leeg te maken. Een numerieke nul blijft een nul, ongeacht de instelling voor lege cellen.

Gebruik [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setDisplayBlanksAs) om te kiezen hoe het diagram lege cellen weergeeft. Deze instelling geldt voor het hele diagram. Hij verandert hoe lege waarden worden geplot, zonder de lege werkboekcel te vullen met nul of een geïnterpoleerde waarde.

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

    # Laat Dag 3 echt leeg, maar behoud de categorie en het datapunt.
    workbook.getCell(0, 3, 1).setValue(None)

    modes = [DisplayBlanksAsType.Gap, DisplayBlanksAsType.Zero, DisplayBlanksAsType.Span]
    mode_names = ["Gap", "Zero", "Span"]
    for mode, mode_name in zip(modes, mode_names):
        chart.setDisplayBlanksAs(mode)
        presentation.save(f"empty_cells_{mode_name}.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Het voorbeeld maakt een lijndiagram met één reeks, wist de waarde voor Dag 3, en slaat hetzelfde diagram op met elk van de modi. Er is geen invoerbestand nodig. De [ChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/) gebruikt werkblad 0, kolom 0 voor categorielabels en kolom 1 voor waarden; rij 0 bevat de reeksnaam. De uiteindelijke data zijn `10, 20, leeg, 30, 40`.

Elke uitvoerbestand slaat de vóór het opslaan toegewezen modus op: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` en `empty_cells_Span.pptx`. Om slechts één versie op te slaan, stelt u de gewenste modus in en slaat u de presentatie één keer op in plaats van te itereren over de modi.

De vergelijking hieronder toont dezelfde data in alle drie de bestanden. Dag 3 is in elk geval leeg in het werkboek:

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

Het zichtbare effect hangt af van het diagramtype. Een lijndiagram maakt alle drie de modi eenvoudig te vergelijken. Balk‑ en kolomdiagrammen hebben geen lijn om over een ontbrekende categorie te verbinden, dus `Span` kan het verbindingssegment niet produceren; een ontbrekende kolom en een nul‑hoogte kolom kunnen er ook gelijk uitzien. Evenzo heeft een spreidingsdiagram met alleen markers geen verbindingslijn. Verwacht geen drie afzonderlijke resultaten voor elk diagramtype; controleer de output voor het type dat u gebruikt.

## **Tussenruimte van de reeks instellen**

Tussenruimte is de ruimte tussen aangrenzende balk‑ of kolomclusters, uitgedrukt als een percentage van de balk‑ of kolombreedte. Net als overlap behoort het tot de bovenliggende seriesgroep en niet tot één serie. Roep [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapWidth) één keer voor de groep aan. Een hogere waarde creëert meer ruimte tussen clusters; een lagere waarde maakt ze dichter.

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

**Welke diagramtypen ondersteunen dataseries?**

Alle diagramtypen die door de [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/)‑enumeratie worden weergegeven, gebruiken diagramdata, maar hun series hebben niet allemaal dezelfde waardestructuur of instellingen. Bijvoorbeeld, categoriediagrammen gebruiken categorieën en waarden, spreidingsdiagrammen gebruiken X‑ en Y‑waarden, en beldiagrammen voegen belgroottes toe. Gebruik de methode voor het maken van datapunten die bij het serietype past. Opties zoals overlapping en tussenruimte zijn alleen van toepassing op compatibele balk‑ of kolomgroepen.

**Wat is een diagramreeks‑groep?**

Een [ChartSeriesGroup](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/) bevat compatibele series die groeps‑niveau plotinstellingen delen. Een combinatiediagram kan meer dan één groep bevatten, dus het wijzigen van de groep die via één serie wordt bereikt, verandert niet noodzakelijk elke serie in het diagram.

**Bevat een nieuw aangemaakt diagram standaardgegevens?**

Ja. Standaard maakt [ShapeCollection.addChart](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addChart) voorbeeldseries, -categorieën en -waarden aan. U kunt die cellen bewerken of zowel de series‑ als de categorieverzamelingen wissen voordat u een volledig aangepaste dataset toevoegt. Een overload kan ook een diagram zonder standaardgegevens creëren.

**Hoe zijn diagramobjecten gekoppeld aan werkbladcellen?**

Seriesnamen, categorielabels en datapunten‑waarden refereren naar cellen in een [ChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/). Het wijzigen van een gerefereerde cel werkt het corresponderende diagramonderdeel bij. Wanneer u aangepaste data opbouwt, houd de rijen met categorieën en de rijen met reeks‑waarden op elkaar afgestemd zodat elk punt onder de beoogde categorie wordt geplot.

**Hoe wis ik één punt in plaats van de hele reeks?**

Stel de relevante waardecel in op `None` om de positie van het punt in de categorie te behouden als een leeg punt. Gebruik [ChartDataPointCollection.clear](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapointcollection/#clear) alleen wanneer u alle punten uit die reeks wilt verwijderen. Als u ook categorieën verwijdert, werk dan elke serie bij zodat hun waarden uitgelijnd blijven met de categorieverzameling.

**Hoe worden lege punten weergegeven?**

Het resultaat hangt af van het diagramtype en de via [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setDisplayBlanksAs) geconfigureerde waarde. Ondersteunde diagrammen kunnen leegtes weergeven als gaten, als nul‑waarden of door aangrenzende punten te verbinden. Kies de instelling die overeenkomt met de betekenis van missende data in uw presentatie. Zie [Weergave van lege cellen regelen](#control-the-display-of-empty-cells) voor een volledig voorbeeld en visuele vergelijking.

**Hoe worden negatieve waarden opgemaakt?**

Voor ondersteunde balk‑, kolom‑ en belreeks‑series roept u [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#setInvertIfNegative) aan en stelt u de kleur in die wordt geretourneerd door [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getInvertedSolidFillColor). U kunt het gedrag voor een individueel punt overschrijven met [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#setInvertIfNegative). Deze methoden beïnvloeden de opmaak, niet de opgeslagen numerieke waarden.

**Welke opmaak heeft voorrang wanneer zowel een serie als een punt zijn opgemaakt?**

Expliciete datapunt‑opmaak heeft voorrang voor dat punt. Andere punten blijven de expliciete serie‑opmaak gebruiken of, wanneer de serie‑opmaak niet is gedefinieerd, de automatische diagramstijl en het thema. Groepsinstellingen zoals overlapping en tussenruimte regelen de lay‑out en zijn geen punt‑niveau opmaak‑overschrijvingen.

**Is er een limiet aan het aantal series dat een diagram kan bevatten?**

Aspose.Slides legt geen afzonderlijke vaste limiet op voor het aantal series. In de praktijk bepalen bestandsbeperkingen van de presentatie, beschikbaar geheugen, render‑tijd en de leesbaarheid van het diagram een bruikbare grens.

**Wat moet ik aanpassen wanneer kolommen te dicht bij elkaar of te ver uit elkaar staan?**

Roep [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapWidth) aan op de juiste bovenliggende seriesgroep. Verhoog de waarde om de ruimte tussen clusters te vergroten, of verlaag deze om de clusters dichter bij elkaar te brengen.