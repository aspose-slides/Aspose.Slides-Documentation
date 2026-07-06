---
title: "Hämta gränser för textdelar i presentationer med Python"
linktitle: "Delgränser"
type: docs
weight: 47
url: /sv/python-net/portion-bounds/
keywords:
- "gränser för textdel"
- "textdel"
- "textdel"
- "textkoordinater"
- "textposition"
- "PowerPoint"
- "OpenDocument"
- "presentation"
- "Python"
- "Aspose.Slides"
description: "Lär dig hur du hämtar gränser för textdelar i PowerPoint- och OpenDocument-presentationer med Aspose.Slides för Python via .NET."
---
## **Översikt**

En textdel representerar ett specifikt fragment av text i ett stycke och gör det möjligt att arbeta med det fragmentet oberoende av omgivande innehåll. I Aspose.Slides kan delar användas när du behöver hämta gränserna för ett textfragment, tillämpa formatering på endast en del av ett stycke eller styra textbeteende på en mer detaljerad nivå.

Denna artikel visar hur du hämtar den avgränsande rektangeln för en del med hjälp av [Portion.get_rect](https://reference.aspose.com/slides/sv/python-net/aspose.slides/portion/get_rect/). Den visar också hur du får koordinaterna för början av en del med hjälp av [Portion.get_coordinates](https://reference.aspose.com/slides/sv/python-net/aspose.slides/portion/get_coordinates/). Dessutom lyfts vanliga scenarier relaterade till delar fram, såsom att applicera en hyperlänk på ett enskilt textfragment, förstå hur formatering löser sig genom del, stycke, textram och temaarv, samt hantera situationer där ett angivet teckensnitt saknas.

## **Hämta gränserna för en textdel**

Använd [Portion.get_rect](https://reference.aspose.com/slides/sv/python-net/aspose.slides/portion/get_rect/) för att hämta den avgränsande rektangeln för en textdel:

```py
import aspose.slides as slides

with slides.Presentation("Shapes.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    for paragraph in shape.text_frame.paragraphs:
        for portion in paragraph.portions:
            rectangle = portion.get_rect()
            print(f"X = {rectangle.x}; Y = {rectangle.y}; Width = {rectangle.width}; Height = {rectangle.height}")
```

## **Hämta koordinaterna för en textdel**

Använd [Portion.get_coordinates](https://reference.aspose.com/slides/sv/python-net/aspose.slides/portion/get_coordinates/) för att hämta koordinaterna för början av en textdel:

```py
import aspose.slides as slides

with slides.Presentation("Shapes.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    for paragraph in shape.text_frame.paragraphs:
        for portion in paragraph.portions:
            point = portion.get_coordinates()
            print(f"X = {point.x}; Y = {point.y}")
```

## **FAQ**

**Kan jag tillämpa en hyperlänk på endast en del av texten i ett enda stycke?**

Ja, du kan [tilldela en hyperlänk](/slides/sv/python-net/manage-hyperlinks/) till en enskild del; bara det fragmentet blir klickbart, inte hela stycket.

**Hur fungerar stilärvning: vad åsidosätter en del, och vad tas från ett stycke eller en textram?**

Egenskaper på delnivå har högsta prioritet. Om en egenskap inte är angiven på [Portion](https://reference.aspose.com/slides/sv/python-net/aspose.slides/portion/), hämtar Aspose.Slides den från [Paragraph](https://reference.aspose.com/slides/sv/python-net/aspose.slides/paragraph/). Om den inte heller är angiven där, använder Aspose.Slides stilen från [TextFrame](https://reference.aspose.com/slides/sv/python-net/aspose.slides/textframe/) eller [theme](https://reference.aspose.com/slides/sv/python-net/aspose.slides.theme/theme/).

**Vad händer om det teckensnitt som angivits för en del saknas på målmaskinen eller servern?**

[Font substitution rules](/slides/sv/python-net/font-selection-sequence/) tillämpas. Texten kan flöda om: metriker, avstavning och bredd kan förändras, vilket är viktigt för exakt positionering.

**Kan jag ställa in delspecifik genomskinlighet för textfyllning eller ett gradient oberoende av resten av stycket?**

Ja, textfärg, fyllning och genomskinlighet på [Portion](https://reference.aspose.com/slides/sv/python-net/aspose.slides/portion/) nivå kan skilja sig från intilliggande fragment.