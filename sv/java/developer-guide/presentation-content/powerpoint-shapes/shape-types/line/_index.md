---
title: Lägg till linjeformer i presentationer i Java
linktitle: Linje
type: docs
weight: 50
url: /sv/java/Line/
keywords:
- linje
- skapa linje
- lägga till linje
- vanlig linje
- konfigurera linje
- anpassa linje
- streckstil
- pilhuvud
- PowerPoint
- presentation
- Java
- Aspose.Slides
description: "Lär dig att manipulera linjeformatering i PowerPoint-presentationer med Aspose.Slides för Java. Upptäck egenskaper, metoder och exempel."
---
## **Översikt**

Aspose.Slides låter dig lägga till linjeformer i PowerPoint-bilder programmässigt. Den här artikeln visar hur du skapar en enkel linje och hur du anpassar en linje så att den ser ut som en pil.

Du kommer att lära dig hur du lägger till en linjeform på en bild, justerar dess visuella utseende och sparar den uppdaterade presentationen. Exemplen fokuserar på praktiska inställningar för linjeformatering såsom stil, bredd, streckmönster, pilarhuvudsalternativ och fyllningsfärg.

## **Skapa en enkel linje**

För att lägga till en enkel linje på en vald bild i presentationen, följ stegen nedan:

- Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Presentation).
- Hämta referensen till en bild genom att använda dess Index.
- Lägg till en AutoShape av typen Line med hjälp av metoden [addAutoShape](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) som exponeras av objektet [IShapeCollection](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IShapeCollection).
- Spara den modifierade presentationen som en PPTX‑fil.

I exemplet nedan har vi lagt till en linje på den första bilden i presentationen.

```java
// Instansiera PresentationEx-klass som representerar PPTX-filen
Presentation pres = new Presentation();
try {
    // Hämta den första bilden
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Lägg till en AutoShape av typ linje
    sld.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);
    
    // Skriv PPTX-filen till disk
    pres.save("LineShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Skapa en pilformad linje**

Aspose.Slides för Java låter också utvecklare konfigurera vissa egenskaper för linjen för att göra den mer attraktiv. Låt oss försöka konfigurera några egenskaper för en linje så att den ser ut som en pil. Följ stegen nedan för att göra det:

- Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Presentation).
- Hämta referensen till en bild genom att använda dess Index.
- Lägg till en AutoShape av typen Line med hjälp av metoden [addAutoShape](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) som exponeras av objektet [IShapeCollection](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IShapeCollection).
- Ställ in [Line Style](https://reference.aspose.com/slides/sv/java/com.aspose.slides/LineStyle) till en av de stilar som erbjuds av Aspose.Slides för Java.
- Ställ in bredden på linjen.
- Ställ in [Dash Style](https://reference.aspose.com/slides/sv/java/com.aspose.slides/LineDashStyle) för linjen till en av de stilar som erbjuds av Aspose.Slides för Java.
- Ställ in [Arrow Head Style](https://reference.aspose.com/slides/sv/java/com.aspose.slides/LineArrowheadStyle) och [Length](https://reference.aspose.com/slides/sv/java/com.aspose.slides/LineArrowheadLength) för linjens startpunkt.
- Ställ in [Arrow Head Style](https://reference.aspose.com/slides/sv/java/com.aspose.slides/LineArrowheadStyle) och [Length](https://reference.aspose.com/slides/sv/java/com.aspose.slides/LineArrowheadLength) för linjens slutpunkt.
- Spara den modifierade presentationen som en PPTX‑fil.

```java
// Instansiera PresentationEx-klass som representerar PPTX-filen
Presentation pres = new Presentation();
try {
    // Hämta den första bilden
    ISlide sld = pres.getSlides().get_Item(0);

    // Lägg till en AutoShape av typ linje
    IAutoShape shp = sld.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);

    // Tillämpa lite formatering på linjen
    shp.getLineFormat().setStyle(LineStyle.ThickBetweenThin);
    shp.getLineFormat().setWidth(10);

    shp.getLineFormat().setDashStyle(LineDashStyle.DashDot);

    shp.getLineFormat().setBeginArrowheadLength(LineArrowheadLength.Short);
    shp.getLineFormat().setBeginArrowheadStyle(LineArrowheadStyle.Oval);

    shp.getLineFormat().setEndArrowheadLength(LineArrowheadLength.Long);
    shp.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle);

    shp.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(new Color(PresetColor.Maroon));

    // Skriv PPTX-filen till disk
    pres.save("LineShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Vanliga frågor**

**Kan jag konvertera en vanlig linje till en connector så att den "snäpper" till former?**

Nej. En vanlig linje (en [AutoShape](https://reference.aspose.com/slides/sv/java/com.aspose.slides/autoshape/) av typen [Line](https://reference.aspose.com/slides/sv/java/com.aspose.slides/shapetype/)) blir inte automatiskt en connector. För att få den att snäppa till former, använd den dedikerade [Connector](https://reference.aspose.com/slides/sv/java/com.aspose.slides/connector/)‑typen och de [motsvarande API:er](/slides/sv/java/connector/) för anslutningar.

**Vad ska jag göra om en linjes egenskaper ärvs från temat och det är svårt att avgöra de slutliga värdena?**

[Läs de effektiva egenskaperna](/slides/sv/java/shape-effective-properties/) via gränssnitten [ILineFormatEffectiveData](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ilinefillformateffectivedata/) — dessa tar redan hänsyn till arv och temastilar.

**Kan jag låsa en linje så att den inte kan redigeras (flyttas, ändras i storlek)?**

Ja. Former tillhandahåller [lock objects](https://reference.aspose.com/slides/sv/java/com.aspose.slides/autoshape/#getAutoShapeLock--) som låter dig [förbjuda redigeringsåtgärder](/slides/sv/java/applying-protection-to-presentation/).