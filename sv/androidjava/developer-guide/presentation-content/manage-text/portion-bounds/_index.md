---
title: Hämta gränser för textavsnitt från presentationer på Android
linktitle: Avsnittsgränser
type: docs
weight: 47
url: /sv/androidjava/portion-bounds/
keywords:
- gränser för textavsnitt
- textavsnitt
- textdel
- textkoordinater
- textposition
- PowerPoint
- presentation
- Android
- Java
- Aspose.Slides
description: "Lär dig hur du hämtar gränser för textavsnitt i PowerPoint-presentationer med Aspose.Slides för Android via Java."
---
## **Översikt**

Ett textavsnitt representerar ett specifikt fragment av text i ett stycke och låter dig arbeta med det fragmentet oberoende av omgivande innehåll. I Aspose.Slides kan avsnitt användas när du behöver hämta gränserna för ett textfragment, tillämpa formatering på endast en del av ett stycke eller kontrollera textbeteende på en mer detaljerad nivå.

Den här artikeln visar hur du får den omgivande rektangeln för ett avsnitt genom att använda [IPortion.getRect](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IPortion#getRect--). Det visar också hur du får koordinaterna för början av ett avsnitt genom att använda [IPortion.getCoordinates](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IPortion#getCoordinates--). Dessutom belyser den vanliga scenarier relaterade till avsnitt, såsom att tillämpa en hyperlänk på ett enskilt textfragment, förstå hur formatering löses genom avsnitt, stycke, textram och temaarv, samt hantera situationer där ett specificerat teckensnitt saknas.

## **Hämta gränsen för ett textavsnitt**

Använd [IPortion.getRect](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IPortion#getRect--) för att hämta den omgivande rektangeln för ett textavsnitt:

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

## **Hämta koordinater för ett textavsnitt**

Använd [IPortion.getCoordinates](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IPortion#getCoordinates--) för att hämta koordinaterna för början av ett textavsnitt:

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

## **Vanliga frågor**

**Kan jag tillämpa en hyperlänk på endast en del av texten i ett enda stycke?**

Ja, du kan [tilldela en hyperlänk](/slides/sv/androidjava/manage-hyperlinks/) till ett enskilt avsnitt; endast det fragmentet blir klickbart, inte hela stycket.

**Hur fungerar stilarv: vad åsidosätter ett avsnitt, och vad tas från ett stycke eller en textram?**

Egenskaper på avsnittsnivå har högsta prioritet. Om en egenskap inte är inställd på [IPortion](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iportion/), tar Aspose.Slides den från [IParagraph](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iparagraph/). Om den inte är inställd där heller, använder Aspose.Slides stil från [ITextFrame](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/itextframe/) eller [theme](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/theme/).

**Vad händer om det teckensnitt som anges för ett avsnitt saknas på målmaskinen eller servern?**

[Font substitution rules](/slides/sv/androidjava/font-selection-sequence/) gäller. Texten kan omflöda: mått, avstavning och bredd kan förändras, vilket är viktigt för exakt positionering.

**Kan jag ställa in avsnittsspecifik fyllnadstransparens eller en gradient för texten oberoende av resten av stycket?**

Ja, textfärg, fyllnad och transparens på [IPortion](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iportion/)‑nivå kan skilja sig från närliggande fragment.