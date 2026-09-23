---
title: Beheer grafiekdata‑labels in presentaties met Python
linktitle: Data‑label
type: docs
url: /nl/python-java/chart-data-label/
keywords:
- grafiek
- data‑label
- dataprecisie
- percentage
- labelafstand
- labelpositie
- PowerPoint
- presentatie
- Python
- Java
- Aspose.Slides
description: "Leer hoe u grafiek‑data‑labels kunt toevoegen en opmaken in PowerPoint‑presentaties met Aspose.Slides voor Python via Java voor boeiendere dia's."
---
## **Inleiding**

Data‑labels tonen informatie over de grafiekseries en individuele datapunten, waardoor lezers waarden kunnen identificeren en de grafiek kunnen begrijpen. Dit artikel legt uit hoe u waarden opmaakt, percentages weergeeft, labeltekst leest, de afstand tussen categorie‑as‑labels aanpast en labels op een taartdiagram positioneert.

## **Instellen van dataprecisie in grafiek‑data‑labels**

Gebruik [setNumberFormatOfValues](https://reference.aspose.com/slides/nl/python-java/aspose.slides/chartseries/#setNumberFormatOfValues) om de waarden van de series op te maken. Dit voorbeeld maakt een lijndiagram met standaardgegevens, toont de datatabel en schakelt waardelabels in voor de eerste serie. Het opmaakpatroon `#,##0.00` geeft een duizendtalseparator en twee decimalen weer zonder de onderliggende waarden te wijzigen.

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

Voor een gestapeld kolomdiagram berekent u elke waarde als een percentage van het totale van die categorie en kent u de tekst toe aan het tekstkader dat wordt geretourneerd door [getTextFrameForOverriding](https://reference.aspose.com/slides/nl/python-java/aspose.slides/datalabel/#getTextFrameForOverriding). Dit voorbeeld gebruikt de standaardgrafiekgegevens en toont percentages met twee decimalen in een lettertype van 8 punten. Categorieën met een totaal van nul worden overgeslagen om deling door nul te voorkomen. Herbereken de aangepaste labeltekst als de grafiekgegevens wijzigen.

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

## **Percentage‑teken instellen met grafiek‑data‑labels**

Wanneer waarden als breuken zijn opgeslagen, gebruikt u [setNumberFormat](https://reference.aspose.com/slides/nl/python-java/aspose.slides/datalabelformat/#setNumberFormat) om percentages weer te geven. Geef `False` door aan [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/nl/python-java/aspose.slides/datalabelformat/#setNumberFormatLinkedToSource) om het label‑formaat onafhankelijk van de broncellen toe te passen.

Dit voorbeeld maakt een 100 % gestapeld kolomdiagram met rode en blauwe series over vier categorieën. Elk paar waarden telt op tot 1. Het label‑formaat `0.0%` toont 0,30 als 30,0 %, terwijl de verticale as twee decimalen gebruikt. Beide series gebruiken witte labeltekst met een grootte van 10 punten.

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

## **De eigenlijke tekst van data‑labels lezen**

Gebruik [getActualLabelText](https://reference.aspose.com/slides/nl/python-java/aspose.slides/datalabel/#getActualLabelText) om de tekst op te halen die door de instellingen van een data‑label is gegenereerd. Dit is nuttig bij het extraheren van labels voor rapporten, het doorzoeken van presentatie‑inhoud, of het valideren van gegenereerde grafieken. In het onderstaande voorbeeld combineert de standaard [data label format](https://reference.aspose.com/slides/nl/python-java/aspose.slides/datalabelformat/) elke categorienaam, serienaam en waarde. Eén punt formatteert zijn waarde als percentage, en een ander gebruikt aangepaste tekst van [getTextFrameForOverriding](https://reference.aspose.com/slides/nl/python-java/aspose.slides/datalabel/#getTextFrameForOverriding).

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

Het getal dat in een datapunt is opgeslagen blijft `0.75`, zelfs wanneer het label `75%` weergeeft samen met de categorie‑ en serienamen. Aangepaste tekst vervangt de gegenereerde labeltekst. [getActualLabelText](https://reference.aspose.com/slides/nl/python-java/aspose.slides/datalabel/#getActualLabelText) retourneert de resulterende label‑string in beide gevallen. Controleer [isVisible](https://reference.aspose.com/slides/nl/python-java/aspose.slides/datalabel/#isVisible) apart, zoals hierboven getoond, wanneer u alleen zichtbare labels wilt extraheren.

## **Labelafstand ten opzichte van een as instellen**

Gebruik [setLabelOffset](https://reference.aspose.com/slides/nl/python-java/aspose.slides/axis/#setLabelOffset) om de afstand tussen categorie‑as‑labels en de as te regelen. De waarde is een percentage van de maximale lettergrootte van de as‑labels. Dit voorbeeld maakt een gegroepeerd kolomdiagram en stelt de horizontale as‑labeloffset in op 500. Deze instelling heeft invloed op categorie‑as‑labels in plaats van op labels die aan individuele datapunten zijn gekoppeld.

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

## **Labelpositie aanpassen**

Op een taartdiagram past u de posities van data‑labels aan om de afstand te verbeteren en ruimte te maken voor leiderslijnen.

Dit voorbeeld toont de waarde van het eerste datapunt, plaatst het label buiten het onderdeel, en past de horizontale en verticale offset aan met behulp van [setX](https://reference.aspose.com/slides/nl/python-java/aspose.slides/datalabel/#setX) en [setY](https://reference.aspose.com/slides/nl/python-java/aspose.slides/datalabel/#setY). Deze offsets zijn respectievelijk relatief aan de breedte en hoogte van de grafiek.

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

![Taartdiagram met een aangepaste data‑labelpositie](pie-chart-adjusted-label.png)

## **Veelgestelde vragen**

**Hoe kan ik voorkomen dat data‑labels overlappen in drukke grafieken?**

Combineer automatische labelplaatsing, leiderslijnen en een kleinere lettergrootte; indien nodig verberg enkele velden (bijvoorbeeld de categorie) of toon labels alleen voor extreme waarden of belangrijke punten.

**Hoe kan ik labels uitschakelen alleen voor nul-, negatieve of lege waarden?**

Filter datapunten voordat u labels inschakelt en schakel de weergave uit voor waarden van 0, negatieve waarden of ontbrekende waarden volgens een gedefinieerde regel.

**Hoe kan ik een consistente labelstijl waarborgen bij exporteren naar PDF/afbeeldingen?**

Stel expliciet de lettertypefamilie en -grootte in en controleer of het lettertype beschikbaar is in de renderomgeving om een fallback te voorkomen.