---
title: PowerPoint-dia's converteren naar PNG in Python
linktitle: PowerPoint naar PNG
type: docs
weight: 30
url: /nl/python-java/convert-powerpoint-to-png/
keywords:
- PowerPoint converteren
- presentatie converteren
- dia converteren
- PPT converteren
- PPTX converteren
- PowerPoint naar PNG
- presentatie naar PNG
- dia naar PNG
- PPT naar PNG
- PPTX naar PNG
- PPT opslaan als PNG
- PPTX opslaan als PNG
- PPT exporteren naar PNG
- PPTX exporteren naar PNG
- Python
- Java
- Aspose.Slides
description: "PowerPoint-dia's converteren naar PNG-afbeeldingen in Python via Java. PPT-, PPTX- en ODP-presentaties exporteren met aangepaste schalen of exacte afbeeldingsafmetingen."
---
## **Overzicht**

In dit artikel wordt uitgelegd hoe u PowerPoint‑presentaties naar PNG‑afbeeldingen kunt converteren met Aspose.Slides voor Python via Java. U kunt PPT‑, PPTX‑ en ODP‑bestanden laden, elke dia renderen en deze opslaan als een aparte PNG‑afbeelding.

De voorbeelden laten ook zien hoe u de uitvoergrootte kunt regelen met schaalfactoren of een exacte breedte en hoogte. Elk voorbeeld start de Java‑virtual machine indien nodig en geeft de presentatie‑ en afbeeldingsbronnen vrij na gebruik.

## **PowerPoint naar PNG converteren**

1. Laad het invoerbestand met de [Presentatie](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/) klasse.  
2. Haal de dia's op met [Presentation.getSlides](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/#getSlides).  
3. Render elke dia met [Slide.getImage](https://reference.aspose.com/slides/nl/python-java/aspose.slides/slide/#getImage).  
4. Sla elke gerenderde afbeelding op met [ImageFormat.Png](https://reference.aspose.com/slides/nl/python-java/aspose.slides/imageformat/#Png) en geef vervolgens de bronnen vrij.

Het volgende Python‑voorbeeld exporteert alle dia's in hun standaardgrootte:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("presentation.pptx")
try:
    for index, slide in enumerate(presentation.getSlides(), start=1):
        slide_image = slide.getImage()
        try:
            slide_image.save(f"slide_{index}.png", ImageFormat.Png)
        finally:
            slide_image.dispose()
finally:
    presentation.dispose()
```

## **PowerPoint naar PNG converteren met een aangepaste schaal**

Geef horizontale en verticale schaalfactoren door aan [Slide.getImage](https://reference.aspose.com/slides/nl/python-java/aspose.slides/slide/#getImage) om de uitvoergrootte te vergroten of te verkleinen. Bijvoorbeeld, een dia van 720 × 540 punten die wordt gerenderd met een schaalfactor van 2 op beide assen levert een afbeelding van 1440 × 1080 pixels op.

Gebruik gelijke schaalfactoren om de beeldverhouding van de dia te behouden. Verschillende factoren rekken de dia horizontaal of verticaal uit.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("presentation.pptx")
try:
    scale_x = 2.0
    scale_y = 2.0
    for index, slide in enumerate(presentation.getSlides(), start=1):
        slide_image = slide.getImage(scale_x, scale_y)
        try:
            slide_image.save(f"slide_scaled_{index}.png", ImageFormat.Png)
        finally:
            slide_image.dispose()
finally:
    presentation.dispose()
```

## **PowerPoint naar PNG converteren met een aangepaste grootte**

Om exacte pixelafmetingen op te geven, geeft u een Java `Dimension`‑object met de gewenste breedte en hoogte door aan [Slide.getImage](https://reference.aspose.com/slides/nl/python-java/aspose.slides/slide/#getImage). Kies afmetingen met dezelfde beeldverhouding als de oorspronkelijke dia om vervorming te voorkomen.

Het volgende voorbeeld slaat elke dia op als een PNG‑afbeelding van 960 × 720 pixels:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation
from java.awt import Dimension

presentation = Presentation("presentation.pptx")
try:
    image_size = Dimension(960, 720)
    for index, slide in enumerate(presentation.getSlides(), start=1):
        slide_image = slide.getImage(image_size)
        try:
            slide_image.save(f"slide_sized_{index}.png", ImageFormat.Png)
        finally:
            slide_image.dispose()
finally:
    presentation.dispose()
```

## **FAQ**

**Kan ik een afzonderlijke vorm, zoals een diagram of afbeelding, exporteren in plaats van de volledige dia?**

Ja. Aspose.Slides ondersteunt [het genereren van miniatuurafbeeldingen voor individuele vormen](/slides/nl/python-java/create-shape-thumbnails/), die u als PNG‑afbeeldingen kunt opslaan.

**Kan ik presentaties parallel op een server converteren?**

Gebruik een aparte presentatie‑instantie voor elke thread of elk proces, en gebruik unieke uitvoer‑paden om te voorkomen dat bestanden worden overschreven. Deel geen presentatie‑instantie tussen threads. Zie [Multithreading](/slides/nl/python-java/multithreading/).

**Wat zijn de beperkingen van de proefversie bij het exporteren naar PNG?**

De evaluatiemodus voegt een watermerk toe aan de uitvoer‑afbeeldingen en past [andere beperkingen](/slides/nl/python-java/licensing/) toe. Pas een licentie toe om deze beperkingen te verwijderen.