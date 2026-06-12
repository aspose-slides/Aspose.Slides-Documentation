---
title: Beheer tekstgedeelten in presentaties in .NET
linktitle: Tekstgedeelte
type: docs
weight: 70
url: /nl/net/portion/
keywords:
- tekstgedeelte
- tekstdeel
- tekstcoördinaten
- tekstpositie
- PowerPoint
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Leer hoe u tekstgedeelten in PowerPoint-presentaties kunt beheren met Aspose.Slides voor .NET, en zo de prestaties en aanpasbaarheid verhoogt."
---
## **Overzicht**

Een tekstgedeelte vertegenwoordigt een specifiek fragment van tekst binnen een alinea en stelt u in staat om met dat fragment onafhankelijk van de omringende inhoud te werken. In Aspose.Slides kunnen gedeelten worden gebruikt wanneer u de positie van een tekstfragment moet ophalen, opmaak alleen op een deel van een alinea wilt toepassen, of het tekstgedrag op een meer gedetailleerd niveau wilt beheersen.

Dit artikel laat zien hoe u de coördinaten van het begin van een gedeelte kunt verkrijgen met de `GetCoordinates()`-methode. Het belicht ook veelvoorkomende scenario’s met betrekking tot gedeelten, zoals het toepassen van een hyperlink op een enkel tekstfragment, begrijpen hoe opmaak wordt afgehandeld via gedeelte, alinea, tekstvak en themaherf, en het afhandelen van gevallen waarin een opgegeven lettertype niet beschikbaar is. Bovendien wordt opgemerkt dat tekstvulling, kleur en transparantie verschillend kunnen worden ingesteld voor individuele gedeelten binnen dezelfde alinea.

## **Coördinaten van een Tekstgedeelte ophalen**
**GetCoordinates()**-methode is toegevoegd aan IPortion en de Portion‑klasse, waarmee de coördinaten van het begin van het gedeelte kunnen worden opgehaald:

```c#
using (Presentation presentation = new Presentation("Shapes.pptx"))
{
    IAutoShape shape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var textFrame = (ITextFrame)shape.TextFrame;

    foreach (var paragraph in textFrame.Paragraphs)
    {
        foreach (Portion portion in paragraph.Portions)
        {
            PointF point = portion.GetCoordinates();
            Console.Write(Environment.NewLine + "Corrdinates X =" + point.X + " Corrdinates Y =" + point.Y);
        }
    }
}
```

## **FAQ**

**Kan ik een hyperlink toepassen op slechts een deel van de tekst binnen één alinea?**

Ja, u kunt [een hyperlink toewijzen](/slides/nl/net/manage-hyperlinks/) aan een individueel gedeelte; alleen dat fragment zal klikbaar zijn, niet de hele alinea.

**Hoe werkt stijl‑overerving: wat overschrijft een Gedeelte, en wat wordt overgenomen van Alinea/tekstvak?**

Eigenschappen op gedeelte‑niveau hebben de hoogste prioriteit. Als een eigenschap niet is ingesteld op de [Portion](https://reference.aspose.com/slides/nl/net/aspose.slides/portion/), haalt de engine deze van de [Paragraph](https://reference.aspose.com/slides/nl/net/aspose.slides/paragraph/); als deze daar ook niet is ingesteld, van het [TextFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/textframe/) of de [theme](https://reference.aspose.com/slides/nl/net/aspose.slides.theme/theme/)-stijl.

**Wat gebeurt er als het opgegeven lettertype voor een Gedeelte ontbreekt op de doelsysteem/server?**

[Font substitution rules](/slides/nl/net/font-selection-sequence/) worden toegepast. De tekst kan opnieuw vloeien: metriek, afbreking en breedte kunnen veranderen, wat belangrijk is voor precieze positionering.

**Kan ik een specifieke tekstvulling, transparantie of verloop voor een Gedeelte instellen, onafhankelijk van de rest van de alinea?**

Ja, tekstkleur, vulling en transparantie op [Portion](https://reference.aspose.com/slides/nl/net/aspose.slides/portion/)-niveau kunnen verschillen van de aangrenzende fragmenten.