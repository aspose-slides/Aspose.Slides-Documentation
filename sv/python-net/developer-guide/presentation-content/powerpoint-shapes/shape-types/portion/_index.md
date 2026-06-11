---
title: Hantera textavsnitt i presentationer med Python
linktitle: Textavsnitt
type: docs
weight: 70
url: /sv/python-net/portion/
keywords:
- textavsnitt
- textdel
- textkoordinater
- textposition
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Lär dig hur du hanterar textavsnitt i PowerPoint- och OpenDocument-presentationer med Aspose.Slides för Python via .NET, vilket förbättrar prestanda och anpassning."
---
## **Introduktion**

Ett textavsnitt representerar ett specifikt fragment av text inom ett stycke och låter dig arbeta med det fragmentet oberoende av omgivande innehåll. I Aspose.Slides kan avsnitt användas när du behöver hämta positionen för ett textfragment, tillämpa formatering på bara en del av ett stycke eller styra textbeteende på en mer detaljerad nivå.

## **Hämta koordinater för textavsnitt**

Metoden [get_coordinates](https://reference.aspose.com/slides/sv/python-net/aspose.slides/portion/get_coordinates/) har lagts till i klassen [Portion](https://reference.aspose.com/slides/sv/python-net/aspose.slides/portion/) som möjliggör att hämta koordinaterna för textavsnitt:

```py
import aspose.slides as slides

with slides.Presentation("HelloWorld.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    text_frame = shape.text_frame

    for paragraph in text_frame.paragraphs:
        for portion in paragraph.portions:
            point = portion.get_coordinates()
            print("Corrdinates X =" + str(point.x) + " Corrdinates Y =" + str(point.y))
```

## **FAQ**

**Kan jag tillämpa en hyperlänk på endast en del av texten inom ett enda stycke?**

Ja, du kan [tilldela en hyperlänk](/slides/sv/python-net/manage-hyperlinks/) till ett enskilt avsnitt; endast det fragmentet blir klickbart, inte hela stycket.

**Hur fungerar stilarv: vad åsidosätter ett Portion, och vad tas från Paragraph/TextFrame?**

Egenskaper på Portion-nivå har högsta prioritet. Om en egenskap inte är angiven på [Portion](https://reference.aspose.com/slides/sv/python-net/aspose.slides/portion/), hämtas den av motorn från [Paragraph](https://reference.aspose.com/slides/sv/python-net/aspose.slides/paragraph/); om den inte är angiven där heller, från [TextFrame](https://reference.aspose.com/slides/sv/python-net/aspose.slides/textframe/) eller [theme](https://reference.aspose.com/slides/sv/python-net/aspose.slides.theme/theme/)‑stilen.

**Vad händer om det teckensnitt som angivits för ett Portion saknas på målmaskinen/servern?**

[Font substitution rules](/slides/sv/python-net/font-selection-sequence/) tillämpas. Texten kan flöda om: mått, avstavning och bredd kan förändras, vilket är viktigt för exakt positionering.

**Kan jag ställa in en Portion-specifik textfyllnadsgenomskinlighet eller gradient oberoende av resten av stycket?**

Ja, textfärg, fyllning och genomskinlighet på [Portion](https://reference.aspose.com/slides/sv/python-net/aspose.slides/portion/)‑nivå kan skilja sig från intilliggande fragment.