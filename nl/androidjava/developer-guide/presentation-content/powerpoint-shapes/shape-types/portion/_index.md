---
title: Beheer tekstgedeelten in presentaties op Android
linktitle: Tekstgedeelte
type: docs
weight: 70
url: /nl/androidjava/portion/
keywords:
- tekstgedeelte
- tekstdeel
- tekstcoördinaten
- tekstpositie
- PowerPoint
- presentatie
- Android
- Java
- Aspose.Slides
description: "Leer hoe u tekstgedeelten in PowerPoint-presentaties kunt beheren met Aspose.Slides voor Android via Java, waardoor de prestaties en maatwerk worden verbeterd."
---
## **Inleiding**

Een tekstgedeelte vertegenwoordigt een specifiek fragment van tekst binnen een alinea en stelt u in staat om met dat fragment onafhankelijk van de omringende inhoud te werken. In Aspose.Slides kunnen gedeelten worden gebruikt wanneer u de positie van een tekstfragment wilt opvragen, opmaak wilt toepassen op slechts een deel van een alinea, of het tekstgedrag op een gedetailleerder niveau wilt beheersen.

## **Coördinaten van een tekstgedeelte opvragen**
De [**getCoordinates()**](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IPortion#getCoordinates--) methode is toegevoegd aan de [IPortion](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iportion/) en [Portion](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/portion/) klasse, waardoor de coördinaten van het begin van het gedeelte kunnen worden opgehaald.

```java
// Instantieer de Presentation-klasse die de PPTX voorstelt
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

Ja, u kunt [een hyperlink toewijzen](/slides/nl/androidjava/manage-hyperlinks/) aan een individueel gedeelte; alleen dat fragment zal klikbaar zijn, niet de volledige alinea.

**Hoe werkt stijl‑overerving: wat overschrijft een Portion en wat wordt overgenomen van Paragraph/TextFrame?**

Eigenschappen op gedeelte‑niveau hebben de hoogste prioriteit. Als een eigenschap niet is ingesteld op de [Portion](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/portion/), neemt de engine deze over van de [Paragraph](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/paragraph/); als deze daar ook niet is ingesteld, van de [TextFrame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/textframe/) of de [theme](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/theme/) stijl.

**Wat gebeurt er als het voor een Portion opgegeven lettertype ontbreekt op de doelmachine/server?**

[Lettertype‑vervangingsregels](/slides/nl/androidjava/font-selection-sequence/) worden toegepast. De tekst kan opnieuw doorstromen: metrieken, afbreking en breedte kunnen wijzigen, wat van belang is voor nauwkeurige positionering.

**Kan ik een Portion-specifieke tekstvulling, transparantie of gradient instellen, onafhankelijk van de rest van de alinea?**

Ja, tekstkleur, vulling en transparantie op het [Portion](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/portion/) niveau kunnen verschillen van aangrenzende fragmenten.