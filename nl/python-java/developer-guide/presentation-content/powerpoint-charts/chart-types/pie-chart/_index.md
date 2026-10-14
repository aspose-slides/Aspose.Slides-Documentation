---
title: Pas cirkeldiagrammen aan in presentaties met Python via Java
linktitle: Cirkeldiagram
type: docs
url: /nl/python-java/pie-chart/
keywords:
- cirkeldiagram
- diagram beheren
- diagram aanpassen
- diagramopties
- diagraminstellingen
- plotopties
- segmentkleur
- PowerPoint
- presentatie
- Python
- Java
- Aspose.Slides
description: "Maak en pas cirkeldiagrammen aan in Python via Java met Aspose.Slides. Configureer secundaire plots, toon gegevenslabels en pas automatische segmentkleuren toe in PowerPoint."
---
## **Overzicht**

Dit artikel legt uit hoe u met cirkeldiagrammen in Aspose.Slides kunt werken. Het laat zien hoe u secundaire plotopties voor Pie of Pie- en Bar of Pie-diagrammen kunt configureren, en hoe u automatische kleurschakering van segmenten voor een standaard cirkeldiagram kunt inschakelen.

De voorbeelden richten zich op diagramaanpassingen, zoals het toevoegen van een diagram aan een dia, het aanpassen van series- en labelinstellingen, het vervangen van standaard diagramgegevens door aangepaste categorieën en waarden, en het opslaan van de bijgewerkte presentatie.

## **Opties voor secundaire plot voor Pie of Pie en Bar of Pie diagrammen**

Aspose.Slides for Python via Java ondersteunt opties voor secundaire plot voor Pie of Pie- en Bar of Pie-diagrammen. Deze opties regelen de grootte van de secundaire plot en hoe gegevenspunten worden verdeeld over de twee plots.

Het volgende voorbeeld maakt een Pie of Pie-diagram in een nieuwe presentatie en toont de waarden van gegevenspunten als labels. De [setSecondPieSize](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setSecondPieSize) methode stelt de grootte van de secundaire plot in op 149% van de hoofdplot. [setPieSplitBy](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setPieSplitBy) selecteert procentgebaseerde splitsing, en [setPieSplitPosition](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setPieSplitPosition) stelt de drempel in op 53%.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, PieSplitType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.PieOfPie, 50, 50, 500, 400)
    series = chart.getChartData().getSeries().get_Item(0)

    # Waarde weergeven en de secundaire plot configureren.
    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)
    series_group = series.getParentSeriesGroup()
    series_group.setSecondPieSize(149)
    series_group.setPieSplitBy(PieSplitType.ByPercentage)
    series_group.setPieSplitPosition(53)

    presentation.save("pie_of_pie.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Selecteer categorieën voor de secundaire plot**

Gebruik aangepaste splitsing wanneer u specifieke categorieën in de secundaire plot wilt groeperen, ongeacht hun procentuele waarden. Bijvoorbeeld, een verkooprapport kan Online en Events samen tonen zodat lezers deze twee kanalen kunnen vergelijken, zelfs al vormen ze respectievelijk 35% en 10% van de totale verkoop.

Roep [setPieSplitBy](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setPieSplitBy) aan met [PieSplitType.Custom](https://reference.aspose.com/slides/python-java/aspose.slides/piesplittype/#Custom) en selecteer de punten via [getPieSplitCustomPoints](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#getPieSplitCustomPoints). De [add](https://reference.aspose.com/slides/python-java/aspose.slides/piesplitcustompointcollection/#add) methode van de collectie accepteert een nulgebaseerde index in de serie; gebruik [addItem](https://reference.aspose.com/slides/python-java/aspose.slides/piesplitcustompointcollection/#addItem) om een gegevenspuntobject toe te voegen. In dit voorbeeld selecteert index 1 Online, en het punt op index 3 selecteert Events. Partners wordt ook tijdelijk toegevoegd, daarna uitgesloten met [removeItem](https://reference.aspose.com/slides/python-java/aspose.slides/piesplitcustompointcollection/#removeItem).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, PieSplitType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.PieOfPie, 50, 50, 600, 200)

    # Vervang de standaardgegevens door verkoop per kanaal.
    workbook = chart.getChartData().getChartDataWorkbook()
    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()
    category_names = ["Retail", "Online", "Partners", "Events"]
    values = [40, 35, 15, 10]
    series_name_cell = workbook.getCell(0, 0, 1, "Sales")
    series = chart.getChartData().getSeries().add(series_name_cell, chart.getType())

    for i in range(len(category_names)):
        category_cell = workbook.getCell(0, i + 1, 0, category_names[i])
        chart.getChartData().getCategories().add(category_cell)

        value_cell = workbook.getCell(0, i + 1, 1, jpype.JInt(values[i]))
        series.getDataPoints().addDataPointForPieSeries(value_cell)

    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)
    series_group = series.getParentSeriesGroup()
    series_group.setPieSplitBy(PieSplitType.Custom)
    series_group.setColorVaried(True)

    # Selecteer Online op basis van zijn nulgebaseerde index en Events via het gegevenspuntobject.
    series_group.getPieSplitCustomPoints().add(1)
    series_group.getPieSplitCustomPoints().addItem(series.getDataPoints().get_Item(3))

    # Sluit Partners uit de selectie zonder de brongegevens te verwijderen.
    series_group.getPieSplitCustomPoints().add(2)
    series_group.getPieSplitCustomPoints().removeItem(series.getDataPoints().get_Item(2))

    presentation.save("pie_of_pie_custom.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Online (35) en Events (10) verschijnen als afzonderlijke segmenten in de secundaire plot. In de primaire plot worden ze weergegeven door één gecombineerd segment met een waarde van 45, naast Retail (40) en Partners (15). Het verwijderen van Partners uit de aangepaste selectie behoudt het in de primaire plot; het verwijdert de categorie of de waarde niet uit de brongegevens van het diagram.

De onderstaande afbeelding toont de opgeslagen presentatie in PowerPoint:

![Pie of Pie-diagram met Online en Events in de secundaire plot en hun gecombineerde waarde van 45 in de primaire plot](pie_of_pie_custom.png)

## **Automatische kleuren voor cirkelsegmenten instellen**

Aspose.Slides for Python via Java kan automatisch verschillende kleuren toewijzen aan segmenten van een cirkeldiagram. Het volgende voorbeeld maakt een cirkeldiagram met een gecentreerde titel en vervangt de standaard gegevens door drie kwartaalcategoriën en hun waarden. De [setShowValue](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setShowValue) methode toont de waarden 20, 50 en 30 als labels, terwijl [setColorVaried](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setColorVaried) een aparte kleur voor elk segment mogelijk maakt.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, NullableBool, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Pie, 100, 100, 400, 400)

    # Voeg een gecentreerde diagramtitel toe.
    chart.getChartTitle().addTextFrameForOverriding("Sample Title")
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True_)
    chart.getChartTitle().setHeight(20)
    chart.setTitle(True)

    # Vervang de standaardgegevens met het eerste werkblad.
    workbook = chart.getChartData().getChartDataWorkbook()
    worksheet_index = 0
    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()
    category_names = ["First Qtr", "2nd Qtr", "3rd Qtr"]
    values = [20, 50, 30]
    series_name_cell = workbook.getCell(worksheet_index, 0, 1, "Series 1")
    series = chart.getChartData().getSeries().add(series_name_cell, chart.getType())

    for i in range(len(category_names)):
        category_cell = workbook.getCell(worksheet_index, i + 1, 0, category_names[i])
        chart.getChartData().getCategories().add(category_cell)

        value_cell = workbook.getCell(worksheet_index, i + 1, 1, jpype.JInt(values[i]))
        series.getDataPoints().addDataPointForPieSeries(value_cell)

    # Toon waarden en wijs verschillende kleuren toe aan de segmenten.
    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)
    series.getParentSeriesGroup().setColorVaried(True)

    presentation.save("pie.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Veelgestelde vragen**

**Worden de Pie of Pie- en Bar of Pie-varianten ondersteund?**

Ja, de bibliotheek [ondersteunt](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) een secundaire plot voor cirkeldiagrammen, inclusief de Pie of Pie- en Bar of Pie-typen.

**Kan ik alleen het diagram exporteren als afbeelding (bijvoorbeeld PNG)?**

Ja, u kunt [het diagram zelf als afbeelding exporteren](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getImage) (bijvoorbeeld PNG) zonder de volledige presentatie te exporteren.