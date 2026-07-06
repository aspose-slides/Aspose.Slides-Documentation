---
title: Tekstgedeeltegrenzen ophalen uit presentaties in Java
linktitle: Gedeeltegrenzen
type: docs
weight: 47
url: /nl/java/portion-bounds/
keywords:
- tekstgedeeltegrenzen
- tekstgedeelte
- tekstdeel
- tekstcoördinaten
- tekstpositie
- PowerPoint
- presentatie
- Java
- Aspose.Slides
description: "Leer hoe u tekstgedeeltegrenzen kunt ophalen in PowerPoint-presentaties met Aspose.Slides voor Java."
---
## **Overzicht**

Een tekstgedeelte vertegenwoordigt een specifiek fragment van tekst binnen een alinea en stelt u in staat om met dat fragment onafhankelijk van de omringende inhoud te werken. In Aspose.Slides kunnen delen worden gebruikt wanneer u de grenzen van een tekstfragment moet ophalen, alleen een deel van een alinea moet opmaken, of het tekstgedrag op een meer gedetailleerd niveau moet regelen. Dit artikel laat zien hoe u de begrenzende rechthoek van een gedeelte kunt ophalen met behulp van [IPortion.getRect](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IPortion#getRect--). Het laat ook zien hoe u de coördinaten van het begin van een gedeelte kunt verkrijgen met behulp van [IPortion.getCoordinates](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IPortion#getCoordinates--). Daarnaast belicht het veelvoorkomende scenario's met betrekking tot gedeelten, zoals het toepassen van een hyperlink op een enkel tekstfragment, het begrijpen van hoe opmaak wordt afgehandeld via gedeelte, alinea, tekstkader en thema‑overerving, en het omgaan met gevallen waarin een opgegeven lettertype niet beschikbaar is.

## **Ophalen van de grenzen van een tekstgedeelte**

Gebruik [IPortion.getRect](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IPortion#getRect--) om de begrenzende rechthoek van een tekstgedeelte op te halen:

```java
Presentation presentation = new Presentation("Shapes.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);

    for (IParagraph paragraph : shape.getTextFrame().getParagraphs())
    {
        for (IPortion portion : paragraph.getPortions())
        {
            java.awt.geom.Rectangle2D.Float rectangle = portion.getRect();
            System.out.println("X = " + rectangle.x + "; Y = " + rectangle.y + "; Width = " + rectangle.width + "; Height = " + rectangle.height);
        }
    }
} finally {
    presentation.dispose();
}
```

## **Coördinaten van een tekstgedeelte**

Gebruik [IPortion.getCoordinates](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IPortion#getCoordinates--) om de coördinaten van het begin van een tekstgedeelte op te halen:

```java
Presentation presentation = new Presentation("Shapes.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);

    for (IParagraph paragraph : shape.getTextFrame().getParagraphs())
    {
        for (IPortion portion : paragraph.getPortions())
        {
            java.awt.geom.Point2D.Float point = portion.getCoordinates();
            System.out.println("X = " + point.x + "; Y = " + point.y);
        }
    }
} finally {
    presentation.dispose();
}
```

## **Veelgestelde vragen**

**Kan ik een hyperlink alleen toepassen op een deel van de tekst binnen één alinea?**

Ja, u kunt [een hyperlink toewijzen](/slides/nl/java/manage-hyperlinks/) aan een individueel gedeelte; alleen dat fragment zal klikbaar zijn, niet de hele alinea.

**Hoe werkt stijl‑overerving: wat overschrijft een gedeelte, en wat wordt overgenomen van een alinea of tekstkader?**

Eigenschappen op gedeelte‑niveau hebben de hoogste prioriteit. Als een eigenschap niet is ingesteld op de [IPortion](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iportion/), neemt Aspose.Slides deze over van de [IParagraph](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iparagraph/). Als deze daar ook niet is ingesteld, gebruikt Aspose.Slides de stijl van het [ITextFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/itextframe/) of van het [theme](https://reference.aspose.com/slides/nl/java/com.aspose.slides/theme/).

**Wat gebeurt er als het opgegeven lettertype voor een gedeelte ontbreekt op de doelmachine of server?**

[lettertypevervangingsregels](/slides/nl/java/font-selection-sequence/) worden toegepast. De tekst kan opnieuw vloeien: metriek, woordafbreking en breedte kunnen veranderen, wat van belang is voor nauwkeurige positionering.

**Kan ik portion‑specifieke tekstvullingdoorzichtigheid of een verloop onafhankelijk van de rest van de alinea instellen?**

Ja, tekstkleur, -vulling en -doorzichtigheid op het niveau van de [IPortion](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iportion/) kunnen verschillen van aangrenzende fragmenten.