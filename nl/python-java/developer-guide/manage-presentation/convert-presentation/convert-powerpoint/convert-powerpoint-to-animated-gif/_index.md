---
title: PowerPoint-presentaties converteren naar geanimeerde GIF's in Python
linktitle: PowerPoint naar GIF
type: docs
weight: 65
url: /nl/python-java/convert-powerpoint-to-animated-gif/
keywords:
- geanimeerde GIF
- PowerPoint converteren
- presentatie converteren
- dia converteren
- PPT converteren
- PPTX converteren
- PowerPoint naar GIF
- presentatie naar GIF
- dia naar GIF
- PPT naar GIF
- PPTX naar GIF
- PPT opslaan als GIF
- PPTX opslaan als GIF
- PPT exporteren als GIF
- PPTX exporteren als GIF
- standaardinstellingen
- aangepaste instellingen
- PowerPoint
- presentatie
- Python
- Java
- Aspose.Slides
description: "Converteer eenvoudig PowerPoint-presentaties (PPT, PPTX) naar geanimeerde GIF's met Aspose.Slides voor Python via Java. Snelle, hoogwaardige resultaten."
---
## **Overzicht**

Aspose.Slides for Python via Java maakt het mogelijk om PowerPoint‑presentaties om te zetten naar geanimeerde GIF‑bestanden met slechts een paar regels code. Dit is handig voor het delen van dia‑inhoud op webpagina’s, in messengers of in documentatie. Dit artikel legt uit hoe je een presentatie exporteert met de standaardinstellingen en hoe je de frame‑grootte, dia‑vertraging en overgang‑frame‑rate kunt aanpassen via [GifOptions](https://reference.aspose.com/slides/nl/python-java/aspose.slides/gifoptions/).

## **Presentaties converteren naar geanimeerde GIF met standaardinstellingen**

Het volgende Python‑voorbeeld laadt `pres.pptx` en slaat het op als een geanimeerde GIF met de standaardinstellingen:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    presentation.save("pres.gif", SaveFormat.Gif)
finally:
    presentation.dispose()
```

{{% alert color="success" title="Tip" %}}
Om de GIF‑output aan te passen, geef je een [GifOptions](https://reference.aspose.com/slides/nl/python-java/aspose.slides/gifoptions/)‑object mee bij het opslaan, zoals hieronder weergegeven.
{{% /alert %}}

## **Presentaties converteren naar geanimeerde GIF met aangepaste instellingen**

Gebruik [setFrameSize](https://reference.aspose.com/slides/nl/python-java/aspose.slides/gifoptions/#setFrameSize) om de uitvoergrootte in pixels op te geven, [setDefaultDelay](https://reference.aspose.com/slides/nl/python-java/aspose.slides/gifoptions/#setDefaultDelay) om de standaarddia‑vertraging in milliseconden in te stellen, en [setTransitionFps](https://reference.aspose.com/slides/nl/python-java/aspose.slides/gifoptions/#setTransitionFps) om de overgang‑frame‑rate te regelen.

Het volgende voorbeeld exporteert een GIF van 960 × 720 met een standaard dia‑vertraging van twee seconden en 35 frames per seconde voor overgangen. De standaardvertraging wordt toegepast wanneer de ‘advance‑after’‑tijd van de dia niet is ingesteld.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import GifOptions, Presentation, SaveFormat

Dimension = jpype.JClass("java.awt.Dimension")

presentation = Presentation("pres.pptx")
try:
    gif_options = GifOptions()
    frame_size = Dimension(960, 720)
    gif_options.setFrameSize(frame_size)
    gif_options.setDefaultDelay(2000)
    gif_options.setTransitionFps(35)

    presentation.save("pres.gif", SaveFormat.Gif, gif_options)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Opmerking" %}}
Je kunt ook Aspose’ gratis [Text to GIF](https://products.aspose.app/slides/nl/text-to-gif)‑converter uitproberen.
{{% /alert %}}

## **FAQ**

**Wat als de lettertypen die in de presentatie worden gebruikt niet op het systeem zijn geïnstalleerd?**

Installeer de ontbrekende lettertypen of [configureer fallback‑lettertypen](/slides/nl/python-java/powerpoint-fonts/). Vervanging van lettertypen kan het uiterlijk van de geëxporteerde GIF wijzigen. Het beschikbaar maken van de originele lettertypen is essentieel om het ontwerp van de presentatie te behouden.

**Kan ik een watermerk op de GIF‑frames plaatsen?**

Ja. [Voeg een semi‑transparant object of logo](/slides/nl/python-java/watermark/) toe aan de betreffende master‑dia’s of aan individuele dia’s vóór export. Het watermerk wordt onderdeel van de gerenderde dia‑inhoud.