---
title: Hämta gränser för textdel i presentationer i Python via Java
linktitle: Portionsgränser
type: docs
weight: 47
url: /sv/python-java/portion-bounds/
keywords:
- gränser för textdel
- textdel
- textdel
- textkoordinater
- textposition
- PowerPoint
- presentation
- Python
- Java
- Aspose.Slides
description: "Lär dig hur du hämtar gränser för textdel i PowerPoint‑presentationer med Aspose.Slides för Python via Java."
---
## **Översikt**

En textdel representerar ett specifikt fragment av text i ett stycke och gör att du kan arbeta med det fragmentet oberoende av omgivande innehåll. I Aspose.Slides kan delar användas när du behöver hämta gränserna för ett textfragment, tillämpa formatering på endast en del av ett stycke eller kontrollera textbeteende på en mer detaljerad nivå.

Den här artikeln visar hur du får den begränsande rektangeln för en del genom att använda [Portion.getRect](https://reference.aspose.com/slides/sv/python-java/aspose.slides/portion/#getRect). Den visar också hur du får koordinaterna för början av en del genom att använda [Portion.getCoordinates](https://reference.aspose.com/slides/sv/python-java/aspose.slides/portion/#getCoordinates). Dessutom belyser den vanliga scenarier relaterade till delar, såsom att tillämpa en hyperlänk på ett enskilt textfragment, förstå hur formatering löses genom del, stycke, textruta och temaarv, samt hantera fall där ett angivet teckensnitt saknas.

## **Hämta gränser för en textdel**

Använd [Portion.getRect](https://reference.aspose.com/slides/sv/python-java/aspose.slides/portion/#getRect) för att hämta den begränsande rektangeln för en textdel:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("Shapes.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)

    for paragraph in shape.getTextFrame().getParagraphs():
        for portion in paragraph.getPortions():
            rectangle = portion.getRect()
            print(f"X = {rectangle.x}; Y = {rectangle.y}; Width = {rectangle.width}; Height = {rectangle.height}")
finally:
    presentation.dispose()
```

## **Hämta koordinater för en textdel**

Använd [Portion.getCoordinates](https://reference.aspose.com/slides/sv/python-java/aspose.slides/portion/#getCoordinates) för att hämta koordinaterna för början av en textdel:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("Shapes.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)

    for paragraph in shape.getTextFrame().getParagraphs():
        for portion in paragraph.getPortions():
            point = portion.getCoordinates()
            print(f"X = {point.x}; Y = {point.y}")
finally:
    presentation.dispose()
```

## **Vanliga frågor**

**Kan jag tillämpa en hyperlänk på endast en del av texten inom ett enda stycke?**

Ja, du kan [tilldela en hyperlänk](/slides/sv/python-java/manage-hyperlinks/) till en enskild del; endast det fragmentet blir klickbart, inte hela stycket.

**Hur fungerar stilarv: vad överskriver en del, och vad tas från ett stycke eller en textruta?**

Egenskaper på delnivå har högsta prioritet. Om en egenskap inte är angiven på [Portion](https://reference.aspose.com/slides/sv/python-java/aspose.slides/portion/), tar Aspose.Slides den från [Paragraph](https://reference.aspose.com/slides/sv/python-java/aspose.slides/paragraph/). Om den inte är angiven där heller, använder Aspose.Slides stilen från [TextFrame](https://reference.aspose.com/slides/sv/python-java/aspose.slides/textframe/) eller [theme](https://reference.aspose.com/slides/sv/python-java/aspose.slides/theme/).

**Vad händer om det teckensnitt som specificerats för en del saknas på målmaskinen eller servern?**

[Font substitution rules](/slides/sv/python-java/font-selection-sequence/) tillämpas. Texten kan flöda om: mått, avstavning och bredd kan ändras, vilket är viktigt för exakt positionering.

**Kan jag ställa in delspecifik textfyllningsgenomskinlighet eller en gradient oberoende av resten av stycket?**

Ja, textfärg, fyllning och genomskinlighet på [Portion](https://reference.aspose.com/slides/sv/python-java/aspose.slides/portion/)‑nivå kan skilja sig från närliggande fragment.