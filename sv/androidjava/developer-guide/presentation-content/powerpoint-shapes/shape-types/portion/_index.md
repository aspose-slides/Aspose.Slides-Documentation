---
title: Hantera textdelar i presentationer på Android
linktitle: Textdel
type: docs
weight: 70
url: /sv/androidjava/portion/
keywords:
- textdel
- textdel
- textkoordinater
- textposition
- PowerPoint
- presentation
- Android
- Java
- Aspose.Slides
description: "Lär dig hur du hanterar textdelar i PowerPoint-presentationer med Aspose.Slides för Android via Java, vilket förbättrar prestanda och anpassning."
---
## **Introduktion**

En textdel representerar ett specifikt fragment av text inom ett stycke och låter dig arbeta med det fragmentet oberoende av omgivande innehåll. I Aspose.Slides kan portioner användas när du behöver hämta positionen för ett textfragment, applicera formatering på endast en del av ett stycke eller kontrollera textbeteende på en mer detaljerad nivå.

## **Hämta koordinater för en textdel**
Metoden [**getCoordinates()**](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IPortion#getCoordinates--) har lagts till i klasserna [IPortion](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iportion/) och [Portion](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/portion/) vilket möjliggör att hämta koordinaterna för början av portionen.

```java
// Instansiera Presentation-klassen som representerar PPTX
Presentation pres = new Presentation();
try {
    // Omformar presentationens sammanhang
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

**Kan jag lägga till en hyperlänk på bara en del av texten inom ett enda stycke?**

Ja, du kan [tilldela en hyperlänk](/slides/sv/androidjava/manage-hyperlinks/) till en enskild portion; endast det fragmentet blir klickbart, inte hela stycket.

**Hur fungerar stilarv: vad åsidosätter en Portion, och vad tas från Paragraph/TextFrame?**

Egenskaper på nivå med Portion har högsta prioritet. Om en egenskap inte är inställd på [Portion](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/portion/), hämtas den av motorn från [Paragraph](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/paragraph/); om den inte är satt där heller, från [TextFrame](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/textframe/) eller [theme](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/theme/)-stilen.

**Vad händer om teckensnittet som anges för en Portion saknas på målmaskinen/servern?**

[Regler för teckensnittssubstitution](/slides/sv/androidjava/font-selection-sequence/) tillämpas. Texten kan flöda om: mått, avstavning och bredd kan förändras, vilket är viktigt för exakt positionering.

**Kan jag ställa in en Portion-specifik textfyllnadsgenomskinlighet eller gradient oberoende av resten av stycket?**

Ja, textfärg, fyllning och genomskinlighet på [Portion](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/portion/)-nivå kan skilja sig från angränsande fragment.