---
title: Hämta styckesgränser från presentationer i Python
linktitle: Stycke
type: docs
weight: 60
url: /sv/python-net/paragraph/
keywords:
- styckesgränser
- textdelgränser
- styckeskoordinat
- delkoordinat
- styckestorlek
- textdelstorlek
- textram
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Lär dig hur du hämtar styckes- och textdelgränser i Aspose.Slides för Python via .NET för att optimera textplacering i PowerPoint- och OpenDocument-presentationer."
---
## **Översikt**

Denna artikel förklarar hur man får gränserna, storleken och koordinaterna för stycken och textdelar i Aspose.Slides. Den visar hur man hämtar ett styckes rektangel i ett `TextFrame` med `get_rect()`, hur man får stycke- och delkoordinater inom en tabellcells textram, och lyfter fram viktiga detaljer såsom mätenheter, hur textomslag påverkar gränser, pixelkonvertering och effektiva formateringsvärden för stycke.

## **Hämta koordinater för stycke och del i TextFrame**
Med Aspose.Slides för Python via .NET kan utvecklare nu hämta de rektangulära koordinaterna för Paragraph i styckeskollektionen i ett TextFrame. Det möjliggör också att hämta koordinaterna för en del i delkollektionen för ett stycke. I detta avsnitt kommer vi att demonstrera med ett exempel hur man får de rektangulära koordinaterna för ett stycke samt positionen för en del inom ett stycke.

## **Hämta rektangulära koordinater för stycke**
Den nya metoden **GetRect()** har lagts till. Den möjliggör att hämta styckets avgränsningsrektangel.

```py
import aspose.slides as slides

# Skapa ett Presentation-objekt som representerar en presentationsfil
with slides.Presentation(path + "Shapes.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    textFrame = shape.text_frame
    rect = textFrame.paragraphs[0].get_rect()
```

## **Hämta storlek på stycke och del i tabellcells textram** ##

För att få storlek och koordinater för [Portion](https://reference.aspose.com/slides/sv/python-net/aspose.slides/portion/) eller [Paragraph](https://reference.aspose.com/slides/sv/python-net/aspose.slides/paragraph/) i en tabellcells textram kan du använda metoderna [IPortion.GetRect](https://reference.aspose.com/slides/sv/python-net/aspose.slides/iportion/) och [IParagraph.GetRect](https://reference.aspose.com/slides/sv/python-net/aspose.slides/iparagraph/).

Detta exempel på kod demonstrerar den beskrivna operationen:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation(path + "source.pptx") as pres:
    tbl = pres.slides[0].shapes[0]

    cell = tbl.rows[1][1]


    x = tbl.X + tbl.rows[1][1].offset_x
    y = tbl.Y + tbl.rows[1][1].offset_y

    for para in cell.text_frame.paragraphs:
        if para.text == "":
            continue

        rect = para.get_rect()
        shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE,
                rect.x + x, rect.y + y, rect.width, rect.height)

        shape.fill_format.fill_type = slides.FillType.NO_FILL
        shape.line_format.fill_format.solid_fill_color.color = draw.Color.yellow
        shape.line_format.fill_format.fill_type = slides.FillType.SOLID

        for portion in para.portions:
            if "0" in portion.text:
                rect = portion.get_rect()
                shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE,
                        rect.x + x, rect.y + y, rect.width, rect.height)

                shape.fill_format.fill_type = slides.FillType.NO_FILL
```

## **Vanliga frågor**

**I vilka enheter returneras koordinaterna för ett stycke och textdelar?**

I punkter, där 1 tum = 72 punkter. Detta gäller för alla koordinater och dimensioner på bilden.

**Påverkar ordbrytning ett styckes avgränsningar?**

Ja. Om [wrapping](https://reference.aspose.com/slides/sv/python-net/aspose.slides/textframeformat/wrap_text/) är aktiverat i [TextFrame](https://reference.aspose.com/slides/sv/python-net/aspose.slides/textframe/), bryts texten för att passa områdets bredd, vilket ändrar styckets faktiska avgränsningar.

**Kan stycke‑koordinater på ett pålitligt sätt konverteras till pixlar i den exporterade bilden?**

Ja. Konvertera punkter till pixlar med: pixels = points × (DPI / 72). Resultatet beror på den DPI som valts för renderingen/exporten.

**Hur får jag de ”effektiva” formateringsparametrarna för ett stycke, med hänsyn till stilarv?**

Använd den [effective paragraph formatting data structure](/slides/sv/python-net/shape-effective-properties/); den returnerar de slutgiltiga sammanställda värdena för indrag, avstånd, ombrytning, RTL och mer.