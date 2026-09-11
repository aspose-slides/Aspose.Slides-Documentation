---
title: Lijnvormen toevoegen aan presentaties in Python via Java
linktitle: Lijn
type: docs
weight: 50
url: /nl/python-java/line/
keywords:
- lijn
- lijn maken
- lijn toevoegen
- gewone lijn
- lijn configureren
- lijn aanpassen
- streepjesstijl
- pijlkop
- PowerPoint
- presentatie
- Python
- Aspose.Slides
description: "Leer hoe u lijnopmaak in PowerPoint-presentaties kunt bewerken met Aspose.Slides voor Python via Java. Ontdek eigenschappen, methoden en voorbeelden."
---
## **Overzicht**

Aspose.Slides stelt u in staat om lijnvormen toe te voegen aan PowerPoint‑dia's via code. Dit artikel laat zien hoe u een eenvoudige lijn maakt en hoe u een lijn aanpast zodat deze eruitziet als een pijl.

U leert hoe u een lijnvorm aan een dia toevoegt, het uiterlijk aanpast en de bijgewerkte presentatie opslaat. De voorbeelden richten zich op praktische lijnopmaakinstellingen zoals stijl, breedte, streepjespatroon, pijlpuntenopties en vulkleur.

## **Maak een gewone lijn**

- Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/) .
- Verkrijg een verwijzing naar een dia op basis van de index.
- Voeg een lijnvorm toe met de methode [addAutoShape](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shapecollection/#addAutoShape) van het object [ShapeCollection](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shapecollection/) .
- Schrijf de aangepaste presentatie weg als een PPTX‑bestand.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

# Instantieer de Presentation-klasse die het PPTX‑bestand vertegenwoordigt.
presentation = Presentation()
try:
    # Haal de eerste dia op.
    slide = presentation.getSlides().get_Item(0)

    # Voeg een lijnvorm toe.
    slide.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0)

    # Schrijf het PPTX‑bestand naar schijf.
    presentation.save("LineShape.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Maak een pijlvormige lijn**

- Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/) .
- Verkrijg een verwijzing naar een dia op basis van de index.
- Voeg een lijnvorm toe met de methode [addAutoShape](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shapecollection/#addAutoShape) van het object [ShapeCollection](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shapecollection/) .
- Stel de [lijnstijl](https://reference.aspose.com/slides/nl/python-java/aspose.slides/linestyle/) in op een van de stijlen die Aspose.Slides for Python via Java biedt.
- Stel de breedte van de lijn in.
- Stel de [streepjesstijl](https://reference.aspose.com/slides/nl/python-java/aspose.slides/linedashstyle/) in op een van de stijlen die Aspose.Slides for Python via Java biedt.
- Stel de [arrowhead style](https://reference.aspose.com/slides/nl/python-java/aspose.slides/linearrowheadstyle/) en [length](https://reference.aspose.com/slides/nl/python-java/aspose.slides/linearrowheadlength/) in aan het begin van de lijn.
- Stel de [arrowhead style](https://reference.aspose.com/slides/nl/python-java/aspose.slides/linearrowheadstyle/) en [length](https://reference.aspose.com/slides/nl/python-java/aspose.slides/linearrowheadlength/) in aan het einde van de lijn.
- Schrijf de aangepaste presentatie weg als een PPTX‑bestand.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, LineArrowheadLength, LineArrowheadStyle, LineDashStyle, LineStyle, Presentation, PresetColor, SaveFormat, ShapeType

# Instantieer de Presentation-klasse die het PPTX-bestand vertegenwoordigt.
presentation = Presentation()
try:
    # Haal de eerste dia op.
    slide = presentation.getSlides().get_Item(0)

    # Voeg een lijnvorm toe.
    line = slide.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0)

    # Pas opmaak toe op de lijn.
    line_format = line.getLineFormat()
    line_format.setStyle(LineStyle.ThickBetweenThin)
    line_format.setWidth(10)

    line_format.setDashStyle(LineDashStyle.DashDot)

    line_format.setBeginArrowheadLength(LineArrowheadLength.Short)
    line_format.setBeginArrowheadStyle(LineArrowheadStyle.Oval)

    line_format.setEndArrowheadLength(LineArrowheadLength.Long)
    line_format.setEndArrowheadStyle(LineArrowheadStyle.Triangle)

    line_format.getFillFormat().setFillType(FillType.Solid)
    line_format.getFillFormat().getSolidFillColor().setPresetColor(PresetColor.Maroon)

    # Schrijf het PPTX-bestand naar schijf.
    presentation.save("LineShape.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Veelgestelde vragen**

**Kan ik een gewone lijn omzetten in een connector zodat deze “klikt” met vormen?**

Nee. Een gewone lijn (een [AutoShape](https://reference.aspose.com/slides/nl/python-java/aspose.slides/autoshape/) van type [Line](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shapetype/)) wordt niet automatisch een connector. Om deze aan vormen te laten klikken, gebruik het speciale type [Connector](https://reference.aspose.com/slides/nl/python-java/aspose.slides/connector/) en de [corresponding APIs](/slides/nl/python-java/connector/) voor verbindingen.

**Wat moet ik doen als de eigenschappen van een lijn geërfd zijn van het thema en het moeilijk is de uiteindelijke waarden te bepalen?**

Lees de [effective properties](/slides/nl/python-java/shape-effective-properties/) van de lijn en de vulling — deze houden al rekening met overerving en themastijlen.

**Kan ik een lijn vergrendelen tegen bewerken (verplaatsen, grootte aanpassen)?**

Ja. Vormen bieden [lock objects](https://reference.aspose.com/slides/nl/python-java/aspose.slides/autoshape/#getAutoShapeLock) waarmee u [disallow editing operations](/slides/nl/python-java/applying-protection-to-presentation/) .