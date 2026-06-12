---
title: Beheer Tekstgedeelten in Presentaties met Java
linktitle: Tekstgedeelte
type: docs
weight: 70
url: /nl/java/portion/
keywords:
- tekstgedeelte
- tekstdeel
- tekstcoördinaten
- tekstpositie
- PowerPoint
- presentatie
- Java
- Aspose.Slides
description: "Leer hoe u tekstgedeelten in PowerPoint-presentaties kunt beheren met Aspose.Slides voor Java, waardoor de prestaties en maatwerk worden verbeterd."
---
## **Overzicht**

Een tekstgedeelte vertegenwoordigt een specifiek fragment tekst binnen een alinea en stelt u in staat om met dat fragment onafhankelijk van de omringende inhoud te werken. In Aspose.Slides kunnen gedeelten worden gebruikt wanneer u de positie van een tekstfragment moet ophalen, alleen een deel van een alinea wilt opmaken, of het tekstgedrag op een meer gedetailleerd niveau wilt beheersen.

Dit artikel laat zien hoe u met de `getCoordinates()`-methode de coördinaten van het begin van een gedeelte kunt ophalen. Het belicht ook veelvoorkomende scenario's met betrekking tot gedeelten, zoals het toepassen van een hyperlink op een enkel tekstfragment, begrijpen hoe opmaak wordt bepaald via het gedeelte, de alinea, het tekstframe en de thema‑erfenis, en het afhandelen van gevallen waarin een opgegeven lettertype niet beschikbaar is. Bovendien wordt vermeld dat tekstvulling, -kleur en -transparantie verschillend kunnen worden ingesteld voor individuele gedeelten binnen dezelfde alinea.

## **Coördinaten van een Tekstgedeelte Ophalen**
De [**getCoordinates()**](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IPortion#getCoordinates--) methode is toegevoegd aan de [IPortion](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iportion/) en [Portion](https://reference.aspose.com/slides/nl/java/com.aspose.slides/portion/) klassen, waarmee u de coördinaten van het begin van het gedeelte kunt ophalen.

```java
// Instantie van de Presentation-klasse die de PPTX vertegenwoordigt
Presentation pres = new Presentation();
try {
    // De context van de presentatie opnieuw vormgeven
    IAutoShape shape = (IAutoShape) pres.getSlides().get_Item(0).getShapes().get_Item(0);
    
    ITextFrame textFrame = (ITextFrame) shape.getTextFrame();
    
    for (IParagraph paragraph : textFrame.getParagraphs()) 
    {
        for (IPortion portion : paragraph.getPortions()) 
        {
            Point2D.Float point = portion.getCoordinates();
            System.out.println("X: " + point.x + " Y: " + point.y);
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Kan ik een hyperlink toepassen op slechts een deel van de tekst binnen één alinea?**  
Ja, u kunt een [hyperlink toewijzen](/slides/nl/java/manage-hyperlinks/) aan een individueel gedeelte; alleen dat fragment zal klikbaar zijn, niet de volledige alinea.

**Hoe werkt stijl‑erfenis: wat overschrijft een Portion en wat wordt overgenomen van Paragraph/TextFrame?**  
Eigenschappen op Portion‑niveau hebben de hoogste prioriteit. Als een eigenschap niet is ingesteld op de [Portion](https://reference.aspose.com/slides/nl/java/com.aspose.slides/portion/), haalt de engine deze van de [Paragraph](https://reference.aspose.com/slides/nl/java/com.aspose.slides/paragraph/); is deze daar ook niet ingesteld, dan van het [TextFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/textframe/) of de [theme](https://reference.aspose.com/slides/nl/java/com.aspose.slides/theme/)-stijl.

**Wat gebeurt er als het voor een Portion opgegeven lettertype ontbreekt op de doelmachine/server?**  
[Regels voor lettertype‑substitutie](/slides/nl/java/font-selection-sequence/) zijn van toepassing. De tekst kan opnieuw worden opgemaakt: metriek, koppeltekens en breedte kunnen veranderen, wat belangrijk is voor nauwkeurige positionering.

**Kan ik een op Portion specifiek tekstvullings‑transparantie of -gradient instellen, onafhankelijk van de rest van de alinea?**  
Ja, tekstkleur, -vulling en -transparantie op het niveau van de [Portion](https://reference.aspose.com/slides/nl/java/com.aspose.slides/portion/) kunnen verschillen van aangrenzende fragmenten.