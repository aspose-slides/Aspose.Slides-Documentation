---
title: Grafiektabelgegevens in presentaties aanpassen met Python
linktitle: Gegevenstabel
type: docs
url: /nl/python-java/chart-data-table/
keywords:
- grafiekgegevens
- gegevenstabel
- lettertype-eigenschappen
- PowerPoint
- presentatie
- Python
- Java
- Aspose.Slides
description: "Pas de lettertype-instellingen, randen en legendasleutels van grafiektabellen aan in PowerPoint-presentaties met Aspose.Slides voor Python via Java."
---
## **Overzicht**

Aspose.Slides for Python via Java stelt u in staat om de gegevenstabel van een diagram weer te geven en de tekstopmaak, randen en legendasleutels aan te passen. Dit artikel legt uit hoe u de tabel inschakelt, de tekst opmaakt, elk type rand beheert en legendasleutels toont of verbergt. De voorbeelden slaan de geconfigureerde diagrammen op in PPTX‑bestanden.

## **Lettertype‑eigenschappen instellen**

Om de gegevenstabel van een diagram weer te geven, geeft u `True` door aan [setDataTable](https://reference.aspose.com/slides/nl/python-java/aspose.slides/chart/#setDataTable). Gebruik [getChartDataTable](https://reference.aspose.com/slides/nl/python-java/aspose.slides/chart/#getChartDataTable) om toegang te krijgen tot de tabel en de tekstopmaak te configureren.

1. Laad de presentatie met de klasse [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/).
1. Voeg een gegroepeerd kolomdiagram toe aan de eerste dia.
1. Schakel de gegevenstabel van het diagram in.
1. Schakel vetgedrukte tekst in met [setFontBold](https://reference.aspose.com/slides/nl/python-java/aspose.slides/baseportionformat/#setFontBold) en geef `20` door aan [setFontHeight](https://reference.aspose.com/slides/nl/python-java/aspose.slides/baseportionformat/#setFontHeight) voor tekst van 20 punten.
1. Sla de gewijzigde presentatie op.

Het onderstaande voorbeeld vereist `test.pptx` in de werkmap met ten minste één dia. Het voegt een diagram met standaardgegevens toe op positie (50, 50), met een breedte van 600 punten en een hoogte van 400 punten. Het opgeslagen `output.pptx` bevat het diagram met de ingeschakelde gegevenstabel en de opgegeven lettertype‑instellingen toegepast.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, NullableBool, Presentation, SaveFormat

presentation = Presentation("test.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)
    chart.setDataTable(True)

    portion_format = chart.getChartDataTable().getTextFormat().getPortionFormat()
    portion_format.setFontBold(NullableBool.True_)
    portion_format.setFontHeight(20)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Randen van gegevenstabel aanpassen**

Schakel de tabel in met [Chart.setDataTable](https://reference.aspose.com/slides/nl/python-java/aspose.slides/chart/#setDataTable) en benader deze via [Chart.getChartDataTable](https://reference.aspose.com/slides/nl/python-java/aspose.slides/chart/#getChartDataTable). U kunt drie soorten randen onafhankelijk beheren:

- [setBorderHorizontal](https://reference.aspose.com/slides/nl/python-java/aspose.slides/datatable/#setBorderHorizontal) regelt de horizontale celranden.
- [setBorderVertical](https://reference.aspose.com/slides/nl/python-java/aspose.slides/datatable/#setBorderVertical) regelt de verticale celranden.
- [setBorderOutline](https://reference.aspose.com/slides/nl/python-java/aspose.slides/datatable/#setBorderOutline) regelt de buitenste rand van de tabel.

Geef `True` door aan elke functie om de randen weer te geven of `False` om ze te verbergen. Het onderstaande voorbeeld maakt een gegroepeerd kolomdiagram met standaardgegevens, toont horizontale randen en de buitenrand, en verbergt verticale randen. Het vereist geen invoerbestand. De positie en afmetingen van het diagram worden opgegeven in punten.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)
    chart.setDataTable(True)

    data_table = chart.getChartDataTable()
    data_table.setBorderHorizontal(True)
    data_table.setBorderVertical(False)
    data_table.setBorderOutline(True)

    presentation.save("data-table-borders.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

De onderstaande vergelijking gebruikt dezelfde diagramgegevens en legendasleutelinstelling in alle vier de gevallen. Beginnend met alle randen ingeschakeld, schakelt elke resterende variant precies één randinstelling uit. De variant links‑onder komt overeen met de randinstellingen in het voorbeeld.

![Diagram‑gegevenstabellen met alle randen ingeschakeld, geen horizontale randen, geen verticale randen en geen buitenrand](data-table-borders.png)

## **Legendasleutels tonen of verbergen**

Legendasleutels zijn kleine gekleurde markeringen naast de serienaam in de gegevenstabel. Ze helpen lezers elke tabelrij te koppelen aan een diagramserie. Geef `True` door aan [setShowLegendKey](https://reference.aspose.com/slides/nl/python-java/aspose.slides/datatable/#setShowLegendKey) om deze markeringen weer te geven of `False` om ze te verbergen.

De afzonderlijke legenda van het diagram wordt beheerd met [Chart.setLegend](https://reference.aspose.com/slides/nl/python-java/aspose.slides/chart/#setLegend). Deze instellingen zijn onafhankelijk: het verbergen van de afzonderlijke legenda verbergt de sleutels in de gegevenstabel niet, en het verbergen van de sleutels in de tabel verbergt de afzonderlijke legenda niet.

Het onderstaande voorbeeld maakt een diagram met standaardgegevens, schakelt de gegevenstabel in en toont legendasleutels daarin terwijl de afzonderlijke legenda verborgen wordt. Alle tabelranden zijn expliciet ingeschakeld. Er is geen invoerpresentatie vereist. Om alleen de sleutels in de tabel te verbergen, geeft u `False` door aan [setShowLegendKey](https://reference.aspose.com/slides/nl/python-java/aspose.slides/datatable/#setShowLegendKey).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)
    chart.setDataTable(True)
    chart.setLegend(False)

    data_table = chart.getChartDataTable()
    data_table.setBorderHorizontal(True)
    data_table.setBorderVertical(True)
    data_table.setBorderOutline(True)
    data_table.setShowLegendKey(True)

    presentation.save("data-table-legend-keys.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

De onderstaande vergelijking toont dezelfde tabel met legendasleutels links weergegeven en rechts verborgen. Alle randen blijven ingeschakeld en de afzonderlijke diagramlegenda is in beide gevallen verborgen.

![Diagram‑gegevenstabellen met legendasleutels links weergegeven en rechts verborgen](data-table-legend-keys.png)

## **FAQ**

**Kan ik legendasleutels tonen in de gegevenstabel van een diagram?**

Ja. Geef `True` door aan [setShowLegendKey](https://reference.aspose.com/slides/nl/python-java/aspose.slides/datatable/#setShowLegendKey) om legendasleutels weer te geven of `False` om ze te verbergen.

**Wordt de gegevenstabel bewaard bij het exporteren van de presentatie naar PDF, HTML of afbeeldingen?**

Ja. Aspose.Slides rendert het diagram en de weergegeven gegevenstabel als onderdeel van de dia bij het exporteren naar [PDF](/slides/nl/python-java/convert-powerpoint-to-pdf/), [HTML](/slides/nl/python-java/convert-powerpoint-to-html/), of [images](/slides/nl/python-java/convert-powerpoint-to-png/).

**Kan ik werken met gegevenstabellen in diagrammen die uit een sjabloon zijn geladen?**

Ja. Voor een diagram dat vanuit een bestaande presentatie of sjabloon is geladen, gebruikt u [hasDataTable](https://reference.aspose.com/slides/nl/python-java/aspose.slides/chart/#hasDataTable) en [setDataTable](https://reference.aspose.com/slides/nl/python-java/aspose.slides/chart/#setDataTable) om te controleren of de gegevenstabel wordt weergegeven en deze eventueel te wijzigen.

**Hoe kan ik diagrammen vinden met een ingeschakelde gegevenstabel?**

Loop door de vormen op elke dia, identificeer de diagrammen en roep hun methode [hasDataTable](https://reference.aspose.com/slides/nl/python-java/aspose.slides/chart/#hasDataTable) aan. Een waarde van `True` geeft aan dat de gegevenstabel ingeschakeld is.