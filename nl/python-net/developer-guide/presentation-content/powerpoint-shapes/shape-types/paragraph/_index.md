---
title: Paragraafgrenzen ophalen uit presentaties in Python
linktitle: Paragraaf
type: docs
weight: 60
url: /nl/python-net/paragraph/
keywords:
- paragraafgrenzen
- tekstportiegrenzen
- paragraafcoördinaat
- portiecoördinaat
- paragraafgrootte
- tekstportiegrootte
- tekstframe
- PowerPoint
- OpenDocument
- presentatie
- Python
- Aspose.Slides
description: "Leer hoe u paragraaf- en tekstportiegrenzen kunt ophalen in Aspose.Slides voor Python via .NET om de tekstpositionering in PowerPoint- en OpenDocument-presentaties te optimaliseren."
---
## **Overzicht**

Dit artikel legt uit hoe u de grenzen, grootte en coördinaten van paragrafen en tekstporties in Aspose.Slides kunt verkrijgen. Het toont hoe u de rechthoek van een paragraaf in een `TextFrame` kunt ophalen met `get_rect()`, hoe u de coördinaten van een paragraaf en portie binnen een tabelcel‑tekstframe kunt krijgen, en belicht belangrijke details zoals meeteenheden, het effect van tekstomloop op grenzen, pixelconversie en effectieve paragraafopmaakwaarden.

## **Paragraaf- en portiecoördinaten ophalen in TextFrame**
Met Aspose.Slides voor Python via .NET kunnen ontwikkelaars nu de rechthoekige coördinaten voor een Paragraaf binnen de paragrafen‑collectie van een TextFrame ophalen. Het maakt ook mogelijk de coördinaten van een portie binnen de portie‑collectie van een paragraaf te verkrijgen. In dit onderwerp demonstreren we met een voorbeeld hoe u de rechthoekige coördinaten voor een paragraaf samen met de positie van een portie binnen die paragraaf kunt ophalen.

## **Rechthoekige coördinaten van paragraaf ophalen**
De nieuwe methode **GetRect()** is toegevoegd. Deze maakt het mogelijk de rechthoek met de grenzen van een paragraaf op te halen.

```py
import aspose.slides as slides

# Maak een Presentation-object aan dat een presentatiebestand voorstelt
with slides.Presentation(path + "Shapes.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    textFrame = shape.text_frame
    rect = textFrame.paragraphs[0].get_rect()
```

## **Grootte van paragraaf en portie binnen tabelceltekstframe ophalen** ##

Om de [Portion](https://reference.aspose.com/slides/nl/python-net/aspose.slides/portion/) of [Paragraph](https://reference.aspose.com/slides/nl/python-net/aspose.slides/paragraph/) grootte en coördinaten in een tabelcel‑tekstframe op te halen, kunt u de methoden [IPortion.GetRect](https://reference.aspose.com/slides/nl/python-net/aspose.slides/iportion/) en [IParagraph.GetRect](https://reference.aspose.com/slides/nl/python-net/aspose.slides/iparagraph/) gebruiken.

Deze voorbeeldcode demonstreert de beschreven operatie:

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

## **Veelgestelde vragen**

**In welke eenheden worden de coördinaten van een paragraaf en tekstporties geretourneerd?**

In points, waarbij 1 inch = 72 points. Dit geldt voor alle coördinaten en afmetingen op de dia.

**Heeft woordomloop invloed op de grenzen van een paragraaf?**

Ja. Als omloop is ingeschakeld in de [TextFrame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframe/), wordt de tekst afgebroken om binnen de breedte van het gebied te passen, waardoor de werkelijke grenzen van de paragraaf veranderen.

**Kunnen paragraafcoördinaten betrouwbaar worden omgezet naar pixels in de geëxporteerde afbeelding?**

Ja. Converteer points naar pixels met: pixels = points × (DPI / 72). Het resultaat hangt af van de DPI die is gekozen voor renderen/export.

**Hoe krijg ik de “effectieve” paragraafopmaakparameters, rekening houdend met stijl‑overerving?**

Gebruik de data‑structuur voor effectieve paragraafopmaak; deze retourneert de uiteindelijke samengevoegde waarden voor inspringingen, afstand, omloop, RTL en meer.