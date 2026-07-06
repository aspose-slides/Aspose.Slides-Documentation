---
title: Hämta gränser för textdelar från presentationer i Java
linktitle: Gränser för del
type: docs
weight: 47
url: /sv/java/portion-bounds/
keywords:
- gränser för textdel
- textdel
- textdel
- textkoordinater
- textposition
- PowerPoint
- presentation
- Java
- Aspose.Slides
description: "Lär dig hur du hämtar gränser för textdelar i PowerPoint-presentationer med Aspose.Slides för Java."
---
## **Översikt**

En textdel representerar ett specifikt fragment av text i ett stycke och gör att du kan arbeta med det fragmentet oberoende av omgivande innehåll. I Aspose.Slides kan delar användas när du behöver hämta gränserna för ett textfragment, applicera formatering på endast en del av ett stycke eller kontrollera textbeteende på en mer detaljerad nivå.

Den här artikeln visar hur du får den omgivande rektangeln för en del genom att använda [IPortion.getRect](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IPortion#getRect--). Den visar också hur du får koordinaterna för början av en del genom att använda [IPortion.getCoordinates](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IPortion#getCoordinates--). Dessutom belyser den vanliga scenarier relaterade till delar, såsom att tillämpa en hyperlänk på ett enskilt textfragment, förstå hur formatering löses genom del, stycke, textram och temaarv, samt hantera fall där ett angivet teckensnitt saknas.

## **Hämta gränser för en textdel**

Använd [IPortion.getRect](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IPortion#getRect--) för att hämta den omgivande rektangeln för en textdel:

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

## **Hämta koordinater för en textdel**

Använd [IPortion.getCoordinates](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IPortion#getCoordinates--) för att hämta koordinaterna för början av en textdel:

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

## **Vanliga frågor**

**Kan jag applicera en hyperlänk på endast en del av texten i ett enda stycke?**

Ja, du kan [tilldela en hyperlänk](/slides/sv/java/manage-hyperlinks/) till en enskild del; endast det fragmentet blir klickbart, inte hela stycket.

**Hur fungerar stilarv: vad åsidosätter en del, och vad tas från ett stycke eller en textram?**

Egenskaper på delnivå har högsta prioritet. Om en egenskap inte är angiven på [IPortion](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iportion/), tar Aspose.Slides den från [IParagraph](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iparagraph/). Om den inte är angiven där heller, använder Aspose.Slides stil från [ITextFrame](https://reference.aspose.com/slides/sv/java/com.aspose.slides/itextframe/) eller [theme](https://reference.aspose.com/slides/sv/java/com.aspose.slides/theme/).

**Vad händer om det teckensnitt som angetts för en del saknas på målmaskinen eller servern?**

[Regler för teckensnittssubstitution](/slides/sv/java/font-selection-sequence/) tillämpas. Texten kan omflöda: mått, avstavning och bredd kan förändras, vilket är viktigt för exakt positionering.

**Kan jag ställa in delspecifik textfyllnadstransparens eller en gradient oberoende av resten av stycket?**

Ja, textfärg, fyllning och transparens på [IPortion](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iportion/) nivå kan skilja sig från närliggande fragment.