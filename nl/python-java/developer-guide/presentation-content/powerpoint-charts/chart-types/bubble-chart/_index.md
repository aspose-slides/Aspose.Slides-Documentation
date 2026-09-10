---
title: Aanpassen van bubbelgrafieken in presentaties met Python
linktitle: Bubbelgrafiek
type: docs
url: /nl/python-java/bubble-chart/
keywords:
- bubbelgrafiek
- bubbelformaat
- schaalvergroting
- representatie van grootte
- PowerPoint
- presentatie
- Python
- Java
- Aspose.Slides
description: "Maak en pas krachtige bubbelgrafieken in PowerPoint aan met Aspose.Slides voor Python via Java om uw datavisualisatie eenvoudig te verbeteren."
---
## **Overzicht**

Dit artikel toont hoe u met bubbelgrafieken werkt in Aspose.Slides. Het behandelt twee specifieke aanpassingsopties: het schalen van de bubbelgroottes via de [setBubbleSizeScale](https://reference.aspose.com/slides/nl/python-java/aspose.slides/chartseriesgroup/#setBubbleSizeScale)‑methode en het bepalen hoe bubbelformaatwaarden worden weergegeven via de [setBubbleSizeRepresentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/chartseriesgroup/#setBubbleSizeRepresentation)‑methode.

De voorbeelden demonstreren hoe u een bubbelgrafiek maakt, de schaal van de groottes aanpast en de weergave van de bubbelgrootte verandert naar breedte. Het artikel bevat ook een korte FAQ‑sectie die duidelijk maakt dat het “Bubble with 3-D” grafiektype wordt ondersteund, opmerkt dat praktische grafieklimieten afhankelijk zijn van prestaties en de doel‑PowerPoint‑versie, en uitlegt dat export het uiterlijk van de grafiek behoudt via de renderengine van Aspose.Slides.

## **Schaal van bubbelgrafiekgroottes**
Aspose.Slides for Python via Java ondersteunt het schalen van bubbelgrafiekgroottes via de [ChartSeries.getBubbleSizeScale](https://reference.aspose.com/slides/nl/python-java/aspose.slides/chartseries/#getBubbleSizeScale), [ChartSeriesGroup.getBubbleSizeScale](https://reference.aspose.com/slides/nl/python-java/aspose.slides/chartseriesgroup/#getBubbleSizeScale) en [ChartSeriesGroup.setBubbleSizeScale](https://reference.aspose.com/slides/nl/python-java/aspose.slides/chartseriesgroup/#setBubbleSizeScale)‑methoden. Het volgende voorbeeld laat zien hoe u bubbelgroottes kunt schalen.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 100, 100, 400, 300)

    chart.getChartData().getSeriesGroups().get_Item(0).setBubbleSizeScale(150)

    presentation.save("Result.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Gegevens weergeven als bubbelgrafiekgroottes**
De methoden [setBubbleSizeRepresentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/chartseriesgroup/#setBubbleSizeRepresentation) en [getBubbleSizeRepresentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/chartseriesgroup/#getBubbleSizeRepresentation) zijn beschikbaar in de [ChartSeriesGroup](https://reference.aspose.com/slides/nl/python-java/aspose.slides/chartseriesgroup/)‑klasse. De bubbelformaat‑representatie specificeert hoe de bubbelformaatwaarden worden weergegeven in de bubbelgrafiek. Mogelijke waarden zijn [BubbleSizeRepresentationType.Area](https://reference.aspose.com/slides/nl/python-java/aspose.slides/bubblesizerepresentationtype/#Area) en [BubbleSizeRepresentationType.Width](https://reference.aspose.com/slides/nl/python-java/aspose.slides/bubblesizerepresentationtype/#Width). De enumeratie [BubbleSizeRepresentationType](https://reference.aspose.com/slides/nl/python-java/aspose.slides/bubblesizerepresentationtype/) geeft de mogelijke manieren aan om gegevens weer te geven als bubbelgrafiekgroottes. Het volgende voorbeeld laat zien hoe u bubbels maakt die de breedte gebruiken.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BubbleSizeRepresentationType, ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 600, 400, True)

    chart.getChartData().getSeriesGroups().get_Item(0).setBubbleSizeRepresentation(BubbleSizeRepresentationType.Width)

    presentation.save("Presentation_BubbleSizeRepresentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Wordt een “bubbelgrafiek met 3‑D‑effect” ondersteund en hoe verschilt deze van een gewone?**

Ja. Er bestaat een apart grafiektype, “Bubble with 3-D”. Het past 3‑D‑styling toe op de bellen maar voegt geen extra as toe; de gegevens blijven X‑Y‑S (grootte). Het type is beschikbaar in de [grafiektype](https://reference.aspose.com/slides/nl/python-java/aspose.slides/charttype/)‑klasse.

**Is er een limiet op het aantal series en punten in een bubbelgrafiek?**

Er is geen harde limiet op API‑niveau; beperkingen worden bepaald door prestaties en de doel‑PowerPoint‑versie. Het wordt aanbevolen om het aantal punten redelijk te houden voor leesbaarheid en render‑snelheid.

**Hoe beïnvloedt export het uiterlijk van een bubbelgrafiek (PDF, afbeeldingen)?**

Exporteren naar ondersteunde formaten behoudt het uiterlijk van de grafiek; de weergave wordt uitgevoerd door de Aspose.Slides‑engine. Voor raster‑/vectorformaten gelden de algemene regels voor grafische weergave (resolutie, anti‑aliasing), dus kies een voldoende DPI voor afdrukken.