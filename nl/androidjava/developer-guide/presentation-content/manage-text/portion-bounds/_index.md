---
title: Tekstgedeelte grenzen ophalen uit presentaties op Android
linktitle: Gedeeltegrenzen
type: docs
weight: 47
url: /nl/androidjava/portion-bounds/
keywords:
- tekstgedeelte grenzen
- tekstgedeelte
- tekstdeel
- tekstcoördinaten
- tekstpositie
- PowerPoint
- presentatie
- Android
- Java
- Aspose.Slides
description: "Leer hoe u de grenzen van een tekstgedeelte in PowerPoint-presentaties kunt ophalen met Aspose.Slides voor Android via Java."
---
## **Overzicht**

Een tekstgedeelte vertegenwoordigt een specifiek fragment van tekst binnen een alinea en stelt u in staat om met dat fragment onafhankelijk van de omringende inhoud te werken. In Aspose.Slides kunnen delen worden gebruikt wanneer u de grenzen van een tekstfragment wilt ophalen, opmaak wilt toepassen op slechts een deel van een alinea, of tekstgedrag op een meer gedetailleerd niveau wilt regelen.

Dit artikel laat zien hoe u de omvattende rechthoek van een deel kunt verkrijgen met [IPortion.getRect](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IPortion#getRect--). Het toont ook hoe u de coördinaten van het begin van een deel kunt krijgen met [IPortion.getCoordinates](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IPortion#getCoordinates--). Bovendien worden veelvoorkomende scenario's met delen benadrukt, zoals het toepassen van een hyperlink op een enkel tekstfragment, begrijpen hoe opmaak wordt afgehandeld via deel, alinea, tekstframe en themaherfen, en het omgaan met gevallen waarin een opgegeven lettertype niet beschikbaar is.

## **Ophalen van de grenzen van een tekstgedeelte**

Gebruik [IPortion.getRect](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IPortion#getRect--) om de omvattende rechthoek van een tekstgedeelte op te halen:

```java
Presentation presentation = new Presentation("Shapes.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);

    for (IParagraph paragraph : shape.getTextFrame().getParagraphs())
    {
        for (IPortion portion : paragraph.getPortions())
        {
            android.graphics.RectF rectangle = portion.getRect();
            System.out.println("X = " + rectangle.left + "; Y = " + rectangle.top + "; Width = " + rectangle.width() + "; Height = " + rectangle.height());
        }
    }
} finally {
    presentation.dispose();
}
```

## **Ophalen van de coördinaten van een tekstgedeelte**

Gebruik [IPortion.getCoordinates](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IPortion#getCoordinates--) om de coördinaten van het begin van een tekstgedeelte op te halen:

```java
Presentation presentation = new Presentation("Shapes.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);

    for (IParagraph paragraph : shape.getTextFrame().getParagraphs())
    {
        for (IPortion portion : paragraph.getPortions())
        {
            PointF point = portion.getCoordinates();
            System.out.println("X = " + point.x + "; Y = " + point.y);
        }
    }
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Kan ik een hyperlink toepassen op slechts een deel van de tekst binnen één alinea?**

Ja, u kunt [een hyperlink toewijzen](/slides/nl/androidjava/manage-hyperlinks/) aan een individueel gedeelte; alleen dat fragment zal klikbaar zijn, niet de hele alinea.

**Hoe werkt stijl‑erfenis: wat overschrijft een deel, en wat wordt overgenomen van een alinea of tekstframe?**

Eigenschappen op deelniveau hebben de hoogste prioriteit. Als een eigenschap niet is ingesteld op de [IPortion](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iportion/), neemt Aspose.Slides deze over van de [IParagraph](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iparagraph/). Als deze daar ook niet is ingesteld, gebruikt Aspose.Slides de stijl van het [ITextFrame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/itextframe/) of van het [theme](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/theme/).

**Wat gebeurt er als het opgegeven lettertype voor een deel ontbreekt op de doelmachine of server?**

[Lettertype vervangingsregels](/slides/nl/androidjava/font-selection-sequence/) worden toegepast. De tekst kan opnieuw worden opgemaakt: metrieken, afbreking en breedte kunnen veranderen, wat van belang is voor precieze positionering.

**Kan ik deel‑specifieke tekstvullende transparantie of een gradient instellen, onafhankelijk van de rest van de alinea?**

Ja, tekstkleur, vulling en transparantie op het niveau van de [IPortion](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iportion/) kunnen verschillen van aangrenzende fragmenten.