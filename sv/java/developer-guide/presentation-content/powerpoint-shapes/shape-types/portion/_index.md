---
title: Hantera textdelar i presentationer med Java
linktitle: Textdel
type: docs
weight: 70
url: /sv/java/portion/
keywords:
- textdel
- textdel
- textkoordinater
- textposition
- PowerPoint
- presentation
- Java
- Aspose.Slides
description: "Lär dig hur du hanterar textdelar i PowerPoint-presentationer med Aspose.Slides för Java, vilket förbättrar prestanda och anpassning."
---
## **Översikt**

En textdel representerar ett specifikt fragment av text i ett stycke och gör det möjligt att arbeta med det fragmentet oberoende av omgivande innehåll. I Aspose.Slides kan portioner användas när du behöver hämta positionen för ett textfragment, applicera formatering på bara en del av ett stycke eller kontrollera textbeteende på en mer detaljerad nivå.

Den här artikeln visar hur du får koordinaterna för början av en portion genom att använda `getCoordinates()`‑metoden. Den belyser också vanliga scenarier relaterade till portioner, såsom att tillämpa en hyperlänk på ett enskilt textfragment, förstå hur formatering löses genom portion, stycke, textram och temaarv, samt hantera fall där ett angivet teckensnitt saknas. Dessutom noteras att textfyllning, färg och transparens kan ställas in olika för enskilda portioner inom samma stycke.

## **Hämta koordinater för en textdel**
Metoden [**getCoordinates()**](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IPortion#getCoordinates--) har lagts till i klasserna [IPortion](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iportion/) och [Portion](https://reference.aspose.com/slides/sv/java/com.aspose.slides/portion/), vilket gör det möjligt att hämta koordinaterna för början av portionen.

```java
// Instansiera Presentation‑klassen som representerar PPTX
Presentation pres = new Presentation();
try {
    // Omforma kontexten för presentationen
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

## **Vanliga frågor**

**Kan jag tillämpa en hyperlänk på bara en del av texten i ett enda stycke?**

Ja, du kan [tilldela en hyperlänk](/slides/sv/java/manage-hyperlinks/) till en enskild portion; endast det fragmentet blir klickbart, inte hela stycket.

**Hur fungerar stilarv: vad åsidosätter en Portion, och vad tas från Paragraph/TextFrame?**

Egenskaper på Portion-nivå har högsta prioritet. Om en egenskap inte är inställd på [Portion](https://reference.aspose.com/slides/sv/java/com.aspose.slides/portion/) tar motorn den från [Paragraph](https://reference.aspose.com/slides/sv/java/com.aspose.slides/paragraph/); om den inte är inställd där heller, från [TextFrame](https://reference.aspose.com/slides/sv/java/com.aspose.slides/textframe/) eller stilen i [theme](https://reference.aspose.com/slides/sv/java/com.aspose.slides/theme/).

**Vad händer om det teckensnitt som anges för en Portion saknas på målmaskinen/-servern?**

[Regler för teckensnittssubstitution](/slides/sv/java/font-selection-sequence/) tillämpas. Texten kan omflöda: mått, avstavning och bredd kan förändras, vilket är viktigt för exakt positionering.

**Kan jag ange en Portion-specifik textfyllnads‑transparent eller gradient oberoende av resten av stycket?**

Ja, textfärg, fyllning och transparens på [Portion](https://reference.aspose.com/slides/sv/java/com.aspose.slides/portion/)-nivå kan skilja sig åt från intilliggande fragment.