---
title: Beheer tekstgedeelten in presentaties met C++
linktitle: Tekstgedeelte
type: docs
weight: 70
url: /nl/cpp/portion/
keywords:
- tekstgedeelte
- tekstdeel
- tekstcoördinaten
- tekstpositie
- PowerPoint
- presentatie
- C++
- Aspose.Slides
description: "Leer hoe u tekstgedeelten in PowerPoint-presentaties kunt beheren met Aspose.Slides voor C++, waardoor de prestaties en aanpassing worden verbeterd."
---
## **Inleiding**

Een tekstgedeelte vertegenwoordigt een specifiek fragment tekst binnen een alinea en stelt u in staat om met dat fragment onafhankelijk van de omliggende inhoud te werken. In Aspose.Slides kunnen gedeelten worden gebruikt wanneer u de positie van een tekstfragment moet ophalen, opmaak alleen op een deel van een alinea wilt toepassen, of het gedrag van tekst op een meer gedetailleerd niveau wilt regelen.

## **Coördinaten van een Tekstgedeelte Ophalen**
**GetCoordinates()**-methode is toegevoegd aan de IPortion- en Portion-klasse, waarmee de coördinaten van het begin van het gedeelte kunnen worden opgehaald:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"Shapes.pptx");
auto shape = System::ExplicitCast<IAutoShape>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
auto textFrame = shape->get_TextFrame();

for (const auto& paragraph : textFrame->get_Paragraphs())
{
    for (const auto& portion : paragraph->get_Portions())
    {
        PointF point = portion->GetCoordinates();
        Console::WriteLine(String(u"Coordinates X =") + point.get_X() + u" Coordinates Y =" + point.get_Y());
    }
}
```

## **FAQ**

**Kan ik een hyperlink toepassen op slechts een deel van de tekst binnen één alinea?**

Ja, u kunt een [hyperlink toewijzen](/slides/nl/cpp/manage-hyperlinks/) aan een afzonderlijk gedeelte; alleen dat fragment zal klikbaar zijn, niet de hele alinea.

**Hoe werkt stijl‑erfenis: wat overschrijft een Portion en wat wordt overgenomen van Paragraph/TextFrame?**

Eigenschappen op Portion‑niveau hebben de hoogste prioriteit. Als een eigenschap niet ingesteld is op de [Portion](https://reference.aspose.com/slides/nl/cpp/aspose.slides/portion/), haalt de engine deze op van de [Paragraph](https://reference.aspose.com/slides/nl/cpp/aspose.slides/paragraph/); als die er ook niet is ingesteld, van het [TextFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/textframe/) of de stijl van het [theme](https://reference.aspose.com/slides/nl/cpp/aspose.slides.theme/theme/).

**Wat gebeurt er als het opgegeven lettertype voor een Portion ontbreekt op de doelmachine/server?**

[Lettertypevervangingsregels](/slides/nl/cpp/font-selection-sequence/) zijn van toepassing. De tekst kan opnieuw worden opgemaakt: metriek, afbreking en breedte kunnen veranderen, wat van belang is voor een precieze positionering.

**Kan ik een Portion‑specifieke transparantie of verloop voor tekstvulling instellen, onafhankelijk van de rest van de alinea?**

Ja, tekstkleur, vulling en transparantie op het [Portion](https://reference.aspose.com/slides/nl/cpp/aspose.slides/portion/) niveau kunnen afwijken van aangrenzende fragmenten.