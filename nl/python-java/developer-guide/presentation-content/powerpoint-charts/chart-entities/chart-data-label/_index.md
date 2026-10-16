---
title: Beheer grafiekgegevenslabels in presentaties met Python
linktitle: Gegevenslabel
type: docs
url: /nl/python-java/chart-data-label/
keywords:
- grafiek
- gegevenslabel
- gegevensprecisie
- percentage
- labelafstand
- labellocatie
- PowerPoint
- presentatie
- Python
- Java
- Aspose.Slides
description: "Leer hoe u grafiekgegevenslabels kunt toevoegen en opmaken in PowerPoint-presentaties met Aspose.Slides voor Python via Java voor boeiendere dia's."
---
## **Inleiding**

Gegevenslabels tonen informatie over grafiekreeksen en individuele gegevenspunten, waardoor lezers waarden kunnen identificeren en de grafiek beter begrijpen. Dit artikel legt uit hoe u waarden opmaakt, percentages weergeeft, labeltekst leest, labels buiten het asmaximum controleert, de tussenruimte van categorie‑as‑labels aanpast en taart‑grafieklabels positioneert.

## **Nauwkeurigheid van gegevens instellen in grafiek‑gegevenslabels**

Gebruik [setNumberFormatOfValues](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#setNumberFormatOfValues) om reeksenwaarden op te maken. Dit voorbeeld maakt een lijngrafiek met standaardgegevens, toont de gegevenstabel en schakelt waardenlabels in voor de eerste reeks. Het formaat `#,##0.00` toont een duizendtallen‑scheidingsteken en twee decimalen zonder de onderliggende waarden te wijzigen.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Line, 50, 50, 450, 300)
    chart.setDataTable(True)

    series = chart.getChartData().getSeries().get_Item(0)
    series.setNumberFormatOfValues("#,##0.00")
    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)

    presentation.save("PrecisionOfDatalabels_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Percentage weergeven als labels**

Voor een gestapelde kolomgrafiek berekent u elke waarde als een percentage van het totaalaantal van die categorie en wijst u de tekst toe aan het tekstvak dat wordt geretourneerd door [getTextFrameForOverriding](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#getTextFrameForOverriding). Dit voorbeeld gebruikt de standaardgrafiekgegevens en toont percentages met twee decimalen in een lettertype van 8 punten. Categorieën met een totaal van nul worden overgeslagen om deling door nul te voorkomen. Herbereken de aangepaste labeltekst als de grafiekgegevens wijzigen.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Portion, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.StackedColumn, 20, 20, 400, 400)

    chart_series = chart.getChartData().getSeries()
    category_totals = [0.0] * chart.getChartData().getCategories().size()
    for category_index in range(len(category_totals)):
        for series_index in range(chart_series.size()):
            data_point = chart_series.get_Item(series_index).getDataPoints().get_Item(category_index)
            category_totals[category_index] += float(data_point.getValue().getData())

    for series_index in range(chart_series.size()):
        series = chart_series.get_Item(series_index)
        series.getLabels().getDefaultDataLabelFormat().setShowLegendKey(False)

        for point_index in range(series.getDataPoints().size()):
            data_point = series.getDataPoints().get_Item(point_index)
            label = data_point.getLabel()
            if category_totals[point_index] == 0:
                print(f"Cannot calculate a percentage for category {point_index}: the total is zero.")
                continue
            point_percentage = float(data_point.getValue().getData()) / category_totals[point_index] * 100

            portion = Portion()
            portion.setText(f"{point_percentage:.2f} %")
            portion.getPortionFormat().setFontHeight(8)
            label.getTextFrameForOverriding().setText("")
            paragraph = label.getTextFrameForOverriding().getParagraphs().get_Item(0)
            paragraph.getPortions().add(portion)

            label_format = label.getDataLabelFormat()
            label_format.setShowValue(True)
            label_format.setShowSeriesName(False)
            label_format.setShowPercentage(False)
            label_format.setShowLegendKey(False)
            label_format.setShowCategoryName(False)
            label_format.setShowBubbleSize(False)

    presentation.save("DisplayPercentageAsLabels_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Procentteken instellen met grafiek‑gegevenslabels**

Wanneer waarden als breuken zijn opgeslagen, gebruikt u [setNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setNumberFormat) om percentages weer te geven. Geef `False` door aan [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setNumberFormatLinkedToSource) om het labelformaat onafhankelijk van de broncellen toe te passen.

Dit voorbeeld maakt een 100 % gestapelde kolomgrafiek met rode en blauwe reeksen over vier categorieën. Elk paar waarden tel tot 1. Het labelformaat `0.0%` toont 0.30 als 30.0 %, terwijl de verticale as twee decimalen gebruikt. Beide reeksen gebruiken witte labeltekst van 10 punten.

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

    chart = slide.getShapes().addChart(ChartType.PercentsStackedColumn, 20, 20, 500, 400)

    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(False)
    chart.getAxes().getVerticalAxis().setNumberFormat("0.00%")

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    worksheet_index = 0
    for i in range(4):
        category_cell = workbook.getCell(worksheet_index, i + 1, 0, f"Category {i + 1}")
        chart.getChartData().getCategories().add(category_cell)

    series_names = ["Reds", "Blues"]
    series_colors = [Color.RED, Color.BLUE]
    values = [[0.30, 0.50, 0.80, 0.65], [0.70, 0.50, 0.20, 0.35]]

    for i, series_name in enumerate(series_names):
        series_cell = workbook.getCell(worksheet_index, 0, i + 1, series_name)
        series = chart.getChartData().getSeries().add(series_cell, chart.getType())
        for j, value in enumerate(values[i]):
            value_cell = workbook.getCell(worksheet_index, j + 1, i + 1, jpype.JDouble(value))
            series.getDataPoints().addDataPointForBarSeries(value_cell)

        series.getFormat().getFill().setFillType(FillType.Solid)
        series.getFormat().getFill().getSolidFillColor().setColor(series_colors[i])

        label_format = series.getLabels().getDefaultDataLabelFormat()
        label_format.setShowValue(True)
        label_format.setNumberFormatLinkedToSource(False)
        label_format.setNumberFormat("0.0%")
        portion_format = label_format.getTextFormat().getPortionFormat()
        portion_format.setFontHeight(10)
        portion_format.getFillFormat().setFillType(FillType.Solid)
        portion_format.getFillFormat().getSolidFillColor().setColor(Color.WHITE)

    presentation.save("SetDataLabelsPercentageSign_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **De daadwerkelijke tekst van gegevenslabels lezen**

Gebruik [getActualLabelText](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#getActualLabelText) om de tekst op te halen die door de instellingen van een gegevenslabel wordt gegenereerd. Dit is nuttig bij het extraheren van labels voor rapporten, het doorzoeken van presentatie‑inhoud of het valideren van gegenereerde grafieken. In het voorbeeld hieronder combineert de standaard [gegevenslabelindeling](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/) elke categorienaam, reeksennaam en waarde. Eén punt formatteert zijn waarde als percentage, een ander gebruikt aangepaste tekst van [getTextFrameForOverriding](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#getTextFrameForOverriding).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 300)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    first_category_cell = workbook.getCell(0, 1, 0, "Q1")
    chart.getChartData().getCategories().add(first_category_cell)
    second_category_cell = workbook.getCell(0, 2, 0, "Q2")
    chart.getChartData().getCategories().add(second_category_cell)

    north_series_cell = workbook.getCell(0, 0, 1, "North")
    north = chart.getChartData().getSeries().add(north_series_cell, chart.getType())
    north_first_value_cell = workbook.getCell(0, 1, 1, jpype.JDouble(0.25))
    north.getDataPoints().addDataPointForBarSeries(north_first_value_cell)
    north_second_value_cell = workbook.getCell(0, 2, 1, jpype.JDouble(0.75))
    north.getDataPoints().addDataPointForBarSeries(north_second_value_cell)

    south_series_cell = workbook.getCell(0, 0, 2, "South")
    south = chart.getChartData().getSeries().add(south_series_cell, chart.getType())
    south_first_value_cell = workbook.getCell(0, 1, 2, jpype.JDouble(0.40))
    south.getDataPoints().addDataPointForBarSeries(south_first_value_cell)
    south_second_value_cell = workbook.getCell(0, 2, 2, jpype.JDouble(0.60))
    south.getDataPoints().addDataPointForBarSeries(south_second_value_cell)

    for series in chart.getChartData().getSeries():
        label_format = series.getLabels().getDefaultDataLabelFormat()
        label_format.setShowCategoryName(True)
        label_format.setShowSeriesName(True)
        label_format.setShowValue(True)

    north.getLabels().get_Item(1).getDataLabelFormat().setNumberFormatLinkedToSource(False)
    north.getLabels().get_Item(1).getDataLabelFormat().setNumberFormat("0%")
    south.getLabels().get_Item(0).getTextFrameForOverriding().setText("Reviewed")

    for series in chart.getChartData().getSeries():
        for point in series.getDataPoints():
            label = point.getLabel()
            if not label.isVisible():
                continue

            print(f"Value: {point.getValue().getData()}; label: {label.getActualLabelText()}")
finally:
    presentation.dispose()
```

Het getal dat in een gegevenspunt is opgeslagen blijft `0.75`, zelfs wanneer het label `75 %` toont samen met de categorie‑ en reeksenamen. Aangepaste tekst vervangt de gegenereerde labeltekst. [getActualLabelText](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#getActualLabelText) retourneert in beide gevallen de uiteindelijke label‑string. Controleer [isVisible](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#isVisible) afzonderlijk, zoals hierboven weergegeven, wanneer u alleen zichtbare labels wilt extraheren.

## **Gegevenslabels buiten het as‑maximum regelen**

Wanneer u een asbereik handmatig beperkt, kunnen sommige gegevenspunten boven het maximum uitkomen. Gebruik [setShowDataLabelsOverMaximum](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setShowDataLabelsOverMaximum) om te bepalen of hun gegevenslabels worden getoond. Deze instelling verandert de zichtbaarheid van labels; ze wijzigt niet het asbereik of de onderliggende gegevenswaarden.

Het voorbeeld hieronder maakt een 2D gegroepeerde kolomgrafiek met waarden van 60 en 120. Het geeft `False` door aan [setAutomaticMaxValue](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAutomaticMaxValue) en stelt het maximum in op 100 met [setMaxValue](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMaxValue) op de verticale as. De eerste dia staat labels toe boven het maximum; een kopie van die dia schakelt ze uit. Beide dia’s worden opgeslagen in `DataLabelsOverMaximum.pptx`.

Schakel waardenlabels in met [setShowValue](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setShowValue). De instelling op grafiekniveau activeert niet automatisch de weergave van waarden en overschrijft niet een individueel label dat waardenweergave heeft uitgeschakeld. Dit voorbeeld activeert waarden voor de volledige reeks en gebruikt [setPosition](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setPosition) om labels aan het buitenste einde van elke kolom te plaatsen.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, LegendDataLabelPosition, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)
    chart.setLegend(False)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()

    first_category = workbook.getCell(0, 1, 0, "Within range")
    second_category = workbook.getCell(0, 2, 0, "Above maximum")

    chart.getChartData().getCategories().add(first_category)
    chart.getChartData().getCategories().add(second_category)

    series_name = workbook.getCell(0, 0, 1, "Values")
    series = chart.getChartData().getSeries().add(series_name, chart.getType())

    first_value = workbook.getCell(0, 1, 1, jpype.JDouble(60))
    second_value = workbook.getCell(0, 2, 1, jpype.JDouble(120))

    series.getDataPoints().addDataPointForBarSeries(first_value)
    series.getDataPoints().addDataPointForBarSeries(second_value)

    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)
    series.getLabels().getDefaultDataLabelFormat().setPosition(LegendDataLabelPosition.OutsideEnd)

    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(False)
    chart.getAxes().getVerticalAxis().setMaxValue(100)
    chart.setShowDataLabelsOverMaximum(True)

    second_slide = presentation.getSlides().addClone(slide)
    second_chart = second_slide.getShapes().get_Item(0)
    second_chart.setShowDataLabelsOverMaximum(False)

    presentation.save("DataLabelsOverMaximum.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

De volgende afbeeldingen tonen de opgeslagen dia’s zoals gerenderd door Microsoft PowerPoint. Met `True` is het label **120** zichtbaar bij de bovenste grens; met `False` is het verborgen. Het label **60** blijft zichtbaar, het as‑maximum blijft **100**, en het tweede gegevenspunt blijft **120** in beide gevallen.

| setShowDataLabelsOverMaximum(True) | setShowDataLabelsOverMaximum(False) |
| --- | --- |
| ![PowerPoint‑grafiek die het waarde‑label 120 toont met een as‑maximum van 100](data-labels-over-maximum-true.png) | ![PowerPoint‑grafiek die het waarde‑label 120 verbergt met een as‑maximum van 100](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Chart Type" %}}
Dit voorbeeld gebruikt een 2D kolomgrafiek met een waardenas. Grafieken zonder waardenas, zoals taart‑ en donutgrafieken, hebben geen as‑maximum dat op deze manier beperkt kan worden.
{{% /alert %}}

## **Labelafstand tot een as instellen**

Gebruik [setLabelOffset](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setLabelOffset) om de afstand tussen categorie‑as‑labels en de as te regelen. De waarde is een percentage van de maximale lettergrootte van de as‑labels. Dit voorbeeld maakt een gegroepeerde kolomgrafiek en stelt de horizontale as‑label‑offset in op 500. Deze instelling heeft invloed op categorie‑as‑labels in plaats van op labels die aan individuele gegevenspunten zijn gekoppeld.

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
    chart.getAxes().getHorizontalAxis().setLabelOffset(500)

    presentation.save("SetCategoryAxisLabelDistance_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Labellocatie aanpassen**

Op een taartgrafiek past u de positie van gegevenslabels aan om de tussenruimte te verbeteren en ruimte te maken voor leidende lijnen.

Dit voorbeeld toont de waarde van het eerste gegevenspunt, plaatst het label buiten de sector en past de horizontale en verticale verschuivingen aan met behulp van [setX](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#setX) en [setY](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#setY). Deze verschuivingen zijn respectievelijk relatief ten opzichte van de breedte en hoogte van de grafiek.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, LegendDataLabelPosition, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 200, 200)
    series = chart.getChartData().getSeries()
    
    label = series.get_Item(0).getLabels().get_Item(0)
    label.getDataLabelFormat().setShowValue(True)
    label.getDataLabelFormat().setPosition(LegendDataLabelPosition.OutsideEnd)
    label.setX(0.71)
    label.setY(0.04)

    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Taartgrafiek met een aangepaste labelpositie](pie-chart-adjusted-label.png)

## **Leidende lijnen opmaken**

Wanneer taart‑grafieklabels buiten hun sectoren staan, helpen leidende lijnen lezers de juiste waarde aan de juiste sector te koppelen. Een contrasterende kleur en een iets dikkere lijn maken deze verbindingen makkelijker te volgen, terwijl transparantie en een gestreepte stijl de lijnen visueel onopvallend houden.

Gebruik [getLeaderLinesFormat](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelcollection/#getLeaderLinesFormat) om leidende lijnen op te maken op het niveau van de gegevenslabel‑collectie van de reeks. De instellingen in `series.getLabels().getLeaderLinesFormat().getLine()` worden toegepast op de collectie, niet op een individueel label.

Dit voorbeeld maakt een taartgrafiek met standaardgegevens, toont waarden buiten de sectoren en schakelt [setShowLeaderLines](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setShowLeaderLines) in. Het verplaatst twee labels verder van hun sectoren met behulp van [setX](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#setX) en [setY](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#setY) verschuivingen, uitgedrukt als breuken van de grafiekbreedte en -hoogte. Er is geen invoer‑presentatie vereist.

De [getFillFormat](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#getFillFormat) van de lijn stelt een effen blauwe kleur in met een alfa‑waarde van 191 van de 255, wat ongeveer 25 % transparantie oplevert. [setWidth](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setWidth) stelt de dikte in op 2 punten, en [setDashStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setDashStyle) maakt de lijn gestreept.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, LegendDataLabelPosition, LineDashStyle, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Pie, 80, 50, 560, 400)
    chart.setLegend(False)

    series = chart.getChartData().getSeries().get_Item(0)

    label_format = series.getLabels().getDefaultDataLabelFormat()
    label_format.setShowValue(True)
    label_format.setPosition(LegendDataLabelPosition.OutsideEnd)
    label_format.setShowLeaderLines(True)

    # Verplaats twee labels verder van hun partjes.
    series.getLabels().get_Item(0).setX(0.10)
    series.getLabels().get_Item(0).setY(-0.05)
    series.getLabels().get_Item(1).setX(-0.10)
    series.getLabels().get_Item(1).setY(0.05)

    line = series.getLabels().getLeaderLinesFormat().getLine()
    line.getFillFormat().setFillType(FillType.Solid)
    color = Color(30, 90, 160, 191)
    line.getFillFormat().getSolidFillColor().setColor(color)
    line.setWidth(2)
    line.setDashStyle(LineDashStyle.Dash)

    presentation.save("FormattedLeaderLines.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Het inschakelen van leidende lijnen garandeert niet dat er voor elk label een lijn verschijnt. De zichtbaarheid hangt af van de labelplaatsing en het lay‑outgedrag van de grafiek. In dit voorbeeld hebben de twee verschoven labels zichtbare leidende lijnen; de labels die dicht bij hun sectoren blijven, hebben ze niet nodig.

De volgende afbeelding toont de opgeslagen `FormattedLeaderLines.pptx` zoals gerenderd met Aspose.Slides:

![Taartgrafiek met blauwe, halftransparante, gestreepte leidende lijnen die twee buitenste labels met hun sectoren verbinden](formatted-leader-lines.png)

## **Meerdere rijen gegevenslabels boven een kolomgrafiek toevoegen**

Dit voorbeeld maakt een kolomgrafiek met twee rijen gegevenslabels boven het plotgebied. Reeks A toont de zichtbare kolommen, terwijl Reeks B en Reeks C de extra labels leveren. Hun kolommen worden verborgen door de vulling en de contour te verwijderen. De methode [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setOverlap) stemt alle drie de reeksen af op dezelfde categorieben centre.

De instellingen van [ChartPlotArea](https://reference.aspose.com/slides/python-java/aspose.slides/chartplotarea/) reserveren ruimte voor de labelrijen. Nadat [Chart.validateChartLayout](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#validateChartLayout) de standaardposities heeft berekend, behouden [DataLabel.setX](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#setX) en [DataLabel.setY](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#setY) de horizontale uitlijning en passen ze verticale verschuivingen toe om de labels in twee rijen te rangschikken. De nummers blijven gegevenslabels gekoppeld aan de reeksenwaarden; alleen de rij‑koppen zijn afzonderlijke tekstvormen.

```python
import jpage
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, LayoutTargetType, LegendDataLabelPosition, Presentation, SaveFormat, ShapeType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 40, 40, 640, 200)
    chart.setTitle(False)
    chart.setLegend(False)
    chart.getTextFormat().getPortionFormat().setFontHeight(12)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    categories = ["North", "South", "East", "West"]
    series_names = ["Series A", "Series B", "Series C"]
    series_values = [[35, 42, 28, 47], [22, 31, 19, 26], [12, 16, 14, 18]]

    for category_index, category in enumerate(categories):
        category_cell = workbook.getCell(0, category_index + 1, 0, category)
        chart.getChartData().getCategories().add(category_cell)

    for series_index, series_name in enumerate(series_names):
        series_cell = workbook.getCell(0, 0, series_index + 1, series_name)
        series = chart.getChartData().getSeries().add(series_cell, ChartType.ClusteredColumn)

        for category_index, value in enumerate(series_values[series_index]):
            value_cell = workbook.getCell(0, category_index + 1, series_index + 1, jpype.JDouble(value))
            series.getDataPoints().addDataPointForBarSeries(value_cell)

        if series_index > 0:
            # Verberg de kolommen van B en C, maar behoud hun gegevenslabels.
            series.getFormat().getFill().setFillType(FillType.NoFill)
            series.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill)
            label_format = series.getLabels().getDefaultDataLabelFormat()
            label_format.setShowValue(True)
            label_format.getTextFormat().getPortionFormat().setFontHeight(12)
            label_fill = label_format.getTextFormat().getPortionFormat().getFillFormat()
            label_fill.setFillType(FillType.Solid)
            label_fill.getSolidFillColor().setColor(Color.BLACK)
            label_format.setPosition(LegendDataLabelPosition.InsideBase)

    # Lijn alle drie reeksen uit met dezelfde categoriecentra.
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setOverlap(jpype.JByte(100))

    # Gebruik minder rasterlijnen voor dit compacte voorbeeld.
    chart.getAxes().getVerticalAxis().setAutomaticMajorUnit(False)
    chart.getAxes().getVerticalAxis().setMajorUnit(10)

    # Reserveer ruimte boven het plot voor twee rijen gegevenslabels.
    chart.getPlotArea().setLayoutTargetType(LayoutTargetType.Inner)
    chart.getPlotArea().setX(0.15)
    chart.getPlotArea().setY(0.32)
    chart.getPlotArea().setWidth(0.80)
    chart.getPlotArea().setHeight(0.48)
    chart.validateChartLayout()

    for series_index in range(1, len(series_names)):
        series = chart.getChartData().getSeries().get_Item(series_index)
        row_top = 0.15 if series_index == 1 else 0.03

        for category_index in range(len(categories)):
            data_label = series.getDataPoints().get_Item(category_index).getLabel()
            # Houd de standaard horizontale positie. Y is een offset ten opzichte van
            # de standaard labelpositie, uitgedrukt als een fractie van de grafiekhoogte.
            data_label.setX(0)
            data_label.setY(row_top - data_label.getActualY() / chart.getHeight())

        # Alleen de rij‑kop is een aparte tekstvorm.
        heading_y = chart.getY() + row_top * chart.getHeight()
        row_heading = slide.getShapes().addAutoShape(ShapeType.Rectangle, chart.getX(), heading_y, 85, 18)
        row_heading.getFillFormat().setFillType(FillType.NoFill)
        row_heading.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
        row_heading.addTextFrame(series_names[series_index])
        row_heading.getTextFrame().getTextFrameFormat().setMarginTop(0)
        row_heading.getTextFrame().getTextFrameFormat().setMarginBottom(0)
        heading_format = row_heading.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat()
        heading_format.setFontHeight(12)
        heading_format.getFillFormat().setFillType(FillType.Solid)
        heading_format.getFillFormat().getSolidFillColor().setColor(Color.BLACK)

    presentation.save("multiple-rows-of-labels.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Kolomgrafiek met twee rijen gegevenslabels boven het plotgebied](multiple-rows-of-labels.png)

## **FAQ**

**Hoe kan ik voorkomen dat gegevenslabels overlappen op dichte grafieken?**

Combineer automatische labelplaatsing, leidende lijnen en een kleinere lettergrootte; verberg indien nodig enkele velden (bijvoorbeeld de categorie) of toon labels alleen voor extreme waarden of belangrijke punten.

**Hoe kan ik labels uitschakelen alleen voor nul‑, negatieve of lege waarden?**

Filter gegevenspunten voordat u labels inschakelt en schakel weergave uit voor waarden van 0, negatieve waarden of ontbrekende waarden volgens een gedefinieerde regel.

**Hoe zorg ik voor een consistente labelstijl bij export naar PDF/afbeeldingen?**

Stel expliciet het lettertype en de grootte in en controleer dat het lettertype beschikbaar is in de rendering‑omgeving om fallback te vermijden.