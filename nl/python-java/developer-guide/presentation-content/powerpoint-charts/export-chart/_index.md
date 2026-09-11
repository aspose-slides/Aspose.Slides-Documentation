---
title: Export Presentatie Diagrammen in Python via Java
linktitle: Export Diagram
type: docs
weight: 90
url: /nl/python-java/export-chart/
keywords:
- diagram
- diagram naar afbeelding
- diagram als afbeelding
- diagramafbeelding extraheren
- PowerPoint
- presentatie
- Python
- Java
- Aspose.Slides
description: "Leer hoe u presentatiediagrammen kunt exporteren met Aspose.Slides voor Python via Java, met ondersteuning voor PPT- en PPTX-formaten, en stroomlijn rapportage in elke workflow."
---
## **Overzicht**

Aspose.Slides stelt je in staat om een diagram uit een presentatie te exporteren als een afbeelding. Dit artikel laat zien hoe je een afbeelding van een diagram kunt krijgen en opslaan, wat handig is wanneer je diagramvisualisaties buiten een PowerPoint‑presentatie moet hergebruiken.

Naast de basisworkflow voor het exporteren van afbeeldingen behandelt het artikel ook veelvoorkomende vragen over export, waaronder het opslaan van diagraminhoud naar SVG, het regelen van de uitvoergrootte via renderopties, het laden van lettertypen om het uiterlijk van labels en legenda te behouden, en het behouden van de oorspronkelijke opmaak van de presentatie, zoals thema's, stijlen, vullingen en effecten tijdens het renderen.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, ImageFormat, Presentation

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)

    chart_image = chart.getImage()
    try:
        chart_image.save("image.jpg", ImageFormat.Jpeg)
    finally:
        chart_image.dispose()
finally:
    presentation.dispose()
```

## **Een diagramafbeelding ophalen**

Aspose.Slides voor Python via Java ondersteunt het extraheren van een afbeelding van een specifiek diagram. Het volgende voorbeeld laat zien hoe je dit kunt doen.

## **FAQ**

**Kan ik een diagram exporteren als een vector (SVG) in plaats van een rasterafbeelding?**

Ja. Een diagram is een vorm, en de inhoud ervan kan worden opgeslagen als SVG met de [shape-to-SVG‑opslaagmethode](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shape/#writeAsSvgToBytes).

**Hoe kan ik de exacte grootte van het geëxporteerde diagram in pixels instellen?**

Gebruik de overloads voor afbeeldingsrendering waarmee je de grootte of schaal kunt specificeren – de bibliotheek ondersteunt het renderen van objecten met opgegeven afmetingen/schaal.

**Wat moet ik doen als lettertypen in labels en de legenda er na export verkeerd uitzien?**

[Laad de vereiste lettertypen](/slides/nl/python-java/custom-font/) via [FontsLoader](https://reference.aspose.com/slides/nl/python-java/aspose.slides/fontsloader/) zodat de rendering van het diagram metriek en tekstopmaak behoudt.

**Houdt de export rekening met het PowerPoint‑thema, stijlen en effecten?**

Ja. De renderer van Aspose.Slides volgt de opmaak van de presentatie (thema’s, stijlen, vullingen, effecten), zodat het uiterlijk van het diagram behouden blijft.

**Waar kan ik de beschikbare render‑/exportmogelijkheden vinden naast diagramafbeeldingen?**

Zie de [API](https://reference.aspose.com/slides/nl/python-java/aspose.slides/)/[documentatie](/slides/nl/python-java/convert-powerpoint/) voor uitvoerdoelen ([PDF](/slides/nl/python-java/convert-powerpoint-to-pdf/), [SVG](/slides/nl/python-java/render-a-slide-as-an-svg-image/), [XPS](/slides/nl/python-java/convert-powerpoint-to-xps/), [HTML](/slides/nl/python-java/convert-powerpoint-to-html/), enz.) en gerelateerde renderopties.